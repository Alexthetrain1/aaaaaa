using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");

        public Form1()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet.Table' table. You can move, or remove it, as needed.
            this.tableTableAdapter.Fill(this.database1DataSet.Table);


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void fillDataGridView()
        {
            conn.Open();
            SqlCommand SqlCmd = conn.CreateCommand();
            SqlCmd.CommandType = CommandType.Text;
            SqlCmd.CommandText = "SELECT * FROM Table1";
            SqlCmd.ExecuteNonQuery();
            DataTable dtbl = new DataTable();
            SqlDataAdapter sqlAd = new SqlDataAdapter(SqlCmd);
            sqlAd.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            conn.Close(); 

        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") || textBox2.Text.Equals("") || textBox3.Text.Equals("") ||
                textBox4.Text.Equals(""))
            {
                MessageBox.Show("Popunite sva polja");
            }

            else
            {
                conn.Open();
                SqlCommand SqlCmd = conn.CreateCommand();
                SqlCmd.CommandType = CommandType.Text;
                SqlCmd.CommandText= "INSERT INTO Table VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox1.SelectedItem.ToString() + "')";
                SqlCmd.ExecuteNonQuery();
                MessageBox.Show("xd");
                conn.Close();
                fillDataGridView();
            }
        }
    }
}
