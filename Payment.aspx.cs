using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Payment : System.Web.UI.Page
    {
        public static int otp;
        public static string card;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
        bool flag = false;
        Money m;
        Username un;
        protected void Page_Load(object sender, EventArgs e)
        {
            m = Session["Amount"] as Money;
            if(m.amount == 0.00)
            {
                Alert.show("Connection Error");
                Response.Redirect("Signup.aspx");
            }
            else
            {
                Label1.Text = m.amount.ToString();
            }
            un = Session["UName"] as Username;
            if(un.Name == null)
            {
                Alert.show("Connection Error");
                Response.Redirect("Signup.aspx");
            }
            else
            {
                Label2.Text = un.Name.ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            card = TextBox1.Text.ToString();
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "Select * from Card_Detail where Number = @num";
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@num", TextBox1.Text.ToString());
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr[0].ToString() != this.TextBox1.Text.ToString() || dr[1].ToString() != this.TextBox2.Text.ToString() || dr[2].ToString() != this.TextBox3.Text.ToString() || dr[3].ToString() != this.TextBox4.Text.ToString() || dr[4].ToString() != this.TextBox5.Text.ToString())
                {
                    flag = false;
                }
                else
                {
                    flag = true;
                }
            }
            if(flag!=true)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "AlertBox", "alert('Wrong Information Provided');", true);
            }
            else
            {
                generateotp();
                Response.Redirect("enter_OTP.aspx");
            }
        }

        public void generateotp()
        {
            try
            {
                int min = 1000;
                int max = 9999;
                Random rdm = new Random();
                otp = rdm.Next(min, max);
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }
    }
}