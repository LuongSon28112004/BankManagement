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
    internal class LoanViewModel
    {
        private CustomerAccountWithInforRepository customerAccountWithInforRepository;
        private LoanRepository loanRepository;

        //cac thuoc tinh bind voi LoanForm
        private int id;
        private decimal principal_amount;
        private DateTime loan_date;
        private float interest_Rate;
        private string note;
        private int customerAccountId;
        private int staffAccountId;
        private DateTime lastPaymentDate;
        private bool paid_status;
        private int loanTerm;
        DataTable dataTableAccount;
        DataTable dataTableLoan;

        public LoanViewModel()
        {
            customerAccountWithInforRepository = new CustomerAccountWithInforRepository();
            loanRepository = new LoanRepository();
        }

        public decimal Principal_amount { get => principal_amount; set => principal_amount = value; }
        public DateTime Loan_date { get => loan_date; set => loan_date = value; }
        public float Interest_Rate { get => interest_Rate; set => interest_Rate = value; }
        public string Note { get => note; set => note = value; }
        public int CustomerAccountId { get => customerAccountId; set => customerAccountId = value; }
        public int StaffAccountId { get => staffAccountId; set => staffAccountId = value; }
        public DateTime LastPaymentDate { get => lastPaymentDate; set => lastPaymentDate = value; }
        public bool Paid_status { get => paid_status; set => paid_status = value; }
        public int LoanTerm { get => loanTerm; set => loanTerm = value; }
        public DataTable DataTableAccount { get => dataTableAccount; set => dataTableAccount = value; }
        public DataTable DataTableLoan { get => dataTableLoan; set => dataTableLoan = value; }
        public int Id { get => id; set => id = value; }

        public void searchAccountInfor(int account_number)
        {
            try
            {
                dataTableAccount = customerAccountWithInforRepository.SearchCustomerAccountByAccountNumber(account_number);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void addLoan()
        {
            try
            {
               Loan loan = new Loan(0,this.principal_amount,this.Loan_date,this.interest_Rate,this.note,this.customerAccountId,this.staffAccountId,this.lastPaymentDate,this.paid_status,this.loanTerm);
                loanRepository.addLoan(loan);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //Kiểm tra xem tài khoản này có đang phải trả khoản vay nào không
        public bool InPaymentPeriod()
        {
            try
            {
                return loanRepository.InPaymentPeriod(this.customerAccountId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public void getLoanByIdAccount()
        {
            try
            {
                dataTableLoan = loanRepository.getLoanByIdAccount(this.customerAccountId);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void updateLoan()
        {
            try
            {
                loanRepository.updateLoan(this.LastPaymentDate, this.paid_status, this.id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
