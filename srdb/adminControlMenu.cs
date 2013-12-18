using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace srdb
{
    public partial class adminControlMenu : Form
    {
        public adminControlMenu()
        {
            InitializeComponent();
        }

        private void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            Form deleteRow = new Form();
        }

        private void btnAddRemoveUser_Click(object sender, EventArgs e)
        {
            this.Close();
            Form adminAddRemoveUsersMenu = new Form();
        }

        private void btnAmmendCombox_Click(object sender, EventArgs e)
        {
            this.Close();
            Form adminAmmendComboBoxes = new Form();
        }

        private void btnSQLQuery_Click(object sender, EventArgs e)
        {
            this.Close();
            Form adminSQLQueryMenu = new Form();
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Close(); 
            Form mainMenu = new Form();
        }

        private void btnResetUserPassword_Click(object sender, EventArgs e)
        {
          this.Close();
          Form adminResetUserPassword = new Form();
        }
    }
}
