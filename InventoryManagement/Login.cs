using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryManagement
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private string connectionString = ConfigurationManager.ConnectionStrings["InventoryDb"].ConnectionString;
        private SqlConnection GetConnection()
        {
            // Sử dụng ConfigurationManager để lấy chuỗi kết nối từ App.config
            string connectionString = ConfigurationManager.ConnectionStrings["InventoryDb"].ConnectionString;
            return new SqlConnection(connectionString);
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPassword.Text;
            string type = cbType.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                 MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(type))
            {
                MessageBox.Show("Vui lòng chọn phân quyền.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection connection = GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = "SELECT MemberID, UserName, FirstName, LastName, YearOfBirth, Gender, IdentityID, Address, PhoneNumber, DateAccept, Type, Status FROM acctab WHERE UserName = @UserName AND Password = @Password AND Type=@Type";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@UserName", username);
                        cmd.Parameters.AddWithValue("@Password", password);
                        cmd.Parameters.AddWithValue("@Type", type);

                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            string memberId = reader["MemberID"].ToString();
                            string userName = reader["UserName"].ToString();
                            string firstName = reader["FirstName"].ToString();
                            string lastName = reader["LastName"].ToString();
                            string yearofBirth = reader["YearOfBirth"].ToString();
                            string gender = reader["Gender"].ToString();
                            string identityId = reader["IdentityID"].ToString();
                            string address = reader["Address"].ToString();
                            string phone = reader["PhoneNumber"].ToString();
                            string dateAccept = reader["DateAccept"].ToString();
                            string Type = reader["Type"].ToString();
                            string status = reader["Status"].ToString();

                            if (status == "Đã thôi việc")
                            {
                                MessageBox.Show("Tài khoản này đã ngừng hoạt động.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return; // không cho phép đăng nhập
                            }
                            if (type =="Nhân viên")
                            {
                                Main mainForm = new Main(memberId, userName, firstName, lastName, yearofBirth, gender, identityId, address, phone, dateAccept, Type, status);
                                this.Hide(); // Ẩn form Login
                                mainForm.ShowDialog();
                                this.Close(); // Đóng form Login sau khi đăng nhập thành công
                            }
                            // Mở form Main và truyền dữ liệu vào
                            else if (type == "Quản trị")
                            {
                                this.Hide();
                                Admin adminForm = new Admin(memberId, userName, firstName, lastName, yearofBirth, gender, identityId, address, phone, dateAccept, Type, status);
                                adminForm.ShowDialog();
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Thông tin đăng nhập không chính xác. Hãy kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
       
    }
}
