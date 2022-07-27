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
    public partial class FrmBankalar : Form
    {
        public FrmBankalar()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("exec BANKABILGILERI", bgl.baglanti());
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

        void Firmalistele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select ID,AD from TBL_FIRMALAR", bgl.baglanti());
            da.Fill(dt);
            cmbFirma.Properties.ValueMember = "ID";
            cmbFirma.Properties.DisplayMember = "AD";
            cmbFirma.Properties.DataSource = dt;

        }

        private void FrmBankalar_Load(object sender, EventArgs e)
        {
            listele();
            Sehirlistele();
            Firmalistele();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_BANKA (BANKAADI,SUBE,IBAN,HESAPNO,YETKILI,TARIH,HESAPTURU,FIRMAID,IL,ILCE,TEL) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsube.Text);
            komut.Parameters.AddWithValue("@p3", mskiban.Text);
            komut.Parameters.AddWithValue("@p4", mskhesapno.Text);
            komut.Parameters.AddWithValue("@p5", txtyetkili.Text);
            komut.Parameters.AddWithValue("@p6", mskTarih.Text);
            komut.Parameters.AddWithValue("@p7", txthesapturu.Text);
            komut.Parameters.AddWithValue("@p8", cmbFirma.EditValue);
            komut.Parameters.AddWithValue("@p9", cmbil.Text);
            komut.Parameters.AddWithValue("@p10", cmbilce.Text);
            komut.Parameters.AddWithValue("@p11", msktel.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Banka Sisteme Kayıt Edildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_BANKA set BANKAADI=@p1,SUBE=@p2,IBAN=@p3, HESAPNO=@p4, YETKILI=@p5, TARIH=@p6, HESAPTURU=@p7,FIRMAID=@p8 ,IL=@p9, ILCE=@p10, TEL=@p11  WHERE ID=@p12", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsube.Text);
            komut.Parameters.AddWithValue("@p3", mskiban.Text);
            komut.Parameters.AddWithValue("@p4", mskhesapno.Text);
            komut.Parameters.AddWithValue("@p5", txtyetkili.Text);
            komut.Parameters.AddWithValue("@p6", mskTarih.Text);
            komut.Parameters.AddWithValue("@p7", txthesapturu.Text);
            komut.Parameters.AddWithValue("@p8", cmbFirma.EditValue);
            komut.Parameters.AddWithValue("@p9", cmbil.Text);
            komut.Parameters.AddWithValue("@p10", cmbilce.Text);
            komut.Parameters.AddWithValue("@p11", msktel.Text);
            komut.Parameters.AddWithValue("@p12", txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Banka Sisteme Kayıt Edildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("Delete From TBL_BANKA Where ID=@p1", bgl.baglanti());
            komutsil.Parameters.AddWithValue("@p1", txtid.Text);
            komutsil.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Banka Başarılı Bir Şekilde Sistemden Kaldırıldı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            listele();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtid.Text = dr["ID"].ToString();
                txtad.Text = dr["BANKAADI"].ToString();
                txtsube.Text = dr["SUBE"].ToString();
                mskiban.Text = dr["IBAN"].ToString();
                mskhesapno.Text = dr["HESAPNO"].ToString();
                txtyetkili.Text = dr["YETKILI"].ToString();
                mskTarih.Text = dr["TARIH"].ToString();
                txthesapturu.Text = dr["HESAPTURU"].ToString();
                cmbil.Text = dr["IL"].ToString();
                cmbilce.Text = dr["ILCE"].ToString();
                msktel.Text = dr["TEL"].ToString();
            }
        }

        void temizle()
        {
            txtad.Text = "";
            txtid.Text = "";
            txthesapturu.Text = "";
            txtsube.Text = "";
            txtyetkili.Text = "";
            mskhesapno.Text = "";
            mskiban.Text = "";
            mskTarih.Text = "";
            msktel.Text = "";
            cmbFirma.Text = "";
            cmbil.Text = "";
            cmbilce.Text = "";

            txtad.Focus();

        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}
