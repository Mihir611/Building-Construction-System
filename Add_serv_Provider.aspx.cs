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
    public partial class Add_serv_Provider : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
        int checkdata, checkdata1, checkdata2 = 0;
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
                    checkdata1 = check1();
                    checkdata2 = check2();
                    if (checkdata == 1)
                        MsgBox("The Company Info already exists", this.Page, this);
                    else if(checkdata1 == 1)
                        MsgBox("The Company Info already exists", this.Page, this);
                    else if(checkdata2 == 1)
                        MsgBox("The Company Info already exists", this.Page, this);
                    else
                    {
                        if (con.State != ConnectionState.Closed)
                            con.Close();
                        con.Open();
                        string query = "INSERT INTO Service_Provider_Det VALUES(@name,@add,@Tin,@conc,@ph,@em)";
                        SqlCommand insertcmd = new SqlCommand(query, con);
                        insertcmd.Parameters.AddWithValue("@name", SqlDbType.VarChar).Value = this.TextBox1.Text;
                        insertcmd.Parameters.AddWithValue("@add", SqlDbType.VarChar).Value = this.TextBox2.Text;
                        insertcmd.Parameters.AddWithValue("@Tin", SqlDbType.VarChar).Value = this.TextBox3.Text;
                        insertcmd.Parameters.AddWithValue("@conc", SqlDbType.VarChar).Value = this.TextBox4.Text;
                        insertcmd.Parameters.AddWithValue("@ph", SqlDbType.BigInt).Value = this.TextBox5.Text;
                        insertcmd.Parameters.AddWithValue("@em", SqlDbType.VarChar).Value = this.TextBox6.Text;
                        insertcmd.ExecuteNonQuery();
                        MsgBox("Records inserted successfully", this.Page, this);
                        createuser();
                        cleardata();
                    }
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

        private void createuser()
        {
            Random r = new Random();
            int genRand = r.Next(10, 500);
            string pass = "Company" + "@" + this.TextBox1.Text + "." + genRand;
            string type = "Service Provider";
            try
            {
                if (con.State != ConnectionState.Closed)
                    con.Close();
                con.Open();
                string query = "INSERT INTO [User](User_Name,Full_Name,Phone,Email,Pass,User_Type,Type) VALUES (@u,@f,@p,@e,@pass,@usr,@t)";
                SqlCommand insertcommand = new SqlCommand(query, con);
                insertcommand.Parameters.AddWithValue("@u", SqlDbType.VarChar).Value = this.TextBox1.Text;
                insertcommand.Parameters.AddWithValue("@f", SqlDbType.VarChar).Value = this.TextBox1.Text;
                insertcommand.Parameters.AddWithValue("@p", SqlDbType.BigInt).Value = this.TextBox5.Text;
                insertcommand.Parameters.AddWithValue("@e", SqlDbType.VarChar).Value = this.TextBox6.Text;
                insertcommand.Parameters.AddWithValue("@pass", SqlDbType.VarChar).Value = pass;
                insertcommand.Parameters.AddWithValue("@usr", SqlDbType.VarChar).Value = type;
                insertcommand.Parameters.AddWithValue("@t", SqlDbType.VarChar).Value = type;
                insertcommand.ExecuteNonQuery();
                MsgBox("Service Provider Login Created", this.Page, this);
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

        private void cleardata()
        {
            this.TextBox1.Text = "";
            this.TextBox2.Text = "";
            this.TextBox3.Text = "";
            this.TextBox4.Text = "";
            this.TextBox5.Text = "";
            this.TextBox6.Text = "";
        }

        private int check()
        {
            con.Open();
            SqlCommand checkcommand = new SqlCommand("select *from Service_Provider_Det where GSTin = @g", con);
            checkcommand.Parameters.AddWithValue("@g", SqlDbType.NVarChar).Value = this.TextBox3.Text;
            SqlDataReader sdr = checkcommand.ExecuteReader();
            if(sdr.HasRows)
            {
                while (sdr.Read())
                {
                    checkdata = 1;
                }
            }
            con.Close();
            return checkdata;
        }

        private int check1()
        {
            con.Open();
            SqlCommand checkcommand1 = new SqlCommand("select * from Service_Provider_Det where Phone = @PH", con);
            checkcommand1.Parameters.AddWithValue("@PH", SqlDbType.BigInt).Value = this.TextBox5.Text;
            SqlDataReader sdr1 = checkcommand1.ExecuteReader();
            if (sdr1.HasRows)
            {
                while (sdr1.Read())
                {
                    checkdata1 = 1;
                }
            }
            con.Close();
            return checkdata1;
        }

        private int check2()
        {
            con.Open();
            SqlCommand checkcommand2 = new SqlCommand("select * from Service_Provider_Det where Email = @EM", con);
            checkcommand2.Parameters.AddWithValue("@EM", SqlDbType.VarChar).Value = this.TextBox6.Text;
            SqlDataReader sdr2 = checkcommand2.ExecuteReader();
            if (sdr2.HasRows)
            {
                while (sdr2.Read())
                {
                    checkdata2 = 1;
                }
            }
            con.Close();
            return checkdata2;
        }
    }
}