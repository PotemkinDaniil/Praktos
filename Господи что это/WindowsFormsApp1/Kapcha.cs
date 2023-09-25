using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Kapcha : Form
    {
        public Kapcha()
        {
            InitializeComponent();
        }

        private string captcha;
        private bool isCaptchaCorrect;
        Login login = new Login();

        private void Kapcha_Load(object sender, EventArgs e)
        {
            GenerateCaptcha();
            AddNoiseToCaptcha();
        }
        private void AddNoiseToCaptcha()
        {
            Bitmap captchaImage = new Bitmap(label1.Width, label1.Height);
            Graphics g = Graphics.FromImage(captchaImage);

            Random random = new Random();

            for (int i = 0; i < 50; i++)
            {
                int x = random.Next(captchaImage.Width);
                int y = random.Next(captchaImage.Height);
                captchaImage.SetPixel(x, y, Color.Black);
            }

            label1.Image = captchaImage;
        }
        private void GenerateCaptcha()
        {
            Random random = new Random();
            captcha = random.Next(1000, 9999).ToString();
            label1.Text = captcha;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isCaptchaCorrect)
            {
                string password = textBox1.Text;
                // Далее можно добавить логику для проверки пароля или открытия другой формы
                MessageBox.Show("Пароль введен!");
            }
            else
            {
                MessageBox.Show("Неправильная капча! Попробуйте еще раз.");
                textBox1.Clear();
                GenerateCaptcha();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == captcha)
            {
                isCaptchaCorrect = true;
                this.Hide();
                login.ShowDialog();
                
            }
            else
            {
                isCaptchaCorrect = false;
                
            }
        }
    }
}
    
