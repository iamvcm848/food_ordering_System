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
    public partial class AdminUpdate : Form
    {
        private string conn;
        private MySqlConnection connect;
        String name = "";
        public AdminUpdate(string uname)
        {
            name = uname;
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

        private void AdminUpdate_Load(object sender, EventArgs e)
        {
            label8.Text = name;
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "Select * from admin_data where username=@user ";
            cmd.Parameters.AddWithValue("@user",name);
            cmd.Connection = connect;
            MySqlDataReader login = cmd.ExecuteReader();
            if (login.Read())
            {
                textBox1.Text = (login["restaurant_name"].ToString());
                textBox2.Text = (login["owner_name"].ToString());
                textBox3.Text = (login["ph_no"].ToString());
                textBox5.Text = (login["city"].ToString());
                textBox4.Text = (login["username"].ToString());
                textBox6.Text = (login["password"].ToString());
            }
            connect.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "update admin_data  set restaurant_name=@rn,owner_name=@on,ph_no=@pn,city=@c,username=@un,password=@p where username=@un1";
            cmd.Parameters.AddWithValue("@rn",textBox1.Text);
            cmd.Parameters.AddWithValue("@on", textBox2.Text);
            cmd.Parameters.AddWithValue("@pn", textBox3.Text);
            cmd.Parameters.AddWithValue("@c", textBox5.Text);
            cmd.Parameters.AddWithValue("@un", textBox4.Text);
            cmd.Parameters.AddWithValue("@p", textBox6.Text);
            cmd.Parameters.AddWithValue("@un1",name);
            name = textBox4.Text;
            cmd.Connection = connect;
            cmd.ExecuteNonQuery();
            //string name = "";
            AdminMenu m = new AdminMenu(name);
            m.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           // string name = "";
            AdminMenu m = new AdminMenu(name);
            m.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "delete from admin_data where username=@un1";
            cmd.Parameters.AddWithValue("@un1", name);
           
           //ame = textBox4.Text;
            cmd.Connection = connect;
            cmd.ExecuteNonQuery();
            //string name = "";
           //dminMenu m = new AdminMenu(name);
            Form1 m = new Form1();
            m.Show();
            this.Hide();
        }
    }
}
