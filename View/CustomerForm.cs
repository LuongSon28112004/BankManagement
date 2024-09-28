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
using System.Web.UI.WebControls;
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

        private void CustomerForm_Load(object sender, EventArgs e)
        {

            //Load gender default
            this.LoadGender();

            //Load status default
            this.LoadStatus();

            //reset các textbox và combo box
            this.reset();
            //Load danh sach tat ca cac customer khi form duoc load len
            this.LoadAllCustomer();

            //Hover IMG customer none
            imgCustomerCustomerForm.HoverState.FillColor = Color.FromArgb(40, 42, 45);

            //Đăng ký sự kiện ScrollBar vertical
            dataGridViewCustomerInforCustomerForm.MouseWheel += dataGridViewCustomerInforCustomerForm_MouseWheel;
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

        public void LoadGender()
		{
            cbGenderCustomerForm.Items.Add("Male");
            cbGenderCustomerForm.Items.Add("Female");
        }

        public void LoadStatus()
        {
            cbStatusCustomerForm.Items.Add("active");
            cbStatusCustomerForm.Items.Add("inActive");
        }

        public void LoadAllCustomer()
		{
			viewModel.LoadAllCustomer();
            //duyệt datatable để lấy các thông tin hiển thị lên datagridview
            this.UpdateDataGridView(viewModel.DataTableCustomerInfor);
        }

		private void btnAddCustomerForm_Click(object sender, EventArgs e)
		{
            // Kiểm tra nếu ComboBox Status không chọn thì gán "" cho Status
            string status = cbStatusCustomerForm.SelectedItem != null ? cbStatusCustomerForm.SelectedItem.ToString() : "";
            // Kiểm tra nếu ComboBox Gender không chọn thì gán "" cho Gender
            string gender = cbGenderCustomerForm.SelectedItem != null ? cbGenderCustomerForm.SelectedItem.ToString() : "";
            string error = viewModel.CheckFormatCustomerForm(txtCCCDCustomerForm.Text,
                                                             txtCustomerNameCustomerForm.Text,
                                                             txtEmailCustomerForm.Text,
                                                             txtJobCustomerForm.Text,
                                                             txtPhoneNumberCustomerForm.Text,
                                                             txtDateOfBirthCustomerForm.Text,
                                                             txtNationalityCustomerForm.Text,
                                                             txtAddressCustomerForm.Text , status , gender);

            if (error != "0")
            {
                MessageBox.Show($"{error}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Lấy các thông tin từ các textBox
            this.UpdateViewModelFromForm();

			//add customer form viewModel
			viewModel.addCustomer();

            //Thay thế tất cả các dữ liệu trong datagridview
            dataGridViewCustomerInforCustomerForm.Rows.Clear();
            this.LoadAllCustomer();
        }

		private void btnSearchCustomerForm_Click(object sender, EventArgs e)
		{
			//Lấy ra các Customer phù hợp
            viewModel.SearchCustomer(txtSearchCustomerForm.Text);

			//xóa tất cả các dữ liệu trong datagridview
            dataGridViewCustomerInforCustomerForm.Rows.Clear();

            this.UpdateDataGridView(viewModel.DataTableCustomerInfor);
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
                string gender = selectedRow.Cells["Gender"].Value.ToString();
                string status = selectedRow.Cells["Status"].Value.ToString();


                // Hiển thị dữ liệu.
                txtCCCDCustomerForm.Text = cccd;
                //không cho phép chỉnh sửa dữ liệu căn cước công dân.
                txtCCCDCustomerForm.ReadOnly = true;
                txtCustomerNameCustomerForm.Text = name;
                txtPhoneNumberCustomerForm.Text = phone_number;
                txtDateOfBirthCustomerForm.Text = dateOfBirth;
                txtAddressCustomerForm.Text = address;
                txtNationalityCustomerForm.Text = nationality;
                txtJobCustomerForm.Text = job;
                txtEmailCustomerForm.Text = email;
                cbGenderCustomerForm.SelectedIndex = (gender == "Male") ? 0 : 1;
                cbStatusCustomerForm.SelectedIndex = (status == "Active") ? 0 : 1;
                cbStatusCustomerForm.Enabled = true;
            }
        }

        private void btnUpdateCustomerForm_Click(object sender, EventArgs e)
        {
            if (txtCCCDCustomerForm.ReadOnly == false)
            {
                MessageBox.Show("Phải chọn các tài khoản có sẵn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Kiểm tra nếu ComboBox Status không chọn thì gán "" cho Status
            string status = cbStatusCustomerForm.SelectedItem != null ? cbStatusCustomerForm.SelectedItem.ToString() : "";
            // Kiểm tra nếu ComboBox Gender không chọn thì gán "" cho Gender
            string gender = cbGenderCustomerForm.SelectedItem != null ? cbGenderCustomerForm.SelectedItem.ToString() : "";
            string error = viewModel.CheckFormatCustomerForm(txtCCCDCustomerForm.Text,
                                                              txtCustomerNameCustomerForm.Text,
                                                              txtEmailCustomerForm.Text,
                                                              txtJobCustomerForm.Text,
                                                              txtPhoneNumberCustomerForm.Text,
                                                              txtDateOfBirthCustomerForm.Text,
                                                              txtNationalityCustomerForm.Text,
                                                              txtAddressCustomerForm.Text ,status , gender);

            if (error != "0")
            {
                MessageBox.Show($"{error}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            //lấy dữ liệu từ các textBox
            this.UpdateViewModelFromForm();

            viewModel.updateCustomer();
            //xóa tất cả các dữ liệu trong datagridview
            dataGridViewCustomerInforCustomerForm.Rows.Clear();
            this.LoadAllCustomer();
        }

        private void btnResetCustomerForm_Click(object sender, EventArgs e)
        {
            this.reset();
            ////xóa tất cả các dữ liệu trong datagridview
            //dataGridViewCustomerInforCustomerForm.Rows.Clear();
            //this.LoadAllCustomer();
        }

        private void UpdateDataGridView(DataTable dataTable)
        {
            foreach (DataRow row in dataTable.Rows)
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
                string gender = row["gender"].ToString();
                string status = row["Status"].ToString();

                dataGridViewCustomerInforCustomerForm.Rows.Add(id, cccd, name, phone_number, formattedDateOfBirth, address, nationality, job, email, gender, status);
            }
        }

        private void btnDeleteCustomerForm_Click(object sender, EventArgs e)
        {
            //phải chọn các tài khoản có sẵn từ bảng 
            if (txtCCCDCustomerForm.ReadOnly == false)
            {
                MessageBox.Show("Phải chọn các tài khoản có sẵn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //lấy dữ liệu từ các textBox
            this.UpdateViewModelFromForm();

            viewModel.deleteCustomer();

            //xóa tất cả các dữ liệu trong datagridview
            dataGridViewCustomerInforCustomerForm.Rows.Clear();
            this.LoadAllCustomer();


        }
        private void reset()
        {
            txtSearchCustomerForm.Text = "";
            txtCCCDCustomerForm.Text = "";
            txtCCCDCustomerForm.ReadOnly = false;
            txtCustomerNameCustomerForm.Text = "";
            txtPhoneNumberCustomerForm.Text = "";
            txtDateOfBirthCustomerForm.Text = "";
            txtAddressCustomerForm.Text = "";
            txtNationalityCustomerForm.Text = "";
            txtJobCustomerForm.Text = "";
            txtEmailCustomerForm.Text = "";
            cbGenderCustomerForm.SelectedIndex = -1;
            cbStatusCustomerForm.SelectedIndex = 0;
            cbStatusCustomerForm.Enabled = false;
        }
        private void UpdateViewModelFromForm()
        {
            viewModel.Cccd = txtCCCDCustomerForm.Text;
            viewModel.Name = txtCustomerNameCustomerForm.Text;
            viewModel.Email = txtEmailCustomerForm.Text;
            viewModel.Job = txtJobCustomerForm.Text;
            viewModel.PhoneNumber = txtPhoneNumberCustomerForm.Text;
            viewModel.DateOfBirth = DateTime.Parse(txtDateOfBirthCustomerForm.Text);
            viewModel.Nationality = txtNationalityCustomerForm.Text;
            viewModel.Address = txtAddressCustomerForm.Text;
            viewModel.Status = cbStatusCustomerForm.SelectedItem.ToString();
            viewModel.Gender = cbGenderCustomerForm.SelectedItem.ToString();
        }


        private void UpdateFormFromViewModel()
        {
            txtCCCDCustomerForm.Text = viewModel.Cccd;
            txtCustomerNameCustomerForm.Text = viewModel.Name;
            txtEmailCustomerForm.Text = viewModel.Email;
            txtJobCustomerForm.Text = viewModel.Job;
            txtPhoneNumberCustomerForm.Text = viewModel.PhoneNumber;
            txtDateOfBirthCustomerForm.Text = viewModel.DateOfBirth.ToString("yyyy-MM-dd");
            txtNationalityCustomerForm.Text = viewModel.Nationality;
            txtAddressCustomerForm.Text = viewModel.Address;
        }
    }
}
