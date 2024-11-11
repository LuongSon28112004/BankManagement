using BankManagement.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankManagement.ViewModel
{
    internal class LoanViewModel
    {
        private CustomerAccountWithInforRepository customerAccountWithInforRepository;
        private LoanRepository loanRepository;
        private LogRepository logRepository;

        //cac thuoc tinh bind voi LoanForm
        private int id;
        private decimal principalAmount;
        private DateTime loanDate;
        private float interestRate;
        private string note;
        private int customerAccountId;
        private int staffAccountId;
        private DateTime lastPaymentDate;
        private DateTime nextInterestDueDate;
        private bool paid_status;
        private int loanTerm;
        private decimal interestDueAmount;
        private decimal penaltyFee;
        private decimal total;
        DataTable dataTableAccount;
        DataTable dataTableLoan;

        public LoanViewModel()
        {
            customerAccountWithInforRepository = new CustomerAccountWithInforRepository();
            loanRepository = new LoanRepository();
            logRepository = new LogRepository();
        }

        public decimal Principal_amount { get => principalAmount; set => principalAmount = value; }
        public decimal InterestDueAmount { get => interestDueAmount; set => interestDueAmount = value; }
        public decimal PenaltyFee { get => penaltyFee; set => penaltyFee = value; }
        public decimal Total { get => total; set => total = value; }
        public DateTime Loan_date { get => loanDate; set => loanDate = value; }
        public float Interest_Rate { get => interestRate; set => interestRate = value; }
        public string Note { get => note; set => note = value; }
        public int CustomerAccountId { get => customerAccountId; set => customerAccountId = value; }
        public int StaffAccountId { get => staffAccountId; set => staffAccountId = value; }
        public DateTime LastPaymentDate { get => lastPaymentDate; set => lastPaymentDate = value; }
        public DateTime NextInterestDueDate { get => nextInterestDueDate; set => nextInterestDueDate = value; }
        public bool Paid_status { get => paid_status; set => paid_status = value; }
        public int LoanTerm { get => loanTerm; set => loanTerm = value; }
        public DataTable DataTableAccount { get => dataTableAccount; set => dataTableAccount = value; }
        public DataTable DataTableLoan { get => dataTableLoan; set => dataTableLoan = value; }
        public int Id { get => id; set => id = value; }


        //Tìm kiếm thông tin khách hàng
        public void searchAccountInfor(int account_number)
        {
            try
            {
                dataTableAccount = customerAccountWithInforRepository.SearchCustomerAccountByAccountNumber(account_number);
            }
            catch(Exception ex)
            {
                // Ném lại ngoại lệ để form cha có thể xử lý
                throw new Exception("Error: " + ex.Message, ex);
            }
        }





        //Tạo 1 khoản vay mới----------------------------------------------------------------------------------------------------------------------------------------------------------------
        public void addLoan()
        {
            try
            {
               Loan loan = new Loan(0,this.principalAmount,this.Loan_date,this.interestRate,this.note,this.customerAccountId,this.staffAccountId,this.lastPaymentDate,this.paid_status,this.loanTerm);
                loanRepository.addLoan(loan);
            }
            catch (Exception ex)
            {
                // Ném lại ngoại lệ để form cha có thể xử lý
                throw new Exception("Error: " + ex.Message, ex);
            }
        }





        //Kiểm tra xem tài khoản này có đang phải trả khoản vay nào không---------------------------------------------------------------------------------------------------------
        public bool InPaymentPeriod()
        {
            return loanRepository.InPaymentPeriod(this.customerAccountId);
        }





        //Lấy ra một khoản vay theo account number và tính toán lãi suất...-----------------------------------------------------------------------------------------------------------------
        public void getLoanByIdAccount()
        {
            dataTableLoan = loanRepository.getLoanByIdAccount(this.customerAccountId);
            if (dataTableLoan.Rows.Count != 0)
            {
                LoadLoanInfor(dataTableLoan);
            }
        }
        public void LoadLoanInfor(DataTable dataTableLoan)
        {
            DataRow row = dataTableLoan.Rows[0];
            this.principalAmount = Decimal.Parse(row["principal_amount"].ToString());
            this.loanDate = DateTime.Parse(row["loan_date"].ToString());
            this.loanTerm = Convert.ToInt32(row["loan_Term"]);
            this.note = row["note"].ToString();
            this.lastPaymentDate = DateTime.Parse(row["last_payment_date"].ToString());
            this.paid_status = Convert.ToBoolean(row["paid_status"]);
            this.Id = Convert.ToInt32(row["id"]);
            this.interestRate = Convert.ToSingle(row["interest_rate"]);

            //Tính hạn kỳ thanh toán tiếp theo
            CalNextInterestDueDate();
            //Tính số tháng trả lãi chậm
            int monthsLate = CalMonthsLate();
            //Tính số tiền phải thanh toán
            CalTotalPayment(monthsLate);

        }
        public void CalNextInterestDueDate()
        { 
            DateTime loanDate = this.loanDate;
            DateTime today = DateTime.Today;

            // Lấy ngày, tháng và năm hiện tại
            int currentDay = today.Day;
            int currentMonth = today.Month;
            int currentYear = today.Year;

            // Kết hợp ngày của loanDate với tháng và năm hiện tại
            DateTime nextPaymentDate = new DateTime(currentYear, currentMonth, loanDate.Day);

            //Trường hợp đã qua ngày thanh toán trong tháng
            if (today > nextPaymentDate)
            {
                nextPaymentDate = nextPaymentDate.AddMonths(1);
            }

            //Trường hợp chưa đến hạn thanh toán nhưng đã thanh toán xong
            DateTime aMonthAgo = nextPaymentDate.AddMonths(-1);
            if (this.lastPaymentDate > aMonthAgo && this.lastPaymentDate <= nextPaymentDate)
            {
                //Khi đã thanh toán thì rời sang tháng sau
                nextPaymentDate = nextPaymentDate.AddMonths(1);
            }
            this.nextInterestDueDate = nextPaymentDate;
        }
        public int CalMonthsLate()
        { 
            int monthsLate = 0;
            DateTime finalPayment = new DateTime(this.lastPaymentDate.Year, this.lastPaymentDate.Month, this.loanDate.Day);
            if (this.lastPaymentDate > finalPayment)
            {
                finalPayment = finalPayment.AddMonths(1);
            }
            monthsLate = this.nextInterestDueDate.Month - finalPayment.Month - 1;
            if (finalPayment.Month > this.NextInterestDueDate.Month) monthsLate = this.nextInterestDueDate.Month - finalPayment.Month + 12 - 1;
            return monthsLate;
        }
        public void CalTotalPayment(int monthsLate)
        { 
            decimal totalPayment = 0;
            decimal interestDueAmount = 0;
            decimal penaltyFee = 0;
            interestDueAmount = principalAmount * Decimal.Parse(this.interestRate.ToString()) / 1200 * (monthsLate + 1);
            penaltyFee = principalAmount * 2 / 100 * monthsLate;
            totalPayment = interestDueAmount + penaltyFee;
            if (IsLastPeriod())
            {
                totalPayment += principalAmount;
            }
            this.interestDueAmount = interestDueAmount;
            this.penaltyFee = penaltyFee;
            this.total = totalPayment;
        }
        public bool IsLastPeriod()
        { 
            DateTime loanDate = this.loanDate;
            DateTime finalPeriod = loanDate.AddMonths(this.loanTerm);
            if (this.nextInterestDueDate >= finalPeriod)
            {
                return true;
            }
            return false;
        }





        //Thanh toán khoản vay----------------------------------------------------------------------------------------------------------------------------------------------
        public void payment()
        {
            bool paid_status = false;
            if (IsLastPeriod())
            {
                paid_status = true;
            }
            loanRepository.payment(this.id, paid_status);
        }





        //Add Log-------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public void AddLog(string act, int staffId)
        {
            Log log = new Log(0, staffId, null, act);
            logRepository.AddLog(log);
        }
    }
}
