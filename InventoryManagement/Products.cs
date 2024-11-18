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
using System.Reflection.Emit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace InventoryManagement
{
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
            dgvProducts.CellClick += dgvProducts_CellClick;
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
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [inventorydb].dbo.[protab]", con);
                DataTable table = new DataTable();
                da.Fill(table);
                dgvProducts.Rows.Clear();
                foreach (DataRow item in table.Rows)
                {
                    int n = dgvProducts.Rows.Add();
                    dgvProducts.Rows[n].Cells["tid"].Value = item["ProductID"].ToString();
                    dgvProducts.Rows[n].Cells["tname"].Value = item["ProductName"].ToString();
                    dgvProducts.Rows[n].Cells["tcategory"].Value = item["Category"].ToString();
                    dgvProducts.Rows[n].Cells["tsupplier"].Value = item["Supplier"].ToString();
                    dgvProducts.Rows[n].Cells["tdate"].Value = Convert.ToDateTime(item["Date"]).ToString("dd/MM/yyyy");
                    dgvProducts.Rows[n].Cells["torigin"].Value = item["Origin"].ToString();
                    dgvProducts.Rows[n].Cells["tdescription"].Value = item["Description"].ToString();
                    dgvProducts.Rows[n].Cells["tstatus"].Value = item["Status"].ToString();

                }
                if (dgvProducts.Rows.Count > 0)
                {
                    labelSP.Text = (dgvProducts.Rows.Count - 1).ToString();

                    int conHang = 0;
                    int hetHang = 0;
                    //float totalDate = 0;
                    foreach (DataGridViewRow row in dgvProducts.Rows)
                    {
                        if (row.Cells["tstatus"].Value != null && row.Cells["tstatus"].Value.ToString() == "Còn hàng")
                        {
                            conHang++;
                        }
                        if (row.Cells["tstatus"].Value != null && row.Cells["tstatus"].Value.ToString() == "Hết hàng")
                        {
                            hetHang++;
                        }
                    }
                    labelHH.Text = hetHang.ToString();
                    labelCH.Text = conHang.ToString();
                }
                else
                {
                    labelSP.Text = "0";
                    labelCH.Text = "0";
                    labelHH.Text = "0";
                }
            }
        }
        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count > 0)
            {
                // Lấy thông tin của hàng được chọn
                DataGridViewRow selectedRow = dgvProducts.SelectedRows[0];

                // Hiển thị thông tin vào các TextBox
                txtProductID.Text = selectedRow.Cells["ProductID"].Value.ToString();
                txtProductName.Text = selectedRow.Cells["ProductName"].Value.ToString();
                cbCategory.Text = selectedRow.Cells["Category"].Value.ToString();
                txtSupplier.Text = selectedRow.Cells["Supplier"].Value.ToString();
                dtpDate.Text = selectedRow.Cells["Date"].Value.ToString();
                txtOrigin.Text = selectedRow.Cells["Origin"].Value.ToString();
                txtDescription.Text = selectedRow.Cells["Description"].Value.ToString();
                cbStatus.Text = selectedRow.Cells["Status"].Value.ToString();
            }
        }
        private void ClearInputs()
        {
            txtProductID.Clear();
            txtProductName.Clear();
            cbCategory.SelectedIndex = -1;
            txtSupplier.SelectedIndex = -1;
            dtpDate.Value = DateTime.Now;
            txtOrigin.Clear();
            txtDescription.Clear();
            cbStatus.SelectedIndex = -1;
        }
        private void LoadCategoryNames()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["InventoryDb"].ConnectionString;
            string query = "SELECT CategoryName FROM cattab";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                // Xóa các mục trong ComboBox trước khi thêm mới
                cbCategory.Items.Clear();
                while (reader.Read())
                {
                    cbCategory.Items.Add(reader["CategoryName"].ToString());
                }

                reader.Close();
            }
        }
        private void LoadSupplierNames()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["InventoryDb"].ConnectionString;
            string query = "SELECT SupplierName FROM suptab";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                // Xóa các mục trong ComboBox trước khi thêm mới
                txtSupplier.Items.Clear();
                while (reader.Read())
                {
                    txtSupplier.Items.Add(reader["SupplierName"].ToString());
                }

                reader.Close();
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (!ValidateInputs())
                return;

            using (SqlConnection con = GetConnection())
            {
                con.Open();

                if (ProductExists(con, txtProductID.Text))
                {
                    MessageBox.Show("Mã sản phẩm đã tồn tại. Vui lòng nhập mã sản phẩm mới.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    string sqlQuery = @"INSERT INTO [inventorydb].dbo.[protab] ([ProductId], [ProductName], [Category], [Supplier], [Date], [Origin], [Description], [Status]) 
                                        VALUES (@ProductID, @ProductName, @Category, @Supplier, @Date, @Origin, @Description, @Status)";
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    cmd.Parameters.AddWithValue("@ProductID", txtProductID.Text);
                    cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text);
                    cmd.Parameters.AddWithValue("@Category", cbCategory.Text);
                    cmd.Parameters.AddWithValue("@Supplier", txtSupplier.Text);
                    cmd.Parameters.AddWithValue("@Date", dtpDate.Value);
                    cmd.Parameters.AddWithValue("@Origin", txtOrigin.Text);
                    cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                    cmd.Parameters.AddWithValue("@Status", cbStatus.Text);


                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đã thêm sản phẩm thành công", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowData();
                }
            }
            ClearInputs();
        }

        private void txtProductID_TextChanged(object sender, EventArgs e)
        {

        }

        private void Products_Load(object sender, EventArgs e)
        {
            LoadCategoryNames();
            LoadSupplierNames();
            ShowData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            using (SqlConnection con = GetConnection())
            {
                con.Open();

                string sqlQuery = "UPDATE protab SET ProductName = @ProductName, Category=@Category, Supplier=@Supplier, Date = @Date, Origin=@Origin, Description=@Description, Status=@Status WHERE ProductID = @ProductID";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text);
                cmd.Parameters.AddWithValue("@Category", cbCategory.Text);
                cmd.Parameters.AddWithValue("@Supplier", txtSupplier.Text);
                cmd.Parameters.AddWithValue("@Date", dtpDate.Value);
                cmd.Parameters.AddWithValue("@Origin", txtOrigin.Text);
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text);
                cmd.Parameters.AddWithValue("@Status", cbStatus.Text);
                cmd.Parameters.AddWithValue("@ProductID", txtProductID.Text);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Cập nhật sản phẩm thành công", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Cập nhật không thành công", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                ClearInputs();
                ShowData();
            }
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {       
            using (SqlConnection con = GetConnection())
            {
                con.Open();
                // Lấy thông tin sản phẩm dựa trên ProductID
                string sqlQuery = "SELECT ProductName, Category, Supplier, Date, Origin, Description, Status FROM protab WHERE ProductID = @ProductID";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.Parameters.AddWithValue("@ProductID", txtProductID.Text);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtProductName.Text = reader["ProductName"].ToString();
                    cbCategory.Text = reader["Category"].ToString();
                    txtSupplier.Text = reader["Supplier"].ToString();
                    dtpDate.Text = reader["Date"].ToString();
                    txtOrigin.Text = reader["Origin"].ToString();
                    txtDescription.Text = reader["Description"].ToString();
                    cbStatus.Text = reader["Status"].ToString();

                }
                else
                {
                    MessageBox.Show("Mã sản phẩm không đúng, không tìm thấy thông tin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                reader.Close();
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
                    //xoá sp dựa trên ProductID
                    string sqlQuery = "DELETE FROM [protab] WHERE [ProductID] = @ProductID";
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    cmd.Parameters.AddWithValue("@ProductID", txtProductID.Text);

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
        private bool ProductExists(SqlConnection con, string productId)
        {
            string checkQuery = "SELECT COUNT(*) FROM protab WHERE ProductID = @ProductID";
            SqlCommand checkCmd = new SqlCommand(checkQuery, con);
            checkCmd.Parameters.AddWithValue("@ProductID", productId);
            int count = (int)checkCmd.ExecuteScalar();
            return count > 0;
        }
        private bool ValidateInputs()
        {
            if (string.IsNullOrEmpty(txtProductID.Text))
            {
                MessageBox.Show("Mã sản phẩm không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtProductName.Text))
            {
                MessageBox.Show("Tên sản phẩm không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(cbCategory.Text))
            {
                MessageBox.Show("Loại sản phẩm không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtSupplier.Text))
            {
                MessageBox.Show("Nhà cung cấp không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtOrigin.Text))
            {
                MessageBox.Show("Xuất xứ không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                MessageBox.Show("Vui lòng thêm mô tả.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(cbStatus.Text))
            {
                MessageBox.Show("Thêm trạng thái sản phẩm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!int.TryParse(txtProductID.Text, out int productId))
            {
                MessageBox.Show("Mã sản phẩm không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo rằng người dùng đã nhấp vào một hàng hợp lệ
            {
                // Lấy hàng hiện tại từ DataGridView
                DataGridViewRow selectedRow = dgvProducts.Rows[e.RowIndex];

                // Hiển thị thông tin vào các TextBox
                txtProductID.Text = selectedRow.Cells["tid"].Value?.ToString();
                txtProductName.Text = selectedRow.Cells["tname"].Value?.ToString();
                cbCategory.Text = selectedRow.Cells["tcategory"].Value?.ToString();
                txtSupplier.Text = selectedRow.Cells["tsupplier"].Value?.ToString();
                dtpDate.Text = selectedRow.Cells["tdate"].Value?.ToString();
                txtOrigin.Text = selectedRow.Cells["torigin"].Value?.ToString();
                txtDescription.Text = selectedRow.Cells["tdescription"].Value?.ToString();
                cbStatus.Text = selectedRow.Cells["tstatus"].Value?.ToString();

            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearInputs();          
            ShowData();
        }

        private void btnLoaiSP_Click(object sender, EventArgs e)
        {
            Category ct = new Category();
            btnLoaiSP.Enabled = false;
            LoadCategoryNames();
            ct.FormClosed += (s, args) =>
            {   btnLoaiSP.Enabled = true;
                LoadCategoryNames();
            };
            ct.ShowDialog();
        }

        private void btnNCC_Click(object sender, EventArgs e)
        {
            Suppliers sp = new Suppliers();
            btnNCC.Enabled = false;
            LoadSupplierNames();
            sp.FormClosed += (s, args) =>
            {
                btnNCC.Enabled = true;
                LoadSupplierNames();
            };
            sp.ShowDialog();
        }
    }
}
