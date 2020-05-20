using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;


namespace ProjectPP
{
    class Products
    {
        CONNECT conn = new CONNECT();
        public bool insertProducts(String name, String cate, String price, MemoryStream picture)
        {
            MySqlCommand command = new MySqlCommand();
            String insertProducts = "INSERT INTO `product`(`name`,`category`, `price`, `image`) VALUES (@name,@cate,@price,@image)";
            command.CommandText = insertProducts;
            command.Connection = conn.getConnection();
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@cate", MySqlDbType.VarChar).Value = cate;
            command.Parameters.Add("@price", MySqlDbType.VarChar).Value = price;
            command.Parameters.Add("@image", MySqlDbType.LongBlob).Value = picture.ToArray();

            conn.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                conn.closeConnection();
                return true;
            }
            else
            {
                conn.closeConnection();
                return false;

            }
        }

        

        internal object getProductss()
        {
            throw new NotImplementedException();
        }

        public DataTable getProductss(MySqlCommand command)
        {

            command.Connection = conn.getConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;

        }
        public bool updateProducts(int id, String name, String cate, String price,  MemoryStream picture)
        {
            MySqlCommand command = new MySqlCommand();
            String updateProducts = "UPDATE `product` SET `name`=@name,`category`=@cate,`price`=@price,`image`=@image WHERE `id`=@ID";
            command.CommandText = updateProducts;
            command.Connection = conn.getConnection();
            command.Parameters.Add("@ID", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@cate", MySqlDbType.VarChar).Value = cate;
            command.Parameters.Add("@price", MySqlDbType.VarChar).Value = price;
            command.Parameters.Add("@image", MySqlDbType.LongBlob).Value = picture.ToArray();

            conn.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                conn.closeConnection();
                return true;
            }
            else
            {
                conn.closeConnection();
                return false;

            }
        }

