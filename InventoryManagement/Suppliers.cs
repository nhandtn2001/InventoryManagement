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
    public partial class Suppliers : Form
    {
        public Suppliers()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.Supplier_Load);
            dgvSupplier.CellClick += dgvSupplier_CellClick;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            using (SqlConnection con = GetConnection())
            {
                con.Open();

                if (SupplierExists(con, txtSupplierID.Text))
                {
                    MessageBox.Show("Mã NCC đã tồn tại. Vui lòng nhập mã mới.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    string sqlQuery = @"INSERT INTO [inventorydb].dbo.[suptab] ([SupplierId], [SupplierName], [Address], [Nation], [Phone], [Contact]) 
                                        VALUES (@SupplierID, @SupplierName, @Address, @Nation, @Phone, @Contact)";
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    cmd.Parameters.AddWithValue("@SupplierID", txtSupplierID.Text);
                    cmd.Parameters.AddWithValue("@SupplierName", txtSupplierName.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@Nation", txtNation.Text);
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@Contact", txtContact.Text);

                    cmd.ExecuteNonQuery();
                    //MessageBox.Show("Đã thêm NCC thành công", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowData();                    
                }
                ClearInputs();
            }
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
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [inventorydb].dbo.[suptab]", con);
                DataTable table = new DataTable();
                da.Fill(table);
                dgvSupplier.Rows.Clear();
                foreach (DataRow item in table.Rows)
                {
                    int n = dgvSupplier.Rows.Add();
                    dgvSupplier.Rows[n].Cells["tid"].Value = item["SupplierID"].ToString();
                    dgvSupplier.Rows[n].Cells["tname"].Value = item["SupplierName"].ToString();
                    dgvSupplier.Rows[n].Cells["taddress"].Value = item["Address"].ToString();
                    dgvSupplier.Rows[n].Cells["tnation"].Value = item["Nation"].ToString();
                    dgvSupplier.Rows[n].Cells["tphone"].Value = item["Phone"].ToString();
                    dgvSupplier.Rows[n].Cells["tcontact"].Value = item["Contact"].ToString();
                }
            }
        }
        private void dgvSupplier_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSupplier.SelectedRows.Count > 0)
            {
                // Lấy thông tin của hàng được chọn
                DataGridViewRow selectedRow = dgvSupplier.SelectedRows[0];

                // Hiển thị thông tin vào các TextBox
                txtSupplierID.Text = selectedRow.Cells["SupplierID"].Value.ToString();
                txtSupplierName.Text = selectedRow.Cells["SupplierName"].Value.ToString();
                txtAddress.Text = selectedRow.Cells["Address"].Value.ToString();
                txtNation.Text = selectedRow.Cells["Nation"].Value.ToString();
                txtPhone.Text = selectedRow.Cells["Phone"].Value.ToString();
                txtContact.Text = selectedRow.Cells["Contact"].Value.ToString();
            }
        }
        private void Supplier_Load(object sender, EventArgs e)
        {
            ShowData();
        }
        private bool SupplierExists(SqlConnection con, string supplierId)
        {
            string checkQuery = "SELECT COUNT(*) FROM suptab WHERE SupplierID = @SupplierID";
            SqlCommand checkCmd = new SqlCommand(checkQuery, con);
            checkCmd.Parameters.AddWithValue("@SupplierID", supplierId);
            int count = (int)checkCmd.ExecuteScalar();
            return count > 0;
        }
        private void dgvSupplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo rằng người dùng đã nhấp vào một hàng hợp lệ
            {
                // Lấy hàng hiện tại từ DataGridView
                DataGridViewRow selectedRow = dgvSupplier.Rows[e.RowIndex];

                // Hiển thị thông tin vào các TextBox
                txtSupplierID.Text = selectedRow.Cells["tid"].Value?.ToString();
                txtSupplierName.Text = selectedRow.Cells["tname"].Value?.ToString();
                txtAddress.Text = selectedRow.Cells["taddress"].Value?.ToString();
                txtNation.Text = selectedRow.Cells["tnation"].Value.ToString();
                txtPhone.Text = selectedRow.Cells["tphone"].Value?.ToString();
                txtContact.Text = selectedRow.Cells["tcontact"].Value?.ToString();


            }
        }
        private void ClearInputs()
        {
            txtSupplierID.Clear();
            txtSupplierName.Clear();
            txtAddress.Clear();
            txtNation.Clear();
            txtPhone.Clear();
            txtContact.Clear();
        }
        private bool ValidateInputs()
        {
            if (string.IsNullOrEmpty(txtSupplierID.Text))
            {
                MessageBox.Show("Mã nhà cung cấp không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtSupplierName.Text))
            {
                MessageBox.Show("Tên nhà cung cấp không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("Địa chỉ nhà cung cấp không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                MessageBox.Show("SDT nhà cung cấp không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtNation.Text))
            {
                MessageBox.Show("Quốc gia không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtContact.Text))
            {
                MessageBox.Show("Tên người liên hệ không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!int.TryParse(txtSupplierID.Text, out int supplierId))
            {
                MessageBox.Show("Mã NCC không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!long.TryParse(txtPhone.Text, out long phone))
            {
                MessageBox.Show("SDT không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            using (SqlConnection con = GetConnection())
            {
                con.Open();

                string sqlQuery = "UPDATE suptab SET SupplierName = @SupplierName, Address=@Address, Nation=@Nation, Phone=@Phone, Contact=@Contact WHERE SupplierID = @SupplierID";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@SupplierName", txtSupplierName.Text);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@Nation", txtNation.Text);
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@Contact", txtContact.Text);
                cmd.Parameters.AddWithValue("@SupplierID", txtSupplierID.Text);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Cập nhật thành công", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Cập nhật không thành công", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                ClearInputs();
                ShowData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            // Nếu người dùng chọn Yes, tiếp tục xóa sản phẩm
            if (result == DialogResult.Yes)
            {
                using (SqlConnection con = GetConnection())
                {
                    con.Open();
                    //xoá sp dựa trên SupplierID
                    string sqlQuery = "DELETE FROM [suptab] WHERE [SupplierID] = @SupplierID";
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    cmd.Parameters.AddWithValue("@SupplierID", txtSupplierID.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        ShowData();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa NCC. Vui lòng kiểm tra lại thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                // Lấy thông tin sản phẩm dựa trên SupplierID
                string sqlQuery = "SELECT SupplierName, Address, Nation, Phone, Contact FROM suptab WHERE SupplierID = @SupplierID";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.Parameters.AddWithValue("@SupplierID", txtSupplierID.Text);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtSupplierName.Text = reader["SupplierName"].ToString();
                    txtAddress.Text = reader["Address"].ToString();
                    txtNation.Text = reader["Nation"].ToString();
                    txtPhone.Text = reader["Phone"].ToString();
                    txtContact.Text = reader["Contact"].ToString();
                }
                else
                {
                    MessageBox.Show("Mã NCC không đúng, không tìm thấy thông tin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
