using RestSharp;
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
    public partial class frmPassport : Form
    {
        public frmPassport()
        {
            InitializeComponent();
        }

        private void txtVehicleNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Control ctl;
                ctl = (Control)sender;
                ctl.Parent.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void txtTel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Control ctl;
                ctl = (Control)sender;
                ctl.Parent.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

       

        private void txtNote_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Control ctl;
                ctl = (Control)sender;
                ctl.Parent.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string station_in = File.ReadLines("./config/key.txt").First().Trim();
            Console.WriteLine(station_in);
            if (station_in.Trim() == "000")
            {
                MessageBox.Show("กรุณาตั้งค่ารหัสประจำด่านตรวจ รายละเอียดโทร 055-252052 ต่อ 454");
                return;
            }

            string api = File.ReadLines("./config/api.txt").First().Trim();
            Console.WriteLine(api);
            if (api == "000")
            {
                MessageBox.Show("กรุณาตั้งค่าช่องทางส่งข้อมูล รายละเอียดโทร 055-252052 ต่อ 454");
                return;
            }

            string version = File.ReadLines("./config/version.txt").First();
            Console.WriteLine(version);

            var vehicle_no = txtVehicleNo.Text.Trim();
            var tel = txtTel.Text.Trim();
            var note = txtNote.Text.Trim();

            if (vehicle_no.Length == 0) {
                MessageBox.Show("หมายเลขทะเบียนพาหนะ ต้องไม่เป็นค่าว่าง");
                txtVehicleNo.Focus();
                return;
            }

            if (tel.Length == 0)
            {
                MessageBox.Show("เบอร์ติดต่อ ต้องไม่เป็นค่าว่าง");
                txtTel.Focus();
                return;
            }

            //post

           

            var client = new RestClient(api.Trim());
            var request = new RestRequest("passport");

            request.AddParameter("station_in", station_in);
            request.AddParameter("vehicle_no", vehicle_no);
            request.AddParameter("tel", tel);
            request.AddParameter("note", note);
            request.AddParameter("version", version);



            var response = client.Post(request);
            var content = response.Content;

            //MessageBox.Show(content);

            if (string.IsNullOrEmpty(content))
            {
                MessageBox.Show("ไม่สามารถเชื่อมต่อกับเครื่องแม่ข่ายได้");
                return;
            }

            if (content == "0")
            {
                
                MessageBox.Show("ไม่สำเร็จ..กรุณาอัพเดทโปรแกรม...โทรสอบถาม 055-252052 ต่อ 454", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (content != "1")
            {
                MessageBox.Show("ไม่สำเร็จ..มีข้อผิดพลาด...โทรสอบถาม 055-252052 ต่อ 454", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //post


            MessageBox.Show("ส่งข้อมูลสำเร็จ..");
            txtTel.Clear();
            txtVehicleNo.Clear();
            txtNote.Clear();

        }

        private void frmPassport_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string version = File.ReadLines("./config/version.txt").First();
            var url = $"http://covid19.plkhealth.go.th/saveplk/web/index.php?r=covid/passport/index&version={version}";
            System.Diagnostics.Process.Start(url);
        }
    }
}
