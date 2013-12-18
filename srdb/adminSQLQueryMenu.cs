using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics; //Add to open link with default browser

namespace srdb
{
    public partial class adminSQLQueryMenu : Form
    {
        public adminSQLQueryMenu()
        {
            InitializeComponent();
        }

        private void linkLabelSQL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        { 
            ProcessStartInfo sInfo = new ProcessStartInfo("http://www.w3schools.com/sql/");
            Process.Start(sInfo);
        }

        private void btnSearchQuery_Click(object sender, EventArgs e)
        {
            this.Hide();
            adminSearchQuery asq = new adminSearchQuery();
            asq.Show();
        }

        private void btnOtherQueries_Click(object sender, EventArgs e)
        {
            this.Hide();
            adminOtherQueries aoq = new adminOtherQueries();
            aoq.Show();
        }
    }
}
