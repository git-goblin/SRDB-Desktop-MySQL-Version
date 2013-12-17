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
            Form searchByName = new Form();
        }

        private void btnSearchInvoiceNumber_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form searchByInvoiceNumber = new Form();
        }

        private void btnSearchSoldyBy_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form soldBySearch = new Form();
        }

        private void btnSearchDate_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form searchByDate = new Form();
        }

        private void btnSearchSRDBID_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form searchServiceRecordID = new Form();
        }
    }
}
