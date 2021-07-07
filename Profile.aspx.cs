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
    public partial class Profile : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
        Username un;
        string name;
        string empcode;
        protected void Page_Load(object sender, EventArgs e)
        {
            un = Session["UName"] as Username;
            name = un.Name.ToString();
            string[] fullname = name.Split('-');
            empcode = fullname[1].ToString();
            gtedata();
        }

        public void MsgBox(String ex, Page pg, Object obj)
        {
            string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        }

        private void gtedata()
        {
            int id = Convert.ToInt32(empcode);
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            string query1 = "SELECT Employee_Name,DOB,Gender,Salary,Designation,Email,Phone,Address1 FROM Employee WHERE Emp_Id = @id";
            SqlCommand getdata = new SqlCommand(query1, con);
            getdata.Parameters.AddWithValue("@id", SqlDbType.Int).Value = id;
            SqlDataReader sdr = getdata.ExecuteReader();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    Label1.Text = sdr[0].ToString();
                    string date = sdr[1].ToString();
                    string[] date1 = date.Split(' ');
                    Label2.Text = date1[0].ToString();
                    Label3.Text = sdr[2].ToString();
                    Label4.Text = sdr[3].ToString();
                    Label5.Text = sdr[4].ToString();
                    TextBox1.Text = sdr[5].ToString();
                    TextBox2.Text = sdr[6].ToString();
                    TextBox3.Text = sdr[7].ToString();
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == "")
                MsgBox("Please enter the email id", this.Page, this);
            else if (TextBox2.Text == "")
                MsgBox("Please enter the Phone number", this.Page, this);
            else if (TextBox3.Text == "")
                MsgBox("Please enter the address", this.Page, this);
            else
            {
                try
                {
                    if(con.State != ConnectionState.Closed)
                        con.Close();
                    con.Open();
                    string query = "UPDATE Employee SET Email = '"+ this.TextBox1.Text + "',Phone = '"+Convert.ToInt32(this.TextBox2.Text)+"',Address1 = '"+ this.TextBox3.Text + "' WHERE Employee_Name = '"+ this.Label1.Text + "'";
                    SqlCommand updatecmd = new SqlCommand(query, con);
                    updatecmd.ExecuteNonQuery();
                    MsgBox("Records updated successfully", this.Page, this);
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            string oldpass = this.TextBox4.Text;
            int success = 0;
            success = fetchpass(oldpass);
            if (success == 0)
                MsgBox("Old Password dosent match in the database!\n Please check the Password", this.Page, this);
            else
            {
                if (TextBox6.Text != TextBox5.Text)
                    MsgBox("Both New Password and confirm Password fields should match...", this.Page, this);
                else
                {
                    try
                    {
                        if (con.State != ConnectionState.Closed)
                            con.Close();
                        con.Open();
                        string query = "UPDATE [User] SET Pass = '"+this.TextBox5.Text+"' WHERE User_Name = '"+un.Name.ToString()+"'";
                        SqlCommand updatepass = new SqlCommand(query, con);
                        updatepass.ExecuteNonQuery();
                        MsgBox("Password updated successfully", this.Page, this);
                    }
                    catch (Exception ex)
                    {
                        MsgBox(ex.ToString(), this.Page, this);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        private int fetchpass(string s)
        {
            string pass1;
            int success = 0;
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            string passquery = "SELECT Pass FROM [User] WHERE User_Name = @uname";
            SqlCommand getpasscmd = new SqlCommand(passquery, con);
            getpasscmd.Parameters.AddWithValue("@uname", SqlDbType.VarChar).Value = un.Name.ToString();
            SqlDataReader sdr = getpasscmd.ExecuteReader();
            if (sdr.HasRows)
            {
                while(sdr.Read())
                {
                    pass1 = sdr[0].ToString();
                    if(pass1 == s)
                    {
                        success = 1;
                    }
                }
            }
            return success;
        }
    }
}