using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Products : Form
    {
        public static string connectionString = "Data Source=ADCLG1;Initial Catalog=AugustikDanya;Integrated Security=True";
        SqlDataAdapter adapter;
        DataSet ds;
        SqlConnection connection = new SqlConnection(connectionString);
        public Products()
        {
            InitializeComponent();
            string query2 = "SELECT * FROM Products";
            connection.Open();
            {
                ds = new DataSet();
                adapter = new SqlDataAdapter(query2, connection);
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            connection.Close();
        }
        private void Refresh()
        {
            string query1 = "SELECT * FROM Clients";
            connection.Open();
            {
                ds = new DataSet();
                adapter = new SqlDataAdapter(query1, connection);
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query1 = "INSERT INTO dbo.[Products] ([ID_Products],[Name_Tovara], [DataPostypleniya], [Count_Products], [PriceBuy]) VALUES" +
                "((\'" + textBox2.Text + "\'), (\'" + textBox1.Text + "\'), (\'" + textBox3.Text + "\'), (\'" + textBox4.Text + "\')), (\'" + textBox5.Text + "\') ";
            SqlCommand com = new SqlCommand(query1, connection);
            connection.Open();
            com.ExecuteNonQuery();
            connection.Close();

            Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var idproduicts = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string delete = "DELETE  FROM dbo.[Products] WHERE [ID_Products] = '" + idproduicts + "'";
            SqlCommand com = new SqlCommand(delete, connection);

            connection.Open();
            com.ExecuteNonQuery();
            connection.Close();
            Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query1 = $"UPDATE  dbo.[Products] SET [ID_Products] = '{textBox2.Text}',[Name_Tovara] = '{textBox1.Text}', [DataPostypleniya] = '{textBox3.Text}', [Count_Products] = '{textBox4.Text}', [PriceBuy] = '{textBox5.Text}'";
            SqlCommand com = new SqlCommand(query1, connection);
            connection.Open();
            com.ExecuteNonQuery();
            connection.Close();

            Refresh();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Who == 1)
            {
                Administrator administrator = new Administrator();
                administrator.ShowDialog();
                this.Hide();
            }
            else if (Properties.Settings.Default.Who == 2)
            {
                Director director = new Director();
                director.ShowDialog();
                this.Hide();
            }
            else if (Properties.Settings.Default.Who == 3)
            {
                Assistent assistent = new Assistent();
                assistent.ShowDialog();
                this.Hide();
            }
            else if (Properties.Settings.Default.Who == 4)
            {
                Meneger meneger = new Meneger();
                meneger.ShowDialog();
                this.Hide();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
