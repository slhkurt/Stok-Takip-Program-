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

namespace SalihKurt
{
    public partial class FrmNotlar : Form
    {
        public FrmNotlar()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from TBL_NOTLAR", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        private void FrmNotlar_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_NOTLAR (NOTSAAT,NOTBASLIK,NOTDETAY,NOTOLUSTURAN,NOTTARIH,NOTHITAP) values (@p1,@p2,@p3,@p4,@p5,@p6)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", msksaat.Text);
            komut.Parameters.AddWithValue("@p2", txtbaslik.Text);
            komut.Parameters.AddWithValue("@p3", rchdetay.Text);
            komut.Parameters.AddWithValue("@p4", txtOlusturan.Text);
            komut.Parameters.AddWithValue("@p5", msktarih.Text);
            komut.Parameters.AddWithValue("@p6", txthitap.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Not Sisteme Kayıt Edildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtid.Text = dr["NOTID"].ToString();
                msksaat.Text = dr["NOTSAAT"].ToString();
                txtbaslik.Text = dr["NOTBASLIK"].ToString();
                rchdetay.Text = dr["NOTDETAY"].ToString();
                txtOlusturan.Text = dr["NOTOLUSTURAN"].ToString();
                msktarih.Text = dr["NOTTARIH"].ToString();
                txthitap.Text = dr["NOTHITAP"].ToString();
            }
        }

        void temizle()
        {
            txtid.Text = "";
            msksaat.Text = "";
            txtbaslik.Text = "";
            rchdetay.Text = "";
            txtOlusturan.Text = "";
            msktarih.Text = "";
            txthitap.Text = "";
            
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_NOTLAR set NOTSAAT=@p1,NOTBASLIK=@p2,NOTDETAY=@p3, NOTOLUSTURAN=@p4, NOTTARIH=@p5, NOTHITAP=@p6 WHERE NOTID=@p7", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", msksaat.Text);
            komut.Parameters.AddWithValue("@p2", txtbaslik.Text);
            komut.Parameters.AddWithValue("@p3", rchdetay.Text);
            komut.Parameters.AddWithValue("@p4", txtOlusturan.Text);
            komut.Parameters.AddWithValue("@p5", msktarih.Text);
            komut.Parameters.AddWithValue("@p6", txthitap.Text);
            komut.Parameters.AddWithValue("@p7", txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Not Başarılı Bir Şekilde Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("Delete From TBL_NOTLAR Where NOTID=@p1", bgl.baglanti());
            komutsil.Parameters.AddWithValue("@p1", txtid.Text);
            komutsil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("NOT Başarılı Bir Şekilde Sistemden Kaldırıldı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            listele();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            FrmNotDetay fr = new FrmNotDetay();

            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                fr.metin = dr["NOTDETAY"].ToString();
            }
            fr.Show();
        }
    }
}
