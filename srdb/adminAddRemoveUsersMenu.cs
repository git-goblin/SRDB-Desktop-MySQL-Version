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
    public partial class adminAddRemoveUsersMenu : Form
    {
        public adminAddRemoveUsersMenu()
        {
            InitializeComponent();
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            adminAddUser aau = new adminAddUser();
            aau.Show();
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            adminDeleteUser adu = new adminDeleteUser();
            adu.Show();
        }

        private void btnViewAllUsers_Click(object sender, EventArgs e)
        {
            this.Hide();
            adminViewAllUsers avau = new adminViewAllUsers();
            avau.Show();
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            adminControlMenu acm = new adminControlMenu();
            acm.Show();
        }
    }
}
