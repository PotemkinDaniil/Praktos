﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Assistent : Form
    {
        public Assistent()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clients clients = new Clients();
            clients.ShowDialog();
            clients.button2.Hide();
            clients.button3.Hide();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Products products = new Products();
            products.ShowDialog();
            products.button1.Hide();
            products.button2.Hide();
            products.button3.Hide();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Sell sell = new Sell();
            sell.ShowDialog();
            sell.button2.Hide();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Post post = new Post();
            post.ShowDialog();
            post.button1.Hide();
            post.button2.Hide();
            post.button3.Hide();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            employee.ShowDialog();
            employee.button1.Hide();
            employee.button2.Hide();
            employee.button3.Hide();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
