﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

//using System.ComponentModel;
using System.Data;

using System.Threading.Tasks;
using MySql.Data.MySqlClient; //required for MySQL Connections
using System.Security.Cryptography; //required for generating SHA1 values
using System.Net.NetworkInformation; //Ping;
using System.Configuration; //Allows config file to be read



namespace srdb
{
    class DBConnect
    {
        public MySqlConnection connection;
        public MySqlConnection services_connection;
        public MySqlConnection login_connection;
        public MySqlConnection cb_connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        private crypto crytp;

        //Constructor
        public DBConnect()
        {
            crytp = new crypto();
            Initialize();
        }
        //Initialize values
        public void Initialize()
        {
            server = ConfigurationManager.AppSettings["server"]; 
            database = ConfigurationManager.AppSettings["database"]; 
            uid = ConfigurationManager.AppSettings["username"]; 
            password = ConfigurationManager.AppSettings["pass"]; 
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        public bool OpenConnection()
        {
            try
            { 
                connection.Close();
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
                        return false;
                
            }
        }
        

        //Close connection
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
               MessageBox.Show(ex.Message);
                return false;
            }
        }
        public void ExecuteQuery(string query)
        {
            try
            {
                if (query == "")
                {
                    MessageBox.Show("Enter a query! ", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //Open connection
                if (this.OpenConnection() == true)
                {
                    //create mysql command
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    cmd.ExecuteNonQuery();

                    //close connection
                    this.CloseConnection();
                }
                MessageBox.Show("Command executed successfully!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error executing command! " + ex, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void login_initialise()
        {
            server = ConfigurationManager.AppSettings["l_server"]; 
            database = ConfigurationManager.AppSettings["l_database"]; 
            uid = ConfigurationManager.AppSettings["l_username"]; 
            password = ConfigurationManager.AppSettings["l_pass"]; 
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            login_connection = new MySqlConnection(connectionString);
        }
        
        public string hash_value(string input)
        {
            var sha512 = SHA512Managed.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] outputBytes = sha512.ComputeHash(inputBytes);
            return BitConverter.ToString(outputBytes).Replace("-", "").ToLower();
        }
        //open connection to database
        public bool login_Open_Connection()
        {
            try
            {
                connection.Close();            
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
                return false;
            }
        }
        public bool login_CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public void combobox_initialise()
        {
            server = ConfigurationManager.AppSettings["cb_server"]; 
            database = ConfigurationManager.AppSettings["cb_database"]; 
            uid = ConfigurationManager.AppSettings["cb_username"];
            password = ConfigurationManager.AppSettings["cb_pass"];
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            cb_connection = new MySqlConnection(connectionString);
        }
        
        
        //open connection to database
        public bool combobox_Open_Connection()
        {
            try
            {
                cb_connection.Close();            
                cb_connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
                return false;
            }
        }
        public bool cb_CloseConnection()
        {
            try
            {
                cb_connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public void services_initialise()
        {
            server = ConfigurationManager.AppSettings["s_server"]; 
            database = ConfigurationManager.AppSettings["s_database"]; 
            uid = ConfigurationManager.AppSettings["s_username"]; 
            password = ConfigurationManager.AppSettings["s_pass"]; 
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            services_connection = new MySqlConnection(connectionString);
        }


        //open connection to database
        public bool services_Open_Connection()
        {
            try
            {
                services_connection.Close();
                services_connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
                return false;
            }
        }
        public bool services_CloseConnection()
        {
            try
            {
                services_connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        //DataTables for the ComboBoxes
        public DataTable m_table = new DataTable();
        public DataTable sb_table = new DataTable();
        public DataTable sbr_table = new DataTable();
        public DataTable t_table = new DataTable();
        public DataTable pm_table = new DataTable();

        public void refresh_cb_tables()
        {
            m_table.Clear();
            sb_table.Clear();
            sbr_table.Clear();
            t_table.Clear();
            pm_table.Clear();
        }

      //ComboBox Fillers
        public void fill_data_model() //Fill model
        {
            try
            {
                combobox_initialise();
                combobox_Open_Connection();
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM model", cb_connection);
                da.Fill(m_table);
                cb_CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filling DataTable with MySQLDataAdaptor " + ex, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void fill_data_soldBy() //Fill soldBy
        {
            try
            {
                combobox_initialise();
                combobox_Open_Connection();
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM soldBy", cb_connection);
                da.Fill(sb_table);
                cb_CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filling DataTable with MySQLDataAdaptor " + ex, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void fill_data_salesBranch() //Fill salesBranch
        {
            try
            {
                combobox_initialise();
                combobox_Open_Connection();
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM salesBranch", cb_connection);
                da.Fill(sbr_table);
                cb_CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filling DataTable with MySQLDataAdaptor " + ex, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void fill_data_type() //Fill type
        {
            try
            {
                combobox_initialise();
                combobox_Open_Connection();
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM type", cb_connection);
                da.Fill(t_table);
                cb_CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filling DataTable with MySQLDataAdaptor " + ex, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void fill_data_paymentMethod() //Fill paymentMethod
        {
            try
            {
                combobox_initialise();
                combobox_Open_Connection();
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM paymentMethod", cb_connection);
                da.Fill(pm_table);
                cb_CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filling DataTable with MySQLDataAdaptor " + ex, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}