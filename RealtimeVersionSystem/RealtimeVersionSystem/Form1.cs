using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RealtimeVersionSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void getUpdate() {
            Application.Run(new Form2());
            //https://www.instagram.com/canasikk/
            //https://github.com/canasikk
        }
        private Boolean checkUpdate() 
        {
            Boolean versionStatu;
            try 
            {
                WebClient client = new WebClient();
                //https://www.instagram.com/canasikk/
                //https://github.com/canasikk
                Stream str = client.OpenRead("http://localhost/can/canAsikk.php?ca=" + Program.systemVersion);
                StreamReader reader = new StreamReader(str);
                String content = reader.ReadToEnd();
                versionStatu = (content == "GETUPDATE") ? versionStatu = true : versionStatu = false;
            }
            catch { versionStatu = false; }
            return versionStatu;
        }
        private void askUpdate() { 
       
            if(checkUpdate()){
                DialogResult dr = MessageBox.Show("New update is available. \n\r Would you like to install it now?","Update found",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
                if (dr == DialogResult.Yes)
                {
                    //https://www.instagram.com/canasikk/
                    //https://github.com/canasikk
                    System.Threading.Thread thread = new System.Threading.Thread(new System.Threading.ThreadStart(getUpdate));
                    thread.Start();
                    this.Close();
                }
            }
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            askUpdate();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            askUpdate();
        }
    }
}
