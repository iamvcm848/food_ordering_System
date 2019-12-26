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
    public partial class UserUpdate : Form
    {
        private string conn;
        private MySqlConnection connect;
        String name = "";
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
        public UserUpdate(string uname)
        {
            InitializeComponent();
            name = uname;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "update user_data  set name=@rn,ph_no=@on,h_data=@pn,city=@c,username=@un,password=@p where username=@un1";
            cmd.Parameters.AddWithValue("@rn", textBox1.Text);
            cmd.Parameters.AddWithValue("@on", textBox2.Text);
            cmd.Parameters.AddWithValue("@pn", textBox3.Text);
            cmd.Parameters.AddWithValue("@c", textBox4.Text);
            cmd.Parameters.AddWithValue("@un", textBox5.Text);
            cmd.Parameters.AddWithValue("@p", textBox6.Text);
            cmd.Parameters.AddWithValue("@un1", name);
            name = textBox5.Text;
            cmd.Connection = connect;
            cmd.ExecuteNonQuery();
            UserMenu m = new UserMenu(name);
            m.Show();
            this.Hide();
        }

        private void UserUpdate_Load(object sender, EventArgs e)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "Select * from user_data where username=@user ";
            cmd.Parameters.AddWithValue("@user", name);
            cmd.Connection = connect;
            MySqlDataReader login = cmd.ExecuteReader();
            if (login.Read())
            {
                textBox1.Text = (login["name"].ToString());
                textBox2.Text = (login["ph_no"].ToString());
                textBox3.Text = (login["h_data"].ToString());
                textBox4.Text = (login["city"].ToString());
                textBox5.Text = (login["username"].ToString());
                textBox6.Text = (login["password"].ToString());
            }
            connect.Close();
        }
    }
}
