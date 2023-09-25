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
    public partial class Post : Form
    {
        public static string connectionString = "Data Source=ADCLG1;Initial Catalog=AugustikDanya;Integrated Security=True";
        SqlDataAdapter adapter;
        DataSet ds;
        SqlConnection connection = new SqlConnection(connectionString);
        public Post()
        {
            InitializeComponent();
            string query2 = "SELECT * FROM Post";
            connection.Open();
            {
                ds = new DataSet();
                adapter = new SqlDataAdapter(query2, connection);
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            connection.Close();
            string query3 = "SELECT * FROM Products";
            connection.Open();
            {
                ds = new DataSet();
                adapter = new SqlDataAdapter(query3, connection);
                adapter.Fill(ds);
                dataGridView2.DataSource = ds.Tables[0];
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
            string query1 = "INSERT INTO dbo.[Post] ([ID_Post],[ID_Products], [NamePost], [Adress], [Number]) VALUES" +
                "((\'" + textBox2.Text + "\'), (\'" + textBox1.Text + "\'), (\'" + textBox3.Text + "\'), (\'" + textBox4.Text + "\'), (\'" + textBox5.Text + "\')) ";
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
            var idpost = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string delete = "DELETE  FROM dbo.[Post] WHERE [ID_Post] = '" + idpost + "'";
            SqlCommand com = new SqlCommand(delete, connection);

            connection.Open();
            com.ExecuteNonQuery();
            connection.Close();
            Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query1 = $"UPDATE  dbo.[Post] SET [ID_Post] = '{textBox2.Text}',[ID_Products] = '{textBox1.Text}', [Name_Post] = '{textBox3.Text}', [Adress] = '{textBox4.Text}', [Number] = '{textBox5.Text}'";
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

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            string searchValue = textBox6.Text;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                bool found = false;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value.ToString().Equals(searchValue))
                    {
                        dataGridView1.ClearSelection(); // снимаем выделение со всех строк
                        row.Selected = true; // выделяем текущую строку
                        dataGridView1.FirstDisplayedScrollingRowIndex = row.Index;
                        found = true;
                        break;
                    }
                }

                if (found)
                {
                    break;
                }
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            string searchValue = textBox7.Text;

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                bool found = false;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value.ToString().Equals(searchValue))
                    {
                        dataGridView1.ClearSelection(); // снимаем выделение со всех строк
                        row.Selected = true; // выделяем текущую строку
                        dataGridView2.FirstDisplayedScrollingRowIndex = row.Index;
                        found = true;
                        break;
                    }
                }

                if (found)
                {
                    break;
                }
            }
        }
    }
}
