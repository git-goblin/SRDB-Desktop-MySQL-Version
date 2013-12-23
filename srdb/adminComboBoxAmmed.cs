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
    public partial class adminComboBoxAmmed : Form
    {
        private DBConnect dbConnect;
        private validate val;
        public adminComboBoxAmmed()
        {
            dbConnect = new DBConnect();
            val = new validate();
            InitializeComponent();
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            adminControlMenu acm = new adminControlMenu();
            acm.Show();
        }

        private void adminComboBoxAmmed_Load(object sender, EventArgs e)
        {
            //fill the comboboxes here!!!
            load_and_refresh_combobox_values();
           
        }
        //model CB starts here
        private void btnAddValueModel_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteModel_Click(object sender, EventArgs e)
        {

        }
        //soldBy CB starts here
        private void btnAddValueSoldBy_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteSoldBy_Click(object sender, EventArgs e)
        {

        }
        //salesBranch CB starts here
        private void btnAddValueSalesBranch_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteSalesBranchID_Click(object sender, EventArgs e)
        {

        }
        //type CB starts here
        private void btnAddValueType_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteTypeID_Click(object sender, EventArgs e)
        {

        }
        //paymentMethod CB starts here
        private void btnAddValuePaymentMethod_Click(object sender, EventArgs e)
        {

        }

        private void btnDeletePaymentMethodID_Click(object sender, EventArgs e)
        {

        }
       
        private void load_and_refresh_combobox_values()
        {
            dbConnect.fill_data_model();
            dataGridViewModel.DataSource = dbConnect.m_table;
            dataGridViewModel.MultiSelect = false;

            dbConnect.fill_data_soldBy();
            dataGridViewSoldBy.DataSource = dbConnect.sb_table;
            dataGridViewSoldBy.MultiSelect = false;

            dbConnect.fill_data_salesBranch();
            dataGridViewSalesBranch.DataSource = dbConnect.sbr_table;
            dataGridViewSalesBranch.MultiSelect = false;

            dbConnect.fill_data_type();
            dataGridViewType.DataSource = dbConnect.t_table;
            dataGridViewType.MultiSelect = false;

            dbConnect.fill_data_paymentMethod();
            dataGridViewPaymentMethod.DataSource = dbConnect.pm_table;
            dataGridViewPaymentMethod.MultiSelect = false;
        }

        private void btnRefreshConnection_Click(object sender, EventArgs e)
        {
            load_and_refresh_combobox_values();
        }
    }
}
