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
    public partial class MemberDeleteCartForm : Form
    {
        public MemberDeleteCartForm()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
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
            try
            {
                int idd = Convert.ToInt32(label8.Text);
                if (MessageBox.Show("Are You Sure You Want To Delete This ", "Delete Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (addp.deletecart(idd))
                    {
                        MessageBox.Show("Product Delete", "Delete Products", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
