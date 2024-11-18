namespace InventoryManagement
{
    partial class BestSales
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
            this.dgvBestSales = new System.Windows.Forms.DataGridView();
            this.tpname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tquantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ttotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBestSales)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Yellow;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 55);
            this.panel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(235, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sản phẩm bán chạy";
            // 
            // dgvBestSales
            // 
            this.dgvBestSales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBestSales.BackgroundColor = System.Drawing.Color.Lime;
            this.dgvBestSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBestSales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tpname,
            this.tquantity,
            this.ttotal});
            this.dgvBestSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBestSales.Location = new System.Drawing.Point(0, 55);
            this.dgvBestSales.Name = "dgvBestSales";
            this.dgvBestSales.RowHeadersWidth = 51;
            this.dgvBestSales.RowTemplate.Height = 24;
            this.dgvBestSales.Size = new System.Drawing.Size(800, 395);
            this.dgvBestSales.TabIndex = 5;
            // 
            // tpname
            // 
            this.tpname.HeaderText = "Tên sản phẩm";
            this.tpname.MinimumWidth = 6;
            this.tpname.Name = "tpname";
            // 
            // tquantity
            // 
            this.tquantity.FillWeight = 50F;
            this.tquantity.HeaderText = "Số lượng";
            this.tquantity.MinimumWidth = 6;
            this.tquantity.Name = "tquantity";
            // 
            // ttotal
            // 
            this.ttotal.HeaderText = "Tổng doanh thu (VND)";
            this.ttotal.MinimumWidth = 6;
            this.ttotal.Name = "ttotal";
            // 
            // BestSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvBestSales);
            this.Controls.Add(this.panel1);
            this.Name = "BestSales";
            this.Text = "BestSales";
            this.Load += new System.EventHandler(this.BestSales_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBestSales)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvBestSales;
        private System.Windows.Forms.DataGridViewTextBoxColumn tpname;
        private System.Windows.Forms.DataGridViewTextBoxColumn tquantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ttotal;
    }
}