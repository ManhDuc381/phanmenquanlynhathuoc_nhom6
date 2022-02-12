using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanmacyTuto
{
    public partial class Selling : Form
    {
        public Selling()
        {
            InitializeComponent();
            ShowBill();
            ShowMed();
            SellerLbl.Text = Login.user;
            GetCustomer();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\luuma\Downloads\PhamacyTuto\PhamacyTuto\DataBase\PharmacyCDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void GetCustomer()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select CustNum from CustomerTbl", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CustNum", typeof(int));
            dt.Load(Rdr);
            CustIdCb.ValueMember = "CustNum";
            CustIdCb.DataSource = dt;
            Con.Close();
        }

        private void GetCustName()
        {
            Con.Open();
            string Query = "Select * from CustomerTbl where CustNum='" + CustIdCb.SelectedValue.ToString() + "'";
            SqlCommand cmd = new SqlCommand(Query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                CustNameTb.Text = dr["CustName"].ToString();
            }
            Con.Close();

        }
        private void UpdateQty()
        {

            try
            {
                int NewQty = Stock - Convert.ToInt32(MedQtyTb.Text);
                Con.Open();
                SqlCommand cmd = new SqlCommand("Update MedicineTb Set MedQty=@MQ where MedNum=@MKey", Con);
                cmd.Parameters.AddWithValue("@MQ", NewQty);
                cmd.Parameters.AddWithValue("@MKey", Key);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Customer Update");
                Con.Close();
                ShowMed();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void InsertBill()
        {
            if(CustNameTb.Text == "")
            {

            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into BillTbl(SName,CustNum,CustName,BDate,BAmount)values(@SN,@CN,@CNa,@BD,@BA)", Con);
                    cmd.Parameters.AddWithValue("@SN", SellerLbl.Text);
                    cmd.Parameters.AddWithValue("@CN", CustIdCb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@CNa", CustNameTb.Text);
                    cmd.Parameters.AddWithValue("@BD", DateTime.Today.Date);
                    cmd.Parameters.AddWithValue("@BA", GrdTotal);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Bill Saved");
                    Con.Close();
                    ShowBill();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }
        private void ShowBill()
        {
            Con.Open();
            string Query = "Select * from BillTbl where SName='"+ SellerLbl.Text +"'";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builer = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            TransactionsDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void ShowMed()
        {
            Con.Open();
            string Query = "Select * from MedicineTb";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builer = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            MedicinesDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        int n = 0, GrdTotal = 0;
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if(MedQtyTb.Text == "" || Convert.ToInt32(MedQtyTb.Text) > Stock)
            {
                MessageBox.Show("Enter Correct Quantiny");
            }
            else
            {
                int total = Convert.ToInt32(MedQtyTb.Text) * Convert.ToInt32(MedPriceTb.Text);
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(BillDGV);
                newRow.Cells[0].Value = n + 1;
                newRow.Cells[1].Value = MedNameTb.Text;
                newRow.Cells[2].Value = MedQtyTb.Text;
                newRow.Cells[3].Value = MedPriceTb.Text;
                newRow.Cells[4].Value = total;
                BillDGV.Rows.Add(newRow);
                GrdTotal = GrdTotal + total;
                TotalLbl.Text = "RS "+ GrdTotal;
                n++;
                UpdateQty();
            }
        }
        int Key = 0, Stock = 0, pos = 60;
        int MedId, Medprice, MedQty, MedTot;

        private void label19_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Sellers Obj = new Sellers();
            Obj.Show();
            this.Hide();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            Sellers Obj = new Sellers();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Customer Obj = new Customer();
            Obj.Show();
            this.Hide();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            Customer Obj = new Customer();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Manufacturer Obj = new Manufacturer();
            Obj.Show();
            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Manufacturer Obj = new Manufacturer();
            Obj.Show();
            this.Hide();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            Medicines Obj = new Medicines();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Medicines Obj = new Medicines();
            Obj.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Dashboard Obj = new Dashboard();
            Obj.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Dashboard Obj = new Dashboard();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void CustIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetCustName();
        }

        private void PrintBtn_Click(object sender, EventArgs e)
        {
            InsertBill();
            printDocument1.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("pprnm", 285, 600);
            if(printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
            
        }

        string Medname;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("HOÁ ĐƠN", new Font("Century Gothic", 12, FontStyle.Bold), Brushes.Red, new Point(90));
            e.Graphics.DrawString("ID MDICINE PRICE QUANTITY TOTAL", new Font("Century Gothic", 10, FontStyle.Bold), Brushes.Red, new Point(26, 40));
            foreach(DataGridViewRow row in BillDGV.Rows){
                MedId = Convert.ToInt32(row.Cells["Column1"].Value);
                Medname = "" + row.Cells["Column2"].Value;
                Medprice = Convert.ToInt32(row.Cells["Column3"].Value);
                MedQty = Convert.ToInt32(row.Cells["Column4"].Value);
                MedTot = Convert.ToInt32(row.Cells["Column5"].Value);
                e.Graphics.DrawString("" + MedId, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(26, pos));
                e.Graphics.DrawString("" + Medname, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(45, pos));
                e.Graphics.DrawString("" + Medprice, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(120, pos));
                e.Graphics.DrawString("" + MedQty, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(170, pos));
                e.Graphics.DrawString("" + MedTot, new Font("Century Gothic", 8, FontStyle.Bold), Brushes.Blue, new Point(235, pos));
                pos = pos + 20;
            }
            e.Graphics.DrawString("Grand Total :Rs" + GrdTotal, new Font("Century Gothic", 10, FontStyle.Bold), Brushes.Crimson, new Point(50, pos + 50));
            e.Graphics.DrawString("***********MCS Pharma**********" , new Font("Century Gothic", 10, FontStyle.Bold), Brushes.Crimson, new Point(10, pos + 85));
            BillDGV.Rows.Clear();
            BillDGV.Refresh();
            pos = 100;
            GrdTotal = 0;
            n = 0;
        }

        private void MedicinesDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MedNameTb.Text = MedicinesDGV.SelectedRows[0].Cells[1].Value.ToString();
            CustNameTb.Text = MedicinesDGV.SelectedRows[0].Cells[2].Value.ToString();
            Stock = Convert.ToInt32(MedicinesDGV.SelectedRows[0].Cells[3].Value.ToString());
            MedPriceTb.Text = MedicinesDGV.SelectedRows[0].Cells[4].Value.ToString();
            //MedManCb.SelectedValue = MedicinesDGV.SelectedRows[0].Cells[5].Value.ToString();
            //MedManTb.Text = MedicinesDGV.SelectedRows[0].Cells[6].Value.ToString();
            if (MedNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(MedicinesDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
    }
}
