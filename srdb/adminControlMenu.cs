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

        }

        private void btnAmmendCombox_Click(object sender, EventArgs e)
        {

        }

        private void btnSQLQuery_Click(object sender, EventArgs e)
        {

        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Close(); 
            Form mainMenu = new Form();
        }
    }
}
