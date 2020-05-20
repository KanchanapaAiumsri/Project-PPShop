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
    public partial class AddCart : Form
    {
        public AddCart()
        {
            InitializeComponent();
        }

        private void AddCart_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAddcart_Click(object sender, EventArgs e)
        {

            Products addp = new Products();
            string username = textBoxUsername.Text;
            string name = label6.Text;
            string price = label7.Text;
            string id = label8.Text;
            


            if (addp.insertCart(id,username, name, price))
            {
                    MessageBox.Show("Added in Cart", "Add Cart", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                    MessageBox.Show("ERROR", "Add Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
            
    }
}


