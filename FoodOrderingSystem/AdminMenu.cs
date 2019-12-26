using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoodOrderingSystem
{
    
    public partial class AdminMenu : Form
    {
        String username = "";
        public AdminMenu(string user)
        {
            
            InitializeComponent();
            username = user;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 m = new Form1();
            m.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminUpdate m = new AdminUpdate(username);
            m.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           ManageItems m = new ManageItems();
            m.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ViewOrders m = new ViewOrders();
            m.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AdminMenu_Load(object sender, EventArgs e)
        {
            label1.Text = "WELCOME "+username;
        }
    }
}
