using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace WebApplication1
{
    public partial class View_Quot : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
        public string data;
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] filepath = Directory.GetFiles(Server.MapPath("Approved_Quote//"));
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
            //Getting Quotation Data
            string path1 = Server.MapPath("Approved_Quote\\");
            string file = DropDownList1.SelectedItem.ToString();
            string read;
            read = File.ReadAllText(path1 + file);
            Advert_Q result = JsonConvert.DeserializeObject<Advert_Q>(read);
            string filename = result.File_Name.ToString();
            Label4.Text = DropDownList1.SelectedItem.ToString();
            //Reading file
            string path2 = Server.MapPath("Quote_Request\\");
            string file1 = filename;
            string read1;
            read1 = File.ReadAllText(path2 + file1);
            Quotation result1 = JsonConvert.DeserializeObject<Quotation>(read1);
            Label5.Text = result1.plotsize1.ToString();
            Label6.Text = result1.plotsize2.ToString();
            Label7.Text = result1.roof.ToString();
            Label8.Text = result1.floor.ToString();
            Label9.Text = result1.wall.ToString();
            Label10.Text = result1.window.ToString();
            Label11.Text = result1.door.ToString();
            Label12.Text = result1.well.ToString();
            Label13.Text = result1.garden.ToString();
            Label14.Text = result1.budget.ToString();
            Label15.Text = result1.entrence_position.ToString();
        }
    }
}