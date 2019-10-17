using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace EasyMCBedrock
{

    public partial class EasyMCBedrock : Form
    {
        private System.Timers.Timer refTimer;
        public EasyMCBedrock()
        {
            InitializeComponent();

            RefreshA();

        }
        private delegate void RefreshD();
        private static RefreshD rd;
        public void RefreshA() {
            listBox1.Items.Clear();
            listBox2.Items.Clear();


            string fileNameF;
            string finalpath;
            string finalpath2;
            string appdata;


            appdata = Environment.GetEnvironmentVariable("LocalAppData");
            string[] array1 = Directory.GetDirectories(@"C:\");
            finalpath = appdata + @"\Packages\Microsoft.MinecraftUWP_8wekyb3d8bbwe\LocalState\games\com.mojang\behavior_packs\";
            

            foreach (var d in System.IO.Directory.GetDirectories(finalpath))
            {
                var dir = new DirectoryInfo(d);
                var dirName = dir.Name;

                listBox1.Items.Add(dirName);
            }

            string RfileNameF;
            string Rfinalpath;
            string Rfinalpath2;
            string Rappdata;


            Rappdata = Environment.GetEnvironmentVariable("LocalAppData");
            string[] Rarray1 = Directory.GetDirectories(@"C:\");
            Rfinalpath = Rappdata + @"\Packages\Microsoft.MinecraftUWP_8wekyb3d8bbwe\LocalState\games\com.mojang\resource_packs\";


            foreach (var d in System.IO.Directory.GetDirectories(Rfinalpath))
            {
                var Rdir = new DirectoryInfo(d);
                var RdirName = Rdir.Name;

                listBox2.Items.Add(RdirName);
            }

        }
        private static EasyMCBedrock myForm;
        private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                myForm.Invoke(rd);
            }
            catch (Exception ee)
            {

            }
        }

        private void EasyMCBedrock_Load(object sender, EventArgs e)
        {
            rd = new RefreshD(RefreshA);
            refTimer = new System.Timers.Timer(1000);
            refTimer.Elapsed += OnTimedEvent;
            refTimer.AutoReset = true;
            refTimer.Enabled = true;
            myForm = this;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            //dlg.ShowDialog();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                /*
               
                owo
                  
                owo
                  
                owo
                
                 */
                Environment.GetEnvironmentVariable("LocalAppData");
                string fileName;
                string fileNameF;
                string s1;
                string finalpath;
                string appdata;
                appdata = Environment.GetEnvironmentVariable("LocalAppData");
                fileName = dlg.FileName;
                fileNameF = Path.GetFileName(fileName);
                string fileNameY = fileNameF.Replace(".zip", "");
                fileNameY = fileNameY.Replace(".mcpack", "");
                finalpath = appdata + @"\Packages\Microsoft.MinecraftUWP_8wekyb3d8bbwe\LocalState\games\com.mojang\resource_packs\" + fileNameY;
                ExtractZipFile(fileName, appdata + @"\Packages\Microsoft.MinecraftUWP_8wekyb3d8bbwe\LocalState\games\com.mojang\resource_packs\" + fileNameY);
                MessageBox.Show("Resource Pack installed. Please restart your game.");
            }

        }

        private void ExtractZipFile(string zipFileLocation, string destination)
        {
            try
            {
                using (Ionic.Zip.ZipFile zip = new Ionic.Zip.ZipFile(zipFileLocation))
                {
                    zip.ExtractAll(destination);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("That's not an archive file I can extract.\nIt might be the wrong format, or maybe just corrupted.\nTry ReDownloading the file!", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            //dlg.ShowDialog();

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                /*
               
                owo
                  
                owo
                  
                owo
                
                 */
                Environment.GetEnvironmentVariable("LocalAppData");
                string fileName;
                string fileNameF;
                string s1;
                string finalpath;
                string appdata;
                appdata = Environment.GetEnvironmentVariable("LocalAppData");
                fileName = dlg.FileName;
                fileNameF = Path.GetFileName(fileName);
                string fileNameY = fileNameF.Replace(".zip", "");
                fileNameY = fileNameY.Replace(".mcpack", "");
                finalpath = appdata + @"\Packages\Microsoft.MinecraftUWP_8wekyb3d8bbwe\LocalState\games\com.mojang\resource_packs\" + fileNameY;
                ExtractZipFile(fileName, appdata + @"\Packages\Microsoft.MinecraftUWP_8wekyb3d8bbwe\LocalState\games\com.mojang\behavior_packs\" + fileNameY);
                MessageBox.Show("Behavior Pack installed. Please restart your game.");
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not implimented yet!");
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://mcpedl.com/");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PopulateListBox(ListBox lsb, string Folder, string FileType)
        {
            DirectoryInfo dinfo = new DirectoryInfo(Folder);
            FileInfo[] Files = dinfo.GetFiles(FileType);
            foreach (FileInfo file in Files)
            {
                lsb.Items.Add(file.Name);
            }
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button8_Click(object sender, EventArgs e)
        {
            RefreshA();
        }
    }
}
