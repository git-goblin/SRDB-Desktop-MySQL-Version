using System;
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



namespace srdb
{
    class DBConnect
    {
        public MySqlConnection connection;
        public MySqlConnection login_connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public DBConnect()
        {
            Initialize();
        }

        //Initialize values
        public void Initialize()
        {
            server = "localhost";
            database = "srdb";
            uid = "root";
            password = "MySQuireL321!";
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
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
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
                //Open connection
                if (this.OpenConnection() == true)
                {
                    //create mysql command
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    cmd.ExecuteNonQuery();

                    //close connection
                    this.CloseConnection();
                }
                MessageBox.Show("Command executed successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error executing command! " + ex);
            }
        }
        public void login_initialise()
        {
            server = "localhost";
            database = "srdb";
            uid = "root";
            password = "MySQuireL321!";
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
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }
        
           public void combobox_initialise()
        {
            server = "localhost";
            database = "combobox";
            uid = "root";
            password = "MySQuireL321!";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            login_connection = new MySqlConnection(connectionString);
        }
        
        
        //open connection to database
        public bool combobox_Open_Connection()
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
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }
        public DataTable table = new DataTable();
        public void fill_data(string db_table)
        {
            MySqlDataAdapter da = new MySqlDataAdapter(db_table, connection);
            da.Fill(table);
        }

    }
}