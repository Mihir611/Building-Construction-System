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
    public partial class new_Task : System.Web.UI.Page
    {
        Username un;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
        DataTable dt = new DataTable();
        string phone1;
        string projid, Phsid;
        DateTime dateTime1, dateTime2;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (ViewState["Records"] == null)
                {
                    dt.Columns.Add("Project ID");
                    dt.Columns.Add("Phase ID");
                    dt.Columns.Add("Task Name");
                    dt.Columns.Add("Start Date");
                    dt.Columns.Add("End Date");
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
            int ans = 0;
            int ans1 = 0;
            DateTime dateTime5 = DateTime.Now.Date;
            //checking if the pahse id is selected from list box or inserted from the textbox
            if (this.TextPhaseID.Text != "")
                Phsid = this.TextPhaseID.Text.ToString();
            else
                Phsid = this.ListBox1.SelectedItem.Text.ToString();
            //checking the end date is less than the start date or not
            if (this.TextStrtDt.Text != "mm/dd/yyyy")
                dateTime1 = DateTime.Parse(this.TextStrtDt.Text.ToString());
            if (this.TextEndDt.Text != "mm/dd/yyyy")
                dateTime2 = DateTime.Parse(this.TextEndDt.Text.ToString());
            if (this.TextEndDt.Text != "mm/dd/yyyy" && this.TextStrtDt.Text != "mm/dd/yyyy")
            {
                ans = datecompare(dateTime2, dateTime1);
            }
            else
            {
                if (this.TextStrtDt.Text == "mm/dd/yyyy")
                    MsgBox("Please input the Start date", this.Page, this);
                if (this.TextEndDt.Text != "mm/dd/yyyy")
                    MsgBox("Please input the End date", this.Page, this);
            }
            ans1 = datecompare(dateTime1, dateTime5);
            //checking all fields
            if (this.TextPhaseName.Text == "")
                MsgBox("Please Enter the Phase Name", this.Page, this);
            else if (Phsid == "")
                MsgBox("Please enter the phase id or select phase id from the dropdown list", this.Page, this);
            else if (ans == 0)
                MsgBox("End date cannot be less than the start date", this.Page, this);
            else if (ans1 == 0)
                MsgBox("Start date cannot be less than current date", this.Page, this);
            else
            {
                //inserting values to the datagrid
                dt = (DataTable)ViewState["Records"];
                dt.Rows.Add(this.DropDownList1.SelectedItem.Text.ToString(), Phsid, this.TextPhaseName.Text.ToString(), this.TextStrtDt.Text.ToString(), this.TextEndDt.Text.ToString());
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            cleardata();
        }

        private void cleardata()
        {
            this.TextPhaseName.Text = "";
            this.TextStrtDt.Text = "mm/dd/yyyy";
            this.TextEndDt.Text = "mm/dd/yyyy";
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            int prog = 0;
            if (con.State != ConnectionState.Closed)
                con.Close();
            try
            {
                con.Open();
                string qu = "INSERT INTO Phase_Sub(Project_Id,Phase_Id,Task_Name,Progress,Start_Date,End_Date)VALUES(@PID,@PHSID,@TASK,@PR,@S,@EN)";
                SqlCommand cmd = new SqlCommand(qu, con);
                foreach (GridViewRow gr in GridView1.Rows)
                {
                    cmd.Parameters.AddWithValue("@PID", SqlDbType.VarChar).Value = gr.Cells[0].Text.ToString();
                    cmd.Parameters.AddWithValue("@PHSID", SqlDbType.VarChar).Value = gr.Cells[1].Text.ToString();
                    cmd.Parameters.AddWithValue("@TASK", SqlDbType.VarChar).Value = gr.Cells[2].Text.ToString();
                    dateTime1 = DateTime.Parse(gr.Cells[3].Text.ToString());
                    cmd.Parameters.AddWithValue("@S", SqlDbType.Date).Value = dateTime1;
                    dateTime2 = DateTime.Parse(gr.Cells[4].Text.ToString());
                    cmd.Parameters.AddWithValue("@EN", SqlDbType.Date).Value = dateTime2;
                    cmd.Parameters.AddWithValue("@PR", SqlDbType.Int).Value = prog;
                    cmd.ExecuteNonQuery();

                }
                MsgBox("Records Inserted Successfully", this.Page, this);
            }
            catch(Exception ex)
            {
                MsgBox(ex.ToString(), this.Page, this);
            }
            finally
            {
                con.Close();
            }
            cleardata1();
        }

        private void cleardata1()
        {
            dt.Rows.Clear();
            GridView1.DataSource = dt;
            GridView1.DataBind();
            ListBox1.DataSource = dt;
            ListBox1.DataBind();
            Response.Redirect(Request.RawUrl);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            this.Label1.Visible = true;
            this.TextPhaseID.Visible = true;
            this.Label2.Visible = false;
            this.ListBox1.Visible = false;
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
    }
}