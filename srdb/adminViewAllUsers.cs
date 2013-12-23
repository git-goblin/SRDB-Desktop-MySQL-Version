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
    public partial class adminViewAllUsers : Form
    {
        private DBConnect dbConnect;
        public adminViewAllUsers()
        {
            dbConnect = new DBConnect();
            InitializeComponent();
        }
        DataTable table = new DataTable(); //create a new DataTable, declared here as a global variable so it can be searched and used to created the DataGridView
        void fillData()
        {
            dbConnect.Initialize();
            dbConnect.OpenConnection();
            using (MySqlDataAdapter dataAdaptor = new MySqlDataAdapter("SELECT * FROM auth", dbConnect.connection)) //create a new DataAdaptor
            {
                dataAdaptor.Fill(table); //File the table with the values from the DataAdaptor
                dataGridView1.DataSource = table; //Set the source, so where the DataGridView gets its value from at the table we have passed the values from the DataAdaptor into
                dataGridView1.MultiSelect = false; //stop users from selecting more than one row
            }

        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            adminControlMenu acm = new adminControlMenu();
            acm.Show();        }

        private void txtSearchByName_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(table);
            dv.RowFilter = string.Format("firstName LIKE '%{0}%' OR surName LIKE '%{0}%'", txtSearchByName.Text);
            dataGridView1.DataSource = dv;
        }

        private void adminViewAllUsers_Load(object sender, EventArgs e)
        {
            fillData();
        }
    }
}
