﻿namespace ATİÇAY3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            statusStrip1 = new StatusStrip();
            uactext = new ToolStripStatusLabel();
            antiatakkurProgress = new ToolStripProgressBar();
            groupBox1 = new GroupBox();
            groupBox6 = new GroupBox();
            autorunAktiflestir = new Button();
            restartexplorer = new Button();
            GizliDosyalariGoster = new Button();
            DosyalariGizle = new Button();
            groupBox5 = new GroupBox();
            GorevYoneticisiniDevredisiBirak = new Button();
            GorevYoneticisiniBaslat = new Button();
            GorevYoneticisiniAktiflesir = new Button();
            yoneticiAl = new Button();
            groupBox2 = new GroupBox();
            button2 = new Button();
            getKeyFile = new Button();
            ccebar = new ProgressBar();
            CCeIndir = new Button();
            groupBox7 = new GroupBox();
            label5 = new Label();
            label3 = new Label();
            AntiAtakKaldir = new Button();
            AntiAtakKur = new Button();
            themebutton = new Button();
            label1 = new Label();
            gorevdurum = new Label();
            servisatakDurum = new Label();
            groupBox3 = new GroupBox();
            groupBox4 = new GroupBox();
            antiatakkurulumyolu = new Label();
            label4 = new Label();
            antiAtakDurum = new Label();
            label2 = new Label();
            logboxtemizle = new Button();
            ytuyari = new Label();
            groupBox8 = new GroupBox();
            label7 = new Label();
            label6 = new Label();
            label9 = new Label();
            logbox = new Label();
            pxbox = new GroupBox();
            label8 = new Label();
            statusStrip1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox7.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox8.SuspendLayout();
            pxbox.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { uactext, antiatakkurProgress });
            statusStrip1.Location = new Point(0, 639);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.RightToLeft = RightToLeft.Yes;
            statusStrip1.Size = new Size(1244, 26);
            statusStrip1.TabIndex = 2;
            statusStrip1.Text = "statusStrip1";
            // 
            // uactext
            // 
            uactext.Name = "uactext";
            uactext.Size = new Size(239, 20);
            uactext.Text = "Atiçay [ATDURUM] Olarak çalışıyor";
            // 
            // antiatakkurProgress
            // 
            antiatakkurProgress.MarqueeAnimationSpeed = 3;
            antiatakkurProgress.Name = "antiatakkurProgress";
            antiatakkurProgress.Size = new Size(1000, 17);
            antiatakkurProgress.Step = 25;
            antiatakkurProgress.Style = ProgressBarStyle.Marquee;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(groupBox6);
            groupBox1.Controls.Add(groupBox5);
            groupBox1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.ForeColor = SystemColors.ControlText;
            groupBox1.Location = new Point(12, 11);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(250, 612);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Windows İnce Ayar";
            groupBox1.Visible = false;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(autorunAktiflestir);
            groupBox6.Controls.Add(restartexplorer);
            groupBox6.Controls.Add(GizliDosyalariGoster);
            groupBox6.Controls.Add(DosyalariGizle);
            groupBox6.Location = new Point(0, 279);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(238, 332);
            groupBox6.TabIndex = 9;
            groupBox6.TabStop = false;
            groupBox6.Text = "Windows Gezgini Ayarları";
            // 
            // autorunAktiflestir
            // 
            autorunAktiflestir.BackColor = Color.LightBlue;
            autorunAktiflestir.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            autorunAktiflestir.ForeColor = SystemColors.ControlText;
            autorunAktiflestir.Location = new Point(16, 250);
            autorunAktiflestir.Name = "autorunAktiflestir";
            autorunAktiflestir.Size = new Size(207, 69);
            autorunAktiflestir.TabIndex = 4;
            autorunAktiflestir.Text = "AutoRun Aktifleştir";
            autorunAktiflestir.UseVisualStyleBackColor = false;
            autorunAktiflestir.Click += autorunAktiflestir_Click;
            // 
            // restartexplorer
            // 
            restartexplorer.BackColor = Color.Yellow;
            restartexplorer.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            restartexplorer.ForeColor = SystemColors.ControlText;
            restartexplorer.Location = new Point(16, 176);
            restartexplorer.Name = "restartexplorer";
            restartexplorer.Size = new Size(207, 68);
            restartexplorer.TabIndex = 3;
            restartexplorer.Text = "Windows Gezginini Yeniden Başlat";
            restartexplorer.UseVisualStyleBackColor = false;
            restartexplorer.Click += button6_Click;
            // 
            // GizliDosyalariGoster
            // 
            GizliDosyalariGoster.BackColor = Color.PaleGreen;
            GizliDosyalariGoster.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            GizliDosyalariGoster.ForeColor = SystemColors.ControlText;
            GizliDosyalariGoster.Location = new Point(16, 28);
            GizliDosyalariGoster.Name = "GizliDosyalariGoster";
            GizliDosyalariGoster.Size = new Size(207, 68);
            GizliDosyalariGoster.TabIndex = 2;
            GizliDosyalariGoster.Text = "Gizli Dosyaları Göster\r\n[ÖNERİLİR]";
            GizliDosyalariGoster.UseVisualStyleBackColor = false;
            GizliDosyalariGoster.Click += GizliDosyalariGoster_Click;
            // 
            // DosyalariGizle
            // 
            DosyalariGizle.BackColor = Color.LightCoral;
            DosyalariGizle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            DosyalariGizle.ForeColor = SystemColors.ControlText;
            DosyalariGizle.Location = new Point(16, 102);
            DosyalariGizle.Name = "DosyalariGizle";
            DosyalariGizle.Size = new Size(207, 68);
            DosyalariGizle.TabIndex = 0;
            DosyalariGizle.Text = "Gizli Dosyaları Gösterme\r\n";
            DosyalariGizle.UseVisualStyleBackColor = false;
            DosyalariGizle.Click += button1_Click;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(GorevYoneticisiniDevredisiBirak);
            groupBox5.Controls.Add(GorevYoneticisiniBaslat);
            groupBox5.Controls.Add(GorevYoneticisiniAktiflesir);
            groupBox5.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox5.Location = new Point(0, 28);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(238, 256);
            groupBox5.TabIndex = 8;
            groupBox5.TabStop = false;
            groupBox5.Text = "Görev Yöneticisi";
            // 
            // GorevYoneticisiniDevredisiBirak
            // 
            GorevYoneticisiniDevredisiBirak.BackColor = Color.LightCoral;
            GorevYoneticisiniDevredisiBirak.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            GorevYoneticisiniDevredisiBirak.ForeColor = SystemColors.ControlText;
            GorevYoneticisiniDevredisiBirak.Location = new Point(16, 173);
            GorevYoneticisiniDevredisiBirak.Name = "GorevYoneticisiniDevredisiBirak";
            GorevYoneticisiniDevredisiBirak.Size = new Size(207, 68);
            GorevYoneticisiniDevredisiBirak.TabIndex = 3;
            GorevYoneticisiniDevredisiBirak.Text = "Görev Yöneticisini Devredışı Bırak\r\n";
            GorevYoneticisiniDevredisiBirak.UseVisualStyleBackColor = false;
            GorevYoneticisiniDevredisiBirak.Click += GorevYoneticisiniDevredisiBirak_Click;
            // 
            // GorevYoneticisiniBaslat
            // 
            GorevYoneticisiniBaslat.BackColor = Color.Yellow;
            GorevYoneticisiniBaslat.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            GorevYoneticisiniBaslat.ForeColor = SystemColors.ControlText;
            GorevYoneticisiniBaslat.Location = new Point(16, 99);
            GorevYoneticisiniBaslat.Name = "GorevYoneticisiniBaslat";
            GorevYoneticisiniBaslat.Size = new Size(207, 68);
            GorevYoneticisiniBaslat.TabIndex = 2;
            GorevYoneticisiniBaslat.Text = "Görev Yöneticisini Başlat";
            GorevYoneticisiniBaslat.UseVisualStyleBackColor = false;
            GorevYoneticisiniBaslat.Click += GorevYoneticisiniBaslat_Click;
            // 
            // GorevYoneticisiniAktiflesir
            // 
            GorevYoneticisiniAktiflesir.BackColor = Color.PaleGreen;
            GorevYoneticisiniAktiflesir.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            GorevYoneticisiniAktiflesir.ForeColor = SystemColors.ControlText;
            GorevYoneticisiniAktiflesir.Location = new Point(16, 25);
            GorevYoneticisiniAktiflesir.Name = "GorevYoneticisiniAktiflesir";
            GorevYoneticisiniAktiflesir.Size = new Size(207, 68);
            GorevYoneticisiniAktiflesir.TabIndex = 1;
            GorevYoneticisiniAktiflesir.Text = "Görev Yöneticisini Aktifleştir";
            GorevYoneticisiniAktiflesir.UseVisualStyleBackColor = false;
            GorevYoneticisiniAktiflesir.Click += GorevYoneticisiniAktiflesir_Click;
            // 
            // yoneticiAl
            // 
            yoneticiAl.BackColor = Color.Chartreuse;
            yoneticiAl.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            yoneticiAl.Location = new Point(314, 64);
            yoneticiAl.Name = "yoneticiAl";
            yoneticiAl.Size = new Size(617, 128);
            yoneticiAl.TabIndex = 7;
            yoneticiAl.Text = "Yönetici Olarak Yeniden Başlat [GEREKLİ]";
            yoneticiAl.UseVisualStyleBackColor = false;
            yoneticiAl.Click += yoneticiAl_Click;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.Transparent;
            groupBox2.Controls.Add(button2);
            groupBox2.Controls.Add(getKeyFile);
            groupBox2.Controls.Add(ccebar);
            groupBox2.Controls.Add(CCeIndir);
            groupBox2.Controls.Add(groupBox7);
            groupBox2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox2.ForeColor = SystemColors.ControlText;
            groupBox2.Location = new Point(982, 11);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(250, 612);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Araç Kutusu";
            groupBox2.Visible = false;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            button2.ForeColor = Color.Blue;
            button2.Location = new Point(156, 0);
            button2.Name = "button2";
            button2.Size = new Size(94, 30);
            button2.TabIndex = 13;
            button2.Text = "Yardım";
            button2.TextAlign = ContentAlignment.TopCenter;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // getKeyFile
            // 
            getKeyFile.BackColor = SystemColors.ControlDarkDark;
            getKeyFile.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            getKeyFile.ForeColor = SystemColors.ControlLightLight;
            getKeyFile.Location = new Point(6, 425);
            getKeyFile.Name = "getKeyFile";
            getKeyFile.Size = new Size(238, 93);
            getKeyFile.TabIndex = 12;
            getKeyFile.Text = "Anahtar Kodu Masaüstüne Çıkart [Deneysel]";
            getKeyFile.UseVisualStyleBackColor = false;
            getKeyFile.Click += button2_Click;
            // 
            // ccebar
            // 
            ccebar.Location = new Point(41, 577);
            ccebar.Name = "ccebar";
            ccebar.Size = new Size(159, 10);
            ccebar.Step = 25;
            ccebar.TabIndex = 11;
            ccebar.Visible = false;
            // 
            // CCeIndir
            // 
            CCeIndir.BackColor = Color.AntiqueWhite;
            CCeIndir.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            CCeIndir.ForeColor = SystemColors.ControlText;
            CCeIndir.Location = new Point(6, 529);
            CCeIndir.Name = "CCeIndir";
            CCeIndir.Size = new Size(238, 69);
            CCeIndir.TabIndex = 10;
            CCeIndir.Text = "CCex64 Kur";
            CCeIndir.UseVisualStyleBackColor = false;
            CCeIndir.Click += CCeIndir_Click;
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(label5);
            groupBox7.Controls.Add(label3);
            groupBox7.Controls.Add(AntiAtakKaldir);
            groupBox7.Controls.Add(AntiAtakKur);
            groupBox7.Location = new Point(12, 28);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(238, 285);
            groupBox7.TabIndex = 9;
            groupBox7.TabStop = false;
            groupBox7.Text = "AntiATAK ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(5, 235);
            label5.Name = "label5";
            label5.Size = new Size(218, 40);
            label5.TabIndex = 3;
            label5.Text = "AntiATAK çözümünü sistemden \r\nkaldırlır\r\n";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(5, 96);
            label3.Name = "label3";
            label3.Size = new Size(227, 40);
            label3.TabIndex = 2;
            label3.Text = "Sistemde A.T.A.K tertibatını\r\nengelleyecek düzenlemeyi yapar.\r\n";
            // 
            // AntiAtakKaldir
            // 
            AntiAtakKaldir.BackColor = Color.Violet;
            AntiAtakKaldir.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            AntiAtakKaldir.ForeColor = SystemColors.Desktop;
            AntiAtakKaldir.Location = new Point(16, 152);
            AntiAtakKaldir.Name = "AntiAtakKaldir";
            AntiAtakKaldir.Size = new Size(207, 68);
            AntiAtakKaldir.TabIndex = 1;
            AntiAtakKaldir.Text = "AntiATAK Kaldır";
            AntiAtakKaldir.UseVisualStyleBackColor = false;
            AntiAtakKaldir.Click += AntiAtakKaldir_Click;
            // 
            // AntiAtakKur
            // 
            AntiAtakKur.BackColor = Color.Aquamarine;
            AntiAtakKur.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            AntiAtakKur.ForeColor = SystemColors.ControlText;
            AntiAtakKur.Location = new Point(16, 25);
            AntiAtakKur.Name = "AntiAtakKur";
            AntiAtakKur.Size = new Size(207, 68);
            AntiAtakKur.TabIndex = 1;
            AntiAtakKur.Text = "AntiATAK Kur";
            AntiAtakKur.UseVisualStyleBackColor = false;
            AntiAtakKur.Click += AntiAtakKur_Click;
            // 
            // themebutton
            // 
            themebutton.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            themebutton.Location = new Point(579, 77);
            themebutton.Name = "themebutton";
            themebutton.Size = new Size(121, 28);
            themebutton.TabIndex = 15;
            themebutton.Text = "Temayı Değiştir";
            themebutton.UseVisualStyleBackColor = true;
            themebutton.Click += button4_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(8, 22);
            label1.Name = "label1";
            label1.Size = new Size(170, 90);
            label1.TabIndex = 5;
            label1.Text = "Görev Yöneticisi :\r\nservisatk durum :\r\n\r\n";
            // 
            // gorevdurum
            // 
            gorevdurum.AutoSize = true;
            gorevdurum.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            gorevdurum.Location = new Point(199, 21);
            gorevdurum.Name = "gorevdurum";
            gorevdurum.Size = new Size(155, 30);
            gorevdurum.TabIndex = 6;
            gorevdurum.Text = "Yönetici Durum";
            // 
            // servisatakDurum
            // 
            servisatakDurum.AutoSize = true;
            servisatakDurum.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            servisatakDurum.Location = new Point(199, 49);
            servisatakDurum.Name = "servisatakDurum";
            servisatakDurum.Size = new Size(68, 30);
            servisatakDurum.TabIndex = 7;
            servisatakDurum.Text = "label2";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label1);
            groupBox3.Controls.Add(gorevdurum);
            groupBox3.Controls.Add(servisatakDurum);
            groupBox3.Location = new Point(276, 392);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(357, 93);
            groupBox3.TabIndex = 8;
            groupBox3.TabStop = false;
            groupBox3.Text = "Windows Durumu";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(themebutton);
            groupBox4.Controls.Add(antiatakkurulumyolu);
            groupBox4.Controls.Add(label4);
            groupBox4.Controls.Add(antiAtakDurum);
            groupBox4.Controls.Add(label2);
            groupBox4.Location = new Point(276, 491);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(700, 106);
            groupBox4.TabIndex = 9;
            groupBox4.TabStop = false;
            groupBox4.Text = "AntiATAK durumu";
            // 
            // antiatakkurulumyolu
            // 
            antiatakkurulumyolu.AutoSize = true;
            antiatakkurulumyolu.BackColor = Color.Transparent;
            antiatakkurulumyolu.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            antiatakkurulumyolu.ForeColor = Color.Red;
            antiatakkurulumyolu.Location = new Point(8, 77);
            antiatakkurulumyolu.Name = "antiatakkurulumyolu";
            antiatakkurulumyolu.Size = new Size(91, 20);
            antiatakkurulumyolu.TabIndex = 9;
            antiatakkurulumyolu.Text = "Kurulu Değil";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(8, 49);
            label4.Name = "label4";
            label4.Size = new Size(233, 30);
            label4.TabIndex = 8;
            label4.Text = "AntiATAK Kurulum Yolu:";
            // 
            // antiAtakDurum
            // 
            antiAtakDurum.AutoSize = true;
            antiAtakDurum.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            antiAtakDurum.Location = new Point(189, 22);
            antiAtakDurum.Name = "antiAtakDurum";
            antiAtakDurum.Size = new Size(154, 30);
            antiAtakDurum.TabIndex = 7;
            antiAtakDurum.Text = "antiAtakDurum";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(6, 22);
            label2.Name = "label2";
            label2.Size = new Size(171, 30);
            label2.TabIndex = 6;
            label2.Text = "AntiATAK durum:";
            // 
            // logboxtemizle
            // 
            logboxtemizle.Location = new Point(882, 342);
            logboxtemizle.Name = "logboxtemizle";
            logboxtemizle.Size = new Size(94, 28);
            logboxtemizle.TabIndex = 10;
            logboxtemizle.Text = "Temizle";
            logboxtemizle.UseVisualStyleBackColor = true;
            logboxtemizle.Click += logboxtemizle_Click;
            // 
            // ytuyari
            // 
            ytuyari.AutoSize = true;
            ytuyari.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            ytuyari.Location = new Point(350, 226);
            ytuyari.Name = "ytuyari";
            ytuyari.Size = new Size(534, 32);
            ytuyari.TabIndex = 11;
            ytuyari.Text = "Atiçay çalışabilmek için yönetici hakları gerektirir.";
            ytuyari.Visible = false;
            // 
            // groupBox8
            // 
            groupBox8.Controls.Add(label8);
            groupBox8.Controls.Add(label7);
            groupBox8.Controls.Add(label6);
            groupBox8.Location = new Point(640, 392);
            groupBox8.Name = "groupBox8";
            groupBox8.Size = new Size(336, 93);
            groupBox8.TabIndex = 12;
            groupBox8.TabStop = false;
            groupBox8.Text = "ATİÇAY Bilgi";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(8, 44);
            label7.Name = "label7";
            label7.Size = new Size(188, 20);
            label7.TabIndex = 6;
            label7.Text = "aticay_net6.0.0_standalone ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(8, 22);
            label6.Name = "label6";
            label6.Size = new Size(155, 21);
            label6.TabIndex = 5;
            label6.Text = "Atiçay Sürüm: v3.0.2 ";
            label6.Click += label6_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Malgun Gothic Semilight", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label9.ForeColor = SystemColors.ControlText;
            label9.Location = new Point(465, 604);
            label9.Name = "label9";
            label9.Size = new Size(322, 28);
            label9.TabIndex = 13;
            label9.Text = "https://github.com/prescionx/aticay\r\n";
            label9.Click += label9_Click;
            // 
            // logbox
            // 
            logbox.AutoSize = true;
            logbox.BackColor = Color.Transparent;
            logbox.Font = new Font("Consolas", 10F, FontStyle.Regular, GraphicsUnit.Point);
            logbox.ForeColor = SystemColors.ControlText;
            logbox.Location = new Point(0, 11);
            logbox.Name = "logbox";
            logbox.Size = new Size(378, 38);
            logbox.TabIndex = 1;
            logbox.Text = "ATİÇAY [Standalone | Microsoft .NET6 ASP]\r\n\r\n";
            logbox.Click += logbox_Click;
            // 
            // pxbox
            // 
            pxbox.BackColor = Color.White;
            pxbox.BackgroundImage = Properties.Resources.aticaybeyaz;
            pxbox.Controls.Add(logbox);
            pxbox.Location = new Point(268, 19);
            pxbox.Name = "pxbox";
            pxbox.Size = new Size(708, 351);
            pxbox.TabIndex = 17;
            pxbox.TabStop = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(8, 63);
            label8.Name = "label8";
            label8.Size = new Size(198, 20);
            label8.TabIndex = 7;
            label8.Text = "Only can God Judge me now";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1244, 665);
            Controls.Add(logboxtemizle);
            Controls.Add(pxbox);
            Controls.Add(label9);
            Controls.Add(groupBox8);
            Controls.Add(groupBox4);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(statusStrip1);
            Controls.Add(groupBox3);
            Controls.Add(yoneticiAl);
            Controls.Add(ytuyari);
            ForeColor = Color.Black;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Location = new Point(-1, -1);
            MaximizeBox = false;
            MaximumSize = new Size(1262, 710);
            MinimumSize = new Size(1262, 710);
            Name = "Form1";
            Text = "ATİÇAY";
            Load += Form1_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox6.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox8.ResumeLayout(false);
            groupBox8.PerformLayout();
            pxbox.ResumeLayout(false);
            pxbox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private StatusStrip statusStrip1;
        private GroupBox groupBox1;
        private ToolStripProgressBar antiatakkurProgress;
        private ToolStripStatusLabel uactext;
        private GroupBox groupBox2;
        private Label label1;
        private Label gorevdurum;
        private Button yoneticiAl;
        private Label servisatakDurum;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private Label label2;
        private Label antiAtakDurum;
        private GroupBox groupBox6;
        private GroupBox groupBox5;
        private Label antiatakkurulumyolu;
        private Label label4;
        private Button GorevYoneticisiniAktiflesir;
        private Button DosyalariGizle;
        private Button AntiAtakKaldir;
        private GroupBox groupBox7;
        private Label label3;
        private Button AntiAtakKur;
        private Button autorunAktiflestir;
        private Button restartexplorer;
        private Button GizliDosyalariGoster;
        private Button GorevYoneticisiniDevredisiBirak;
        private Button GorevYoneticisiniBaslat;
        private Label label5;
        private ProgressBar ccebar;
        private Button CCeIndir;
        private Button logboxtemizle;
        private Label ytuyari;
        private GroupBox groupBox8;
        private Label label6;
        private Label label7;
        private Label label9;
        private Label logbox;
        private GroupBox pxbox;
        private Button getKeyFile;
        private Button button2;
        private Button themebutton;
        private Label label8;
    }
}