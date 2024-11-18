using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace InventoryManagement
{
    public partial class Customers : Form
    {       
        public Customers()
        {
            InitializeComponent();
            dgvCustomers.CellClick += dgvCustomers_CellClick;
        }
        private SqlConnection GetConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["InventoryDb"].ConnectionString;
            return new SqlConnection(connectionString);
        }

        public void ShowData()
        {
            using (SqlConnection con = GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [inventorydb].dbo.[custab]", con);
                DataTable table = new DataTable();
                da.Fill(table);
                dgvCustomers.Rows.Clear();
                foreach (DataRow item in table.Rows)
                {
                    int n = dgvCustomers.Rows.Add();
                    dgvCustomers.Rows[n].Cells["tid"].Value = item["CustomerID"].ToString();
                    dgvCustomers.Rows[n].Cells["tname"].Value = item["CustomerName"].ToString();
                    dgvCustomers.Rows[n].Cells["tyearofbirth"].Value = Convert.ToDateTime(item["YearOfBirth"]).ToString("dd/MM/yyyy");
                    dgvCustomers.Rows[n].Cells["taddress"].Value = item["Address"].ToString();
                    dgvCustomers.Rows[n].Cells["tphonenumber"].Value = item["PhoneNumber"].ToString();
                }
            }
        }
        private void dgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                // Lấy thông tin của hàng được chọn
                DataGridViewRow selectedRow = dgvCustomers.SelectedRows[0];
                // Hiển thị thông tin vào các TextBox
                txtCustomerID.Text = selectedRow.Cells["tid"].Value?.ToString();
                txtCustomerName.Text = selectedRow.Cells["tname"].Value?.ToString();
                txtYearOfBirth.Text = selectedRow.Cells["tyearofbirth"].Value?.ToString();
                txtAddress.Text = selectedRow.Cells["taddress"].Value?.ToString();
                txtPhoneNumber.Text = selectedRow.Cells["tphonenumber"].Value?.ToString();
            }
        }
        private void ClearInputs()
        {
            txtCustomerID.Clear();
            txtCustomerName.Clear();
            txtYearOfBirth.Value = DateTime.Now;
            txtAddress.Clear();
            txtPhoneNumber.Clear();
        }
        private void Customers_Load(object sender, EventArgs e)
        {
            ShowData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            using (SqlConnection con = GetConnection())
            {
                con.Open();

                if (ProductExists(con, txtCustomerID.Text))
                {
                    MessageBox.Show("Mã khách đã tồn tại. Vui lòng nhập mã khách mới.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    string sqlQuery = @"INSERT INTO [inventorydb].dbo.[custab] ([CustomerId], [CustomerName], [YearOfBirth], [Address], [PhoneNumber]) 
                                        VALUES (@CustomerID, @CustomerName, @YearOfBirth, @Address, @PhoneNumber)";
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    cmd.Parameters.AddWithValue("@CustomerID", txtCustomerID.Text);
                    cmd.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
                    cmd.Parameters.AddWithValue("@YearOfBirth", DateTime.ParseExact(txtYearOfBirth.Text, "dd/MM/yyyy", null).Date); // Ensure no time component
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@PhoneNumber", txtPhoneNumber.Text);

                    cmd.ExecuteNonQuery();
                    //MessageBox.Show("Đã thêm KH thành công", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowData();
                    ClearInputs();
                }
            }
        }
        private bool ProductExists(SqlConnection con, string customerId)
        {
            string checkQuery = "SELECT COUNT(*) FROM custab WHERE CustomerID = @CustomerID";
            SqlCommand checkCmd = new SqlCommand(checkQuery, con);
            checkCmd.Parameters.AddWithValue("@CustomerID", customerId);
            int count = (int)checkCmd.ExecuteScalar();
            return count > 0;
        }
        private bool ValidateInputs()
        {
            string dateFormat = "dd/MM/yyyy";
            if (string.IsNullOrEmpty(txtCustomerID.Text))
            {
                MessageBox.Show("Mã khách không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtCustomerName.Text))
            {
                MessageBox.Show("Tên khách không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtYearOfBirth.Text))
            {
                MessageBox.Show("Năm sinh không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("Địa chỉ không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtPhoneNumber.Text))
            {
                MessageBox.Show("SDT không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!int.TryParse(txtCustomerID.Text, out int customerId))
            {
                MessageBox.Show("Mã khách không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!DateTime.TryParseExact(txtYearOfBirth.Text, dateFormat, null, System.Globalization.DateTimeStyles.None, out DateTime birthDate))
            {
                MessageBox.Show("Định dạng ngày tháng năm không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!long.TryParse(txtPhoneNumber.Text, out long phone))
            {
                MessageBox.Show("SDT không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo rằng người dùng đã nhấp vào một hàng hợp lệ
            {
                // Lấy hàng hiện tại từ DataGridView
                DataGridViewRow selectedRow = dgvCustomers.Rows[e.RowIndex];
                // Hiển thị thông tin vào các TextBox
                txtCustomerID.Text = selectedRow.Cells["tid"].Value?.ToString();
                txtCustomerName.Text = selectedRow.Cells["tname"].Value?.ToString();
                txtYearOfBirth.Text = selectedRow.Cells["tyearofbirth"].Value?.ToString();
                txtAddress.Text = selectedRow.Cells["taddress"].Value?.ToString();
                txtPhoneNumber.Text = selectedRow.Cells["tphonenumber"].Value?.ToString();
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            using (SqlConnection con = GetConnection())
            {
                con.Open();
                // Cập nhật thông tin khách hàng
                string sqlQuery = "UPDATE custab SET CustomerName = @CustomerName, YearOfBirth = @YearOfBirth, Address = @Address, PhoneNumber = @PhoneNumber WHERE CustomerID = @CustomerID";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.Parameters.Clear();

                // Thêm các tham số
                cmd.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@PhoneNumber", txtPhoneNumber.Text);
                cmd.Parameters.AddWithValue("@CustomerID", txtCustomerID.Text);

                // Sử dụng SqlParameter để thêm YearOfBirth
                cmd.Parameters.Add(new SqlParameter("@YearOfBirth", SqlDbType.Date)
                {
                    Value = DateTime.ParseExact(txtYearOfBirth.Text, "dd/MM/yyyy", null).Date
                });

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Cập nhật thông tin khách thành công", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Cập nhật không thành công", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                ShowData();
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                using (SqlConnection con = GetConnection())
                {
                    con.Open();
                    //xoá sp dựa trên ProductID
                    string sqlQuery = "DELETE FROM [custab] WHERE [CustomerID] = @CustomerID";
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    cmd.Parameters.AddWithValue("@CustomerID", txtCustomerID.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        ShowData();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa khách hàng. Vui lòng kiểm tra lại thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            ClearInputs();
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = GetConnection())
            {
                con.Open();
                // Lấy thông tin sản phẩm dựa trên ProductID
                string sqlQuery = "SELECT CustomerName, YearOfBirth, Address, PhoneNumber FROM custab WHERE CustomerID = @CustomerID";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.Parameters.AddWithValue("@CustomerID", txtCustomerID.Text);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtCustomerName.Text = reader["CustomerName"].ToString();
                    txtYearOfBirth.Text = Convert.ToDateTime(reader["YearOfBirth"]).ToString("dd/MM/yyyy");
                    txtAddress.Text = reader["Address"].ToString();
                    txtPhoneNumber.Text = reader["PhoneNumber"].ToString();
                }
                else
                {
                    MessageBox.Show("Mã KH không đúng, không tìm thấy thông tin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                reader.Close();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearInputs();
            ShowData();
        }
    }
}