        public bool deleteProducts(int id)
        {
            MySqlCommand command = new MySqlCommand();
            String updateProducts = "DELETE FROM `product` WHERE `id`=@ProductsID";
            command.CommandText = updateProducts;
            command.Connection = conn.getConnection();
            command.Parameters.Add("@ProductsID", MySqlDbType.Int32).Value = id;


            conn.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                conn.closeConnection();
                return true;
            }
            else
            {
                conn.closeConnection();
                return false;

            }
        }
        public bool insertCart(String id, String username, String name, String price )
        {
            MySqlCommand command = new MySqlCommand();
            String insertProducts = "INSERT INTO `bag`(`username`, `name`, `price`) VALUES (@username,@name,@price)";
            command.CommandText = insertProducts;
            command.Connection = conn.getConnection();
            
            command.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@price", MySqlDbType.LongBlob).Value = price;

            conn.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                conn.closeConnection();
                return true;
            }
            else
            {
                conn.closeConnection();
                return false;

            }


        }
        public bool deletecart(int idd)
        {
            MySqlCommand command = new MySqlCommand();
            String updateProducts = "DELETE FROM `bag` WHERE `id`=@ProductsID";
            command.CommandText = updateProducts;
            command.Connection = conn.getConnection();
            command.Parameters.Add("@ProductsID", MySqlDbType.Int32).Value = idd;


            conn.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                conn.closeConnection();
                return true;
            }
            else
            {
                conn.closeConnection();
                return false;

            }
        }
        public bool deleteallcart(String username)
        {
            MySqlCommand command = new MySqlCommand();
            String updateProducts = "DELETE FROM `bag` WHERE `username`=@username";
            command.CommandText = updateProducts;
            command.Connection = conn.getConnection();
            command.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;


            conn.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                conn.closeConnection();
                return true;
            }
            else
            {
                conn.closeConnection();
                return false;

            }
        }
        public bool savepayment(String orderid,MemoryStream picture)
        {
            MySqlCommand command = new MySqlCommand();
            String savepayment = "INSERT INTO `statistics`(`orderid`,`payment`) VALUES (@orderid,@payment)";
            command.CommandText = savepayment;
            command.Connection = conn.getConnection();
            command.Parameters.Add("@orderid", MySqlDbType.VarChar).Value = orderid;
            command.Parameters.Add("@payment", MySqlDbType.LongBlob).Value = picture.ToArray();

            conn.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                conn.closeConnection();
                return true;
            }
            else
            {
                conn.closeConnection();
                return false;

            }
        }
        public bool confirm(int randomNumber, String username,String name, String price, String time, String status)
        {
            MySqlCommand command = new MySqlCommand();
            String insertProducts = "INSERT INTO `order`(`orderid`,`username`,`name`,`price`,`time`,`status`) VALUES (@orderid,@username,@name,@price,@time,@status)";
            command.CommandText = insertProducts;
            command.Connection = conn.getConnection();
            command.Parameters.Add("@orderid", MySqlDbType.Int32).Value = randomNumber;
            command.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@price", MySqlDbType.LongBlob).Value = price;
            command.Parameters.Add("@time", MySqlDbType.LongBlob).Value = time;
            command.Parameters.Add("@status", MySqlDbType.VarChar).Value = status;
            conn.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                conn.closeConnection();
                return true;
            }
            else
            {
                conn.closeConnection();
                return false;

            }


        }
        public bool addcount(int randomNumber, String username)
        {
            MySqlCommand command = new MySqlCommand();
            String count = "INSERT INTO `count`(`id`,`username`) VALUES (@id,@username)";
            command.CommandText = count;
            command.Connection = conn.getConnection();
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = randomNumber;
            command.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
           

            conn.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                conn.closeConnection();
                return true;
            }
            else
            {
                conn.closeConnection();
                return false;

            }


        }
        internal object getorders()
        {
            throw new NotImplementedException();
        }

        public DataTable getoders(MySqlCommand command)
        {

            command.Connection = conn.getConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;

        }
        public bool updateorders(int id, String username, String name, String price, String time, String status)
        {
            MySqlCommand command = new MySqlCommand();
            String updatecart = "UPDATE `order` SET `name`=@name,`username`=@username,`price`=@price,`time`=@time,`status`=@status WHERE `id`=@ID";
            command.CommandText = updatecart;
            command.Connection = conn.getConnection();
            command.Parameters.Add("@ID", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@price", MySqlDbType.VarChar).Value = price;
            command.Parameters.Add("@time", MySqlDbType.VarChar).Value = time;
            command.Parameters.Add("@status", MySqlDbType.VarChar).Value = status;


            conn.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                conn.closeConnection();
                return true;
            }
            else
            {
                conn.closeConnection();
                return false;

            }
        }
        public bool updateordersuccess(int orderid,String status)
        {
            MySqlCommand command = new MySqlCommand();
            String updateordersuccess = "UPDATE `order` SET `status`=@status WHERE `orderid`=@orderid";
            command.CommandText = updateordersuccess;
            command.Connection = conn.getConnection();
            command.Parameters.Add("@orderid", MySqlDbType.Int32).Value = orderid;
            command.Parameters.Add("@status", MySqlDbType.VarChar).Value = status;
            


            conn.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                conn.closeConnection();
                return true;
            }
            else
            {
                conn.closeConnection();
                return false;

            }
        }
        public bool deleteorders(int idd)
        {
            MySqlCommand command = new MySqlCommand();
            String deleteorder = "DELETE FROM `order` WHERE `id`=@ProductsID";
            command.CommandText = deleteorder;
            command.Connection = conn.getConnection();
            command.Parameters.Add("@ProductsID", MySqlDbType.Int32).Value = idd;


            conn.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                conn.closeConnection();
                return true;
            }
            else
            {
                conn.closeConnection();
                return false;

            }
        }        
        public DataTable getcart(MySqlCommand command)
        {

            command.Connection = conn.getConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;

        }
        public bool updatecart(int id, String username, String name, String price)
        {
            MySqlCommand command = new MySqlCommand();
            String updatecart = "UPDATE `bag` SET `name`=@name,`username`=@username,`price`=@price WHERE `id`=@ID";
            command.CommandText = updatecart;
            command.Connection = conn.getConnection();
            command.Parameters.Add("@ID", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@price", MySqlDbType.VarChar).Value = price;
            


            conn.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                conn.closeConnection();
                return true;
            }
            else
            {
                conn.closeConnection();
                return false;

            }
        }
        public bool deletecartbyadmin(int idd)
        {
            MySqlCommand command = new MySqlCommand();
            String deletecartbyadmin = "DELETE FROM `bag` WHERE `id`=@ProductsID";
            command.CommandText = deletecartbyadmin;
            command.Connection = conn.getConnection();
            command.Parameters.Add("@ProductsID", MySqlDbType.Int32).Value = idd;


            conn.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                conn.closeConnection();
                return true;
            }
            else
            {
                conn.closeConnection();
                return false;

            }
        }
        public bool deleteallcartbyadmin()
        {
            MySqlCommand command = new MySqlCommand();
            String deleteallcartbyadmin = "DELETE FROM `bag` ";
            command.CommandText = deleteallcartbyadmin;
            command.Connection = conn.getConnection();
            


            conn.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                conn.closeConnection();
                return true;
            }
            else
            {
                conn.closeConnection();
                return false;

            }
        }
        public bool deleteallproduct()
        {
            MySqlCommand command = new MySqlCommand();
            String deleteallproduct = "DELETE FROM `product` ";
            command.CommandText = deleteallproduct;
            command.Connection = conn.getConnection();



            conn.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                conn.closeConnection();
                return true;
            }
            else
            {
                conn.closeConnection();
                return false;

            }
        }
        public bool deleteallorders()
        {
            MySqlCommand command = new MySqlCommand();
            String deleteallorders = "DELETE FROM `order` ";
            command.CommandText = deleteallorders;
            command.Connection = conn.getConnection();



            conn.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                conn.closeConnection();
                return true;
            }
            else
            {
                conn.closeConnection();
                return false;

            }
        }
        public DataTable getpayment(MySqlCommand command)
        {

            command.Connection = conn.getConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;

        }
        public bool updatepayment(int id,MemoryStream picture)
        {
            MySqlCommand command = new MySqlCommand();
            String updatepayment = "UPDATE `statistics` SET `payment`=@image WHERE `id`=@ID";
            command.CommandText = updatepayment;
            command.Connection = conn.getConnection();
            command.Parameters.Add("@ID", MySqlDbType.Int32).Value = id;            
            command.Parameters.Add("@image", MySqlDbType.LongBlob).Value = picture.ToArray();

            conn.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                conn.closeConnection();
                return true;
            }
            else
            {
                conn.closeConnection();
                return false;

            }
        }
        public bool deletepayment(int id)
        {
            MySqlCommand command = new MySqlCommand();
            String deletepayment = "DELETE FROM `statistics` WHERE `id`=@ProductsID";
            command.CommandText = deletepayment;
            command.Connection = conn.getConnection();
            command.Parameters.Add("@ProductsID", MySqlDbType.Int32).Value = id;


            conn.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                conn.closeConnection();
                return true;
            }
            else
            {
                conn.closeConnection();
                return false;

            }
        }
    }



}