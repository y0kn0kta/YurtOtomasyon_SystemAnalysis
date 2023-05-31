using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace YurtKayitSistemi
{
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
        }

        Class1 bgl = new Class1();

        private void Form13_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'yurtKayitDataSet6.Personel' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.personelTableAdapter.Fill(this.yurtKayitDataSet6.Personel);

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Personel (PersonelAdSoyad, PersonelDepartman) values (@p1,@p2)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtPersonelAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtPersonelGorev.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt eklendi.");
            this.personelTableAdapter.Fill(this.yurtKayitDataSet6.Personel);
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from Personel where Personelid=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtPersonelid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt silindi.");
            this.personelTableAdapter.Fill(this.yurtKayitDataSet6.Personel);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen;
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            string ad, gorev, id;
            id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            ad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            gorev = dataGridView1.Rows[secilen].Cells[2].Value.ToString();

            TxtPersonelAd.Text = ad;
            TxtPersonelGorev.Text = gorev;
            TxtPersonelid.Text = id;
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komutgun = new SqlCommand("update Personel set PersonelAdSoyad=@p1, PersonelDepartman=@p2 where Personelid=@p3", bgl.baglanti());
            komutgun.Parameters.AddWithValue("@p1", TxtPersonelAd.Text);
            komutgun.Parameters.AddWithValue("@p2", TxtPersonelGorev.Text);
            komutgun.Parameters.AddWithValue("@p3", TxtPersonelid.Text);
            komutgun.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt güncellendi.");
            this.personelTableAdapter.Fill(this.yurtKayitDataSet6.Personel);
        }
    }
}
