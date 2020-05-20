using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectPP
{
    public partial class MemberMainForm : Form
    {
       // ClIENT client = new ClIENT();
        Products pd = new Products();
        //CONNECT conn = new CONNECT();
        MySqlConnection Connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=projactpp");
        public MemberMainForm(string textBoxUsername)
        {
            InitializeComponent();
            label9.Text = textBoxUsername;
            //String username = label9.Text;

        }

        private void MemberForm_Load(object sender, EventArgs e)
        {
            labelTimeDate.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
            fillGrid1(new MySqlCommand("SELECT * FROM `product`"));
            

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
            column3.Width = 120;
            column1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column0.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            column3.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
            comboBox1.Text = "ALL";
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm form1 = new LoginForm();
            form1.Show();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            MemberChangePasswordForm changepass = new MemberChangePasswordForm(label9.Text);
            changepass.ShowDialog();
        }

        private void label10_MouseHover(object sender, EventArgs e)
        {
            label10.ForeColor = Color.White;
        }

        private void label10_MouseLeave(object sender, EventArgs e)
        {
            label10.ForeColor = Color.MidnightBlue;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            AddCart addc = new AddCart();            
            addc.textBoxUsername.Text = label9.Text;
            addc.label6.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            addc.label7.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            addc.label8.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            addc.ShowDialog();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            MemberCartForm cf = new MemberCartForm();
            cf.textBoxUsername.Text = label9.Text;            
            cf.ShowDialog();
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
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

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            MemberListOrderForm lod = new MemberListOrderForm();
            lod.textBoxUsername.Text = label9.Text;
            lod.ShowDialog();
        }

        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            pictureBox5.BackColor = Color.White;
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.BackColor = Color.Transparent;
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.White;
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.BackColor = Color.Transparent;
        }
        

        private void pictureBox7_MouseHover(object sender, EventArgs e)
        {
            pictureBox7.BackColor = Color.White;
        }

        private void pictureBox7_MouseLeave(object sender, EventArgs e)
        {
            pictureBox7.BackColor = Color.Transparent;
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.White;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackColor = Color.Transparent;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MemberUploadSlip upl = new MemberUploadSlip();
            upl.textBoxUsername.Text = label9.Text;
            upl.ShowDialog();
        }
    }
}
