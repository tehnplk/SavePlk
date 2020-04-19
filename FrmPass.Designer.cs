namespace SavePLK
{
    partial class FrmPass
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTemp = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cbViaType = new System.Windows.Forms.ComboBox();
            this.txtDateBack = new System.Windows.Forms.MaskedTextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Ivory;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtTemp);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.cbViaType);
            this.panel1.Controls.Add(this.txtDateBack);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.label23);
            this.panel1.Location = new System.Drawing.Point(12, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(758, 497);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.Location = new System.Drawing.Point(21, 453);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(551, 25);
            this.label2.TabIndex = 116;
            this.label2.Text = "*หากพบผู้มีอุณภูมิ 37.5 ขึ้นไป ให้ปรึกษาเจ้าหน้าที่สาธารณสุขประจำจุดตรวจ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(22, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 25);
            this.label3.TabIndex = 113;
            this.label3.Text = "อุณภูมิร่างกาย : ";
            // 
            // txtTemp
            // 
            this.txtTemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtTemp.Location = new System.Drawing.Point(26, 223);
            this.txtTemp.Name = "txtTemp";
            this.txtTemp.Size = new System.Drawing.Size(546, 34);
            this.txtTemp.TabIndex = 3;
            this.txtTemp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTemp_KeyDown);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.button1.Location = new System.Drawing.Point(423, 273);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 51);
            this.button1.TabIndex = 4;
            this.button1.Text = "ส่งข้อมูล";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // cbViaType
            // 
            this.cbViaType.AutoCompleteCustomSource.AddRange(new string[] {
            "มาราชการ",
            "มาหาหมอ",
            "ผ่านไปจังหวัดอื่น",
            "อื่น"});
            this.cbViaType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbViaType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cbViaType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cbViaType.FormattingEnabled = true;
            this.cbViaType.Items.AddRange(new object[] {
            "มาราชการ",
            "มาหาหมอ",
            "ผ่านไปจังหวัดอื่น",
            "อื่นๆ"});
            this.cbViaType.Location = new System.Drawing.Point(26, 45);
            this.cbViaType.Name = "cbViaType";
            this.cbViaType.Size = new System.Drawing.Size(546, 33);
            this.cbViaType.TabIndex = 1;
            this.cbViaType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbViaType_KeyDown);
            // 
            // txtDateBack
            // 
            this.txtDateBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtDateBack.Location = new System.Drawing.Point(26, 130);
            this.txtDateBack.Mask = "00/00/0000";
            this.txtDateBack.Name = "txtDateBack";
            this.txtDateBack.Size = new System.Drawing.Size(546, 34);
            this.txtDateBack.TabIndex = 2;
            this.txtDateBack.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDateBack.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDateBack_KeyDown);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label21.Location = new System.Drawing.Point(21, 102);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(303, 25);
            this.label21.TabIndex = 110;
            this.label21.Text = "จะออกจากพิษณุโลกวันไหน (วว/ดด/พศ):";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label23.Location = new System.Drawing.Point(21, 17);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(226, 25);
            this.label23.TabIndex = 108;
            this.label23.Text = "มาทำอะไรที่จังหวัดพิษณุโลก : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "เข้าออกไม่ค้างคืนที่พิษณุโลก";
            // 
            // FrmPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmPass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmPass";
            this.Load += new System.EventHandler(this.FrmPass_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbViaType;
        private System.Windows.Forms.MaskedTextBox txtDateBack;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTemp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}