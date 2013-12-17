using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient; //required for MySQL Connections
// using System.Security.Cryptography; //required for generating SHA1 values

namespace srdb
{ 
    public partial class adminControlPanelLogin : Form
    {
        private DBConnect dbConnect;
        private string pass;
        private string hashed_pass;
        private string user_level;

        public adminControlPanelLogin()
        {
            InitializeComponent();
            dbConnect = new DBConnect();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                dbConnect.login_initialise();
                dbConnect.login_Open_Connection();
                string login_query = "SELECT * FROM Auth WHERE username=@username AND pass=@pass";
                MySqlCommand cmd = new MySqlCommand();
                pass = txtPassword.Text;
                hashed_pass = dbConnect.hash_value(pass); //creates a hashed value for the password
                cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@pass", hashed_pass);
                MySqlDataReader reader = new MySqlDataReader();
                while (reader.Read())
                {
                    user_level = reader.GetString(reader.GetOrdinal("user_level"));
                    if (reader.HasRows == true && user_level == "Admin")
                        MessageBox.Show("Welcome!");
                    this.Close();
                    Form adminControlMenu = new Form();
                    if (reader.HasRows == false)
                    {
                        MessageBox.Show("Wrong Username or Password");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Logging in" + ex);
            }
        }
    }
}
