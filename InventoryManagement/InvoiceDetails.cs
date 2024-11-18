using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagement
{
    public partial class InvoiceDetails : Form
    {
        private string DeliveryID;

        // Constructor nhận mã hóa đơn
        public InvoiceDetails(string deliveryID)
        {
            InitializeComponent();
            DeliveryID = deliveryID;

            // Gọi phương thức để tải thông tin hóa đơn
            LoadInvoiceDetails();
            dgvDetails.CellFormatting += dgvDetails_CellFormatting;
        }
        private void dgvDetails_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Kiểm tra nếu cột là tprice hoặc ttotalprice và khác null
            if (dgvDetails.Columns[e.ColumnIndex].Name == "tprice" && dgvDetails.Columns[e.ColumnIndex].Name == "ttotal" || e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal price))
                {
                    e.Value = price.ToString("N0");
                    e.FormattingApplied = true;
                }
            }
        }
        private void LoadInvoiceDetails()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["InventoryDb"].ConnectionString;
            string queryInvoice = "SELECT * FROM devtab WHERE DeliveryID = @DeliveryID"; // hoá đơn
            string queryDetails = "SELECT * FROM dettab WHERE DeliveryID = @DeliveryID"; // chi tiết hoá đơn

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                // Load thông tin hóa đơn
                using (SqlCommand cmd = new SqlCommand(queryInvoice, conn))
                {
                    cmd.Parameters.AddWithValue("@DeliveryID", DeliveryID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lbDeliveryID.Text = reader["DeliveryID"].ToString();
                            lbCustomerName.Text = reader["CustomerName"].ToString();
                            lbPhone.Text = reader["Phone"].ToString();
                            lbAddress.Text = reader["Address"].ToString();
                            lbDate.Text = DateTime.Parse(reader["Date"].ToString()).ToString("dd/MM/yyyy");
                            lbCreate.Text = reader["CreatePerson"].ToString();
                            lbTotalPrice.Text = string.Format("{0:N0} Đồng", reader["TotalPrice"]);

                        }
                    }
                }
                //Load chi tiết hóa đơn
                using (SqlCommand cmd = new SqlCommand(queryDetails, conn))
                {
                    cmd.Parameters.AddWithValue("@DeliveryID", DeliveryID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        dgvDetails.Rows.Clear(); // Xóa tất cả dòng trước khi thêm mới

                        while (reader.Read())
                        {
                            int rowIndex = dgvDetails.Rows.Add();
                            dgvDetails.Rows[rowIndex].Cells["tdetailid"].Value = reader["DetailID"];
                            dgvDetails.Rows[rowIndex].Cells["tdeliveryid"].Value = reader["DeliveryID"];
                            dgvDetails.Rows[rowIndex].Cells["tpname"].Value = reader["ProductName"];
                            dgvDetails.Rows[rowIndex].Cells["tprice"].Value = reader["Price"];
                            dgvDetails.Rows[rowIndex].Cells["tquantity"].Value = reader["Quantity"];
                            dgvDetails.Rows[rowIndex].Cells["ttotal"].Value = reader["TotalPrice"];

                        }
                    }
                }
            }
        }

        private void InvoiceDetails_Load(object sender, EventArgs e)
        {

        }
    }
}
