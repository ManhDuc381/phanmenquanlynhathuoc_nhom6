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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            CountMed();
            CountSeller();
            CountCust();
            SumAmt();
            GetSeller();
            GetBestSeller();
            GetBestCustomer();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\luuma\Downloads\PhamacyTuto\PhamacyTuto\DataBase\PharmacyCDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void CountMed()
        {
            Con.Open();
            SqlDataAdapter Sda = new SqlDataAdapter("Select Count(*) from MedicineTb", Con);
            DataTable dt = new DataTable();
            Sda.Fill(dt);
            MedNum.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void CountSeller()
        {
            Con.Open();
            SqlDataAdapter Sda = new SqlDataAdapter("Select Count(*) from SellerTbl", Con);
            DataTable dt = new DataTable();
            Sda.Fill(dt);
            SellerLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void CountCust()
        {
            Con.Open();
            SqlDataAdapter Sda = new SqlDataAdapter("Select Count(*) from CustomerTbl", Con);
            DataTable dt = new DataTable();
            Sda.Fill(dt);
            CustLbl.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void SumAmt()
        {
            Con.Open();
            SqlDataAdapter Sda = new SqlDataAdapter("Select Sum(BAmount) from BillTbl", Con);
            DataTable dt = new DataTable();
            Sda.Fill(dt);
            SellAmtLbl.Text ="Rs " + dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void SumAmtbySeller()
        {
            Con.Open();
            SqlDataAdapter Sda = new SqlDataAdapter("Select Sum(BAmount) from BillTbl where SName='"+ SellerCb.SelectedValue.ToString()+ "'", Con);
            DataTable dt = new DataTable();
            Sda.Fill(dt);
            SellsBySeller.Text = "Rs " + dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void GetSeller()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("Select SName from SellerTbl", Con);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("SName", typeof(String));
            dt.Load(Rdr);
            SellerCb.ValueMember = "SName";
            SellerCb.DataSource = dt;
            Con.Close();
        }
        private void GetBestSeller()
        {
            try
            {
                Con.Open();
                string InnerQuery = "Select Max(BAmount) from BillTbl";
                DataTable dt1 = new DataTable();
                SqlDataAdapter sda1 = new SqlDataAdapter(InnerQuery, Con);
                sda1.Fill(dt1);
                SqlDataAdapter Sda = new SqlDataAdapter("Select SName from BillTbl where BAmount='" + dt1.Rows[0][0].ToString() + "'", Con);
                DataTable dt = new DataTable();
                Sda.Fill(dt);
                BestSellerLbl.Text = dt.Rows[0][0].ToString();
                Con.Close();
            }
            catch (Exception ex)
            {
                Con.Close();
            }
            
        }
        private void GetBestCustomer()
        {
            try
            {
                Con.Open();
                string InnerQuery = "Select Max(BAmount) from BillTbl";
                DataTable dt1 = new DataTable();
                SqlDataAdapter sda1 = new SqlDataAdapter(InnerQuery, Con);
                sda1.Fill(dt1);
                SqlDataAdapter Sda = new SqlDataAdapter("Select CustName from BillTbl where BAmount='" + dt1.Rows[0][0].ToString() + "'", Con);
                DataTable dt = new DataTable();
                Sda.Fill(dt);
                BestCumtomerLbl.Text = dt.Rows[0][0].ToString();
                Con.Close();
            }
            catch (Exception ex)
            {
                Con.Close();
            }

        }
        private void pictureBox14_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void label19_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void SellerCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            SumAmtbySeller();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Medicines Obj = new Medicines();
            Obj.Show();
            this.Hide();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            Medicines Obj = new Medicines();
            Obj.Show();
            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Manufacturer Obj = new Manufacturer();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Manufacturer Obj = new Manufacturer();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Customer Obj = new Customer();
            Obj.Show();
            this.Hide();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            Customer Obj = new Customer();
            Obj.Show();
            this.Hide();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            Sellers Obj = new Sellers();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Sellers Obj = new Sellers();
            Obj.Show();
            this.Hide();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            Selling Obj = new Selling();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Selling Obj = new Selling();
            Obj.Show();
            this.Hide();
        }
    }
}
