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
    public partial class MemberListOrderForm : Form
    {
        CONNECT conn = new CONNECT();
        double all;
        double all1;
        public MemberListOrderForm()
        {
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Listorder_Load(object sender, EventArgs e)
        {
            comboadditem();
            String username = textBoxUsername.Text;
            
            labelDateTime.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
            MySqlCommand command = new MySqlCommand("SELECT name,price,time,status FROM `order` WHERE `username` = @username", conn.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            command.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
            adapter.SelectCommand = command;
            adapter.Fill(table);            
            dataGridView1.DataSource = table;
            DataGridViewColumn column0 = dataGridView1.Columns[0];
            column0.Width = 370;
            DataGridViewColumn column1 = dataGridView1.Columns[1];
            column1.Width = 60;
            column1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.AllowUserToAddRows = false;
            int i = 0;
            while (i < table.Rows.Count)
            {
                all += Convert.ToDouble(table.Rows[i]["price"]);
                i++;
            }
            textBoxSum.Text = all.ToString();
        }
        public void comboadditem()
        {
            String username = textBoxUsername.Text;
            CONNECT conn = new CONNECT();            
            MySqlCommand command1 = new MySqlCommand("SELECT * FROM `count` WHERE `username` = @username", conn.getConnection());
            MySqlDataAdapter adapterr = new MySqlDataAdapter();
            MySqlDataReader myReader;
            command1.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
            try
            {
                conn.openConnection();
                myReader = command1.ExecuteReader();
                while (myReader.Read())
                {
                    string sName = myReader.GetString("id");
                    comboBox1.Items.Add(sName);

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            all1 = 0;
            string qurey = "SELECT name,price,time,status FROM `order` WHERE CONCAT(`orderid`) LIKE'%" + comboBox1.Text + "%'";
            MySqlCommand command1 = new MySqlCommand(qurey,conn.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command1;
            adapter.Fill(table);
            dataGridView1.DataSource = table;            
            int i = 0;
            while (i < table.Rows.Count)
            {
                all1 += Convert.ToDouble(table.Rows[i]["price"]);
                i++;
            }
            textBoxSum.Text = all1.ToString();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            all = 0;
            all1 = 0;            
            String username = textBoxUsername.Text;

            labelDateTime.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
            MySqlCommand command = new MySqlCommand("SELECT name,price,time,status FROM `order` WHERE `username` = @username", conn.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            command.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            DataGridViewColumn column0 = dataGridView1.Columns[0];
            column0.Width = 370;
            DataGridViewColumn column1 = dataGridView1.Columns[1];
            column1.Width = 60;
            column1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.AllowUserToAddRows = false;
            int i = 0;
            while (i < table.Rows.Count)
            {
                all += Convert.ToDouble(table.Rows[i]["price"]);
                i++;
            }
            textBoxSum.Text = all.ToString();
        }
    }
}
