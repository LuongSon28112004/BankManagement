using BankManagement.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankManagement.ViewModel
{
    internal class AccountViewModel
    {
        //defualt length of password = 12;
        const int PASSWORD_LENGH = 12;

        CustomerAccountWithInforRepository customerAccountWithInforRepository;

        //cac thuoc tinh bind voi customerAccount Form
        private int account_number;
        private string username;
        private string account_status;
        private DateTime date_opened;
        private Decimal balance;

        // ----------------------------------------
        private DataTable dataTableAccountInfor;
        private DataTable dataTableCustomerInfor;
        private DataTable dataTableAccount;

        public AccountViewModel()
        {
            this.customerAccountWithInforRepository = new CustomerAccountWithInforRepository();
        }

       
        //getter and setter
        public int Account_number { get => account_number; set => account_number = value; }
        public string Username { get => username; set => username = value; }
        public string Account_status { get => account_status; set => account_status = value; }
        public DateTime Date_opened { get => date_opened; set => date_opened = value; }
        public decimal Balance { get => balance; set => balance = value; }
        public DataTable DataTableAccountInfor { get => dataTableAccountInfor; set => dataTableAccountInfor = value; }
        public DataTable DataTableCustomerInfor { get => dataTableCustomerInfor; set => dataTableCustomerInfor = value; }
        public DataTable DataTableAccount { get => dataTableAccount; set => dataTableAccount = value; }

        //-----------------------lấy một danh sách các tài khoản------------------------------------
        public void searchCustomerAccountByAccountNumber(int account_number)
        {
            dataTableAccountInfor = customerAccountWithInforRepository.SearchCustomerAccountByAccountNumber(account_number);
        }


        //---------------------------lấy thông tin của khách hàng----------------------------------------------------------------------
        public void searchCustomerInforByCccd(string cccd)
        {
            dataTableCustomerInfor = customerAccountWithInforRepository.SearchCustomerInforByCccd(cccd);
        }

        //---------------------------------lấy danh sách tất cả các tài khoản---------------------------------------------------------------------------

        public void LoadAllCustomerAccount()
        {
            dataTableAccount = customerAccountWithInforRepository.LoadAllAccount();
        }

        //-----------------------------thêm một tài khoản vào csdl-----------------------------------------------------------------------------------------

        public void AddCustomerAccount(int customer_id)
        {
            if(customerAccountWithInforRepository.getCustomerAccountByUserName(this.username) != null)
            {
                MessageBox.Show("Đã có username này trong hệ thống,vui lòng chọn một tên khác","Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string randomPassWord = GenerateRandomPassword(PASSWORD_LENGH);
            CustomerAccount customerAccount = new CustomerAccount(0, this.username, randomPassWord, this.balance, this.date_opened, customer_id, "active", this.Account_number);
            customerAccountWithInforRepository.AddCustomerAccount(customerAccount);
        }

        //--------------------------xóa một tài khoản--------------------------------------------------------------------------------------

        public void deleteCustomerAccount()
        {
            customerAccountWithInforRepository.deleteCustomerAccount(this.Username);
        }



        public void updateStatusAccountCustomer()
        {
            customerAccountWithInforRepository.updateStatusAccountCustomer(this.Username);
        }


        //-----------------------------------------------------------------------------------------------------------------
        static string GenerateRandomPassword(int length)
        {
            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()";
            StringBuilder password = new StringBuilder();
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] randomBytes = new byte[1];
                while (password.Length < length)
                {
                    rng.GetBytes(randomBytes);
                    char randomChar = (char)randomBytes[0];
                    if (validChars.Contains(randomChar))
                    {
                        password.Append(randomChar);
                    }
                }
            }
            return password.ToString();
        }


    }
}
