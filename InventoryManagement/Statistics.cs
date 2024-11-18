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
    public partial class Statistics : Form
    {
        public Statistics()
        {
            InitializeComponent();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            // Lấy giá trị từ DateTimePicker
            DateTime startDate = dtpStart.Value.Date;
            DateTime endDate = dtpEnd.Value.Date;

            // Kiểm tra ngày kết thúc phải lớn hơn hoặc bằng ngày bắt đầu
            if (startDate > endDate)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Thực hiện truy vấn SQL để lấy dữ liệu
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["InventoryDb"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Câu truy vấn SQL
                    string query = @"
                SELECT 
                    (SELECT COUNT(*) FROM invtab WHERE Date BETWEEN @startDate AND @endDate) AS SoDonNhap,
                    (SELECT COUNT(*) FROM devtab WHERE Date BETWEEN @startDate AND @endDate) AS SoDonXuat,
                    (SELECT ISNULL(SUM(TotalPrice), 0) FROM invtab WHERE Date BETWEEN @startDate AND @endDate) AS TongTienNhap,
                    (SELECT ISNULL(SUM(TotalPrice), 0) FROM devtab WHERE Date BETWEEN @startDate AND @endDate) AS TongTienXuat";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@startDate", startDate);
                        cmd.Parameters.AddWithValue("@endDate", endDate);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Hiển thị kết quả lên Label
                                lblSoDonNhap.Text = $"Số đơn nhập:  {reader["SoDonNhap"]}";
                                lblSoDonXuat.Text = $"Số đơn xuất:  {reader["SoDonXuat"]}";
                                lblTongTienNhap.Text = $"Tổng tiền đơn nhập: {Convert.ToDecimal(reader["TongTienNhap"]).ToString("N0")} Đồng";
                                lblTongTienXuat.Text = $"Tổng tiền đơn xuất: {Convert.ToDecimal(reader["TongTienXuat"]).ToString("N0")} Đồng";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
