using BankManagement.Language;
using BankManagement.Model;
using BankManagement.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Windows.Forms;

namespace BankManagement.ViewModel
{
    internal class AccountViewModel
    {
        //Độ dài mật khẩu mặc định khi tạo mới tài khoản
        const int PASSWORD_LENGH = 12;
        CustomerAccountWithInforRepository customerAccountWithInforRepository;
        CustomerInforRepository customerInforRepository;
        LogRepository logRepository;
        TransactionReponsitory TransactionReponsitory;

        //Các thuộc tính bind với CustomerAccountForm
        private int staffId;
        private int account_number;
        private string username;
        private string account_status;
        private DateTime date_opened;
        private Decimal balance;
        private DataTable dataTableAccountInfor; //Danh sách dữ liệu chứa thông tin khách hàng
        private DataTable dataTableCustomerInfor; //Danh sách dữ liệu chứa cả thông tin khách hàng và tài khoản
        private DataTable dataTableAllTransfer;
        private DataTable datatableAllDeposit;
        private DataTable datatableAllWithdraw;

        public AccountViewModel()
        {
            this.customerAccountWithInforRepository = new CustomerAccountWithInforRepository();
            this.customerInforRepository = new CustomerInforRepository();
            this.logRepository = new LogRepository();
            this.TransactionReponsitory = new TransactionReponsitory();
        }
       
        //Getter, setter
        public int Account_number { get => account_number; set => account_number = value; }

        public int StaffId { get => staffId; set => staffId = value; }
        public string Username { get => username; set => username = value; }
        public string Account_status { get => account_status; set => account_status = value; }
        public DateTime Date_opened { get => date_opened; set => date_opened = value; }
        public decimal Balance { get => balance; set => balance = value; }
        public DataTable DataTableAccountInfor { get => dataTableAccountInfor; set => dataTableAccountInfor = value; }
        public DataTable DataTableCustomerInfor { get => dataTableCustomerInfor; set => dataTableCustomerInfor = value; }
        public DataTable DataTableAllTransfer { get => dataTableAllTransfer; set => dataTableAllTransfer = value; }
        public DataTable DatatableAllDeposit { get => datatableAllDeposit; set => datatableAllDeposit = value; }
        public DataTable DatatableAllWithdraw { get => datatableAllWithdraw; set => datatableAllWithdraw = value; }





        //Lấy ra danh sách thông tin khách hàng và tải khoản tương ứng bằng account number-----------------------------------------------------------------------------------
        public void searchCustomerAccountByAccountNumber(int account_number)
        {
            this.dataTableAccountInfor = customerAccountWithInforRepository.SearchCustomerAccountByAccountNumber(account_number);
        }





        //Lấy ra danh sách thông tin khách hàng và tải khoản tương ứng bằng account number-----------------------------------------------------------------------------------
        public void searchCustomerAccountByCCCD(string cccd)
        {
            this.dataTableAccountInfor = customerAccountWithInforRepository.SearchCustomerAccountByCccd(cccd);
        }





        //Lấy ra thông tin khách hàng bằng cccd--------------------------------------------------------------------------------------------------
        public void searchCustomerInforByCccd(string cccd)
        {
            this.dataTableCustomerInfor = customerInforRepository.searchCustomerByCccd(cccd);
        }





        //Lấy ra toàn bộ thông tin khách hàng và tài khoản tương ứng-------------------------------------------------------------------------------------------
        public void LoadAllCustomerAccount()
        {
            dataTableAccountInfor = customerAccountWithInforRepository.LoadAllAccount();
        }





        //Thêm một tài khoản-----------------------------------------------------------------------------------------------------------------------------------
        public void AddCustomerAccount()
        {
            //Kiểm tra xem UserName đã tồn tại chưa
            if(customerAccountWithInforRepository.getCustomerAccountByUserName(this.username) != null)
            {
                CustomMessageBox.ShowBox(LangHelper.Instance.GetString("This username already exists!"), "Error");
                return;
            }

            //Sinh password ngẫu nhiên
            string randomPassword = GenerateRandomPassword(PASSWORD_LENGH);
            //Lấy ra số tài khoản lớn nhất hiện có (cuối cùng được tạo) rồi + 1 để tạo stk mới
            this.Account_number = customerAccountWithInforRepository.getMaxAccountNumber() + 1;
            CustomerAccount customerAccount = new CustomerAccount(0, this.username, randomPassword, this.balance, this.date_opened, Convert.ToInt32(this.dataTableCustomerInfor.Rows[0]["id"]), "Active", this.Account_number);
            customerAccountWithInforRepository.AddCustomerAccount(customerAccount);
        }
        //Sinh password ngẫu nhiên
        static string GenerateRandomPassword(int length)
        {
            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*";
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





        //Xóa tài khoản---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public void deleteCustomerAccount()
        {
            customerAccountWithInforRepository.deleteCustomerAccount(this.Account_number);
        }





        //Active account------------------------------------------------------------------------------------------------------------------------------------------------
        public void updateStatusAccountCustomer()
        {
            customerAccountWithInforRepository.updateStatusAccountCustomer(this.Account_number);
        }




        //Add Log-------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public void AddLog(string act)
        {
            Log log = new Log(0, this.staffId, null, act + this.account_number);
            logRepository.AddLog(log);
        }

        // lấy all giao dịch giữa 2 tài khoản bằng id tài khoản 
        public void getAllTransferByIdAccount(int accountId)
        {
            try
            {
                this.dataTableAllTransfer = TransactionReponsitory.getAllTransferByIdAccount(accountId);
            }catch (Exception ex) 
            {
                 // Ném lại ngoại lệ để form cha có thể xử lý
                throw new Exception("Error: " + ex.Message, ex);
            }
        }

        //lấy all giao dịch chuyển tiền bởi tài khoản bằng id tài khoản
        public void getAllDepositByIdAccount(int accountId)
        {
            try
            {
                this.datatableAllDeposit = TransactionReponsitory.getAllDepositByIdAccount(accountId);
            }
            catch (Exception ex)
            {
                // Ném lại ngoại lệ để form cha có thể xử lý
                throw new Exception("Error: " + ex.Message, ex);
            }
        }

        //lấy all giao dịch chuyển tiền bởi tài khoản bằng id tài khoản
        public void getAllWithDrawByIdAccount(int accountId)
        {
            try
            {
                this.datatableAllWithdraw = TransactionReponsitory.getAllWithDrawByIdAccount(accountId);
            }
            catch (Exception ex)
            {
                // Ném lại ngoại lệ để form cha có thể xử lý
                throw new Exception("Error: " + ex.Message, ex);
            }
        }
    }
}
