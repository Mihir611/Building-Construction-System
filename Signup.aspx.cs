using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Text.RegularExpressions;

namespace WebApplication1
{
    public partial class Signup : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
        public string uname;
        public string fname, pass, email;
        public double Phone;
        public double amt;
        private Money m = new Money();
        private Username un = new Username();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            uname = this.TextBox1.Text;
            fname = this.TextBox3.Text;
            pass = this.psw.Text;
            email = this.TextBox5.Text;
            //Phone = Convert.ToDouble(this.TextBox4.Text);
            if (this.TextBox6.Text == pass)
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select COUNT(*) FROM [User] where User_Name = @u", con);
                cmd.Parameters.AddWithValue("@u", SqlDbType.VarChar).Value = uname;
                int user = (int)cmd.ExecuteScalar();
                con.Close();
                if (user > 0)
                {
                    Alert.show("User Name already Exists");
                }
                else
                {
                    con.Open();
                    SqlCommand cmd_Phone_Exists = new SqlCommand("Select COUNT(*) FROM [User] where Phone = @P", con);
                    cmd_Phone_Exists.Parameters.AddWithValue("@P", SqlDbType.BigInt).Value = this.TextBox4.Text;
                    int phone = (int)cmd_Phone_Exists.ExecuteScalar();
                    con.Close();
                    if(phone > 0)
                    {
                        Alert.show("Phone Number already Exists");
                    }
                    else
                    {
                        con.Open();
                        SqlCommand cmd_Email_Exists = new SqlCommand("Select COUNT(*) FROM [User] where Email = @e", con);
                        cmd_Email_Exists.Parameters.AddWithValue("@e", SqlDbType.VarChar).Value = email;
                        int Email = (int)cmd_Email_Exists.ExecuteScalar();
                        con.Close();
                        if (Email > 0)
                        {
                            Alert.show("Email ID already Exists");
                        }
                        else
                        {
                            try
                            {
                                con.Open();
                                SqlCommand insert_cmd = new SqlCommand("insert into [User] (User_Name, Full_Name, Phone, Email, Pass, User_Type) values (@uname, @fname, @phone, @email, @pass, @utype)", con);
                                insert_cmd.Parameters.AddWithValue("@uname", SqlDbType.VarChar).Value = this.TextBox1.Text;
                                insert_cmd.Parameters.AddWithValue("@fname", SqlDbType.VarChar).Value = this.TextBox3.Text;
                                insert_cmd.Parameters.AddWithValue("@Phone", SqlDbType.BigInt).Value = this.TextBox4.Text;
                                insert_cmd.Parameters.AddWithValue("@email", SqlDbType.VarChar).Value = this.TextBox5.Text;
                                insert_cmd.Parameters.AddWithValue("@pass", SqlDbType.VarChar).Value = pass;
                                insert_cmd.Parameters.AddWithValue("@utype", SqlDbType.VarChar).Value = "customer";
                                insert_cmd.ExecuteNonQuery();
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Registration success')", true);
                                amt = 100.0;
                                sendamt();
                                Response.Redirect("Home.aspx");
                            }
                            finally
                            {
                                con.Close();
                            }
                        }
                    }
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Password and Confirm password field should match')", true);
            }
        }

        void sendamt()
        {
            m.amount = amt;
            Session["Amount"] = m;
            un.Name = uname;
            Session["UName"] = un;
            un.type = "Registered";
        }
    }
}