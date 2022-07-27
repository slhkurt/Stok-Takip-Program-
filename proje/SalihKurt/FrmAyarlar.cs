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
    public partial class FrmAyarlar : Form
    {
        public FrmAyarlar()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from TBL_ADMIN", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        private void FrmAyarlar_Load(object sender, EventArgs e)
        {
            listele();
            txtkad.Text = "";
            txtS.Text = "";
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (btnKaydet.Text == "KAYDET")
            {
                SqlCommand komut = new SqlCommand("insert into TBL_ADMIN (KullaniciAd,Sifre) values (@p1,@p2)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", txtkad.Text);
                komut.Parameters.AddWithValue("@p2", txtS.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Kullanıcı Sisteme Kayıt Edildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
            }
            if (btnKaydet.Text == "GÜNCELLE")
            {
                SqlCommand komut = new SqlCommand("update TBL_ADMIN set Sifre=@p2 where KullaniciAd=@p1 ", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", txtkad.Text);
                komut.Parameters.AddWithValue("@p2", txtS.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Kullanıcı Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                txtkad.Text = dr["KullaniciAd"].ToString();
                txtS.Text = dr["Sifre"].ToString();
            }
        }

        private void txtkad_TextChanged(object sender, EventArgs e)
        {
            if (txtkad.Text != "")
            {
                btnKaydet.Text = "GÜNCELLE";
                btnKaydet.ForeColor = Color.Green;
            }
            else
            {
                btnKaydet.Text = "KAYDET";
                btnKaydet.ForeColor = Color.Blue;
            }
        }
    }
}
