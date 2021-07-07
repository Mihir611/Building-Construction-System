using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Dashboard_User : System.Web.UI.MasterPage
    {
        Username un;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
        string s = "Confirmed";
        int count = 0;
        int count1 = 0;

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
            if (un.Name == null && un.type != "Admin" )
            {
                MsgBox("You need to be logged in with specific role to view this page", this.Page, this);
                Response.Redirect("Login.aspx");
            }
            else
            {
                Label1.Text = un.Name.ToString();
            }
            count = getData();
            bindData();
            count1 = Get_Quotationinfo();
            if (count1 == 1)
            {
                geta();
                count1 = 1;
                Rep2.Visible = true;
            }
            else
                count1 = 0;
            count = count + count1;
            Label3.Text = count.ToString();
        }

        private void geta()
        {
            string e = "Not Advertised";
            con.Open();
            SqlDataAdapter sdacheck = new SqlDataAdapter("select Username, Filename from Quotations where status = '" + e + "'", con);
            DataTable dt1 = new DataTable();
            sdacheck.Fill(dt1);
            Rep2.DataSource = dt1;
            Rep2.DataBind();
            con.Close();
        }

        private int Get_Quotationinfo()
        {
            int c = 0;
            string checkq;
            string e = "Not Advertised";
            checkq = "select Username,Filename from Quotations where status = @e";
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            SqlCommand checkcmd = new SqlCommand(checkq, con);
            checkcmd.Parameters.AddWithValue("@e", SqlDbType.VarChar).Value = e.ToString();
            SqlDataReader sdrcheck = checkcmd.ExecuteReader();
            if (sdrcheck.HasRows)
            {
                while (sdrcheck.Read())
                {
                    c = 1;
                }
            }
            else
            {
                c = -1;
            }
            con.Close();
            return c;
        }

        private int getData()
        {
            int count1 = 0;
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            string query = "Select count(Rec_Id) from Final_Main where Status = '" + s + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            count1 = Convert.ToInt32(cmd.ExecuteScalar());
            return count1;
        }

        private void bindData()
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            SqlDataAdapter sdr = new SqlDataAdapter("SELECT File_Name,Status FROM Final_Main WHERE Status = '" + s + "'", con);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Remove("UName");
            Session.Clear();
            Response.Redirect("index.aspx");
        }
    }
}