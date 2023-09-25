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
    public partial class Login : Form
    {
        public static string connectionString = "Data Source=ADCLG1;Initial Catalog=AugustikDanya;Integrated Security=True";
        SqlDataAdapter adapter;
        DataSet ds;
        SqlConnection connection = new SqlConnection(connectionString);
        int how = 0;
        public Login()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            var password = (textBox2.Text);
            string querystring = $"select Post, Password from Employee where Post ='{textBox1.Text}' and Password = '{password}'";
            SqlCommand command = new SqlCommand(querystring, connection);
            how = how + 1;
            if (command.ExecuteScalar() != null)
            {
                if (command.ExecuteScalar().ToString() == "Управляющий")
                {
                    Properties.Settings.Default.Who = 1;
                    MessageBox.Show("Добро Пожаловать Администратор!");
                    Administrator administrator = new Administrator();
                    this.Hide();
                    administrator.ShowDialog();
                    
                }
                else if (command.ExecuteScalar().ToString() == "Директор")
                {
                    Properties.Settings.Default.Who = 2;
                    MessageBox.Show("Добро пожаловать Директор!");
                    Director director = new Director();
                    this.Hide();
                    director.ShowDialog();
                    
                }
                else if (command.ExecuteScalar().ToString() == "Консультант")
                {
                    Properties.Settings.Default.Who = 3;
                    MessageBox.Show("Добро пожаловать Консультант!");
                    Assistent assistent = new Assistent();
                    this.Hide();
                    assistent.ShowDialog();
                    
                }
                else if (command.ExecuteScalar().ToString() == "Менеджер")
                {
                    Properties.Settings.Default.Who = 4;
                    MessageBox.Show("Добро пожаловать Менеджер!");
                    Meneger meneger = new Meneger();
                    this.Hide();
                    meneger.ShowDialog();
                    

                }

            }
            else
            {

                MessageBox.Show("Неверный логин или пароль",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if(how == 3)
                {
                    Kapcha kapcha = new Kapcha();
                    this.Hide();
                    kapcha.ShowDialog();
                }
            }
            connection.Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            textBox1.MaxLength = 15;

            textBox2.MaxLength = 10;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
