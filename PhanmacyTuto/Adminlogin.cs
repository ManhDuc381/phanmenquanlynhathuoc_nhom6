using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanmacyTuto
{
    public partial class Adminlogin : Form
    {
        public Adminlogin()
        {
            InitializeComponent();
        }
        private void label4_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }
        
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if(adminPassTb.Text == "")
            {

            }
            else if(adminPassTb.Text == "Admin")
            {
                
                Dashboard sellers = new Dashboard();
                sellers.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("WWrong Admin Password");
                adminPassTb.Text = "";
            }
            
        }

    }
}
