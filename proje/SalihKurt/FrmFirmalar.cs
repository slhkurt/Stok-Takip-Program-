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
    public partial class FrmFirmalar : Form
    {
        public FrmFirmalar()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        void FirmaListesi ()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_FIRMALAR", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void Sehirlistele()
        {
            SqlCommand komut = new SqlCommand("select SEHIR from TBL_ILLER", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbil.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }

        private void cmbil_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbilce.Properties.Items.Clear();

            SqlCommand komut = new SqlCommand("select ILCE from TBL_ILCELER Where SEHIR = @p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", cmbil.SelectedIndex + 1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbilce.Properties.Items.Add(dr[0]);
            }
            bgl.baglanti().Close();
        }
        
        void temizle()
        {
            txtad.Text = "";
            txtgorev.Text = "";
            txtid.Text = "";
            txtkod1.Text = "";
            txtkod2.Text = "";
            txtkod3.Text = "";
            txtmail.Text = "";
            txtsektor.Text = "";
            txtVD.Text = "";
            txtyetkili.Text = "";
            mskFax.Text = "";
            mskTel1.Text="";
            mskTel2.Text = "";
            mskTel3.Text = "";
            mskYTc.Text = "";
            rchAdres.Text = "";
            rchkod1.Text = "";
            rchkod2.Text = "";
            rchkod3.Text = "";
            cmbilce.Text = "";
            txtad.Focus();

        }

        void carikodaciklamalar()
        {
            SqlCommand komut = new SqlCommand("select FIRMAKOD1,FIRMAKOD2,FIRMAKOD3 From TBL_KODLAR", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                rchkod1.Text = dr[0].ToString();
                rchkod2.Text = dr[1].ToString();
                rchkod3.Text = dr[2].ToString();
            }
            bgl.baglanti().Close();
        }

        private void FrmFirmalar_Load(object sender, EventArgs e)
        {
            FirmaListesi();
            Sehirlistele();
            carikodaciklamalar();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtid.Text = dr["ID"].ToString();
                txtad.Text = dr["AD"].ToString();
                txtyetkili.Text = dr["YETKILIADSOYAD"].ToString();
                txtgorev.Text = dr["YETKILISTATU"].ToString();
                mskTel1.Text = dr["TELEFON1"].ToString();
                mskTel2.Text = dr["TELEFON2"].ToString();
                mskTel3.Text = dr["TELEFON3"].ToString();
                mskYTc.Text = dr["YETKILITC"].ToString();
                mskFax.Text = dr["FAX"].ToString();
                txtmail.Text = dr["MAIL"].ToString();
                cmbil.Text = dr["IL"].ToString();
                cmbilce.Text = dr["ILCE"].ToString();
                txtVD.Text = dr["VERGIDAIRE"].ToString();
                rchAdres.Text = dr["ADRES"].ToString();
                txtkod1.Text = dr["OZELKOD1"].ToString();
                txtkod2.Text = dr["OZELKOD2"].ToString();
                txtkod3.Text = dr["OZELKOD3"].ToString();
                txtsektor.Text = dr["SEKTORU"].ToString();
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_FIRMALAR (AD,YETKILISTATU,YETKILIADSOYAD,TELEFON1,TELEFON2 ,TELEFON3,MAIL,FAX,IL,ILCE,VERGIDAIRE,ADRES,YETKILITC,OZELKOD1,OZELKOD2,OZELKOD3, SEKTORU) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15,@p16,@p17)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtgorev.Text);
            komut.Parameters.AddWithValue("@p3", txtyetkili.Text);
            komut.Parameters.AddWithValue("@p4", mskTel1.Text);
            komut.Parameters.AddWithValue("@p5", mskTel2.Text);
            komut.Parameters.AddWithValue("@p6", mskTel3.Text);
            komut.Parameters.AddWithValue("@p7", txtmail.Text);
            komut.Parameters.AddWithValue("@p8", mskFax.Text);
            komut.Parameters.AddWithValue("@p9", cmbil.Text);
            komut.Parameters.AddWithValue("@p10", cmbilce.Text);
            komut.Parameters.AddWithValue("@p11", txtVD.Text);
            komut.Parameters.AddWithValue("@p12", rchAdres.Text);
            komut.Parameters.AddWithValue("@p13", mskYTc.Text);
            komut.Parameters.AddWithValue("@p14", txtkod1.Text);
            komut.Parameters.AddWithValue("@p15", txtkod2.Text);
            komut.Parameters.AddWithValue("@p16", txtkod3.Text);
            komut.Parameters.AddWithValue("@p17", txtsektor.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Firma Sisteme Kayıt Edildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FirmaListesi();
            temizle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_FIRMALAR set AD=@p1,YETKILISTATU=@p2,YETKILIADSOYAD=@p3, TELEFON1=@p4, TELEFON2=@p5, TELEFON3=@p6, MAIL=@p7, FAX=@p8,IL=@p9 ,ILCE=@p10,VERGIDAIRE=@p11, ADRES=@p12, YETKILITC=@p13, OZELKOD1=@p14, OZELKOD2=@p15, OZELKOD3=@p16, SEKTORU=@p17   WHERE ID=@p18", bgl.baglanti()); 
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtgorev.Text);
            komut.Parameters.AddWithValue("@p3", txtyetkili.Text);
            komut.Parameters.AddWithValue("@p4", mskTel1.Text);
            komut.Parameters.AddWithValue("@p5", mskTel2.Text);
            komut.Parameters.AddWithValue("@p6", mskTel3.Text);
            komut.Parameters.AddWithValue("@p7", txtmail.Text);
            komut.Parameters.AddWithValue("@p8", mskFax.Text);
            komut.Parameters.AddWithValue("@p9", cmbil.Text);
            komut.Parameters.AddWithValue("@p10", cmbilce.Text);
            komut.Parameters.AddWithValue("@p11", txtVD.Text);
            komut.Parameters.AddWithValue("@p12", rchAdres.Text);
            komut.Parameters.AddWithValue("@p13", mskYTc.Text);
            komut.Parameters.AddWithValue("@p14", txtkod1.Text);
            komut.Parameters.AddWithValue("@p15", txtkod2.Text);
            komut.Parameters.AddWithValue("@p16", txtkod3.Text);
            komut.Parameters.AddWithValue("@p17", txtsektor.Text);
            komut.Parameters.AddWithValue("@p18", txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Firma Başarılı Bir Şekilde Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FirmaListesi();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("Delete From TBL_FIRMALAR Where ID=@p1", bgl.baglanti());
            komutsil.Parameters.AddWithValue("@p1", txtid.Text);
            komutsil.ExecuteNonQuery();
            bgl.baglanti().Close();
            FirmaListesi();
            MessageBox.Show("Firma Başarılı Bir Şekilde Sistemden Kaldırıldı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}
