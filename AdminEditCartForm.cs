using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectPP
{
    public partial class AdminEditCartForm : Form
    {
        public AdminEditCartForm()
        {
            InitializeComponent();
        }
        Products addp = new Products();
        private void label6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        bool verif()
        {
            if ((textBoxName.Text.Trim() == "") ||
                (textBoxUsername.Text.Trim() == "") || 
                (textBoxID.Text.Trim() == "") || (textBoxPrice.Text.Trim() == ""))
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
                string username = textBoxUsername.Text;
                


                if (verif())
                {
                    if (addp.updatecart(id, username, name, price))
                    {
                        MessageBox.Show("Cart Updated ", "Edit Cart", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("ERROR", "Edit Cart", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Empty Fields", "Edit Cart", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch
            {
                MessageBox.Show("Enter a Valid Products Id", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Editcart_Load(object sender, EventArgs e)
        {

        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            try
            {
                int idd = Convert.ToInt32(textBoxID.Text);
                if (MessageBox.Show("Are you sure you want to delete this product in cart? ", "Delete cart", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (addp.deletecartbyadmin(idd))
                    {
                        MessageBox.Show("Cart delete", "Delete cart", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBoxID.Text = "";
                        textBoxName.Text = "";
                        textBoxPrice.Text = "";
                        

                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("ERROR", "Delete cart", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Please Enter a Valid Products Id", "Delete Products", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
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

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
