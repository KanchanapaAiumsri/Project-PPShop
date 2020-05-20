using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProjectPP
{
    class user
        
    {
    CONNECT conn = new CONNECT();
        public bool editPassword(String username, String password, String passwordnew)
        {
            MySqlCommand command = new MySqlCommand();
            String editQuery = "UPDATE `users` SET `password`= @passnew WHERE `username`=@uname AND `password`=@pass";
            command.CommandText = editQuery;
            command.Connection = conn.getConnection();

            command.Parameters.Add("@uname", MySqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password;
            command.Parameters.Add("@passnew", MySqlDbType.VarChar).Value = passwordnew;

            conn.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                conn.closeConnection();
                return true;
            }
            else
            {
                conn.openConnection();
                return false;
            }


        }
    }
}
