using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YurtKayitSistemi
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void giderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form8 fr = new Form8();
            fr.Show();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'yurtKayitDataSet1.Ogrenci' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.ogrenciTableAdapter.Fill(this.yurtKayitDataSet1.Ogrenci);
            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongDateString();
            label2.Text = DateTime.Now.ToLongTimeString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void öğrenciEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 fr = new Form1();
            fr.Show();
        }

        private void öğrenciListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 fr = new Form5();
            fr.Show();
        }

        private void öğrenciDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 fr = new Form6();
            fr.Show();
        }

        private void bölümEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 fr = new Form2();
            fr.Show();
        }

        private void öğrenciÖdemeAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 fr = new Form4();
            fr.Show();
        }

        private void giderEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 fr = new Form7();
            fr.Show();
        }

        private void gelirİstatistikleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form10 fr = new Form10();
            fr.Show();
        }

        private void şifreİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form12 fr = new Form12();
            fr.Show();
        }

        private void personelDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form13 fr = new Form13();
            fr.Show();
        }

        private void hakkımızdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sistem analizi ve tasarımı final proje");
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
