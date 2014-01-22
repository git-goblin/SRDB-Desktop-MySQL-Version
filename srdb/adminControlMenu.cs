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
            this.Hide();
            deleteRow dr = new deleteRow();
            dr.Show();
        }

        private void btnAddRemoveUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            adminAddRemoveUsersMenu aarum = new adminAddRemoveUsersMenu();
            aarum.Show();
        }

        private void btnAmmendCombox_Click(object sender, EventArgs e)
        {
            this.Hide();
           // adminAmmendComboBoxes aacb = new adminAmmendComboBoxes();
           // aacb.Show(); 
            adminComboBoxAmmed acba = new adminComboBoxAmmed();
            acba.Show();
        }

        private void btnSQLQuery_Click(object sender, EventArgs e)
        {
            this.Hide();
            adminSQLQueryMenu asqm = new adminSQLQueryMenu();
            asqm.Show();
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainMenu mm = new mainMenu();
            mm.Show();
        }

        private void btnResetUserPassword_Click(object sender, EventArgs e)
        {
            this.Hide();
            adminResetUserPassword arup = new adminResetUserPassword();
            arup.Show();
        }

        private void btnEditRecord_Click(object sender, EventArgs e)
        {
            this.Hide();
            editForm ef = new editForm();
            ef.Show();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnServicesReports_Click(object sender, EventArgs e)
        {
            this.Hide();
            adminServicesReports asr = new adminServicesReports();
            asr.Show();
        }
    }
}
