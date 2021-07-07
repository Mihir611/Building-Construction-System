using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Add_Employee : System.Web.UI.Page
    {
        int Age = 0;
        int count = 0;
        int count1 = 0;
        int empcode = 0;
        string gender, uname, type, utype, pass;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
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
            Age = getAge();
            if(Age <= 18)
            {
                MsgBox("The Employee cannot be added to the company", this.Page, this);
            }
            else
            {
                count = CheckforexistingData();
                if(count > 0)
                {
                    MsgBox("This phone number already exists.", this.Page, this);
                }
                else
                {
                    count1 = checkemailexists();
                    if (count1 > 0)
                    {
                        MsgBox("This Email Id already exists.", this.Page, this);
                    }
                    else
                    {
                        empcode = getempcode();
                        uname = "EMP" + "-" + empcode.ToString() +"-" + this.TextBox1.Text;
                        type = "Employee";
                        utype = "Internal_User";
                        pass = uname;
                        if(con.State != ConnectionState.Closed)
                        {
                            con.Close();
                        }
                        else
                        {
                            gender = getgender();
                            try
                            {
                                con.Open();
                                string query = "insert into Employee (Emp_Id,Employee_Name,Address1,Phone,Email,DOB,Gender,Join_Dt,Designation,Salary) VALUES (@id,@name,@add,@phone,@email,@DOB,@Gender,@date,@desig,@sal)";
                                SqlCommand cmd = new SqlCommand(query, con);
                                cmd.Parameters.Add("@id", SqlDbType.Int).Value = empcode;
                                cmd.Parameters.Add("@name", SqlDbType.VarChar, 50).Value = this.TextBox1.Text;
                                cmd.Parameters.Add("@add", SqlDbType.VarChar).Value = this.TextBox2.Text;
                                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = this.TextBox3.Text;
                                cmd.Parameters.Add("@phone", SqlDbType.BigInt).Value = Convert.ToInt64(this.TextBox4.Text);
                                cmd.Parameters.Add("@DOB", SqlDbType.Date).Value = Convert.ToDateTime(this.TextBox5.Text);
                                cmd.Parameters.Add("@Gender", SqlDbType.VarChar).Value = gender;
                                cmd.Parameters.Add("@date", SqlDbType.Date).Value = Convert.ToDateTime(this.TextBox6.Text);
                                cmd.Parameters.Add("@desig", SqlDbType.VarChar).Value = this.DropDownList1.SelectedItem.Text.ToString();
                                cmd.Parameters.Add("@sal", SqlDbType.Decimal).Value = Convert.ToDecimal(this.TextBox7.Text);
                                cmd.ExecuteNonQuery();
                                MsgBox("Records Inserted", this.Page, this);
                            }
                            catch (Exception ex)
                            {
                                MsgBox(ex.ToString(), this.Page, this);
                            }
                            finally
                            {
                                con.Close();
                            }
                            int success = insert();
                            if (success == 1)
                                MsgBox("Employee Login Created Successfully", this.Page, this);
                            cleardata();
                        }
                    }
                }
            }
        }

        private int insert()
        {
            int success = 0;
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            try
            {
                string query = "INSERT INTO [User] (User_Name,Full_Name,Phone,Email,Pass,User_type,Type) VALUES(@usern,@fulln,@ph,@em,@pas,@ut,@ty)";
                SqlCommand createlogin = new SqlCommand(query, con);
                createlogin.Parameters.AddWithValue("@usern", SqlDbType.VarChar).Value = uname;
                createlogin.Parameters.AddWithValue("@fulln", SqlDbType.VarChar).Value = this.TextBox1.Text;
                createlogin.Parameters.AddWithValue("@ph", SqlDbType.BigInt).Value = this.TextBox4.Text;
                createlogin.Parameters.AddWithValue("@em", SqlDbType.VarChar).Value = this.TextBox3.Text;
                createlogin.Parameters.AddWithValue("@pas", SqlDbType.VarChar).Value = pass;
                createlogin.Parameters.AddWithValue("@ut", SqlDbType.VarChar).Value = utype;
                createlogin.Parameters.AddWithValue("@ty", SqlDbType.VarChar).Value = type;
                createlogin.ExecuteNonQuery();
                success = 1;
            }
            catch(Exception ex)
            {
                MsgBox(ex.ToString(), this.Page, this);
            }
            finally
            {
                con.Close();
            }
            return success;
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
            this.TextBox7.Text = "";
        }

        private string getgender()
        {
            if (RadioButton1.Checked == true)
                gender = RadioButton1.Text;
            else
                gender = RadioButton2.Text;
            return gender;
        }

        private int getempcode()
        {
            if(con.State != ConnectionState.Closed)
            {
                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand getcommand = new SqlCommand("Select count(*) from Employee", con);
                empcode = Convert.ToInt32(getcommand.ExecuteScalar());
                if (empcode > 0)
                    empcode = empcode + 1;
                else
                    empcode = 1;
                con.Close();
            }
            return empcode;
        }

        private int checkemailexists()
        {
            if(con.State != ConnectionState.Closed)
            {
                con.Close();
            }
            else 
            {
                con.Open();
                SqlCommand checkemail = new SqlCommand("select count(*) from Employee where Email = @em", con);
                checkemail.Parameters.AddWithValue("@em", SqlDbType.BigInt).Value = this.TextBox3.Text;
                count1 = Convert.ToInt32(checkemail.ExecuteScalar());
                con.Close();
            }
            return count1;
        }

        private int getAge()
        {
            string[] DOB = this.TextBox5.Text.Split('-');
            int year = Convert.ToInt32(DOB[0]);
            var year1 = DateTime.Now.Year;
            Age = year1 - year;
            return Age;
        }

        private int CheckforexistingData()
        {
            if(con.State != ConnectionState.Closed)
            {
                con.Close();
            }
            else
            {
                con.Open();
                SqlCommand checkcmd = new SqlCommand("select count(*) from Employee where Phone = @ph", con);
                checkcmd.Parameters.AddWithValue("@ph", SqlDbType.BigInt).Value = this.TextBox4.Text;
                count = Convert.ToInt32(checkcmd.ExecuteScalar());
                con.Close();
            }
            return count;
        }
    }
}