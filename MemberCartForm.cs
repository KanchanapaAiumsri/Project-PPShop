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
    public partial class MemberCartForm : Form
    {
        Products addp = new Products();
        CONNECT conn = new CONNECT();        
        double all;
        int randomNumber;

        public MemberCartForm()
        {
            InitializeComponent();

        }
        
        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {

        }


        private void CartForm_Load(object sender, EventArgs e)
        {
            Random random = new Random();
            randomNumber = random.Next(1000000, 10000000);
            labelTimeDate.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
            MySqlDataAdapter adp = new MySqlDataAdapter("SELECT * FROM `bag` WHERE CONCAT(`username`) LIKE '%" + textBoxUsername.Text + "%'", conn.getConnection());
            DataTable table1 = new DataTable();
            adp.Fill(table1);
            int i = 0;
            while (i < table1.Rows.Count)
            {
                all += Convert.ToDouble(table1.Rows[i]["price"]);
                i++;
            }
            textBoxSum.Text = all.ToString();

            String username = textBoxUsername.Text;
            MySqlCommand command = new MySqlCommand("SELECT id,name,price FROM `bag` WHERE `username` = @username", conn.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            command.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            //dataGridView1.ReadOnly = true;
            DataGridViewColumn column0 = dataGridView1.Columns[0];
            column0.Width = 20;
            DataGridViewColumn column1 = dataGridView1.Columns[1];
            column1.Width = 500;
            DataGridViewColumn column2 = dataGridView1.Columns[2];
            column2.Width = 50;
            column2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column0.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MemberDeleteCartForm dlc = new MemberDeleteCartForm();
            dlc.label8.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            dlc.textBoxUsername.Text = textBoxUsername.Text;
            dlc.label6.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            dlc.label7.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

            dlc.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            labelTimeDate.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
            all = 0;
            MySqlDataAdapter adp = new MySqlDataAdapter("SELECT * FROM `bag` WHERE CONCAT(`username`) LIKE '%" + textBoxUsername.Text + "%'", conn.getConnection());
            DataTable table1 = new DataTable();
            adp.Fill(table1);
            int i = 0;
            while (i < table1.Rows.Count)
            {
                all += Convert.ToDouble(table1.Rows[i]["price"]);
                i++;
            }
            textBoxSum.Text = all.ToString();

            String username = textBoxUsername.Text;
            MySqlCommand command = new MySqlCommand("SELECT id,name,price FROM `bag` WHERE `username` = @username", conn.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            command.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            DataGridViewColumn column0 = dataGridView1.Columns[0];
            column0.Width = 20;
            DataGridViewColumn column1 = dataGridView1.Columns[1];
            column1.Width = 500;
            DataGridViewColumn column2 = dataGridView1.Columns[2];
            column2.Width = 50;
            column2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column0.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MemberReceiptForm lt = new MemberReceiptForm();
            lt.textBoxUsername.Text = textBoxUsername.Text;
            lt.textBoxSum.Text = textBoxSum.Text;
            lt.labelAddress.Text = textBoxAddress.Text;
            lt.textBoxOrdernumer.Text = randomNumber.ToString();
            lt.ShowDialog();

        } 

        
        bool verif1()
        {
            if (
                (pictureBox2.Image == null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int count = 0;            
            string username = textBoxUsername.Text;
                                    
            this.button1.PerformClick();
            DialogResult test = MessageBox.Show("Are you sure you want to confirm this cart? ", "Confirm orders", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (test == DialogResult.Yes)
            {
                addp.addcount(randomNumber, username);
                for (int k = 0; k < dataGridView1.Rows.Count; k++)
                {

                    //string username = textBoxUsername.Text;
                    string status = "Waiting";
                    string time = labelTimeDate.Text;
                    string name = dataGridView1.Rows[k].Cells[1].Value.ToString();
                    string price = dataGridView1.Rows[k].Cells[2].Value.ToString();

                    if (addp.confirm(randomNumber, username, name, price, time,status))
                    {

                        addp.deleteallcart(username);

                    }
                    else
                    {
                        MessageBox.Show("ERRORrrrr", "Confirm cart", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    count++;
                }
            }
            else if(test == DialogResult.No)
                {

            }
                                 
            else
            {
                MessageBox.Show("Try to choose other products", "Confirm orders", MessageBoxButtons.OK, MessageBoxIcon.Information);                               
            }
            MessageBox.Show("Thank you for supporting. You have ordered " + count + " products.", "Confirm cart", MessageBoxButtons.OK, MessageBoxIcon.Information);
            labelTimeDate.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
            all = 0;
            MySqlDataAdapter adp = new MySqlDataAdapter("SELECT * FROM `bag` WHERE CONCAT(`username`) LIKE '%" + textBoxUsername.Text + "%'", conn.getConnection());
            DataTable table1 = new DataTable();
            adp.Fill(table1);
            int i = 0;
            while (i < table1.Rows.Count)
            {
                all += Convert.ToDouble(table1.Rows[i]["price"]);
                i++;
            }
            textBoxSum.Text = all.ToString();

            //String username = textBoxUsername.Text;
            MySqlCommand command = new MySqlCommand("SELECT id,name,price FROM `bag` WHERE `username` = @username", conn.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            command.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            DataGridViewColumn column0 = dataGridView1.Columns[0];
            column0.Width = 20;
            DataGridViewColumn column1 = dataGridView1.Columns[1];
            column1.Width = 500;
            DataGridViewColumn column2 = dataGridView1.Columns[2];
            column2.Width = 50;
            column2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column0.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            

        }

        private void label5_Click(object sender, EventArgs e)
        {
            MethodsPayForm mp = new MethodsPayForm();
            mp.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
                String username = textBoxUsername.Text;
                if (MessageBox.Show("Are you sure you want to delete all product in cart? ", "Cart", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (addp.deleteallcart(username))
                    {
                        MessageBox.Show("Deleted all products in cart", "Cart", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                }
                    else
                    {
                       MessageBox.Show("Deleted all products in cart", "Cart", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            labelTimeDate.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
            all = 0;
            MySqlDataAdapter adp = new MySqlDataAdapter("SELECT * FROM `bag` WHERE CONCAT(`username`) LIKE '%" + textBoxUsername.Text + "%'", conn.getConnection());
            DataTable table1 = new DataTable();
            adp.Fill(table1);
            int i = 0;
            while (i < table1.Rows.Count)
            {
                all += Convert.ToDouble(table1.Rows[i]["price"]);
                i++;
            }
            textBoxSum.Text = all.ToString();
            
            MySqlCommand command = new MySqlCommand("SELECT id,name,price FROM `bag` WHERE `username` = @username", conn.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            command.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            DataGridViewColumn column0 = dataGridView1.Columns[0];
            column0.Width = 20;
            DataGridViewColumn column1 = dataGridView1.Columns[1];
            column1.Width = 500;
            DataGridViewColumn column2 = dataGridView1.Columns[2];
            column2.Width = 50;
            column2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column0.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void label5_MouseHover(object sender, EventArgs e)
        {
            label5.ForeColor = Color.White;
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            label5.ForeColor = Color.Blue;
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            label5.BackColor = Color.White;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            label5.BackColor = Color.Transparent;
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            label5.ForeColor = Color.White;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label5.ForeColor = Color.Transparent;
        }
    }
}
       
        


