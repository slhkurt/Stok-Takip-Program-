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
    public partial class FrmGiderler : Form
    {
        public FrmGiderler()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from TBL_GIDER", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        private void FrmGiderler_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_GIDER (ELEKTRIK,SU,DOGALGAZ,INTERNET,MAASLAR,EKSTRA,NOTLAR,AY,YIL) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", decimal.Parse( txtelektrik.Text));
            komut.Parameters.AddWithValue("@p2", decimal.Parse(txtsu.Text));
            komut.Parameters.AddWithValue("@p3", decimal.Parse(txtdogalgaz.Text));
            komut.Parameters.AddWithValue("@p4", decimal.Parse(txtinternet.Text));
            komut.Parameters.AddWithValue("@p5", decimal.Parse(txtmaaslar.Text));
            komut.Parameters.AddWithValue("@p6", decimal.Parse(txtekstra.Text));
            komut.Parameters.AddWithValue("@p7", txtnotlar.Text);
            komut.Parameters.AddWithValue("@p8", cmbay.Text);
            komut.Parameters.AddWithValue("@p9", cmbyil.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Gider Sisteme Kayıt Edildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_GIDER set ELEKTRIK=@p1,SU=@p2,DOGALGAZ=@p3, INTERNET=@p4, MAASLAR=@p5, EKSTRA=@p6, NOTLAR=@p7,AY=@p8 ,YIL=@p9  WHERE ID=@p10", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", decimal.Parse(txtelektrik.Text));
            komut.Parameters.AddWithValue("@p2", decimal.Parse(txtsu.Text));
            komut.Parameters.AddWithValue("@p3", decimal.Parse(txtdogalgaz.Text));
            komut.Parameters.AddWithValue("@p4", decimal.Parse(txtinternet.Text));
            komut.Parameters.AddWithValue("@p5", decimal.Parse(txtmaaslar.Text));
            komut.Parameters.AddWithValue("@p6", decimal.Parse(txtekstra.Text));
            komut.Parameters.AddWithValue("@p7", txtnotlar.Text);
            komut.Parameters.AddWithValue("@p8", cmbay.Text);
            komut.Parameters.AddWithValue("@p9", cmbyil.Text);
            komut.Parameters.AddWithValue("@p10", txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Gider Başarılı Bir Şekilde Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtid.Text = dr["ID"].ToString();
                txtdogalgaz.Text = dr["DOGALGAZ"].ToString();
                txtekstra.Text = dr["EKSTRA"].ToString();
                txtelektrik.Text = dr["ELEKTRIK"].ToString();
                txtinternet.Text = dr["INTERNET"].ToString();
                txtmaaslar.Text = dr["MAASLAR"].ToString();
                txtnotlar.Text = dr["NOTLAR"].ToString();
                txtsu.Text = dr["SU"].ToString();
                cmbay.Text = dr["AY"].ToString();
                cmbyil.Text = dr["YIL"].ToString();
            }
        }

        void temizle()
        {
            txtdogalgaz.Text = "";
            txtekstra.Text = "";
            txtelektrik.Text = "";
            txtid.Text = "";
            txtinternet.Text = "";
            txtmaaslar.Text = "";
            txtnotlar.Text = "";
            txtsu.Text = "";
            cmbay.Text = "";
            cmbyil.Text = "";
            txtid.Focus();

        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("Delete From TBL_GIDER Where ID=@p1", bgl.baglanti());
            komutsil.Parameters.AddWithValue("@p1", txtid.Text);
            komutsil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Gider Başarılı Bir Şekilde Sistemden Kaldırıldı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            listele();
            temizle();
        }
    }
}
