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
    public partial class NewOrder : Form
    {
        private string conn;
        private MySqlConnection connect;
        DataTable table = new DataTable();
        string username = "";
        int total = 0;
        public NewOrder(string user)
        {
            InitializeComponent();
            DateTime thisDay = DateTime.Today;
            label6.Text=thisDay.ToString("d");
            username = user;
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
        private void button3_Click(object sender, EventArgs e)
        {
            string name = "";
            AdminMenu m = new AdminMenu(name);
            m.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            db_connection();
            int no=0,N=0,total=0;
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "Select * from sr_no ";
            cmd.Connection = connect;
            MySqlDataReader login = cmd.ExecuteReader();
            while (login.Read())
            {
                no = login.GetUInt16("number");
               
            }
           login.Close();
          /*  MySqlCommand cmd2 = new MySqlCommand();
            cmd2.CommandText = "insert into bill_ref(sr_no,id_no) values(@new,@new1)";
            cmd2.Parameters.AddWithValue("@new", no);
            cmd2.Parameters.AddWithValue("@new1", username);
            cmd2.Connection = connect;
            cmd2.ExecuteNonQuery(); */

            MySqlCommand cmd1 = new MySqlCommand();
            cmd1.CommandText = "update sr_no set number=@new ";
            N = no + 1;
            cmd1.Parameters.AddWithValue("@new",N);
            cmd1.Connection = connect;
            cmd1.ExecuteNonQuery();
            // string name = "";


            ////////
            string query = "SELECT item_name,quantity,price,quantity*price FROM bill inner join food_item where item_name=name and bill_no=@bn";
            //initialize new Sql commands
            MySqlCommand cmd3 = new MySqlCommand();
            cmd3 = new MySqlCommand();
            // textBox1.Text = (login["name"].ToString());
            //hold the data to be executed.
            cmd3.Connection = connect;
            cmd3.Parameters.AddWithValue("@bn", label7.Text);
            cmd3.CommandText = query;
            MySqlDataReader login1 = cmd3.ExecuteReader();
            while (login1.Read())
            {
                string number = (login1["quantity*price"].ToString());
                int x = Int16.Parse(number);
                total = total + x;
            }
            login1.Close();
            ////////

            //textBox3.Text = total.ToString();
            MessageBox.Show("YOUR TOTAL AMOUNT IS : Rs "+total.ToString());



            delivery m = new delivery(username);
            m.Show();
            this.Hide();
        }

        private void NewOrder_Load(object sender, EventArgs e)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            MySqlCommand cmd1 = new MySqlCommand();
            cmd.CommandText = "Select * from food_item ";
            cmd1.CommandText = "Select * from sr_no ";
            cmd.Connection = connect;
            cmd1.Connection = connect;
            MySqlDataReader login = cmd.ExecuteReader();
          //  table.Columns.Add("Food Name", typeof(string));// datatype string
            //table.Columns.Add("QUANTITY", typeof(string));// datatype string
            dataGridView1.DataSource = table;
    
            while (login.Read())
            {
                comboBox1.Items.Add(login.GetString("name"));
                
            }
            login.Close();

            MySqlDataReader login1 = cmd1.ExecuteReader();
            while (login1.Read())
            {
           
                label7.Text = login1.GetString("number");
            }
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            table.Clear();
            total = 0;
            int t1 = 0;
            string name = comboBox1.GetItemText(this.comboBox1.SelectedItem);
            int no = Convert.ToInt32(numericUpDown1.Value);
                
               // domainUpDown1.SelectedIndex;
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataAdapter da = new MySqlDataAdapter();
            cmd.CommandText = "insert into bill(bill_no,item_name,quantity,date,u_id) values('" + label7.Text + "','" + name + "','" + no + "','" + label6.Text + "','"+username+"') ";
            cmd.Connection = connect;
            if (cmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Data Inserted Successfully !!!");
            }


           string query = "SELECT item_name,quantity,price,quantity*price FROM bill inner join food_item where item_name=name and bill_no=@bn";
            //initialize new Sql commands
            cmd = new MySqlCommand();
           // textBox1.Text = (login["name"].ToString());
            //hold the data to be executed.
            cmd.Connection = connect;
            cmd.Parameters.AddWithValue("@bn",label7.Text);
            cmd.CommandText = query;
            MySqlDataReader login = cmd.ExecuteReader();
            while (login.Read())
            {
                string number = (login["quantity*price"].ToString());
                int x = Int16.Parse(number);
                total = total + x;
            }
            login.Close();
            //initialize new Sql data adapter
            da = new MySqlDataAdapter();
            //fetching query in the database.
            da.SelectCommand = cmd;
            //initialize new datatable
           // dt = new DataTable();
            //refreshes the rows in specified range in the datasource. 
            da.Fill(table);
             dataGridView1.DataSource = table;
            t1 = total;
           // textBox3.Text = t1.ToString();
            
          
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string item = "";
            int t1 = 0;
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
           
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                item = this.dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                MessageBox.Show(item);
               // this.dataGridView1.SelectedRows[0].Cells[1].Value;
                dataGridView1.Rows.RemoveAt(this.dataGridView1.SelectedRows[0].Index);
            }

           
            
            cmd.CommandText = "delete from bill where item_name=@un1";
            cmd.Parameters.AddWithValue("@un1", item);
            cmd.Connection = connect;
            cmd.ExecuteNonQuery();
            //initialize new Sql data adapter
            //// da = new MySqlDataAdapter();
            //fetching query in the database.
            //da.SelectCommand = cmd1;
            connect.Close();
            //initialize new datatable
            // dt = new DataTable();
            //refreshes the rows in specified range in the datasource. 

           // t1 = total;
           // textBox3.Text = t1.ToString();

        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
