namespace SavePLK
{
    partial class FrmQt
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbQtHomeAmphur = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtQtHomeTambol = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.txtQtHomeAddr = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbQtHotel = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTemp = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtQtDateBegin = new System.Windows.Forms.MaskedTextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LavenderBlush;
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtTemp);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.txtQtDateBegin);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Location = new System.Drawing.Point(12, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(758, 497);
            this.panel1.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Honeydew;
            this.groupBox2.Controls.Add(this.cbQtHomeAmphur);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtQtHomeTambol);
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.txtQtHomeAddr);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox2.Location = new System.Drawing.Point(21, 144);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(718, 167);
            this.groupBox2.TabIndex = 117;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "บ้าน";
            // 
            // cbQtHomeAmphur
            // 
            this.cbQtHomeAmphur.AutoCompleteCustomSource.AddRange(new string[] {
            "เมืองพิษณุโลก",
            "นครไทย",
            "ชาติตระการ",
            "บางระกำ",
            "บางกระทุ่ม",
            "พรหมพิราม",
            "วัดโบสถ์",
            "วังทอง",
            "เนินมะปราง"});
            this.cbQtHomeAmphur.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbQtHomeAmphur.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbQtHomeAmphur.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cbQtHomeAmphur.FormattingEnabled = true;
            this.cbQtHomeAmphur.ItemHeight = 25;
            this.cbQtHomeAmphur.Items.AddRange(new object[] {
            "เมืองพิษณุโลก",
            "นครไทย",
            "ชาติตระการ",
            "บางระกำ",
            "บางกระทุ่ม",
            "พรหมพิราม",
            "วัดโบสถ์",
            "วังทอง",
            "เนินมะปราง"});
            this.cbQtHomeAmphur.Location = new System.Drawing.Point(363, 115);
            this.cbQtHomeAmphur.Name = "cbQtHomeAmphur";
            this.cbQtHomeAmphur.Size = new System.Drawing.Size(340, 33);
            this.cbQtHomeAmphur.TabIndex = 308;
            this.cbQtHomeAmphur.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQtHomeAmphur_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label8.Location = new System.Drawing.Point(359, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 20);
            this.label8.TabIndex = 311;
            this.label8.Text = "อำเภอ : ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label7.Location = new System.Drawing.Point(15, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 20);
            this.label7.TabIndex = 310;
            this.label7.Text = "ตำบล : ";
            // 
            // txtQtHomeTambol
            // 
            this.txtQtHomeTambol.AutoCompleteCustomSource.AddRange(new string[] {
            "กรุงเทพมหานคร",
            "ปทุมธานี",
            "นนทบุรี",
            "สมุทรปราการ",
            "ชลบุรี",
            "เชียงใหม่"});
            this.txtQtHomeTambol.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtQtHomeTambol.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtQtHomeTambol.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtQtHomeTambol.Location = new System.Drawing.Point(19, 115);
            this.txtQtHomeTambol.Name = "txtQtHomeTambol";
            this.txtQtHomeTambol.Size = new System.Drawing.Size(321, 34);
            this.txtQtHomeTambol.TabIndex = 307;
            this.txtQtHomeTambol.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQtHomeTambol_KeyDown);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label25.Location = new System.Drawing.Point(15, 32);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(143, 20);
            this.label25.TabIndex = 309;
            this.label25.Text = "เลขที่ - หมู่ - ถนน : ";
            // 
            // txtQtHomeAddr
            // 
            this.txtQtHomeAddr.AutoCompleteCustomSource.AddRange(new string[] {
            "กรุงเทพมหานคร",
            "ปทุมธานี",
            "นนทบุรี",
            "สมุทรปราการ",
            "ชลบุรี",
            "เชียงใหม่"});
            this.txtQtHomeAddr.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtQtHomeAddr.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtQtHomeAddr.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtQtHomeAddr.Location = new System.Drawing.Point(19, 55);
            this.txtQtHomeAddr.Name = "txtQtHomeAddr";
            this.txtQtHomeAddr.Size = new System.Drawing.Size(684, 34);
            this.txtQtHomeAddr.TabIndex = 306;
            this.txtQtHomeAddr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQtHomeAddr_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Honeydew;
            this.groupBox1.Controls.Add(this.cbQtHotel);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.groupBox1.Location = new System.Drawing.Point(21, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(718, 124);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ที่พักจัดเตรียมไว้ให้";
            // 
            // cbQtHotel
            // 
            this.cbQtHotel.AutoCompleteCustomSource.AddRange(new string[] {
            "รถยนต์",
            "รถจักรยานยนต์",
            "รถโดยสารสาธารณะ",
            "รถไฟ",
            "เครื่องบิน",
            "เรือ",
            "อื่นๆ"});
            this.cbQtHotel.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbQtHotel.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbQtHotel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cbQtHotel.FormattingEnabled = true;
            this.cbQtHotel.Items.AddRange(new object[] {
            "รถยนต์",
            "รถจักรยานยนต์",
            "รถโดยสารสาธารณะ",
            "รถไฟ",
            "เครื่องบิน",
            "เรือ"});
            this.cbQtHotel.Location = new System.Drawing.Point(19, 57);
            this.cbQtHotel.Name = "cbQtHotel";
            this.cbQtHotel.Size = new System.Drawing.Size(684, 33);
            this.cbQtHotel.TabIndex = 1;
            this.cbQtHotel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbQtHotel_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(15, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 306;
            this.label4.Text = "เลือกที่พัก : ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label9.Location = new System.Drawing.Point(16, 420);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(446, 25);
            this.label9.TabIndex = 116;
            this.label9.Text = "*ติดขัดปัญหาการกักตัว กรุณาติดต่อ 055252052 ต่อ 651-5";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(17, 458);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(545, 24);
            this.label2.TabIndex = 115;
            this.label2.Text = "*หากพบผู้มีอุณภูมิ 37.5 ขึ้นไป ให้ปรึกษาเจ้าหน้าที่สาธารณสุขประจำจุดตรวจ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(274, 314);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 25);
            this.label3.TabIndex = 113;
            this.label3.Text = "อุณภูมิร่างกาย : ";
            // 
            // txtTemp
            // 
            this.txtTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtTemp.Location = new System.Drawing.Point(279, 342);
            this.txtTemp.Name = "txtTemp";
            this.txtTemp.Size = new System.Drawing.Size(460, 34);
            this.txtTemp.TabIndex = 6;
            this.txtTemp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTemp_KeyDown);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Red;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(594, 394);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 51);
            this.button1.TabIndex = 7;
            this.button1.Text = "ส่งข้อมูล";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtQtDateBegin
            // 
            this.txtQtDateBegin.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtQtDateBegin.Location = new System.Drawing.Point(22, 342);
            this.txtQtDateBegin.Mask = "00/00/0000";
            this.txtQtDateBegin.Name = "txtQtDateBegin";
            this.txtQtDateBegin.Size = new System.Drawing.Size(238, 34);
            this.txtQtDateBegin.TabIndex = 5;
            this.txtQtDateBegin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtQtDateBegin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQtDateBegin_KeyDown);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label21.Location = new System.Drawing.Point(17, 314);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(200, 25);
            this.label21.TabIndex = 110;
            this.label21.Text = "วันเริ่มเข้าพัก (วว/ดด/พศ):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Red;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(491, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "กักตัว 14 วัน ให้เลือกกักตัวที่โรงแรมหรือบ้าน";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmQt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmQt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmQt";
            this.Load += new System.EventHandler(this.FrmQt_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTemp;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MaskedTextBox txtQtDateBegin;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbQtHotel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbQtHomeAmphur;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtQtHomeTambol;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox txtQtHomeAddr;
    }
}