using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProjectPP
{
    public partial class AdminMainForm : Form
    {
        ClIENT client = new ClIENT();
        Products pd = new Products();
        MySqlConnection Connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=projactpp");
        public AdminMainForm(string textBoxUsername)
        {
            InitializeComponent();
            label9.Text = textBoxUsername;
            String username = label9.Text;
        }

        private void Main_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void personnelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminPersonnalForm ps = new AdminPersonnalForm();
            ps.ShowDialog();
        }

        private void addProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminAddProductForm add = new AdminAddProductForm();
            add.ShowDialog();
        }

        

        private void listProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminProductsListForm plf = new AdminProductsListForm();
            plf.Show(this);

        }

        private void editProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminEditProductsForm upd = new AdminEditProductsForm();
            upd.ShowDialog();
        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            label5.ForeColor = Color.White;
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            label5.ForeColor = Color.Black;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

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
            column2.Width = 450;
            DataGridViewColumn column3 = dataGridView1.Columns[3];
            column3.Width = 80;
            picCol = (DataGridViewImageColumn)dataGridView1.Columns[4];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        public void fillGrid2(MySqlCommand command)
        {
            dataGridView2.DataSource = client.getClients();
            DataGridViewColumn column0 = dataGridView2.Columns[0];
            column0.Width = 45;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            fillGrid1(new MySqlCommand("SELECT * FROM `product`"));

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            fillGrid2(new MySqlCommand("SELECT * FROM `client`"));

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

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string qurey = "SELECT * FROM `clientperson` WHERE CONCAT(`first_name`,`last_name`,`phone`,`country`) LIKE'%" + textBoxSearch2.Text + "%'";
            MySqlCommand command1 = new MySqlCommand(qurey, Connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command1;
            adapter.Fill(table);
            dataGridView2.DataSource = table;

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm form1 = new LoginForm();
            form1.Show();
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {
            labelTimeDate.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
            fillGrid1(new MySqlCommand("SELECT * FROM `product`"));
            fillGrid2(new MySqlCommand("SELECT * FROM `client`"));
        }

        private void confToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminorderForm admincf = new AdminorderForm();
            admincf.ShowDialog();
        }

        private void cartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminCartForm acf = new AdminCartForm();
            acf.ShowDialog();
        }

        private void paymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminPaymantForm spm = new AdminPaymantForm();
            spm.ShowDialog();
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

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }


}
