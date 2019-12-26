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
    public partial class UserSignUp : Form
    {
        private string conn;
        private MySqlConnection connect;
        public UserSignUp()
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

        private void button1_Click(object sender, EventArgs e)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();

            cmd.CommandText = "insert into user_data(NAME,PH_NO,H_DATA,CITY,USERNAME,PASSWORD) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "') ";
            if (textBox1.Text == "")
            {
                MessageBox.Show("ENTER A VALID NAME !!");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("ENTER A VALID PHONE NUMBER !!");
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("ENTER A VALID ADDRESS !!");
            }
            else if (textBox2.Text.Length != 10)
            {
                MessageBox.Show("ENTER A VALID PHONE NUMBER !!");
            }
            else if (textBox4.Text == "")
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
                }

                UserMenu m = new UserMenu(textBox5.Text);
                m.Show();
                this.Hide();
            }
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserMenu m = new UserMenu(textBox5.Text);
            m.Show();
            this.Hide();
        }
    }
}
