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
    public partial class Final_Q : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
        Username un;
        string status = "Approved Waiting for Conformation";
        DataTable dataTable = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            un = Session["UName"] as Username;
            con.Open();
            SqlCommand cms = new SqlCommand("SELECT * FROM Final_Main where Status = @s AND File_Name = @f", con);
            cms.Parameters.AddWithValue("@s", SqlDbType.VarChar).Value = status;
            cms.Parameters.AddWithValue("@f", SqlDbType.VarChar).Value = un.Name.ToString();
            DropDownList1.DataSource = cms.ExecuteReader();
            DropDownList1.DataTextField = "Quo_Id";
            DropDownList1.DataValueField = "Rec_Id";
            DropDownList1.DataBind();
            con.Close();
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
            this.LabelQid.Text = DropDownList1.SelectedItem.Text.ToString();
            if (con.State != ConnectionState.Closed)
            {
                con.Close();
            }
            con.Open();
            string query = "SELECT B.For_Quoid, B.Date, B.Total, B.File_Name, BS.Item, BS.Qty, BS.Unitre_Price, BS.Amount FROM Final_Main B INNER JOIN Final_Sub BS ON B.Quo_Id = BS.Quo_Id where B.Quo_Id = '" + this.LabelQid.Text.ToString() + "'";
            SqlCommand getcmd = new SqlCommand(query, con);
            SqlDataReader sdr = getcmd.ExecuteReader();
            dataTable.Columns.Add("Item");
            dataTable.Columns.Add("Qty");
            dataTable.Columns.Add("Unite Price");
            dataTable.Columns.Add("Amount");
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    LabelForQID.Text = sdr[0].ToString();
                    LabelDT.Text = sdr[1].ToString();
                    LabelTotal.Text = sdr[2].ToString();
                    LabelFileName.Text = sdr[3].ToString();
                    DataRow row = dataTable.NewRow();
                    row["Item"] = sdr["Item"];
                    row["Qty"] = sdr["Qty"];
                    row["Unite Price"] = sdr["Unitre_Price"];
                    row["Amount"] = sdr["Amount"];
                    dataTable.Rows.Add(row);
                }
                GridView1.DataSource = dataTable;
                GridView1.DataBind();
            }
            con.Close();
            LabelNote.Text = "Note* The Prices may vary depending on the market conditions.";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int ans = updatedata();
            if(ans == 1)
            {
                MsgBox("You Have successfully accepted the Quotation and the Company will get in touch with you soon", this.Page, this);
            }
            else
            {
                MsgBox("Error Found Please Try again",this.Page,this);
            }
        }

        private int updatedata()
        {
            int ans = 0;
            string status1 = "Confirmed";
            if (con.State != ConnectionState.Closed)
                con.Close();
            try
            {
                con.Open();
                string query = "UPDATE Final_Main SET Status = @S WHERE Quo_Id = @Q";
                SqlCommand updatecmd = new SqlCommand(query, con);
                updatecmd.Parameters.AddWithValue("@S", SqlDbType.VarChar).Value = status1;
                updatecmd.Parameters.AddWithValue("@Q", SqlDbType.VarChar).Value = this.LabelQid.Text.ToString();
                updatecmd.ExecuteNonQuery();
                ans++;
            }
            catch(Exception ex)
            {
                MsgBox(ex.ToString(), this.Page, this);
            }
            finally
            {
                con.Close();
            }            
            return ans;
        }
    }
}