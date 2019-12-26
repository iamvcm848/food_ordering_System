using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace FoodOrderingSystem
{
    public partial class AdminLogin : Form
    {
        private string conn;
        private MySqlConnection connect;
        public AdminLogin()
        {
            InitializeComponent();
        }
        private void db_connection()
        {
            try
            {
                conn = "server=localhost;user id=root;database=restaurant";
                connect = new MySqlConnection(conn);
                connect.Open();
            }
            catch (MySqlException e)
            {
                throw;
            }
        }
        private bool validate_login(string user, string pass)
        {
              db_connection();
              MySqlCommand cmd = new MySqlCommand();
              cmd.CommandText = "Select * from admin_data where username=@user and password=@pass";
             cmd.Parameters.AddWithValue("@user", user);
             cmd.Parameters.AddWithValue("@pass", pass);
              cmd.Connection = connect;
              MySqlDataReader login = cmd.ExecuteReader();
              if (login.Read())
              {
                  connect.Close();
                  return true;
              }
              else
              {
                  connect.Close();
                  return false;
              }    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            string pass = textBox2.Text;
            if (user == "" || pass == "")
            {
                MessageBox.Show("Empty Fields Detected ! Please fill up all the fields");
                return;
            }
            bool r = validate_login(user, pass);
            if (r)
            {
                MessageBox.Show("Correct Login Credentials");
                AdminMenu m = new AdminMenu(user);
                m.Show();
                this.Hide();
            }
                
            else
            MessageBox.Show("Incorrect Login Credentials");  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminSignUp m = new AdminSignUp();
            m.Show();
            this.Hide();
        }

        private void AdminLogin_Load(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar =false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }
    }
}
