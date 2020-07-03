using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealtimeVersionSystem
{
    public partial class Form2 : Form
    {
        string appPath = Application.StartupPath + "\\example3.rar";
        public Form2()
        {
            InitializeComponent();
        }

        private void ProgressChanged(object sneder, DownloadProgressChangedEventArgs e) { 
          progressBar1.Value = e.ProgressPercentage;
          label2.Text = "Downloading...   " + BytesToString(e.BytesReceived) + " / " + BytesToString(e.TotalBytesToReceive);
        }
        private void Completed(object sender, AsyncCompletedEventArgs e) {
            label2.Text = "Done!";
            //https://www.instagram.com/canasikk/
            //https://github.com/canasikk
            DialogResult dr = MessageBox.Show("Do you want to install","Done",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
            try { 
                if(dr == DialogResult.Yes){
                    System.Diagnostics.Process.Start(appPath);
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //https://www.instagram.com/canasikk/
            //https://github.com/canasikk
            timer1.Stop();
            WebClient webClient = new WebClient();
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            webClient.DownloadFileAsync(new Uri("http://localhost/can/example3.rar"),appPath);
        }

        private static string BytesToString(long byteCount)
        {
            string[] suf = { "B", "KB", "MB", "GB", "TB", "PB", "EB" };
            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place),1);
            //https://www.instagram.com/canasikk/
            //https://github.com/canasikk
            return (Math.Sign(bytes) * num).ToString() + suf[place];
        }

    }
}
