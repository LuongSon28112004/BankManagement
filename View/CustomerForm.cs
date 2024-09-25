using BankManagement.Model;
using BankManagement.ViewModel;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BankManagement
{
	public partial class CustomerForm : Form
	{
		CustomerViewModel viewModel;
		public CustomerForm()
		{
			InitializeComponent();
			viewModel = new CustomerViewModel();
			this.ShowInTaskbar = false;
		}

		public void LoadGender()
		{
            cbGenderCustomerForm.Items.Add("Male");
            cbGenderCustomerForm.Items.Add("Female");
        }

		public void LoadAllCustomer()
		{
			DataTable dt = viewModel.LoadAllCustomer();
            //duyệt datatable để lấy các thông tin hiển thị lên datagridview
            foreach (DataRow row in dt.Rows)
            {
                int id = Convert.ToInt32(row["id"]);
                string cccd = row["cccd"].ToString();
                string name = row["name"].ToString();
                string phone_number = row["phone_number"].ToString();
                // Parse and format the dateOfBirth to only display the date part
                DateTime dateOfBirth = DateTime.Parse(row["date_of_birth"].ToString());
                string formattedDateOfBirth = dateOfBirth.ToString("dd/MM/yyyy");
                string address = row["address"].ToString();
                string nationality = row["nationality"].ToString();
                string job = row["job"].ToString();
                string email = row["email"].ToString();

                dataGridViewCustomerInforCustomerForm.Rows.Add(id, cccd, name, phone_number, formattedDateOfBirth, address, nationality, job, email);
            }
        }

		public void reset()
		{
			txtCCCDCustomerForm.Text = "";
            txtCCCDCustomerForm.Enabled = true;
            txtCustomerNameCustomerForm.Text = "";
            txtPhoneNumberCustomerForm.Text = "";
            txtDateOfBirthCustomerForm.Text = "";
            txtAddressCustomerForm.Text = "";
            txtNationalityCustomerForm.Text = "";
            txtJobCustomerForm.Text = "";
            txtEmailCustomerForm.Text = "";
        }

		private void CustomerForm_Load(object sender, EventArgs e)
		{
			//reset các textbox và combo box
			this.reset();
			//Load gender dafault
			this.LoadGender();

			//Load danh sach tat ca cac customer khi form duoc load len
			this.LoadAllCustomer();
			

			//Đăng ký sự kiện ScrollBar vertical
			dataGridViewCustomerInforCustomerForm.MouseWheel += dataGridViewCustomerInforCustomerForm_MouseWheel;
		}

        private void cbGenderCustomerForm_Paint(object sender, PaintEventArgs e)
        {
            // Lấy kích thước của ComboBox
            Rectangle rect = new Rectangle(0, 0, cbGenderCustomerForm.Width, cbGenderCustomerForm.Height);

            // Tùy chỉnh vẽ viền
            e.Graphics.DrawRectangle(new Pen(Color.Red, 2), rect);
        }

        //Sự kiện sử dụng con lăn chuột để kéo dataGridView
        private void dataGridViewCustomerInforCustomerForm_MouseWheel(object sender, MouseEventArgs e)
		{
			if (e.Delta > 0)
			{
				if (dataGridViewCustomerInforCustomerForm.FirstDisplayedScrollingRowIndex > 0)
				{
					dataGridViewCustomerInforCustomerForm.FirstDisplayedScrollingRowIndex--;
				}
			}
			else if (e.Delta < 0)
			{
				if (dataGridViewCustomerInforCustomerForm.FirstDisplayedScrollingRowIndex < dataGridViewCustomerInforCustomerForm.RowCount - 1)
				{
					dataGridViewCustomerInforCustomerForm.FirstDisplayedScrollingRowIndex++;
				}
			}
		}

		private void btnAddCustomerForm_Click(object sender, EventArgs e)
		{
            if (txtCCCDCustomerForm.Text == "" || txtCustomerNameCustomerForm.Text == "" || txtPhoneNumberCustomerForm.Text == "" 
				|| txtDateOfBirthCustomerForm.Text == "" || txtAddressCustomerForm.Text == "" || txtNationalityCustomerForm.Text == "" 
				|| txtJobCustomerForm.Text == "" || txtEmailCustomerForm.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Lấy các thông tin từ các textBox
            int id = 0;
			string cccd = txtCCCDCustomerForm.Text;
			string name = txtCustomerNameCustomerForm.Text;
			string phone_number = txtPhoneNumberCustomerForm.Text;
			DateTime date_of_birth = DateTime.Parse(txtDateOfBirthCustomerForm.Text);
			date_of_birth.ToString("yyyy-MM-dd");
			string address = txtAddressCustomerForm.Text;
			string nationality = txtNationalityCustomerForm.Text;
			string job = txtJobCustomerForm.Text;
			string email = txtEmailCustomerForm.Text;
			string photo = "";


			//tạo 1 customerInfor
			CustomerInfor customerInfor = new CustomerInfor(id, name, cccd, phone_number, email, job, nationality, address, date_of_birth, photo);
			viewModel.addCustomer(customerInfor);
            //xóa tất cả các dữ liệu trong datagridview
            dataGridViewCustomerInforCustomerForm.Rows.Clear();
            this.LoadAllCustomer();
        }

		private void btnSearchCustomerForm_Click(object sender, EventArgs e)
		{
			//datatable trả về 1 bảng các customer 
            DataTable dt = viewModel.SearchCustomer(txtSearchCustomerForm.Text);
			//xóa tất cả các dữ liệu trong datagridview
            dataGridViewCustomerInforCustomerForm.Rows.Clear();
            //duyệt datatable để lấy các thông tin hiển thị lên datagridview
            foreach (DataRow row in dt.Rows)
			{
				int id = Convert.ToInt32(row["id"]);
				string cccd = row["cccd"].ToString();
				string name = row["name"].ToString();
				string phone_number = row["phone_number"].ToString();
                // Parse and format the dateOfBirth to only display the date part
                DateTime dateOfBirth = DateTime.Parse(row["date_of_birth"].ToString());
                string formattedDateOfBirth = dateOfBirth.ToString("dd/MM/yyyy");
                string address = row["address"].ToString();
				string nationality = row["nationality"].ToString();
				string job = row["job"].ToString() ;
				string email = row["email"].ToString();
                dataGridViewCustomerInforCustomerForm.Rows.Add(id, cccd, name, phone_number, formattedDateOfBirth, address , nationality , job , email);
            }
        }

        private void dataGridViewCustomerInforCustomerForm_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem chỉ số hàng hợp lệ
            if (e.RowIndex >= 0)
            {
                // Lấy hàng được chọn
                DataGridViewRow selectedRow = dataGridViewCustomerInforCustomerForm.Rows[e.RowIndex];

                // Lấy dữ liệu từ các cột trong hàng với kiểm tra null
                int id = Convert.ToInt32(selectedRow.Cells["id"].Value);
				string cccd = selectedRow.Cells["cccd"].Value.ToString();
				string name = selectedRow.Cells["customerName"].Value.ToString();
				string phone_number = selectedRow.Cells["phoneNumber"].Value.ToString();
				string dateOfBirth = selectedRow.Cells["dateOfBirth"].Value.ToString();
				string address = selectedRow.Cells["address"].Value.ToString();
				string nationality = selectedRow.Cells["nationality"].Value.ToString();
				string job = selectedRow.Cells["job"].Value.ToString();
				string email = selectedRow.Cells["email"].Value.ToString();

                // Hiển thị dữ liệu.
                txtCCCDCustomerForm.Text = cccd;
                //không cho phép chỉnh sửa dữ liệu căn cước công dân.
                txtCCCDCustomerForm.Enabled = false;
                txtCustomerNameCustomerForm.Text = name;
                txtPhoneNumberCustomerForm.Text = phone_number;
                txtDateOfBirthCustomerForm.Text = dateOfBirth;
                txtAddressCustomerForm.Text = address;
                txtNationalityCustomerForm.Text = nationality;
                txtJobCustomerForm.Text = job;
                txtEmailCustomerForm.Text = email;
            }
        }

        private void btnUpdateCustomerForm_Click(object sender, EventArgs e)
        {
            if (txtCCCDCustomerForm.Text == "" || txtCustomerNameCustomerForm.Text == "" || txtPhoneNumberCustomerForm.Text == ""
                || txtDateOfBirthCustomerForm.Text == "" || txtAddressCustomerForm.Text == "" || txtNationalityCustomerForm.Text == ""
                || txtJobCustomerForm.Text == "" || txtEmailCustomerForm.Text == "")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(txtCCCDCustomerForm.Enabled == true)
            {
                MessageBox.Show("Phải chọn các tài khoản có sẵn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Lấy các thông tin từ các textBox
            int id = 0;
            string cccd = txtCCCDCustomerForm.Text;
            string name = txtCustomerNameCustomerForm.Text;
            string phone_number = txtPhoneNumberCustomerForm.Text;
            DateTime date_of_birth = DateTime.Parse(txtDateOfBirthCustomerForm.Text);
            date_of_birth.ToString("yyyy-MM-dd");
            string address = txtAddressCustomerForm.Text;
            string nationality = txtNationalityCustomerForm.Text;
            string job = txtJobCustomerForm.Text;
            string email = txtEmailCustomerForm.Text;
            string photo = "";


            //tạo 1 customerInfor
            CustomerInfor customerInfor = new CustomerInfor(id, name, cccd, phone_number, email, job, nationality, address, date_of_birth, photo);
            viewModel.updateCustomer(customerInfor);
            //xóa tất cả các dữ liệu trong datagridview
            dataGridViewCustomerInforCustomerForm.Rows.Clear();
            this.LoadAllCustomer();
        }

        private void btnResetCustomerForm_Click(object sender, EventArgs e)
        {
            this.reset();
        }
    }
}
