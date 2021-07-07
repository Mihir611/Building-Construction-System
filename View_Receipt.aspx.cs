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
    public partial class View_Receipt : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
        double total = 0.00;
        protected void Page_Load(object sender, EventArgs e)
        {
   
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            string query = "SELECT * FROM Receipts WHERE User_Name = '"+this.DropDownList1.SelectedItem.Text.ToString()+"'";
            SqlDataAdapter Adp = new SqlDataAdapter(query, con);
            DataTable Dt = new DataTable();
            Adp.Fill(Dt);
            grid1.DataSource = Dt;
            grid1.DataBind();
            con.Close();
            total = getTotal();
            Label1.Text = total.ToString();
        }

        private double getTotal()
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            string query = "SELECT Amount FROM Receipts WHERE User_Name = '" + this.DropDownList1.SelectedItem.Text.ToString() + "'";
            SqlCommand getcmd = new SqlCommand(query, con);
            SqlDataReader sdr = getcmd.ExecuteReader();
            if(sdr.HasRows)
            {
                while(sdr.Read())
                {
                    total = total + Convert.ToDouble(sdr[0].ToString());
                }
            }
            return total;
        }
    }
}