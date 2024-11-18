using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace InventoryManagement
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        private SqlConnection GetConnection()
        {
            // Sử dụng ConfigurationManager để lấy chuỗi kết nối từ App.config
            string connectionString = ConfigurationManager.ConnectionStrings["InventoryDb"].ConnectionString;
            return new SqlConnection(connectionString);
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Register_Load(object sender, EventArgs e)
        {
            
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;
            using (SqlConnection con = GetConnection())
            {
                con.Open();

                if (MemberIDExists(con, txtMemberID.Text))
                {
                    MessageBox.Show("Mã thành viên đã tồn tại. Vui lòng nhập mã khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (UserNameExists(con, txtUserName.Text))
                {
                    MessageBox.Show("Tên tài khoản đã tồn tại. Vui lòng nhập tên khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (IdentityIDExists(con, txtIdentityID.Text))
                {
                    MessageBox.Show("Đã tồn tại CCCD.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    string sqlQuery = @"INSERT INTO [inventorydb].dbo.[acctab] ([MemberId], [UserName], [Password], [Type], [LastName], [FirstName], [YearOfBirth], [Gender], [IdentityID], [Address], [PhoneNumber], [DateAccept], [Status]) 
                                    VALUES (@MemberID, @UserName, @Password, @Type, @LastName, @FirstName, @YearOfBirth, @Gender, @IdentityID, @Address, @PhoneNumber, @DateAccept, @Status)";
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@MemberID", txtMemberID.Text);
                        cmd.Parameters.AddWithValue("@UserName", txtUserName.Text);
                        cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                        cmd.Parameters.AddWithValue("@Type", cbType.Text);
                        cmd.Parameters.AddWithValue("@LastName", txtLastName.Text);
                        cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                        cmd.Parameters.AddWithValue("@YearOfBirth", dtpYearOfBirth.Value);
                        cmd.Parameters.AddWithValue("@Gender", cbGender.Text);
                        cmd.Parameters.AddWithValue("@IdentityID", txtIdentityID.Text);
                        cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                        cmd.Parameters.AddWithValue("@PhoneNumber", txtPhone.Text);
                        cmd.Parameters.AddWithValue("@DateAccept", dtpDateAcp.Value);
                        cmd.Parameters.AddWithValue("@Status", cbStatus.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Đăng ký tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearInputs();
                    }
                }
            }
        }
        private bool MemberIDExists(SqlConnection con, string memberId)
        {
            string query = "SELECT COUNT(*) FROM acctab WHERE MemberID = @MemberID";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@MemberID", memberId);

                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
        private bool UserNameExists(SqlConnection con, string userName)
        {
            string query = "SELECT COUNT(*) FROM acctab WHERE UserName = @UserName";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@UserName", userName);

                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
        private bool IdentityIDExists(SqlConnection con, string identityId)
        {
            string query = "SELECT COUNT(*) FROM acctab WHERE IdentityID = @IdentityID";
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@IdentityID", identityId);

                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
        private void ClearInputs()
        {
            txtMemberID.Clear();
            txtUserName.Clear();
            txtPassword.Clear();
            cbType.SelectedIndex = -1;
            txtLastName.Clear();
            txtFirstName.Clear();
            dtpYearOfBirth.Value = DateTime.Now;
            cbGender.SelectedIndex = -1;
            txtIdentityID.Clear();
            txtAddress.Clear();
            txtPhone.Clear();
            dtpDateAcp.Value = DateTime.Now;
            cbStatus.SelectedIndex = -1;
        }
        private bool ValidateInputs()
        {
            //string patternUserName = "^[a-Z0-9]+$";
            //string userName = txtUserName.Text.Trim(); // Loại bỏ khoảng trắng thừa
            if (string.IsNullOrEmpty(txtMemberID.Text))
            {
                MessageBox.Show("Mã thành viên không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!int.TryParse(txtMemberID.Text, out int memberId))
            {
                MessageBox.Show("Mã thành viên không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                MessageBox.Show("Tên tài khoản không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtUserName.Text.Length < 5)
            {
                MessageBox.Show("Tên tài khoản phải có ít nhất 5 ký tự.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtUserName.Text.Length > 15)
            {
                MessageBox.Show("Tên tài khoản chỉ chứa tối đa 15 ký tự.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtUserName.Text.Contains(" "))
            {
                MessageBox.Show("Tên tài khoản không được chứa khoảng trắng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //if (!Regex.IsMatch(userName, patternUserName))
            //{
            //    MessageBox.Show("Tên tài khoản chỉ được chứa chữ thường và số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return false;
            //}
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Mật khẩu không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtPassword.Text.Length < 6)
            {
                MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtPassword.Text.Length > 15)
            {
                MessageBox.Show("Mật khẩu chỉ chứa tối đa 15 ký tự.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtPassword.Text.Contains(" "))
            {
                MessageBox.Show("Mật khẩu không được chứa khoảng trắng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //string patternPassword = @"^(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_+{}:;<>,.?/~`-]).+$";
            //if (!Regex.IsMatch(txtPassword.Text, patternPassword))
            //{
            //    MessageBox.Show("Mật khẩu phải chứa ít nhất 1 chữ số, 1 chữ in hoa và 1 ký tự đặc biệt.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return false;
            //}
            if (string.IsNullOrEmpty(cbType.Text))
            {
                MessageBox.Show("Vui lòng chọn phân quyền.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtLastName.Text))
            {
                MessageBox.Show("Họ không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtFirstName.Text))
            {
                MessageBox.Show("Tên không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(cbGender.Text))
            {
                MessageBox.Show("Vui lòng chọn giới tính.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtIdentityID.Text))
            {
                MessageBox.Show("CCCD không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("Địa chỉ không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                MessageBox.Show("SĐT không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!int.TryParse(txtPhone.Text, out int phone))
            {
                MessageBox.Show("SĐT không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(cbStatus.Text))
            {
                MessageBox.Show("Vui lòng chọn trạng thái.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }        
            return true;
        }

        private void txtMemberID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
