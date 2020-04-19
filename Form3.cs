using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThaiNationalIDCard;

namespace SavePLK
{
    public partial class Form3 : Form
    {
        ThaiIDCard idcard;
        String _addr;
        String _tumbol;
        String _amphur;
        public Form3()
        {
            InitializeComponent();
            idcard = new ThaiIDCard();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Personal p = idcard.readAll();
            if (p != null)
            {

                _addr = p.addrHouseNo + " " + p.addrVillageNo + " " + p.addrRoad + " " + p.addrLane;
                _tumbol = p.addrTambol;
                _amphur = p.addrAmphur;

                txtCid.Text = p.Citizenid;
                txtFullName.Text = p.Th_Prefix + p.Th_Firstname + " " + p.Th_Lastname;
                var sex = p.Sex;
                if (sex == "1")
                {
                    cbSex.Text = "ชาย";
                }
                else
                {
                    cbSex.Text = "หญิง";
                }
                
                var addr = p.Address;
                addr = addr.Replace("หมู่ที่", "ม.");
                addr = addr.Replace("ตำบล", "ต.");
                addr = addr.Replace("อำเภอ", "อ.");
                addr = addr.Replace("จังหวัด", "จ.");
                txtAddr.Text = addr;
                

                txtTel.Focus();

                Console.WriteLine(p.Birthday);
                //Console.WriteLine(p.Birthday.ToShortDateString());

                try
                {
                    txtBirth.Text = p.Birthday.Date.ToShortDateString();
                }
                catch (FormatException exp)
                {
                    MessageBox.Show(exp.Message);
                    return;
                }


            }
            else if (idcard.ErrorCode() > 0)
            {

                MessageBox.Show("ไม่สามารถอ่านบัตรได้ / กรุณาเสียบบัตรอีกครั้ง");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtAddr.Clear();
            txtAddr.Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string version = File.ReadLines("./config/version.txt").First();
            var url = $"http://ttm.plkhealth.go.th/saveplk/web/index.php?r=covid/via&version={version}";
            System.Diagnostics.Process.Start(url);
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

        private void button4_Click(object sender, EventArgs e)
        {

            if (txtStation.Text.Trim() == "000")
            {
                MessageBox.Show("กรุณาตั้งค่ารหัสประจำด่านตรวจ รายละเอียดโทร 055-252052 ต่อ 454");
                return;
            }

            string api = File.ReadLines("./config/api.txt").First();

            if (api == "000")
            {
                MessageBox.Show("กรุณาตั้งค่าช่องทางส่งข้อมูล รายละเอียดโทร 055-252052 ต่อ 454");
                return;
            }


            if (txtCid.Text.Trim().Length == 0)
            {
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

            if (txtComeFrom.Text.Trim().Length == 0)
            {
                MessageBox.Show("มาจาก ต้องไม่เป็นค่าว่าง");
                txtComeFrom.Focus();
                return;
            }

            if (cbVehicle.Text.Trim().Length == 0)
            {
                MessageBox.Show("ยานพาหนะ ต้องไม่เป็นค่าว่าง");
                cbVehicle.Focus();
                return;
            }

            if (txtVehicleNo.Text.Trim().Length == 0)
            {
                MessageBox.Show("ทะเบียน ต้องไม่เป็นค่าว่าง");
                txtVehicleNo.Focus();
                return;
            }





            if (cbViaType.Text.Trim().Length == 0)
            {
                //MessageBox.Show("เหตุผลที่มา ต้องไม่เป็นค่าว่าง");
                //cbViaType.Focus();
                //return;
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

            var request = new RestRequest("via");
            request.AddParameter("cid", txtCid.Text.Trim());
            request.AddParameter("fullname", txtFullName.Text.Trim());
            request.AddParameter("sex", cbSex.Text.Trim());
            request.AddParameter("birth", CheckDate(txtBirth.Text));
            request.AddParameter("addr", txtAddr.Text.Trim());
            request.AddParameter("tel", txtTel.Text.Trim());
            request.AddParameter("come_from", txtComeFrom.Text.Trim());
            request.AddParameter("vehicle", cbVehicle.Text.Trim());
            request.AddParameter("vehicle_no", txtVehicleNo.Text.Trim());

            request.AddParameter("total", txtTotal.Text.Trim());
            request.AddParameter("via_type", cbViaType.Text.Trim());
            request.AddParameter("stay_at", txtStayAt.Text.Trim());
            request.AddParameter("destination", txtDestination.Text.Trim());
            request.AddParameter("date_back", CheckDate(txtDateBack.Text));




            request.AddParameter("temp", txtTemp.Text.Trim());
            request.AddParameter("symptom", txtSymptom.Text.Trim());
            request.AddParameter("note", txtNote.Text.Trim());
            request.AddParameter("station", txtStation.Text.Trim());

            var response = client.Post(request);
            var content = response.Content; // raw content as string
            if (string.IsNullOrEmpty(content))
            {
                

                using (StreamWriter w = File.AppendText("data/via.txt"))
                {
                    var cid = txtCid.Text.Trim();
                    var fullname = txtFullName.Text.Trim();
                    var sex = cbSex.Text.Trim();
                    var birth = CheckDate(txtBirth.Text);
                    var addr = txtAddr.Text.Trim();
                    var tel =  txtTel.Text.Trim();
                    var come_from = txtComeFrom.Text.Trim();
                    var vehicle = cbVehicle.Text.Trim();
                    var vehicle_no = txtVehicleNo.Text.Trim();

                    var total = txtTotal.Text.Trim();
                    var via_type =  cbViaType.Text.Trim();
                    var stay_at = txtStayAt.Text.Trim();
                    var destination = txtDestination.Text.Trim();
                    var date_back = CheckDate(txtDateBack.Text);
                                                         
                    var temp =  txtTemp.Text.Trim();
                    var symptom = txtSymptom.Text.Trim();
                    var note = txtNote.Text.Trim();
                    var station = txtStation.Text.Trim();

                    var d_record = CheckDate(DateTime.UtcNow.ToShortDateString()) + " " + DateTime.Now.ToString("HH:mm:ss");
                    var d_update = CheckDate(DateTime.UtcNow.ToShortDateString()) + " " + DateTime.Now.ToString("HH:mm:ss");

                    var data1 = $"null,{cid},{fullname},{sex},{birth},{addr},{tel},{come_from},{vehicle},{vehicle_no}";
                    var data2 = $",{total},{via_type},{stay_at},{destination},{date_back}";
                    var data3 = $",{temp},{symptom},{note},{station}";
                    var data4 = $",{d_record},{d_update}";

                    var data = data1 + data2 + data3 + data4;

                    w.Write(data);
                    w.Write("\r\n");

                }

                MessageBox.Show("ไม่สำเร็จ..เชื่อมต่อกับเครื่องแม่ข่ายไม่ได้...บันทึก offline แล้ว");
                clearForm();
                return;
            }
            if (content != "1")
            {
                MessageBox.Show("ไม่สำเร็จ..มีข้อผิดพลาด");
                return;
            }
            MessageBox.Show("ส่งข้อมูลสำเร็จ!!!");

            clearForm();

        }

        void clearForm() {

            ClearAllText(this);

            cbSex.Text = "";
            cbVehicle.Text = "";
            cbViaType.Text = "";

            txtCid.Clear();
            txtBirth.Clear();

            txtCid.Focus();

            var d = DateTime.UtcNow.ToShortDateString();
            txtDateBack.Text = d;
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

        private void Form3_Load(object sender, EventArgs e)
        {
            var d = DateTime.UtcNow.ToShortDateString();
            txtDateBack.Text = d;

            string key = File.ReadLines("./config/key.txt").First();
            Console.WriteLine(key);
            txtStation.Text = key;

            AutoCompleteStringCollection prov = new AutoCompleteStringCollection();

            string[] provs = File.ReadAllLines("./config/prov.txt");
            foreach (string line in provs)
            {

                Console.WriteLine(line);
                prov.Add(line);
            }
            txtComeFrom.AutoCompleteCustomSource = prov;
            txtDestination.AutoCompleteCustomSource = prov;


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
            }
        }

        private void txtTotal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Control ctl;
                ctl = (Control)sender;
                ctl.Parent.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void txtViaType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Control ctl;
                ctl = (Control)sender;
                ctl.Parent.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void txtDestination_KeyDown(object sender, KeyEventArgs e)
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

        private void txtStayAt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Control ctl;
                ctl = (Control)sender;
                ctl.Parent.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            File.Copy("data/via.txt", "via_.txt",true);
            Process.Start("notepad.exe", "via_.txt");
        }
    }
}
