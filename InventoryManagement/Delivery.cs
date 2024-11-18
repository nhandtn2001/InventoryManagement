using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace InventoryManagement
{
    public partial class Delivery : Form
    {
        public Delivery()
        {
            InitializeComponent();
            dgvDetails.CellValueChanged += dgvDetails_CellValueChanged;
            dgvDetails.CellFormatting += dgvDetails_CellFormatting;
        }
        private SqlConnection GetConnection()
        {
            // Sử dụng ConfigurationManager để lấy chuỗi kết nối từ App.config
            string connectionString = ConfigurationManager.ConnectionStrings["InventoryDb"].ConnectionString;
            return new SqlConnection(connectionString);
        }
        private void LoadProductNames()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["InventoryDb"].ConnectionString;
            string query = "SELECT ProductName FROM protab WHERE Status='Còn hàng'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                // Xóa các mục trong ComboBox trước khi thêm mới
                cbProductName.Items.Clear();
                while (reader.Read())
                {

                    cbProductName.Items.Add(reader["ProductName"].ToString());
                }

                reader.Close();
            }
        }
        private bool ValidateInputInvoices() // kt thông tin hoá đơn
        {
            if (string.IsNullOrEmpty(txtDeliveryID.Text))
            {
                MessageBox.Show("Mã đơn xuất không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!int.TryParse(txtDeliveryID.Text, out int deliveryId))
            {
                MessageBox.Show("Mã đơn không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (CheckInvoiceExists(txtDeliveryID.Text))
            {
                MessageBox.Show("Mã đơn xuất đã tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtCustomerName.Text))
            {
                MessageBox.Show("Tên khách không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                MessageBox.Show("Địa chỉ không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtCreatePerson.Text))
            {
                MessageBox.Show("Người lập đơn không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }            
            return true;
        }
        private bool ValidateInputProducts() // kt sản phẩm nhập hoá đơn
        {
            if (string.IsNullOrEmpty(cbProductName.Text))
            {
                MessageBox.Show("Tên sản phẩm không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtPrice.Text))
            {
                MessageBox.Show("Đơn giá không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!long.TryParse(txtPrice.Text, out long price))
            {
                MessageBox.Show("Đơn giá không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtQuantity.Text))
            {
                MessageBox.Show("Số lượng không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!int.TryParse(txtQuantity.Text, out int quantity))
            {
                MessageBox.Show("Số lượng không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private bool ValidateInputDetails() //kiểm tra chi tiết hoá đơn
        {
            foreach (DataGridViewRow row in dgvDetails.Rows)
            {
                // Kiểm tra nếu hàng không phải là hàng mới và ô tpname có giá trị
                if (!row.IsNewRow && row.Cells["tpname"].Value != null &&
                    !string.IsNullOrWhiteSpace(row.Cells["tpname"].Value.ToString()))
                {
                    return true; // Có ít nhất một dòng chứa dữ liệu
                }
            }
            return false; // Chỉ có các dòng trống
        }
        private bool CheckInvoiceExists(string deliveryId) //kt mã sản phẩm khi thêm vào chi tiết hoá đơn
        {
            using (SqlConnection con = GetConnection())
            {
                con.Open();
                string sqlQuery = "SELECT COUNT(1) FROM [devtab] WHERE [DeliveryId] = @DeliveryId";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.Parameters.AddWithValue("@DeliveryId", deliveryId);

                int count = (int)cmd.ExecuteScalar();
                return count > 0;  // Trả về true nếu mã hóa đơn đã tồn tại, ngược lại trả về false
            }
        }
        
        private void dgvDetails_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu cột là "Quantity" hoặc "Price" để thực hiện phép nhân
            if (e.ColumnIndex == dgvDetails.Columns["tquantity"].Index ||
                e.ColumnIndex == dgvDetails.Columns["tprice"].Index)
            {
                // Lấy hàng hiện tại
                DataGridViewRow row = dgvDetails.Rows[e.RowIndex];

                // Kiểm tra nếu cả hai ô đều có giá trị hợp lệ
                if (int.TryParse(row.Cells["tquantity"].Value?.ToString(), out int quantity) &&
                    decimal.TryParse(row.Cells["tprice"].Value?.ToString(), out decimal price))
                {
                    // Thực hiện phép nhân và gán vào ô "Total"
                    row.Cells["ttotal"].Value = quantity * price;
                }
                else
                {
                    // Nếu dữ liệu không hợp lệ, đặt giá trị Total về null hoặc 0
                    row.Cells["ttotal"].Value = null;
                }
                CalculateTotal();
            }
            
        }
        private void CalculateTotal()
        {
            if (dgvDetails.Rows.Count > 0)
            {
                decimal totalPrice = 0;
                for (int i = 0; i < dgvDetails.Rows.Count; ++i)
                {
                    // Kiểm tra nếu giá trị của ô không phải là null trước khi chuyển đổi
                    if (dgvDetails.Rows[i].Cells["ttotal"].Value != null &&
                        decimal.TryParse(dgvDetails.Rows[i].Cells["ttotal"].Value.ToString(), out decimal price))
                    {
                        totalPrice += price;
                    }
                }
                labelTG.Text = totalPrice.ToString("N0");
            }
            else
            {
                labelTG.Text = "0";
            }

        }

        private int detailIdCounter = 1;
        private void UpdateDetailIds()
        {
            for (int i = 0; i < dgvDetails.Rows.Count; i++)
            {
                // Cập nhật thứ tự từ 1 đến số hàng trong DataGridView
                dgvDetails.Rows[i].Cells["tdetailid"].Value = i + 1;
            }
        }
        private void btnAddProducts_Click(object sender, EventArgs e)
        {
            if (!ValidateInputProducts())
                return;

            string pname = cbProductName.Text;
            string price = txtPrice.Text;
            string quantity = txtQuantity.Text;

            // Thêm một hàng mới vào DataGridView
            int rowIndex = dgvDetails.Rows.Add();
            dgvDetails.Rows[rowIndex].Cells["tpname"].Value = pname;
            dgvDetails.Rows[rowIndex].Cells["tprice"].Value = price;
            dgvDetails.Rows[rowIndex].Cells["tquantity"].Value = quantity;

            // Cập nhật lại thứ tự
            UpdateDetailIds();

            cbProductName.SelectedIndex = -1;
            txtPrice.Clear();
            txtQuantity.Clear();
        }

        private void Delivery_Load(object sender, EventArgs e)
        {
            LoadProductNames();
        }

        private bool InvoiceExists(SqlConnection con, string deliveryId)
        {
            string checkQuery = "SELECT COUNT(*) FROM devtab WHERE DeliveryID = @DeliveryID";
            SqlCommand checkCmd = new SqlCommand(checkQuery, con);
            checkCmd.Parameters.AddWithValue("@DeliveryID", deliveryId);
            int count = (int)checkCmd.ExecuteScalar();
            return count > 0;
        }
        private void dgvDetails_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Kiểm tra nếu cột là tprice hoặc ttotalprice và khác null
            if (dgvDetails.Columns[e.ColumnIndex].Name == "tprice" && dgvDetails.Columns[e.ColumnIndex].Name == "tquantity" && dgvDetails.Columns[e.ColumnIndex].Name == "ttotal" || e.Value != null)
            {
                if (float.TryParse(e.Value.ToString(), out float price))
                {
                    // Định dạng số tiền với dấu phân cách hàng ngàn và thêm " Đồng"
                    e.Value = price.ToString("N0");
                    e.FormattingApplied = true;
                }
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào được chọn trong DataGridView không
            if (dgvDetails.SelectedRows.Count > 0)
            {
                // Lấy dòng được chọn đầu tiên
                DataGridViewRow selectedRow = dgvDetails.SelectedRows[0];
                // Kiểm tra nếu dòng được chọn có rỗng không
                bool isEmptyRow = true;
                foreach (DataGridViewCell cell in selectedRow.Cells)
                {
                    if (cell.Value != null && !string.IsNullOrWhiteSpace(cell.Value.ToString()))
                    {
                        isEmptyRow = false;
                        break;
                    }
                }
                // Nếu dòng không rỗng, hiển thị hộp thoại xác nhận
                if (!isEmptyRow)
                {
                    DialogResult result = MessageBox.Show("Bạn có muốn xóa sản phẩm không?","Xác nhận xóa",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        dgvDetails.Rows.RemoveAt(selectedRow.Index);
                        UpdateDetailIds();
                        CalculateTotal();
                    }
                }
                else
                {
                    MessageBox.Show("Không thể xóa dòng trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void ClearInputs()
        {
            dgvDetails.Rows.Clear();
            txtDeliveryID.Clear();
            txtCustomerName.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            dtpDate.Value = DateTime.Now;
            txtCreatePerson.Clear();
            labelTG.Text = "0";
        }
        private void btnAddInvoices_Click(object sender, EventArgs e)
        {
            if (!ValidateInputInvoices())
                return;
            if (!ValidateInputDetails())
            {
                MessageBox.Show("Bạn chưa thêm sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (SqlConnection con = GetConnection())
            {
                con.Open();

                if (InvoiceExists(con, txtDeliveryID.Text))
                {
                    MessageBox.Show("Mã đơn đã tồn tại. Vui lòng nhập mã đơn mới.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    // Thêm hóa đơn vào bảng deltab
                    string sqlQuery = @"INSERT INTO [inventorydb].dbo.[devtab] 
                                ([DeliveryId], [CustomerName], [Phone], [Address], [Date], [CreatePerson], [TotalPrice]) 
                                VALUES (@DeliveryId, @CustomerName, @Phone, @Address, @Date, @CreatePerson, @TotalPrice)";
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    cmd.Parameters.AddWithValue("@DeliveryID", txtDeliveryID.Text);
                    cmd.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@Date", dtpDate.Value);
                    cmd.Parameters.AddWithValue("@CreatePerson", txtCreatePerson.Text);
                    cmd.Parameters.AddWithValue("@TotalPrice", decimal.Parse(labelTG.Text.Replace(",", ""))); // Chuyển TotalPrice về dạng số

                    cmd.ExecuteNonQuery();

                    // Kiểm tra nếu có ít nhất một dòng chi tiết hóa đơn trong DataGridView
                    

                    // Thêm chi tiết hóa đơn từ DataGridView vào bảng chi tiết
                    foreach (DataGridViewRow row in dgvDetails.Rows)
                    {
                        if (row.IsNewRow) continue;

                        string sqlDetailQuery = @"INSERT INTO [inventorydb].dbo.[dettab] 
                                          ([DetailID], [DeliveryID], [ProductName], [Price], [Quantity], [TotalPrice]) 
                                          VALUES (@DetailID, @DeliveryID, @ProductName, @Price, @Quantity, @TotalPrice)";
                        SqlCommand detailCmd = new SqlCommand(sqlDetailQuery, con);
                        detailCmd.Parameters.AddWithValue("@DetailID", Convert.ToInt32(row.Cells["tdetailid"].Value));
                        detailCmd.Parameters.AddWithValue("@DeliveryID", txtDeliveryID.Text);
                        detailCmd.Parameters.AddWithValue("@ProductName", row.Cells["tpname"].Value?.ToString());
                        detailCmd.Parameters.AddWithValue("@Price", Convert.ToDecimal(row.Cells["tprice"].Value));
                        detailCmd.Parameters.AddWithValue("@Quantity", Convert.ToInt32(row.Cells["tquantity"].Value));
                        detailCmd.Parameters.AddWithValue("@TotalPrice", Convert.ToDecimal(row.Cells["ttotal"].Value));

                        detailCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Đã thêm hóa đơn thành công", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            ClearInputs();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UpdateDetailIds();
            ClearInputs();
            LoadProductNames();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            Products ps = new Products();
            btnProduct.Enabled = false;
            LoadProductNames();
            ps.FormClosed += (s, args) =>
            {
                btnProduct.Enabled = true;
                LoadProductNames();
            };
            ps.ShowDialog();
        }
    }
}
