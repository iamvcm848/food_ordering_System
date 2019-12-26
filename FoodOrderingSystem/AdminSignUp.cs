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
    public partial class AdminSignUp : Form
    {
        string name = "";
        private string conn;
        private MySqlConnection connect;
        public AdminSignUp()
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

        private void button2_Click(object sender, EventArgs e)
        {
            
            AdminMenu m = new AdminMenu(name);
            m.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "insert into admin_data(RESTAURANT_NAME,OWNER_NAME,PH_NO,CITY,USERNAME,PASSWORD) values('"+textBox1.Text+ "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "') ";
            if (textBox1.Text=="")
            {
                MessageBox.Show("ENTER A VALID RESTAURANT NAME !!");
            }
           else if (textBox2.Text == "")
            {
                MessageBox.Show("ENTER A VALID OWNER NAME !!");
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("ENTER A VALID PHONE NUMBER !!");
            }
           else if(textBox3.Text.Length!=10)
            {
                MessageBox.Show("ENTER A VALID PHONE NUMBER !!");
            }
           else  if (textBox4.Text == "")
            {
                MessageBox.Show("ENTER A VALID CITY !!");
            }
           else if (textBox5.Text == "")
            {
                MessageBox.Show("ENTER A VALID USERNAME !!");
            }
           else if (textBox6.Text == "")
            {
                MessageBox.Show("ENTER A VALID PASSWORD !!");
            }
            else
            {
                cmd.Connection = connect;
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Data Inserted Successfully !!!");
                    name = textBox5.Text;
                    AdminMenu m = new AdminMenu(name);
                    m.Show();
                    this.Hide();
                }
            }
        }

        private void AdminSignUp_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
