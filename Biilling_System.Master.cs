using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Biilling_System : System.Web.UI.MasterPage
    {
        Username un;

        public void MsgBox(String ex, Page pg, Object obj)
        {
            string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            un = Session["UName"] as Username;
            if (un.Name == null && un.type != "Admin" || un.Name == null && un.type != "Employee")
            {
                MsgBox("You need to be logged in with specific role to view this page", this.Page, this);
                Response.Redirect("Login.aspx");
            }
            else
            {
                Label1.Text = un.Name.ToString();
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (un.type == "Employee")
                Response.Redirect("Bs_Employee.aspx");
            else
                Response.Redirect("Dashboard_User.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Session.Remove("UName");
            Session.Clear();
            Response.Redirect("index.aspx");
        }
    }
}