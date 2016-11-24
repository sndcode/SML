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
    public partial class frmSetPath : Form
    {
        public frmSetPath()
        {
            InitializeComponent();
        }

        private void readSettings()
        {
            var dic = File.ReadAllLines(Application.StartupPath + "\\sml.ini")
              .Select(l => l.Split(new[] { '=' }))
              .ToDictionary(s => s[0].Trim(), s => s[1].Trim());
            string gamepath = dic["USERID"];
            string modspath = dic["PASSWORD"];
        }

        private void chooseFolder()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if (!string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                string path = fbd.SelectedPath;
                textBox1.Text = path;
            }
        }

        private void frmSetPath_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            chooseFolder();
        }
    }
}
