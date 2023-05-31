using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace YurtKayitSistemi
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        public string elektrik, su, dogalgaz, gida, diger, internet, personel, id;

        Class1 bgl = new Class1();

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("update Giderler set Elektrik=@p1, Su=@p2, Dogalgaz=@p3, internet=@p4, Gida=@p5, Personel=@p6, Diger=@p7 where Odemeid=@p8", bgl.baglanti());
                komut.Parameters.AddWithValue("@p8", TxtGiderid.Text);
                komut.Parameters.AddWithValue("@p1", TxtElektrik.Text);
                komut.Parameters.AddWithValue("@p2", TxtSu.Text);
                komut.Parameters.AddWithValue("@p3", TxtDogalgaz.Text);
                komut.Parameters.AddWithValue("@p4", TxtInternet.Text);
                komut.Parameters.AddWithValue("@p5", TxtGida.Text);
                komut.Parameters.AddWithValue("@p6", TxtPersonel.Text);
                komut.Parameters.AddWithValue("@p7", TxtDiger.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Güncelleme yapıldı.");
            }
            catch (Exception)
            {
                MessageBox.Show("Hata oluştu! Yeniden deneyin.");
            }
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            TxtGiderid.Text = id;
            TxtElektrik.Text = elektrik;
            TxtDogalgaz.Text = dogalgaz;
            TxtGida.Text = gida;
            TxtSu.Text = su;
            TxtPersonel.Text = personel;
            TxtInternet.Text = internet;
            TxtDiger.Text = diger;
        }
    }
}
