namespace InventoryManagement
{
    partial class Statistics
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.lblTongTienNhap = new System.Windows.Forms.Label();
            this.lblTongTienXuat = new System.Windows.Forms.Label();
            this.lblSoDonNhap = new System.Windows.Forms.Label();
            this.lblSoDonXuat = new System.Windows.Forms.Label();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Fuchsia;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(916, 73);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(361, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thống kê";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(41, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "Từ:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(470, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 29);
            this.label3.TabIndex = 3;
            this.label3.Text = "Đến:";
            // 
            // dtpStart
            // 
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(114, 117);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(239, 22);
            this.dtpStart.TabIndex = 4;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(548, 117);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(239, 22);
            this.dtpEnd.TabIndex = 5;
            // 
            // lblTongTienNhap
            // 
            this.lblTongTienNhap.AutoSize = true;
            this.lblTongTienNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTienNhap.Location = new System.Drawing.Point(396, 192);
            this.lblTongTienNhap.Name = "lblTongTienNhap";
            this.lblTongTienNhap.Size = new System.Drawing.Size(31, 29);
            this.lblTongTienNhap.TabIndex = 10;
            this.lblTongTienNhap.Text = "...";
            // 
            // lblTongTienXuat
            // 
            this.lblTongTienXuat.AutoSize = true;
            this.lblTongTienXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTienXuat.Location = new System.Drawing.Point(396, 259);
            this.lblTongTienXuat.Name = "lblTongTienXuat";
            this.lblTongTienXuat.Size = new System.Drawing.Size(31, 29);
            this.lblTongTienXuat.TabIndex = 11;
            this.lblTongTienXuat.Text = "...";
            // 
            // lblSoDonNhap
            // 
            this.lblSoDonNhap.AutoSize = true;
            this.lblSoDonNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoDonNhap.Location = new System.Drawing.Point(58, 192);
            this.lblSoDonNhap.Name = "lblSoDonNhap";
            this.lblSoDonNhap.Size = new System.Drawing.Size(31, 29);
            this.lblSoDonNhap.TabIndex = 12;
            this.lblSoDonNhap.Text = "...";
            // 
            // lblSoDonXuat
            // 
            this.lblSoDonXuat.AutoSize = true;
            this.lblSoDonXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoDonXuat.Location = new System.Drawing.Point(58, 259);
            this.lblSoDonXuat.Name = "lblSoDonXuat";
            this.lblSoDonXuat.Size = new System.Drawing.Size(31, 29);
            this.lblSoDonXuat.TabIndex = 13;
            this.lblSoDonXuat.Text = "...";
            // 
            // btnThongKe
            // 
            this.btnThongKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongKe.Location = new System.Drawing.Point(366, 368);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(142, 41);
            this.btnThongKe.TabIndex = 14;
            this.btnThongKe.Text = "Xem";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // Statistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(916, 450);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.lblSoDonXuat);
            this.Controls.Add(this.lblSoDonNhap);
            this.Controls.Add(this.lblTongTienXuat);
            this.Controls.Add(this.lblTongTienNhap);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Name = "Statistics";
            this.Text = "Statistics";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label lblTongTienNhap;
        private System.Windows.Forms.Label lblTongTienXuat;
        private System.Windows.Forms.Label lblSoDonNhap;
        private System.Windows.Forms.Label lblSoDonXuat;
        private System.Windows.Forms.Button btnThongKe;
    }
}