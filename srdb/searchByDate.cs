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
    public partial class searchByDate : Form
    {
        private DBConnect dbConnect;
        public searchByDate()
        {
            InitializeComponent();
            dbConnect = new DBConnect();
        }

        DataTable table = new DataTable(); //create a new DataTable, declared here as a global variable so it can be searched and used to created the DataGridView
        void fillData()
        {
            dbConnect.Initialize();
            dbConnect.OpenConnection();
            using (MySqlDataAdapter dataAdaptor = new MySqlDataAdapter("SELECT * FROM records", dbConnect.connection)) //create a new DataAdaptor
            {
                dataAdaptor.Fill(table); //File the table with the values from the DataAdaptor
                dataGridView1.DataSource = table; //Set the source, so where the DataGridView gets its value from at the table we have passed the values from the DataAdaptor into
                dataGridView1.MultiSelect = true; //stop users from selecting more than one row
            }

        }

        private void btnEditRecord_Click(object sender, EventArgs e)
        {
            this.Hide();
            editForm ef = new editForm();
            ef.Show();
        }

        private void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete a row? Once it is deleted, it is permanently removed!", "Warning! Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                Form deleteRow = new Form();
            }
            if (dialogResult == DialogResult.No)
            {
                Close();
            }
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainMenu mm = new mainMenu();
            mm.Show();
        }

        private void txtSearchByName_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(table);
            dv.RowFilter = string.Format("date_sold LIKE '%{0}%'", txtSearchByDate.Text);
            dataGridView1.DataSource = dv;
        }

        private void searchByDate_Load(object sender, EventArgs e)
        {
            fillData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            table.Clear();
            fillData();
        }
    }
}
