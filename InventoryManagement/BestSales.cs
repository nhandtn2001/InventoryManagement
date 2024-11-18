using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagement
{
    public partial class BestSales : Form
    {
        public BestSales()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.BestSales_Load);
            dgvBestSales.CellFormatting += dgvBestSales_CellFormatting;
        }
        private void dgvBestSales_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Kiểm tra nếu cột là tprice hoặc ttotalprice và khác null
            if (dgvBestSales.Columns[e.ColumnIndex].Name == "ttotal" && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal price))
                {
                    e.Value = price.ToString("N0");
                    e.FormattingApplied = true;
                }
            }
        }
        public void LoadBestSellingProducts()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["InventoryDb"].ConnectionString;
            string query = @"
            SELECT 
                ProductName,
                SUM(Quantity) AS TotalQuantity,
                SUM(TotalPrice) AS TotalRevenue
            FROM dettab
                GROUP BY ProductName
                ORDER BY TotalQuantity DESC;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                //Load chi tiết hóa đơn
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dgvBestSales.Rows.Clear(); // Xóa tất cả dòng trước khi thêm mới

                        while (reader.Read())
                        {
                            int rowIndex = dgvBestSales.Rows.Add();
                            dgvBestSales.Rows[rowIndex].Cells["tpname"].Value = reader["ProductName"];
                            dgvBestSales.Rows[rowIndex].Cells["tquantity"].Value = reader["TotalQuantity"];
                            dgvBestSales.Rows[rowIndex].Cells["ttotal"].Value = reader["TotalRevenue"];
                        }
                    }
                }
            }
        }

        private void BestSales_Load(object sender, EventArgs e)
        {
            LoadBestSellingProducts();
        }
    }
}
