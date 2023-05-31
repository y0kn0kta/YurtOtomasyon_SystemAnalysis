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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        Class1 bgl = new Class1();

        private void Form10_Load(object sender, EventArgs e)
        {
            //Kasadaki toplam tutar
            SqlCommand komut = new SqlCommand("Select Sum(OdemeMiktar) from Kasa",bgl.baglanti());
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                LblPara.Text = oku[0].ToString() + " TL";
            }
            bgl.baglanti().Close();

            //Tekrarsız olarak ayları listeleme
            SqlCommand komut2 = new SqlCommand("Select distinct(OdemeAy) from Kasa", bgl.baglanti());
            SqlDataReader oku2 = komut2.ExecuteReader();
            while (oku2.Read())
            {
                CmbAy.Items.Add(oku2[0].ToString());
            }
            bgl.baglanti().Close();

        }

        private void CmbAy_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select sum(OdemeMiktar) from Kasa where OdemeAy=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", CmbAy.Text);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                LblAyKazanc.Text = oku[0].ToString();
            }
            bgl.baglanti().Close();
        }
    }
}
