using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace PhanmacyTuto
{
    public partial class Manufacturer : Form
    {
        public Manufacturer()
        {
            InitializeComponent();
            ShowMan();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\luuma\Downloads\PhamacyTuto\PhamacyTuto\DataBase\PharmacyCDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void ShowMan()
        {
            Con.Open();
            string Query = "Select * from ManufacturerTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builer = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ManufacturerDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if(ManAddTb.Text == "" || ManNameTb.Text == "" || ManPhoneTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into ManufacturerTbl(ManName,ManAdd,ManPhone,ManJDate)values(@MN,@MA,@MP,@MJD)", Con);
                    cmd.Parameters.AddWithValue("@MN", ManNameTb.Text);
                    cmd.Parameters.AddWithValue("@MA", ManAddTb.Text);
                    cmd.Parameters.AddWithValue("@MP", ManPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@MJD", ManJDate.Value.Date);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Manufacturer Added");
                    Con.Close();
                    ShowMan();
                    Reset();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        int Key = 0;
        private void ManufacturerDGV_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            ManNameTb.Text = ManufacturerDGV.SelectedRows[0].Cells[1].Value.ToString();
            ManAddTb.Text = ManufacturerDGV.SelectedRows[0].Cells[2].Value.ToString();
            ManPhoneTb.Text = ManufacturerDGV.SelectedRows[0].Cells[3].Value.ToString();
            ManJDate.Text = ManufacturerDGV.SelectedRows[0].Cells[4].Value.ToString();
            if (ManNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(ManufacturerDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select The Manufacturer");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from ManufacturerTbl where ManId=@MKey", Con);
                    cmd.Parameters.AddWithValue("@MKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Manufacturer Deleted");
                    Con.Close();
                    ShowMan();
                    Reset();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void Reset()
        {
            ManNameTb.Text = "";
            ManAddTb.Text = "";
            ManPhoneTb.Text = "";
            Key = 0;
        }
        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (ManAddTb.Text == "" || ManNameTb.Text == "" || ManPhoneTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Update ManufacturerTbl Set ManName=@MN,ManAdd=@MA,ManPhone=@MP,ManJDate=@MJD where ManId=@MKey", Con);
                    cmd.Parameters.AddWithValue("@MN", ManNameTb.Text);
                    cmd.Parameters.AddWithValue("@MA", ManAddTb.Text);
                    cmd.Parameters.AddWithValue("@MP", ManPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@MJD", ManJDate.Value.Date);
                    cmd.Parameters.AddWithValue("@MKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Manufacturer Update");
                    Con.Close();
                    ShowMan();
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

        private void label16_Click(object sender, EventArgs e)
        {
            Customer Obj = new Customer();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Customer Obj = new Customer();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Sellers Obj = new Sellers();
            Obj.Show();
            this.Hide();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            Sellers Obj = new Sellers();
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
    }
}
