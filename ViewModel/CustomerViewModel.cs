using BankManagement.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankManagement.ViewModel
{
    internal class CustomerViewModel
    {
        private CustomerInforRepository customerInforRepository;

        //Các thuộc tính bind với CustomerForm
        private int id;
        private string cccd;
        private string name;
        private string email;
        private string job;
        private string phone_number;
        private DateTime date_of_birth;
        private string nationality;
        private string address;

        public CustomerViewModel()
        {
            customerInforRepository = new CustomerInforRepository();
        }

        //Lấy thông tin từ repository
        public void LoadCustomer(CustomerInfor customerInfor)
        {
            //CustomerInfor customerInfor = customerInforRepository.getCustomerInforById(CustomerInforID);
            this.id = customerInfor.Id;
            this.cccd = customerInfor.Cccd;
            this.name = customerInfor.Name;
            this.email = customerInfor.Email;
            this.job = customerInfor.Job;
            this.phone_number = customerInfor.PhoneNumber;
            this.date_of_birth = customerInfor.DateOfBirth;
            this.nationality = customerInfor.Nationality;
            this.address = customerInfor.Address;
        }

        public void addCustomer(CustomerInfor customer)
        {
            CustomerInfor customerInfor = customerInforRepository.getCustomerInforByCccd(customer.Cccd);
            if (customerInfor != null)
            {
                MessageBox.Show("Đã có Khách Hàng này trong hệ thống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (customerInfor == null)
            {
                customerInforRepository.addCustomer(customer);
            }
        }

        public void updateCustomer(CustomerInfor customer)
        {
            if(customer != null)
            {
                customerInforRepository.updateCustomer(customer);
            }
        }

        public DataTable SearchCustomer(string Cccd)
        {
            DataTable dataTable = customerInforRepository.searchCustomerByCccd(Cccd);
            return dataTable;
        }

        public DataTable LoadAllCustomer()
        {
            DataTable datatable = customerInforRepository.LoadAllCustomer();
            return datatable;
        }


    }
}
