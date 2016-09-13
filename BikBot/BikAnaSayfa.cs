using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BikBot.Model.DB;

namespace BikBot
{
    public partial class BikAnaSayfa : Form
    {
        private readonly BikModel bik = new BikModel();

        public BikAnaSayfa()
        {
            InitializeComponent();
            timer1.Start(); // zaman belirleyici
            timer1.Interval = 1000;
            txbSirket.Text = BikModelEntities.bilgiler.FirstOrDefault(i => i.id == 1).sirketAdi;
        }

        private BikDBEntities BikModelEntities { get; } = new BikDBEntities();
        private Mail Mail1 { get; } = new Mail();
        public int Sayac { get; set; }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (bik.NetKontrol())
            {
                browser.Navigate(bik.LinkYukle("http://gazete.bik.gov.tr/")); //linke git
                browser.ScriptErrorsSuppressed = true; // scriptleri engelle
                //sayfanın yüklenmesini bekle
                while (browser.ReadyState != WebBrowserReadyState.Complete)
                {
                    Application.DoEvents();
                }

                //giriş butonuna tıklar (click eventına gider)
                btnGirisYap.PerformClick();
            }

            else
            {
                MessageBox.Show("İnternet Bağlantınızı Kontrol Ediniz", "HATA", MessageBoxButtons.RetryCancel,
                    MessageBoxIcon.Exclamation);
            }
            //Garbage Collector
            Copcu();
        }

        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            /* browser meşgul değilken 1 kereye mahsus döner 
             * Kullanıcı adı ve şifresini veritabanından alarak giriş yapmak üzere yerleştirir             
             */
            while (!browser.IsBusy && Sayac < 1)
            {
                Sayac++;
                var doc = browser.Document;
                var kAdi = doc.GetElementById("UserName");
                var pass = doc.GetElementById("Password");
                bik.OznitelikVerileri(kAdi, pass);
                //bik.Bilgiler();
                if (kAdi != null) kAdi.InnerText = BikModelEntities.bilgiler.FirstOrDefault()?.kAdi;
                if (pass != null) pass.InnerText = BikModelEntities.bilgiler.FirstOrDefault()?.sifre;
            }

