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

    public partial class delivery : Form
    {
        string username = "";
        private string conn;
        private MySqlConnection connect;
        public delivery(string user)
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

        private void delivery_Load(object sender, EventArgs e)
        {
            db_connection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "Select * from user_data where username=@user ";
            cmd.Parameters.AddWithValue("@user", username);
            cmd.Connection = connect;
            MySqlDataReader login = cmd.ExecuteReader();
            if (login.Read())
            {

                label1.Text = (login["h_data"].ToString());
                label3.Text = (login["city"].ToString());

                connect.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserMenu m = new UserMenu(username);
            m.Show();
            this.Hide();
        }
    }
}
