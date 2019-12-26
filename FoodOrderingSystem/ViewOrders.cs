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
    public partial class ViewOrders : Form
    {
        private string conn;
        private MySqlConnection connect;
        DataTable table = new DataTable();
        
        public ViewOrders()
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
            string name = "";
            AdminMenu m = new AdminMenu(name);
            m.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // dataGridView1.DataSource = null;
            //dataGridView1.Rows.Clear();
            table.Clear();
            string name = "";
            int flag = 0;
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataAdapter da = new MySqlDataAdapter();
            cmd.CommandText = "Select * from bill where date=@user ";
            cmd.Parameters.AddWithValue("@user",dateTimePicker1.Text);
            MessageBox.Show(dateTimePicker1.Text);
            cmd.Connection = connect;
            MySqlDataReader login = cmd.ExecuteReader();
            if (login.Read())
            {
                da = new MySqlDataAdapter();
                //fetching query in the database.
                da.SelectCommand = cmd;
                //initialize new datatable
                // dt = new DataTable();
                //refreshes the rows in specified range in the datasource. 
                flag = 1;
               // connect.Close();

            }
            login.Close();
            if(flag==1)
            {
               // dataGridView1.AllowUserToAddRows = false;
                da.Fill(table);
                dataGridView1.DataSource = table;
                
            }
            else
            {
               // MessageBox.Show("bye ye=jernf");
                AdminMenu m = new AdminMenu(name);
                m.Show();
                this.Hide();
            }
            // da.Fill(table1);
            // dataGridView1.DataSource = table1;
            //  da.Fill(null);
            //  table.DataSet.Clear();
           
        }
       
        private void ViewOrders_Load(object sender, EventArgs e)
        {

            // table.Columns.Add("Food Name", typeof(string));// datatype string
            //table.Columns.Add("QUANTITY", typeof(string));// datatype string
            // dataGridView1.DataSource = table;
            
           // this.BindDataGridView();
            //this.BindDataGridView();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
