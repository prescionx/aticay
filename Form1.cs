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

namespace ATİÇAY3
{
    public partial class Form1 : Form
    {
        private string url = "https://cdn.glitch.global/809e4dc2-d822-44d3-960c-66b700aec03c/antiatak_aticay.exe?v=1688586111186";
        private string versionx = "v3.0.1";
        private string applicationName = "servisatk";
        private bool isRunning = false;
        private bool stopMonitoring = false;
        private bool isDragging = false;
        private int mouseX, mouseY;
        private HttpClient httpClient = new HttpClient();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) // Formun Yüklenmesi İle Tetiklenecek Eventler
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent(); WindowsPrincipal principal = new WindowsPrincipal(identity);
            bool isAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);

            if (isAdmin)
            {
                this.Text = "ATİÇAY [YÖNETİCİ]";
                uactext.Text = "ATİÇAY Yönetici Olarak Çalışıyor";
                logat("ATİÇAY Yönetici Hakları ile başlatıldı");
                yoneticiAl.Visible = false;
                groupBox1.Visible = true;
                groupBox2.Visible = true;

            }
            else
            {
                this.Text = "ATİÇAY [KULLANICI]";
                uactext.Text = "ATİÇAY Yönetici Olarak Çalışmıyor";
                uactext.ForeColor = Color.Red;
                logat("[ RİSKLİ!!] ATİÇAY Yönetici Hakları Olmadan başlatıldı");
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
                Process[] processes = Process.GetProcessesByName(applicationName);
                isRunning = (processes.Length > 0);
                Invoke((MethodInvoker)delegate
                {
                    UpdateStatusText();
                    UpdateTaskManagerStatus();
                    checkAntiAtakInstalled();
                });
                Thread.Sleep(700); // Belirli bir süre bekleyerek tekrar kontrol etmek için 2200 milisaniye kadar beklemeye al
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
                        Invoke(new Action(() => { gorevdurum.Text = "Devre Dışı"; gorevdurum.ForeColor = Color.Red; }));
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
                        Invoke(new Action(() => { gorevdurum.Text = "Normal"; gorevdurum.ForeColor = Color.Green; }));
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
                        logbox.Text = "ATAK SERVİSİ KAPATILDI";
                        logbox.ForeColor = Color.Red;
                        logat("Explorer kapatıldı.");
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
                antiatakkurulumyolu.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point);

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
            logbox.Text += message + Environment.NewLine;
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
    }
}


