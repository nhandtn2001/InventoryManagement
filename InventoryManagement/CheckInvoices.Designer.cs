namespace InventoryManagement
{
    partial class CheckInvoices
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
            this.btnDelete = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDeliveryID = new System.Windows.Forms.TextBox();
            this.btnCheckDetails = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvInvoices = new System.Windows.Forms.DataGridView();
            this.tid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tcname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tphone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tcreate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ttotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelDDH = new System.Windows.Forms.Label();
            this.labelTG = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoices)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Aqua;
            this.panel1.Controls.Add(this.labelDDH);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.labelTG);
            this.panel1.Controls.Add(this.txtDeliveryID);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.btnCheckDetails);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1054, 134);
            this.panel1.TabIndex = 4;
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(458, 71);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(92, 34);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Xoá";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mã đơn";
            // 
            // txtDeliveryID
            // 
            this.txtDeliveryID.Location = new System.Drawing.Point(83, 74);
            this.txtDeliveryID.Name = "txtDeliveryID";
            this.txtDeliveryID.Size = new System.Drawing.Size(177, 22);
            this.txtDeliveryID.TabIndex = 2;
            // 
            // btnCheckDetails
            // 
            this.btnCheckDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckDetails.Location = new System.Drawing.Point(292, 71);
            this.btnCheckDetails.Name = "btnCheckDetails";
            this.btnCheckDetails.Size = new System.Drawing.Size(147, 34);
            this.btnCheckDetails.TabIndex = 1;
            this.btnCheckDetails.Text = "Xem chi tiết";
            this.btnCheckDetails.UseVisualStyleBackColor = true;
            this.btnCheckDetails.Click += new System.EventHandler(this.btnCheckDetails_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(385, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Xem hoá đơn xuất ";
            // 
            // dgvInvoices
            // 
            this.dgvInvoices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInvoices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tid,
            this.tcname,
            this.tphone,
            this.taddress,
            this.tcreate,
            this.tdate,
            this.ttotal});
            this.dgvInvoices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInvoices.Location = new System.Drawing.Point(0, 134);
            this.dgvInvoices.Name = "dgvInvoices";
            this.dgvInvoices.ReadOnly = true;
            this.dgvInvoices.RowHeadersWidth = 51;
            this.dgvInvoices.RowTemplate.Height = 24;
            this.dgvInvoices.Size = new System.Drawing.Size(1054, 316);
            this.dgvInvoices.TabIndex = 5;
            // 
            // tid
            // 
            this.tid.FillWeight = 85F;
            this.tid.HeaderText = "Mã hoá đơn";
            this.tid.MinimumWidth = 6;
            this.tid.Name = "tid";
            this.tid.ReadOnly = true;
            // 
            // tcname
            // 
            this.tcname.HeaderText = "Tên khách";
            this.tcname.MinimumWidth = 6;
            this.tcname.Name = "tcname";
            this.tcname.ReadOnly = true;
            // 
            // tphone
            // 
            this.tphone.HeaderText = "Số điện thoại";
            this.tphone.MinimumWidth = 6;
            this.tphone.Name = "tphone";
            this.tphone.ReadOnly = true;
            // 
            // taddress
            // 
            this.taddress.HeaderText = "Địa chỉ";
            this.taddress.MinimumWidth = 6;
            this.taddress.Name = "taddress";
            this.taddress.ReadOnly = true;
            // 
            // tcreate
            // 
            this.tcreate.HeaderText = "Người lập đơn";
            this.tcreate.MinimumWidth = 6;
            this.tcreate.Name = "tcreate";
            this.tcreate.ReadOnly = true;
            // 
            // tdate
            // 
            this.tdate.HeaderText = "Ngày lập đơn";
            this.tdate.MinimumWidth = 6;
            this.tdate.Name = "tdate";
            this.tdate.ReadOnly = true;
            // 
            // ttotal
            // 
            this.ttotal.HeaderText = "Tổng giá (VND)";
            this.ttotal.MinimumWidth = 6;
            this.ttotal.Name = "ttotal";
            this.ttotal.ReadOnly = true;
            // 
            // labelDDH
            // 
            this.labelDDH.AutoSize = true;
            this.labelDDH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDDH.Location = new System.Drawing.Point(795, 53);
            this.labelDDH.Name = "labelDDH";
            this.labelDDH.Size = new System.Drawing.Size(19, 20);
            this.labelDDH.TabIndex = 30;
            this.labelDDH.Text = "0";
            // 
            // labelTG
            // 
            this.labelTG.AutoSize = true;
            this.labelTG.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTG.Location = new System.Drawing.Point(712, 95);
            this.labelTG.Name = "labelTG";
            this.labelTG.Size = new System.Drawing.Size(19, 20);
            this.labelTG.TabIndex = 28;
            this.labelTG.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(610, 53);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(160, 20);
            this.label10.TabIndex = 26;
            this.label10.Text = "Số đơn xuất hàng:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(610, 95);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 20);
            this.label9.TabIndex = 25;
            this.label9.Text = "Tổng giá:";
            // 
            // CheckInvoices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 450);
            this.Controls.Add(this.dgvInvoices);
            this.Controls.Add(this.panel1);
            this.Name = "CheckInvoices";
            this.Text = "CheckInvoices";
            this.Load += new System.EventHandler(this.CheckInvoices_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoices)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvInvoices;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDeliveryID;
        private System.Windows.Forms.Button btnCheckDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn tid;
        private System.Windows.Forms.DataGridViewTextBoxColumn tcname;
        private System.Windows.Forms.DataGridViewTextBoxColumn tphone;
        private System.Windows.Forms.DataGridViewTextBoxColumn taddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn tcreate;
        private System.Windows.Forms.DataGridViewTextBoxColumn tdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ttotal;
        private System.Windows.Forms.Label labelDDH;
        private System.Windows.Forms.Label labelTG;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
    }
}