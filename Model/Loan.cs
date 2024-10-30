using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement.Model
{
    internal class Loan
    {
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

        public Loan(int id, decimal principal_amount, DateTime loan_date, float interest_Rate, string note, int customerAccount, int staffAccount, DateTime lastPaymentDate, bool paid_status, int loanTerm)
        {
            this.id = id;
            this.principal_amount = principal_amount;
            this.loan_date = loan_date;
            this.interest_Rate = interest_Rate;
            this.note = note;
            this.customerAccountId = customerAccount;
            this.staffAccountId = staffAccount;
            this.lastPaymentDate = lastPaymentDate;
            this.paid_status = paid_status;
            this.loanTerm = loanTerm;
        }

        public int Id { get => id; set => id = value; }
        public decimal Principal_amount { get => principal_amount; set => principal_amount = value; }
        public DateTime Loan_date { get => loan_date; set => loan_date = value; }
        public float Interest_Rate { get => interest_Rate; set => interest_Rate = value; }
        public string Note { get => note; set => note = value; }
        public int CustomerAccountId { get => customerAccountId; set => customerAccountId = value; }
        public int StaffAccountId { get => staffAccountId; set => staffAccountId = value; }
        public DateTime LastPaymentDate { get => lastPaymentDate; set => lastPaymentDate = value; }
        public bool Paid_status { get => paid_status; set => paid_status = value; }
        public int LoanTerm { get => loanTerm; set => loanTerm = value; }
    }
}
