using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Dashboard1 : System.Web.UI.Page
    {
        Username un;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
        int pross1 = 0;
        string phone;
        string projid;
        string PHID;
        protected void Page_Load(object sender, EventArgs e)
        {
            un = Session["UName"] as Username;
            getuserdata();
            getprojectdet();
            getPhaseData();
        }

        private void getuserdata()
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            string qu = "select Phone from [User] where User_Name = @u";
            SqlCommand cmd = new SqlCommand(qu, con);
            cmd.Parameters.AddWithValue("@u", SqlDbType.VarChar).Value = un.Name.ToString();
            SqlDataReader sdr = cmd.ExecuteReader();
            if(sdr.HasRows)
            {
                while (sdr.Read())
                {
                    phone = sdr["Phone"].ToString();
                }
            }
            con.Close();
        }

        private void getprojectdet()
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            string Query = "Select Project_ID,Project_Name,Actual_Start_Date,Actual_End_Date,Progress from Projects where Owner_Info = @O and Project_status != @PS";
            SqlCommand getcmd = new SqlCommand(Query, con);
            long phone1 = long.Parse(phone.ToString());
            getcmd.Parameters.AddWithValue("@O", SqlDbType.BigInt).Value = phone1;
            getcmd.Parameters.AddWithValue("@PS", SqlDbType.VarChar).Value = "Completed";
            SqlDataReader sdr1 = getcmd.ExecuteReader();
            if (sdr1.HasRows)
            {
                while (sdr1.Read())
                {
                    string date1 = sdr1["Actual_Start_Date"].ToString();
                    string[] date2 = date1.Split(' ');
                    this.StartDt.Text = date2[0].ToString();
                    string date3 = sdr1["Actual_End_Date"].ToString();
                    string[] date4 = date3.Split(' ');
                    this.EndDt.Text = date4[0].ToString();
                    pross1 = Convert.ToInt32(sdr1["Progress"].ToString());
                    this.Label1.Text = sdr1["Project_Name"].ToString();
                    this.Label2.Text = pross1.ToString();
                    projid = sdr1["Project_ID"].ToString();
                }
            }
            divprogress1.Style.Clear();
            divprogress1.Style.Add("width", pross1 + "%");
            Label3.Text = pross1 + "%";
            con.Close();
        }

        private void getPhaseData()
        {
            if (projid != null)
            {
                DataTable dt = new DataTable();
                if (con.State != ConnectionState.Closed)
                    con.Close();
                con.Open();
                string q = "SELECT Phase_Id,Overall_Progress from Phase_Main where Project_Id = @P ";
                SqlCommand getcmd1 = new SqlCommand(q, con);
                getcmd1.Parameters.AddWithValue("@p", SqlDbType.VarChar).Value = projid.ToString();
                SqlDataAdapter sda = new SqlDataAdapter(getcmd1);
                sda.Fill(dt);
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
            }
        }

        private void getTask()
        {
            /*DataTable dt1 = new DataTable();
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            string q = "SELECT Task_Name,Progress from Phase_Sub where Phase_Id = @phsid and Project_Id = @P";
            SqlCommand getcmd2 = new SqlCommand(q, con);
            getcmd2.Parameters.AddWithValue("@phsid", SqlDbType.VarChar).Value = Repeater1.FindControl("LblPhaseID").ToString();
            getcmd2.Parameters.AddWithValue("@P", SqlDbType.VarChar).Value = projid;
            SqlDataAdapter sda1 = new SqlDataAdapter(getcmd2);
            sda1.Fill(dt1);
            gri*/
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Models.aspx");
        }
    }
}