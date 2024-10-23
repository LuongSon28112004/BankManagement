using BankManagement.Model;
using BankManagement.View;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankManagement.ViewModel
{
	internal class TransactionViewModel
	{
		private CustomerAccountWithInforRepository customerAccountWithInforRepository;
		private TransactionReponsitory transactionReponsitory;
		private LogRepository logRepository;


		//các thuộc tính bind với transaction form
		private Decimal amount;
		private string note;
		private int account_customer_send;
		private int account_customer_receive;
		private int staff_id;
		private DataTable datatableAccountSend;
		private DataTable datatableAccountReceive;
		private int account_customer_send_id;
		private int account_customer_receive_id;
		private int id;


		//constructor
		public TransactionViewModel()
		{
			customerAccountWithInforRepository = new CustomerAccountWithInforRepository();
			transactionReponsitory = new TransactionReponsitory();
			logRepository = new LogRepository();
		}


		//getter and setter 
		public decimal Amount { get => amount; set => amount = value; }
		public string Note { get => note; set => note = value; }
		public int Account_customer_send { get => account_customer_send; set => account_customer_send = value; }
		public int Account_customer_receive { get => account_customer_receive; set => account_customer_receive = value; }
		public int Staff_account_transfer_id { get => staff_id; set => staff_id = value; }
		public DataTable DatatableAccountSend { get => datatableAccountSend; set => datatableAccountSend = value; }
		public DataTable DatatableAccountReceive { get => datatableAccountReceive; set => datatableAccountReceive = value; }
		public int Account_customer_send_id { get => account_customer_send_id; set => account_customer_send_id = value; }
		public int Account_customer_receive_id { get => account_customer_receive_id; set => account_customer_receive_id = value; }
		public int Id { get => id; set => id = value; }





		//thêm một transaction transfer vào trong cơ sở dữ liệu-------------------------------------------------------------------------------------------------------------------------------------
		public void addTransactionTransfer(DateTime time)
		{
			Transaction transaction = new Transaction(0, this.amount, time, this.note, this.account_customer_send_id, this.account_customer_receive_id, this.staff_id);
			try
			{
                transactionReponsitory.addTransactionTransfer(transaction);
                bool updateBalanceAccountSend = customerAccountWithInforRepository.updateAccountBalance(this.amount * -1, this.Account_customer_send);
                bool updateBalanceAccountReceive = customerAccountWithInforRepository.updateAccountBalance(this.amount, this.Account_customer_receive);
                this.Id = transaction.Id;
            }
            catch (Exception ex)
            {
                // Ném lại ngoại lệ để form cha có thể xử lý
                throw new Exception("Lỗi: " + ex.Message, ex);
            }

        }





		//thêm một transaction deposit vào trong cơ sở dữ liệu-------------------------------------------------------------------------------------------------------------------------------
		public void addTransactionDeposit(DateTime time)
		{
			//mặc định giao dịch là ngày hôm nay 
			Transaction transaction = new Transaction(0, this.amount, time, this.note, this.account_customer_send_id, 0, this.staff_id);
			try
			{
                transactionReponsitory.addTransactionDeposit(transaction);
                bool updateBalanceAccountSend = customerAccountWithInforRepository.updateAccountBalance(this.amount, this.Account_customer_send);
                this.id = transaction.Id;
            }
            catch (Exception ex)
            {
                // Ném lại ngoại lệ để form cha có thể xử lý
                throw new Exception("Lỗi: " + ex.Message, ex);
            }
        }





		//thêm một transaction withdraw vào trong cơ sở dữ liệu-------------------------------------------------------------------------------------------------------------------------------------
		public void addTransactionWithdraw(DateTime time)
		{ 
			Transaction transaction = new Transaction(0, this.amount, time, this.note, this.account_customer_send_id, 0, this.staff_id);
			try
			{
                transactionReponsitory.addTransactionWithdraw(transaction);
                bool updateBalanceAccountReceive = customerAccountWithInforRepository.updateAccountBalance(this.amount * -1, this.Account_customer_send);
                this.Id = transaction.Id;
            }
            catch (Exception ex)
            {
                // Ném lại ngoại lệ để form cha có thể xử lý
                throw new Exception("Lỗi: " + ex.Message, ex);
            }
        }






		//tim kiếm tài khoản gửi tiền
		public void searchAccountSend(int accountNumber)
		{
			datatableAccountSend = customerAccountWithInforRepository.SearchCustomerAccountByAccountNumber(accountNumber);
		}





		//tìm kiếm tài khoản nhận tiền
		public void searchAccountReceive(int accountNumber)
		{
			datatableAccountReceive = customerAccountWithInforRepository.SearchCustomerAccountByAccountNumber(accountNumber);
		}





		//Add log
		public void AddLog(string act)
		{
			Log log = new Log(0, this.staff_id, null, this.account_customer_send + act + this.amount.ToString("#,0", new CultureInfo("vi-VN")) + " VNĐ");
			logRepository.AddLog(log);
		}
		public void AddLogTransfer(string act)
		{
            Log log = new Log(0, this.staff_id, null, this.account_customer_send + act + this.account_customer_receive + " " + this.amount.ToString("#,0", new CultureInfo("vi-VN")) + " VNĐ");
			logRepository.AddLog(log);
        }

	}
}
