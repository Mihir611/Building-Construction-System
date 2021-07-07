using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Newtonsoft.Json;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

namespace WebApplication1
{
    public partial class receivedq : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
        public string data;
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] filepath = Directory.GetFiles(Server.MapPath("Quote_Request//"));
            List<ListItem> files = new List<ListItem>();
            foreach (string path in filepath)
            {
                files.Add(new ListItem(Path.GetFileName(path)));
            }
            DropDownList1.DataSource = files;
            DropDownList1.DataBind();
            
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
            string path1 = Server.MapPath("Quote_Request\\");
            string file = DropDownList1.SelectedItem.ToString();
            string read;
            read = File.ReadAllText(path1 + file);
            Quotation result = JsonConvert.DeserializeObject<Quotation>(read);
            Label1.Text = result.name.ToString();
            Label4.Text = result.Id.ToString();
            Label5.Text = result.plotsize1.ToString();
            Label6.Text = result.plotsize2.ToString();
            Label7.Text = result.roof.ToString();
            Label8.Text = result.floor.ToString();
            Label9.Text = result.wall.ToString();
            Label10.Text = result.window.ToString();
            Label11.Text = result.door.ToString();
            Label12.Text = result.well.ToString();
            Label13.Text = result.garden.ToString();
            Label14.Text = result.budget.ToString();
            Label15.Text = result.entrence_position.ToString();
            //getting user details
            con.Open();
            try
            {
                SqlCommand getdata = new SqlCommand("SELECT Phone,Email from [User] WHERE User_Name = @u",con);
                getdata.Parameters.AddWithValue("@u", Label1.Text);
                SqlDataReader sdr = getdata.ExecuteReader();
                if(sdr.HasRows)
                {
                    while (sdr.Read())
                    {
                        Label2.Text = sdr[0].ToString();
                        Label3.Text = sdr[1].ToString();
                    }
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
            //checking if directory exists
            string path = Server.MapPath("Uploads\\" + Label1.Text + "\\");
            if (System.IO.Directory.Exists(path))
            {
                //getting all the uploaded images
                DataTable dt = new DataTable();
                DataColumn dc = new DataColumn("ImageUrl");
                dt.Columns.Add(dc);

                ArrayList pics = new ArrayList();
                string html;
                DirectoryInfo dirs = new DirectoryInfo(Server.MapPath("Uploads\\" + Label1.Text + "\\"));
                html = dirs.GetFiles("*").Count().ToString();
                foreach (FileInfo s in dirs.GetFiles("*"))
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = s.Name;
                    dt.Rows.Add(dr);
                }
                dtlist.DataSource = dt;
                dtlist.DataBind();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Advert_Q _data = new Advert_Q();
            _data.Id = this.Label4.Text;
            _data.File_Name = this.DropDownList1.SelectedItem.ToString();
            _data.Status = "Advertised";
            string json = JsonConvert.SerializeObject(_data);
            string path1 = Server.MapPath("Approved_Quote\\");
            string fname = this.Label4.Text + "-" + DateTime.Now.Date.ToString("d-M-yyyy");
            var myfile = System.IO.File.Create(path1 + fname);
            myfile.Close();
            string main_Path = path1 + fname;
            System.IO.File.WriteAllText(main_Path, json);
            //adding to database
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            SqlCommand insertcmd = new SqlCommand("insert_data_Quot", con);
            insertcmd.CommandType = CommandType.StoredProcedure;
            insertcmd.Parameters.AddWithValue("@Quot_Name",SqlDbType.VarChar).Value = this.DropDownList1.SelectedItem.ToString();
            insertcmd.Parameters.AddWithValue("@Status", SqlDbType.VarChar).Value = "Advertised";
            insertcmd.Parameters.AddWithValue("@Location", SqlDbType.VarChar).Value = path1;
            insertcmd.ExecuteNonQuery();
            MsgBox("This Quotation is Advertised successfully", this.Page, this);
        }
    }
}