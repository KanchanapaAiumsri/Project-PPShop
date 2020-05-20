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
    public partial class AdminCartForm : Form
    {
        MySqlConnection Connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=projactpp");
        public AdminCartForm()
        {
            InitializeComponent();
        }
        Products pd = new Products();

        private void AdminCartForm_Load(object sender, EventArgs e)
        {
            fillGrid1(new MySqlCommand("SELECT * FROM `bag`"));
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void fillGrid1(MySqlCommand command)
        {

            dataGridView1.ReadOnly = true;

            dataGridView1.RowTemplate.Height = 100;
            dataGridView1.DataSource = pd.getcart(command);
            DataGridViewColumn column0 = dataGridView1.Columns[0];
            column0.Width = 45;
            DataGridViewColumn column1 = dataGridView1.Columns[1];
            column1.Width = 80;
            DataGridViewColumn column2 = dataGridView1.Columns[2];
            column2.Width = 400;
            DataGridViewColumn column3 = dataGridView1.Columns[3];
            column3.Width = 80;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void buttonSearch2_Click(object sender, EventArgs e)
        {
            string qurey = "SELECT * FROM `bag` WHERE CONCAT(`id`,`username`,`name`,`price`) LIKE'%" + textBoxSearch.Text + "%'";
            MySqlCommand command1 = new MySqlCommand(qurey, Connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command1;
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            AdminEditCartForm udf = new AdminEditCartForm();
            udf.textBoxID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            udf.textBoxUsername.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            udf.textBoxName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            udf.textBoxPrice.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            

            udf.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            fillGrid1(new MySqlCommand("SELECT * FROM `bag`"));
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            fillGrid1(new MySqlCommand("SELECT * FROM `bag`"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete all cart? ", "Cart", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (pd.deleteallcartbyadmin())
                {
                    MessageBox.Show("Deleted all products in cart", "Cart", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Deleted all products in cart", "Cart", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }

}
