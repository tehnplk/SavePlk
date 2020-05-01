using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThaiNationalIDCard;
using RestSharp;
using System.IO;

namespace SavePLK
{
    public partial class Form2 : Form
    {

        ThaiIDCard idcard;
        String _addr;
        String _tumbol;
        String _amphur;

        public Form2()
        {
            InitializeComponent();
            idcard = new ThaiIDCard();
        }

        public void readCard()
        {

            Personal personal = idcard.readAll();
            if (personal != null)
            {

                Console.WriteLine(personal.Citizenid);
                Console.WriteLine(personal.Birthday.ToString("dd/MM/yyyy"));
                Console.WriteLine(personal.Sex);
                Console.WriteLine(personal.Th_Prefix);
                Console.WriteLine(personal.Th_Firstname);
                Console.WriteLine(personal.Th_Lastname);
                Console.WriteLine(personal.En_Prefix);
                Console.WriteLine(personal.En_Firstname);
                Console.WriteLine(personal.En_Lastname);
                Console.WriteLine(personal.Issue.ToString("dd/MM/yyyy")); // วันออกบัตร
                Console.WriteLine(personal.Expire.ToString("dd/MM/yyyy")); // วันหมดอายุ

                Console.WriteLine(personal.Address);
                Console.WriteLine(personal.addrHouseNo); // บ้านเลขที่
                Console.WriteLine(personal.addrVillageNo); // หมู่ที่
                Console.WriteLine(personal.addrLane); // ซอย
                Console.WriteLine(personal.addrRoad); // ถนน
                Console.WriteLine(personal.addrTambol);
                Console.WriteLine(personal.addrAmphur);
                Console.WriteLine(personal.addrProvince);
            }
            else if (idcard.ErrorCode() > 0)
            {
                Console.WriteLine(idcard.Error());
            }
        }

       
        private void txtCid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                txtFullName.Focus();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
            Personal p = idcard.readAll();
            if (p != null)
            {

                _addr = p.addrHouseNo +" "+ p.addrVillageNo +" "+ p.addrRoad +" "+ p.addrLane;
                _tumbol = p.addrTambol;
                _amphur = p.addrAmphur;

                txtCid.Text = p.Citizenid;
                txtFullName.Text = p.Th_Prefix + p.Th_Firstname + " " + p.Th_Lastname;
                var sex = p.Sex;
                if (sex == "1"){
                    cbSex.Text = "ชาย";
                }
                else {
                    cbSex.Text = "หญิง";
                }
                
                var addr = p.Address;
                addr = addr.Replace("หมู่ที่", "ม.");
                addr = addr.Replace("ตำบล", "ต.");
                addr = addr.Replace("อำเภอ", "อ.");
                addr = addr.Replace("จังหวัด", "จ.");
                txtAddr.Text = addr;

                txtTel.Focus();

                Console.WriteLine(p.Birthday.Date);
                //Console.WriteLine(p.Birthday.ToShortDateString());
                try {
                    txtBirth.Text = p.Birthday.Date.ToShortDateString();
                } catch (FormatException exp) {
                    MessageBox.Show(exp.Message);
                    return;
                }
                

                
            }
            else if (idcard.ErrorCode() > 0)
            {
                
                MessageBox.Show("ไม่สามารถอ่านบัตรได้ / กรุณาเสียบบัตรอีกครั้ง");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            txtAddr.Clear();
            txtAddr.Focus();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_addr)) {
                return;
            }
            //txtQtHomeAddr.Text = _addr.Replace("หมู่ที่","ม.").Trim();
            //txtQtHomeTambol.Text = _tumbol.Replace("ตำบล","");
            //cbQtHomeAmphur.Text = _amphur.Replace("อำเภอ","");
        }

       

        private void Form2_Load(object sender, EventArgs e)
        {



            string version = File.ReadLines("./config/version.txt").First();

            string release = File.ReadLines("./config/release.txt").First();
            this.Text = $"SavePLK  Version {version} ({release})";

            var d = DateTime.UtcNow.ToShortDateString();
            //txtQtDateBegin.Text = d;

            string key = File.ReadLines("./config/key.txt").First();
            Console.WriteLine(key);
            txtStation.Text = key;

            if (key == "000") {
                MessageBox.Show("กรุณาใส่รหัสประจำด่านตรวจ");
                this.Close();
            }

            

            AutoCompleteStringCollection prov_items = new AutoCompleteStringCollection();

            string[] provs = File.ReadAllLines("./config/prov.txt");
            cbComeFrom.Items.Clear();
            foreach (string line in provs)
            {
                
                Console.WriteLine(line);
                prov_items.Add(line);
                cbComeFrom.Items.Add(line);
            }
            //txtComeFrom.AutoCompleteCustomSource = prov_items;
            //cbComeFrom.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbComeFrom.AutoCompleteCustomSource = prov_items;
            

            AutoCompleteStringCollection tmb = new AutoCompleteStringCollection();
            string[] tmbs = File.ReadAllLines("./config/tmb.txt");
            foreach (string line in tmbs)
            {

                Console.WriteLine(line);
                tmb.Add(line);
            }
            //txtQtHomeTambol.AutoCompleteCustomSource = tmb;

            AutoCompleteStringCollection item_vehicle = new AutoCompleteStringCollection();
            string[] vehicles = File.ReadAllLines("./config/vehicle.txt");
            cbVehicle.Items.Clear();
            foreach (string line in vehicles)
            {

                Console.WriteLine(line);
                item_vehicle.Add(line);
                cbVehicle.Items.Add(line);
            }
            
            cbVehicle.AutoCompleteCustomSource = item_vehicle;







        }

        void ClearAllText(Control con)
        {
            foreach (Control c in con.Controls)
            {
                if (c is TextBox)
                    ((TextBox)c).Clear();
                else
                    ClearAllText(c);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //var msg = "";

            

            if (txtStation.Text.Trim() == "000") {
                MessageBox.Show("กรุณาตั้งค่ารหัสประจำด่านตรวจ รายละเอียดโทร 055-252052 ต่อ 454");
                return;
            }

            string api = File.ReadLines("./config/api.txt").First();

            if (api == "000")
            {
                MessageBox.Show("กรุณาตั้งค่าช่องทางส่งข้อมูล รายละเอียดโทร 055-252052 ต่อ 454");
                return;
            }


            if (txtCid.Text.Trim().Length == 0) {
                MessageBox.Show("เลขบัตร ต้องไม่เป็นค่าว่าง");
                txtCid.Focus();
                return;
            }

            if (txtFullName.Text.Trim().Length == 0)
            {
                MessageBox.Show("ชื่อ-นามสกุล ต้องไม่เป็นค่าว่าง");
                txtFullName.Focus();
                return;
            }

            

            if (txtAddr.Text.Trim().Length == 0)
            {
                MessageBox.Show("ที่อยู่ ต้องไม่เป็นค่าว่าง");
                txtAddr.Focus();
                return;
            }

            

            if (txtStation.Text.Trim().Length != 3)
            {
                MessageBox.Show("รหัสด่านตรวจไม่ถูกต้อง");
                txtStation.Focus();
                return;
            }

            //string api = File.ReadLines("./config/api.txt").First();
            Console.WriteLine(api);


            var client = new RestClient(api.Trim());

            var request = new RestRequest("income");
            request.AddParameter("cid", txtCid.Text.Trim());
            request.AddParameter("fullname", txtFullName.Text.Trim());
            request.AddParameter("sex", cbSex.Text.Trim());
            request.AddParameter("birth", txtBirth.Text);
            request.AddParameter("addr", txtAddr.Text.Trim());
            request.AddParameter("tel", txtTel.Text.Trim());
            //request.AddParameter("come_from", txtComeFrom.Text.Trim());
            request.AddParameter("vehicle", cbVehicle.Text.Trim());
            request.AddParameter("vehicle_no", txtVehicleNo.Text.Trim());
            //request.AddParameter("q_date_begin", CheckDate(txtQtDateBegin.Text));
            //request.AddParameter("q_hotel", cbQtHotel.Text.Trim());
            //request.AddParameter("q_home_addr", txtQtHomeAddr.Text.Trim());
            //request.AddParameter("q_home_tambol", txtQtHomeTambol.Text.Trim());
            //request.AddParameter("q_home_amphur", cbQtHomeAmphur.Text.Trim());
            //request.AddParameter("temp", txtTemp.Text.Trim());
            //request.AddParameter("symptom", txtSymptom.Text.Trim());
            //request.AddParameter("note", txtNote.Text.Trim());
            request.AddParameter("station", txtStation.Text.Trim());

            var response = client.Post(request);
            var content = response.Content; // raw content as string
            if (string.IsNullOrEmpty(content)) {
                MessageBox.Show("ไม่สำเร็จ..กรุณาเชื่อมต่อกับเครื่องแม่ข่าย");
                return;
            }
            if (content != "1") {
                MessageBox.Show("ไม่สำเร็จ..มีข้อผิดพลาด");
                return;
            }
            MessageBox.Show("ส่งข้อมูลสำเร็จ!!!");

            ClearAllText(this);
            
            cbSex.Text = "";
            //cbQtHotel.Text = "";
            //cbQtHomeAmphur.Text = "";
            cbVehicle.Text = "";

            txtCid.Clear();
            txtBirth.Clear();
            //txtQtDateBegin.Clear();

            txtCid.Focus();

            var d = DateTime.UtcNow.ToShortDateString();
            //txtQtDateBegin.Text = d;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string version = File.ReadLines("./config/version.txt").First();
            var url = $"http://covid19.plkhealth.go.th/saveplk/web/index.php?r=covid/income&version={version}";
            System.Diagnostics.Process.Start(url);
        }

        private void txtStation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Control ctl;
                ctl = (Control)sender;
                ctl.Parent.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

       
        private void txtComeFrom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Control ctl;
                ctl = (Control)sender;
                ctl.Parent.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void cbVehicle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Control ctl;
                ctl = (Control)sender;
                ctl.Parent.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void txtVehicleNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Control ctl;
                ctl = (Control)sender;
                ctl.Parent.SelectNextControl(ActiveControl, true, true, true, true);
                //txtQtDateBegin.SelectAll();
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

        private void cbQtHotel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Control ctl;
                ctl = (Control)sender;
                ctl.Parent.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void txtCid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Control ctl;
                ctl = (Control)sender;
                ctl.Parent.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void txtFullName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Control ctl;
                ctl = (Control)sender;
                ctl.Parent.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void cbSex_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Control ctl;
                ctl = (Control)sender;
                ctl.Parent.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void txtBirth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Control ctl;
                ctl = (Control)sender;
                ctl.Parent.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void txtAddr_KeyDown(object sender, KeyEventArgs e)
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

        private void cbQtHomeAmphur_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Control ctl;
                ctl = (Control)sender;
                ctl.Parent.SelectNextControl(ActiveControl, true, true, true, true);
            }
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

        private void txtSymptom_KeyDown(object sender, KeyEventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var card = "เขียว";

            var cid = txtCid.Text.Trim();
            var fullname = txtFullName.Text.Trim();
            var sex = cbSex.Text.Trim();
            var birth = txtBirth.Text.Trim();
            var addr = txtAddr.Text.Trim();
            var tel = txtTel.Text.Trim();
            var vehicle = cbVehicle.Text.Trim();
            var vehicle_no = txtVehicleNo.Text.Trim();
            var total = txtTotal.Text.Trim();
            var come_from = cbComeFrom.Text.Trim();
            var version = File.ReadLines("./config/version.txt").First();

            if (cid.Length == 0) {
                MessageBox.Show("เลขบัตร ต้องไม่เป็นค่าว่าง");
                txtCid.Focus();
                return;
            }

            if (fullname.Length == 0)
            {
                MessageBox.Show("ชื่อ-นามสกุล ต้องไม่เป็นค่าว่าง");
                txtFullName.Focus();
                return;
            }

            if (addr.Length == 0)
            {
                MessageBox.Show("ที่อยู่ ต้องไม่เป็นค่าว่าง");
                txtAddr.Focus();
                return;
            }
            if (tel.Length == 0)
            {
                MessageBox.Show("เบอร์โทร ต้องไม่เป็นค่าว่าง");
                txtTel.Focus();
                return;
            }
            if (vehicle.Length == 0)
            {
                MessageBox.Show("พาหนะ ต้องไม่เป็นค่าว่าง");
                cbVehicle.Focus();
                return;
            }

            if (vehicle_no.Length == 0)
            {
                MessageBox.Show("เลขทะเบียน ต้องไม่เป็นค่าว่าง");
                txtVehicleNo.Focus();
                return;
            }

            FrmPass f = new FrmPass(cid, fullname,sex,birth,addr,tel,vehicle,vehicle_no,total,come_from,card,version);
            f.ShowDialog(this);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("บัตรสีชมพู สามารถเดินทางออกไปต่างจังหวัด และเดินทางกลับเข้ามาจากต่างจังหวัด เฉพาะจังหวัดที่คณะกรรมการฯอนุญาตเท่านั้น");
        
            //System.Diagnostics.Process.Start("http://covid19.plkhealth.go.th/checkpoint/");
        }

        private void Form2_Activated(object sender, EventArgs e)
        {
            txtCid.Focus();
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            var card = "เหลือง";

            var cid = txtCid.Text.Trim();
            var fullname = txtFullName.Text.Trim();
            var sex = cbSex.Text.Trim();
            var birth = txtBirth.Text.Trim();
            var addr = txtAddr.Text.Trim();
            var tel = txtTel.Text.Trim();
            var vehicle = cbVehicle.Text.Trim();
            var vehicle_no = txtVehicleNo.Text.Trim();
            var total = txtTotal.Text.Trim();
            var come_from = cbComeFrom.Text.Trim();
            var version = File.ReadLines("./config/version.txt").First();

            if (cid.Length == 0)
            {
                MessageBox.Show("เลขบัตร ต้องไม่เป็นค่าว่าง");
                txtCid.Focus();
                return;
            }

            if (fullname.Length == 0)
            {
                MessageBox.Show("ชื่อ-นามสกุล ต้องไม่เป็นค่าว่าง");
                txtFullName.Focus();
                return;
            }

            if (addr.Length == 0)
            {
                MessageBox.Show("ที่อยู่ ต้องไม่เป็นค่าว่าง");
                txtAddr.Focus();
                return;
            }
            if (tel.Length == 0)
            {
                MessageBox.Show("เบอร์โทร ต้องไม่เป็นค่าว่าง");
                txtTel.Focus();
                return;
            }
            if (vehicle.Length == 0)
            {
                MessageBox.Show("พาหนะ ต้องไม่เป็นค่าว่าง");
                cbVehicle.Focus();
                return;
            }

            if (vehicle_no.Length == 0)
            {
                MessageBox.Show("เลขทะเบียน ต้องไม่เป็นค่าว่าง");
                txtVehicleNo.Focus();
                return;
            }

            FrmQt f = new FrmQt(cid, fullname, sex, birth, addr, tel, vehicle, vehicle_no, total, come_from, card, version);
            f.ShowDialog(this);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            var card = "ฟ้า";

            var cid = txtCid.Text.Trim();
            var fullname = txtFullName.Text.Trim();
            var sex = cbSex.Text.Trim();
            var birth = txtBirth.Text.Trim();
            var addr = txtAddr.Text.Trim();
            var tel = txtTel.Text.Trim();
            var vehicle = cbVehicle.Text.Trim();
            var vehicle_no = txtVehicleNo.Text.Trim();
            var total = txtTotal.Text.Trim();
            var come_from = cbComeFrom.Text.Trim();
            var version = File.ReadLines("./config/version.txt").First();

            if (cid.Length == 0)
            {
                MessageBox.Show("เลขบัตร ต้องไม่เป็นค่าว่าง");
                txtCid.Focus();
                return;
            }

            if (fullname.Length == 0)
            {
                MessageBox.Show("ชื่อ-นามสกุล ต้องไม่เป็นค่าว่าง");
                txtFullName.Focus();
                return;
            }

            if (addr.Length == 0)
            {
                MessageBox.Show("ที่อยู่ ต้องไม่เป็นค่าว่าง");
                txtAddr.Focus();
                return;
            }
            if (tel.Length == 0)
            {
                MessageBox.Show("เบอร์โทร ต้องไม่เป็นค่าว่าง");
                txtTel.Focus();
                return;
            }
            if (vehicle.Length == 0)
            {
                MessageBox.Show("พาหนะ ต้องไม่เป็นค่าว่าง");
                cbVehicle.Focus();
                return;
            }

            if (vehicle_no.Length == 0)
            {
                MessageBox.Show("เลขทะเบียน ต้องไม่เป็นค่าว่าง");
                txtVehicleNo.Focus();
                return;
            }

            FrmQt f = new FrmQt(cid, fullname, sex, birth, addr, tel, vehicle, vehicle_no, total, come_from, card, version);
            f.ShowDialog(this);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var card = "ขาว";

            var cid = txtCid.Text.Trim();
            var fullname = txtFullName.Text.Trim();
            var sex = cbSex.Text.Trim();
            var birth = txtBirth.Text.Trim();
            var addr = txtAddr.Text.Trim();
            var tel = txtTel.Text.Trim();
            var vehicle = cbVehicle.Text.Trim();
            var vehicle_no = txtVehicleNo.Text.Trim();
            var total = txtTotal.Text.Trim();
            var come_from = cbComeFrom.Text.Trim();
            var version = File.ReadLines("./config/version.txt").First();

            if (cid.Length == 0)
            {
                MessageBox.Show("เลขบัตร ต้องไม่เป็นค่าว่าง");
                txtCid.Focus();
                return;
            }

            if (fullname.Length == 0)
            {
                MessageBox.Show("ชื่อ-นามสกุล ต้องไม่เป็นค่าว่าง");
                txtFullName.Focus();
                return;
            }

            if (addr.Length == 0)
            {
                MessageBox.Show("ที่อยู่ ต้องไม่เป็นค่าว่าง");
                txtAddr.Focus();
                return;
            }
            if (tel.Length == 0)
            {
                MessageBox.Show("เบอร์โทร ต้องไม่เป็นค่าว่าง");
                txtTel.Focus();
                return;
            }
            if (vehicle.Length == 0)
            {
                MessageBox.Show("พาหนะ ต้องไม่เป็นค่าว่าง");
                cbVehicle.Focus();
                return;
            }

            if (vehicle_no.Length == 0)
            {
                MessageBox.Show("เลขทะเบียน ต้องไม่เป็นค่าว่าง");
                txtVehicleNo.Focus();
                return;
            }

            FrmQt f = new FrmQt(cid, fullname, sex, birth, addr, tel, vehicle, vehicle_no, total, come_from, card, version);
            f.ShowDialog(this);
        }

        private void txtTotal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Control ctl;
                ctl = (Control)sender;
                ctl.Parent.SelectNextControl(ActiveControl, true, true, true, true);
                //txtQtDateBegin.SelectAll();
            }
        }

       

        private void button7_Click(object sender, EventArgs e)
        {
            string version = File.ReadLines("./config/version.txt").First();
            var url = $"http://covid19.plkhealth.go.th/saveplk/web/index.php?r=covid/default/index&version={version}";
            System.Diagnostics.Process.Start(url);
        }

        private void cbComeFrom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                cbComeFrom.SelectionStart = cbComeFrom.Text.Length;
                cbComeFrom.SelectionLength = 0;
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
    }
}
