using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Newtonsoft.Json;

namespace WebApplication1
{
    public partial class Create_Project : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
        string Mainstatus = "Confirmed";
        string name;
        int count = 0;
        string pm;
        string role = "PM";
        string Empstatus = "Working";
        string Phone;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            string query = "SELECT Quo_Id FROM Final_Main WHERE Status = '"+ Mainstatus + "'";
            SqlDataAdapter adpt = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            DropDownList3.DataSource = dt;
            DropDownList3.DataBind();
            DropDownList3.DataTextField = "Quo_Id";
            DropDownList3.DataValueField = "Quo_Id";
            DropDownList3.DataBind();
            con.Close();
            if (!IsPostBack)
            {
                genProjectID();
            }
        }

        public void MsgBox(String ex, Page pg, Object obj)
        {
            string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        }

        protected void BtnGetData_Click(object sender, EventArgs e)
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            string query = "SELECT Date,Total,File_Name from Final_Main WHERE Quo_Id = @q";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@q", SqlDbType.VarChar).Value = this.DropDownList3.SelectedItem.Text.ToString();
            SqlDataReader sdr = cmd.ExecuteReader();
            if(sdr.HasRows)
            {
                while (sdr.Read())
                {
                    string Date = sdr["Date"].ToString();
                    string[] d = Date.Split(' ');
                    LblDate.Text = d[0].ToString();
                    LblAmt.Text = sdr["Total"].ToString();
                    LblAgree.Text = Mainstatus;
                    name = sdr["File_Name"].ToString();
                }
            }
            con.Close();
            getcusdata();
            ReadFile();
            GetManagerInfo();
            getDefaultTask();
        }

        private void getcusdata()
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            string query = "SELECT Full_Name,Phone,Email FROM [User] WHERE User_Name = @U";
            SqlCommand getcmd = new SqlCommand(query, con);
            getcmd.Parameters.AddWithValue("@U", SqlDbType.VarChar).Value = name;
            SqlDataReader sdr1 = getcmd.ExecuteReader();
            if(sdr1.HasRows)
            {
                while (sdr1.Read())
                {
                    LblCusName.Text = sdr1["Full_Name"].ToString();
                    LblPhone.Text = sdr1["Phone"].ToString();
                    LblMail.Text = sdr1["Email"].ToString();
                }
            }
            con.Close();
        }

        private void genProjectID()
        {
            var dateTime = DateTime.Now;
            Random r = new Random();
            int genRand = r.Next(0, 10000);
            LblID.Text = "BCS Proj" + genRand.ToString() + dateTime.ToString("dd/yyyy");
        }

        private void ReadFile()
        {
            string path1 = Server.MapPath("Quote_Request\\");
            string file = name;
            string read;
            read = File.ReadAllText(path1 + file);
            Quotation result = JsonConvert.DeserializeObject<Quotation>(read);
            Label1.Text = result.Id.ToString();
            Label2.Text = result.plotsize1.ToString();
            Label3.Text = result.plotsize2.ToString();
            Label4.Text = result.entrence_position.ToString();
            string space = result.garden.ToString();
            if (space == "Yes")
            {
                LblGarden.Text = "Required";
                LblGard.Text = "Required";
            }
                
            else
            {
                LblGarden.Text = "Not Required";
                LblGard.Text = "Not Required";
            }
                
            string well = result.well.ToString();
            if (well == "Yes")
            {
                LblWEl.Text = "Required";
                LblWell.Text = "Required";
            } 
            else
            {
                LblWell.Text = "Not Required";
                LblWEl.Text = "Not Required";
            }
            LblRoof.Text = result.roof.ToString();
            LblW.Text= result.wall.ToString();
            LblWindow.Text = result.window.ToString();
            LblDoor.Text = result.door.ToString();
            LblFloor.Text = result.floor.ToString();
        }

        private void GetManagerInfo()
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            string query = "SELECT Emp_Id, CONCAT(Employee_Name,' Assigned Projects are ',Project) AS Records FROM Employee WHERE Role = '"+role+"' AND Status = '"+Empstatus+"'";
            SqlDataAdapter adpt = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            DropDownList2.DataSource = dt;
            DropDownList2.DataBind();
            DropDownList2.DataTextField = "Records";
            DropDownList2.DataValueField = "Emp_Id";
            DropDownList2.DataBind();
            con.Close();
        }

        private void getDefaultTask()
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            DataTable dt1 = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter("SELECT Phase_Name,Task_Name FROM Default_Task", con);
            sda.Fill(dt1);
            GridView1.DataSource = dt1;
            GridView1.DataBind();
            con.Close();
        }

        protected void BtnAssignPM_Click(object sender, EventArgs e)
        {
            pm = DropDownList2.SelectedItem.Text.ToString();
            string[] m = pm.Split(' ');
            pm = m[0];
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            string Query = "SELECT Project FROM Employee WHERE Employee_Name = @E";
            SqlCommand getcmd1 = new SqlCommand(Query, con);
            getcmd1.Parameters.AddWithValue("@E", SqlDbType.VarChar).Value = pm.ToString();
            SqlDataReader sdr = getcmd1.ExecuteReader();
            if(sdr.HasRows)
            {
                while (sdr.Read())
                {
                    count = Convert.ToInt32(sdr["Project"].ToString());
                }
            }
            if (count > 0)
                count= count + 1;
            else
                count = 1;
            getEMPPhone();
            updateEMP();
        }

        private void updateEMP()
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
            try
            {
                con.Open();
                string Query = "UPDATE Employee SET Project = @C WHERE Employee_Name = @E";
                SqlCommand updatecmd = new SqlCommand(Query, con);
                updatecmd.Parameters.AddWithValue("@C", SqlDbType.Int).Value = count;
                updatecmd.Parameters.AddWithValue("@E", SqlDbType.VarChar).Value = pm;
                updatecmd.ExecuteNonQuery();
                MsgBox("Project Manager has been assigned successfully", this.Page, this);
            }
            catch (Exception ex)
            {
                MsgBox(ex.ToString(), this.Page, this);
            }
            finally
            {
                con.Close();
            }
            BtnAssignPM.Enabled = false;
        }

        private void getEMPPhone()
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            string query = "SELECT Phone FROM Employee WHERE Employee_Name = @E";
            SqlCommand getph = new SqlCommand(query, con);
            getph.Parameters.AddWithValue("@E", SqlDbType.VarChar).Value = pm;
            SqlDataReader sdr = getph.ExecuteReader();
            if(sdr.HasRows)
            {
                while (sdr.Read())
                {
                    Label5.Text = sdr["Phone"].ToString();
                }
            }
            con.Close();
        }

        protected void BtnSaveData_Click(object sender, EventArgs e)
        {
            int datacount = 1;
            int datacount1 = 1;
            if (this.TextName.Text == "")
                MsgBox("Please Enter the name of the project", this.Page, this);
            else if (this.TextAddress.Text == "")
                MsgBox("Please enter the construction address", this.Page, this);
            else if (this.BtnAssignPM.Enabled == true)
                MsgBox("Please select a Project Manager", this.Page, this);
            else if (DropDownList1.SelectedItem.Text == "Select Item")
                MsgBox("Please select the appropriate Project Type", this.Page, this);
            else if (TextStartDate.Text == "mm/dd/yyyy" || TextEndDate.Text == "mm/dd/yyyy")
                MsgBox("Please select the start and end date", this.Page, this);
            else
            {
                if (con.State != ConnectionState.Closed)
                    con.Close();
                try
                {
                    con.Open();
                    SqlCommand insertcmd = new SqlCommand("Add_Project", con);
                    insertcmd.CommandType = CommandType.StoredProcedure;
                    foreach (GridViewRow gr in GridView1.Rows)
                    {
                        insertcmd.Parameters.AddWithValue("@Proj_Id", SqlDbType.VarChar).Value = this.LblID.Text.ToString();
                        insertcmd.Parameters.AddWithValue("@Prj_Name", SqlDbType.VarChar).Value = this.TextName.Text.ToString();
                        long ph = long.Parse(this.LblPhone.Text.ToString());
                        insertcmd.Parameters.AddWithValue("@Ow_Ph", SqlDbType.BigInt).Value = ph;
                        insertcmd.Parameters.AddWithValue("@Ctor_Addr", SqlDbType.VarChar).Value = this.TextAddress.Text.ToString();
                        long ph1 = long.Parse(this.Label5.Text.ToString());
                        insertcmd.Parameters.AddWithValue("@Pm_Ph", SqlDbType.BigInt).Value = ph1;
                        DateTime startD = DateTime.Parse(this.TextStartDate.Text.ToString());
                        insertcmd.Parameters.AddWithValue("@Prj_Start_Dt", SqlDbType.Date).Value = startD;
                        DateTime endD = DateTime.Parse(this.TextEndDate.Text.ToString());
                        insertcmd.Parameters.AddWithValue("@Prj_End_Dt", SqlDbType.Date).Value = endD;
                        insertcmd.Parameters.AddWithValue("@Prj_Phase", SqlDbType.VarChar).Value = gr.Cells[0].Text.ToString();
                        decimal budget = Decimal.Parse(this.LblAmt.Text.ToString());
                        insertcmd.Parameters.AddWithValue("@Budget", SqlDbType.Decimal).Value = budget;
                        insertcmd.Parameters.AddWithValue("@Phase_Id", SqlDbType.VarChar).Value = gr.Cells[0].Text.ToString();
                        insertcmd.Parameters.AddWithValue("@Task_Name", SqlDbType.VarChar).Value = gr.Cells[1].Text.ToString();
                        insertcmd.Parameters.AddWithValue("@Prj_Status", SqlDbType.VarChar).Value = "Not Yet Started";
                        insertcmd.Parameters.AddWithValue("@CNT", SqlDbType.Int).Value = datacount;
                        insertcmd.Parameters.AddWithValue("@CNT1", SqlDbType.Int).Value = datacount1;
                        insertcmd.ExecuteNonQuery();
                        insertcmd.Parameters.Clear();
                        datacount++;
                        datacount1++;
                    }
                    MsgBox("Records inserted successfully", this.Page, this);
                }
                catch(Exception ex)
                {
                    MsgBox(ex.ToString(), this.Page, this);
                }
                finally
                {
                    con.Close();
                    cleardata();
                }
            }
        }

        private void cleardata()
        {
            
        }
    }
}