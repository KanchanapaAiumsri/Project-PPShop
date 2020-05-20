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
    public partial class MemberChangePasswordForm : Form
    {
        public MemberChangePasswordForm(string label9)
        {
            InitializeComponent();
            textBoxUsername.Text = label9;

        }
        user userr = new user();
        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void label1_MouseHover(object sender, EventArgs e)
        {
            label1.ForeColor = Color.White;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Black;
        }

        

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            textBoxNewPassword.UseSystemPasswordChar = false;
            
            textBoxConfirmPassword.UseSystemPasswordChar = false;
            textBoxOldPassword.UseSystemPasswordChar = false;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            textBoxNewPassword.UseSystemPasswordChar = true;
            
            textBoxConfirmPassword.UseSystemPasswordChar = true;
            textBoxOldPassword.UseSystemPasswordChar = true;
        }

        private void changepassword_Load(object sender, EventArgs e)
        {

        }
        bool verif()
        {
            if ((textBoxUsername.Text.Trim() == "") ||
                (textBoxNewPassword.Text.Trim() == "") || (textBoxOldPassword.Text.Trim() == ""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBoxNewPassword.Text.Equals(textBoxConfirmPassword.Text))
            {
                
                try
                {
                    user userr = new user();
                    string username = textBoxUsername.Text;
                    string passnew = textBoxNewPassword.Text;
                    string pass = textBoxOldPassword.Text; 
                    if (verif())
                    {

                        if (userr.editPassword(username, pass,passnew))
                        {
                            MessageBox.Show("Password Changed ", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Password is incorrect", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Empty Fields", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                catch
                {
                    MessageBox.Show("Enter a Valid Username ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Wrong Confirmation Password", "Password Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void textBoxConfirmPassword_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void label1_MouseHover_1(object sender, EventArgs e)
        {
            label1.ForeColor = Color.White;
        }

        private void label1_MouseLeave_1(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Black;
        }

        private void textBoxOldPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxNewPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxConfirmPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
    }


