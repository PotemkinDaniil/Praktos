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
    public partial class Employee : Form
    {
        public static string connectionString = "Data Source=ADCLG1;Initial Catalog=AugustikDanya;Integrated Security=True";
        SqlDataAdapter adapter;
        DataSet ds;
        SqlConnection connection = new SqlConnection(connectionString);
        public Employee()
        {
            InitializeComponent();
            string query2 = "SELECT * FROM Employee";
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
            string query1 = "SELECT * FROM Employee";
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
            string query1 = "INSERT INTO dbo.[Employee] ([ID_Employee],[Name_Employee], [Post], [Number], [Adress], [Vacation], [Password]) VALUES" +
                "((\'" + textBox2.Text + "\'), (\'" + textBox1.Text + "\'), (\'" + textBox3.Text + "\'), (\'" + textBox4.Text + "\'), (\'" + textBox5.Text + "\'), (\'" + textBox6.Text + "\'), (\'" + textBox7.Text + "\')) ";
            SqlCommand com = new SqlCommand(query1, connection);
            connection.Open();
            com.ExecuteNonQuery();
            connection.Close();

            Refresh();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var idemployee = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string delete = "DELETE  FROM dbo.[Employee] WHERE [ID_Employee] = '" + idemployee + "'";
            SqlCommand com = new SqlCommand(delete, connection);

            connection.Open();
            com.ExecuteNonQuery();
            connection.Close();
            Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query1 = $"UPDATE  dbo.[Employee] SET [ID_Employee] = '{textBox2.Text}',[Name_Employee] = '{textBox1.Text}', [Post] = '{textBox3.Text}', [Number] = '{textBox4.Text}', [Adress] = '{textBox5.Text}', [Vacation] = '{textBox6.Text}', [Password] = '{textBox7.Text}'";
            SqlCommand com = new SqlCommand(query1, connection);
            connection.Open();
            com.ExecuteNonQuery();
            connection.Close();

            Refresh();
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
