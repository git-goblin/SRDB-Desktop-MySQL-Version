using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace srdb
{
    public partial class adminSearchQuery : Form
    {
        private DBConnect dbConnect;
        public adminSearchQuery()
        {
            dbConnect = new DBConnect();
            InitializeComponent();
        }

        DataTable table = new DataTable(); //create a new DataTable, declared here as a global variable so it can be searched and used to created the DataGridView
        void fillData()
        {
            dbConnect.Initialize();
            dbConnect.OpenConnection();
            using (MySqlDataAdapter dataAdaptor = new MySqlDataAdapter(txtSQLQuery.Text, dbConnect.connection)) //create a new DataAdaptor
            {
                dataAdaptor.Fill(table); //File the table with the values from the DataAdaptor
                dataGridView1.DataSource = table; //Set the source, so where the DataGridView gets its value from at the table we have passed the values from the DataAdaptor into
                dataGridView1.MultiSelect = false; //stop users from selecting more than one row
            }
        }
        private void btnEditRecord_Click(object sender, EventArgs e)
        {
            Form editForm = new Form();
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form adminControlMenu = new Form();
        }

        private void btnRunQuery_Click(object sender, EventArgs e)
        {
            fillData();
        }
    }
}
