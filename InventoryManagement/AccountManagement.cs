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
    public partial class AccountManagement : Form
    {
        public AccountManagement()
        {
            InitializeComponent();
            dgvAccMag.CellClick += dgvAccMag_CellClick;
        }
        private SqlConnection GetConnection()
        {
            // Sử dụng ConfigurationManager để lấy chuỗi kết nối từ App.config
            string connectionString = ConfigurationManager.ConnectionStrings["InventoryDb"].ConnectionString;
            return new SqlConnection(connectionString);
        }
        private void dgvAccMag_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAccMag.SelectedRows.Count > 0)
            {
                // Lấy thông tin của hàng được chọn
                DataGridViewRow selectedRow = dgvAccMag.SelectedRows[0];
                // Hiển thị thông tin vào các TextBox
                txtMemberID.Text = selectedRow.Cells["tmemberid"].Value?.ToString();
                cbType.Text = selectedRow.Cells["type"].Value?.ToString();
                cbStatus.Text = selectedRow.Cells["status"].Value?.ToString();
            }
        }
        private bool MemberExists(SqlConnection con, string memberId)
        {
            string checkQuery = "SELECT COUNT(*) FROM acctab WHERE MemberID = @MemberID";
            SqlCommand checkCmd = new SqlCommand(checkQuery, con);
            checkCmd.Parameters.AddWithValue("@MemberID", memberId);
            int count = (int)checkCmd.ExecuteScalar();
            return count > 0;
        }
        private void dgvAccMag_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo rằng người dùng đã nhấp vào một hàng hợp lệ
            {
                // Lấy hàng hiện tại từ DataGridView
                DataGridViewRow selectedRow = dgvAccMag.Rows[e.RowIndex];
                // Hiển thị thông tin vào các TextBox
                txtMemberID.Text = selectedRow.Cells["tmemberid"].Value?.ToString();
                cbType.Text = selectedRow.Cells["type"].Value?.ToString();
                cbStatus.Text = selectedRow.Cells["tstatus"].Value?.ToString();
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Register rg = new Register();
            btnAdd.Enabled = false;
            rg.FormClosed += (s, args) =>
            {
                btnAdd.Enabled = true;
            };
            rg.ShowDialog();
        }

        private void AccountManagement_Load(object sender, EventArgs e)
        {
            ShowData();
            
        }
        private void ShowData()
        {
            using (SqlConnection con = GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [inventorydb].dbo.[acctab]", con);
                DataTable table = new DataTable();
                da.Fill(table);
                dgvAccMag.Rows.Clear();
                foreach (DataRow item in table.Rows)
                {
                    int n = dgvAccMag.Rows.Add();
                    dgvAccMag.Rows[n].Cells["tmemberid"].Value = item["MemberID"].ToString();
                    dgvAccMag.Rows[n].Cells["tusername"].Value = item["UserName"].ToString();
                    dgvAccMag.Rows[n].Cells["type"].Value = item["Type"].ToString();
                    dgvAccMag.Rows[n].Cells["tlastname"].Value = item["LastName"].ToString();
                    dgvAccMag.Rows[n].Cells["tfirstname"].Value = item["FirstName"].ToString();
                    dgvAccMag.Rows[n].Cells["tyearofbirth"].Value = Convert.ToDateTime(item["YearOfBirth"]).ToString("dd/MM/yyyy");
                    dgvAccMag.Rows[n].Cells["tgender"].Value = item["Gender"].ToString();
                    dgvAccMag.Rows[n].Cells["tidentity"].Value = item["IdentityID"].ToString();
                    dgvAccMag.Rows[n].Cells["taddress"].Value = item["Address"].ToString();
                    dgvAccMag.Rows[n].Cells["tphone"].Value = item["PhoneNumber"].ToString();
                    dgvAccMag.Rows[n].Cells["taccept"].Value = Convert.ToDateTime(item["DateAccept"]).ToString("dd/MM/yyyy");
                    dgvAccMag.Rows[n].Cells["tstatus"].Value = item["Status"].ToString();

                }
            }
        }
        private void ClearInputs()
        {
            txtMemberID.Clear();
            cbType.SelectedIndex = -1;
            cbStatus.SelectedIndex = -1;
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearInputs();
            ShowData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                using (SqlConnection con = GetConnection())
                {
                    con.Open();
                    //xoá sp dựa trên ProductID
                    string sqlQuery = "DELETE FROM [acctab] WHERE [MemberID] = @MemberID";
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    cmd.Parameters.AddWithValue("@MemberID", txtMemberID.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        ClearInputs();
                        ShowData();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa tài khoản. Vui lòng kiểm tra lại thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private bool ValidateInputs()
        {
            if (string.IsNullOrEmpty(txtMemberID.Text))
            {
                MessageBox.Show("Vui lòng nhập mã thành viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(cbType.Text))
            {
                MessageBox.Show("Vui lòng chọn phân quyền.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(cbStatus.Text))
            {
                MessageBox.Show("Vui lòng chọn trạng thái.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void dgvAccMag_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            using (SqlConnection con = GetConnection())
            {
                con.Open();
                // Cập nhật thông tin khách hàng
                string sqlQuery = "UPDATE acctab SET Type = @Type, Status = @Status WHERE MemberID = @MemberID";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.Parameters.Clear();
                // Thêm các tham số
                cmd.Parameters.AddWithValue("@Type", cbType.Text);
                cmd.Parameters.AddWithValue("@Status", cbStatus.Text);
                cmd.Parameters.AddWithValue("@MemberID", txtMemberID.Text);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Cập nhật thông tin tài khoản thành công", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Cập nhật không thành công", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                ClearInputs();
                ShowData();
            }
        }
    }
}
