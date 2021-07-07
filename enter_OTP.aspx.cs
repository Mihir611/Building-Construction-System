using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class enter_OTP : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
        string t = "Subscribed";
        public static string uname;
        Username un;
        Money m;
        protected void Page_Load(object sender, EventArgs e)
        {
            un = Session["UName"] as Username;
            m = Session["Amount"] as Money;
            Label1.Text = DateTime.Now.Date.ToString();
            Label2.Text = Payment.card.ToString();
            Label5.Text = Payment.otp.ToString();
            if (!IsPostBack)
            {
                getVal();
                getData();
            }
        }

        void getVal()
        {
            if (m.amount == 0.00)
            {
                Alert.show("Connection Error");
                Response.Redirect("Signup.aspx");
            }
            else
            {
                Label3.Text = m.amount.ToString();
            }
            if (un.Name == null)
            {
                Alert.show("Connection Error");
                Response.Redirect("Signup.aspx");
            }
            else
            {
                uname = un.Name.ToString();
            }
        }

        private void getData()
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            string query = "Select Phone from [User] where User_Name = @u";
            SqlCommand getcmd = new SqlCommand(query,con);
            getcmd.Parameters.AddWithValue("@u", SqlDbType.VarChar).Value = uname.ToString();
            SqlDataReader sdr = getcmd.ExecuteReader();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    this.Label4.Text = sdr["Phone"].ToString();
                }
            }
            con.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int count = 0;
            if(TextBox1.Text == Label5.Text)
            {
                //uname = un.Name.ToString();
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "update [User] set Type = @type where User_Name = @uname";
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@uname", uname);
                cmd.Parameters.AddWithValue("@type", t);
                cmd.ExecuteNonQuery();
                con.Close();
                /*inserting to another table*/
                insertdata();
                Session.Clear();
                un.Name = uname;
                Session["UName"] = un;
                un.type = "Subscribed";
                Response.Redirect("Home.aspx");
            }
            else
            {
                count += 1;
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please check the OTP and Re-Enter');", true);
                if(count > 3)
                {
                    Button1.Enabled = false;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Please Restart the payment process');", true);
                }
            }
        }

        public void insertdata()
        {
            con.Open();
            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandText = "insert into Receipts(User_Name,Amount,Date) Values (@uname,@amt,@dt)";
            cmd1.Connection = con;
            cmd1.Parameters.AddWithValue("@uname", uname);
            cmd1.Parameters.AddWithValue("@amt", Convert.ToDecimal(Label3.Text));
            cmd1.Parameters.AddWithValue("@dt", Convert.ToDateTime(Label1.Text));
            cmd1.ExecuteNonQuery();
            con.Close();
        }
    }
}