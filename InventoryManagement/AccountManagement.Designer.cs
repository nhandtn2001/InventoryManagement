namespace InventoryManagement
{
    partial class AccountManagement
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
            this.btnUpdate = new System.Windows.Forms.Button();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnFind = new System.Windows.Forms.Button();
            this.txtMemberID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvAccMag = new System.Windows.Forms.DataGridView();
            this.tmemberid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tusername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tlastname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tfirstname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tyearofbirth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tgender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tidentity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tphone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taccept = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tstatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccMag)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Controls.Add(this.btnUpdate);
            this.panel1.Controls.Add(this.cbStatus);
            this.panel1.Controls.Add(this.cbType);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnFind);
            this.panel1.Controls.Add(this.txtMemberID);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1382, 179);
            this.panel1.TabIndex = 2;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(1209, 121);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(129, 32);
            this.btnUpdate.TabIndex = 23;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // cbStatus
            // 
            this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Items.AddRange(new object[] {
            "Đang làm việc",
            "Đã thôi việc"});
            this.cbStatus.Location = new System.Drawing.Point(1047, 127);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(138, 24);
            this.cbStatus.TabIndex = 22;
            // 
            // cbType
            // 
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "Quản trị",
            "Nhân viên"});
            this.cbType.Location = new System.Drawing.Point(774, 127);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(146, 24);
            this.cbType.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Yellow;
            this.label4.Location = new System.Drawing.Point(943, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 20;
            this.label4.Text = "Trạng thái:";
            // 
            // btnFind
            // 
            this.btnFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.Location = new System.Drawing.Point(525, 127);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(104, 32);
            this.btnFind.TabIndex = 19;
            this.btnFind.Text = "Tìm";
            this.btnFind.UseVisualStyleBackColor = true;
            // 
            // txtMemberID
            // 
            this.txtMemberID.Location = new System.Drawing.Point(154, 131);
            this.txtMemberID.Name = "txtMemberID";
            this.txtMemberID.Size = new System.Drawing.Size(341, 22);
            this.txtMemberID.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Yellow;
            this.label3.Location = new System.Drawing.Point(652, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "Phân quyền:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(21, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "Mã thành viên:";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(272, 66);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(102, 36);
            this.btnRefresh.TabIndex = 15;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(146, 66);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(102, 36);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "Xoá";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(23, 66);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(102, 36);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(557, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Quản lý tài khoản";
            // 
            // dgvAccMag
            // 
            this.dgvAccMag.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAccMag.BackgroundColor = System.Drawing.Color.Yellow;
            this.dgvAccMag.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAccMag.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tmemberid,
            this.tusername,
            this.type,
            this.tlastname,
            this.tfirstname,
            this.tyearofbirth,
            this.tgender,
            this.tidentity,
            this.taddress,
            this.tphone,
            this.taccept,
            this.tstatus});
            this.dgvAccMag.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAccMag.Location = new System.Drawing.Point(0, 179);
            this.dgvAccMag.Name = "dgvAccMag";
            this.dgvAccMag.ReadOnly = true;
            this.dgvAccMag.RowHeadersWidth = 51;
            this.dgvAccMag.RowTemplate.Height = 24;
            this.dgvAccMag.Size = new System.Drawing.Size(1382, 346);
            this.dgvAccMag.TabIndex = 3;
            this.dgvAccMag.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAccMag_CellContentClick);
            // 
            // tmemberid
            // 
            this.tmemberid.FillWeight = 94.05569F;
            this.tmemberid.HeaderText = "Mã thành viên";
            this.tmemberid.MinimumWidth = 6;
            this.tmemberid.Name = "tmemberid";
            this.tmemberid.ReadOnly = true;
            // 
            // tusername
            // 
            this.tusername.FillWeight = 90.90318F;
            this.tusername.HeaderText = "Tên tài khoản";
            this.tusername.MinimumWidth = 6;
            this.tusername.Name = "tusername";
            this.tusername.ReadOnly = true;
            // 
            // type
            // 
            this.type.FillWeight = 88.86057F;
            this.type.HeaderText = "Phân quyền";
            this.type.MinimumWidth = 6;
            this.type.Name = "type";
            this.type.ReadOnly = true;
            // 
            // tlastname
            // 
            this.tlastname.FillWeight = 84.56982F;
            this.tlastname.HeaderText = "Họ";
            this.tlastname.MinimumWidth = 6;
            this.tlastname.Name = "tlastname";
            this.tlastname.ReadOnly = true;
            // 
            // tfirstname
            // 
            this.tfirstname.FillWeight = 82.30949F;
            this.tfirstname.HeaderText = "Tên";
            this.tfirstname.MinimumWidth = 6;
            this.tfirstname.Name = "tfirstname";
            this.tfirstname.ReadOnly = true;
            // 
            // tyearofbirth
            // 
            this.tyearofbirth.FillWeight = 80.26176F;
            this.tyearofbirth.HeaderText = "Năm sinh";
            this.tyearofbirth.MinimumWidth = 6;
            this.tyearofbirth.Name = "tyearofbirth";
            this.tyearofbirth.ReadOnly = true;
            // 
            // tgender
            // 
            this.tgender.FillWeight = 78.40663F;
            this.tgender.HeaderText = "Giới tính";
            this.tgender.MinimumWidth = 6;
            this.tgender.Name = "tgender";
            this.tgender.ReadOnly = true;
            // 
            // tidentity
            // 
            this.tidentity.FillWeight = 76.726F;
            this.tidentity.HeaderText = "CCCD";
            this.tidentity.MinimumWidth = 6;
            this.tidentity.Name = "tidentity";
            this.tidentity.ReadOnly = true;
            // 
            // taddress
            // 
            this.taddress.FillWeight = 77.64367F;
            this.taddress.HeaderText = "Địa chỉ";
            this.taddress.MinimumWidth = 6;
            this.taddress.Name = "taddress";
            this.taddress.ReadOnly = true;
            // 
            // tphone
            // 
            this.tphone.FillWeight = 82.54218F;
            this.tphone.HeaderText = "SĐT";
            this.tphone.MinimumWidth = 6;
            this.tphone.Name = "tphone";
            this.tphone.ReadOnly = true;
            // 
            // taccept
            // 
            this.taccept.FillWeight = 82.9128F;
            this.taccept.HeaderText = "Ngày nhận việc";
            this.taccept.MinimumWidth = 6;
            this.taccept.Name = "taccept";
            this.taccept.ReadOnly = true;
            // 
            // tstatus
            // 
            this.tstatus.FillWeight = 80.80833F;
            this.tstatus.HeaderText = "Trạng thái";
            this.tstatus.MinimumWidth = 6;
            this.tstatus.Name = "tstatus";
            this.tstatus.ReadOnly = true;
            // 
            // AccountManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1382, 525);
            this.Controls.Add(this.dgvAccMag);
            this.Controls.Add(this.panel1);
            this.Name = "AccountManagement";
            this.Text = "AccountManagement";
            this.Load += new System.EventHandler(this.AccountManagement_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAccMag)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvAccMag;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn tmemberid;
        private System.Windows.Forms.DataGridViewTextBoxColumn tusername;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn tlastname;
        private System.Windows.Forms.DataGridViewTextBoxColumn tfirstname;
        private System.Windows.Forms.DataGridViewTextBoxColumn tyearofbirth;
        private System.Windows.Forms.DataGridViewTextBoxColumn tgender;
        private System.Windows.Forms.DataGridViewTextBoxColumn tidentity;
        private System.Windows.Forms.DataGridViewTextBoxColumn taddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn tphone;
        private System.Windows.Forms.DataGridViewTextBoxColumn taccept;
        private System.Windows.Forms.DataGridViewTextBoxColumn tstatus;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtMemberID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnFind;
    }
}