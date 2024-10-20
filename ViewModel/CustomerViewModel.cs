using BankManagement.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankManagement.ViewModel
{
    internal class CustomerViewModel
    {
        private CustomerInforRepository customerInforRepository;
        private CustomerAccountWithInforRepository customerAccountWithInforRepository;

        //Các thuộc tính bind với CustomerForm
        private int id;
        private string cccd;
        private string name;
        private string email;
        private string job;
        private string phoneNumber;
        private DateTime dateOfBirth;
        private string nationality;
        private string address;
        private string status;
        private string gender;
        private string photo;
        private DataTable dataTableCustomerInfor;

        public CustomerViewModel()
        {
            customerInforRepository = new CustomerInforRepository();
            customerAccountWithInforRepository = new CustomerAccountWithInforRepository();
        }

        // Getter và Setter cho từng thuộc tính
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Cccd
        {
            get { return cccd; }
            set { cccd = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Job
        {
            get { return job; }
            set { job = value; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }

        public string Nationality
        {
            get { return nationality; }
            set { nationality = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public DataTable DataTableCustomerInfor
        {
            get { return dataTableCustomerInfor; }
            set { dataTableCustomerInfor = value; }
        }

        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public string Photo
        {
            get { return photo; }
            set { photo = value; }
        }





        //Thêm một khách hàng-------------------------------------------------------------------------------------------------------------------------------------------------------------
        public void addCustomer()
        {
            //Tìm khách hàng theo cccd, nếu có thì return
            CustomerInfor customerInfor = customerInforRepository.getCustomerInforByCccd(this.Cccd);
            if (customerInfor != null)
            {
                MessageBox.Show("Đã có Khách Hàng này trong hệ thống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (customerInfor == null)
            {
                CustomerInfor cI = new CustomerInfor(0, this.name, this.cccd, this.phoneNumber, this.email, this.job, this.nationality, this.address, this.dateOfBirth, this.photo , this.status , this.gender);
                customerInforRepository.addCustomer(cI);
            }
        }





        //Cập nhật thông tin khách hàng---------------------------------------------------------------------------------------------------------------------------------------------------------
        public void updateCustomer()
        {
            CustomerInfor cI = new CustomerInfor(0, this.name, this.cccd, this.phoneNumber, this.email, this.job, this.nationality, this.address, this.dateOfBirth, this.photo , this.status , this.gender);
            customerInforRepository.updateCustomer(cI);
        }





        //Xoá một khách hàng----------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public void deleteCustomer()
        {
            DataTable lsCustomerAccount = customerAccountWithInforRepository.SearchCustomerAccountByCccd(this.Cccd);
            foreach (DataRow row in lsCustomerAccount.Rows)
            {
                if (row["account_status"].ToString() == "Active")
                {
                    throw new Exception("Vẫn còn tài khoản của khách hàng tồn tại!");
                }
            }
            customerInforRepository.deleteCustomer(this.cccd);
        }






        //Tìm kiếm list khách hàng theo cccd để thêm vào dataGridView-----------------------------------------------------------------------------------------------------------------------------
        public void SearchCustomer(string Cccd)
        {
            this.dataTableCustomerInfor = customerInforRepository.searchCustomerByCccd(Cccd);
        }





        //Lấy ra toàn bộ khách hàng để thêm vào dataGridView sau khi loadForm, resetForm...--------------------------------------------------------------------------------------------------------
        public void LoadAllCustomer()
        {
            this.dataTableCustomerInfor = customerInforRepository.LoadAllCustomer();
        }





        //Kiểm tra định dạng của các trường điền thông tin khách hàng--------------------------------------------------------------------------------------------------------------------------------
        public string CheckFormatCustomerForm(string txtCCCDCustomerForm,
                                              string txtCustomerNameCustomerForm, 
                                              string txtEmailCustomerForm, 
                                              string txtJobCustomerForm,
                                              string txtPhoneNumberCustomerForm,
                                              string txtDateOfBirthCustomerForm,
                                              string txtNationalityCustomerForm,
                                              string txtAddressCustomerForm,
                                              string cbGenderCustomerForm)
        {
            string error = "0";
            if (txtCCCDCustomerForm == "" ||
                txtCustomerNameCustomerForm == "" ||
                txtEmailCustomerForm == "" ||
                txtJobCustomerForm == "" ||
                txtPhoneNumberCustomerForm == "" ||
                txtDateOfBirthCustomerForm == "" ||
                txtNationalityCustomerForm == "" ||
                txtAddressCustomerForm == "" ||
                cbGenderCustomerForm == "")
            {
                error = "Vui lòng điền đầy đủ thông tin!";
                return error;
            }

            // Tên chỉ được phép là chữ cái in hoa
            if (!txtCustomerNameCustomerForm.All(c => char.IsUpper(c) || char.IsWhiteSpace(c)))
            {
                error = "Vui lòng nhập tên khách hàng đúng định dạng!\nVD: DINH NGOC THE";
                return error;
            }

            // Kiểm tra định dạng của CCCD phải toàn là số
            if (!txtCCCDCustomerForm.All(char.IsDigit))
            {
                error = "Vui lòng nhập đúng định dạng CCCD!";
                return error;
            }

            // Kiểm tra định dạng của DateOfBirth
            if (!DateTime.TryParseExact(txtDateOfBirthCustomerForm, "dd/MM/yyyy",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out _))
            {
                error = "Vui lòng nhập đúng định dạng ngày sinh: DD/MM/YYYY!";
                return error;
            }

            // Kiểm tra định dạng SĐT phải toàn là số
            if (!txtPhoneNumberCustomerForm.All(char.IsDigit))
            {
                error = "Vui lòng nhập đúng định dạng SĐT!";
                return error;
            }

            // Định nghĩa biểu thức chính quy để kiểm tra định dạng email
            var emailPattern = @"[a-z0-9._%+\-]+@[a-z0-9.\-]+\.[a-z]{2,}$"; 
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtEmailCustomerForm, emailPattern))
            {
                error = "Địa chỉ email không hợp lệ!";
                return error;
            }

            return error;
        }
    }
}
