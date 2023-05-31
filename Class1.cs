using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace YurtKayitSistemi
{
    public class Class1
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=Y0K;Initial Catalog=YurtKayit;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
