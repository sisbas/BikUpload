using System;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;
using BikBot.Model.DB;

namespace BikBot
{
    public class Mail
    {
        private readonly BikDBEntities bikModelEntities = new BikDBEntities();
        private string _gonderen;
        private string _gonderilecekMail;
        private string _sifre;

        public string Gonderen
        {
            get { return _gonderen; }
            set
            {
                if (_gonderen == null)
                {
                    _gonderen = value;
                }
            }
        }

        public string Sifre
        {
            get { return _sifre; }
            set
            {
                if (_sifre == null)
                {
                    _sifre = value;
                }
            }
        }

        public string GonderilecekMail
        {
            get { return _gonderilecekMail; }
            set
            {
                if (_gonderilecekMail == null)
                {
                    _gonderilecekMail = value;
                }
            }
        }

        public string MacAddres { get; set; }

        public string IpAdres { get; set; }

        public async Task MailBilgiler()
        {
            using (var db = new BikDBEntities())
            {
                if (db.bilgiler != null)
                {
                    GonderilecekMail = db.bilgiler.FirstOrDefaultAsync(i => i.id == 1).Result.ePosta;
                    Gonderen = db.bilgiler.FirstOrDefaultAsync(i => i.id == 1).Result.gonderen;
                    Sifre = db.bilgiler.FirstOrDefaultAsync(i => i.id == 1).Result.gonderenSifre;
                }
            }
        }

        public virtual async void MailGonder(string gonderilecekMail)
        {
            try
            {
                await MailBilgiler();
                var client = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(_gonderen, _sifre),
                    //Credentials = new System.Net.NetworkCredential("basinilanbilgilendirme@gmail.com", "mkeff2346"),
                    Timeout = 10000
                };
                var mm = new MailMessage(_gonderen, gonderilecekMail, "Bik",
                    "İşlem başarıyla gerçekleştirilmiştir.");
                client.Send(mm);
            }
            catch (Exception e)
            {
                MessageBox.Show("MAİL GÖNDERİLEMEDİ" + e.Message);
            }
        }

        ~Mail()
        {
            Debug.Print("Destructor");
        }

        public async void MailBit()
        {
            await MailBilgiler();
            await GetMACAddress();
            var mail = new MailMessage();
            var SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("basinilanhata@gmail.com");
            mail.To.Add(_gonderen);
            mail.Subject = "Hata Bildirimi";
            mail.Body = "Ekran Görüntüsü Ektedir" + "\n" + MacAddres + "\n" + IpAdres;

            Attachment attachment;
            attachment = new Attachment(Environment.CurrentDirectory + "\\hata.jpg");
            mail.Attachments.Add(attachment);

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new NetworkCredential("basinilanhata@gmail.com", _sifre);
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
        }

        public async Task GetMACAddress()
        {
            var nics = NetworkInterface.GetAllNetworkInterfaces();
            var sMacAddress = string.Empty;
            foreach (var adapter in nics)
            {
                if (sMacAddress == string.Empty) // only return MAC Address from first card  
                {
                    //IPInterfaceProperties properties = adapter.GetIPProperties(); Line is not required
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            }
            MacAddres = sMacAddress;
            IpAdres = Dns.GetHostEntry(Dns.GetHostName())
                .AddressList
                .First(f => f.AddressFamily == AddressFamily.InterNetwork)
                .ToString();
        }

        public class HataMail : Mail
        {
            private string _body { get; set; }

            public string Body
            {
                get { return _body; }
                set
                {
                    if (_body != null)
                    {
                        _body = value;
                    }
                }
            }

            public override async void MailGonder(string body)
            {
                _body = body;
                await MailBilgiler();
                try
                {
                    var client = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        Credentials = new NetworkCredential(_gonderen, _sifre),
                        Timeout = 10000
                    };
                    var mm = new MailMessage(_gonderen, _gonderilecekMail, "Bik",
                        _body);
                    client.Send(mm);
                }
                catch (Exception e)
                {
                    MessageBox.Show("MAİL GÖNDERİLEMEDİ" + e.Message);
                }
            }
        }
    }
}