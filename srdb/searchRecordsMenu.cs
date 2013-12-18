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
    public partial class searchRecordsMenu : Form
    {
        public searchRecordsMenu()
        {
            InitializeComponent();
        }

        private void btnSearchName_Click(object sender, EventArgs e)
        {
            this.Hide();
            searchByName sbn = new searchByName();
            sbn.Show();
        }

        private void btnSearchInvoiceNumber_Click(object sender, EventArgs e)
        {
            this.Hide(); 
            searchInvoiceNumber sinbr = new searchInvoiceNumber();
            sinbr.Show();
        }

        private void btnSearchSoldyBy_Click(object sender, EventArgs e)
        {
            this.Hide();
            soldBySearch sbs = new soldBySearch();
            sbs.Show();
        }

        private void btnSearchDate_Click(object sender, EventArgs e)
        {
            this.Hide();
            searchByDate sbd = new searchByDate();
            sbd.Show();
        }

        private void btnSearchSRDBID_Click(object sender, EventArgs e)
        {
            this.Hide();
            searchServiceRecordID ssrid = new searchServiceRecordID();
            ssrid.Show();
        }
    }
}
