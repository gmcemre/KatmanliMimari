using KatmanliMimariEntity;
using KatmanliMimariORM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KatmanliMimari_WinFormUI
{
    public partial class UrunlerForm : Form
    {
        public UrunlerForm()
        {
            InitializeComponent();
        }

        UrunlerORM urunlerORM = new UrunlerORM();
        private void UrunlerForm_Load(object sender, EventArgs e)
        {

            dataGridView1.DataSource = urunlerORM.Select();

            KategoriORM kategori = new KategoriORM();
            cmbKategori.DisplayMember = "KategoriAdi";
            cmbKategori.ValueMember = "KAtegoriID";
            cmbKategori.DataSource = kategori.Select();

            TedarikciORM tedarikci = new TedarikciORM();
            cmbTedarikci.DisplayMember = "SirketAdi";
            cmbTedarikci.ValueMember = "TedarikciID";
            cmbTedarikci.DataSource = tedarikci.Select();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Urunler urun = new Urunler { UrunAdi = txtUrunAdi.Text, BirimFiyati = nudFiyat.Value, HedefStokDuzeyi = (short)nudStok.Value, KategoriID = Convert.ToInt32(cmbKategori.SelectedValue), TedarikciID = Convert.ToInt32(cmbTedarikci.SelectedValue), BirimdekiMiktar = "" };

            bool sonuc = urunlerORM.Insert(urun);
            if (sonuc)
            {
                MessageBox.Show("Ürün Eklendi.");
                dataGridView1.DataSource = urunlerORM.Select();
            }
            else
                MessageBox.Show("Ürün eklenirken bir hata oluştu.");
        }
    }
}
