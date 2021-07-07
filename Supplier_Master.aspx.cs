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
    public partial class Supplier_Master : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
        int checkdata = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

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
            if (TextBox1.Text == "")
                MsgBox("Please enter the Supplier Name", this.Page, this);
            else if (TextBox2.Text == "")
                MsgBox("Please enter the Supplier's Address", this.Page, this);
            else if (TextBox3.Text == "")
                MsgBox("Please Enter the GST/UIN Number", this.Page, this);
            else if (TextBox4.Text == "")
                MsgBox("PLease enter the contact person's name", this.Page, this);
            else if (TextBox5.Text == "")
                MsgBox("Please enter the company's phone number", this.Page, this);
            else if (TextBox6.Text == "")
                MsgBox("Please enter the Email Id of the company", this.Page, this);
            else
            {
                try
                {
                    checkdata = check();
                    if (checkdata == 1)
                        MsgBox("The Company Info already exists", this.Page, this);
                    else
                    {
                        con.Open();
                        string query = "INSERT INTO Supplier_Det VALUES(@name,@add,@Tin,@conc,@ph,@em,@fx)";
                        SqlCommand insertcmd = new SqlCommand(query, con);
                        insertcmd.Parameters.AddWithValue("@name", SqlDbType.VarChar).Value = this.TextBox1.Text;
                        insertcmd.Parameters.AddWithValue("@add", SqlDbType.VarChar).Value = this.TextBox2.Text;
                        insertcmd.Parameters.AddWithValue("@Tin", SqlDbType.VarChar).Value = this.TextBox3.Text;
                        insertcmd.Parameters.AddWithValue("@conc", SqlDbType.VarChar).Value = this.TextBox4.Text;
                        insertcmd.Parameters.AddWithValue("@ph", SqlDbType.BigInt).Value = this.TextBox5.Text;
                        insertcmd.Parameters.AddWithValue("@em", SqlDbType.VarChar).Value = this.TextBox6.Text;
                        insertcmd.Parameters.AddWithValue("@fx", SqlDbType.BigInt).Value = this.TextBox7.Text;
                        insertcmd.ExecuteNonQuery();
                        MsgBox("Records inserted successfully", this.Page, this);
                        cleardata();
                    }
                }
                catch(Exception ex)
                {
                    MsgBox(ex.ToString(), this.Page, this);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void cleardata()
        {
            this.TextBox1.Text = "";
            this.TextBox2.Text = "";
            this.TextBox3.Text = "";
            this.TextBox4.Text = "";
            this.TextBox5.Text = "";
            this.TextBox6.Text = "";
            this.TextBox7.Text = "";
        }

        private int check()
        {
            con.Open();
            SqlCommand checkcommand = new SqlCommand("select count(*) from Supplier_Det", con);
            checkdata = Convert.ToInt32(checkcommand.ExecuteScalar());
            if (checkdata > 0)
                checkdata = 1;
            else
                checkdata = -1;
            con.Close();
            return checkdata;
        }
    }
}