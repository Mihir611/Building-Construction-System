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
    public partial class place_Order : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
        DataTable dt = new DataTable();
        int count = 0;
        int finalamt = 0;
        int finalqty = 0;
        string orderid;
        string company = "BCP";
        protected void Page_Load(object sender, EventArgs e)
        {
            //cleardata();
            count = getOrderid();
            orderid = company + count + "/" + DateTime.Now.Date.ToString("dMyyyy");
            Label3.Text = orderid.ToString();
            Label7.Text = DateTime.Now.Date.ToString();
            if (!IsPostBack)
            {
                if (ViewState["Records"] == null)
                {
                    dt.Columns.Add("Item Name");
                    dt.Columns.Add("Quantity");
                    dt.Columns.Add("Unite Price");
                    dt.Columns.Add("Amount");
                    ViewState["Records"] = dt;
                }
            }
        }

        private int getOrderid()
        {
            con.Open();
            string query = "SELECT COUNT(Order_Id) FROM Order_tab";
            SqlCommand getorder = new SqlCommand(query, con);
            count = Convert.ToInt32( getorder.ExecuteScalar());
            if (count > 0)
                count = count + 1;
            else
                count = 1;
            return count;
        }

        public void MsgBox(String ex, Page pg, Object obj)
        {
            string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(con.State != ConnectionState.Closed)
                con.Close();
            //getting supplier info
            con.Open();
            string query = "SELECT Supplier_Name,Email,GSTin FROM Supplier_Det WHERE Phone = @ph";
            SqlCommand fetchcmd = new SqlCommand(query, con);
            fetchcmd.Parameters.AddWithValue("@ph", SqlDbType.BigInt).Value = this.TextBox1.Text;
            SqlDataReader sdr = fetchcmd.ExecuteReader();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    Label1.Text = sdr[0].ToString();
                    Label2.Text = sdr[1].ToString();
                    Label6.Text = sdr[2].ToString();
                }
            }
            else
            {
                MsgBox("Reord dosent exists", this.Page, this);
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //Adding data to Grid
            if (TextName.Text == "")
            {
                Alert.show("Please enter the Product Name");
            }
            else if (TextQty.Text == "")
            {
                Alert.show("The Quantity Field cannot be empty");
            }
            else if (Convert.ToDouble(TextQty.Text) <= 0)
            {
                Alert.show("The Quantity Field cannot be 0 or less than 0");
            }
            else if (TextPrice.Text == "")
            {
                Alert.show("The Price Field cannot be empty");
            }
            else
            {
                double tot = Convert.ToDouble(this.TextPrice.Text) * Convert.ToDouble(this.TextQty.Text);
                dt = (DataTable)ViewState["Records"];
                dt.Rows.Add(TextName.Text, TextQty.Text, TextPrice.Text,tot);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                finalqty = getfinalqty();
                finalamt = getfinalamt();
                Label4.Text = finalqty.ToString();
                Label5.Text = finalamt.ToString();
                clearinput();
            }
        }

        private void clearinput()
        {
            //clearing data after adding to grid
            TextName.Text = "";
            TextPrice.Text = "";
            TextQty.Text = "";
        }

        private int getfinalqty()
        {
            //fn to get total qty
            foreach (GridViewRow g in GridView1.Rows)
            {
                finalqty = finalqty + Convert.ToInt32(g.Cells[1].Text);
            }
            return finalqty;
        }

        private int getfinalamt()
        {
            //function to get total amount
            foreach (GridViewRow g in GridView1.Rows)
            {
                finalamt = finalamt + Convert.ToInt32(g.Cells[3].Text);
            }
            return finalamt;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int cnt = 1;
            DateTime d;
            string data;
            if (TextBox2.Text == "")
                data = "No Narration";
            else
                data = TextBox2.Text;
            d = Convert.ToDateTime(Label7.Text);
            //Saving to database
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            try
            {
                SqlCommand insertdata = new SqlCommand("Order_Info", con);
                insertdata.CommandType = CommandType.StoredProcedure;
                foreach (GridViewRow gr in GridView1.Rows)
                {
                    insertdata.Parameters.AddWithValue("@Order_Id", SqlDbType.VarChar).Value = this.Label3.Text.ToString();
                    insertdata.Parameters.AddWithValue("@OrderDate", SqlDbType.Date).Value = d;
                    insertdata.Parameters.AddWithValue("@Supplier_Phone", SqlDbType.BigInt).Value = this.TextBox1.Text;
                    insertdata.Parameters.AddWithValue("@Status", SqlDbType.VarChar).Value = "Not Delivered";
                    insertdata.Parameters.AddWithValue("@Narration", SqlDbType.VarChar).Value = data.ToString();
                    insertdata.Parameters.AddWithValue("@Total", SqlDbType.Decimal).Value = Decimal.Parse(this.Label5.Text.ToString());
                    insertdata.Parameters.AddWithValue("@Item", SqlDbType.VarChar).Value = gr.Cells[0].Text.ToString();
                    insertdata.Parameters.AddWithValue("@Qty", SqlDbType.Int).Value = gr.Cells[1].Text.ToString();
                    insertdata.Parameters.AddWithValue("@Uni_Price", SqlDbType.Decimal).Value = Decimal.Parse(gr.Cells[2].Text.ToString());
                    insertdata.Parameters.AddWithValue("@Amount", SqlDbType.Decimal).Value = Decimal.Parse(gr.Cells[3].Text.ToString());
                    insertdata.Parameters.AddWithValue("@CNT", SqlDbType.Int).Value = cnt;
                    insertdata.ExecuteNonQuery();
                    insertdata.Parameters.Clear();
                    cnt++;
                }
            }
            catch (Exception ex)
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
            this.TextBox1.Text = "";
            this.TextBox2.Text = "";
            Label1.Text = "";
            Label2.Text = "";
            Label3.Text = "";
            Label4.Text = "0.00";
            Label5.Text = "0.00";
            Label6.Text = "";
            dt.Rows.Clear();
            GridView1.DataSource = null;
            GridView1.DataBind();
        }
    }
}