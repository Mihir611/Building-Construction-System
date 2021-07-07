using Newtonsoft.Json;
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
    public partial class Get_Quotation : System.Web.UI.Page
    {
        Username un;
        public string rdata, fdata, wadata, widata, ddata, wedata, gdata, finalpath , mp;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());

        protected void Page_Load(object sender, EventArgs e)
        {
            un = Session["UName"] as Username;
            if (!IsPostBack)
            {
                Random r = new Random();
                int genRand = r.Next(10, 99);
                string num = genRand.ToString();
                Label2.Text = num + ' ' + DateTime.Now.Date.ToString("d-M-yyyy");
            }
        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            GetRData();
            GetFData();
            GetWaData();
            GetWiData();
            GetDData();
            GetWeData();
            GetGData();
            Quotation _data = new Quotation();
            _data.Id = Label2.Text;
            _data.plotsize1 = Convert.ToInt32(this.TextBox1.Text);
            _data.plotsize2 = Convert.ToInt32(this.TextBox2.Text);
            _data.roof = rdata;
            _data.floor = fdata;
            _data.wall = wadata;
            _data.door = ddata;
            _data.window = widata;
            _data.well = wedata;
            _data.garden = gdata;
            _data.entrence_position = this.TextBox4.Text;
            _data.budget = Convert.ToDouble(this.TextBox3.Text);
            _data.name = un.Name.ToString();
            string json = JsonConvert.SerializeObject(_data);
            string path1 = Server.MapPath("Quote_Request\\");
            string fname = un.Name.ToString();
            var myfile = System.IO.File.Create(path1 + fname);
            myfile.Close();
            mp = path1;
            string main_Path = path1 + fname;
            System.IO.File.WriteAllText(main_Path, json);
            Alert.show("Data Sent Successfully");
            pushdata();
            Response.Redirect("Dashboard.aspx");
        }

        private void pushdata()
        {
            string stat = "Not Advertised";
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            string q = "INSERT INTO Quotations (Username,Filename,status,Location) VALUES (@u,@f,@s,@l)";
            SqlCommand pushcmd = new SqlCommand(q, con);
            pushcmd.Parameters.AddWithValue("@u",SqlDbType.VarChar).Value = un.Name.ToString();
            pushcmd.Parameters.AddWithValue("@f", SqlDbType.VarChar).Value = un.Name.ToString();
            pushcmd.Parameters.AddWithValue("@s", SqlDbType.VarChar).Value = stat.ToString();
            pushcmd.Parameters.AddWithValue("@l", SqlDbType.VarChar).Value = mp.ToString();
            pushcmd.ExecuteNonQuery();
            con.Close();
        }

        public string GetRData()
        {
            if (RadioButton1.Checked == true)
                rdata = RadioButton1.Text;
            else if (RadioButton2.Checked == true)
                rdata = RadioButton2.Text;
            return rdata;
        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            //File Uploader btn
            if (FileUpload1.HasFiles)
            {
                string ext = System.IO.Path.GetExtension(FileUpload1.FileName);
                //Label1.Text = ext;
                if(ext == ".jpg" || ext==".png" || ext==".gltf" || ext == ".glb" || ext == ".fbx")
                {
                    string uname = Dashboard.uname.ToString();
                    string path = Server.MapPath("Uploads\\"+uname);
                    if (!System.IO.Directory.Exists(path))
                        System.IO.Directory.CreateDirectory(path);
                    string finalpath1 = Server.MapPath("Uploads\\"+uname+"\\");
                    int filecount = 0;
                    foreach(HttpPostedFile file in FileUpload1.PostedFiles)
                    {
                        filecount += 1;
                        file.SaveAs(finalpath1 + file.FileName);
                    }
                    Label1.Text = filecount + "files uploaded successfully";
                }
                else
                {
                    Label1.Text = "File types must be .jpg or .png or.gltf or.fbx or.glb";
                }
            }
            else
            {
                Label1.Text = "Please select a file";
            }
        }

        public string GetFData()
        {
            if (RadioButton3.Checked == true)
                fdata = RadioButton3.Text;
            else if (RadioButton4.Checked == true)
                fdata = RadioButton4.Text;
            return fdata;
        }

        public string GetWaData()
        {
            if (RadioButton5.Checked == true)
                wadata = RadioButton5.Text;
            else if (RadioButton6.Checked == true)
                wadata = RadioButton6.Text;
            else if (RadioButton7.Checked == true)
                wadata = RadioButton7.Text;
            return wadata;
        }

        public string GetWiData()
        {
            if (RadioButton8.Checked == true)
                widata = RadioButton8.Text;
            else if (RadioButton9.Checked == true)
                widata = RadioButton9.Text;
            return widata;
        }

        public string GetDData()
        {
            if (RadioButton10.Checked == true)
                ddata = RadioButton10.Text;
            else if (RadioButton11.Checked == true)
                ddata = RadioButton11.Text;
            return fdata;
        }

        public string GetWeData()
        {
            if (RadioButton12.Checked == true)
                wedata = RadioButton12.Text;
            else if (RadioButton13.Checked == true)
                wedata = RadioButton13.Text;
            return wedata;
        }

        public string GetGData()
        {
            if (RadioButton14.Checked == true)
                gdata = RadioButton14.Text;
            else if (RadioButton15.Checked == true)
                gdata = RadioButton15.Text;
            return gdata;
        }
    }
}