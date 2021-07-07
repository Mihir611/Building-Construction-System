using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace WebApplication1
{
    public partial class Login : System.Web.UI.Page
    {
        int type;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
        private Username un = new Username();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from [User] where User_Name = @username and Pass = @password", con);
                cmd.Parameters.AddWithValue("@username", this.TextBox1.Text);
                cmd.Parameters.AddWithValue("@password", this.TextBox2.Text);
                SqlDataAdapter adapt = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapt.Fill(ds);
                con.Close();
                int count = ds.Tables[0].Rows.Count;
                if(count == 1)
                {
                    type = validateUsers();
                    sendvalue();
                    if (type == 1)
                        Response.Redirect("Bs_Employee.aspx");
                    else if (type == 2)
                        Response.Redirect("Dashboard.aspx");
                    else if (type == 3)
                        Response.Redirect("Service_Providers_Home.aspx");
                    else if(type == 4)
                        Response.Redirect("Dashboard_User.aspx");
                    else
                        Response.Redirect("Home.aspx");
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please Check the Username,Password and try again')", true);
                }
            }
            catch(Exception ex)
            {
                Alert.show(ex.Message);
            }
        }

        public void sendvalue()
        {
            un.Name = this.TextBox1.Text;
            Session["UName"] = un;
            if (type == 1)
                un.type = "Employee";
            else if (type == 2)
                un.type = "Subscribed";
            else if (type == 3)
                un.type = "Service_Provider";
            else if (type == 4)
                un.type = "Admin";
            else
                un.type = "Registered";
        }

        public int validateUsers()
        {
            string type, utype, type1, utype1, type2, utype2, type3, utype3;
            int ans = 0;
            type = "Employee";
            utype = "Internal_User";
            type1 = "Subscribed";
            utype1 = "customer";
            type2 = "Service Provider";
            utype2 = "Service Provider";
            type3 = "Admin";
            utype3 = "Admin";
            con.Open();
            SqlCommand Validuser = new SqlCommand("Select User_Type,Type from [User] where User_Name = @un", con);
            Validuser.Parameters.AddWithValue("@un", SqlDbType.VarChar).Value = this.TextBox1.Text;
            SqlDataReader dr = Validuser.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    if (utype == dr[0].ToString() && type == dr[1].ToString())
                        ans = 1;
                    else if (utype1 == dr[0].ToString() && type1 == dr[1].ToString())
                        ans = 2;
                    else if (utype2 == dr[0].ToString() && type2 == dr[1].ToString())
                        ans = 3;
                    else if (utype3 == dr[0].ToString() && type3 == dr[1].ToString())
                        ans = 4;
                }
            }
            con.Close();
            return ans;
        }
    }
}