            bik.ButonVeriYukleme(browser.Document?.GetElementsByTagName("button"));
            bik.ButonTiklama();
            Copcu();
        }

        private void btnYukle_Click(object sender, EventArgs e)
        {
            bik.ATagleriVeriYukleme(browser.Document?.GetElementsByTagName("a"));
            bik.ATagleriTiklama();
            Copcu();
        }

        private void btnTarihKontrol_Click(object sender, EventArgs e)
        {
            Copcu();
        }

        private void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (browser.DocumentTitle == "Ana Sayfa - İlan Bilgi Sistemi" && browser.StatusText == "Bitti")
            {
                textBox1.Text = browser.DocumentTitle;
                btnYukle.PerformClick();
            }
            else if (browser.DocumentTitle == "Baskı Yükle - İlan Bilgi Sistemi" && browser.StatusText == "Bitti")
            {
                textBox1.Text = browser.DocumentTitle;
                btnGazeteYukle.PerformClick();
            }
            Copcu();
        }

        private void btnGazeteYukle_Click(object sender, EventArgs e)
        {
            browser.DocumentCompleted -= browser_DocumentCompleted;
            Populate().ContinueWith(_ => { }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private async Task PopulateInputFile(HtmlElement dosya)
        {
            try
            {
                dosya.Focus();

                var sendKeyTask =
                    Task.Delay(1000)
                        .ContinueWith(
                            _ =>
                            {
                                SendKeys.Send(BikModelEntities.bilgiler.FirstOrDefault()?.dosyaYolu.ToLower() +
                                              "{ENTER}");
                            },
                            TaskScheduler.FromCurrentSynchronizationContext());
                await Task.Delay(500);
                dosya.InvokeMember("Click");

                await sendKeyTask;

                await Task.Delay(200000);

                var elements = browser.Document?.GetElementsByTagName("span");

                if (bik.TarihKontrol(elements[4].InnerHtml.Substring(0, 2)))
                {
                    if (browser.Document != null) browser.Document.GetElementById("kaydet")?.InvokeMember("Click");
                }

                await Task.Delay(100);

                if ((bool) BikModelEntities.bilgiler.FirstOrDefault(i => i.id == 1)?.mailGonderilsinmi)
                {
                    var firstOrDefault = BikModelEntities.bilgiler.FirstOrDefault();
                    if (firstOrDefault != null || firstOrDefault.mailGonderilsinmi != null ||
                        firstOrDefault.mailGonderilsinmi.Value)
                    {
                        var epostaBilgi = firstOrDefault.ePosta;
                        var altEpostaBilgi = firstOrDefault.altEposta;
                        Mail1.MailGonder(epostaBilgi);
                        Mail1.MailGonder(altEpostaBilgi);
                    }
                }
            }
            catch (Exception exception)
            {
                Process.Start(BikModelEntities.bilgiler.FirstOrDefaultAsync(i => i.id == 1).Result.dosyaYoluTeam);
                var hataMail = new Mail.HataMail();
                hataMail.MailGonder(exception.Message);
            }
            finally
            {
                Hide();
            }
        }

        private async Task Populate()
        {
            var elements = browser.Document?.GetElementsByTagName("input");
            foreach (HtmlElement file in elements)
            {
                if (file.GetAttribute("name") == "qqfile")
                {
                    file.Focus();
                    await PopulateInputFile(file);
                }
            }
        }

        private void ayarlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form2 = new Ayarlar();
            if (form2.Visible == false)
                form2.Show();
        }

        private static void Copcu()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
            {
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(500);
            }
            else if (FormWindowState.Normal == WindowState)
            {
                notifyIcon1.Visible = false;
            }
            else if (FormWindowState.Maximized == WindowState)
            {
                notifyIcon1.Visible = false;
            }
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void çıkışToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }

        private void ayarlarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form2 = new Ayarlar();
            form2.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("H:mm:ss");

            if (DateTime.Now.ToString("H:mm:ss") ==
                BikModelEntities.bilgiler.FirstOrDefaultAsync(i => i.id == 1).Result.zaman)
            {
                var path = Environment.CurrentDirectory;
                Application.ExitThread();
                Process.Start(path + "\\BikBot.exe");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void gizleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void gösterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Show();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose();
            GC.Collect();
        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bik.ShowPopup(
                "AYDINLIK BİLGİ İŞLEM SERVİSİ TARAFINDAN GELİŞTİRİLMİŞTİR.\n\nPROBLEM DAHİLİNDE İLETİŞİME GEÇİNİZ\n\nTÜM YASAL HAKLARI SAKLADIR",
                450, 125);
        }

        private void renkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dr = colorDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                // Set form background to the selected color.
                BackColor = colorDialog1.Color;
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dr = fontDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                Font = fontDialog1.Font;
                BikModelEntities.gorunum.FirstOrDefaultAsync(i => i.id == 1).Result.font = fontDialog1.Font.ToString();
            }
        }

        private void ekranGörüntüsüÇekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Screenshot = new Bitmap(Width, Height);

            // bitmapten grafik nesnesi oluştur
            var GFX = Graphics.FromImage(Screenshot);

            // ekrandan programın bulunduğu konumun resmini alalım
            GFX.CopyFromScreen(Left, Top, 0, 0, Size);

            Screenshot.Save(Environment.CurrentDirectory + "\\hata.jpg");
            Mail1.MailBit();
            bik.ShowPopup("Bilgilendirme için teşekkürler.\n\nEn kısa sürede iletişime geçilecektir.", 300, 100);
        }

        private void BikAnaSayfa_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void kaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BikModelEntities.gorunum.FirstOrDefault().renk = BackColor.Name;
        }

        private void yenidenBaşlatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
            Process.Start(Environment.CurrentDirectory + "\\BikBot.exe");
            Task.Delay(500);
            Dispose();
            Copcu();
        }
    }
}