using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Service_Provider : System.Web.UI.MasterPage
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
            Label3.Text = "0";
            int filecount = 0;
            int data1 = 0;
            string data;
            string path1 = Server.MapPath("Approved_Quote\\");
            filecount = System.IO.Directory.GetFiles(path1).Length;
            Label2.Text = filecount.ToString();
            if (filecount > 0)
            {
                data = Label2.Text;
                data1 = data1 + Convert.ToInt32(data);
                Label3.Text = data1.ToString();
            }
            un = Session["UName"] as Username;
            if (un.Name == null && un.type != "Service_Provider")
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
            Session.Remove("UName");
            Session.Clear();
            Response.Redirect("index.aspx");
        }
    }
}