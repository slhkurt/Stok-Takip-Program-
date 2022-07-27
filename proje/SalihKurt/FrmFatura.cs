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
    public partial class FrmFatura : Form
    {
        public FrmFatura()
        {
            InitializeComponent();
        }


        sqlbaglantisi bgl = new sqlbaglantisi();

        void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from TBL_FATURABILGI", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        private void FrmFatura_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtfaturaid.Text == "")
            {
                SqlCommand komut = new SqlCommand("insert into TBL_FATURABILGI (SERI,SIRANO,SAAT,VERGIDAIRE,ALICI,TESLIMEDEN,TESLIMALAN,TARIH) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", txtseri.Text);
                komut.Parameters.AddWithValue("@p2", txtSIRANO.Text);
                komut.Parameters.AddWithValue("@p3", mskSaat.Text);
                komut.Parameters.AddWithValue("@p4", txtvergi.Text);
                komut.Parameters.AddWithValue("@p5", txtALICI.Text);
                komut.Parameters.AddWithValue("@p6", txtTESLIMEDEN.Text);
                komut.Parameters.AddWithValue("@p7", txtTESLIMALAN.Text);
                komut.Parameters.AddWithValue("@p8", mskTARIH.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Fatura Sisteme Kayıt Edildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
            }
            if (txtfaturaid.Text != "")
            {
                double miktar, tutar, fiyat;
                fiyat = Convert.ToDouble(txtfiyat.Text);
                miktar = Convert.ToDouble(txtmiktar.Text);
                tutar = miktar * fiyat;
                txttutar.Text = tutar.ToString();
                SqlCommand komut = new SqlCommand("insert into TBL_FATURASATIR (URUNAD,MIKTAR,FİYAT,TUTAR,FATURASATIRID) values (@p1,@p2,@p3,@p4,@p5)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", txtad.Text);
                komut.Parameters.AddWithValue("@p2", txtmiktar.Text);
                komut.Parameters.AddWithValue("@p3", txtfiyat.Text);
                komut.Parameters.AddWithValue("@p4", txttutar.Text);
                komut.Parameters.AddWithValue("@p5", txtfaturaid.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Fatura'ya Ait Ürün Sisteme Kayıt Edildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
            }
        }

        void temizle()
        {
            txtad.Text = "";
            txtALICI.Text = "";
            txtfaturaid.Text = "";
            txtfiyat.Text = "";
            txtid.Text = "";
            txtmiktar.Text = "";
            txtseri.Text = "";
            txtSIRANO.Text = "";
            txtTESLIMALAN.Text = "";
            txtTESLIMEDEN.Text = "";
            txttutar.Text = "";
            txtvergi.Text = "";
            txtüid.Text = "";
            mskSaat.Text = "";
            mskTARIH.Text = "";

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtid.Text = dr["FATURABILGIID"].ToString();
                txtSIRANO.Text = dr["SERI"].ToString();
                txtseri.Text = dr["SIRANO"].ToString();
                mskTARIH.Text = dr["TARIH"].ToString();
                mskSaat.Text = dr["SAAT"].ToString();
                txtvergi.Text = dr["VERGIDAIRE"].ToString();
                txtALICI.Text = dr["ALICI"].ToString();
                txtTESLIMEDEN.Text = dr["TESLIMEDEN"].ToString();
                txtTESLIMALAN.Text = dr["TESLIMALAN"].ToString();
            }
        }

        private void btnSil_Click_1(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("Delete From TBL_FATURABILGI Where FATURABILGIID=@p1", bgl.baglanti());
            komutsil.Parameters.AddWithValue("@p1", txtid.Text);
            komutsil.ExecuteNonQuery();
            bgl.baglanti().Close();
            listele();
            MessageBox.Show("Fatura Başarılı Bir Şekilde Sistemden Kaldırıldı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_FATURABILGI set SERI=@p1,SIRANO=@p2,SAAT=@p3,VERGIDAIRE=@p4,ALICI=@p5,TESLIMEDEN=@p6,TESLIMALAN=@p7,TARIH=@p8 Where FATURABILGIID=@p9", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtseri.Text);
            komut.Parameters.AddWithValue("@p2", txtSIRANO.Text);
            komut.Parameters.AddWithValue("@p3", mskSaat.Text);
            komut.Parameters.AddWithValue("@p4", txtvergi.Text);
            komut.Parameters.AddWithValue("@p5", txtALICI.Text);
            komut.Parameters.AddWithValue("@p6", txtTESLIMEDEN.Text);
            komut.Parameters.AddWithValue("@p7", txtTESLIMALAN.Text);
            komut.Parameters.AddWithValue("@p8", mskTARIH.Text);
            komut.Parameters.AddWithValue("@p9", txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Fatura Güncelleme Gerçekleştirildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            temizle();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmFaturaUrunDetay fr = new FrmFaturaUrunDetay();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr!=null)
            {
                fr.id = dr["FATURABILGIID"].ToString();
            }
            fr.Show();
        }
    }
}
