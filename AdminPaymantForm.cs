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
    public partial class AdminPaymantForm : Form
    {
        MySqlConnection Connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=projactpp");
        public AdminPaymantForm()
        {
            InitializeComponent();
        }
        Products pd = new Products();
        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowpaymantForm_Load(object sender, EventArgs e)
        {
            fillGrid1(new MySqlCommand("SELECT * FROM `statistics`"));
        }
        public void fillGrid1(MySqlCommand command)
        {

            dataGridView1.ReadOnly = true;
            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            dataGridView1.RowTemplate.Height = 100;
            dataGridView1.DataSource = pd.getpayment(command);
            DataGridViewColumn column0 = dataGridView1.Columns[0];
            column0.Width = 80;            
            picCol = (DataGridViewImageColumn)dataGridView1.Columns[2];
            picCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void buttonSearch2_Click(object sender, EventArgs e)
        {
            string qurey = "SELECT * FROM `statistics` WHERE CONCAT(`id`) LIKE'%" + textBoxSearch.Text + "%'";
            MySqlCommand command1 = new MySqlCommand(qurey, Connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command1;
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            AdminEditPaymentForm udf = new AdminEditPaymentForm();
            udf.textBoxID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            udf.textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            byte[] pic;
            pic = (byte[])dataGridView1.CurrentRow.Cells[2].Value;
            MemoryStream picture = new MemoryStream(pic);
            udf.pictureBox1.Image = Image.FromStream(picture);
            udf.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            fillGrid1(new MySqlCommand("SELECT * FROM `statistics`"));
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            fillGrid1(new MySqlCommand("SELECT * FROM `statistics`"));
        }
    }
}
