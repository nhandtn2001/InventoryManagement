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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace InventoryManagement
{
    public partial class Infomation : Form
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
        public Infomation(string memberID, string userName, string firstName, string lastName, string yearofBirth,
        string gender, string identityID, string address, string phone, string dateAccept, string type, string status)
        {
            InitializeComponent();
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
            lbMemberID.Text = memberID;
            lbUserName.Text = userName;
            lbFirstName.Text = firstName;
            lbLastName.Text =  lastName;
            lbYearOfBirth.Text = yearofBirth;
            lbGender.Text = gender;
            lbidentityID.Text = identityID;
            lbAddress.Text = address;
            lbPhone.Text = phone;
            lbAccept.Text = dateAccept;
            lbType.Text = type;
            lbStatus.Text = status;

            DateTime birthDate = DateTime.Parse(lbYearOfBirth.Text);
            SetFormattedDate(lbYearOfBirth, birthDate);
            DateTime accept = DateTime.Parse(lbAccept.Text);
            SetFormattedDate1(lbAccept, accept);

        }
        private void SetFormattedDate(Label label, DateTime date)
        {
            lbYearOfBirth.Text = date.ToString("dd/MM/yyyy");
        }
        private void SetFormattedDate1(Label label, DateTime date)
        {
            lbAccept.Text = date.ToString("dd/MM/yyyy");
        }

        // Khi form được load, hiển thị thông tin
        private void Information_Load(object sender, EventArgs e)
        {

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Infomation_Load(object sender, EventArgs e)
        {

        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            ChangePassword cp = new ChangePassword(userName);
            btnChangePassword.Enabled = false;
            cp.FormClosed += (s, args) =>
            { btnChangePassword.Enabled = true; };
            cp.ShowDialog();
        }
    }
}
