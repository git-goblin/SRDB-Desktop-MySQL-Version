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
    public partial class adminServicesReports : Form
    {
        public adminServicesReports()
        {
            InitializeComponent();
        }

        private void btnEoMReport_Click(object sender, EventArgs e)
        {
            this.Hide();
            adminEoMReport aar = new adminEoMReport();
            aar.Show();
        }

        private void btnMonthYearReport_Click(object sender, EventArgs e)
        {
            this.Hide();
            adminSpecificEoMReport aser = new adminSpecificEoMReport();
            aser.Show();
        }

        private void btnSQLReport_Click(object sender, EventArgs e)
        {
            this.Hide();
            adminSQLServiceReport assr = new adminSQLServiceReport();
            assr.Show();
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            adminControlMenu acm = new adminControlMenu();
            acm.Show();
        }
    }
}
