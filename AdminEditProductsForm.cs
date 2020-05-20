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
    public partial class AdminEditProductsForm : Form
    {
        public AdminEditProductsForm()
        {
            InitializeComponent();
        }
        Products product = new Products();
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "select Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";

            if (opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(opf.FileName);
            }
        }
        bool verif()
        {
            if ((textBoxName.Text.Trim() == "") ||
                (textBoxPrice.Text.Trim() == "") || (textBoxCategory.Text.Trim() == "") ||
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
                Products addp = new Products();
                int id = Convert.ToInt32(textBoxID.Text);
                string name = textBoxName.Text;
                string price = textBoxPrice.Text;
                string cate = textBoxCategory.Text;
                MemoryStream pic = new MemoryStream();
                if (verif())
                {
                    pictureBox1.Image.Save(pic, pictureBox1.Image.RawFormat);
                    if (addp.updateProducts(id, name, cate, price, pic))
                    {
                        MessageBox.Show("Products Updated ", "Edit Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("ERROR", "EditProduct", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Empty Fields", "Edit Product", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch 
            {
                MessageBox.Show("Enter a Valid Products Id", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBoxID.Text);
                if (MessageBox.Show("Are you sure you want to delete this product? ", "Delete Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (product.deleteProducts(id))
                    {
                        MessageBox.Show("Product Delete", "Delete Products", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBoxID.Text = "";
                        textBoxName.Text = "";
                        textBoxPrice.Text = "";
                        textBoxCategory.Text = "";
                        pictureBox1.Image = null;
                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("ERROR", "Delete Products", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Please Enter a Valid Products Id", "Delete Products", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBoxID.Text);
                MySqlCommand command = new MySqlCommand("SELECT `id`, `name`, `price`, `image` FROM `product` WHERE `id`=" + id);

                DataTable table = product.getProductss(command);
                if (table.Rows.Count > 0)
                {
                    textBoxName.Text = table.Rows[0]["name"].ToString();
                    textBoxPrice.Text = table.Rows[0]["price"].ToString();

                    byte[] pic = (byte[])table.Rows[0]["image"];
                    MemoryStream picture = new MemoryStream(pic);
                    pictureBox1.Image = Image.FromStream(picture);


                }
            }catch(Exception) 
            {
                MessageBox.Show("Enter a Valid Products Id", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void textBoxID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label6_MouseHover(object sender, EventArgs e)
        {
            label6.ForeColor = Color.White;
        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
            label6.ForeColor = Color.Black;
        }

        private void textBoxName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void UpdateDeleteProductsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
