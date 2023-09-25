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
    public partial class Sell : Form
    {
        public static string connectionString = "Data Source=ADCLG1;Initial Catalog=AugustikDanya;Integrated Security=True";
        SqlDataAdapter adapter;
        DataSet ds;
        SqlConnection connection = new SqlConnection(connectionString);
        public Sell()
        {
            InitializeComponent();
            string query2 = "SELECT * FROM Sell";
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
            string query4 = "SELECT * FROM Clients";
            connection.Open();
            {
                ds = new DataSet();
                adapter = new SqlDataAdapter(query4, connection);
                adapter.Fill(ds);
                dataGridView3.DataSource = ds.Tables[0];
            }
            connection.Close();
        }
        private void Refresh()
        {
            string query1 = "SELECT * FROM Sell";
            connection.Open();
            {
                ds = new DataSet();
                adapter = new SqlDataAdapter(query1, connection);
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            connection.Close();




        }



        private void RefreshButton_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query1 = "INSERT INTO dbo.[Sell] ([ID_Sell],[ID_Products], [Data_Sell], [Count_SellProducts], [PriceSell],[ID_Client],[ID_Employee]) VALUES" +
                "((\'" + textBox2.Text + "\'), (\'" + textBox1.Text + "\'), (\'" + textBox3.Text + "\'), (\'" + textBox4.Text + "\'), (\'" + textBox5.Text + "\'), (\'" + textBox6.Text + "\'), (\'" + textBox7.Text + "\')) ";
            SqlCommand com = new SqlCommand(query1, connection);
            connection.Open();
            com.ExecuteNonQuery();
            connection.Close();

            Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var idsell = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string delete = "DELETE  FROM dbo.[Sell] WHERE [ID_Sell] = '" + idsell + "'";
            SqlCommand com = new SqlCommand(delete, connection);

            connection.Open();
            com.ExecuteNonQuery();
            connection.Close();
            Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query1 = $"UPDATE  dbo.[Sell] SET [ID_Sell] = '{textBox2.Text}',[ID_Products] = '{textBox1.Text}', [Data_Sell] = '{textBox3.Text}', [Count_SellProducts] = '{textBox4.Text}', [PriceSell] = '{textBox5.Text}', [ID_Client] = '{textBox6.Text}', [ID_Employee] = '{textBox7.Text}'";
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
            textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
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

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            string searchValue = textBox8.Text;

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

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            string searchValue = textBox9.Text;

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                bool found = false;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value.ToString().Equals(searchValue))
                    {
                        dataGridView2.ClearSelection(); // снимаем выделение со всех строк
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

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            string searchValue = textBox10.Text;

            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                bool found = false;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value.ToString().Equals(searchValue))
                    {
                        dataGridView3.ClearSelection(); // снимаем выделение со всех строк
                        row.Selected = true; // выделяем текущую строку
                        dataGridView3.FirstDisplayedScrollingRowIndex = row.Index;
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
