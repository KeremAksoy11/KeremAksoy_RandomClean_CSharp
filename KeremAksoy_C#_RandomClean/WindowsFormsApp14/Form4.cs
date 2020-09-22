using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp14
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source= Temizlikv1.31.accdb");
        private void Form4_Load(object sender, EventArgs e)
        {
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM Temizlik", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
        void listele_temizlik()
        {

            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM  Temizlik", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);

        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            listele_temizlik();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM Temizlik", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DialogResult tus = MessageBox.Show("KAYIDI SİLMEK İSTİYOR MUSUN ? ", "ÇIKIŞ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tus == DialogResult.Yes)
            {
                string secilen_öğrenci = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                baglanti.Open();
                OleDbCommand komut = new OleDbCommand("DELETE FROM Temizlik WHERE kimlik = @a", baglanti);
                komut.Parameters.AddWithValue("@a", secilen_öğrenci);
                komut.ExecuteNonQuery();
                baglanti.Close();
                listele_temizlik();
            }
        }
    }
}
