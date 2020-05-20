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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Drawing.Imaging;
using Rectangle = System.Drawing.Rectangle;

namespace ProjectPP
{
    public partial class MemberReceiptForm : Form
    {
        Products pd = new Products();
        CONNECT conn = new CONNECT();
        MySqlConnection Connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=projactpp");
        public MemberReceiptForm()
        {
            InitializeComponent();
            textBoxDateTime.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void labeltime_Click(object sender, EventArgs e)
        {

        }

        private void textBoxDateTime_TextChanged(object sender, EventArgs e)
        {

        }

        private void last_Load(object sender, EventArgs e)
        {
            String username = textBoxUsername.Text;
            MySqlCommand command = new MySqlCommand("SELECT name,price FROM `bag` WHERE `username` = @username", conn.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            command.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridView1.DataSource = table;           
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "Image files (*.jpg)|*.jpg"
            })
            {
                if (sfd.ShowDialog(this) == DialogResult.OK)
                {                    
                    Bitmap bmp = new Bitmap(this.Width, this.Height);
                    this.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));
                    bmp.Save(sfd.FileName, ImageFormat.Jpeg);
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
