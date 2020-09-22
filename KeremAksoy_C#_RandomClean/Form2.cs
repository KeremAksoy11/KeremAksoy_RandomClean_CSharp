using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp14
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public static string gonderilecekveri;
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            gonderilecekveri = textBox1.Text;
            Form1 frm1 = new Form1();
            Form2 frm2 = new Form2();
            frm1.Show();
            this.Hide();
            // Form 2 geldikten sonra form1 kapatılsın 

        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
           // Dispose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Red;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Blue;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
            this.KeyPreview = true;
            this.KeyDown += Form2_KeyDown;
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
