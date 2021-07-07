using Newtonsoft.Json;
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
    public partial class Review_Q : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
        private Final_Approval fn = new Final_Approval();
        string status = "Approved Waiting for Conformation";
        int count, co, c = 0;
        DataTable dataTable = new DataTable();
        private double finalamt;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Random rnd = new Random();
                int card = rnd.Next(1, 100);
                string data = Convert.ToString(card) + DateTime.Now.Date.ToString("d-M-yyyy");
                Label8.Text = data.ToString();
                dataTable.Columns.Add("Item Name");
                dataTable.Columns.Add("Quantity");
                dataTable.Columns.Add("Unite Price");
                dataTable.Columns.Add("Amount");
                ViewState["Records"] = dataTable;
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
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            string query = "SELECT B.Service_Provider, B.For_Quot, B.Date, B.Total, B.File_Name, BS.Item, BS.Qty, BS.Unite_Price, BS.Amount FROM BOM_Main B INNER JOIN BOM_Sub BS ON B.Quotation_Id = BS.Quotation_Id where B.Quotation_Id = '" + this.DropDownList1.SelectedItem.Text.ToString() + "'";
            SqlCommand getcmd = new SqlCommand(query, con);
            SqlDataReader sdr = getcmd.ExecuteReader();
            dataTable.Columns.Add("Item");
            dataTable.Columns.Add("Qty");
            dataTable.Columns.Add("Unite Price");
            dataTable.Columns.Add("Amount");
            if (sdr.HasRows)
            {
                while (sdr.Read())
                {
                    Label1.Text = sdr[0].ToString();
                    Label4.Text = sdr[2].ToString();
                    Label2.Text = sdr[1].ToString();
                    Label5.Text = sdr["Total"].ToString();
                    Label3.Text = sdr["File_Name"].ToString();
                    Label7.Text = Label3.Text.ToString();
                    DataRow row = dataTable.NewRow();
                    row["Item"] = sdr["Item"];
                    row["Qty"] = sdr["Qty"];
                    row["Unite Price"] = sdr["Unite_Price"];
                    row["Amount"] = sdr["Amount"];
                    dataTable.Rows.Add(row);
                }
                GridView1.DataSource = dataTable;
                GridView1.DataBind();
            }
            Label6.Text = "Note* The Prices may vary depending on the market conditions.";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            senddata();
            if (c == 0)
                MsgBox("Error Found while inserting data", this.Page, this);
            else
            {
                updatetable();
                if (count == 0)
                    MsgBox("Error Found while updating the data", this.Page, this);
                else
                {
                    Sendforapproval();
                    if (co == 0)
                        MsgBox("Error found while sending the quotation to the client", this.Page, this);
                    else
                        MsgBox("Records inserted and sent to the client successfully", this.Page, this);
                }
            }
            cleardata();
        }

        private void cleardata()
        {
            Label1.Text = "";
            Label2.Text = "";
            Label3.Text = "";
            Label4.Text = "";
            Label5.Text = "";
            Label6.Text = "";
            Label7.Text = "";
            Label6.Text = "";
            dataTable.Rows.Clear();
            GridView1.DataSource = null;
            GridView1.DataBind();
        }

        private void senddata()
        {
            int count1 = 1;
            if (con.State != ConnectionState.Closed)
                con.Close();
            try
            {
                con.Open();
                SqlCommand insertdata = new SqlCommand("InsertFinal", con);
                insertdata.CommandType = CommandType.StoredProcedure;
                foreach (GridViewRow gr in GridView1.Rows)
                {
                    insertdata.Parameters.AddWithValue("@Qid", SqlDbType.VarChar).Value = this.Label8.Text.ToString();
                    insertdata.Parameters.AddWithValue("@Date", SqlDbType.Date).Value = DateTime.Now.Date;
                    insertdata.Parameters.AddWithValue("@Fid", SqlDbType.VarChar).Value = this.Label2.Text.ToString();
                    insertdata.Parameters.AddWithValue("@Stat", SqlDbType.VarChar).Value = this.status;
                    Decimal dt = decimal.Parse(this.Label5.Text.ToString());
                    insertdata.Parameters.AddWithValue("@Tot", SqlDbType.Decimal).Value = dt;
                    insertdata.Parameters.AddWithValue("@Itm", SqlDbType.VarChar).Value = gr.Cells[0].Text.ToString();
                    insertdata.Parameters.AddWithValue("@Qty", SqlDbType.VarChar).Value = gr.Cells[1].Text.ToString();
                    decimal gr1 = Decimal.Parse(gr.Cells[2].Text.ToString());
                    insertdata.Parameters.AddWithValue("@Uprice", SqlDbType.Decimal).Value = gr1;
                    decimal gr2 = Decimal.Parse(gr.Cells[3].Text.ToString());
                    insertdata.Parameters.AddWithValue("@Amt", SqlDbType.Decimal).Value = gr2;
                    insertdata.Parameters.AddWithValue("@CNT", SqlDbType.Int).Value = count1;
                    insertdata.ExecuteNonQuery();
                    insertdata.Parameters.Clear();
                    count1++;
                }
                c++;
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

        private void updatetable()
        {
            if (con.State != ConnectionState.Closed)
                con.Close();
            con.Open();
            try
            {
                string query = "UPDATE BOM_Main SET Status = @s WHERE Quotation_Id = @q";
                SqlCommand updatecmd = new SqlCommand(query, con);
                updatecmd.Parameters.AddWithValue("@s", SqlDbType.VarChar).Value = status;
                updatecmd.Parameters.AddWithValue("@q", SqlDbType.VarChar).Value = this.DropDownList1.SelectedItem.Text.ToString();
                updatecmd.ExecuteNonQuery();
                count++;
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

        private void Sendforapproval()
        {
            //inserting values to class
            fn.amt1 = decimal.Parse(Label5.Text.ToString());
            fn.id1 = this.DropDownList1.SelectedItem.Text.ToString();
            fn.filename = Label7.Text.ToString();
            //Writing values to json file
            string json = JsonConvert.SerializeObject(fn);
            string path1 = Server.MapPath("Final_Approval_Waiting\\");
            string fname = "Quotation for " + Label7.Text.ToString();
            var myfile = System.IO.File.Create(path1 + fname);
            myfile.Close();
            string main_Path = path1 + fname;
            System.IO.File.WriteAllText(main_Path, json);
            co++;
        }

        protected void Button3_Click(object sender, EventArgs e)
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
                dataTable = (DataTable)ViewState["Records"];
                string Qty = this.TextQty.Text.ToString() + " " + DropDownList2.SelectedItem.ToString();
                dataTable.Rows.Add(TextName.Text, Qty, TextPrice.Text, tot);
                GridView1.DataSource = dataTable;
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
            double amt = double.Parse(Label5.Text.ToString());
            finalamt = amt;
            foreach (GridViewRow g in GridView1.Rows)
            {
                finalamt = finalamt + Convert.ToDouble(g.Cells[3].Text);
            }
            Label5.Text = finalamt.ToString();
        }
    }
}