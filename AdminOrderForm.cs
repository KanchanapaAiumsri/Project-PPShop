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
    public partial class AdminorderForm : Form
    {
        MySqlConnection Connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=projactpp");
        public AdminorderForm()
        {
            InitializeComponent();
        }
        CONNECT conn = new CONNECT();
        Products pd = new Products();
        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AdmincartForm_Load(object sender, EventArgs e)
        {
            
            fillGrid1(new MySqlCommand("SELECT * FROM `order`"));
            comboadditem();
        }
        public void comboadditem()
        {            
            CONNECT conn = new CONNECT();
            MySqlCommand command1 = new MySqlCommand("SELECT * FROM `count`", conn.getConnection());
            MySqlDataAdapter adapterr = new MySqlDataAdapter();
            MySqlDataReader myReader;            
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void fillGrid1(MySqlCommand command)
        {

            dataGridView1.ReadOnly = true;
            
            dataGridView1.RowTemplate.Height = 100;
            dataGridView1.DataSource = pd.getoders(command);
            DataGridViewColumn column0 = dataGridView1.Columns[0];
            column0.Width = 40;
            DataGridViewColumn column1 = dataGridView1.Columns[1];
            column1.Width = 60;
            DataGridViewColumn column2 = dataGridView1.Columns[2];
            column2.Width = 60;
            DataGridViewColumn column3 = dataGridView1.Columns[3];
            column3.Width = 400;
            DataGridViewColumn column4 = dataGridView1.Columns[4];
            column4.Width = 60;                        
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void buttonSearch2_Click(object sender, EventArgs e)
        {
            string qurey = "SELECT * FROM `order` WHERE CONCAT(`id`,`orderid`,`username`,`name`,`price`,`time`) LIKE'%" + textBoxSearch.Text + "%'";
            MySqlCommand command1 = new MySqlCommand(qurey, Connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command1;
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            fillGrid1(new MySqlCommand("SELECT * FROM `order`"));
            textBoxSearch.Text = "";
            comboBox1.Text = "";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            AdminEditOrdersForm udf = new AdminEditOrdersForm();
            udf.textBoxID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            udf.textBoxUsername.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            udf.textBoxName.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            udf.textBoxPrice.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            udf.textBoxTime.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            udf.comboBox1.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            udf.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            fillGrid1(new MySqlCommand("SELECT * FROM `order`"));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete all orders? ", "orders", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (pd.deleteallorders())
                {
                    MessageBox.Show("Deleted all orders", "orders", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Deleted all orders", "orders", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string qurey = "SELECT * FROM `order` WHERE CONCAT(`orderid`) LIKE'%" + comboBox1.Text + "%'";
            MySqlCommand command1 = new MySqlCommand(qurey, conn.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command1;
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }
    }

}
