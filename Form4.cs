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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        Class1 bgl = new Class1(); 

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'yurtKayitDataSet2.Borclar' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.borclarTableAdapter.Fill(this.yurtKayitDataSet2.Borclar);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen;
            string id, ad, soyad, kalan;
            secilen = dataGridView1.SelectedCells[0].RowIndex;
            id = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            ad = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            soyad = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            kalan = dataGridView1.Rows[secilen].Cells[3].Value.ToString();

            TxtAd.Text = ad;
            TxtSoyad.Text = soyad;
            TxtKalan.Text = kalan;
            TxtOgrid.Text = id;
        }

        private void BtnOdemeAl_Click(object sender, EventArgs e)
        {
            //Ödenen tutarı kalan tutardan düşürme
            int odenen, kalan, yeniborc;
            odenen = Convert.ToInt16(TxtOdenen.Text);
            kalan = Convert.ToInt16(TxtKalan.Text);
            yeniborc = kalan - odenen;
            TxtKalan.Text = yeniborc.ToString();

            //Yeni tutarı veri tabanına kaydetme
            SqlCommand komut = new SqlCommand("update Borclar set OgrKalanBorc=@p1 where Ogrid=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p2", TxtOgrid.Text);
            komut.Parameters.AddWithValue("@p1", TxtKalan.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Borç ödendi.");
            this.borclarTableAdapter.Fill(this.yurtKayitDataSet2.Borclar);

            //Kasa tablosuna ekleme yapma
            SqlCommand komut2 = new SqlCommand("insert into Kasa (OdemeAy, OdemeMiktar) values (@k1, @k2)", bgl.baglanti());
            komut2.Parameters.AddWithValue("@k1", TxtOdenenAy.Text);
            komut2.Parameters.AddWithValue("@k2", TxtOdenen.Text);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();
        }
    }
}
