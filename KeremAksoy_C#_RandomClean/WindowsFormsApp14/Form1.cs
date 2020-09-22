using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.OleDb;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp14
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static string gonderilecekveri;
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source= Temizlikv1.31.accdb");
        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer4.Start();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label13.Text = Form2.gonderilecekveri;
            timer1.Start();
            timer2.Start();
            timer3.Start();
            ToolTip Aciklama = new ToolTip();
            Aciklama.ToolTipTitle = "Bilgi";
            Aciklama.ToolTipIcon = ToolTipIcon.Info;
            Aciklama.IsBalloon = true;
            Aciklama.SetToolTip(button2, "Temizlik Görevleri Arasından Random Görev Atar");
            timer5.Start();
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;

        }
        void listele_temizlik()
        {

            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM  Temizlik", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);

        }
       

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            MessageBox.Show("İyi Temizlikler Kolay Gelsin");
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("INSERT INTO Temizlik(t_ogrenci1,t_gorev1,t_ogrenci2,t_gorev2,t_ogrenci3,t_gorev3) VALUES(@ogrenci1,@gorev1,@ogrenci2,@gorev2,@ogrenci3,gorev3)", baglanti);
            komut.Parameters.AddWithValue("@ogrenci1", comboBox1.Text);
            komut.Parameters.AddWithValue("@gorev1", label9.Text);
            komut.Parameters.AddWithValue("@ogrenci2", comboBox2.Text);
            komut.Parameters.AddWithValue("@gorev2", label10.Text);
            komut.Parameters.AddWithValue("@ogrenci3", comboBox3.Text);
            komut.Parameters.AddWithValue("@gorev3", label11.Text);
            komut.ExecuteNonQuery();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label12.Text = label12.Text.Substring(1) + label12.Text.Substring(0, 1);

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label12.ForeColor = Color.Yellow;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            label12.ForeColor = Color.Red;
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label4.Text = comboBox1.SelectedItem.ToString(); label4.Visible = true;
            label2.Visible = true;
            comboBox2.Visible = true;
            comboBox2.Items.Remove(comboBox1.SelectedItem);
            comboBox3.Items.Remove(comboBox1.SelectedItem);
            comboBox1.Items.Remove(comboBox2.SelectedItem);
            comboBox1.Items.Remove(comboBox3.SelectedItem);







        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            label5.Text = comboBox2.SelectedItem.ToString(); label5.Visible = true;
            comboBox3.Visible = true;
            label3.Visible = true;
            comboBox3.Items.Remove(comboBox2.SelectedItem);
            comboBox3.Items.Remove(comboBox1.SelectedItem);
            comboBox2.Items.Remove(comboBox1.SelectedItem);
            comboBox2.Items.Remove(comboBox3.SelectedItem);

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            label6.Text = comboBox3.SelectedItem.ToString(); label6.Visible = true;
            comboBox2.Items.Remove(comboBox3.SelectedItem);
            comboBox3.Items.Remove(comboBox1.SelectedItem);
            comboBox3.Items.Remove(comboBox1.SelectedItem);
            comboBox3.Items.Remove(comboBox2.SelectedItem);


        }

        
        private void timer4_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            //string[] görevler = { "Paspas", "Toz Alma", "Süpürge"};
            List<string> gorev = new List<string> { "Paspas", "Toz Alma", "Süpürge" };
            int no = rnd.Next(0, gorev.Count);
            label9.Text = (gorev[no]); label9.Visible = true;
            gorev.RemoveAt(no);
            int no1 = rnd.Next(0, gorev.Count);
            label10.Text = (gorev[no1]); label10.Visible = true;
            gorev.RemoveAt(no1);
            int no2 = rnd.Next(0, gorev.Count);
            label11.Text = (gorev[no2]); label11.Visible = true;

           
            

        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            timer4.Stop();
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox5_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.ShowDialog();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }

        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void PictureBox6_Click(object sender, EventArgs e)
        {
            
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("INSERT INTO Temizlik(t_ogrenci1,t_gorev1,t_ogrenci2,t_gorev2,t_ogrenci3,t_gorev3) VALUES(@ogrenci1,@gorev1,@ogrenci2,@gorev2,@ogrenci3,gorev3)", baglanti);
            komut.Parameters.AddWithValue("@ogrenci1", comboBox1.Text);
            komut.Parameters.AddWithValue("@gorev1", label9.Text);
            komut.Parameters.AddWithValue("@ogrenci2", comboBox2.Text);
            komut.Parameters.AddWithValue("@gorev2", label10.Text);
            komut.Parameters.AddWithValue("@ogrenci3", comboBox3.Text);         
            komut.Parameters.AddWithValue("@gorev3", label11.Text);
            komut.ExecuteNonQuery();
            listele_temizlik();
            Form4 frm4 = new Form4();
            frm4.ShowDialog();
            baglanti.Close();
        }

        private void PictureBox6_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           
        }

        private void PictureBox7_Click(object sender, EventArgs e)
        {
            listele_temizlik();
            Form4 frm4 = new Form4();
            frm4.ShowDialog();
        }

        private void PictureBox5_ClientSizeChanged(object sender, EventArgs e)
        {
            
            
        }
        

    }
}
    

