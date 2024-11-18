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
    public partial class CheckInvoices : Form
    {
        public CheckInvoices()
        {
            InitializeComponent();
            dgvInvoices.CellClick += dgvInvoices_CellClick;
            dgvInvoices.CellFormatting += dgvInvoices_CellFormatting;
        }
        private SqlConnection GetConnection()
        {
            // Sử dụng ConfigurationManager để lấy chuỗi kết nối từ App.config
            string connectionString = ConfigurationManager.ConnectionStrings["InventoryDb"].ConnectionString;
            return new SqlConnection(connectionString);
        }
        public void ShowData()
        {
            using (SqlConnection con = GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [inventorydb].dbo.[devtab] ORDER BY Date DESC", con);
                DataTable table = new DataTable();
                da.Fill(table);
                dgvInvoices.Rows.Clear();
                foreach (DataRow item in table.Rows)
                {
                    int n = dgvInvoices.Rows.Add();
                    dgvInvoices.Rows[n].Cells["tid"].Value = item["DeliveryID"].ToString();
                    dgvInvoices.Rows[n].Cells["tcname"].Value = item["CustomerName"].ToString();
                    dgvInvoices.Rows[n].Cells["tphone"].Value = item["Phone"].ToString();
                    dgvInvoices.Rows[n].Cells["taddress"].Value = item["Address"].ToString();
                    dgvInvoices.Rows[n].Cells["tdate"].Value = Convert.ToDateTime(item["Date"]).ToString("dd/MM/yyyy");
                    dgvInvoices.Rows[n].Cells["tcreate"].Value = item["CreatePerson"].ToString();
                    dgvInvoices.Rows[n].Cells["ttotal"].Value = item["TotalPrice"].ToString();

                }
                if (dgvInvoices.Rows.Count > 0)
                {
                    labelDDH.Text = (dgvInvoices.Rows.Count - 1).ToString();

                    decimal totalPrice = 0;

                    for (int i = 0; i < dgvInvoices.Rows.Count; ++i)
                    {
                        // Kiểm tra nếu giá trị của ô không phải là null trước khi chuyển đổi
                        if (dgvInvoices.Rows[i].Cells["ttotal"].Value != null &&
                            decimal.TryParse(dgvInvoices.Rows[i].Cells["ttotal"].Value.ToString(), out decimal price))
                        {
                            totalPrice += price;
                        }
                    }
                    labelTG.Text = totalPrice.ToString("N0") + " Đồng";

                }
                else
                {
                    labelTG.Text = "0";
                    labelDDH.Text = "0";
                }
            }
        }
        private void dgvInvoices_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Kiểm tra nếu cột là tprice hoặc ttotalprice và khác null
            if (dgvInvoices.Columns[e.ColumnIndex].Name == "ttotal" && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal price))
                {
                    // Định dạng số tiền với dấu phân cách hàng ngàn và thêm " Đồng"
                    e.Value = price.ToString("N0");
                    e.FormattingApplied = true;
                }
            }
        }
        private void dgvInvoices_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvInvoices.SelectedRows.Count > 0)
            {
                // Lấy thông tin của hàng được chọn
                DataGridViewRow selectedRow = dgvInvoices.SelectedRows[0];
                // Hiển thị thông tin vào các TextBox
                txtDeliveryID.Text = selectedRow.Cells["tid"].Value?.ToString();

            }
        }
        private void dgvInvoices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo rằng người dùng đã nhấp vào một hàng hợp lệ
            {
                // Lấy hàng hiện tại từ DataGridView
                DataGridViewRow selectedRow = dgvInvoices.Rows[e.RowIndex];
                // Hiển thị thông tin vào các TextBox
                txtDeliveryID.Text = selectedRow.Cells["tid"].Value?.ToString();
            }
        }
        private bool InvoiceExists(SqlConnection con, string deliveryId)
        {
            string checkQuery = "SELECT COUNT(*) FROM devtab WHERE DeliveryID = @DeliveryID";
            SqlCommand checkCmd = new SqlCommand(checkQuery, con);
            checkCmd.Parameters.AddWithValue("@DeliveryID", deliveryId);
            int count = (int)checkCmd.ExecuteScalar();
            return count > 0;
        }

        private void btnCheckDetails_Click(object sender, EventArgs e)
        {
            string deliveryID = txtDeliveryID.Text.Trim();

            if (string.IsNullOrEmpty(deliveryID))
            {
                MessageBox.Show("Vui lòng nhập mã hóa đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string connectionString = ConfigurationManager.ConnectionStrings["InventoryDb"].ConnectionString;

            // Kiểm tra xem mã hóa đơn có tồn tại trong cơ sở dữ liệu
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM devtab WHERE DeliveryID = @DeliveryID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@DeliveryID", deliveryID);
                    int count = (int)cmd.ExecuteScalar();

                    if (count > 0)
                    {
                        InvoiceDetails invoiceDetailsForm = new InvoiceDetails(deliveryID);
                        invoiceDetailsForm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Mã hóa đơn không tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void CheckInvoices_Load(object sender, EventArgs e)
        {
            ShowData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa hoá đơn này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                using (SqlConnection con = GetConnection())
                {
                    con.Open();
                    // Xóa trong bảng [dettab] trước
                    string sqlQueryDetails = "DELETE FROM [dettab] WHERE [DeliveryID] = @DeliveryID";
                    using (SqlCommand detailcmd = new SqlCommand(sqlQueryDetails, con))
                    {
                        detailcmd.Parameters.AddWithValue("@DeliveryID", txtDeliveryID.Text);
                        detailcmd.ExecuteNonQuery();
                    }
                    // Xóa bảng [devtab] sau
                    string sqlQuery = "DELETE FROM [devtab] WHERE [DeliveryID] = @DeliveryID";
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@DeliveryID", txtDeliveryID.Text);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Hóa đơn đã được xóa.", "Đã xoá", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ShowData();
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa hóa đơn. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
            }
        }
    }
}
