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
    public partial class searchMenu : Form
    {
        public searchMenu()
        {
            InitializeComponent();
        }

        private void btnSearchRecords_Click(object sender, EventArgs e)
        {
            this.Hide();
            searchRecordsMenu srm = new searchRecordsMenu();
            srm.Show();
        }

        private void btnSearchServices_Click(object sender, EventArgs e)
        {
            this.Hide();
            servicesSearchMenu ssm = new servicesSearchMenu();
            ssm.Show();
        }
    }
}
