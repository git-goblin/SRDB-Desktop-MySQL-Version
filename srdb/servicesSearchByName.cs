﻿using System;
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
    public partial class servicesSearchByName : Form
    {
        private DBConnect dbConnect;
        public servicesSearchByName()
        {
            dbConnect = new DBConnect();
            InitializeComponent();
        }

      DataTable table = new DataTable(); //create a new DataTable, declared here as a global variable so it can be searched and used to created the DataGridView
        void fillData()
        {
            dbConnect.Initialize();
            dbConnect.OpenConnection();
            using (MySqlDataAdapter dataAdaptor = new MySqlDataAdapter("SELECT * FROM services", dbConnect.connection)) //create a new DataAdaptor
            {
                dataAdaptor.Fill(table); //File the table with the values from the DataAdaptor
                dataGridView1.DataSource = table; //Set the source, so where the DataGridView gets its value from at the table we have passed the values from the DataAdaptor into
                dataGridView1.MultiSelect = true; //stop users from selecting more than one row
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            table.Clear();
            fillData();
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            mainMenu mm = new mainMenu();
            mm.Show();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(table);
            dv.RowFilter = string.Format("firstName LIKE '%{0}%' OR surName LIKE '%{0}%'", txtSearch.Text);
            dataGridView1.DataSource = dv;
        }

        private void servicesSearchByName_Load(object sender, EventArgs e)
        {
            fillData();
        }
    }
}
