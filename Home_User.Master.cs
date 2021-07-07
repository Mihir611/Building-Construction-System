using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Home_User : System.Web.UI.MasterPage
    {
        Username un;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            un = Session["UName"] as Username;
            if(un.Name == null)
            {
                MsgBox("You need to be logged in to view other pages", this.Page, this);
                Response.Redirect("Login.aspx");
            }
            else
            {
                Label1.Text = un.Name.ToString();
            }
            if (un.type == "Registered")
                Button1.Visible = false;
            else
                Button1.Visible = true;
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
            Response.Redirect("Dashboard.aspx");
        }
    }
}