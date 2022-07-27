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
    public partial class FrmAdmin : Form
    {
        public FrmAdmin()
        {
            InitializeComponent();
        }

        private void FrmAdmin_MouseHover(object sender, EventArgs e)
        {
            btnGiris.BackColor = Color.Aqua;
        }

        private void FrmAdmin_MouseLeave(object sender, EventArgs e)
        {
            btnGiris.BackColor = Color.PaleTurquoise;
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        private void btnGiris_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from TBL_ADMIN where KullaniciAd=@p1 and Sifre=@p2",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtKA.Text);
            komut.Parameters.AddWithValue("@p2", txtS.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FrmAnaModul fa = new FrmAnaModul();
                fa.kullanici = txtKA.Text;
                fa.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı Veya Şifre Hatalı Lütfen Kontrol Ediniz..", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            bgl.baglanti().Close();
        }
    }
}
