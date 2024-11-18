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
    public partial class Category : Form
    {
        public Category()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.Category_Load);
            dgvCategory.CellClick += dgvCategory_CellClick;
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
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [inventorydb].dbo.[cattab]", con);
                DataTable table = new DataTable();
                da.Fill(table);
                dgvCategory.Rows.Clear();
                foreach (DataRow item in table.Rows)
                {
                    int n = dgvCategory.Rows.Add();
                    dgvCategory.Rows[n].Cells["tid"].Value = item["CategoryID"].ToString();
                    dgvCategory.Rows[n].Cells["tname"].Value = item["CategoryName"].ToString();
                }
            }
        }
        private void dgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCategory.SelectedRows.Count > 0)
            {
                // Lấy thông tin của hàng được chọn
                DataGridViewRow selectedRow = dgvCategory.SelectedRows[0];
                // Hiển thị thông tin vào các TextBox
                txtCategoryID.Text = selectedRow.Cells["tid"].Value?.ToString();
                txtCategoryName.Text = selectedRow.Cells["tname"].Value?.ToString();
            }
        }
        private void Category_Load(object sender, EventArgs e)
        {
            ShowData();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            using (SqlConnection con = GetConnection())
            {
                con.Open();

                if (CategoryExist(con, txtCategoryID.Text))
                {
                    MessageBox.Show("Mã loại đã tồn tại. Vui lòng nhập mã loại mới.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    string sqlQuery = @"INSERT INTO [inventorydb].dbo.[cattab] ([CategoryId], [CategoryName]) 
                                        VALUES (@CategoryID, @CategoryName)";
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    cmd.Parameters.AddWithValue("@CategoryID", txtCategoryID.Text);
                    cmd.Parameters.AddWithValue("@CategoryName", txtCategoryName.Text);


                    cmd.ExecuteNonQuery();
                    //MessageBox.Show("Đã thêm KH thành công", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowData();
                }
            }
            ClearInputs();
        }
        private bool CategoryExist(SqlConnection con, string categoryId)
        {
            string checkQuery = "SELECT COUNT(*) FROM cattab WHERE CategoryID = @CategoryID";
            SqlCommand checkCmd = new SqlCommand(checkQuery, con);
            checkCmd.Parameters.AddWithValue("@CategoryID", categoryId);
            int count = (int)checkCmd.ExecuteScalar();
            return count > 0;
        }
        private bool ValidateInputs()
        {
            if (string.IsNullOrEmpty(txtCategoryID.Text))
            {
                MessageBox.Show("Mã loại không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtCategoryName.Text))
            {
                MessageBox.Show("Tên loại không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!int.TryParse(txtCategoryID.Text, out int categoryId))
            {
                MessageBox.Show("Mã loại không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void dgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo rằng người dùng đã nhấp vào một hàng hợp lệ
            {
                // Lấy hàng hiện tại từ DataGridView
                DataGridViewRow selectedRow = dgvCategory.Rows[e.RowIndex];
                // Hiển thị thông tin vào các TextBox
                txtCategoryID.Text = selectedRow.Cells["tid"].Value?.ToString();
                txtCategoryName.Text = selectedRow.Cells["tname"].Value?.ToString();

            }
        }
        private void ClearInputs()
        {
            txtCategoryID.Clear();
            txtCategoryName.Clear();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            using (SqlConnection con = GetConnection())
            {
                con.Open();

                string sqlQuery = "UPDATE cattab SET CategoryName = @CategoryName WHERE CategoryID = @CategoryID";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@CategoryName", txtCategoryName.Text);
                cmd.Parameters.AddWithValue("@CategoryID", txtCategoryID.Text);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Cập nhật sản phẩm thành công", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            // Kiểm tra xem người dùng có muốn xóa sản phẩm không
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            // Nếu người dùng chọn Yes, tiếp tục xóa sản phẩm
            if (result == DialogResult.Yes)
            {
                using (SqlConnection con = GetConnection())
                {
                    con.Open();
                    //xoá sp dựa trên CategoryID
                    string sqlQuery = "DELETE FROM [cattab] WHERE [CategoryID] = @CategoryID";
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    cmd.Parameters.AddWithValue("@CategoryID", txtCategoryID.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        ShowData();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa sản phẩm. Vui lòng kiểm tra lại thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                // Lấy thông tin sản phẩm dựa trên CategoryID
                string sqlQuery = "SELECT CategoryName FROM cattab WHERE CategoryID = @CategoryID";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.Parameters.AddWithValue("@CategoryID", txtCategoryID.Text);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtCategoryName.Text = reader["CategoryName"].ToString();
                }
                else
                {
                    MessageBox.Show("Mã sản phẩm không đúng, không tìm thấy thông tin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
