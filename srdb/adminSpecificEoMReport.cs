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
    public partial class adminSpecificEoMReport : Form
    {
        public adminSpecificEoMReport()
        {
            InitializeComponent();
        }

        private void adminSpecificEoMReport_Load(object sender, EventArgs e)
        {
            //Form loading, code goes here -->
            for (int i = 1900; i < Convert.ToInt32(DateTime.Today.Year); i++)
            {
               
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            //--> Main Button here, all code goes here!

        }
    }
}
