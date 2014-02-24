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
        public adminServerConnections()
        {
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
        }

        private void txtSave_Click(object sender, EventArgs e)
        {
            if (txtCBDB.Text != "" && txtCBPassword.Text != "" && txtCBServer.Text != "" && txtCBUser.Text != "" && txtDBDB.Text != "" && txtDBPass.Text != "" && txtDBServer.Text != "" && txtDBUser.Text != "" && txtLDB.Text != "" && txtLPassword.Text != "" && txtLServer.Text != "" && txtLUser.Text != "")
            {
                //do stuff here
            }
            else
            {
                MessageBox.Show("No fields can be left empty!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
