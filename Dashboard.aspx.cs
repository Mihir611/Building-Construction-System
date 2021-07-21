using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace WebApplication1
{
    public partial class Dashboard1 : System.Web.UI.Page
    {
        Username un;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
        int pross1 = 0;
        string phone;
        string projid;
        int val1, val2, val3, val4, val5, val6;
        int ans1, ans2, ans3 = 0;
        double aa1, aa2, aa3, aa4, aa5, aa6;
        int getp1, getp2, ansgetp = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            un = Session["UName"] as Username;
            getuserdata();
            storedata();
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

        private void storedata()
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            string Query = "Select Project_ID from Projects where Owner_Info = @O and Project_status != @PS";
            SqlCommand getcmd = new SqlCommand(Query, con);
            long phone1 = long.Parse(phone.ToString());
            getcmd.Parameters.AddWithValue("@O", SqlDbType.BigInt).Value = phone1;
            getcmd.Parameters.AddWithValue("@PS", SqlDbType.VarChar).Value = "Completed";
            DataTable dt21 = new DataTable();
            dt21.Load(getcmd.ExecuteReader());
            con.Close();
            DropDownList1.DataSource = dt21;
            DropDownList1.DataTextField = "Project_ID";
            DropDownList1.DataValueField = "Project_ID";
            DropDownList1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            main.Visible = true;
            getprojectdet();
            getTask1();
            getTask2();
            getTask3();
            updateoverallprog();
            updateoverallprog2();
            updateoverallprog1();
            finalget();
            finalget2();
            finalget3();
            compute();
            allupdate();
            allupdate2();
            allupdate3();
            getPhaseData();
            finalGetProgUpdate();
            finalcompute();
            finalupdate();
            selproj.Visible = false;
        }

        private void getprojectdet()
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            string Query = "Select Project_ID,Project_Name,Actual_Start_Date,Actual_End_Date,Progress from Projects where Project_ID = @O and Project_status != @PS";
            SqlCommand getcmd = new SqlCommand(Query, con);
            getcmd.Parameters.AddWithValue("@O", SqlDbType.BigInt).Value = this.DropDownList1.SelectedItem.Text.ToString();
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
                DataTable dt1 = new DataTable();
                if (con.State != ConnectionState.Closed)
                    con.Close();
                con.Open();
                string q = "SELECT Phase_Id from Phase_Main where Project_Id = @P ";
                SqlCommand getcmd1 = new SqlCommand(q, con);
                getcmd1.Parameters.AddWithValue("@p", SqlDbType.VarChar).Value = projid.ToString();
                SqlDataAdapter sda = new SqlDataAdapter(getcmd1);
                sda.Fill(dt1);
                string [] array = new string[dt1.Rows.Count];
                for (int a = 0; a < dt1.Rows.Count; a++)
                {
                    array[a] = dt1.Rows[a]["Phase_ID"].ToString();
                }
                Label6.Text = array[0].ToString();
                Label8.Text = array[1].ToString();
                Label9.Text = array[2].ToString();
            }
        }

        private void getTask1()
        {
            DataTable dt1 = new DataTable();
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            string q = "SELECT Task_Name,Progress from Phase_Sub where Phase_Id = @phsid and Project_Id = @P";
            SqlCommand getcmd2 = new SqlCommand(q, con);
            getcmd2.Parameters.AddWithValue("@phsid", SqlDbType.VarChar).Value = "Phase 1";
            getcmd2.Parameters.AddWithValue("@P", SqlDbType.VarChar).Value = projid;
            SqlDataAdapter sda1 = new SqlDataAdapter(getcmd2);
            sda1.Fill(dt1);
            GridView2.DataSource = dt1;
            GridView2.DataBind();
        }

        private void getTask2()
        {
            DataTable dt2 = new DataTable();
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            string q = "SELECT Task_Name,Progress from Phase_Sub where Phase_Id = @phsid and Project_Id = @P";
            SqlCommand getcmd3 = new SqlCommand(q, con);
            getcmd3.Parameters.AddWithValue("@phsid", SqlDbType.VarChar).Value = "Phase 2";
            getcmd3.Parameters.AddWithValue("@P", SqlDbType.VarChar).Value = projid;
            SqlDataAdapter sda1 = new SqlDataAdapter(getcmd3);
            sda1.Fill(dt2);
            GridView3.DataSource = dt2;
            GridView3.DataBind();
        }

        private void getTask3()
        {
            DataTable dt3 = new DataTable();
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            string q = "SELECT Task_Name,Progress from Phase_Sub where Phase_Id = @phsid and Project_Id = @P";
            SqlCommand getcmd4 = new SqlCommand(q, con);
            getcmd4.Parameters.AddWithValue("@phsid", SqlDbType.VarChar).Value = "Phase 3";
            getcmd4.Parameters.AddWithValue("@P", SqlDbType.VarChar).Value = projid;
            SqlDataAdapter sda1 = new SqlDataAdapter(getcmd4);
            sda1.Fill(dt3);
            GridView4.DataSource = dt3;
            GridView4.DataBind();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Models.aspx");
        }

        private void updateoverallprog()
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            string query = "select COUNT(Progress) from Phase_Sub where Phase_Id = @Phsid and Project_Id = @p and Progress != @prog";
            SqlCommand cmdupdate =new SqlCommand(query,con);
            cmdupdate.Parameters.AddWithValue("@Phsid", SqlDbType.VarChar).Value = "Phase 1";
            cmdupdate.Parameters.AddWithValue("@p", SqlDbType.VarChar).Value = projid;
            cmdupdate.Parameters.AddWithValue("@prog", SqlDbType.Int).Value = 100;
            SqlDataReader sdr = cmdupdate.ExecuteReader();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    val1 = Convert.ToInt32(sdr[0]);
                }
            }
        }

        private void updateoverallprog1()
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            string query = "select COUNT(Progress) from Phase_Sub where Phase_Id = @Phsid and Project_Id = @p and Progress != @prog";
            SqlCommand cmdupdate = new SqlCommand(query, con);
            cmdupdate.Parameters.AddWithValue("@Phsid", SqlDbType.VarChar).Value = "Phase 2";
            cmdupdate.Parameters.AddWithValue("@p", SqlDbType.VarChar).Value = projid;
            cmdupdate.Parameters.AddWithValue("@prog", SqlDbType.Int).Value = 100;
            SqlDataReader sdr = cmdupdate.ExecuteReader();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    val2 = Convert.ToInt32(sdr[0]);
                }
            }
        }

        private void updateoverallprog2()
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            string query = "select COUNT(Progress) from Phase_Sub where Phase_Id = @Phsid and Project_Id = @p and Progress != @prog";
            SqlCommand cmdupdate = new SqlCommand(query, con);
            cmdupdate.Parameters.AddWithValue("@Phsid", SqlDbType.VarChar).Value = "Phase 3";
            cmdupdate.Parameters.AddWithValue("@p", SqlDbType.VarChar).Value = projid;
            cmdupdate.Parameters.AddWithValue("@prog", SqlDbType.Int).Value = 100;
            SqlDataReader sdr = cmdupdate.ExecuteReader();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    val3 = Convert.ToInt32(sdr[0]);
                }
            }
        }

        private void finalget()
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            string query = "select count(Project_Id) from Phase_Sub where Phase_Id = @Phsid and Project_Id = @p";
            SqlCommand cmdupdate = new SqlCommand(query, con);
            cmdupdate.Parameters.AddWithValue("@Phsid", SqlDbType.VarChar).Value = "Phase 1";
            cmdupdate.Parameters.AddWithValue("@p", SqlDbType.VarChar).Value = projid;
            SqlDataReader sdr = cmdupdate.ExecuteReader();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    val4 = Convert.ToInt32(sdr[0]);
                }
            }
        }

        private void finalget2()
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            string query = "select count(Project_Id) from Phase_Sub where Phase_Id = @Phsid and Project_Id = @p";
            SqlCommand cmdupdate = new SqlCommand(query, con);
            cmdupdate.Parameters.AddWithValue("@Phsid", SqlDbType.VarChar).Value = "Phase 2";
            cmdupdate.Parameters.AddWithValue("@p", SqlDbType.VarChar).Value = projid;
            SqlDataReader sdr = cmdupdate.ExecuteReader();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    val5 = Convert.ToInt32(sdr[0]);
                }
            }
        }

        private void finalget3()
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            string query = "select count(Project_Id) from Phase_Sub where Phase_Id = @Phsid and Project_Id = @p";
            SqlCommand cmdupdate = new SqlCommand(query, con);
            cmdupdate.Parameters.AddWithValue("@Phsid", SqlDbType.VarChar).Value = "Phase 3";
            cmdupdate.Parameters.AddWithValue("@p", SqlDbType.VarChar).Value = projid;
            SqlDataReader sdr = cmdupdate.ExecuteReader();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    val6 = Convert.ToInt32(sdr[0]);
                }
            }
        }

        private void compute()
        {
            double a1, a2, a3;
            a1 = Convert.ToDouble( val4 - val1);
            aa1 = a1 / val4;
            aa4 = aa1 * 100;
            ans1 = Convert.ToInt32(aa4);

            a2 = Convert.ToDouble( val5 - val2);
            aa2 = a2 / val5;
            aa5 = aa2 * 100;
            ans2 = Convert.ToInt32(aa5);

            a3 = Convert.ToDouble( val6 - val3);
            aa3 = a3 / val6;
            aa6 = aa3 * 100;
            ans3 = Convert.ToInt32(aa6);
        }

        private void allupdate()
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            string Query = "update Phase_Main set Overall_Progress = @OP where Phase_Id = @Phsid and Project_Id = @p";
            SqlCommand update1 = new SqlCommand(Query,con);
            update1.Parameters.AddWithValue("@Phsid", SqlDbType.VarChar).Value = "Phase 1";
            update1.Parameters.AddWithValue("@p", SqlDbType.VarChar).Value = projid;
            update1.Parameters.AddWithValue("@OP", SqlDbType.Int).Value = ans1;
            update1.ExecuteNonQuery();
            pross1 = ans1;
            div1.Style.Clear();
            div1.Style.Add("width", pross1 + "%");
            Label7.Text = pross1 + "%";

        }

        private void allupdate2()
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            string Query = "update Phase_Main set Overall_Progress = @OP where Phase_Id = @Phsid and Project_Id = @p";
            SqlCommand update1 = new SqlCommand(Query, con);
            update1.Parameters.AddWithValue("@Phsid", SqlDbType.VarChar).Value = "Phase 2";
            update1.Parameters.AddWithValue("@p", SqlDbType.VarChar).Value = projid;
            update1.Parameters.AddWithValue("@OP", SqlDbType.Int).Value = ans2;
            update1.ExecuteNonQuery();
            pross1 = ans2;
            div2.Style.Clear();
            div2.Style.Add("width", pross1 + "%");
            Label10.Text = pross1 + "%";
        }

        private void allupdate3()
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            string Query = "update Phase_Main set Overall_Progress = @OP where Phase_Id = @Phsid and Project_Id = @p";
            SqlCommand update1 = new SqlCommand(Query, con);
            update1.Parameters.AddWithValue("@Phsid", SqlDbType.VarChar).Value = "Phase 3";
            update1.Parameters.AddWithValue("@p", SqlDbType.VarChar).Value = projid;
            update1.Parameters.AddWithValue("@OP", SqlDbType.Int).Value = ans3;
            update1.ExecuteNonQuery();
            con.Close();
            pross1 = ans3;
            div3.Style.Clear();
            div3.Style.Add("width", pross1 + "%");
            Label11.Text = pross1 + "%";
        }

        private void finalGetProgUpdate()
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            string Query = "select count(Phase_Id),sum(Overall_Progress) from Phase_Main where Project_Id = @pid";
            SqlCommand selcmd = new SqlCommand(Query, con);
            selcmd.Parameters.AddWithValue("@pid",SqlDbType.VarChar).Value = projid;
            SqlDataReader sdr21 = selcmd.ExecuteReader();
            if (sdr21.HasRows)
            {
                while (sdr21.Read())
                {
                    getp1 = Convert.ToInt32(sdr21[0]);
                    getp2 = Convert.ToInt32(sdr21[1]);
                }
            }
            con.Close();
        }

        private void finalcompute()
        {
            ansgetp = getp2 / getp1;
        }

        private void finalupdate()
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            string Query = "update Projects set Progress = @OP1 where Project_Id = @pid";
            SqlCommand selcmd = new SqlCommand(Query, con);
            selcmd.Parameters.AddWithValue("@pid", SqlDbType.VarChar).Value = projid;
            selcmd.Parameters.AddWithValue("@OP1", SqlDbType.Int).Value = ansgetp;
            selcmd.ExecuteNonQuery();
            con.Close();
            pross1 = ansgetp;
            divprogress1.Style.Clear();
            divprogress1.Style.Add("width", pross1 + "%");
            Label3.Text = pross1 + "%";
        }
    }
}