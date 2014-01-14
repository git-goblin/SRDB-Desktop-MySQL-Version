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
    public partial class mainMenu : Form
    {
        public mainMenu()
        {
            InitializeComponent();
        }

        private void btnAddrecord_Click(object sender, EventArgs e)
        {
            this.Hide();
            addRecord ar = new addRecord();
            ar.Show();
        }

        private void btnSearchrecords_Click(object sender, EventArgs e)
        {
            this.Hide();
            searchRecordsMenu srm = new searchRecordsMenu();
            srm.Show();
        }

        private void btnAdminpanel_Click(object sender, EventArgs e)
        {
            this.Hide();
            adminControlPanelLogin acpl = new adminControlPanelLogin();
            acpl.Show();
        }

        private void btnGeneratePDF_Click(object sender, EventArgs e)
        {
            this.Hide();
            PDFGenerator pg = new PDFGenerator();
            pg.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnServices_Click(object sender, EventArgs e)
        {
            this.Hide();
            inputService inpts = new inputService();
            inpts.Show();
        }
    }
}
