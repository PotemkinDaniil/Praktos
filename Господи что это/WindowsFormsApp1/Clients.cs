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
    public partial class Clients : Form
    {
        public static string connectionString = "Data Source=ADCLG1;Initial Catalog=AugustikDanya;Integrated Security=True";
        SqlDataAdapter adapter;
        DataSet ds;
        SqlConnection connection = new SqlConnection(connectionString);
        public Clients()
        {
            InitializeComponent();
            string query2 = "SELECT * FROM Clients";
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

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query1 = "INSERT INTO dbo.[Clients] ([ID_Client],[Name_Client], [Adress], [Number]) VALUES" +
                "((\'" + textBox2.Text + "\'), (\'" + textBox1.Text + "\'), (\'" + textBox3.Text + "\'), (\'" + textBox4.Text + "\')) ";
            SqlCommand com = new SqlCommand(query1, connection);
            connection.Open();
            com.ExecuteNonQuery();
            connection.Close();

            Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var idclietns = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            string delete = "DELETE  FROM dbo.[Clients] WHERE [ID_Client] = '" + idclietns + "'";
            SqlCommand com = new SqlCommand(delete, connection);

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
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query1 = $"UPDATE  dbo.[Clients] SET [ID_Client] = '{textBox2.Text}',[Name_Client] = '{textBox1.Text}', [Adress] = '{textBox3.Text}', [Number] = '{textBox4.Text}'";
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
                this.Close();
            }
            else if (Properties.Settings.Default.Who == 2)
            {
                Director director = new Director();
                director.ShowDialog();
                this.Close();
            }
            else if (Properties.Settings.Default.Who == 3)
            {
                Assistent assistent = new Assistent();
                assistent.ShowDialog();
                this.Close();
            }
            else if (Properties.Settings.Default.Who == 4)
            {
                Meneger meneger = new Meneger();
                meneger.ShowDialog();
                this.Close();
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
