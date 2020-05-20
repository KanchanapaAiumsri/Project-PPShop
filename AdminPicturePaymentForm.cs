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
    public partial class bigpic : Form
    {
        public bigpic()
        {
            InitializeComponent();
        }
        CONNECT conn = new CONNECT();
       
        private void label6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                        
        }

        private void bigpic_Load(object sender, EventArgs e)
        {
            dataGridView1.RowTemplate.Height = 600;
            String id = textBoxID.Text;
            MySqlCommand command = new MySqlCommand("SELECT * FROM `statistics` WHERE `id` = @id", conn.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = id;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            //dataGridView1.ReadOnly = true;
                        
            DataGridViewColumn column0 = dataGridView1.Columns[0];
            column0.Width = 1;
            DataGridViewColumn column1 = dataGridView1.Columns[1];
            column1.Width = 1;


            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
