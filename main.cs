using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        // Connection string for the database
        private string ConnectionString = "Data Source=DESKTOP-R3QO0FF\\SQLEXPRESS;Initial Catalog=bmn;Integrated Security=True";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Open a connection to the database
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                string f_name = textBox1.Text;
                string l_name = textBox2.Text;
                string Email = textBox5.Text;
                string contactNumber = textBox6.Text;
                string qua = textBox7.Text;

                // Create a parameterized SQL query to insert data
                string Query = "INSERT INTO regis(f_name, l_name, email, con_num, qua) " +
                               $"VALUES ('{f_name}', '{l_name}', '{Email}', '{contactNumber}', '{qua}')";

                // Execute the query
                using (SqlCommand cmd = new SqlCommand(Query, con))
                {
                    cmd.ExecuteNonQuery();
                }

                // Display a message to indicate that the record has been added
                MessageBox.Show("Record added");
                con.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Load data into the DataGridView when the form loads
            this.regisTableAdapter.Fill(this.bmnDataSet2.regis);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Create a DataTable to hold the data retrieved from the database
            DataTable dtb1 = new DataTable();

            // Open a connection to the database
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();

                // Use a SqlDataAdapter to fill the DataTable with data from the "regis" table
                SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT * FROM regis", con);
                dataAdapter.Fill(dtb1);

                // Display the data in the DataGridView
                dataGridView1.DataSource = dtb1;
            }
        }
    }
}
