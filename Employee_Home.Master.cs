using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Employee_Home : System.Web.UI.MasterPage
    {
        Username un;
        protected void Page_Load(object sender, EventArgs e)
        {
            un = Session["UName"] as Username;
            if (un.Name == null && un.type != "Employee" )
            {
                Alert.show("You need to be logged in to view other pages");
                Response.Redirect("Login.aspx");
            }
            else
            {
                Label1.Text = un.Name.ToString();
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Remove("UName");
            Session.Clear();
            Response.Redirect("index.aspx");
        }
    }
}