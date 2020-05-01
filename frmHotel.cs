using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SavePLK
{
    public partial class frmHotel : Form
    {
        Image img;
        public frmHotel()
        {
            InitializeComponent();
        }

        private void frmHotel_Load(object sender, EventArgs e)
        {
            img = Image.FromFile("./config/hotel.jpg");
            pictureBox1.Image = img;
        }

        private void frmHotel_FormClosing(object sender, FormClosingEventArgs e)
        {
            img.Dispose();
            pictureBox1.Image = null;
        }
    }
}
