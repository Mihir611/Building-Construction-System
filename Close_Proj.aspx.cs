using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class Close_Proj : System.Web.UI.Page
    {
        Username un;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
        string phone1;
        string projid;
        protected void Page_Load(object sender, EventArgs e)
        {
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
            string query = "SELECT Project_ID FROM Projects WHERE Project_status != '"+"Completed"+"'";
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
            if (projid == "SELECT ITEM")
                MsgBox("Please select a Project Id from the Dropdown list", this.Page, this);
            else
            {
                con.Open();
                string query = "SELECT Project_Name,Owner_Info,Construction_Address,Progress,Project_status FROM Projects WHERE Project_Id = @PHSID";
                SqlCommand getcommand = new SqlCommand(query, con);
                getcommand.Parameters.AddWithValue("@PHSID", SqlDbType.VarChar).Value = projid.ToString();
                SqlDataReader sdr = getcommand.ExecuteReader();
                if (sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        this.LblProjName.Text = sdr["Project_Name"].ToString();
                        this.LblId.Text = this.DropDownList1.SelectedItem.Text.ToString();
                        this.LblAddress.Text = sdr["Construction_Address"].ToString();
                        phone1 = sdr["Owner_Info"].ToString();
                        this.LblProg.Text = sdr["Progress"].ToString();
                        this.LblStatus.Text = sdr["Project_status"].ToString();
                    }
                }
                con.Close();
                getownername();
            }
        }

        private void getownername()
        {
            long ph;
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            string qu = "SELECT Full_Name FROM [User] WHERE Phone = @p";
            SqlCommand cmd = new SqlCommand(qu, con);
            ph = long.Parse(phone1.ToString());
            cmd.Parameters.AddWithValue("@p", SqlDbType.BigInt).Value = ph;
            SqlDataReader sdRead = cmd.ExecuteReader();
            if (sdRead.HasRows)
            {
                while (sdRead.Read())
                {
                    this.LblOwName.Text = sdRead["Full_Name"].ToString();
                }
            }
            con.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string status = "Completed";
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            string qu = "UPDATE Projects SET Project_status = @st WHERE Project_Id = @PHSID";
            SqlCommand updatecmd = new SqlCommand(qu, con);
            updatecmd.Parameters.AddWithValue("@st", SqlDbType.VarChar).Value = status;
            updatecmd.Parameters.AddWithValue("@PHSID", SqlDbType.VarChar).Value = this.DropDownList1.SelectedItem.Text.ToString();
            updatecmd.ExecuteNonQuery();
            MsgBox("Project closed successfully", this.Page, this);
            con.Close();
            cleardata();
        }

        private void cleardata()
        {
            this.LblAddress.Text = "";
            this.LblId.Text = "";
            this.LblOwName.Text = "";
            this.LblProg.Text = "";
            this.LblProjName.Text = "";
            this.LblStatus.Text = "";
        }
    }
}