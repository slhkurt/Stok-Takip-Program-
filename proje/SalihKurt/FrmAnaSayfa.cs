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
using System.Xml;

namespace SalihKurt
{
    public partial class FrmAnaSayfa : Form
    {
        public FrmAnaSayfa()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        void stoklar()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select URUNAD,sum(ADET) as 'ADET' From TBL_URUNLER group by URUNAD having SUM(ADET)<=20 order by SUM(ADET) ", bgl.baglanti());
            da.Fill(dt);
            gcStok.DataSource = dt;
        }

        void ajanda()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select top 8  NOTTARIH,NOTSAAT,NOTBASLIK From TBL_NOTLAR order by NOTID desc  ", bgl.baglanti());
            da.Fill(dt);
            gcAjanda.DataSource = dt;
        }

        void hareket()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("exec FirmaHareket2", bgl.baglanti());
            da.Fill(dt);
            gcHareket.DataSource = dt;
        }

        void fihrist()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select AD,TELEFON1,MAIL From TBL_FIRMALAR", bgl.baglanti());
            da.Fill(dt);
            gcFihrist.DataSource = dt;
        }

        int a = 0;
        void haberler()
        {
            XmlTextReader xmloku = new XmlTextReader("https://www.hurriyet.com.tr/rss/anasayfa");
            while (xmloku.Read())
            {
                if (xmloku.Name=="title")
                {
                    listBox1.Items.Add(xmloku.ReadString());
                }
            }
        }

        private void FrmAnaSayfa_Load(object sender, EventArgs e)
        {
            stoklar();
            ajanda();
            hareket();
            fihrist();
            haberler();

            webBrowser1.Navigate("https://www.tcmb.gov.tr/kurlar/kurlar_tr.html");
        }
    }
}
