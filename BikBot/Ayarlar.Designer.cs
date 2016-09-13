namespace BikBot
{
    partial class Ayarlar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ayarlar));
            this.gbEposta = new System.Windows.Forms.GroupBox();
            this.btnEpostaKaydet = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txbAlternatifMail = new System.Windows.Forms.TextBox();
            this.cbMailBilgilendirme = new System.Windows.Forms.CheckBox();
            this.lblGonderilecekAdres = new System.Windows.Forms.Label();
            this.txtMailAdresi = new System.Windows.Forms.TextBox();
            this.gbKullanici = new System.Windows.Forms.GroupBox();
            this.btnKBilgiKaydet = new System.Windows.Forms.Button();
            this.txbSifre = new System.Windows.Forms.TextBox();
            this.txbKAdi = new System.Windows.Forms.TextBox();
            this.lblSifre = new System.Windows.Forms.Label();
            this.lblKullaniciAdi = new System.Windows.Forms.Label();
            this.gbKlasor = new System.Windows.Forms.GroupBox();
            this.rbTeamViewer = new System.Windows.Forms.RadioButton();
            this.rbKaynak = new System.Windows.Forms.RadioButton();
            this.btnDosyaYoluKaydet = new System.Windows.Forms.Button();
            this.btnDosyaYolu = new System.Windows.Forms.Button();
            this.txbDosyaYolu = new System.Windows.Forms.TextBox();
            this.lblDosya = new System.Windows.Forms.Label();
            this.ofdDosyaYolu = new System.Windows.Forms.OpenFileDialog();
            this.gbZaman = new System.Windows.Forms.GroupBox();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.lblZaman = new System.Windows.Forms.Label();
            this.txbZaman = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.txbSirketAdi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gbEposta.SuspendLayout();
            this.gbKullanici.SuspendLayout();
            this.gbKlasor.SuspendLayout();
            this.gbZaman.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbEposta
            // 
            this.gbEposta.Controls.Add(this.btnEpostaKaydet);
            this.gbEposta.Controls.Add(this.label1);
            this.gbEposta.Controls.Add(this.txbAlternatifMail);
            this.gbEposta.Controls.Add(this.cbMailBilgilendirme);
            this.gbEposta.Controls.Add(this.lblGonderilecekAdres);
            this.gbEposta.Controls.Add(this.txtMailAdresi);
            resources.ApplyResources(this.gbEposta, "gbEposta");
            this.gbEposta.Name = "gbEposta";
            this.gbEposta.TabStop = false;
            // 
            // btnEpostaKaydet
            // 
            resources.ApplyResources(this.btnEpostaKaydet, "btnEpostaKaydet");
            this.btnEpostaKaydet.Name = "btnEpostaKaydet";
            this.btnEpostaKaydet.TabStop = false;
            this.btnEpostaKaydet.UseVisualStyleBackColor = true;
            this.btnEpostaKaydet.Click += new System.EventHandler(this.btnEpostaKaydet_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // txbAlternatifMail
            // 
            resources.ApplyResources(this.txbAlternatifMail, "txbAlternatifMail");
            this.txbAlternatifMail.Name = "txbAlternatifMail";
            this.txbAlternatifMail.TabStop = false;
            // 
            // cbMailBilgilendirme
            // 
            resources.ApplyResources(this.cbMailBilgilendirme, "cbMailBilgilendirme");
            this.cbMailBilgilendirme.Name = "cbMailBilgilendirme";
            this.cbMailBilgilendirme.TabStop = false;
            this.cbMailBilgilendirme.UseVisualStyleBackColor = true;
            // 
            // lblGonderilecekAdres
            // 
            resources.ApplyResources(this.lblGonderilecekAdres, "lblGonderilecekAdres");
            this.lblGonderilecekAdres.Name = "lblGonderilecekAdres";
            // 
            // txtMailAdresi
            // 
            resources.ApplyResources(this.txtMailAdresi, "txtMailAdresi");
            this.txtMailAdresi.Name = "txtMailAdresi";
            this.txtMailAdresi.TabStop = false;
            // 
            // gbKullanici
            // 
            this.gbKullanici.Controls.Add(this.label2);
            this.gbKullanici.Controls.Add(this.txbSirketAdi);
            this.gbKullanici.Controls.Add(this.btnKBilgiKaydet);
            this.gbKullanici.Controls.Add(this.txbSifre);
            this.gbKullanici.Controls.Add(this.txbKAdi);
            this.gbKullanici.Controls.Add(this.lblSifre);
            this.gbKullanici.Controls.Add(this.lblKullaniciAdi);
            resources.ApplyResources(this.gbKullanici, "gbKullanici");
            this.gbKullanici.Name = "gbKullanici";
            this.gbKullanici.TabStop = false;
            // 
            // btnKBilgiKaydet
            // 
            resources.ApplyResources(this.btnKBilgiKaydet, "btnKBilgiKaydet");
            this.btnKBilgiKaydet.Name = "btnKBilgiKaydet";
            this.btnKBilgiKaydet.TabStop = false;
            this.btnKBilgiKaydet.UseVisualStyleBackColor = true;
            this.btnKBilgiKaydet.Click += new System.EventHandler(this.btnKBilgiKaydet_Click);
            // 
            // txbSifre
            // 
            resources.ApplyResources(this.txbSifre, "txbSifre");
            this.txbSifre.Name = "txbSifre";
            this.txbSifre.TabStop = false;
            // 
            // txbKAdi
            // 
            resources.ApplyResources(this.txbKAdi, "txbKAdi");
            this.txbKAdi.Name = "txbKAdi";
            this.txbKAdi.TabStop = false;
            // 
            // lblSifre
            // 
            resources.ApplyResources(this.lblSifre, "lblSifre");
            this.lblSifre.Name = "lblSifre";
            // 
            // lblKullaniciAdi
            // 
            resources.ApplyResources(this.lblKullaniciAdi, "lblKullaniciAdi");
            this.lblKullaniciAdi.Name = "lblKullaniciAdi";
            // 
            // gbKlasor
            // 
            this.gbKlasor.Controls.Add(this.rbTeamViewer);
            this.gbKlasor.Controls.Add(this.rbKaynak);
            this.gbKlasor.Controls.Add(this.btnDosyaYoluKaydet);
            this.gbKlasor.Controls.Add(this.btnDosyaYolu);
            this.gbKlasor.Controls.Add(this.txbDosyaYolu);
            this.gbKlasor.Controls.Add(this.lblDosya);
            resources.ApplyResources(this.gbKlasor, "gbKlasor");
            this.gbKlasor.Name = "gbKlasor";
            this.gbKlasor.TabStop = false;
            // 
            // rbTeamViewer
            // 
            resources.ApplyResources(this.rbTeamViewer, "rbTeamViewer");
            this.rbTeamViewer.Name = "rbTeamViewer";
            this.rbTeamViewer.TabStop = true;
            this.rbTeamViewer.UseVisualStyleBackColor = true;
            // 
            // rbKaynak
            // 
            resources.ApplyResources(this.rbKaynak, "rbKaynak");
            this.rbKaynak.Name = "rbKaynak";
            this.rbKaynak.TabStop = true;
            this.rbKaynak.UseVisualStyleBackColor = true;
            // 
            // btnDosyaYoluKaydet
            // 
            resources.ApplyResources(this.btnDosyaYoluKaydet, "btnDosyaYoluKaydet");
            this.btnDosyaYoluKaydet.Name = "btnDosyaYoluKaydet";
            this.btnDosyaYoluKaydet.TabStop = false;
            this.btnDosyaYoluKaydet.UseVisualStyleBackColor = true;
            this.btnDosyaYoluKaydet.Click += new System.EventHandler(this.btnDosyaYoluKaydet_Click);
            // 
            // btnDosyaYolu
            // 
            resources.ApplyResources(this.btnDosyaYolu, "btnDosyaYolu");
            this.btnDosyaYolu.Name = "btnDosyaYolu";
            this.btnDosyaYolu.TabStop = false;
            this.btnDosyaYolu.UseVisualStyleBackColor = true;
            this.btnDosyaYolu.Click += new System.EventHandler(this.btnDosyaYolu_Click);
            // 
            // txbDosyaYolu
            // 
            resources.ApplyResources(this.txbDosyaYolu, "txbDosyaYolu");
            this.txbDosyaYolu.Name = "txbDosyaYolu";
            this.txbDosyaYolu.TabStop = false;
            // 
            // lblDosya
            // 
            resources.ApplyResources(this.lblDosya, "lblDosya");
            this.lblDosya.Name = "lblDosya";
            // 
            // ofdDosyaYolu
            // 
            this.ofdDosyaYolu.FileName = "default";
            resources.ApplyResources(this.ofdDosyaYolu, "ofdDosyaYolu");
            // 
            // gbZaman
            // 
            this.gbZaman.Controls.Add(this.btnKaydet);
            this.gbZaman.Controls.Add(this.lblZaman);
            this.gbZaman.Controls.Add(this.txbZaman);
            resources.ApplyResources(this.gbZaman, "gbZaman");
            this.gbZaman.Name = "gbZaman";
            this.gbZaman.TabStop = false;
            // 
            // btnKaydet
            // 
            resources.ApplyResources(this.btnKaydet, "btnKaydet");
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // lblZaman
            // 
            resources.ApplyResources(this.lblZaman, "lblZaman");
            this.lblZaman.Name = "lblZaman";
            // 
            // txbZaman
            // 
            resources.ApplyResources(this.txbZaman, "txbZaman");
            this.txbZaman.Name = "txbZaman";
            this.txbZaman.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txbSirketAdi
            // 
            resources.ApplyResources(this.txbSirketAdi, "txbSirketAdi");
            this.txbSirketAdi.Name = "txbSirketAdi";
            this.txbSirketAdi.TabStop = false;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // Ayarlar
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbZaman);
            this.Controls.Add(this.gbKlasor);
            this.Controls.Add(this.gbKullanici);
            this.Controls.Add(this.gbEposta);
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Ayarlar";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.gbEposta.ResumeLayout(false);
            this.gbEposta.PerformLayout();
            this.gbKullanici.ResumeLayout(false);
            this.gbKullanici.PerformLayout();
            this.gbKlasor.ResumeLayout(false);
            this.gbKlasor.PerformLayout();
            this.gbZaman.ResumeLayout(false);
            this.gbZaman.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gbEposta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbAlternatifMail;
        private System.Windows.Forms.CheckBox cbMailBilgilendirme;
        private System.Windows.Forms.Label lblGonderilecekAdres;
        private System.Windows.Forms.TextBox txtMailAdresi;
        private System.Windows.Forms.GroupBox gbKullanici;
        private System.Windows.Forms.TextBox txbKAdi;
        private System.Windows.Forms.Label lblSifre;
        private System.Windows.Forms.Label lblKullaniciAdi;
        private System.Windows.Forms.TextBox txbSifre;
        private System.Windows.Forms.Button btnEpostaKaydet;
        private System.Windows.Forms.Button btnKBilgiKaydet;
        private System.Windows.Forms.GroupBox gbKlasor;
        private System.Windows.Forms.TextBox txbDosyaYolu;
        private System.Windows.Forms.Label lblDosya;
        private System.Windows.Forms.OpenFileDialog ofdDosyaYolu;
        private System.Windows.Forms.Button btnDosyaYolu;
        private System.Windows.Forms.Button btnDosyaYoluKaydet;
        private System.Windows.Forms.RadioButton rbTeamViewer;
        private System.Windows.Forms.RadioButton rbKaynak;
        private System.Windows.Forms.GroupBox gbZaman;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblZaman;
        private System.Windows.Forms.TextBox txbZaman;
        private System.Windows.Forms.Button btnKaydet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbSirketAdi;
    }
}