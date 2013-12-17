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
            Form adminAddUser = new Form();
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            Form adminDeleteUser = new Form();
        }

        private void btnViewAllUsers_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form adminViewAllUsers = new Form();
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form adminControlMenu = new Form();
        }
    }
}
