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

namespace DownloadSynchronously
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
                var text = client.DownloadString($"http://{textBox1.Text}");
                Thread.Sleep(10000);
                label3.Text = text;
            }
        }
    }
}