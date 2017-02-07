using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DownloadAsynchronously
{
    public partial class Form1 : Form
    {
        private int counter;
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label2.Text = $"Count: {counter++}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            using (var client = new WebClient())
            {
                client.DownloadStringAsync(new Uri($"http://{textBox1.Text}"));
                button1.Enabled = false;
                client.DownloadStringCompleted += Client_DownloadStringCompleted;
            }
        }

        private void Client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            label4.Text = e.Result;
            label4.Visible = true;
            button1.Enabled = true;
        }
    }
}
