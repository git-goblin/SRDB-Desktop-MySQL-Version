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
                string login_query = "SELECT * FROM auth WHERE username=@username AND pass=@pass AND user_level = 'Admin'";
                MySqlCommand cmd = new MySqlCommand(login_query, dbConnect.connection);
                pass = txtPassword.Text;
                hashed_pass = dbConnect.hash_value(pass); //creates a hashed value for the password
                cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@pass", hashed_pass);
                        if (cmd.ExecuteScalar() != null) // && user_level == "Admin")
                        {
                            dbConnect.login_CloseConnection();
                            this.Hide();
                            adminControlMenu acm = new adminControlMenu();
                            acm.Show();
                        }
                        else
                        {
                            MessageBox.Show("Wrong Username or Password", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
           
            catch (Exception ex)
            {
                MessageBox.Show("Error Logging in" + ex, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void adminControlPanelLogin_Load(object sender, EventArgs e)
        {
            try
            {
                int stat;
                long lat;
                dbConnect.ping_test(out stat, out lat);
                lblLatenc.Text = string.Empty;
                lblServerStat.Text = string.Empty;

                //Display the server status
                if (stat == 1)
                {
                    lblServerStat.Text = "Up";
                    lblServerStat.ForeColor = Color.Green;
                }
                else if (stat != 1)
                {
                    lblServerStat.Text = "Unreachable";
                    lblServerStat.ForeColor = Color.Red;
                }

                //Display the latency
                if (lat <= 200)
                {
                    lblLatenc.Text = lat + "ms";
                    lblLatenc.ForeColor = Color.Green;
                }
                else if (lat > 200 && lat <= 350)
                {
                    lblLatenc.Text = lat + "ms";
                    lblLatenc.ForeColor = Color.Yellow;
                }
                else if (lat > 350 && lat <= 500)
                {
                    lblLatenc.Text = lat + "ms";
                    lblLatenc.ForeColor = Color.Orange;
                }
                else if (lat > 500)
                {
                    lblLatenc.Text = lat + "ms";
                    lblLatenc.ForeColor = Color.Red;
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