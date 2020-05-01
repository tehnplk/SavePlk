using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SavePLK
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string version = File.ReadLines("./config/version.txt").First();            

            string release = File.ReadLines("./config/release.txt").First();
            this.Text = $"Save Phitsanulpk  Version {version} ({release})";
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string version = File.ReadLines("./config/version.txt").First();
            var url = $"http://covid19.plkhealth.go.th/saveplk/web/index.php?r=covid/default/index&version={version}";
            System.Diagnostics.Process.Start(url);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            f.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            frmPassport f = new frmPassport();
            f.ShowDialog(this);
        }
    }
}
