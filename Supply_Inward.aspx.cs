using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Supply_Inward : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
        DataTable dt = new DataTable();
        public double gst;
        public double amt;
        double finalamt = 0.00;
        double discamt = 0.00;
        double ftotal = 0.00;
        public double damt;
        int count = 0;

        public void MsgBox(String ex, Page pg, Object obj)
        {
            string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            //inserting data to grid
            if (TextName.Text == "")
            {
                Alert.show("Please enter the Product Name");
            }
            else if (TextQuantity.Text == "")
            {
                Alert.show("The Quantity Field cannot be empty");
            }
            else if (Convert.ToDouble(TextQuantity.Text) <= 0)
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
                amt = getamt();
                Label1.Text = amt.ToString();
                Label5.Text = amt.ToString();
            }
            cleardata();
        }

        private double getftotal(double a,double b)
        {
            //getting Final Amount
            if (DropDownList1.SelectedItem.Text == "%")
            {
                ftotal = a * b;
                Label4.Text = ftotal.ToString();
                ftotal = a - ftotal;
            }
            else if(DropDownList1.SelectedItem.Text == "Rs")
            {
                ftotal = a - b;
                Label4.Text = b.ToString();
            }
            return ftotal;
        }

        private double getDiscount()
        {
            //Getting Discount in % and in Rs
            if(DropDownList1.SelectedItem.Text == "%")
            {
                discamt = Convert.ToDouble(this.TextBox5.Text) / 100;
            }
            else if(DropDownList1.SelectedItem.Text == "Rs")
            {
                discamt = Convert.ToDouble(this.TextBox5.Text);
            }
            return discamt;
        }

        private double getamt()
        {
            //Getting Amount
            foreach (GridViewRow g in GridView1.Rows)
            {
                finalamt = finalamt + Convert.ToDouble(g.Cells[6].Text);
            }
            return finalamt;
        }

        private double Getgst()
        {
            //Getting GST
            if (DropDownGST.SelectedItem.Text == "5%")
            {
                gst = 0.05;
            }
            else if (DropDownGST.SelectedItem.Text == "12%")
            {
                gst = 0.12;
            }
            else if (DropDownGST.SelectedItem.Text == "18%")
            {
                gst = 0.18;
            }
            else if (DropDownGST.SelectedItem.Text == "28%")
            {
                gst = 0.28;
            }
            return gst;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //Calculating Discount Amount
            damt = getDiscount();
            ftotal = getftotal(Convert.ToDouble(Label1.Text), damt);
            Label5.Text = ftotal.ToString();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int ct1 = 1;
            try
            {
                count = checkbill_No();
                if (count == 1)
                {
                    MsgBox("! This Bill Number already exists !", this.Page, this);
                }
                else
                {
                    con.Open();
                    SqlCommand insertdata = new SqlCommand("Purchase", con);
                    insertdata.CommandType = CommandType.StoredProcedure;
                    foreach (GridViewRow gr in GridView1.Rows)
                    {
                        insertdata.Parameters.AddWithValue("@Invoice_Number", SqlDbType.NVarChar).Value = this.TextBox1.Text;
                        insertdata.Parameters.AddWithValue("@Invoice_Date", SqlDbType.Date).Value = Convert.ToDateTime(this.TextBox3.Text);
                        insertdata.Parameters.AddWithValue("@Order_Number", SqlDbType.NVarChar).Value = this.DropDownList2.SelectedItem.Text.ToString();
                        insertdata.Parameters.AddWithValue("@Supplier_Info", SqlDbType.BigInt).Value = this.TextBox4.Text;
                        insertdata.Parameters.AddWithValue("@Item_Name", SqlDbType.VarChar).Value = gr.Cells[0].Text.ToString();
                        insertdata.Parameters.AddWithValue("@Qty", SqlDbType.Int).Value = gr.Cells[1].Text.ToString();
                        insertdata.Parameters.AddWithValue("@Unite_Price", SqlDbType.Decimal).Value = Decimal.Parse(gr.Cells[2].Text.ToString());
                        insertdata.Parameters.AddWithValue("@GST", SqlDbType.VarChar).Value = gr.Cells[3].Text.ToString();
                        insertdata.Parameters.AddWithValue("@CGST", SqlDbType.Decimal).Value = Decimal.Parse(gr.Cells[4].Text.ToString());
                        insertdata.Parameters.AddWithValue("@SGST", SqlDbType.Decimal).Value = Decimal.Parse(gr.Cells[5].Text.ToString());
                        insertdata.Parameters.AddWithValue("@Amount", SqlDbType.Decimal).Value = Decimal.Parse(gr.Cells[6].Text.ToString());
                        insertdata.Parameters.AddWithValue("@Discount", SqlDbType.Decimal).Value = Decimal.Parse(this.Label4.Text.ToString());
                        insertdata.Parameters.AddWithValue("@Total", SqlDbType.Decimal).Value = Decimal.Parse(this.Label5.Text.ToString());
                        insertdata.Parameters.AddWithValue("@CNT", SqlDbType.Int).Value = ct1;
                        insertdata.ExecuteNonQuery();
                        insertdata.Parameters.Clear();
                        ct1++;
                    }    
                }
            }
            catch (Exception ex)
            {
                MsgBox(ex.ToString(), this.Page, this);
            }
            finally
            {
                clearalldata();
                MsgBox("Records inserted successfully", this.Page, this);
                con.Close();
            } 
        }

        private void clearalldata()
        {
            this.Label4.Text = "0.00";
            this.Label5.Text = "0.00";
            this.Label1.Text = "0.00";
            this.Label2.Text = "0.00";
            this.Label6.Text = "";
            this.Label7.Text = "";
            this.TextName.Text = "";
            this.TextPrice.Text = "";
            this.TextQuantity.Text = "";
            this.TextBox5.Text = "0.00";
            this.TextBox1.Text = "";
            //this.TextBox2.Text = "";
            this.TextBox4.Text = "";
            dt.Rows.Clear();
            GridView1.DataSource = null;
            GridView1.DataBind();
        }

        private void cleardata()
        {
            this.TextName.Text = "";
            this.TextPrice.Text = "";
            this.TextQuantity.Text = "";
        }

        private int checkbill_No()
        {
            //Checking if Bill already exists
            con.Open();
            SqlCommand cmd = new SqlCommand("select count(*) from Purchase_Main where Invoice_Number = @inv_No", con);
            cmd.Parameters.AddWithValue("@inv_No", SqlDbType.VarChar).Value = this.TextBox1.Text;
            count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                count = 1;
            }
            con.Close();
            return count;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            string qry = "SELECT Supplier_Name,Email,GSTin FROM Supplier_Det WHERE Phone = @p";
            SqlCommand getcmd = new SqlCommand(qry, con);
            getcmd.Parameters.AddWithValue("@p", SqlDbType.BigInt).Value = this.TextBox4.Text;
            SqlDataReader sdr = getcmd.ExecuteReader();
            if(sdr.HasRows)
            {
                while (sdr.Read())
                {
                    this.Label3.Text = sdr["Supplier_Name"].ToString();
                    this.Label6.Text = sdr["GSTin"].ToString();
                    this.Label7.Text = sdr["Email"].ToString();
                }
            }
            con.Close();
            gettotaltransaction();
            checkOrderID();
        }

        private void gettotaltransaction()
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            string query = "SELECT SUM(Total) FROM Purchase_Main WHERE Supplier_Info = @s";
            SqlCommand getcmd1 = new SqlCommand(query, con);
            getcmd1.Parameters.AddWithValue("@s",SqlDbType.BigInt).Value = this.TextBox4.Text;
            SqlDataReader sdr2 = getcmd1.ExecuteReader();
            if (sdr2.HasRows)
            {
                while (sdr2.Read())
                {
                    Label2.Text = sdr2[0].ToString();
                }
            }
            con.Close();
        }

        private void checkOrderID()
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            string q = "SELECT Order_Id FROM Order_Main WHERE Supplier_Phone = @p AND Status != @st";
            SqlCommand cmd = new SqlCommand(q, con);
            cmd.Parameters.AddWithValue("@p", SqlDbType.BigInt).Value = this.TextBox4.Text;
            cmd.Parameters.AddWithValue("@st", SqlDbType.VarChar).Value = "Delivered";
            DataTable dt1 = new DataTable();
            dt1.Load(cmd.ExecuteReader());
            con.Close();
            DropDownList2.DataSource = dt1;
            DropDownList2.DataTextField = "Order_Id";
            DropDownList2.DataValueField = "Order_Id";
            DropDownList2.DataBind();
            con.Close();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            string q1 = "UPDATE Order_Main SET Status = @s1 WHERE Order_Id = @OI";
            SqlCommand setstatus = new SqlCommand(q1, con);
            setstatus.Parameters.AddWithValue("@s1", SqlDbType.VarChar).Value = "Delivered";
            setstatus.Parameters.AddWithValue("@OI", SqlDbType.VarChar).Value = this.DropDownList2.SelectedItem.Text.ToString();
            setstatus.ExecuteNonQuery();
            MsgBox("Status Updated", this.Page, this);
            con.Close();
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            string q1 = "UPDATE Order_Main SET Status = @s2 WHERE Order_Id = @OI";
            SqlCommand setstatus1 = new SqlCommand(q1, con);
            setstatus1.Parameters.AddWithValue("@s2", SqlDbType.VarChar).Value = "Partially Delivered";
            setstatus1.Parameters.AddWithValue("@OI", SqlDbType.VarChar).Value = this.DropDownList2.SelectedItem.Text.ToString();
            setstatus1.ExecuteNonQuery();
            MsgBox("Status Updated", this.Page, this);
            con.Close();
        }
    }
}