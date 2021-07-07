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
    public partial class UpdateProject : System.Web.UI.Page
    {
        Username un;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
        string phone1;
        protected void Page_Load(object sender, EventArgs e)
        {
            un = Session["UName"] as Username;
            getUName();
            if (un.type == "Admin")
                GetAllData();
            else
                GetSpecificData();
        }

        public void MsgBox(String ex, Page pg, Object obj)
        {
            string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        }

        private void getUName()
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            string qu = "SELECT Phone FROM [User] WHERE User_Name = @U";
            SqlCommand CMD = new SqlCommand(qu, con);
            CMD.Parameters.AddWithValue("@U", SqlDbType.VarChar).Value = un.Name.ToString();
            SqlDataReader sdr = CMD.ExecuteReader();
            if(sdr.HasRows)
            {
                while(sdr.Read())
                {
                    phone1 = sdr["Phone"].ToString();
                }
            }
            con.Close();
        }

        private void GetAllData()
        {
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
            long ph = long.Parse(this.phone1.ToString());
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            string query = "SELECT Project_ID FROM Projects WHERE Project_Manager_Info = '"+ph+ "' AND Project_status != '" + "Completed" + "'";
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            int tot1 = 0;
            string projid = this.DropDownList1.SelectedItem.Text.ToString();
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            if (projid == "")
                MsgBox("Please select a Project Id from the Dropdown list", this.Page, this);
            else
            {
                string query = "SELECT Progress,Start_Date,End_Date,Budget,Project_status FROM Projects WHERE Project_ID = @P";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@P", SqlDbType.VarChar).Value = projid.ToString();
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        string dt1 = sdr["Start_Date"].ToString();
                        string[] dt = dt1.Split(' ');
                        LblStrtDt.Text = dt[0];
                        string dt2 = sdr["End_Date"].ToString();
                        string[] dt3 = dt2.Split(' ');
                        LblEndDt.Text = dt3[0];
                        LblBudget.Text = sdr["Budget"].ToString();
                        string tot = sdr["Progress"].ToString();
                        if (tot == "")
                            tot1 = 0;
                        else
                            tot1 = Convert.ToInt32(tot);
                        LblTotalPerc.Text = tot1.ToString();
                        LblStatus.Text = sdr["Project_status"].ToString();
                    }
                }
                con.Close();
                getPrhasedata1();
                getPrhasedata2();
                getPrhasedata3();
            }
        }

        private void getPrhasedata1()
        {
            int tot1 = 0;
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            string query = "SELECT Progress from Phase_Main p INNER JOIN Phase_Sub ps ON p.Phase_Id = ps.Phase_Id AND p.Project_Id = @P AND p.Phase_Id = @PHSID ";
            SqlCommand getcommand1 = new SqlCommand(query, con);
            getcommand1.Parameters.AddWithValue("@P",SqlDbType.VarChar).Value = this.DropDownList1.SelectedItem.Text.ToString();
            getcommand1.Parameters.AddWithValue("@PHSID", SqlDbType.VarChar).Value = "Phase 1";
            SqlDataReader sdr1 = getcommand1.ExecuteReader();
            if (sdr1.HasRows)
            {
                while (sdr1.Read())
                {
                    string tot = sdr1["Progress"].ToString();
                    if (tot == "")
                        tot1 = 0;
                    else
                        tot1 = Convert.ToInt32(tot);
                    LblPhase1Perc.Text = tot1.ToString();                    
                }
            }
            con.Close();
        }

        private void getPrhasedata2()
        {
            int tot1 = 0;
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            string query = "SELECT Progress from Phase_Main p INNER JOIN Phase_Sub ps ON p.Phase_Id = ps.Phase_Id AND p.Project_Id = @P AND p.Phase_Id = @PHSID ";
            SqlCommand getcommand1 = new SqlCommand(query, con);
            getcommand1.Parameters.AddWithValue("@P", SqlDbType.VarChar).Value = this.DropDownList1.SelectedItem.Text.ToString();
            getcommand1.Parameters.AddWithValue("@PHSID", SqlDbType.VarChar).Value = "Phase 2";
            SqlDataReader sdr2 = getcommand1.ExecuteReader();
            if (sdr2.HasRows)
            {
                while (sdr2.Read())
                {
                    string tot = sdr2["Progress"].ToString();
                    if (tot == "")
                        tot1 = 0;
                    else
                        tot1 = Convert.ToInt32(tot);
                    LblPhase2Perc.Text = tot1.ToString();
                }
            }
            con.Close();
        }

        private void getPrhasedata3()
        {
            int tot1 = 0;
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            string query = "SELECT Progress from Phase_Main p INNER JOIN Phase_Sub ps ON p.Phase_Id = ps.Phase_Id AND p.Project_Id = @P AND p.Phase_Id = @PHSID ";
            SqlCommand getcommand1 = new SqlCommand(query, con);
            getcommand1.Parameters.AddWithValue("@P", SqlDbType.VarChar).Value = this.DropDownList1.SelectedItem.Text.ToString();
            getcommand1.Parameters.AddWithValue("@PHSID", SqlDbType.VarChar).Value = "Phase 3";
            SqlDataReader sdr3 = getcommand1.ExecuteReader();
            if (sdr3.HasRows)
            {
                while (sdr3.Read())
                {
                    string tot = sdr3["Progress"].ToString();
                    if (tot == "")
                        tot1 = 0;
                    else
                        tot1 = Convert.ToInt32(tot);
                    LblPhase3Perc.Text = tot1.ToString();
                }
            }
            con.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (TextBudget.Text == "0")
                MsgBox("Please Enter the Updated Budget", this.Page, this);
            else if (this.TextEndDt.Text == "mm/dd/yyyy")
                MsgBox("Please enter the appropriate Project End Date", this.Page, this);
            else if (this.TextStrtDt.Text == "mm/dd/yyyy")
                MsgBox("Please enter the appropriate Project Start Date", this.Page, this);
            else if (this.TextP1EndDt.Text == "mm/dd/yyyy")
                MsgBox("Please enter the appropriate Phase 1 Start Date", this.Page, this);
            else if (this.TextP1StrtDt.Text == "mm/dd/yyyy")
                MsgBox("Please enter the appropriate Phase 1 Start Date", this.Page, this);
            else if (this.TextP2EndDt.Text == "mm/dd/yyyy")
                MsgBox("Please enter the appropriate Phase 2 Start Date", this.Page, this);
            else if (this.TextP2StrtDt.Text == "mm/dd/yyyy")
                MsgBox("Please enter the appropriate Phase 2 Start Date", this.Page, this);
            else if (this.TextP3EndDt.Text == "mm/dd/yyyy")
                MsgBox("Please enter the appropriate Phase 3 Start Date", this.Page, this);
            else if (this.TextP3StrtDt.Text == "mm/dd/yyyy")
                MsgBox("Please enter the appropriate Phase 3 Start Date", this.Page, this);
            else if (this.TextStatus.Text == "status")
                MsgBox("Please enter the Status of the Project", this.Page, this);
            else
            {
                updatedata();
                updatesubdata1();
                updatesubdata2();
                updatesubdata3();
                MsgBox("Records updated Successfully", this.Page, this);
            }
        }

        private void updatedata()
        {
            DateTime dt1 = DateTime.Parse(this.TextStrtDt.Text.ToString());
            DateTime dt2 = DateTime.Parse(this.TextEndDt.Text.ToString());
            decimal bud = Decimal.Parse(this.TextBudget.Text.ToString());
            int ans = datecompare(dt1, dt2);
            int prog = 0;
            try
            {
                if (con.State != ConnectionState.Closed)
                    con.Close();
                con.Open();
                string query = "UPDATE Projects SET Actual_Start_Date = @A, Actual_End_Date = @B, Budget = @C, Progress = @D, Project_status=@E";
                if (this.TextBudget.Text == "0")
                    this.TextBudget.Text = this.LblBudget.Text.ToString();
                else if (this.TextStatus.Text == "status")
                    this.TextStatus.Text = this.LblStatus.Text.ToString();
                else if (this.LblStatus.Text == "Completed")
                    MsgBox("Cannot update Project details \n because the Project has been complted and the keys have been handed over",this.Page,this);
                else if(ans == 1)
                    MsgBox("The Start date/End date cannot be less than Start/End Date", this.Page, this);
                else
                {
                    SqlCommand updatecmd1 = new SqlCommand(query, con);
                    updatecmd1.Parameters.AddWithValue("@A", SqlDbType.Date).Value = dt1;
                    updatecmd1.Parameters.AddWithValue("@B", SqlDbType.Date).Value = dt2;
                    updatecmd1.Parameters.AddWithValue("@C", SqlDbType.Decimal).Value = bud;
                    updatecmd1.Parameters.AddWithValue("@D", SqlDbType.Int).Value = prog;
                    updatecmd1.Parameters.AddWithValue("@E", SqlDbType.VarChar).Value = this.TextStatus.Text.ToString();
                    updatecmd1.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                MsgBox(ex.ToString(), this.Page, this);
            }
            finally
            {
                con.Close();
            }
        }

        private void updatesubdata1()
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
            DateTime dt1 = DateTime.Parse(this.TextP1StrtDt.Text.ToString());
            DateTime dt2 = DateTime.Parse(this.TextP1EndDt.Text.ToString());
            int prog = 0;
            int ans = datecompare(dt1, dt2);
            if (ans == 1)
                MsgBox("The Start date/End date cannot be less than Start/End Date", this.Page, this);
            else
            {
                try
                {
                    con.Open();
                    string query = "UPDATE Phase_Sub SET Progress=@P, Start_Date=@S, End_Date = @E WHERE Phase_Id = @PID";
                    SqlCommand updatecmd2 = new SqlCommand(query, con);
                    updatecmd2.Parameters.AddWithValue("@P", SqlDbType.Int).Value = prog;
                    updatecmd2.Parameters.AddWithValue("@S", SqlDbType.Date).Value = dt1;
                    updatecmd2.Parameters.AddWithValue("@E", SqlDbType.Date).Value = dt2;
                    updatecmd2.Parameters.AddWithValue("@PID", SqlDbType.VarChar).Value = "Phase 1";
                    updatecmd2.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MsgBox(ex.ToString(), this.Page, this);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void updatesubdata2()
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
            DateTime dt1 = DateTime.Parse(this.TextP2StrtDt.Text.ToString());
            DateTime dt2 = DateTime.Parse(this.TextP2EndDt.Text.ToString());
            int prog = 0;
            int ans = datecompare(dt1, dt2);
            if (ans == 1)
                MsgBox("The Start date/End date cannot be less than Start/End Date", this.Page, this);
            else
            {
                try
                {
                    con.Open();
                    string query = "UPDATE Phase_Sub SET Progress=@P, Start_Date=@S, End_Date = @E WHERE Phase_Id = @PID";
                    SqlCommand updatecmd2 = new SqlCommand(query, con);
                    updatecmd2.Parameters.AddWithValue("@P", SqlDbType.Int).Value = prog;
                    updatecmd2.Parameters.AddWithValue("@S", SqlDbType.Date).Value = dt1;
                    updatecmd2.Parameters.AddWithValue("@E", SqlDbType.Date).Value = dt2;
                    updatecmd2.Parameters.AddWithValue("@PID", SqlDbType.VarChar).Value = "Phase 2";
                    updatecmd2.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MsgBox(ex.ToString(), this.Page, this);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void updatesubdata3()
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
            int prog = 0;
            DateTime dt1 = DateTime.Parse(this.TextP3StrtDt.Text.ToString());
            DateTime dt2 = DateTime.Parse(this.TextP3EndDt.Text.ToString());
            int ans = datecompare(dt1, dt2);
            if (ans == 1)
                MsgBox("The Start date/End date cannot be less than Start/End Date", this.Page, this);
            else
            {
                try
                {
                    con.Open();
                    string query = "UPDATE Phase_Sub SET Progress=@P, Start_Date=@S, End_Date = @E WHERE Phase_Id = @PID";
                    SqlCommand updatecmd2 = new SqlCommand(query, con);
                    updatecmd2.Parameters.AddWithValue("@P", SqlDbType.Int).Value = prog;
                    updatecmd2.Parameters.AddWithValue("@S", SqlDbType.Date).Value = dt1;
                    updatecmd2.Parameters.AddWithValue("@E", SqlDbType.Date).Value = dt2;
                    updatecmd2.Parameters.AddWithValue("@PID", SqlDbType.VarChar).Value = "Phase 3";
                    updatecmd2.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MsgBox(ex.ToString(), this.Page, this);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private int datecompare(DateTime dt1, DateTime dt2)
        {
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