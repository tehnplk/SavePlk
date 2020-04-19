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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {


            string st = File.ReadLines("./config/key.txt").First();
            cbStation.Text = st;

            string api = File.ReadLines("./config/api.txt").First();
            cbApi.Text = api;




            var d = DateTime.UtcNow.ToShortDateString();
            if (d.Length < 10) {
                label2.Text = d + " กรุณาตั้งค่ารูปแบบวันที่ Short Date เป็น  dd/MM/yyyy";
                return;
            }
            label2.Text = "รูปแบบวันที่ของเครื่อง : " +d;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbStation.Text.Trim().Length == 0) {
                MessageBox.Show("กรุณาเลือกรหัสด่าน");
                return;
            }

            if (cbApi.Text.Trim().Length == 0)
            {
                MessageBox.Show("กรุณาช่องทางส่งข้อมูล");
                return;
            }
            var d = DateTime.UtcNow.ToShortDateString();
            if (d.Length < 10)
            {
                MessageBox.Show("รูปแบบวันที่ของเครื่องคอมพิวเตอร์ยังไม่ถูกต้อง");
                return;
            }

            
            string station = cbStation.Text.Trim();
            File.WriteAllText("config/key.txt", station);

            string api = cbApi.Text.Trim();
            File.WriteAllText("config/api.txt", api);
            MessageBox.Show("บันทึกสำเร็จ","แจ้งเตือน",MessageBoxButtons.OK,MessageBoxIcon.Information);
            this.Close();

        }
            

        
    }
}
