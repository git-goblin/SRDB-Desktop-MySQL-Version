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
                dbConnect.login_initialise(); //creates connection string
                dbConnect.login_Open_Connection(); //opens the connection
                string login_query = "SELECT username FROM auth WHERE username=@username AND pass=@pass";
                MySqlCommand cmd = new MySqlCommand(login_query, dbConnect.connection);
                pass = txtPassword.Text;
                hashed_pass = dbConnect.hash_value(pass); //creates a hashed value for the password
                cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@pass", hashed_pass);
                if (cmd.ExecuteScalar() != null)
                {
                    dbConnect.CloseConnection();
                    this.Hide();
                    mainMenu mm = new mainMenu();
                    mm.Show(); 
                }
                else 
                {
                    MessageBox.Show("Wrong Username or Password","Error!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error while logging in " + ex, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void login_Load(object sender, EventArgs e)
        {
            try
            {
                int stat;
                long lat;
                dbConnect.ping_test(out stat, out lat);
                lblLatency.Text = string.Empty;
                lblServerStatus.Text = string.Empty;

                //Display the server status
                if (stat == 1)
                {
                    lblServerStatus.Text = "Up";
                    lblServerStatus.ForeColor = Color.Green;
                }
                else if (stat != 1)
                {
                    lblServerStatus.Text = "Unreachable";
                    lblServerStatus.ForeColor = Color.Red;
                }

                //Display the latency
                if (lat <= 200)
                {
                    lblLatency.Text = lat + "ms";
                    lblLatency.ForeColor = Color.Green;
                }
                else if (lat > 200 && lat <= 350)
                {
                    lblLatency.Text = lat + "ms";
                    lblLatency.ForeColor = Color.Yellow;
                }
                else if (lat > 350 && lat <= 500)
                {
                    lblLatency.Text = lat + "ms";
                    lblLatency.ForeColor = Color.Orange;
                }
                else if (lat > 500)
                {
                    lblLatency.Text = lat + "ms";
                    lblLatency.ForeColor = Color.Red;
                }
                else if (lat >= 9999)
                {
                    lblLatency.Text = "Unreachable";
                    lblLatency.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting server status " + ex, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
