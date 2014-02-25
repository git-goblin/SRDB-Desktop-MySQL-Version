using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace srdb
{
    public partial class adminServerConnections : Form
    {
        private crypto crytp;
        public adminServerConnections()
        {
            crytp = new crypto();
            InitializeComponent();
        }

        private void adminServerConnections_Load(object sender, EventArgs e)
        {
            //on load, pull the values
            
            //ComboBox

            txtCBDB.Text = ConfigurationManager.AppSettings["cb_database"];
            txtCBPassword.Text = ConfigurationManager.AppSettings["cb_pass"];
            txtCBServer.Text = ConfigurationManager.AppSettings["cb_server"];
            txtCBUser.Text = ConfigurationManager.AppSettings["cb_username"];

            //Database

            txtDBDB.Text = ConfigurationManager.AppSettings["database"];
            txtDBPass.Text = ConfigurationManager.AppSettings["pass"];
            txtDBServer.Text = ConfigurationManager.AppSettings["server"];
            txtDBUser.Text = ConfigurationManager.AppSettings["username"];

            //Login

            txtLDB.Text = ConfigurationManager.AppSettings["l_database"]; 
            txtLPassword.Text = ConfigurationManager.AppSettings["l_pass"];
            txtLServer.Text = ConfigurationManager.AppSettings["l_server"];
            txtLUser.Text = ConfigurationManager.AppSettings["l_username"];

            //Services

            txtSDB.Text = ConfigurationManager.AppSettings["s_database"];
            txtSPassword.Text = ConfigurationManager.AppSettings["s_pass"];
            txtSServer.Text = ConfigurationManager.AppSettings["s_server"];
            txtSUser.Text = ConfigurationManager.AppSettings["s_username"];
        }

        private void txtSave_Click(object sender, EventArgs e)
        {
            if (txtCBDB.Text != "" && txtCBPassword.Text != "" && txtCBServer.Text != "" && txtCBUser.Text != "" && txtDBDB.Text != "" && txtDBPass.Text != "" && txtDBServer.Text != "" && txtDBUser.Text != "" && txtLDB.Text != "" && txtLPassword.Text != "" && txtLServer.Text != "" && txtLUser.Text != "")
            {
                try
                {
                    //do stuff here
                    UpdateSettings("cb_database", txtCBDB.Text);
                    UpdateSettings("cb_pass", txtCBPassword.Text);
                    UpdateSettings("cb_server", txtCBServer.Text);
                    UpdateSettings("cb_username", txtCBUser.Text);

                    UpdateSettings("database", txtDBDB.Text);
                    UpdateSettings("pass", txtDBPass.Text);
                    UpdateSettings("server", txtDBServer.Text);
                    UpdateSettings("username", txtDBUser.Text);

                    UpdateSettings("l_database", txtLDB.Text);
                    UpdateSettings("l_pass", txtLPassword.Text);
                    UpdateSettings("l_server", txtLServer.Text);
                    UpdateSettings("l_username", txtLUser.Text);

                    UpdateSettings("s_database", txtSDB.Text);
                    UpdateSettings("s_pass", txtSPassword.Text);
                    UpdateSettings("s_server", txtSServer.Text);
                    UpdateSettings("s_username", txtSUser.Text);

                    MessageBox.Show("Config file updated!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("Error updating config file!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No fields can be left empty!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private static void UpdateSettings(string key, string value)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings[key].Value = value;
            configuration.Save();

            ConfigurationManager.RefreshSection("appSettings");
        }

        private void txtMainMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            adminControlMenu acm = new adminControlMenu();
            acm.Show();
        }
    }
}
