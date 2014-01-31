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
    public partial class servicesSearchMenu : Form
    {
        public servicesSearchMenu()
        {
            InitializeComponent();
        }

        private void btnSByDate_Click(object sender, EventArgs e)
        {
            this.Hide();
            servicesSearchByDate ssbd = new servicesSearchByDate();
            ssbd.Show();
        }

        private void btnSByName_Click(object sender, EventArgs e)
        {
            this.Hide();
            servicesSearchByName ssbn = new servicesSearchByName();
            ssbn.Show();
        }

        private void btnSBySRID_Click(object sender, EventArgs e)
        {
            this.Hide();
            servicesSearchBySRID ssbs = new servicesSearchBySRID();
            ssbs.Show();
        }

        private void btnSByINum_Click(object sender, EventArgs e)
        {
            this.Hide();
            servicesSearchByInvoiceNumber ssbin = new servicesSearchByInvoiceNumber();
            ssbin.Show();
        }

        private void btnSByRegistration_Click(object sender, EventArgs e)
        {
            this.Hide();
            servicesSearchByRegistration ssbr = new servicesSearchByRegistration();
            ssbr.Show();
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainMenu mm = new mainMenu();
            mm.Show();
        }
    }
}
