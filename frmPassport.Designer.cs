namespace SavePLK
{
    partial class frmPassport
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTel = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVehicleNo = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Ivory;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtNote);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtTel);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtVehicleNo);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label23);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(670, 426);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(117, 229);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 25);
            this.label1.TabIndex = 131;
            this.label1.Text = "หมายเหตุ : ";
            // 
            // txtNote
            // 
            this.txtNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtNote.Location = new System.Drawing.Point(120, 257);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(419, 38);
            this.txtNote.TabIndex = 10;
            this.txtNote.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNote_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Orange;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(67, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(542, 36);
            this.label5.TabIndex = 129;
            this.label5.Text = "บันทึกข้อมูลบัตรผ่านข้ามจังหวัด ณ ด่านขาเข้า";
            // 
            // txtTel
            // 
            this.txtTel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtTel.Location = new System.Drawing.Point(120, 176);
            this.txtTel.Mask = "000-000-0000";
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(421, 38);
            this.txtTel.TabIndex = 6;
            this.txtTel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTel.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtTel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTel_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.Location = new System.Drawing.Point(116, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 25);
            this.label3.TabIndex = 122;
            this.label3.Text = "เบอร์ติดต่อ : ";
            // 
            // txtVehicleNo
            // 
            this.txtVehicleNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtVehicleNo.Location = new System.Drawing.Point(122, 100);
            this.txtVehicleNo.Name = "txtVehicleNo";
            this.txtVehicleNo.Size = new System.Drawing.Size(419, 38);
            this.txtVehicleNo.TabIndex = 5;
            this.txtVehicleNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVehicleNo_KeyDown);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.button1.Location = new System.Drawing.Point(397, 318);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 51);
            this.button1.TabIndex = 11;
            this.button1.Text = "ส่งข้อมูล";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label23.Location = new System.Drawing.Point(116, 72);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(207, 25);
            this.label23.TabIndex = 108;
            this.label23.Text = "หมายเลขทะเบียนพาหนะ : ";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Orange;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(122, 318);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(149, 51);
            this.button2.TabIndex = 132;
            this.button2.Text = "online";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmPassport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 450);
            this.Controls.Add(this.panel1);
            this.Name = "frmPassport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmPassport";
            this.Load += new System.EventHandler(this.frmPassport_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtVehicleNo;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.MaskedTextBox txtTel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Button button2;
    }
}