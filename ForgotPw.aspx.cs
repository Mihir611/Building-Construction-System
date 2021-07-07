using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class ForgotPw : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
        int status = 0;
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
            if(TextBox1.Text == "")
            {
                MsgBox("Please enter the User Name", this.Page, this);
            }
            else if(TextBox2.Text == "" && this.TextBox1.Text == "no data")
            {
                MsgBox("Please enter the Email ID", this.Page, this);
            }
            else
            {
                if (con.State != ConnectionState.Closed)
                    con.Close();
                try
                {
                    if (this.TextBox1.Text != "")
                    {
                        if (this.TextBox1.Text != "no data")
                        {
                            con.Open();
                            string Query = "select Phone from [User] where User_Name = @u";
                            SqlCommand getcmd = new SqlCommand(Query, con);
                            getcmd.Parameters.AddWithValue("@u", SqlDbType.VarChar).Value = this.TextBox1.Text;
                            SqlDataReader sdr = getcmd.ExecuteReader();
                            if (sdr.HasRows)
                            {
                                while (sdr.Read())
                                {
                                    this.Button2.Text = "Change Password";
                                    this.pass1.Visible = true;
                                    this.Button1.Visible = false;
                                    this.Button2.Visible = true;
                                }
                            }
                            else
                            {
                                Label1.Text = "User Dosent Exist Please check the user name";
                                Button2.Enabled = false;
                            }
                        }
                    }

                    if (this.TextBox2.Text != "")
                    {
                        con.Close();
                        con.Open();
                        string Query = "select Phone from [User] where Email = @e";
                        SqlCommand getcmd = new SqlCommand(Query, con);
                        getcmd.Parameters.AddWithValue("@e", SqlDbType.VarChar).Value = this.TextBox2.Text;
                        SqlDataReader sdr = getcmd.ExecuteReader();
                        if (sdr.HasRows)
                        {
                            while (sdr.Read())
                            {
                                this.Button2.Text = "Change Password";
                                this.pass1.Visible = true;
                                this.Button1.Visible = false;
                                this.Button2.Visible = true;
                            }
                        }
                        else
                        {
                            Label2.Text = "Email Dosent Exist Please check the EmailID";
                            Button2.Enabled = false;
                        }
                    }
                }
                catch
                {
                    MsgBox("Connection to the server failed please try again", this.Page, this);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            this.TextBox1.Text = "no data";
            this.pass.Visible = false;
            this.LinkButton1.Visible = false;
            this.nousr.Visible = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (this.psw.Text == "")
            {
                MsgBox("Please Fill up the Pasword field", this.Page, this);
            }
            else if (this.TextBox3.Text == "")
            {
                MsgBox("Please Fill up the Confirm Pasword field", this.Page, this);
            }
            else if (this.psw.Text != this.TextBox3.Text)
            {
                MsgBox("Ensure that the Password field and Confirm Pasword field are matching", this.Page, this);
            }
            else
            {
                status = updatedata();
                if (status == 1)
                    MsgBox("Password has been updated successfully", this.Page, this);
                if (status == 2)
                    MsgBox("Connection Error Please try again later", this.Page, this);
            }
        }

        private int updatedata()
        {
            if (this.TextBox1.Text != "")
            {
                if (TextBox1.Text != "no data")
                {
                    try
                    {
                        if (con.State != ConnectionState.Closed)
                            con.Close();
                        con.Open();
                        string query1 = "Update [User] set pass = @p where User_Name = @u";
                        SqlCommand updatecmd = new SqlCommand(query1, con);
                        updatecmd.Parameters.AddWithValue("@u", SqlDbType.VarChar).Value = this.TextBox1.Text;
                        updatecmd.Parameters.AddWithValue("@p", SqlDbType.VarChar).Value = this.psw.Text;
                        updatecmd.ExecuteNonQuery();
                        status = 1;
                    }
                    catch
                    {
                        status = 2;
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            if (TextBox2.Text != "")
            {
                try
                {
                    if (con.State != ConnectionState.Closed)
                        con.Close();
                    con.Open();
                    string query1 = "Update [User] set pass = @p where Email = @e";
                    SqlCommand updatecmd = new SqlCommand(query1, con);
                    updatecmd.Parameters.AddWithValue("@e", SqlDbType.VarChar).Value = this.TextBox2.Text;
                    updatecmd.Parameters.AddWithValue("@p", SqlDbType.VarChar).Value = this.psw.Text;
                    updatecmd.ExecuteNonQuery();
                    status = 1;
                }
                catch
                {
                    status = 2;
                }
                finally
                {
                    con.Close();
                }
            }
            return status;
        }
    }
}