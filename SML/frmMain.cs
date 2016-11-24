using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SML
{
    public partial class frmMain : Form
    {
        public string gamepath;
        public string modfolderpath;

        public frmMain()
        {
            InitializeComponent();
        }

        private void setGamePath()
        {
            MessageBox.Show("Path is not set yet..");
            showPathSelectionForm();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();
            readSettings();
            modfolderpath = gamepath + "\\Mods\\";
            //MessageBox.Show(modfolderpath);

            if( modfolderpath != "")
            {
                DirectoryInfo directory = new DirectoryInfo(modfolderpath);
                DirectoryInfo[] directories = directory.GetDirectories();
                foreach (DirectoryInfo folder in directories)
                    checkedListBox1.Items.Add(folder.Name);
            }
            else if( gamepath == "" ) { setGamePath(); }
        }

        private void toggleMods()
        {
            foreach (Object item in checkedListBox1.CheckedItems)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void showPathSelectionForm()
        {
            frmSetPath fsp = new frmSetPath();
            fsp.Show();
        }

        private void setGamePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showPathSelectionForm();
        }

        private void readSettings()
        {
            try
            { 
                var dic = File.ReadAllLines(Application.StartupPath + "\\sml.ini")
                  .Select(l => l.Split(new[] { '=' }))
                  .ToDictionary(s => s[0].Trim(), s => s[1].Trim());
                string settingspath = dic["path_to_exe"];
                gamepath = settingspath;
            }
            catch { }
        }

        private void checkPaths()
        {
            //if(!File.Exists(Application.StartupPath + "\\sml.ini"))
            //{
            //    File.Create(Application.StartupPath + "\\sml.ini");
            //    setGamePath();
            //}
            //else if(File.Exists(Application.StartupPath + "\\sml.ini"))
            //{
            //    readSettings();
            //}
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //checkPaths();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("INFO about mod : " + checkedListBox1.SelectedItem);
        }
    }
}
