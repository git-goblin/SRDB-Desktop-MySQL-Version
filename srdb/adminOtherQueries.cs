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
    public partial class adminOtherQueries : Form
    {
        private DBConnect dbConnect;
        public adminOtherQueries()
        {
            dbConnect = new DBConnect();
            InitializeComponent();
        }

        private void btnExecuteQuery_Click(object sender, EventArgs e)
        {
            dbConnect.Initialize();
            dbConnect.OpenConnection();
            dbConnect.ExecuteQuery(txtSQLQuery.Text);
        }
    }
}
