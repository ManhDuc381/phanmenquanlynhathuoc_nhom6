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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\luuma\Downloads\PhamacyTuto\PhamacyTuto\DataBase\PharmacyCDb.mdf;Integrated Security=True;Connect Timeout=30");
        public static string user;
        private void label4_Click(object sender, EventArgs e)
        {
            Adminlogin adminlogin = new Adminlogin();
            adminlogin.Show();
            this.Hide();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (UNameTb.Text == "" || UPassTb.Text == "")
            {
                MessageBox.Show("Enter Both UserName or Password");
            }
            else
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from SellerTbl where SName='"+ UNameTb.Text + "' and SPass='"+ UPassTb.Text+ "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if(dt.Rows[0][0].ToString() == "1")
                {
                    user = UNameTb.Text;
                    Selling dashboard = new Selling(); 
                    dashboard.Show();
                    this.Hide();
                    Con.Close();
                }
                else
                {
                    MessageBox.Show("Wrong Username or Password");
                }
                Con.Close();
            }
        }

        private void ExitLbl_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
