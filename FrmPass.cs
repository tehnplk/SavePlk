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
    public partial class FrmPass : Form
    {
        string cid ,fullname,sex,birth,addr, tel, vehicle,vehicle_no,total,come_from,card,version;

        public FrmPass()
        {
            InitializeComponent();
        }

        public FrmPass(
            string cid, string fullname, string sex, string birth,
            string addr, string tel, string vehicle, string vehicle_no,
            string total, string come_from, string card, string version
        )
        {
            InitializeComponent();
            //this.Text = cid;

            this.cid = cid;
            this.fullname = fullname;
            this.sex = sex;
            this.birth = birth;
            this.addr = addr;
            this.tel = tel;
            this.vehicle = vehicle;
            this.vehicle_no = vehicle_no;
            this.total = total;
            this.come_from = come_from;
            this.card = card;
            this.version = version;


        }

        public string CheckDate(String bdate)
        {
            DateTime temp;
            if (DateTime.TryParse(bdate, out temp))
            {
                string[] d = bdate.Split('/');
                var yyyy = Int32.Parse(d[2]) - 543;
                var mm = d[1];
                var dd = d[0];
                return yyyy + "-" + mm + "-" + dd;
            }
            else
            {
                return "1900-01-01";
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var via_type = cbViaType.Text.Trim();
            var date_back = txtDateBack.Text.Trim();
            var temperature = txtTemp.Text.Trim();

            if (via_type.Length == 0)
            {
                MessageBox.Show("เหตุผลที่มา ต้องไม่เป็นค่าว่าง");
                cbViaType.Focus();
                return;
            }

            if (date_back.Length == 0) {
                MessageBox.Show("วันเดินทางออก ต้องไม่เป็นค่าว่าง");
                txtDateBack.Focus();
                return;
            }

            if (temperature.Length == 0)
            {
                MessageBox.Show("อุณภูมิ ต้องไม่เป็นค่าว่าง");
                txtTemp.Focus();
                return;
            }




            //post
            string station = File.ReadLines("./config/key.txt").First().Trim();
            Console.WriteLine(station);
            if (station.Trim() == "000")
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


            var client = new RestClient(api.Trim());
            var request = new RestRequest("via");

            request.AddParameter("cid", this.cid);
            request.AddParameter("fullname", this.fullname);
            request.AddParameter("sex", this.sex);
            request.AddParameter("birth", CheckDate(this.birth));
            request.AddParameter("addr", this.addr);
            request.AddParameter("tel", this.tel);           
            request.AddParameter("vehicle", this.vehicle);
            request.AddParameter("vehicle_no", this.vehicle_no);
            request.AddParameter("total", this.total);
            request.AddParameter("come_from", this.come_from);

            request.AddParameter("via_type", via_type);
            request.AddParameter("date_back", CheckDate(date_back));                       
            request.AddParameter("temperature", temperature);
                        
            request.AddParameter("station", station);            
            request.AddParameter("card", this.card);
            request.AddParameter("version", this.version);

            

            var response = client.Post(request);
            var content = response.Content;

            if (string.IsNullOrEmpty(content)) { 
                MessageBox.Show("กรุณาเชื่อมต่ออินเตอร์เน็ต");
                return;
            }

            if (content != "1")
            {
                MessageBox.Show("ไม่สำเร็จ..มีข้อผิดพลาด...โทรสอบถาม 055-252052 ต่อ 454", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("ส่งข้อมูลสำเร็จ!!!");
            //MessageBox.Show("ส่งข้อมูลสำเร็จ!!!", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Information);



            //end post

            // clear parent
            MaskedTextBox pCid = ((Form2)this.Owner).txtCid;
            pCid.Clear();

            TextBox pFullanme = ((Form2)this.Owner).txtFullName;
            pFullanme.Clear();

            ComboBox pSex = ((Form2)this.Owner).cbSex;
            pSex.Text = "";

            MaskedTextBox pBirth = ((Form2)this.Owner).txtBirth;
            pBirth.Clear();

            TextBox pAddr = ((Form2)this.Owner).txtAddr;
            pAddr.Clear();

            MaskedTextBox pTel = ((Form2)this.Owner).txtTel;
            pTel.Clear();

            ComboBox pVehicle = ((Form2)this.Owner).cbVehicle;
            pVehicle.Text = "";

            TextBox pVehicleNo = ((Form2)this.Owner).txtVehicleNo;
            pVehicleNo.Clear();

            TextBox pTotal = ((Form2)this.Owner).txtTotal;
            pTotal.Clear();

            ComboBox pComeFrom = ((Form2)this.Owner).cbComeFrom;
            pComeFrom.Text="";


            this.Close();




        }

        private void txtTemp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Control ctl;
                ctl = (Control)sender;
                ctl.Parent.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void txtDateBack_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Control ctl;
                ctl = (Control)sender;
                ctl.Parent.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void cbViaType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Control ctl;
                ctl = (Control)sender;
                ctl.Parent.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

                     

        private void FrmPass_Load(object sender, EventArgs e)
        {
            cbViaType.Items.Clear();
            AutoCompleteStringCollection items = new AutoCompleteStringCollection();

            string[] datas = File.ReadAllLines("./config/come_type.txt");
            foreach (string line in datas)
            {

                Console.WriteLine(line);
                items.Add(line);
                cbViaType.Items.Add(line);
            }
            cbViaType.AutoCompleteCustomSource = items;


            var cDate = DateTime.UtcNow.ToShortDateString();
            txtDateBack.Text = cDate;
        }
    }
}
