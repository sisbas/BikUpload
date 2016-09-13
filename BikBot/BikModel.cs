using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using BikBot.Model.DB;

namespace BikBot
{
    public class BikModel
    {
        private readonly BikDBEntities BikModelEntities = new BikDBEntities();
        private readonly Mail hataMail = new Mail.HataMail();
        private BikDBEntities bikModelEntities = new BikDBEntities();
        private HtmlElement _kullaniciID { get; set; }
        private HtmlElement _passwordID { get; set; }
        //private string _kullaniciAdi { get; set; }
        //private string _sifre { get; set; }
        private string _link { get; set; }
        private string _tarih { get; set; }
        private HtmlElementCollection _butonlar { get; set; }
        private HtmlElementCollection _aTaglari { get; set; }
        private HtmlElementCollection _h1Tagleri { get; set; }
        private HtmlElementCollection _inputTagleri { get; set; }

        public HtmlElement KullaniciID
        {
            get { return _kullaniciID; }
            set { _kullaniciID = value; }
        }

        public HtmlElement PasswordID
        {
            get { return _passwordID; }
            set { _passwordID = value; }
        }

        public string Link
        {
            get { return _link; }
            set { _link = value; }
        }

        //public string KullaniciAdi
        //{
        //    get { return _kullaniciAdi; }
        //    set { _kullaniciAdi = value; }
        //}

        //public string Sifre
        //{
        //    get { return _sifre; }
        //    set { _sifre = value; }
        //}

        public string Tarih
        {
            get { return _tarih; }
            set { _tarih = value; }
        }

        public string LinkYukle(string link)
        {
            Link = link;
            return link;
        }

        public void OznitelikVerileri(HtmlElement kID, HtmlElement passID)
        {
            KullaniciID = kID;
            PasswordID = passID;
        }

        //internal void Bilgiler()
        //{
        //    KullaniciAdi = "Y000065-1";
        //    Sifre = "İya75Cov+-";
        //}

        public void ButonVeriYukleme(HtmlElementCollection btnCollection)
        {
            _butonlar = btnCollection;
        }

        public void ATagleriVeriYukleme(HtmlElementCollection aCollection)
        {
            _aTaglari = aCollection;
        }

        public void BrTagleriVeriYukleme(HtmlElementCollection brCollection)
        {
            _h1Tagleri = brCollection;
        }

        public void InputTagleriVeriYukleme(HtmlElementCollection inputCollection)
        {
            _inputTagleri = inputCollection;
        }

        public bool TarihKontrol(string tagTarih)
        {
            var yarin = DateTime.Today.Day + 1;
            if (tagTarih != yarin.ToString().Substring(0, 2))
            {
                hataMail.MailGonder("TARİH UYUŞMUYOR LÜTFEN KONTROL EDİNİZ");
                Process.Start(BikModelEntities.bilgiler.FirstOrDefaultAsync(i => i.id == 1).Result.dosyaYoluTeam);
                MessageBox.Show("Tarih Uyuşmuyor. Lütfen iletişime geçiniz!", "TARİH HATASI", MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);
                return false;
            }
            Tarih = DateTime.Today.AddDays(1).ToString().Substring(0, 10);
            return true;
        }

        public void ButonTiklama()
        {
            try
            {
                _butonlar[0].InvokeMember("Click");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ATagleriTiklama()
        {
            try
            {
                _aTaglari[2].InvokeMember("Click");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string BrVeriCekme()
        {
            try
            {
                _h1Tagleri[1].InnerText.Substring(0, 2);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return _h1Tagleri[1].InnerText.Substring(0, 2);
        }

        public void InputTagleriTiklama()
        {
            try
            {
                _inputTagleri[1].InvokeMember("Click");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString(), "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool NetKontrol()
        {
            return new Ping().Send("www.google.com", 1000).Status == IPStatus.Success;
        }

        public void ShowPopup(string text, int width, int height)
        {
            // Popup adında bir form oluştur
            var Popup = new Form
            {
                Width = width, // genişlik parametresini ata
                Height = height, // yükseklik parametresini ata
                ShowInTaskbar = false, // başlat çubuğunda görünme
                FormBorderStyle = FormBorderStyle.None, // Form kenarlıkları olmasın
                BackColor = Color.Coral, // Arkaplan "Mısır çiçeği mavisi" rengi
                StartPosition = FormStartPosition.CenterParent, // Formu ekrana ortala
                TopMost = true, // Her zaman üstte
                Cursor = Cursors.Hand // İmleç, el şeklinde olsun
            };

            // Form click eventi
            Popup.Click += delegate
            {
                Debug.Assert(Popup != null, "Popup != null");
                Popup.Dispose(); // tıklanıldığında formu kapat
            };

            // Form içi grafik işlemleri
            Popup.Paint += delegate
            {
                // Formun etrafına bir dörtgen çiz (Rengi siyah = Pens.Black)
                Popup.CreateGraphics().DrawRectangle(Pens.AliceBlue, 2, -2, width, height);
            };

            // lbl_text adında bir label oluştur
            var lbl_text = new Label
            {
                Left = 25, // sol tarafa uzaklık 30 pixel
                Top = 25, // yukarıya uzaklık 30 pixel
                AutoSize = true, // label boyutunu text'e göre  ayarla
                Font = new Font(Popup.Font, FontStyle.Bold), // font kalın olsun
                Text = text // metin parametresini ata
            };

            var txbSirket = new TextBox
            {
                Left = 25,
                Top = 25,
                AutoSize = true,
                Font = new Font(Popup.Font, FontStyle.Bold)
            };

            // oluşturulan labeli forma ekle
            Popup.Controls.Add(lbl_text);

            // pop-up formu göster
            Popup.ShowDialog();
        }

        ~BikModel()
        {
            Debug.Print("Destructor");
        }
    }
}