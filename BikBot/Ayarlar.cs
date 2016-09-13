using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BikBot.Model.DB;

namespace BikBot
{
    public partial class Ayarlar : Form
    {
        private bilgiler _bilgilers;

        public Ayarlar()
        {
            InitializeComponent();
        }

        private BikDBEntities BikModelEntities { get; } = new BikDBEntities();

        private void Form2_Load(object sender, EventArgs e)
        {
            Debug.Assert(_bilgilers == null, "_bilgilers null");
            _bilgilers = BikModelEntities.bilgiler.FirstOrDefaultAsync(i => i.id == 1).Result;
            rbKaynak.Checked = true;
            if (txbKAdi != null)
                txbKAdi.Text = _bilgilers.kAdi;
            if (txbSifre != null)
                txbSifre.Text = _bilgilers.sifre;
            if (txtMailAdresi != null)
                txtMailAdresi.Text = _bilgilers.ePosta;
            if (txbAlternatifMail != null)
                txbAlternatifMail.Text = _bilgilers.altEposta;
            if (rbKaynak.Checked)
            {
                txbDosyaYolu.Text = "";
                if (txbDosyaYolu != null)
                    txbDosyaYolu.Text = _bilgilers.dosyaYolu;
            }
            else if (rbTeamViewer.Checked)
            {
                if (txbDosyaYolu != null)
                    txbDosyaYolu.Text = _bilgilers.dosyaYoluTeam;
            }
            if (txbZaman != null)
                txbZaman.Text = _bilgilers.zaman;
            if (txbSirketAdi != null)
                txbSirketAdi.Text = _bilgilers.sirketAdi;

            cbMailBilgilendirme.CheckState = CheckState.Checked;

            var zamanTip = new ToolTip
            {
                ToolTipTitle = "Uyarı!",
                ToolTipIcon = ToolTipIcon.Info,
                BackColor = Color.CadetBlue,
                IsBalloon = true
            };
            zamanTip.SetToolTip(txbZaman, "1:00:00 şeklinde belirtmeniz gerekmektedir.");
        }

        private void btnDosyaYolu_Click(object sender, EventArgs e)
        {
            ofdDosyaYolu.Multiselect = false;
            ofdDosyaYolu.ShowDialog();

            foreach (var item in ofdDosyaYolu.FileNames)
            {
                txbDosyaYolu.Text += item;
            }

            ofdDosyaYolu.Dispose();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            BikModelEntities.Dispose();

            Copcu();
        }

        private async void btnEpostaKaydet_Click(object sender, EventArgs e)
        {
            var bilgilers = BikModelEntities.bilgiler.FirstOrDefault(i => i.id == 1);
            bilgilers.ePosta = txtMailAdresi.Text;
            bilgilers.altEposta = txbAlternatifMail.Text;

            await BikModelEntities.SaveChangesAsync();
        }

        private async void btnKBilgiKaydet_Click(object sender, EventArgs e)
        {
            var bilgilers = BikModelEntities.bilgiler.FirstOrDefault(i => i.id == 1);
            bilgilers.kAdi = txbKAdi.Text;
            bilgilers.sifre = txbSifre.Text;
            bilgilers.sirketAdi = txbSirketAdi.Text;
            await BikModelEntities.SaveChangesAsync();
        }

        private static void Copcu()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private async void btnDosyaYoluKaydet_Click(object sender, EventArgs e)
        {
            _bilgilers = BikModelEntities.bilgiler.FirstOrDefaultAsync(i => i.id == 1).Result;
            if (rbKaynak.Checked)
            {
                _bilgilers.dosyaYolu = txbDosyaYolu.Text;
                await BikModelEntities.SaveChangesAsync();
            }
            else if (rbTeamViewer.Checked)
            {
                _bilgilers.dosyaYoluTeam = txbDosyaYolu.Text;
                await BikModelEntities.SaveChangesAsync();
            }
            else
            {
                MessageBox.Show("Lütfen hangi dosya yolu olduğunu işaretleyerek belirtiniz", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private async void btnKaydet_Click(object sender, EventArgs e)
        {
            _bilgilers = BikModelEntities.bilgiler.FirstOrDefaultAsync(i => i.id == 1).Result;
            _bilgilers.zaman = txbZaman.Text;
            await BikModelEntities.SaveChangesAsync();
        }
    }
}