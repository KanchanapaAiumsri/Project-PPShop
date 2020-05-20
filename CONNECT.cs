using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;


namespace ProjectPP
{
    class CONNECT
    {
        private MySqlConnection Connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=projactpp");
        public MySqlConnection getConnection()
        {
            return Connection;
        }
        public void openConnection()
        {
            if(Connection.State == ConnectionState.Closed)
            {
                Connection.Open();
            }

        }
        public void closeConnection()
        {
            if (Connection.State == ConnectionState.Open)
            {
                Connection.Close();
            }

        }

    }
}
