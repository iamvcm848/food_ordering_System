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
    public partial class ManageItems : Form
    {
        private string conn;
        private MySqlConnection connect;
        public ManageItems()
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
            MySqlCommand cmd1 = new MySqlCommand();
            cmd1.Connection = connect;
           // string name = comboBox1.GetItemText(this.comboBox1.SelectedItem);
            cmd1.CommandText = "select name from food_item where name = @fn";
            cmd1.Parameters.AddWithValue("@fn",textBox1.Text);
            MySqlDataReader login = cmd1.ExecuteReader();
            if (login.Read())
            {
                MessageBox.Show("FOOD ITEM ALREADY PRESENT !!!");
               
            }
            
            else{
                login.Close();
                cmd.CommandText = "insert into food_item(NAME,PRICE) values('" +textBox1.Text + "','" + textBox2.Text + "') ";
                cmd.Connection = connect;
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Data Inserted Successfully !!!");
                    string name1 = "";
                    AdminMenu m = new AdminMenu(name1);
                    m.Show();
                    this.Hide();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int Flag = 0;
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            MySqlCommand cmd1 = new MySqlCommand();
            cmd1.Connection = connect;
            string name = comboBox1.GetItemText(this.comboBox1.SelectedItem);
            cmd1.CommandText = "select name from food_item where name = @fn";
            cmd1.Parameters.AddWithValue("@fn",name);
            MySqlDataReader login = cmd1.ExecuteReader();
            if (login.Read())
            {
                cmd.CommandText = "update food_item set NAME=@nm , PRICE=@P where NAME=@NM1 ";
                cmd.Connection = connect;
                cmd.Parameters.AddWithValue("@nm",name);
                cmd.Parameters.AddWithValue("@P", textBox2.Text);
                cmd.Parameters.AddWithValue("@NM1",name);
                //  cmd1.Parameters.AddWithValue("@n", textBox1.Text);
                Flag = 1;
            }
            login.Close();
            if (Flag == 1)
            {
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Data Updated Successfully !!!");
                    string name1 = "";
                    AdminMenu m = new AdminMenu(name1);
                    m.Show();
                    this.Hide();
                }
            }

            else
            {
                MessageBox.Show("FOOD ITEM NOT PRESENT !!!");
                login.Close();
            }
        }

        private void ManageItems_Load(object sender, EventArgs e)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
          //  MySqlCommand cmd1 = new MySqlCommand();
            cmd.CommandText = "Select * from food_item ";
            //cmd1.CommandText = "Select * from sr_no ";
            cmd.Connection = connect;
            //cmd1.Connection = connect;
            MySqlDataReader login = cmd.ExecuteReader();
            //  table.Columns.Add("Food Name", typeof(string));// datatype string
            //table.Columns.Add("QUANTITY", typeof(string));// datatype string
           // dataGridView1.DataSource = table;

            while (login.Read())
            {
                comboBox1.Items.Add(login.GetString("name"));

            }
            login.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
