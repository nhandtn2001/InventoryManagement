namespace InventoryManagement
{
    partial class Inventory
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnNCC = new System.Windows.Forms.Button();
            this.btnProduct = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cbSupplierName = new System.Windows.Forms.ComboBox();
            this.txtProductName = new System.Windows.Forms.ComboBox();
            this.txtReceivePerson = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.labelDDH = new System.Windows.Forms.Label();
            this.labelSL = new System.Windows.Forms.Label();
            this.labelTG = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtInventoryID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvInventory = new System.Windows.Forms.DataGridView();
            this.pid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tcname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tquantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ttotalprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.treceive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1367, 51);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(519, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đơn hàng nhập kho";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panel2.Controls.Add(this.btnNCC);
            this.panel2.Controls.Add(this.btnProduct);
            this.panel2.Controls.Add(this.btnRefresh);
            this.panel2.Controls.Add(this.cbSupplierName);
            this.panel2.Controls.Add(this.txtProductName);
            this.panel2.Controls.Add(this.txtReceivePerson);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.labelDDH);
            this.panel2.Controls.Add(this.labelSL);
            this.panel2.Controls.Add(this.labelTG);
            this.panel2.Controls.Add(this.dtpDate);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtPrice);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.btnLoad);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnUpdate);
            this.panel2.Controls.Add(this.btnAdd);
            this.panel2.Controls.Add(this.txtQuantity);
            this.panel2.Controls.Add(this.txtInventoryID);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 51);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1367, 508);
            this.panel2.TabIndex = 4;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // btnNCC
            // 
            this.btnNCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNCC.ForeColor = System.Drawing.Color.Red;
            this.btnNCC.Location = new System.Drawing.Point(336, 276);
            this.btnNCC.Name = "btnNCC";
            this.btnNCC.Size = new System.Drawing.Size(247, 36);
            this.btnNCC.TabIndex = 31;
            this.btnNCC.Text = "Nhà cung cấp";
            this.btnNCC.UseVisualStyleBackColor = true;
            this.btnNCC.Click += new System.EventHandler(this.btnNCC_Click);
            // 
            // btnProduct
            // 
            this.btnProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProduct.ForeColor = System.Drawing.Color.Red;
            this.btnProduct.Location = new System.Drawing.Point(164, 276);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(147, 36);
            this.btnProduct.TabIndex = 30;
            this.btnProduct.Text = "Sản phẩm";
            this.btnProduct.UseVisualStyleBackColor = true;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(24, 276);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(113, 36);
            this.btnRefresh.TabIndex = 29;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cbSupplierName
            // 
            this.cbSupplierName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSupplierName.FormattingEnabled = true;
            this.cbSupplierName.Location = new System.Drawing.Point(175, 94);
            this.cbSupplierName.Name = "cbSupplierName";
            this.cbSupplierName.Size = new System.Drawing.Size(408, 24);
            this.cbSupplierName.TabIndex = 28;
            // 
            // txtProductName
            // 
            this.txtProductName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtProductName.FormattingEnabled = true;
            this.txtProductName.Location = new System.Drawing.Point(921, 47);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(338, 24);
            this.txtProductName.TabIndex = 27;
            // 
            // txtReceivePerson
            // 
            this.txtReceivePerson.Location = new System.Drawing.Point(175, 188);
            this.txtReceivePerson.Name = "txtReceivePerson";
            this.txtReceivePerson.Size = new System.Drawing.Size(408, 22);
            this.txtReceivePerson.TabIndex = 26;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(20, 190);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(125, 20);
            this.label12.TabIndex = 25;
            this.label12.Text = "Người nhận đơn";
            // 
            // labelDDH
            // 
            this.labelDDH.AutoSize = true;
            this.labelDDH.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDDH.Location = new System.Drawing.Point(1227, 183);
            this.labelDDH.Name = "labelDDH";
            this.labelDDH.Size = new System.Drawing.Size(27, 29);
            this.labelDDH.TabIndex = 24;
            this.labelDDH.Text = "0";
            // 
            // labelSL
            // 
            this.labelSL.AutoSize = true;
            this.labelSL.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSL.Location = new System.Drawing.Point(894, 183);
            this.labelSL.Name = "labelSL";
            this.labelSL.Size = new System.Drawing.Size(27, 29);
            this.labelSL.TabIndex = 23;
            this.labelSL.Text = "0";
            this.labelSL.Click += new System.EventHandler(this.labelSL_Click);
            // 
            // labelTG
            // 
            this.labelTG.AutoSize = true;
            this.labelTG.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTG.Location = new System.Drawing.Point(894, 229);
            this.labelTG.Name = "labelTG";
            this.labelTG.Size = new System.Drawing.Size(27, 29);
            this.labelTG.TabIndex = 22;
            this.labelTG.Text = "0";
            this.labelTG.Click += new System.EventHandler(this.labelTG_Click);
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd/MM/yyyy";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(921, 140);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(341, 22);
            this.dtpDate.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(764, 183);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(124, 29);
            this.label11.TabIndex = 20;
            this.label11.Text = "Số lượng:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(1017, 183);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(194, 29);
            this.label10.TabIndex = 19;
            this.label10.Text = "Đơn nhận hàng:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(764, 229);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(124, 29);
            this.label9.TabIndex = 18;
            this.label9.Text = "Tổng giá:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(19, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 20);
            this.label8.TabIndex = 17;
            this.label8.Text = "Tên NCC";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(773, 140);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "Ngày";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(175, 140);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(408, 22);
            this.txtPrice.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(20, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Đơn giá";
            // 
            // btnLoad
            // 
            this.btnLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.Location = new System.Drawing.Point(470, 228);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(113, 36);
            this.btnLoad.TabIndex = 11;
            this.btnLoad.Text = "Tìm";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(336, 229);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(111, 36);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Xoá";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(164, 229);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(147, 36);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(23, 229);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(114, 36);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(921, 96);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(341, 22);
            this.txtQuantity.TabIndex = 7;
            // 
            // txtInventoryID
            // 
            this.txtInventoryID.Location = new System.Drawing.Point(175, 51);
            this.txtInventoryID.Name = "txtInventoryID";
            this.txtInventoryID.Size = new System.Drawing.Size(408, 22);
            this.txtInventoryID.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(773, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Số lượng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(773, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tên sản phẩm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mã đơn nhập";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(230, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Thông tin đơn nhập hàng";
            // 
            // dgvInventory
            // 
            this.dgvInventory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInventory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pid,
            this.tpname,
            this.tcname,
            this.tprice,
            this.tquantity,
            this.ttotalprice,
            this.tdate,
            this.treceive});
            this.dgvInventory.Location = new System.Drawing.Point(0, 369);
            this.dgvInventory.Name = "dgvInventory";
            this.dgvInventory.ReadOnly = true;
            this.dgvInventory.RowHeadersWidth = 51;
            this.dgvInventory.RowTemplate.Height = 24;
            this.dgvInventory.Size = new System.Drawing.Size(1367, 190);
            this.dgvInventory.TabIndex = 5;
            this.dgvInventory.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInventory_CellContentClick);
            // 
            // pid
            // 
            this.pid.FillWeight = 85F;
            this.pid.HeaderText = "Mã đơn nhập";
            this.pid.MinimumWidth = 6;
            this.pid.Name = "pid";
            this.pid.ReadOnly = true;
            // 
            // tpname
            // 
            this.tpname.FillWeight = 116.0806F;
            this.tpname.HeaderText = "Tên hàng nhập";
            this.tpname.MinimumWidth = 6;
            this.tpname.Name = "tpname";
            this.tpname.ReadOnly = true;
            // 
            // tcname
            // 
            this.tcname.HeaderText = "Tên nhà cung cấp";
            this.tcname.MinimumWidth = 6;
            this.tcname.Name = "tcname";
            this.tcname.ReadOnly = true;
            // 
            // tprice
            // 
            this.tprice.FillWeight = 86.355F;
            this.tprice.HeaderText = "Đơn giá (VND)";
            this.tprice.MinimumWidth = 6;
            this.tprice.Name = "tprice";
            this.tprice.ReadOnly = true;
            // 
            // tquantity
            // 
            this.tquantity.FillWeight = 67.45672F;
            this.tquantity.HeaderText = "Số lượng";
            this.tquantity.MinimumWidth = 6;
            this.tquantity.Name = "tquantity";
            this.tquantity.ReadOnly = true;
            // 
            // ttotalprice
            // 
            this.ttotalprice.HeaderText = "Thành tiền (VND)";
            this.ttotalprice.MinimumWidth = 6;
            this.ttotalprice.Name = "ttotalprice";
            this.ttotalprice.ReadOnly = true;
            // 
            // tdate
            // 
            this.tdate.FillWeight = 118.9163F;
            this.tdate.HeaderText = "Ngày nhận hàng";
            this.tdate.MinimumWidth = 6;
            this.tdate.Name = "tdate";
            this.tdate.ReadOnly = true;
            // 
            // treceive
            // 
            this.treceive.HeaderText = "Người nhận đơn";
            this.treceive.MinimumWidth = 6;
            this.treceive.Name = "treceive";
            this.treceive.ReadOnly = true;
            // 
            // Inventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1367, 559);
            this.Controls.Add(this.dgvInventory);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Inventory";
            this.Text = "Inventory";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtInventoryID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgvInventory;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label labelDDH;
        private System.Windows.Forms.Label labelSL;
        private System.Windows.Forms.Label labelTG;
        private System.Windows.Forms.TextBox txtReceivePerson;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox txtProductName;
        private System.Windows.Forms.ComboBox cbSupplierName;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnNCC;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn pid;
        private System.Windows.Forms.DataGridViewTextBoxColumn tpname;
        private System.Windows.Forms.DataGridViewTextBoxColumn tcname;
        private System.Windows.Forms.DataGridViewTextBoxColumn tprice;
        private System.Windows.Forms.DataGridViewTextBoxColumn tquantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ttotalprice;
        private System.Windows.Forms.DataGridViewTextBoxColumn tdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn treceive;
    }
}