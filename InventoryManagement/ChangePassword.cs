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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace InventoryManagement
{
    public partial class ChangePassword : Form
    {
        private string userName; // Biến lưu trữ tên người dùng

        // Constructor nhận vào tên người dùng
        public ChangePassword(string userName)
        {
            InitializeComponent();
            this.userName = userName;
        }

        private SqlConnection GetConnection()
        {
            // Sử dụng ConfigurationManager để lấy chuỗi kết nối từ App.config
            string connectionString = ConfigurationManager.ConnectionStrings["InventoryDb"].ConnectionString;
            return new SqlConnection(connectionString);
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            string currentPassword = txtCurrentPassword.Text;
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            // Kiểm tra mật khẩu mới và xác nhận mật khẩu có khớp không
            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu không khớp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Kiểm tra độ dài và ký tự của mật khẩu mới
            if (newPassword.Length < 6)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (newPassword.Length > 15)
            {
                MessageBox.Show("Mật khẩu phải chỉ chứa tối đa 15 ký tự", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (newPassword.Contains(" "))
            {
                MessageBox.Show("Mật khẩu không chứa khoảng trắng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (SqlConnection connection = GetConnection())
            {
                try
                {
                    connection.Open();

                    // Kiểm tra mật khẩu hiện tại có đúng không
                    string queryCheckPassword = "SELECT COUNT(1) FROM acctab WHERE UserName = @UserName AND Password = @CurrentPassword";
                    using (SqlCommand cmd = new SqlCommand(queryCheckPassword, connection))
                    {
                        cmd.Parameters.AddWithValue("@UserName", userName);
                        cmd.Parameters.AddWithValue("@CurrentPassword", currentPassword);

                        int count = (int)cmd.ExecuteScalar();
                        if (count == 0)
                        {
                            MessageBox.Show("Mật khẩu hiện tại không đúng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Cập nhật mật khẩu mới
                    string queryUpdatePassword = "UPDATE acctab SET Password = @NewPassword WHERE UserName = @UserName";
                    using (SqlCommand cmdUpdate = new SqlCommand(queryUpdatePassword, connection))
                    {
                        cmdUpdate.Parameters.AddWithValue("@NewPassword", newPassword);
                        cmdUpdate.Parameters.AddWithValue("@UserName", userName);

                        int rowsAffected = cmdUpdate.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Đổi mật khẩu thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
