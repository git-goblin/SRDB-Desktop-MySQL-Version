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
using System.Security.Cryptography;

namespace srdb
{
    public partial class login : Form
    {
        private DBConnect dbConnect;
        private string pass;
        private string hashed_pass;
      

        public login()
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
                string login_query = "SELECT * FROM auth WHERE username=@username AND pass=@pass";
                MySqlCommand cmd = new MySqlCommand(login_query, dbConnect.connection);
                pass = txtPassword.Text;
                hashed_pass = dbConnect.hash_value(pass); //creates a hashed value for the password
                cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@pass", hashed_pass);
                using (MySqlDataReader reader = cmd.ExecuteReader()) 
                {    
                while (reader.Read())
                {
                    if (reader.HasRows == true)
                        MessageBox.Show("Welcome!");
                        this.Close();
                        Form mainMenu = new Form(); 
                    if (reader.HasRows == false)
                    {
                        MessageBox.Show("Wrong Username or Password"); 
                    }
                }
                }
            } 
            catch (Exception ex)
            {
                MessageBox.Show("Error while logging in" + ex); 
            }
        }
    }
}
