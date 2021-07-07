using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Dashboard : System.Web.UI.MasterPage
    {
        public static string uname;
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
            if (un.Name != null && un.type == null)
            {
                MsgBox("You are not a subscribed user so please buy a package first then come back", this.Page, this);
            }
            else if(un.Name != null && un.type != "Subscribed")
            {
                MsgBox("You dont have specialised permissions to view this page", this.Page, this);
                Response.Redirect("Login.aspx");
            }
            else if(un.Name == null && un.type != "Subscribed")
            {
                MsgBox("You dont have specialised permissions to view this page", this.Page, this);
                Response.Redirect("Login.aspx");
            }
            else
            {
                Label2.Text = un.Name.ToString();
                uname = Label2.Text;
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