using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;
using Newtonsoft.Json;
using System.Data;

namespace WebApplication1
{
    public partial class Generate_BOM : System.Web.UI.Page
    {
        Username un;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
        public static string Quoid;
        DataTable dt = new DataTable();
        double finalamt = 0.00;
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = DateTime.Now.Date.ToString("M-d-yyyy");
            string[] filepath = Directory.GetFiles(Server.MapPath("Approved_Quote//"));
            List<ListItem> files = new List<ListItem>();
            foreach (string path in filepath)
            {
                files.Add(new ListItem(Path.GetFileName(path)));
            }
            DropDownList1.DataSource = files;
            DropDownList1.DataBind();
            if (!IsPostBack)
            {
                if (ViewState["Records"] == null)
                {
                    dt.Columns.Add("Item Name");
                    dt.Columns.Add("Quantity");
                    dt.Columns.Add("Unite Price");
                    dt.Columns.Add("Amount");
                    ViewState["Records"] = dt;
                }
            }
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
            string path1 = Server.MapPath("Approved_Quote\\");
            string file = DropDownList1.SelectedItem.ToString();
            string read;
            read = File.ReadAllText(path1 + file);
            Advert_Q result = JsonConvert.DeserializeObject<Advert_Q>(read);
            Label4.Text = DropDownList1.SelectedItem.ToString();
            Label3.Text = result.Id.ToString();
            Label5.Text = result.File_Name.ToString();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (TextName.Text == "")
            {
                Alert.show("Please enter the Product Name");
            }
            else if (TextQty.Text == "")
            {
                Alert.show("The Quantity Field cannot be empty");
            }
            else if (Convert.ToDouble(TextQty.Text) <= 0)
            {
                Alert.show("The Quantity Field cannot be 0 or less than 0");
            }
            else if (TextPrice.Text == "")
            {
                Alert.show("The Price Field cannot be empty");
            }
            else if (Convert.ToDouble(TextPrice.Text) <= 0)
            {
                Alert.show("The Price Field cannot be 0 or less than 0");
            }
            else
            {
                double tot = Convert.ToDouble(this.TextPrice.Text) * Convert.ToDouble(this.TextQty.Text);
                dt = (DataTable)ViewState["Records"];
                string Qty = this.TextQty.Text.ToString() + " " + DropDownList2.SelectedItem.ToString();
                dt.Rows.Add(TextName.Text, Qty, TextPrice.Text, tot);
                GridView1.DataSource = dt;
                GridView1.DataBind();
                getfinalamt();
                clear();
            }
        }

        private void clear()
        {
            this.TextName.Text = "";
            this.TextQty.Text = "";
            this.TextQty.Text = "";
            this.TextPrice.Text = "";
        }

        private void getfinalamt()
        {
            foreach (GridViewRow g in GridView1.Rows)
            {
                finalamt = finalamt + Convert.ToDouble(g.Cells[3].Text);
            }
            Label2.Text = finalamt.ToString();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int count = 1;
           Quoid = geneQuotID();
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            string review = "Under Review";
            //insert data
            try
            {

                SqlCommand insertdata = new SqlCommand("Generate_BOM", con);
                insertdata.CommandType = CommandType.StoredProcedure;
                foreach (GridViewRow gr in GridView1.Rows)
                {
                    insertdata.Parameters.AddWithValue("@Quotation_Id", SqlDbType.VarChar).Value = Quoid;
                    insertdata.Parameters.AddWithValue("@Service_Provider", SqlDbType.VarChar).Value = un.Name.ToString();
                    insertdata.Parameters.AddWithValue("@Date", SqlDbType.Date).Value = Convert.ToDateTime(DateTime.Now.Date);
                    insertdata.Parameters.AddWithValue("@Tot", SqlDbType.Decimal).Value = Decimal.Parse(this.Label2.Text.ToString());
                    insertdata.Parameters.AddWithValue("@Status", SqlDbType.VarChar).Value = review;
                    insertdata.Parameters.AddWithValue("@For_Quot", SqlDbType.VarChar).Value = this.Label3.Text.ToString();
                    insertdata.Parameters.AddWithValue("@f_N", SqlDbType.VarChar).Value = this.Label5.Text.ToString();
                    insertdata.Parameters.AddWithValue("@Item", SqlDbType.VarChar).Value = gr.Cells[0].Text.ToString();
                    insertdata.Parameters.AddWithValue("@Qty", SqlDbType.VarChar).Value = gr.Cells[1].Text.ToString();
                    decimal gr1 = Decimal.Parse(gr.Cells[2].Text.ToString());
                    insertdata.Parameters.AddWithValue("@Unite_Price", SqlDbType.Decimal).Value = gr1;
                    decimal gr2 = Decimal.Parse(gr.Cells[3].Text.ToString());
                    insertdata.Parameters.AddWithValue("@Amount", SqlDbType.Decimal).Value = gr2;
                    insertdata.Parameters.AddWithValue("@CNT", SqlDbType.Int).Value = count;
                    insertdata.ExecuteNonQuery();
                    insertdata.Parameters.Clear();
                    count++;
                }
                MsgBox("Records Saved and has been sent.", this.Page, this);
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
            this.Label1.Text = "";
            this.Label2.Text = "";
            this.Label3.Text = "";
            this.Label4.Text = "";
            this.Label5.Text = "";
            dt.Rows.Clear();
            GridView1.DataSource = null;
            GridView1.DataBind();
        }

        private string geneQuotID()
        {
            un = Session["UName"] as Username;
            string data = un.Name.ToString();
            string[] id = this.DropDownList1.SelectedItem.ToString().Split(' ');
            string data1 = " " + id[1];
            Quoid = data + data1;
            return Quoid;
        }
    }
}