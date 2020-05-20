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
    public partial class AdminEditPaymentForm : Form
    {
        public AdminEditPaymentForm()
        {
            InitializeComponent();
        }
        Products addp = new Products();
        bool verif()
        {
            if ((textBoxID.Text.Trim() == "") || (comboBox1.Text.Trim() == "") ||
                (pictureBox1.Image == null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                
                int id = Convert.ToInt32(textBoxID.Text);                
                MemoryStream image = new MemoryStream();
                
                if (verif())
                {
                    pictureBox1.Image.Save(image, pictureBox1.Image.RawFormat);
                    if (addp.updatepayment(id,image))
                    {
                        MessageBox.Show("Payment Updated ", "Edit Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("ERROR", "Edit Payment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Empty Fields", "Edit Payment", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch
            {
                MessageBox.Show("Enter a Valid Products Id", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "select Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(opf.FileName);
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBoxID.Text);
                if (MessageBox.Show("Are you sure you want to delete this Payment? ", "Delete Payment", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (addp.deletepayment(id))
                    {
                        MessageBox.Show("Product Delete", "Delete Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBoxID.Text = "";                        
                        pictureBox1.Image = null;
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("ERROR", "Delete Payment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Please Enter a Valid Products Id", "Delete Products", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            bigpic udf = new bigpic();
            udf.textBoxID.Text = textBoxID.Text;
            udf.ShowDialog();
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void AdminEditPaymentForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int orderid = Convert.ToInt32(textBox1.Text);
                String status = comboBox1.Text;


                if (verif())
                {
                    
                    if (addp.updateordersuccess(orderid,status))
                    {
                        MessageBox.Show("Order Updated ", "Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error", "Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Empty Fields", "Order", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch
            {
                MessageBox.Show("Enter a Valid Products Id", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
