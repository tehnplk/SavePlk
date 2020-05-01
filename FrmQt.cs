using RestSharp;
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

namespace SavePLK
{
    public partial class FrmQt : Form
    {
        string cid, fullname, sex, birth, addr, tel, vehicle, vehicle_no, total,come_from, card, version;
        string[] _hotels;

        private void txtQtHomeMoo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Control ctl;
                ctl = (Control)sender;
                ctl.Parent.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void txtQtHomeRoad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtQtHomeTambol.Focus();
            }
        }

        private void txtQtHomeTambol_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Control ctl;
                ctl = (Control)sender;
                ctl.Parent.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void cbQtHomeAmphur_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtTemp.Focus();
            }
        }

        private void txtQtHomeTambol_KeyDown_2(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                cbQtHomeAmphur.Focus();
            }
        }

        private void cbQtHomeAmphur_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtTemp.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {


            string remoteUri = "http://61.19.22.99/saveplk/web/download/";

            Console.WriteLine($"download...{remoteUri}");

            WebClient myWebClient = new WebClient();            
            
            
            myWebClient.DownloadFile(remoteUri + "/hotel.txt", "./config/hotel.txt");

            myWebClient.DownloadFile(remoteUri + "/hotel.jpg", "./config/hotel.jpg");
           
                                 
            MessageBox.Show("อัพเดทสำเร็จ!!!");
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmHotel f = new frmHotel();
            f.ShowDialog(this);
        }

        private void txtQtHomeTambol_KeyDown_3(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                cbQtHomeAmphur.Focus();
            }
        }

        private void cbQtHomeAmphur_KeyDown_2(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtTemp.Focus();
            }
        }

        private void txtQtHomeTambol_KeyDown_4(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                cbQtHomeAmphur.Focus();
               
            }
        }

        private void cbQtHomeAmphur_KeyDown_3(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtTemp.Focus();

            }
        }

        public FrmQt()
        {
            InitializeComponent();
        }

        public FrmQt(
            string cid, string fullname, string sex, string birth,
            string addr, string tel, string vehicle, string vehicle_no,
            string total, string come_from, string card, string version
        )
        {
            InitializeComponent();

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

            if (card == "เหลือง")
            {
                label1.BackColor = Color.Yellow;
                label1.Text = "คนต่างจังหวัดพักค้างคืนชั่วคราวต้องพักที่โรงแรมที่จัดให้เท่านั้น";
                label1.ForeColor = Color.Black;
                txtQtHomeAddr.Enabled = false;
                txtQtHomeTambol.Enabled = false;
                cbQtHomeAmphur.Enabled = false;
                txtQtHomeMoo.Enabled = false;
                txtQtHomeRoad.Enabled = false;
                
            }

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

        private void button1_Click(object sender, EventArgs e)
        {

            var q_hotel = cbQtHotel.Text.Trim();

            var q_home_addr = txtQtHomeAddr.Text.Trim();
            var q_home_moo = txtQtHomeMoo.Text.Trim();
            var q_home_road = txtQtHomeRoad.Text.Trim();

            var q_home_tambol = txtQtHomeTambol.Text.Trim();
            var q_home_amphur = cbQtHomeAmphur.Text.Trim();
            var q_date_begin = txtQtDateBegin.Text.Trim();
            var temperature = txtTemp.Text.Trim();


            if (this.card == "เหลือง" && q_hotel=="")
            {
                MessageBox.Show("บัตรสีเหลือง กรุณาเลือกที่พักที่จังหวัดจัดไว้ให้");
                cbQtHotel.Focus();
                return;
            }

            if (this.card != "เหลือง" && (q_hotel == "" || q_hotel == "ที่บ้าน"))
            {

                if (q_home_addr == "")
                {
                    MessageBox.Show("กรณีเลือกกักตัวที่บ้าน บ้านเลขที่ ต้องไม่เป็นค่าว่าง");
                    txtQtHomeAddr.Focus();
                    return;
                }

                if (q_home_moo=="" && q_home_road =="") {
                    MessageBox.Show("กรณีเลือกกักตัวที่บ้าน หมู่ที่ หรือ ถนน ต้องไม่เป็นค่าว่าง");
                    txtQtHomeMoo.Focus();
                    return;
                }

                if (q_home_tambol == "")
                {
                    MessageBox.Show("กรณีเลือกกักตัวที่บ้าน ตำบล ต้องไม่เป็นค่าว่าง");
                    txtQtHomeTambol.Focus();
                    return;
                }

                if (q_home_amphur.Length < 5)
                {
                    Console.WriteLine(q_home_amphur.Length);
                    MessageBox.Show("กรณีเลือกกักตัวที่บ้าน อำเภอ ต้องไม่เป็นค่าว่าง");
                    cbQtHomeAmphur.Focus();
                    return;
                }

            }


            if (temperature == "") {
                MessageBox.Show("อุณภูมิ ต้องไม่เป็นค่าว่าง");
                txtTemp.Focus();
                return;
            }

            string moo = " ม.";

            if (q_home_moo == "" || q_home_moo == "-")
            {
                moo = "";
            }
            else {
                moo = moo + q_home_moo;
            }

            string rd = " ถ.";

            if (q_home_road == "" || q_home_road == "-")
            {
                rd = "";
            }
            else {
                rd = rd + q_home_road;
            }

            q_home_addr = q_home_addr + moo + rd;




            //post
            string station = File.ReadLines("./config/key.txt").First().Trim();
            Console.WriteLine(station);
            if (station.Trim() == "000")
            {
                MessageBox.Show("กรุณาตั้งค่ารหัสด่านตรวจ รายละเอียดโทร 055-252052 ต่อ 454");
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
            var request = new RestRequest("income");

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

            request.AddParameter("q_hotel", q_hotel);
            request.AddParameter("q_home_addr", q_home_addr);
            request.AddParameter("q_home_tambol", q_home_tambol);
            request.AddParameter("q_home_amphur", q_home_amphur);
            request.AddParameter("q_date_begin", CheckDate(q_date_begin));

            request.AddParameter("temperature", temperature);

            request.AddParameter("station", station);
            request.AddParameter("card", this.card);
            request.AddParameter("version", this.version);



            var response = client.Post(request);
            var content = response.Content;

            if (string.IsNullOrEmpty(content))
            {
                MessageBox.Show("กรุณาเชื่อมต่ออินเตอร์เน็ต");
                return;
            }

            if (content == "0")
            {
                MessageBox.Show("ไม่สำเร็จ..กรุณาอัพเดทโปรแกรม...โทรสอบถาม 055-252052 ต่อ 454", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (content != "1")
            {
                MessageBox.Show("ไม่สำเร็จ..มีข้อผิดพลาด...โทรสอบถาม 055-252052 ต่อ 454","แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("ส่งข้อมูลสำเร็จ!!!");



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
                button1.Focus();
                
            }
        }

        private void txtQtDateBegin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Control ctl;
                ctl = (Control)sender;
                ctl.Parent.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void txtQtHomeAmphur_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtQtDateBegin.Focus();
            }
        }

        private void txtQtHomeTambol_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Control ctl;
                ctl = (Control)sender;
                ctl.Parent.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void txtQtHomeAddr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Control ctl;
                ctl = (Control)sender;
                ctl.Parent.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void cbQtHotel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                
                e.SuppressKeyPress = true;
                var hotel = cbQtHotel.Text.Trim();
                if (this.card == "เหลือง")
                {
                    txtTemp.Focus();
                    return;
                }

                if(hotel=="ที่บ้าน" || hotel == "")
                {
                    txtQtHomeAddr.Focus();
                    return;
                }
                txtTemp.Focus();

            }
        }

        

        private void FrmQt_Load(object sender, EventArgs e)
        {
            cbQtHotel.Focus();
            var cDate = DateTime.UtcNow.ToShortDateString();
            txtQtDateBegin.Text = cDate;

            AutoCompleteStringCollection tmb_items = new AutoCompleteStringCollection();
            string[] tmbs = File.ReadAllLines("./config/tmb.txt");
            foreach (string line in tmbs)
            {

                Console.WriteLine(line);
                tmb_items.Add(line);
            }
            txtQtHomeTambol.AutoCompleteCustomSource = tmb_items;

            cbQtHotel.Items.Clear();
            AutoCompleteStringCollection hotel_items = new AutoCompleteStringCollection();
            string[] hotels = File.ReadAllLines("./config/hotel.txt");

            List<String> _h = new List<string>();
            foreach (string line in hotels)
            {

                Console.WriteLine(line);
                if(line.Trim() != "")
                {
                    hotel_items.Add(line);
                    cbQtHotel.Items.Add(line);
                    _h.Add(line);
                }
                
            }
            _hotels = _h.ToArray();


            if (this.card == "เหลือง") {
                //cbQtHotel.Items.RemoveAt(0);
            }
            cbQtHotel.AutoCompleteCustomSource = hotel_items;

        }

       

       
    }
}
