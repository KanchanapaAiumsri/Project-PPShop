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
    public partial class AdminProductsListForm : Form
    {
        MySqlConnection Connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=projactpp");
        public AdminProductsListForm()
        {
            InitializeComponent();
        }
        Products pd = new Products();
        private void ProductsListForm_Load(object sender, EventArgs e)
        {
            fillGrid1(new MySqlCommand("SELECT * FROM `product`")); ;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            AdminEditProductsForm udf = new AdminEditProductsForm();
            udf.textBoxID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            udf.textBoxName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            udf.textBoxPrice.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            udf.textBoxCategory.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();

            byte[] pic;
            pic = (byte[])dataGridView1.CurrentRow.Cells[4].Value;
            MemoryStream picture = new MemoryStream(pic);
            udf.pictureBox1.Image = Image.FromStream(picture);
            udf.ShowDialog();
        }

       

        private void label7_MouseEnter(object sender, EventArgs e)
        {
            label7.ForeColor = Color.White;
        }

        private void label7_MouseLeave(object sender, EventArgs e)
        {
            label7.ForeColor = Color.Black;
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            fillGrid1(new MySqlCommand("SELECT * FROM `product`"));
        }
        public void fillGrid1(MySqlCommand command)
        {

            dataGridView1.ReadOnly = true;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 100;
            dataGridView1.DataSource = pd.getProductss(command);
            DataGridViewColumn column0 = dataGridView1.Columns[0];
            column0.Width = 45;
            DataGridViewColumn column1 = dataGridView1.Columns[1];
            column1.Width = 100;
            DataGridViewColumn column2 = dataGridView1.Columns[2];
            column2.Width = 550;
            DataGridViewColumn column3 = dataGridView1.Columns[3];
            column3.Width = 80;
            picCol = (DataGridViewImageColumn)dataGridView1.Columns[4];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void buttonSearch2_Click(object sender, EventArgs e)
        {
            string qurey = "SELECT * FROM `product` WHERE CONCAT(`name`,`price`) LIKE'%" + textBoxSearch.Text + "%'";
            MySqlCommand command1 = new MySqlCommand(qurey, Connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command1;
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            fillGrid1(new MySqlCommand("SELECT * FROM `product`"));
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string qurey = "SELECT * FROM `product` WHERE CONCAT(`category`) LIKE'%" + comboBox1.Text + "%'";
            MySqlCommand command1 = new MySqlCommand(qurey, Connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command1;
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete all products? ", "products", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (pd.deleteallproduct())
                {
                    MessageBox.Show("Deleted all products", "products", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Deleted all products", "products", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }

}