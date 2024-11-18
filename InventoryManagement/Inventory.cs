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
    public partial class Inventory : Form
    {
        public Inventory()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.Inventory_Load);
            dgvInventory.CellClick += dgvInventory_CellClick;
            dgvInventory.CellFormatting += dgvInventory_CellFormatting;
        }
        private SqlConnection GetConnection()
        {
            // Sử dụng ConfigurationManager để lấy chuỗi kết nối từ App.config
            string connectionString = ConfigurationManager.ConnectionStrings["InventoryDb"].ConnectionString;
            return new SqlConnection(connectionString);
        }
        private void Inventory_Load(object sender, EventArgs e)
        {
            LoadProductNames();
            LoadSupplierNames();
            ShowData();
        }
        public void ShowData()
        {
            using (SqlConnection con = GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM [inventorydb].dbo.[invtab] ORDER BY Date DESC", con);
                DataTable table = new DataTable();
                da.Fill(table);
                dgvInventory.Rows.Clear();
                foreach (DataRow item in table.Rows)
                {
                    int n = dgvInventory.Rows.Add();
                    dgvInventory.Rows[n].Cells["pid"].Value = item["ProductID"].ToString();
                    dgvInventory.Rows[n].Cells["tpname"].Value = item["ProductName"].ToString();
                    dgvInventory.Rows[n].Cells["tcname"].Value = item["CustomerName"].ToString();
                    dgvInventory.Rows[n].Cells["tprice"].Value = item["Price"].ToString();
                    dgvInventory.Rows[n].Cells["tquantity"].Value = item["Quantity"].ToString();
                    dgvInventory.Rows[n].Cells["ttotalprice"].Value = item["TotalPrice"].ToString();
                    dgvInventory.Rows[n].Cells["tdate"].Value = Convert.ToDateTime(item["Date"]).ToString("dd/MM/yyyy");    
                    dgvInventory.Rows[n].Cells["treceive"].Value = item["ReceivePerson"].ToString();

                }
                if (dgvInventory.Rows.Count > 0)
                {
                    labelDDH.Text = (dgvInventory.Rows.Count - 1).ToString();

                    float totalQuantity = 0;
                    float totalPrice = 0;
                    for (int i = 0; i < dgvInventory.Rows.Count; ++i)
                    {
                        // Kiểm tra nếu giá trị của ô không phải là null trước khi chuyển đổi
                        if (dgvInventory.Rows[i].Cells["tquantity"].Value != null &&
                            float.TryParse(dgvInventory.Rows[i].Cells["tquantity"].Value.ToString(), out float quantity))
                        {
                            totalQuantity += quantity;
                        }
                    }
                    labelSL.Text = totalQuantity.ToString("N0");
                    for (int i = 0; i < dgvInventory.Rows.Count; ++i)
                    {
                        // Kiểm tra nếu giá trị của ô không phải là null trước khi chuyển đổi
                        if (dgvInventory.Rows[i].Cells["ttotalprice"].Value != null &&
                            float.TryParse(dgvInventory.Rows[i].Cells["ttotalprice"].Value.ToString(), out float price))
                        {
                            totalPrice += price;
                        }
                    }
                    labelTG.Text = totalPrice.ToString("N0") + " Đồng";

                }
                else
                {
                    labelTG.Text = "0";
                    labelDDH.Text = "0";
                    labelSL.Text = "0"; // Đặt giá trị này thành 0 nếu không có hàng nào
                }

            }
        }
        private void dgvInventory_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Kiểm tra nếu cột là tprice hoặc ttotalprice và khác null
            if (dgvInventory.Columns[e.ColumnIndex].Name == "tprice" && dgvInventory.Columns[e.ColumnIndex].Name == "ttotalprice" || e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal price))
                {
                    // Định dạng số tiền với dấu phân cách hàng ngàn và thêm " Đồng"
                    e.Value = price.ToString("N0");
                    e.FormattingApplied = true;
                }
            }
        }
        private void dgvInventory_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvInventory.SelectedRows.Count > 0)
            {
                // Lấy thông tin của hàng được chọn
                DataGridViewRow selectedRow = dgvInventory.SelectedRows[0];
                // Hiển thị thông tin vào các TextBox
                txtInventoryID.Text = selectedRow.Cells["pid"].Value?.ToString();
                txtProductName.Text = selectedRow.Cells["tpname"].Value?.ToString();
                cbSupplierName.Text = selectedRow.Cells["tcname"].Value?.ToString();
                txtPrice.Text = selectedRow.Cells["tprice"].Value?.ToString();
                txtQuantity.Text = selectedRow.Cells["tquantity"].Value?.ToString();
                txtPrice.Text = selectedRow.Cells["tprice"].Value?.ToString();
                selectedRow.Cells["ttotalprice"].Value?.ToString();
                dtpDate.Text = selectedRow.Cells["tdate"].Value?.ToString();

            }
        }     
        private bool ProductExists(SqlConnection con, string productexistId)
        {
            string checkQuery = "SELECT COUNT(*) FROM invtab WHERE ProductID = @ProductID";
            SqlCommand checkCmd = new SqlCommand(checkQuery, con);
            checkCmd.Parameters.AddWithValue("@ProductID", productexistId);
            int count = (int)checkCmd.ExecuteScalar();
            return count > 0;
        }
        private bool ValidateInputs()
        {
            //string dateFormat = "dd/MM/yyyy";
            if (string.IsNullOrEmpty(txtInventoryID.Text))
            {
                MessageBox.Show("Mã sản phẩm không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!int.TryParse(txtInventoryID.Text, out int customerId))
            {
                MessageBox.Show("Mã sản phẩm không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtProductName.Text))
            {
                MessageBox.Show("Tên sản phẩm không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(cbSupplierName.Text))
            {
                MessageBox.Show("Tên khách không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (string.IsNullOrEmpty(txtPrice.Text))
            {
                MessageBox.Show("Tổng giá không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!long.TryParse(txtPrice.Text, out long price))
            {
                MessageBox.Show("Giá sản phẩm không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        
        private void dgvInventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo rằng người dùng đã nhấp vào một hàng hợp lệ
            {
                // Lấy hàng hiện tại từ DataGridView
                DataGridViewRow selectedRow = dgvInventory.Rows[e.RowIndex];

                // Hiển thị thông tin vào các TextBox
                txtInventoryID.Text = selectedRow.Cells["pid"].Value?.ToString();
                txtProductName.Text = selectedRow.Cells["tpname"].Value?.ToString();
                cbSupplierName.Text = selectedRow.Cells["tcname"].Value?.ToString();
                txtPrice.Text = selectedRow.Cells["tprice"].Value?.ToString();
                txtQuantity.Text = selectedRow.Cells["tquantity"].Value?.ToString();
                selectedRow.Cells["ttotalprice"].Value?.ToString();
                dtpDate.Text = selectedRow.Cells["tdate"].Value?.ToString();
                txtReceivePerson.Text = selectedRow.Cells["treceive"].Value?.ToString();

            }
        }
        private void dgvInventory_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem cột hiện tại là Quantity hoặc UnitPrice
            if (dgvInventory.Columns[e.ColumnIndex].Name == "Quantity" || dgvInventory.Columns[e.ColumnIndex].Name == "Price")
            {
                try
                {
                    // Lấy giá trị của cột Quantity và UnitPrice
                    int quantity = Convert.ToInt32(dgvInventory.Rows[e.RowIndex].Cells["Quantity"].Value);
                    decimal price = Convert.ToDecimal(dgvInventory.Rows[e.RowIndex].Cells["Price"].Value);

                    // Tính thành tiền
                    decimal totalprice = quantity * price;

                    // Gán giá trị tính được vào cột Total
                    dgvInventory.Rows[e.RowIndex].Cells["TotalPrice"].Value = totalprice;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tính toán: " + ex.Message);
                }
            }
        }
        private void LoadProductNames()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["InventoryDb"].ConnectionString;
            string query = "SELECT ProductName FROM protab";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                // Xóa các mục trong ComboBox trước khi thêm mới
                txtProductName.Items.Clear();
                while (reader.Read())
                {
                    txtProductName.Items.Add(reader["ProductName"].ToString());
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
                cbSupplierName.Items.Clear();
                while (reader.Read())
                {
                    cbSupplierName.Items.Add(reader["SupplierName"].ToString());
                }

                reader.Close();
            }
        }
        private void dgvInventory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            using (SqlConnection con = GetConnection())
            {
                con.Open();

                if (ProductExists(con, txtInventoryID.Text))
                {
                    MessageBox.Show("Mã đơn nhập hàng đã tồn tại. Vui lòng nhập mã khác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    decimal price = decimal.Parse(txtPrice.Text);
                    int quantity = int.Parse(txtQuantity.Text);
                    decimal totalPrice = price * quantity;

                    string sqlQuery = @"INSERT INTO [inventorydb].dbo.[invtab] ([ProductId], [ProductName], [CustomerName], [Price], [Quantity], [TotalPrice], [Date], [ReceivePerson]) 
                                    VALUES (@ProductID, @ProductName, @CustomerName, @Price, @Quantity, @TotalPrice, @Date, @ReceivePerson)";
                    using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@ProductID", txtInventoryID.Text);
                        cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text);
                        cmd.Parameters.AddWithValue("@CustomerName", cbSupplierName.Text);
                        cmd.Parameters.AddWithValue("@Price", price);
                        cmd.Parameters.AddWithValue("@Quantity", quantity);
                        cmd.Parameters.AddWithValue("@TotalPrice", totalPrice);
                        cmd.Parameters.AddWithValue("@Date", DateTime.ParseExact(dtpDate.Text, "dd/MM/yyyy", null).Date);
                        cmd.Parameters.AddWithValue("@ReceivePerson", txtReceivePerson.Text);
                        cmd.ExecuteNonQuery();
                        //MessageBox.Show("Đã thêm đơn nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearInputs();
                        ShowData();
                    }
                }
            }
        }
        private void ClearInputs()
        {
            txtInventoryID.Clear();
            txtProductName.SelectedIndex = -1;
            cbSupplierName.SelectedIndex = -1;
            txtQuantity.Clear();
            txtPrice.Clear();
            dtpDate.Value = DateTime.Now;
            txtReceivePerson.Clear();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            using (SqlConnection con = GetConnection())
            {
                con.Open();
                decimal price = decimal.Parse(txtPrice.Text);
                int quantity = int.Parse(txtQuantity.Text);
                decimal totalPrice = price * quantity;
                string sqlQuery = "UPDATE invtab SET ProductName=@ProductName, CustomerName=@CustomerName, Price=@Price, Quantity=@Quantity, Date=@Date, TotalPrice=@TotalPrice, ReceivePerson=@ReceivePerson WHERE ProductID=@ProductID";

                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ProductID", txtInventoryID.Text);
                cmd.Parameters.AddWithValue("@ProductName", txtProductName.Text);
                cmd.Parameters.AddWithValue("@CustomerName", cbSupplierName.Text);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.Parameters.AddWithValue("@Quantity", quantity);
                cmd.Parameters.AddWithValue("@TotalPrice", totalPrice);
                cmd.Parameters.Add(new SqlParameter("@Date", SqlDbType.Date)
                {
                    Value = DateTime.ParseExact(dtpDate.Text, "dd/MM/yyyy", null).Date
                });
                cmd.Parameters.AddWithValue("@ReceivePerson", txtReceivePerson.Text);


                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Cập nhật thông tin thành công", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa thông tin này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                using (SqlConnection con = GetConnection())
                {
                    con.Open();
                    //xoá sp dựa trên ProductID
                    string sqlQuery = "DELETE FROM [invtab] WHERE [ProductID] = @ProductID";
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    cmd.Parameters.AddWithValue("@ProductID", txtInventoryID.Text);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        ShowData();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa. Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = GetConnection())
            {
                con.Open();
                // Lấy thông tin sản phẩm dựa trên ProductID
                string sqlQuery = "SELECT ProductName, CustomerName, Price, Quantity, Date FROM invtab WHERE ProductID = @ProductID";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                cmd.Parameters.AddWithValue("@ProductID", txtInventoryID.Text);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtProductName.Text = reader["ProductName"].ToString();
                    cbSupplierName.Text = reader["CustomerName"].ToString();                    
                    txtPrice.Text = reader["Price"].ToString();
                    txtQuantity.Text = reader["Quantity"].ToString();
                    dtpDate.Text = Convert.ToDateTime(reader["Date"]).ToString("dd/MM/yyyy");
                    txtReceivePerson.Text = reader["ReceivePerson"].ToString();


                }
                else
                {
                    MessageBox.Show("Mã đơn nhập hàng không đúng, không tìm thấy thông tin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                reader.Close();
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearInputs();
            LoadProductNames();
            LoadSupplierNames();
            ShowData();
        }
        private void labelSL_Click(object sender, EventArgs e)
        {

        }

        private void labelTG_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnNCC_Click(object sender, EventArgs e)
        {
            Suppliers sp = new Suppliers();
            btnNCC.Enabled = false;
            // Gọi LoadSupplierNames trước khi hiển thị form
            LoadSupplierNames();
            sp.FormClosed += (s, args) =>
            {
                btnNCC.Enabled = true;
                // Gọi lại LoadSupplierNames sau khi form đóng
                LoadSupplierNames();
            };
            sp.ShowDialog();
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
