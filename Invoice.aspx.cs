using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1
{
    public partial class Invoice : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
        int count,getcount1 = 0;
        DataTable dt = new DataTable();
        public double gst;
        double finalamt = 0.00;
        protected void Page_Load(object sender, EventArgs e)
        {
            Label7.Text = DateTime.Now.Date.ToString("d-M-yyyy");
            GetBillNo();
            GetProjectName();
            if(!IsPostBack)
            {
                if (ViewState["Records"] == null)
                {
                    dt.Columns.Add("Product Name");
                    dt.Columns.Add("Quantity");
                    dt.Columns.Add("Unite Price");
                    dt.Columns.Add("GST @");
                    dt.Columns.Add("SGST");
                    dt.Columns.Add("CGST");
                    dt.Columns.Add("Amount");
                    ViewState["Records"] = dt;
                }
            }
        }

        public void MsgBox(String ex, Page pg, Object obj)
        {
            string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        }

        private void GetProjectName()
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            string query = "select Project_Name from Projects";
            SqlCommand command = new SqlCommand(query, con);
            DataTable dt1 = new DataTable();
            dt1.Load(command.ExecuteReader());
            con.Close();
            DropDownList3.DataSource = dt1;
            DropDownList3.DataTextField = "Project_Name";
            DropDownList3.DataValueField = "Project_Name";
            DropDownList3.DataBind();
        }

        void GetBillNo()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from Sales_Main", con);
            count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                count = count + 1;
            }
            else
            {
                count = 1;
            }
            Label6.Text = count.ToString();
            con.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(TextName.Text == "")
            {
                Alert.show("Please enter the Product Name");
            }
            else if(TextQuantity.Text == "")
            {
                Alert.show("The Quantity Field cannot be empty");
            }
            else if(Convert.ToDouble(TextQuantity.Text) <= 0)
            {
                Alert.show("The Quantity Field cannot be 0 or less than 0");
            }
            else if (TextPrice.Text == "")
            {
                Alert.show("The Price Field cannot be empty");
            }
            else if (Convert.ToDouble(TextPrice.Text) <= 0)
            {
                Alert.show("The Price Field cannot be 0 or less than 0");
            }
            else
            {
                double tot = Convert.ToDouble(this.TextPrice.Text) * Convert.ToDouble(this.TextQuantity.Text);
                double gstamt = tot * Getgst();
                tot = tot + gstamt;
                dt = (DataTable)ViewState["Records"];
                dt.Rows.Add(TextName.Text, TextQuantity.Text, TextPrice.Text, DropDownGST.SelectedItem.Text, gstamt / 2, gstamt / 2, tot);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                getfinalamt();
            }
        }

        private void getfinalamt()
        {
            foreach(GridViewRow g in GridView1.Rows)
            {
                finalamt = finalamt + Convert.ToDouble(g.Cells[6].Text);
            }
            Label3.Text = finalamt.ToString();
        }

        private double Getgst()
        {
            if(DropDownGST.SelectedItem.Text == "5%")
            {
                gst = 0.05;
            }
            else if(DropDownGST.SelectedItem.Text == "12%")
            {
                gst = 0.12;
            }
            else if(DropDownGST.SelectedItem.Text == "18%")
            {
                gst = 0.18;
            }
            else if(DropDownGST.SelectedItem.Text == "28%")
            {
                gst = 0.28;
            }
            return gst;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int c2 = 1;
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            SqlCommand insertdata = new SqlCommand("Sales_Bill_Add", con);
            insertdata.CommandType = CommandType.StoredProcedure;
            try
            {
                foreach (GridViewRow gr in GridView1.Rows)
                {
                    insertdata.Parameters.AddWithValue("@bno", SqlDbType.Int).Value = this.Label6.Text.ToString();
                    insertdata.Parameters.AddWithValue("@dt", SqlDbType.Date).Value = DateTime.Now.Date.ToString();
                    insertdata.Parameters.AddWithValue("@prjName", SqlDbType.VarChar).Value = this.DropDownList3.SelectedItem.Text.ToString();
                    insertdata.Parameters.AddWithValue("@btyp", SqlDbType.VarChar).Value = this.DropDownList1.SelectedItem.Text.ToString();
                    insertdata.Parameters.AddWithValue("@cust", SqlDbType.BigInt).Value = this.Label9.Text.ToString();
                    insertdata.Parameters.AddWithValue("@cont", SqlDbType.BigInt).Value = this.Label10.Text.ToString();
                    insertdata.Parameters.AddWithValue("@tot", SqlDbType.Decimal).Value = Decimal.Parse(this.Label3.Text.ToString());
                    insertdata.Parameters.AddWithValue("@itm", SqlDbType.VarChar).Value = gr.Cells[0].Text.ToString();
                    insertdata.Parameters.AddWithValue("@qty", SqlDbType.Int).Value = gr.Cells[1].Text.ToString();
                    insertdata.Parameters.AddWithValue("@uniP", SqlDbType.Decimal).Value = Decimal.Parse(gr.Cells[2].Text.ToString());
                    insertdata.Parameters.AddWithValue("@GST@", SqlDbType.VarChar).Value = gr.Cells[3].Text.ToString();
                    insertdata.Parameters.AddWithValue("@SGST", SqlDbType.Decimal).Value = Decimal.Parse(gr.Cells[4].Text.ToString());
                    insertdata.Parameters.AddWithValue("@CGST", SqlDbType.Decimal).Value = Decimal.Parse(gr.Cells[5].Text.ToString());
                    insertdata.Parameters.AddWithValue("@Amt", SqlDbType.Decimal).Value = Decimal.Parse(gr.Cells[6].Text.ToString());
                    insertdata.Parameters.AddWithValue("@CNT", SqlDbType.Int).Value = c2;
                    insertdata.ExecuteNonQuery();
                    c2++;
                }
            }
            catch(Exception ex)
            {
                MsgBox(ex.ToString(), this.Page, this);
            }
            finally
            {
                con.Close();
                MsgBox("Data Inserted", this.Page, this);
            }
            cleardata();
            Response.Redirect(Request.RawUrl);
        }

        private void cleardata()
        {
            dt.Rows.Clear();
            GridView1.DataSource = null;
            GridView1.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand getdata = new SqlCommand("Select Full_Name,User_Name,Email from [User] where Phone = @ph", con);
            getdata.Parameters.AddWithValue("@ph", SqlDbType.BigInt).Value = this.Label9.Text;
            SqlDataReader dr = getdata.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Label1.Text = dr[0].ToString();
                    Label2.Text = dr[1].ToString();
                    Label5.Text = dr[2].ToString();
                }
            }
            con.Close();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string text = DropDownList1.SelectedItem.Text.ToString();
            if (text == "Select Option")
            {
                MsgBox("Please select the Bill Type", this.Page, this);
            }
            else
            {
                check();
            }
        }

        private void check()
        {
            getcount1 = AuthenticateData();
            if (getcount1 == 1)
            {
                MsgBox("The Sales Bill Already Exists for this project", this.Page, this);
            }
            else
            {
                GenerateUsers();
                GeneratePM();
                mySection01.Visible = false;
                Generateinvoice.Visible = true;
            }
        }

        private int AuthenticateData()
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            string query = "Select Project_Name from Sales_Main where Bill_Type = @t";
            SqlCommand checkcmd = new SqlCommand(query, con);
            checkcmd.Parameters.AddWithValue("@t", SqlDbType.VarChar).Value = this.DropDownList1.SelectedItem.Text.ToString();
            SqlDataReader sdr1 = checkcmd.ExecuteReader();
            if (sdr1.HasRows)
            {
                while (sdr1.Read())
                {
                    getcount1 = 1;
                }
            }
            con.Close();
            return getcount1;
        }

        private void GenerateUsers()
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            string q = "select Owner_Info,Project_Manager_Info from Projects where Project_Name = @prjn";
            SqlCommand getcmd2 = new SqlCommand(q, con);
            getcmd2.Parameters.AddWithValue("@prjn", SqlDbType.VarChar).Value = this.DropDownList3.SelectedItem.Text.ToString();
            SqlDataReader sdr2 = getcmd2.ExecuteReader();
            if (sdr2.HasRows)
            {
                while (sdr2.Read())
                {
                    this.Label9.Text = sdr2["Owner_Info"].ToString();
                    this.Label10.Text = sdr2["Project_Manager_Info"].ToString();
                }
            }
            con.Close();
        }

        private void GeneratePM()
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            string q1 = "select Employee_Name from Employee where Phone = @PH";
            SqlCommand getemp = new SqlCommand(q1, con);
            getemp.Parameters.AddWithValue("@PH", SqlDbType.BigInt).Value = this.Label10.Text.ToString();
            SqlDataReader sdr3 = getemp.ExecuteReader();
            if (sdr3.HasRows)
            {
                while (sdr3.Read())
                {
                    this.TextBox2.Text = sdr3["Employee_Name"].ToString();
                }
            }
            con.Close();
        }
    }
}