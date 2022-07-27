using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalihKurt
{
    public partial class FrmAnaModul : Form
    {
        public FrmAnaModul()
        {
            InitializeComponent();
        }

        FrmUrunler fu;
        private void btnUrunler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fu == null)
            {
                fu = new FrmUrunler();
                fu.MdiParent = this;
                fu.Show();
            }
        }

        FrmMusteriler fm;
        private void btnMusteri_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fm == null)
            {
                fm = new FrmMusteriler();
                fm.MdiParent = this;
                fm.Show();
            }
        }

        FrmFirmalar ff;
        private void btnFirma_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ff == null)
            {
                ff = new FrmFirmalar();
                ff.MdiParent = this;
                ff.Show();
            }
        }

        FrmPersonel fp;
        private void btnPersonel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fp == null)
            {
                fp = new FrmPersonel();
                fp.MdiParent = this;
                fp.Show();
            }
        }

        FrmRehber fr;
        private void btnRehber_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fr == null)
            {
                fr = new FrmRehber();
                fr.MdiParent = this;
                fr.Show();
            }
        }

        FrmGiderler fg;
        private void btnGider_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fg == null)
            {
                fg = new FrmGiderler();
                fg.MdiParent = this;
                fg.Show();
            }
        }

        FrmBankalar fb;
        private void btnBanka_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fb == null)
            {

                fb = new FrmBankalar();
                fb.MdiParent = this;
                fb.Show();
            }
        }

        FrmFatura ff2;
        private void btnFatura_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (ff2 == null)
            {
                ff2 = new FrmFatura();
                ff2.MdiParent = this;
                ff2.Show();
            }
        }

        FrmNotlar fn;
        private void btnNotlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fn == null)
            {

                fn = new FrmNotlar();
                fn.MdiParent = this;
                fn.Show();
            }
        }

        FrmHareketler fh;
        private void btnHareketler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fh == null)
            {
                fh = new FrmHareketler();
                fh.MdiParent = this;
                fh.Show();

            }
        }

        FrmStoklar fs;
        private void btnStok_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fs == null)
            {
                fs = new FrmStoklar();
                fs.MdiParent = this;
                fs.Show();
            }
        }

        FrmAyarlar fa;
        private void btnAyarlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fa==null)
            {
                fa = new FrmAyarlar();
                fa.MdiParent = this;
                fa.Show();
            }

        }

        FrmKasa fk;
        private void btnKasa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fk==null)
            {
                fk = new FrmKasa();
                fk.ad = kullanici;
                fk.MdiParent = this;
                fk.Show();
            }
        }

        public string kullanici;
        private void FrmAnaModul_Load(object sender, EventArgs e)
        {
            if (fas == null)
            {
                fas = new FrmAnaSayfa();
                fas.MdiParent = this;
                fas.Show();
            }
        }

        FrmAnaSayfa fas;
        private void btnAnaSayfa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fas==null)
            {
                fas = new FrmAnaSayfa();
                fas.MdiParent = this;
                fas.Show();
            }
        }
    }
}
