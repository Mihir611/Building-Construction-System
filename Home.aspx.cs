using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Home : System.Web.UI.Page
    {
        private Money m = new Money();
        Username un;
        protected void Page_Load(object sender, EventArgs e)
        {
            un = Session["UName"] as Username;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int amt = 0;
            if (un.type != "Subscribed")
                amt = 100;
            amt = amt + Convert.ToInt32(Label3.Text.ToString());
            senamt(amt);
            Response.Redirect("Payment.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int amt = 0;
            if (un.type != "Subscribed")
                amt = 100;
            amt = amt + Convert.ToInt32(Label2.Text.ToString());
            senamt(amt);
            Response.Redirect("Payment.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int amt = 0;
            if (un.type != "Subscribed")
                amt = 100;
            amt = amt + Convert.ToInt32(Label1.Text.ToString());
            senamt(amt);
            Response.Redirect("Payment.aspx");
        }

        private void senamt(int amt)
        {
            m.amount = amt;
            Session["Amount"] = m;
        }
    }
}