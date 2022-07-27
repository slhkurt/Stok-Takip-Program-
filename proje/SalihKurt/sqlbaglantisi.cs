using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SalihKurt
{
    class sqlbaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=DESKTOP-CPCAVRV\SA2019;Initial Catalog=DboStokTakip;Integrated Security=True");
            baglan.Open();
            return baglan;


        }


    }
}
