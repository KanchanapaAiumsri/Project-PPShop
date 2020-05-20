using ProjectPP.Properties;
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
    public partial class AdminPersonnalForm : Form
    {
        
        ClIENT client = new ClIENT();
        Image Add = Resources.add;
        Image Edit = Resources.edit;
        Image Remove = Resources.remove;
        Image Clear = Resources.clear;
        public AdminPersonnalForm()
        {
            InitializeComponent();
            pictureBox1.Image = Add;
            pictureBox2.Image = Edit;
            pictureBox3.Image = Remove;
            pictureBox4.Image = Clear;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBoxID.Text = "";
            textBoxFirstname.Text = "";
            textBoxLastname.Text = "";            
            textBoxPhon.Text = "";
            textBoxCountry.Text = "";

        }

        

        private void Personnel_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = client.getClients();
        }

       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBoxFirstname.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBoxLastname.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBoxPhon.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBoxCountry.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void label7_MouseEnter(object sender, EventArgs e)
        {
            label7.ForeColor = Color.White;
        }

        private void label7_MouseLeave(object sender, EventArgs e)
        {
            label7.ForeColor = Color.Black;
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            String fname = textBoxFirstname.Text;
            String lname = textBoxLastname.Text;
            String phon = textBoxPhon.Text;
            String country = textBoxCountry.Text;
            if (fname.Trim().Equals("") || lname.Trim().Equals("") || phon.Trim().Equals("") || country.Trim().Equals(""))
            {
                MessageBox.Show("Reuired Fields - First & Last Name + Phone + Country", "Empty Fields ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Boolean insertClient = client.insertClient(fname, lname, phon, country);

                if (insertClient)
                {
                    dataGridView1.DataSource = client.getClients();
                    MessageBox.Show("Inserted Successfuly", "Add Client ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    button4.PerformClick();
                }
                else
                {
                    MessageBox.Show("ERROR - Not Inserted", "Add Client ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

       

        private void textBoxPhon_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            textBoxID.Text = "";
            textBoxFirstname.Text = "";
            textBoxLastname.Text = "";
            textBoxPhon.Text = "";
            textBoxCountry.Text = "";
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Add;
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            int Check_Width = Add.Width + ((Add.Width * 20) / 100);
            int Check_Height = Add.Height + ((Add.Height * 20) / 100);

            Bitmap Add_1 = new Bitmap(Check_Width, Check_Height);
            Graphics g = Graphics.FromImage(Add_1);
            g.DrawImage(Add, new Rectangle(Point.Empty, Add_1.Size));
            pictureBox1.Image = Add_1;
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            int Check_Width = Add.Width + ((Add.Width * 20) / 100);
            int Check_Height = Add.Height + ((Add.Height * 20) / 100);

            Bitmap Edit_1 = new Bitmap(Check_Width, Check_Height);
            Graphics g = Graphics.FromImage(Edit_1);
            g.DrawImage(Edit, new Rectangle(Point.Empty, Edit_1.Size));
            pictureBox2.Image = Edit_1;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = Edit;
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            int Check_Width = Add.Width + ((Add.Width * 30) / 100);
            int Check_Height = Add.Height + ((Add.Height * 30) / 100);

            Bitmap Remove_1 = new Bitmap(Check_Width, Check_Height);
            Graphics g = Graphics.FromImage(Remove_1);
            g.DrawImage(Remove, new Rectangle(Point.Empty, Remove_1.Size));
            pictureBox3.Image = Remove_1;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Image = Remove;
        }

        private void pictureBox1_Click_2(object sender, EventArgs e)
        {
            String fname = textBoxFirstname.Text;
            String lname = textBoxLastname.Text;
            String phon = textBoxPhon.Text;
            String country = textBoxCountry.Text;
            if (fname.Trim().Equals("") || lname.Trim().Equals("") || phon.Trim().Equals("") || country.Trim().Equals(""))
            {
                MessageBox.Show("Reuired Fields - First & Last Name + Phone + Country", "Empty Fields ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Boolean insertClient = client.insertClient(fname, lname, phon, country);

                if (insertClient)
                {
                    dataGridView1.DataSource = client.getClients();
                    MessageBox.Show("Inserted Successfuly", "Add Client ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    button4.PerformClick();
                }
                else
                {
                    MessageBox.Show("ERROR - Not Inserted", "Add Client ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            int id;
            String fname = textBoxFirstname.Text;
            String lname = textBoxLastname.Text;
            String phon = textBoxPhon.Text;
            String country = textBoxCountry.Text;

            try
            {
                id = Convert.ToInt32(textBoxID.Text);

                if (fname.Trim().Equals("") || lname.Trim().Equals("") || phon.Trim().Equals("") || country.Trim().Equals(""))
                {
                    MessageBox.Show("Reuired Fields - First & Last Name + Phone + Country", "Empty Fields ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Boolean insertClient = client.editClient(id, fname, lname, phon, country);

                    if (insertClient)
                    {
                        dataGridView1.DataSource = client.getClients();
                        MessageBox.Show("New Client Updated Successfuly", "EditClient ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        button4.PerformClick();
                    }
                    else
                    {
                        MessageBox.Show("ERROR - Client Not Update", "Edit Client ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ID ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBoxID.Text);

                if (client.removeClient(id))
                {
                    dataGridView1.DataSource = client.getClients();
                    MessageBox.Show("Client Deleted Successfuly", "Deleted Client ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    button4.PerformClick();
                }
                else
                {
                    MessageBox.Show("ERROR - Client Not Deleted", "Deleted Client ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Deleted ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxFirstname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxLastname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxCountry_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBoxPhon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
    }

