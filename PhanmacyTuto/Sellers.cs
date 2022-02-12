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
    public partial class Sellers : Form
    {
        public Sellers()
        {
            InitializeComponent();
            ShowSell();

        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\luuma\Downloads\PhamacyTuto\PhamacyTuto\DataBase\PharmacyCDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void ShowSell()
        {
            Con.Open();
            string Query = "Select * from SellerTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builer = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            SellerDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Reset()
        {
            SNameTb.Text = "";
            SAddTb.Text = "";
            SPassTb.Text = "";
            SPhoneTb.Text = "";
            SGenCb.SelectedIndex = 0;
            Key = 0;
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (SNameTb.Text == "" || SAddTb.Text == "" || SPhoneTb.Text == "" || SGenCb.SelectedIndex == -1 || SPassTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into SellerTbl(SName,SAdd,SPhone,SPass,SDOB,SGen)values(@SN,@SA,@SP,@SPS,@SD,@SG)", Con);
                    cmd.Parameters.AddWithValue("@SN", SNameTb.Text);
                    cmd.Parameters.AddWithValue("@SA", SAddTb.Text);
                    cmd.Parameters.AddWithValue("@SP", SPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@SPS", SPassTb.Text);
                    cmd.Parameters.AddWithValue("@SD", SDOB.Value.Date);
                    cmd.Parameters.AddWithValue("@SG", SGenCb.SelectedItem.ToString());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Medicines Added");
                    Con.Close();
                    ShowSell();
                    Reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        int Key = 0;
        private void SellerDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SNameTb.Text = SellerDGV.SelectedRows[0].Cells[1].Value.ToString();
            SAddTb.Text = SellerDGV.SelectedRows[0].Cells[4].Value.ToString();
            SPhoneTb.Text = SellerDGV.SelectedRows[0].Cells[3].Value.ToString();
            SDOB.Text = SellerDGV.SelectedRows[0].Cells[2].Value.ToString();
            SPassTb.Text = SellerDGV.SelectedRows[0].Cells[6].Value.ToString();
            SGenCb.SelectedItem = SellerDGV.SelectedRows[0].Cells[5].Value.ToString();
            if (SNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(SellerDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select The Customer");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from SellerTbl where SNum=@SKey", Con);
                    cmd.Parameters.AddWithValue("@SKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Medicines Deleted");
                    Con.Close();
                    ShowSell();
                    Reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (SNameTb.Text == "" || SAddTb.Text == "" || SPhoneTb.Text == "" || SGenCb.SelectedIndex == -1 || SPassTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Update SellerTbl Set SName=@SN,SAdd=@SA,SPhone=@SP,SDOB=@SD,SGen=@SG,SPass=@SPS where SNum=@SKey", Con);
                    cmd.Parameters.AddWithValue("@SN", SNameTb.Text);
                    cmd.Parameters.AddWithValue("@SA", SAddTb.Text);
                    cmd.Parameters.AddWithValue("@SP", SPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@SPS", SPassTb.Text);
                    cmd.Parameters.AddWithValue("@SD", SDOB.Value.Date);
                    cmd.Parameters.AddWithValue("@SG", SGenCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@SKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Update");
                    Con.Close();
                    ShowSell();
                    Reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
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

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            Selling Obj = new Selling();
            Obj.Show();
            this.Hide();
        }

        private void label18_Click(object sender, EventArgs e)
        {
            Selling Obj = new Selling();
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
    }
}
