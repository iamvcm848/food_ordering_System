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
    public partial class UserMenu : Form
    {
        string username = "";
        public UserMenu(string user)
        {
            InitializeComponent();
            username = user;
        }

        private void button4_Click(object sender, EventArgs e)
        {
                Form1 m = new Form1();
            m.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NewOrder m = new NewOrder(username);
            m.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //  UserMenu m = new UserMenu();
            // m.Show();
            ViewBooking m = new ViewBooking(username);
            m.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserUpdate m = new UserUpdate(username);
            m.Show();
            this.Hide();
        }

        private void UserMenu_Load(object sender, EventArgs e)
        {
            label1.Text = "WELCOME " + username;
        }
    }
}
