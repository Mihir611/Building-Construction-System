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
    public partial class Task_Management : System.Web.UI.Page
    {
        Username un;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
        DataTable dt = new DataTable();
        string phone1;
        string projid, Phsid;
        DateTime dateTime1, dateTime2;
        string s1;
        string[] s2;
        public static string date;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
                if (ViewState["Records"] == null)
                {
                    dt.Columns.Add("Task Name");
                    dt.Columns.Add("Progress %");
                    dt.Columns.Add("Actual Start Date");
                    dt.Columns.Add("Actual End Date");
                    ViewState["Records"] = dt;
                }
            }
            un = Session["UName"] as Username;
            getUName();
            if (un.type == "Admin")
                GetAllData();
            else
                GetSpecificData();
        }

        private void getUName()
        {
            //getting employee/admin phone number
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            string qu = "SELECT Phone FROM [User] WHERE User_Name = @U";
            SqlCommand CMD = new SqlCommand(qu, con);
            CMD.Parameters.AddWithValue("@U", SqlDbType.VarChar).Value = un.Name.ToString();
            SqlDataReader sdr = CMD.ExecuteReader();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    phone1 = sdr["Phone"].ToString();
                }
            }
            con.Close();
        }

        private void GetAllData()
        {
            //getting project id if user logged in is admin
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            string query = "SELECT Project_ID FROM Projects WHERE Project_status != '" + "Completed" + "'";
            SqlDataAdapter adpt = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            DropDownList1.DataSource = dt;
            DropDownList1.DataBind();
            DropDownList1.DataTextField = "Project_ID";
            DropDownList1.DataValueField = "Project_ID";
            DropDownList1.DataBind();
            con.Close();
        }

        private void GetSpecificData()
        {
            //getting project id if user logged in is an employee
            long ph = long.Parse(this.phone1.ToString());
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            string query = "SELECT Project_ID FROM Projects WHERE Project_Manager_Info = '" + ph + "' AND Project_status != '" + "Completed" + "'";
            SqlDataAdapter adpt = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            DropDownList1.DataSource = dt;
            DropDownList1.DataBind();
            DropDownList1.DataTextField = "Project_ID";
            DropDownList1.DataValueField = "Project_ID";
            DropDownList1.DataBind();
            con.Close();
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
            //getting project phase details
            projid = this.DropDownList1.SelectedItem.Text.ToString();
            if (con.State != ConnectionState.Closed)
                con.Close();
            if (projid == "")
                MsgBox("Please select a Project Id from the Dropdown list", this.Page, this);
            else
            {
                con.Open();
                string query = "SELECT Phase_Id FROM Phase_Main WHERE Project_Id = @PHSID";
                SqlCommand getcommand = new SqlCommand(query, con);
                getcommand.Parameters.AddWithValue("@PHSID", SqlDbType.VarChar).Value = projid.ToString();
                SqlDataReader sdr = getcommand.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        ListBox1.Items.Add((string)sdr["Phase_Id"]);
                    }
                }
                con.Close();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //adding data to the gridview
            int ans = 0;
            int ans1 = 0;
            int ans2 = 0;
            dateTime1 = DateTime.Parse(date.ToString());
            dateTime2 = DateTime.Parse(this.TextStrtDt.Text.ToString());
            DateTime dateTime3 = DateTime.Parse(DateTime.Now.Date.ToString());
            DateTime dateTime4 = DateTime.Parse(this.TextEndDt.Text.ToString());
            ans = datecompare(dateTime2, dateTime1);
            ans1 = datecompare(dateTime3, dateTime1);
            ans2 = datecompare(dateTime4, dateTime1);
            if (TextStrtDt.Text == "mm/dd/yyyy")
                MsgBox("Please enter the Actual Start date", this.Page, this);
            else if (TextEndDt.Text == "mm/dd/yyyy")
                MsgBox("Please enter the Actual END date", this.Page, this);
            else if (Convert.ToInt32(TextProgress.Text) < 0 || Convert.ToInt32(TextProgress.Text) > 100 || TextProgress.Text == "")
                MsgBox("Please enter a number between 0 and 100", this.Page, this);
            else if (ans == 0)
                MsgBox("The Actual Start Date cannot be less than Start Date", this.Page, this);
            else if (ans1 == 0 && Convert.ToInt32(TextProgress.Text) > 0)
                MsgBox("The Progress cannot be greater than 0 bcz the task cannont be started now", this.Page, this);
            else if (ans2 == 0)
                MsgBox("The Actual End Date cannot be Less than Actual Start Date", this.Page, this);
            else
            {
                dt = (DataTable)ViewState["Records"];
                dt.Rows.Add(this.DropDownList2.SelectedItem.Text.ToString(), this.TextProgress.Text, this.TextStrtDt.Text, this.TextEndDt.Text);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            clear();
        }

        private void clear()
        {
            this.TextEndDt.Text = "mm/dd/yyyy";
            this.TextStrtDt.Text = "mm/dd/yyyy";
            this.TextProgress.Text = "0";
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            //getting the task name from the database according to phase id
            Phsid = this.ListBox1.SelectedItem.Text.ToString();
            this.LblPhaseID.Text = Phsid.ToString();
            if (con.State != ConnectionState.Closed)
                con.Close();
            if (Phsid == "")
                MsgBox("Please select a Phase Id from the  given list", this.Page, this);
            else
            {
                con.Open();
                string qu = "SELECT Task_Name from Phase_Main P INNER JOIN Phase_Sub PS ON P.Phase_Id = PS.Phase_Id WHERE P.Phase_Id = @PID AND P.Project_Id = @PHSID AND Progress != @Prog AND End_Date != @dT OR Actual_End_Date != @DT1";
                SqlCommand getcmd = new SqlCommand(qu, con);
                getcmd.Parameters.AddWithValue("@PID", SqlDbType.VarChar).Value = Phsid;
                getcmd.Parameters.AddWithValue("@PHSID", SqlDbType.VarChar).Value = DropDownList1.SelectedItem.Text.ToString();
                getcmd.Parameters.AddWithValue("@Prog", SqlDbType.Int).Value = 100;
                getcmd.Parameters.AddWithValue("@dT", SqlDbType.Date).Value = DateTime.Now.Date.ToString();
                getcmd.Parameters.AddWithValue("@DT1", SqlDbType.Date).Value = DateTime.Now.Date.ToString();
                SqlDataAdapter apd = new SqlDataAdapter(getcmd);
                DataTable dataTable = new DataTable();
                apd.Fill(dataTable);
                DropDownList2.DataSource = dataTable;
                DropDownList2.DataBind();
                DropDownList2.DataTextField = "Task_Name";
                DropDownList2.DataValueField = "Task_Name";
                DropDownList2.DataBind();
                con.Close();
                date = readData();
            }
        }

        private string readData()
        {
            //getting start date of the task name  to compare
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            string qu = "SELECT Start_Date from Phase_Main P INNER JOIN Phase_Sub PS ON P.Phase_Id = PS.Phase_Id WHERE P.Phase_Id = @PID AND P.Project_Id = @PHSID AND Progress != @Prog AND End_Date != @dT OR Actual_End_Date != @DT1 AND Task_Name = @T";
            SqlCommand cmd = new SqlCommand(qu, con);
            cmd.Parameters.AddWithValue("@PID", SqlDbType.VarChar).Value = this.LblPhaseID.Text.ToString();
            cmd.Parameters.AddWithValue("@PHSID", SqlDbType.VarChar).Value = DropDownList1.SelectedItem.Text.ToString();
            cmd.Parameters.AddWithValue("@Prog", SqlDbType.Int).Value = 100;
            cmd.Parameters.AddWithValue("@dT", SqlDbType.Date).Value = DateTime.Now.Date.ToString();
            cmd.Parameters.AddWithValue("@DT1", SqlDbType.Date).Value = DateTime.Now.Date.ToString();
            cmd.Parameters.AddWithValue("@T", SqlDbType.VarChar).Value = this.DropDownList2.SelectedItem.Text.ToString();
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    s1 = sdr["Start_Date"].ToString();
                    s2 = s1.Split(' ');
                    s1 = s2[0].ToString();
                }
            }
            return s1;
        }

        private int datecompare(DateTime dt1, DateTime dt2)
        {
            //date comparision
            int ans = 0;
            int result = DateTime.Compare(dt1, dt2);
            if (result < 0)
                ans = 0;
            else if (result == 0)
                ans = 1;
            else
                ans = 2;
            return ans;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //Updatting the table information with the latest info
            if (con.State != ConnectionState.Closed)
                con.Close();
            try
            {
                con.Open();
                string Query = "UPDATE Phase_Sub SET Progress = @P1, Actual_Start_Date = @as, Actual_End_Date=@ae WHERE Task_Name = @TN AND Project_Id = @PRID";
                SqlCommand updatecommand = new SqlCommand(Query, con);
                foreach (GridViewRow gr in GridView1.Rows)
                {
                    int prog = 0;
                    prog = int.Parse(gr.Cells[1].Text.ToString());
                    updatecommand.Parameters.AddWithValue("@P1", SqlDbType.Int).Value = prog;
                    dateTime1 = DateTime.Parse(gr.Cells[2].Text.ToString());
                    updatecommand.Parameters.AddWithValue("@as", SqlDbType.Date).Value = dateTime1;
                    dateTime2 = DateTime.Parse(gr.Cells[3].Text.ToString());
                    updatecommand.Parameters.AddWithValue("ae", SqlDbType.Date).Value = dateTime2;
                    updatecommand.Parameters.AddWithValue("@TN", SqlDbType.VarChar).Value = gr.Cells[0].Text.ToString();
                    updatecommand.Parameters.AddWithValue("@PRID", SqlDbType.VarChar).Value = this.DropDownList1.SelectedItem.Text.ToString();
                    updatecommand.ExecuteNonQuery();
                    updatecommand.Parameters.Clear();
                }
                MsgBox("Records updated successfully", this.Page, this);
            }
            catch(Exception ex)
            {
                MsgBox(ex.ToString(), this.Page, this);
            }
            finally
            {
                con.Close();
            }
            cleardata();
        }

        private void cleardata()
        {
            dt.Rows.Clear();
            GridView1.DataSource = dt;
            GridView1.DataBind();
            ListBox1.DataSource = dt;
            ListBox1.DataBind();
            Response.Redirect(Request.RawUrl);
        }
    }
}