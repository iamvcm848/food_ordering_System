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
    public partial class ViewBooking : Form
    {
        private string conn;
        private MySqlConnection connect;
        DataTable table = new DataTable();
        string username = "";
        public ViewBooking(string user)
        {
            InitializeComponent();
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

        private void button1_Click(object sender, EventArgs e)
        {
            string name = "";
            UserMenu m = new UserMenu(username);
            m.Show();
            this.Hide();
        }

        private void ViewBooking_Load(object sender, EventArgs e)
        {
            int flag = 0;
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            MySqlDataAdapter da = new MySqlDataAdapter();
            string query = "SELECT bill_no,item_name,quantity,date FROM bill where u_id=@un1";
            //initialize new Sql commands
            cmd = new MySqlCommand();
            cmd.Parameters.AddWithValue("@un1",username);
            //hold the data to be executed.
            cmd.Connection = connect;
            cmd.CommandText = query;
            //initialize new Sql data adapter
            da = new MySqlDataAdapter();
            //fetching query in the database.
            da.SelectCommand = cmd;
            //initialize new datatable
            // dt = new DataTable();
            //refreshes the rows in specified range in the datasource. 
            da.Fill(table);
            dataGridView1.DataSource = table;

        }
    }
}
