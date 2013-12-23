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
            mainMenu mm = new mainMenu();
            mm.Show();
        }

        private void adminComboBoxAmmed_Load(object sender, EventArgs e)
        {
            //fill the comboboxes here!!!
            string m_table = "SELECT * FROM model";
            string sb_table = "SELECT * FROM soldBy";
            string sbr_table = "SELECT * FROM salesBranch";
            string t_table = "SELECT * FROM type";
            string pm_table = "SELECT * FROM paymentMethod";

            dbConnect.fill_data(m_table);
            dataGridViewModel.DataSource = dbConnect.table;
            dataGridViewModel.MultiSelect = false;

            dbConnect.fill_data(sb_table);
            dataGridViewSoldBy.DataSource = dbConnect.table;
            dataGridViewSoldBy.MultiSelect = false;

            dbConnect.fill_data(sbr_table);
            dataGridViewSalesBranch.DataSource = dbConnect.table;
            dataGridViewSalesBranch.MultiSelect = false;

            dbConnect.fill_data(t_table);
            dataGridViewType.DataSource = dbConnect.table;
            dataGridViewType.MultiSelect = false;

            dbConnect.fill_data(pm_table);
            dataGridViewPaymentMethod.DataSource = dbConnect.table;
            dataGridViewPaymentMethod.MultiSelect = false;
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
       

    }
}
