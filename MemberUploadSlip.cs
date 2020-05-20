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
    public partial class MemberUploadSlip : Form
    {
        public MemberUploadSlip()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void UploadSlip_Load(object sender, EventArgs e)
        {
            comboadditem();
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
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
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf2 = new OpenFileDialog();
            opf2.Filter = "select Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";

            if (opf2.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Image = Image.FromFile(opf2.FileName);
            }

            Products addp = new Products();

            MemoryStream payment = new MemoryStream();
            string orderid = comboBox1.Text;

            if (verif1())
            {
                pictureBox2.Image.Save(payment, pictureBox2.Image.RawFormat);
                if (addp.savepayment(orderid,payment))
                {
                    MessageBox.Show("Uploaded. Please check the order status on order list.", "Payment ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    pictureBox2.Image = null;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("ERROR !", "Payment ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No photo uploaded", "Payment ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
