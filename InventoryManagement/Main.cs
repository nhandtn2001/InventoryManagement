using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace InventoryManagement
{

    public partial class Main : Form
    {
        private string memberId;
        private string userName;
        private string firstName;
        private string lastName;
        private string yearofBirth;
        private string gender;
        private string identityID;
        private string address;
        private string phone;
        private string dateAccept;
        private string type;
        private string status;
        public Main(string memberID, string userName,string firstName,string lastName, string yearofBirth,
        string gender, string identityID, string address, string phone, string dateAccept, string type, string status)
        {
            InitializeComponent();
            lblName.Text = "Xin chào: " + firstName;
            this.memberId = memberID;
            this.userName = userName;
            this.firstName = firstName;
            this.lastName = lastName;
            this.yearofBirth = yearofBirth;
            this.gender = gender;
            this.identityID = identityID;
            this.address = address;
            this.phone = phone;
            this.dateAccept = dateAccept;
            this.type = type;
            this.status = status;
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            Products ps = new Products();
            // Vô hiệu hóa Button
            btnProduct.Enabled = false;
            // Đăng ký sự kiện FormClosed để kích hoạt lại Button khi Form đóng
            ps.FormClosed += (s, args) =>
            {
                btnProduct.Enabled = true;
            };
            // Mở Form dưới dạng một hộp thoại (modal)
            ps.ShowDialog();
        }
        private void btnCustomer_Click(object sender, EventArgs e)
        {
            Customers cs = new Customers();
            btnCustomer.Enabled = false;
            cs.FormClosed += (s,args) =>
            {  btnCustomer.Enabled = true; };
            cs.ShowDialog();
        }
        private void btnInventory_Click(object sender, EventArgs e)
        {
            Inventory it = new Inventory();
            btnInventory.Enabled = false;
            it.FormClosed += (s, args) =>
            { btnInventory.Enabled = true; };
            it.ShowDialog();
        }
        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Transport ts = new Transport();
            //button5 .Enabled = false;
            //ts.FormClosed += (s,args) =>
            //{ button5.Enabled = true; };
            //ts.ShowDialog();
        }


        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn đăng xuất không?", "Đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                Login form = new Login();
                form.ShowDialog();
                this.Close();
            }
        }

        private void btnLoaiSP_Click(object sender, EventArgs e)
        {
            Category ct = new Category();
            btnLoaiSP.Enabled = false;
            ct.FormClosed += (s, args) =>
            { btnLoaiSP.Enabled = true; };
            ct.ShowDialog();
        }

        private void btnNCC_Click(object sender, EventArgs e)
        {
            Suppliers sp = new Suppliers();
            btnNCC.Enabled = false;
            sp.FormClosed += (s, args) =>
            {
                btnNCC.Enabled = true;
            };
            sp.ShowDialog();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            Infomation info = new Infomation(memberId, userName, firstName,lastName, 
                yearofBirth, gender, identityID, address, phone, dateAccept, type, status);
            info.ShowDialog();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            Statistics statistics = new Statistics();
            btnThongKe.Enabled = false;
            statistics.FormClosed += (s, args) =>
            {
                btnThongKe.Enabled = true;
            };
            statistics.ShowDialog();
        }

        private void BtnBestSales_Click(object sender, EventArgs e)
        {
            BestSales bestSales = new BestSales();
            btnBestSales.Enabled = false;
            bestSales.FormClosed += (s, args) =>
            {
                btnBestSales.Enabled = true;
            };
            bestSales.ShowDialog();

        }

        private void btnDelivery_Click(object sender, EventArgs e)
        {
            Delivery delivery = new Delivery();
            btnDelivery.Enabled = false;
            delivery.FormClosed += (s, args) =>
            {
                btnDelivery.Enabled = true;
            };
            delivery.ShowDialog();
        }

        private void btnCheckDelivery_Click(object sender, EventArgs e)
        {
            CheckInvoices checkInvoices = new CheckInvoices();
            btnCheckDelivery.Enabled = false;
            checkInvoices.FormClosed += (s, args) =>
            {
                btnCheckDelivery.Enabled = true;
            };
            checkInvoices.ShowDialog();
        }
    }
}
