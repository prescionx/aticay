using System;
using System.Security.Principal;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.ServiceProcess;
using System.ComponentModel;
using System.Net;
using Microsoft.Win32;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.VisualBasic.Devices;
using System.IO.Compression;
using ATİÇAY3.Properties;

namespace ATİÇAY3
{

    public partial class Form1 : Form
    {
        int theme = 0;
        private string url = "https://cdn.glitch.global/809e4dc2-d822-44d3-960c-66b700aec03c/antiatak_aticay.exe?v=1688586111186";
        private string versionx = "v3.0.1";
        private string applicationName = "servisatk";
        private bool isRunning = false;
        private bool stopMonitoring = false;
        private bool isDragging = false;
        private int mouseX,
        mouseY;
        private HttpClient httpClient = new HttpClient();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) // Formun Yüklenmesi İle Tetiklenecek Eventler
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            bool isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);

            if (isAdmin)
            {
                this.Text = "ATİÇAY " + versionx + " [YÖNETİCİ]";
                uactext.Text = "ATİÇAY Yönetici Olarak Çalışıyor";
                logat("ATİÇAY Yönetici Hakları ile başlatıldı");
                yoneticiAl.Visible = false;
                groupBox1.Visible = true;
                groupBox2.Visible = true;

            }
            else
            {
                this.Text = "ATİÇAY " + versionx + " [YÖNETİCİ OLARAK YENİDEN BAŞLATIN!]";
                uactext.Text = "ATİÇAY Yönetici Olarak Çalışmıyor";
                uactext.ForeColor = Color.Red;
                yoneticiAl.Visible = true;
                groupBox1.Visible = false;
                groupBox2.Visible = false;
                logbox.Visible = false;
                groupBox3.Visible = false;
                groupBox4.Visible = false;
                groupBox5.Visible = false;
                ytuyari.Visible = true;
                logboxtemizle.Visible = false;
            }

            logat("by prescionx. version: " + versionx);

            Thread monitoringThread = new Thread(CheckApplicationStatus);
            monitoringThread.Start(); // Monitörlemeyi başlat.

        }

        protected override void OnFormClosing(FormClosingEventArgs e) // Form Kapatıldığında tetiklenecek Eventler
        {
            base.OnFormClosing(e);
            stopMonitoring = true;
            httpClient.Dispose();
        }

        //////////////////// //////////////////// ///////
        ////////////// FONKSİYONLAR BAŞLANGIÇ ///////////
        //////////////////// //////////////////// ///////

        /* CheckApplicationStatus() INTERVAL Tanımlamaları başlangıç  */
        private void CheckApplicationStatus()
        {
            while (!stopMonitoring)
            {
                try
                {
                    Process[] processes = Process.GetProcessesByName(applicationName);
                    isRunning = (processes.Length > 0);
                    Invoke((MethodInvoker)delegate {
                        UpdateStatusText();
                        UpdateTaskManagerStatus();
                        checkAntiAtakInstalled();
                    });
                    Thread.Sleep(700); // Belirli bir süre bekleyerek tekrar kontrol etmek için 2200 milisaniye kadar beklemeye al
                }
                catch (Exception e) { }
            }
        }
        /* CheckApplicationStatus() INTERVAL Tanımlamaları SON  */

        /* UpdateTaskManagerStatus() Fonksiyon Tanımlaması Başlangıcı */
        private void UpdateTaskManagerStatus() // Görev yöneticisinin sistemde devrede olup olmadığını denetle.
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
            if (key != null)
            {
                int? disableTaskMgrValue = (int?)key.GetValue("DisableTaskMgr", 0);
                key.Close();

                if (disableTaskMgrValue == 1)
                {
                    if (InvokeRequired)
                    {
                        Invoke(new Action(() => {
                            gorevdurum.Text = "Devre Dışı";
                            gorevdurum.ForeColor = Color.Red;
                        }));
                    }
                    else
                    {
                        gorevdurum.Text = "Devre Dışı";
                        gorevdurum.ForeColor = Color.Red;
                    }
                }
                else
                {
                    if (InvokeRequired)
                    {
                        Invoke(new Action(() => {
                            gorevdurum.Text = "Normal";
                            gorevdurum.ForeColor = Color.Green;
                        }));
                    }
                    else
                    {
                        gorevdurum.Text = "Devrede";
                        gorevdurum.ForeColor = Color.Green;
                    }
                }
            }
            else
            {
                MessageBox.Show("DisableTaskMgr anahtarı bulunamadı. Görev yöneticisi daha önce devredışı bırakılmamış.");
            }
        }
        /* UpdateTaskManagerStatus() Fonksiyon Tanımlaması Sonu */

        private void EnableAutorun()
        {
            try
            {

                // Registry anahtarına yazma işlemini gerçekleştir
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer", true))
                {
                    key.SetValue("NoDriveTypeAutoRun", 0);
                }
                logat("AutoRUN sistem genelinde Etkinleştirildi");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Autorun ayarları etkinleştirilirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /* Bu Öğe CheckApplicationStatus() ile bağlantılıdır. UpdateStatusText() Fonksiyon Tanımlamaları başlangıç  */
        private void UpdateStatusText()
        {
            if (isRunning)
            {
                servisatakDurum.Text = "Çalışıyor";
                servisatakDurum.ForeColor = Color.Green;
            }
            else
            {
                servisatakDurum.Text = "Çalışmıyor";
                servisatakDurum.ForeColor = Color.Red;
            }
        }
        /* UpdateStatusText() Fonksiyon Tanımlamaları Son*/

        /* Bu öğe Görev yöneticisini regedit ile kapatmaya yarar. DisableTaskmanager() Fonksiyon Tanımlamaları Baş*/
        private void DisableTaskManager()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies", true);
            if (key != null)
            {
                RegistryKey systemKey = key.CreateSubKey("System");
                if (systemKey != null)
                {
                    systemKey.SetValue("DisableTaskMgr", 1, RegistryValueKind.DWord);
                    systemKey.Close();
                    logat("Görev Yöneticisi Devredışı Bırakıldı.");
                    UpdateStatusText();
                    UpdateTaskManagerStatus();
                }
                else
                {
                    MessageBox.Show("Görev Yöneticisi anahtarı oluşturulamadı.");
                }
                key.Close();
            }
            else
            {
                MessageBox.Show("Policies anahtarı bulunamadı.");
            }
        }
        /*  DisableTaskmanager() Fonksiyon Tanımlamaları Son*/

        /* Bu öğe Görev yöneticisini regedit ile etkinleştirmeye yarar. EnableTaskmanager() Fonksiyon Tanımlamaları Baş*/
        private void EnableTaskManager()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System", true);
            if (key != null)
            {
                key.DeleteValue("DisableTaskMgr", false);
                key.Close();
                logat("Görev Yöneticisi Etkinleştirildi");
                UpdateStatusText();
                UpdateTaskManagerStatus();
            }
            else
            {
                MessageBox.Show("Görev Yöneticisi anahtarı bulunamadı.");
            }
        }
        /*  EnableTaskmanager() Fonksiyon Tanımlamaları Son*/

        /* Bu öğe Formu yönetici olarak yeniden başlatmaya yarar. RestartAsAdminstrator() Fonksiyon Tanımlamaları Baş*/
        static void RestartAsAdministrator()
        {
            var startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.UseShellExecute = true;
            startInfo.WorkingDirectory = Environment.CurrentDirectory;
            startInfo.FileName = Application.ExecutablePath;
            startInfo.Verb = "runas"; // Yönetici ayrıcalıklarını talep etmek için "runas" kullanılır

            try
            {
                System.Diagnostics.Process.Start(startInfo);
            }
            catch (System.ComponentModel.Win32Exception)
            {
                // Kullanıcı UAC (User Account Control) ile uyarıyı reddederse, işlem Win32Exception hatası alır.
                // Bu durumu ele almak için özel bir işlem yapabilirsiniz.
                MessageBox.Show("İleri seviye UAC Kullanıcı Hakları Reddedildi.");
            }

            Application.Exit();
        }

        /* RestartAsAdminstrator() Fonksiyon Tanımlamaları Son*/

        /*Bu öğe sistemde çalışmakta olan servisatk isimli işlemi sonlandırır. AtakServisiKapat() Fonksiyon Tanımlamaları Baş*/
        private void AtakServisKapat()
        {

            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);

            bool isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
            if (isAdmin)
            {
                Process[] processes = Process.GetProcesses();

                foreach (Process process in processes)
                {
                    if (process.ProcessName == "servisatk")
                    {
                        process.Kill();
                        logbox.Text = "ATAK SERVİSİ KAPATILDI";
                        logbox.ForeColor = Color.Red;
                        logat("servisatk kapatıldı.");
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Bunun için yönetici olman gerekiyor.");
            }
        }
        /*AtakServisKapat Öğe tanımlamaları son.*/

        /* ExplorerRestart() Fonksiyon Tanımlamaları Baş*/
        private void ExplorerRestart()
        {

            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);

            bool isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
            if (isAdmin)
            {
                Process[] processes = Process.GetProcesses();

                foreach (Process process in processes)
                {
                    if (process.ProcessName == "explorer")
                    {
                        process.Kill();
                        logat("Görev Yöneticisi Yeniden Başlatıldı");
                        Thread.Sleep(100);
                        Process.Start("explorer.exe");
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Bunun için yönetici olman gerekiyor.");
            }
        }
        /*ExplorerRestart Öğe tanımlamaları son.*/

        private void checkAntiAtakInstalled()
        {
            string startupKlasor = Environment.GetFolderPath(Environment.SpecialFolder.Startup); // shell:startup klasörünün tam yolu
            string dosyaAdi = "antiatak_aticay.exe"; // Kaydedilecek dosyanın adı
            string dosyaYolu = Path.Combine(startupKlasor, dosyaAdi); // Tam dosya yolunu oluşturun

            if (File.Exists(dosyaYolu))
            {
                antiAtakDurum.Text = "AntiATAK Kurulmuş!";
                antiAtakDurum.ForeColor = Color.Green;
                antiatakkurProgress.Style = ProgressBarStyle.Blocks;
                antiatakkurProgress.Value = 100;
                antiatakkurulumyolu.Visible = true;
                antiatakkurulumyolu.Text = dosyaYolu;
                antiatakkurulumyolu.ForeColor = Color.Green;
                antiatakkurulumyolu.Font = new Font("Seoge UI", 7F, FontStyle.Regular, GraphicsUnit.Point);

            }
            else
            {
                antiAtakDurum.Text = "AntiAtak Kurulu değil!";
                antiAtakDurum.ForeColor = Color.Red;
                antiatakkurulumyolu.Visible = false;
            }
        }

        /*AntiATAK için gereken tertibatı kurar.AntiATAKkur() Fonksiyonu Başlangıcı*/
        private async void AntiATAKkur()
        {
            string startupKlasor = Environment.GetFolderPath(Environment.SpecialFolder.Startup); // shell:startup klasörünün tam yolu
            string dosyaAdi = "antiatak_aticay.exe"; // Kaydedilecek dosyanın adı
            string dosyaYolu = Path.Combine(startupKlasor, dosyaAdi); // Tam dosya yolunu oluşturun

            if (File.Exists(dosyaYolu))
            {
                AntiAtakKur.Text = "AntiATAK Zaten Kurulmuş!";
            }
            else
            {
                antiatakkurProgress.Style = ProgressBarStyle.Blocks;
                antiatakkurProgress.Value = 0;

                string filePath = Path.Combine(startupKlasor, dosyaAdi);

                try
                {

                    antiatakkurProgress.PerformStep();

                    HttpResponseMessage response = await httpClient.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    using (Stream contentStream = await response.Content.ReadAsStreamAsync())
                    {
                        logat("AntiATAKserver Bağlantı Sağlandı.");
                        antiatakkurProgress.PerformStep();
                        using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            await contentStream.CopyToAsync(fileStream);
                            antiatakkurProgress.PerformStep();

                        }
                    }

                    antiatakkurProgress.PerformStep();

                    logat("Antiatak kuruldu");
                    AntiAtakKaldir.Text = "AntiATAK Kaldır";

                }
                catch (Exception ex)
                {
                    // Hata durumlarıyla başa çıkma.
                    MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /*AntiATAKkur() Fonksiyonu sonu*/

        /* Kurulu AntiATAK Tertibatını kaldırır. AntiATAKkaldir() Fonksiyonu Başlangıcı*/
        private void AntiATAKkaldir()
        {
            string startupKlasor = Environment.GetFolderPath(Environment.SpecialFolder.Startup); // shell:startup klasörünün tam yolu
            string dosyaAdi = "antiatak_aticay.exe"; // Kaydedilecek dosyanın adı
            string dosyaYolu = Path.Combine(startupKlasor, dosyaAdi); // Tam dosya yolunu oluşturun

            if (!File.Exists(dosyaYolu))
            {
                AntiAtakKaldir.Text = "AntiATAK Dosyası Bulunamadı!";
            }
            else
            {
                try
                {
                    if (File.Exists(dosyaYolu))
                    {
                        File.Delete(dosyaYolu);
                        antiAtakDurum.Text = "AntiATAK başarıyla kaldırıldı.";
                        logat("AntiATAK Kaldırıldı.");
                        antiatakkurProgress.Style = ProgressBarStyle.Marquee;
                        AntiAtakKur.Text = "AntiATAK Kur";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata oluştu: " + ex.Message);
                }

            }
        }
        /* AntiATAKkaldir() Fonksiyonu Son*/

        /*Bu fonksiyon kullanıcı tarayıcısında github sayfasını açar. GithubOpenInBrowser() Başlangıç*/
        private void GithubOpenInBrowser()
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = "http://github.com/prescionx/aticay",
                UseShellExecute = true
            });
        }
        /* GithubOpenInBrowser() Son */

        private void HelpWikiOpen()
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/prescionx/aticay/wiki/Nas%C4%B1l-Kullan%C4%B1l%C4%B1r",
                UseShellExecute = true
            });
        }

        /* CCe Son sürümü Comodo CDNden indirip masaüstüne kaydeder. CCeDownload() Fonksiyonu Başlangıcı*/
        private async void CCeDownload()
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string cceFilePath = Path.Combine(desktopPath, "cce.zip");

            if (File.Exists(cceFilePath))
            {
                MessageBox.Show("Masaüstünde 'cce' adında bir dosya bulunuyor!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                ccebar.Visible = true;
                ccebar.Value = 0;
                string url = "https://cdn.download.comodo.com/cce/download/setups/cce_x64.zip";
                string filePath = Path.Combine(desktopPath, "cce.zip");

                try
                {
                    ccebar.PerformStep();
                    logat("Bağlantı Sağlandı.");

                    HttpResponseMessage response = await httpClient.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    using (Stream contentStream = await response.Content.ReadAsStreamAsync())
                    {
                        ccebar.PerformStep();
                        using (FileStream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            await contentStream.CopyToAsync(fileStream);
                            ccebar.PerformStep();

                        }
                    }

                    ccebar.PerformStep();

                    logat("CCe başarıyla indirildi ve masaüstüne kaydedildi.");
                }
                catch (Exception ex)
                {
                    // Hata durumlarıyla başa çıkma.
                    MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /* CCeDownload() Fonksiyonu Sonu*/
        private const string RegistryKeyPath = @"Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced";

        public void ShowHiddenFiles()
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistryKeyPath, true);
                key.SetValue("Hidden", 1);
                key.Close();

                logat("Gizli dosyaların görünürlüğü açıldı.");
            }
            catch (Exception ex)
            {
                logat("Gizli dosyaların görünürlüğü açılırken bir hata oluştu: " + ex.Message);
            }
        }

        public void HideHiddenFiles()
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistryKeyPath, true);
                key.SetValue("Hidden", 0);
                key.Close();

                logat("Gizli dosyaların görünürlüğü kapatıldı.");
            }
            catch (Exception ex)
            {
                logat("Gizli dosyaların görünürlüğü kapatılırken bir hata oluştu: " + ex.Message);
            }
        }

        /* Ortadaki Mesaj Kutusuna Birşeyler Yazdırmak için gerekli fonksiyon*/
        private void logat(string message)
        {
            logbox.Text += "[" + DateTime.Now.ToString("HH:mm:ss") + "] " + message + Environment.NewLine;
        }

        //////////////////// //////////////////// ///////
        ////////////// FONKSİYONLAR BİTİŞ ///////////////
        //////////////////// //////////////////// ///////

        private void GorevYoneticisiniAktiflesir_Click(object sender, EventArgs e)
        {
            EnableTaskManager();
        }
        private void GorevYoneticisiniBaslat_Click(object sender, EventArgs e)
        {
            Process.Start("taskmgr.exe");
            logat("Yönetici başlatılıyor.");
        }
        private void GorevYoneticisiniDevredisiBirak_Click(object sender, EventArgs e)
        {
            DisableTaskManager();
        }
        private void AntiAtakKur_Click(object sender, EventArgs e)
        {
            antiatakkurProgress.Style = ProgressBarStyle.Blocks;
            AntiATAKkur();
        }
        private void AntiAtakKaldir_Click(object sender, EventArgs e)
        {
            AntiATAKkaldir();
        }
        private void CCeIndir_Click(object sender, EventArgs e)
        {
            CCeDownload();
        }

        private void autorunAktiflestir_Click(object sender, EventArgs e)
        {
            EnableAutorun();
        }

        private void logboxtemizle_Click(object sender, EventArgs e)
        {
            logbox.Text = " ";
        }

        private void logbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {
            GithubOpenInBrowser();
        }

        private void yoneticiAl_Click(object sender, EventArgs e)
        {
            RestartAsAdministrator();
        }

        private void GizliDosyalariGoster_Click(object sender, EventArgs e)
        {
            ShowHiddenFiles();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HideHiddenFiles();
        }

        private void logbox_Click(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            CopyFileFromFlashDrive();
        }

        public void ToggleTheme()
        {
            if (theme == 0)
            {
                themebutton.ForeColor = Color.Black;
                this.BackColor = Color.Black;
                this.ForeColor = Color.White;
                label9.ForeColor = Color.White;
                groupBox1.ForeColor = Color.White;
                groupBox2.ForeColor = Color.White;
                groupBox3.ForeColor = Color.White;
                groupBox4.ForeColor = Color.White;
                groupBox5.ForeColor = Color.White;
                groupBox6.ForeColor = Color.White;
                groupBox7.ForeColor = Color.White;
                groupBox8.ForeColor = Color.White;
                logbox.ForeColor = Color.White;
                themebutton.ForeColor = Color.White;
                logboxtemizle.ForeColor = Color.White;
                logboxtemizle.BackColor = Color.Black;
                button2.ForeColor = Color.Cyan;
                button2.BackColor = Color.Black;
                statusStrip1.BackColor = Color.Black;
                statusStrip1.ForeColor = Color.White;
                pxbox.BackgroundImage = Properties.Resources.atidark;
                GorevYoneticisiniAktiflesir.BackColor = Color.DarkGreen;
                GorevYoneticisiniAktiflesir.ForeColor = Color.White;
                GorevYoneticisiniBaslat.BackColor = Color.Goldenrod;
                GorevYoneticisiniBaslat.ForeColor = Color.White;
                GorevYoneticisiniDevredisiBirak.BackColor = Color.Firebrick;
                GorevYoneticisiniDevredisiBirak.ForeColor = Color.White;
                GizliDosyalariGoster.BackColor = Color.DarkGreen;
                GizliDosyalariGoster.ForeColor = Color.White;
                DosyalariGizle.BackColor = Color.Firebrick;
                DosyalariGizle.ForeColor = Color.White;
                restartexplorer.BackColor = Color.Goldenrod;
                restartexplorer.ForeColor = Color.White;
                autorunAktiflestir.BackColor = Color.SteelBlue;
                autorunAktiflestir.ForeColor = Color.White;
                AntiAtakKur.BackColor = Color.Teal;
                AntiAtakKur.ForeColor = Color.White;
                AntiAtakKaldir.BackColor = Color.Purple;
                AntiAtakKaldir.ForeColor = Color.White;
                CCeIndir.BackColor = Color.SaddleBrown;
                CCeIndir.ForeColor = Color.White;
                themebutton.BackColor = Color.Black;
                themebutton.ForeColor = Color.White;
                theme = 1;
            }
            else
            {
                this.BackColor = SystemColors.Control;
                this.ForeColor = Color.Black;
                label9.ForeColor = Color.Black;
                groupBox1.ForeColor = Color.Black;
                groupBox2.ForeColor = Color.Black;
                groupBox3.ForeColor = Color.Black;
                groupBox4.ForeColor = Color.Black;
                groupBox5.ForeColor = Color.Black;
                groupBox6.ForeColor = Color.Black;
                groupBox7.ForeColor = Color.Black;
                groupBox8.ForeColor = Color.Black;
                logbox.ForeColor = Color.Black;
                themebutton.ForeColor = Color.Black;
                statusStrip1.BackColor = SystemColors.Control;
                statusStrip1.ForeColor = Color.Black;
                logboxtemizle.ForeColor = Color.Black;
                logboxtemizle.BackColor = SystemColors.Control;
                button2.ForeColor = Color.Blue;
                button2.BackColor = Color.Transparent;
                pxbox.BackgroundImage = Properties.Resources.aticaybeyaz;
                GorevYoneticisiniAktiflesir.BackColor = Color.PaleGreen;
                GorevYoneticisiniAktiflesir.ForeColor = Color.Black;
                GorevYoneticisiniBaslat.BackColor = Color.Yellow;
                GorevYoneticisiniBaslat.ForeColor = Color.Black;
                GorevYoneticisiniDevredisiBirak.BackColor = Color.LightCoral;
                GorevYoneticisiniDevredisiBirak.ForeColor = Color.Black;
                GizliDosyalariGoster.BackColor = Color.PaleGreen;
                GizliDosyalariGoster.ForeColor = Color.Black;
                DosyalariGizle.BackColor = Color.LightCoral;
                DosyalariGizle.ForeColor = Color.Black;
                restartexplorer.BackColor = Color.Yellow;
                restartexplorer.ForeColor = Color.Black;
                autorunAktiflestir.BackColor = Color.LightBlue;
                autorunAktiflestir.ForeColor = Color.Black;
                AntiAtakKur.BackColor = Color.Aquamarine;
                AntiAtakKur.ForeColor = Color.Black;
                AntiAtakKaldir.BackColor = Color.Violet;
                AntiAtakKaldir.ForeColor = Color.Black;
                CCeIndir.BackColor = Color.AntiqueWhite;
                CCeIndir.ForeColor = Color.Black;
                themebutton.BackColor = SystemColors.Control;
                themebutton.ForeColor = Color.Black;
                theme = 0;
            }
        }


        public void CopyFileFromFlashDrive()
        {
            // Masaüstü yolunu alın
            // Masaüstü yolunu alın
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            // Kontrol etmek istediğiniz dosyanın tam yolunu oluşturun
            string filePath = Path.Combine(desktopPath, "atak.veri");

            // Dosya mevcutsa uyarı gösterin
            if (File.Exists(filePath))
            {
                MessageBox.Show("Masaüstünde 'atak.veri' adında bir dosya bulunuyor. Önce bu dosyayı silin veya ismini değiştirin!", "[ATİÇAY] Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                // Tüm flash sürücüleri bulun
                DriveInfo[] drives = DriveInfo.GetDrives();

                foreach (DriveInfo drive in drives)
                {
                    if (drive.DriveType == DriveType.Removable)
                    {
                        // Flash sürücüsündeki tüm dizinleri ve alt dizinleri tarayın
                        string flashDrivePath = drive.RootDirectory.FullName;
                        string driveName = drive.Name;

                        SearchAndCopyFile(flashDrivePath, "atak.veri", desktopPath, drive.Name[0], driveName);
                    }
                }
            }
        }

        private void SearchAndCopyFile(string directoryPath, string fileName, string destinationPath, char driveLetter, string driveName)
        {
            try
            {
                // Ana dizindeki klasörleri sırala
                DirectoryInfo directory = new DirectoryInfo(directoryPath);
                DirectoryInfo[] subDirectories = directory.GetDirectories();

                foreach (DirectoryInfo subDirectory in subDirectories)
                {
                    // Dizin adını kontrol et
                    if (subDirectory.Name != "System Volume Information")
                    {
                        if (subDirectory.Name.Length > 10)
                        {
                            // "atak.veri" dosyasını ara
                            string[] files = Directory.GetFiles(subDirectory.FullName, fileName, SearchOption.AllDirectories);

                            foreach (string filePath in files)
                            {
                                // Dosyayı masaüstüne kopyala
                                string destinationFilePath = Path.Combine(destinationPath, fileName);
                                File.Copy(filePath, destinationFilePath, true);
                                MessageBox.Show("Dosya başarıyla kopyalandı: " + destinationFilePath, "[ATİÇAY] Başarı!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                logat("ATAK veri başarıyla " + destinationFilePath + " olarak kopyalandı");

                                // Dizin.txt belgesini oluştur ve içeriğini yaz
                                string dizinFilePath = Path.Combine(destinationPath, driveLetter + "_AticayATAK_Cikti_(" + DateTime.Now.ToString("yyyy-MM-dd.HH-mm-ss") + ").txt");
                                using (StreamWriter writer = new StreamWriter(dizinFilePath, true))
                                {
                                    writer.WriteLine("[ATİÇAY v3 - ATAK KEY ÇIKARTICI BETA]");
                                    writer.WriteLine("https://github.com/prescionx/aticay");
                                    writer.WriteLine("================");
                                    writer.WriteLine(" ");
                                    writer.WriteLine(filePath);
                                    writer.WriteLine(" ");
                                    writer.WriteLine("================");
                                    writer.WriteLine("Oluşturma Zamanı: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")); // Tarih ve saat bilgisini yazdır
                                    writer.WriteLine(" ");
                                    writer.WriteLine("Bu dosya " + driveLetter + " (" + driveName + ")  Belleğinin içinden çıkartılmıştır. ATAK için anahtar dosyayı içerir. ");
                                    writer.WriteLine("Kendi USB Belleğinize atakveri.cikti txt içeriğindeki dizine atak.veri'yi kopyalayarak tahtayı açabilirsiniz.");
                                    writer.WriteLine("Örneğin çıktı 'E:\\a735d8a8449bae6641f3128407e970c6\\atak.veri' olsun. Kendi usbnizin içinde");
                                    writer.WriteLine("'a735d8a8449bae6641f3128407e970c6' isimli bir klasör açıp içine atak.veri'yi kopyalarsanız tahtayı TEORİDE kendi usbniz ile açabilirsiniz.");
                                    writer.WriteLine(" ");
                                    writer.WriteLine("https://github.com/prescionx/aticay/wiki/A.T.A.K-1.0.9-%C3%87al%C4%B1%C5%9Fma-prensibi-hakk%C4%B1nda");
                                    writer.WriteLine("adresini ziyaret edin veya program üzerindeki yardım butonuna tıkladıktan sonra wikiye gelin ve oradan okuyun.");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                // Hata durumunda isteğe bağlı olarak bir hata mesajı yazdırabilirsiniz
                MessageBox.Show("Hata: " + e.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ExplorerRestart();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            HelpWikiOpen();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ToggleTheme();
        }
    }
}

/*
When the sun goes down, all our sins collide
When the moon comes out, I'm a devil inside
Gonna go all night, 'cause you know we arrange it right

We don't sleep at night
We don't sleep at night
We don't sleep at night

In the land of milk and honey
We spendin' all our parent's money
Don't give a fuck about tomorrow
We only care about tonight

When the sun goes down, all our sins collide
When the moon comes out, I'm a devil inside
Gonna go all night, 'cause you know we arrange it right

We don't sleep at night
We don't sleep at night
We don't sleep at night
Poppin' pills
For the thrills
We don't sleep at night

Turning you on when the lights go off, o-o-o-o-off
Turning you on when the lights go off
We don't sleep at night

You make me hungry like the wolves
'Cause I'm a creature of the night

Doctor says I got a problem
'Cause I think sleep is for the weak
I wanna bite him like a vampire
'Cause I'm a kinky little freak

When the sun goes down, all our sins collide
When the moon comes out, I'm a devil inside
Gonna go all night, 'cause you know we arrange it right
We don't sleep at night


Turning you on when the lights go off, o-o-o-o-off
Turning you on when the lights go off
We don't sleep at night
Turning you on when the lights go off
We don't sleep at night


WE • DONT • SLEEP • AT • NIGHT


Developed by PrescionX. 2023 July. with love, as always.
s
 */
