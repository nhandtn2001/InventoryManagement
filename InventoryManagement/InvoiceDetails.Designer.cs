namespace InventoryManagement
{
    partial class InvoiceDetails
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
            this.label16 = new System.Windows.Forms.Label();
            this.lbDate = new System.Windows.Forms.Label();
            this.lbAddress = new System.Windows.Forms.Label();
            this.lbCustomerName = new System.Windows.Forms.Label();
            this.lbTotalPrice = new System.Windows.Forms.Label();
            this.lbCreate = new System.Windows.Forms.Label();
            this.lbPhone = new System.Windows.Forms.Label();
            this.lbDeliveryID = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.tdetailid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tdeliveryid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tquantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ttotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Yellow;
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.lbDate);
            this.panel1.Controls.Add(this.lbAddress);
            this.panel1.Controls.Add(this.lbCustomerName);
            this.panel1.Controls.Add(this.lbTotalPrice);
            this.panel1.Controls.Add(this.lbCreate);
            this.panel1.Controls.Add(this.lbPhone);
            this.panel1.Controls.Add(this.lbDeliveryID);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1070, 282);
            this.panel1.TabIndex = 5;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(20, 255);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(166, 19);
            this.label16.TabIndex = 17;
            this.label16.Text = "== Chi tiết hoá đơn ==";
            // 
            // lbDate
            // 
            this.lbDate.AutoSize = true;
            this.lbDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDate.Location = new System.Drawing.Point(675, 147);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(50, 25);
            this.lbDate.TabIndex = 16;
            this.lbDate.Text = "date";
            // 
            // lbAddress
            // 
            this.lbAddress.AutoSize = true;
            this.lbAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAddress.Location = new System.Drawing.Point(675, 108);
            this.lbAddress.Name = "lbAddress";
            this.lbAddress.Size = new System.Drawing.Size(82, 25);
            this.lbAddress.TabIndex = 15;
            this.lbAddress.Text = "address";
            // 
            // lbCustomerName
            // 
            this.lbCustomerName.AutoSize = true;
            this.lbCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCustomerName.Location = new System.Drawing.Point(675, 65);
            this.lbCustomerName.Name = "lbCustomerName";
            this.lbCustomerName.Size = new System.Drawing.Size(144, 25);
            this.lbCustomerName.TabIndex = 14;
            this.lbCustomerName.Text = "customerName";
            // 
            // lbTotalPrice
            // 
            this.lbTotalPrice.AutoSize = true;
            this.lbTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalPrice.Location = new System.Drawing.Point(205, 198);
            this.lbTotalPrice.Name = "lbTotalPrice";
            this.lbTotalPrice.Size = new System.Drawing.Size(90, 25);
            this.lbTotalPrice.TabIndex = 13;
            this.lbTotalPrice.Text = "totalprice";
            // 
            // lbCreate
            // 
            this.lbCreate.AutoSize = true;
            this.lbCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCreate.Location = new System.Drawing.Point(205, 147);
            this.lbCreate.Name = "lbCreate";
            this.lbCreate.Size = new System.Drawing.Size(128, 25);
            this.lbCreate.TabIndex = 12;
            this.lbCreate.Text = "createPerson";
            // 
            // lbPhone
            // 
            this.lbPhone.AutoSize = true;
            this.lbPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPhone.Location = new System.Drawing.Point(205, 108);
            this.lbPhone.Name = "lbPhone";
            this.lbPhone.Size = new System.Drawing.Size(67, 25);
            this.lbPhone.TabIndex = 11;
            this.lbPhone.Text = "phone";
            // 
            // lbDeliveryID
            // 
            this.lbDeliveryID.AutoSize = true;
            this.lbDeliveryID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDeliveryID.Location = new System.Drawing.Point(205, 65);
            this.lbDeliveryID.Name = "lbDeliveryID";
            this.lbDeliveryID.Size = new System.Drawing.Size(98, 25);
            this.lbDeliveryID.TabIndex = 10;
            this.lbDeliveryID.Text = "deliveryID";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(51, 198);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 25);
            this.label8.TabIndex = 9;
            this.label8.Text = "Tổng giá:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(527, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 25);
            this.label7.TabIndex = 8;
            this.label7.Text = "Tên khách:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(527, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 25);
            this.label6.TabIndex = 7;
            this.label6.Text = "Ngày lập đơn:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(51, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 25);
            this.label5.TabIndex = 6;
            this.label5.Text = "SĐT:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(51, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Người lập đơn:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(527, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Địa chỉ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(51, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mã đơn:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(412, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Xem chi tiết hoá đơn";
            // 
            // dgvDetails
            // 
            this.dgvDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tdetailid,
            this.tdeliveryid,
            this.tpname,
            this.tprice,
            this.tquantity,
            this.ttotal});
            this.dgvDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetails.Location = new System.Drawing.Point(0, 282);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.ReadOnly = true;
            this.dgvDetails.RowHeadersWidth = 51;
            this.dgvDetails.RowTemplate.Height = 24;
            this.dgvDetails.Size = new System.Drawing.Size(1070, 239);
            this.dgvDetails.TabIndex = 8;
            // 
            // tdetailid
            // 
            this.tdetailid.FillWeight = 50F;
            this.tdetailid.HeaderText = "Mã CTHD";
            this.tdetailid.MinimumWidth = 6;
            this.tdetailid.Name = "tdetailid";
            this.tdetailid.ReadOnly = true;
            // 
            // tdeliveryid
            // 
            this.tdeliveryid.FillWeight = 50F;
            this.tdeliveryid.HeaderText = "Mã đơn xuất";
            this.tdeliveryid.MinimumWidth = 6;
            this.tdeliveryid.Name = "tdeliveryid";
            this.tdeliveryid.ReadOnly = true;
            // 
            // tpname
            // 
            this.tpname.HeaderText = "Tên sản phẩm";
            this.tpname.MinimumWidth = 6;
            this.tpname.Name = "tpname";
            this.tpname.ReadOnly = true;
            // 
            // tprice
            // 
            this.tprice.FillWeight = 50F;
            this.tprice.HeaderText = "Đơn giá (VND)";
            this.tprice.MinimumWidth = 6;
            this.tprice.Name = "tprice";
            this.tprice.ReadOnly = true;
            // 
            // tquantity
            // 
            this.tquantity.FillWeight = 40F;
            this.tquantity.HeaderText = "Số lượng";
            this.tquantity.MinimumWidth = 6;
            this.tquantity.Name = "tquantity";
            this.tquantity.ReadOnly = true;
            // 
            // ttotal
            // 
            this.ttotal.FillWeight = 80F;
            this.ttotal.HeaderText = "Thành tiền (VND)";
            this.ttotal.MinimumWidth = 6;
            this.ttotal.Name = "ttotal";
            this.ttotal.ReadOnly = true;
            // 
            // InvoiceDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 521);
            this.Controls.Add(this.dgvDetails);
            this.Controls.Add(this.panel1);
            this.Name = "InvoiceDetails";
            this.Text = "InvoiceDetails";
            this.Load += new System.EventHandler(this.InvoiceDetails_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbDate;
        private System.Windows.Forms.Label lbAddress;
        private System.Windows.Forms.Label lbCustomerName;
        private System.Windows.Forms.Label lbTotalPrice;
        private System.Windows.Forms.Label lbCreate;
        private System.Windows.Forms.Label lbPhone;
        private System.Windows.Forms.Label lbDeliveryID;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridViewTextBoxColumn tdetailid;
        private System.Windows.Forms.DataGridViewTextBoxColumn tdeliveryid;
        private System.Windows.Forms.DataGridViewTextBoxColumn tpname;
        private System.Windows.Forms.DataGridViewTextBoxColumn tprice;
        private System.Windows.Forms.DataGridViewTextBoxColumn tquantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ttotal;
    }
}