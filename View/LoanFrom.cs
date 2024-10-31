using BankManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankManagement.View
{
    public partial class LoanFrom : Form
    {
        private int staffId;
        private LoanViewModel viewModel;
        public LoanFrom(int staffId)
        {
            InitializeComponent();
            this.staffId = staffId;
            viewModel = new LoanViewModel();    
            this.ShowInTaskbar = false;
            
        }


        private void LoanFrom_Load(object sender, EventArgs e)
        {
            btnCreateTaskBarLoanForm_Click(this, EventArgs.Empty);
            btnCreateTaskBarLoanForm.HoverState.FillColor = Color.FromArgb(50, 50, 50);
            btnPaymentTaskBarLoanForm.HoverState.FillColor = Color.FromArgb(50, 50, 50);
        }





        //Reset cac component-----------------------------------------------------------------------------------------------------------------------------------------------
        private void reset()
        {
            imgCustomerLoanForm.Image = System.Drawing.Image.FromFile($"..\\..\\Resources\\avatar_customer_default.png");
            txtSearchByAccountNumberLoanForm.Text = "";
            lbCustomerNameLoanForm.Text = "Customer Name";
            lbAccountNumberLoanForm.Text = "101xxxxxxx";
            this.SetAccountSendStatus("Status");
            txtCCCDLoanForm.Text = "";
            txtPhoneNumberLoanForm.Text = "";
            txtEmailLoanForm.Text = "";
            txtAmountLoanForm.Text = "";
            txtLoanDateLoanForm.Text = "";
            txtLoanTermLoanForm.Text = "";
            txtLoanPurposeLoanForm.Text = "";
            txtNextInterestDueDateLoanForm.Text = "";
            txtLastPaymentDateLoanForm.Text = "";
            txtInterestDueAmountLoanForm.Text = "";
            txtPenaltyFeeLoanForm.Text = "";
            txtTotalLoanForm.Text = "";
            txtSearchByAccountNumberLoanForm.Text = "";
        }
        //set status của tài khoản gửi 
        private void SetAccountSendStatus(string status)
        {
            if (status == "Inactive")
            {
                imgAccountStatusLoanForm.Image = System.Drawing.Image.FromFile("..\\..\\Resources\\x-button.png");
                lbAccountStatusLoanForm.Text = status;
                lbAccountStatusLoanForm.ForeColor = Color.FromArgb(203, 57, 53);
            }
            else
            {
                imgAccountStatusLoanForm.Image = System.Drawing.Image.FromFile("..\\..\\Resources\\checked.png");
                lbAccountStatusLoanForm.Text = status;
                lbAccountStatusLoanForm.ForeColor = Color.FromArgb(90, 190, 40);
            }
        }





        //Btn Create Taskbar---------------------------------------------------------------------------------------------------------------------------------------------------------
        private void btnCreateTaskBarLoanForm_Click(object sender, EventArgs e)
        {
            //reset lai cac label va textbox
            this.reset();
            DateTime time = DateTime.Today;
            txtLoanDateLoanForm.Text = time.ToString("dd/MM/yyyy");

            btnPaymentTaskBarLoanForm.ForeColor = Color.FromArgb(170, 170, 170);
            btnCreateTaskBarLoanForm.ForeColor = Color.FromArgb(255, 255, 255);
            btnPaymentTaskBarLoanForm.CustomBorderThickness = new Padding(0, 0, 0, 0);
            btnCreateTaskBarLoanForm.CustomBorderThickness = new Padding(0, 0, 0, 1);
            btnCreateTaskBarLoanForm.CustomBorderColor = Color.Aquamarine;

            btnResetLoanForm.Visible = true;
            btnCreateLoanForm.Visible = true;
            panelPaymentLoanForm.Visible = false;

            txtAmountLoanForm.ReadOnly = false;
            txtLoanTermLoanForm.ReadOnly = false;
            txtLoanPurposeLoanForm.ReadOnly = false;
        }





        //Btn Payment Taskbar------------------------------------------------------------------------------------------------------------------------------------------------------
        private void btnPaymentTaskBarLoanForm_Click(object sender, EventArgs e)
        {
            //reset lai cac label va textbox
            this.reset();

            btnPaymentTaskBarLoanForm.ForeColor = Color.FromArgb(255, 255, 255);
            btnCreateTaskBarLoanForm.ForeColor = Color.FromArgb(170, 170, 170);
            btnPaymentTaskBarLoanForm.CustomBorderThickness = new Padding(0, 0, 0, 1);
            btnCreateTaskBarLoanForm.CustomBorderThickness = new Padding(0, 0, 0, 0);
            btnCreateTaskBarLoanForm.CustomBorderColor = Color.Aquamarine;

            btnResetLoanForm.Visible = false;
            btnCreateLoanForm.Visible = false;
            panelPaymentLoanForm.Visible = true;

            txtAmountLoanForm.ReadOnly = true;
            txtLoanTermLoanForm.ReadOnly = true;
            txtLoanPurposeLoanForm.ReadOnly = true;
        }





        //Btn reset-------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void btnResetLoanForm_Click(object sender, EventArgs e)
        {
            this.reset();
            DateTime time = DateTime.Today;
            txtLoanDateLoanForm.Text = time.ToString("dd/MM/yyyy");
        }

        private void btnSearchByAccountNumberLoanForm_Click(object sender, EventArgs e)
        {
            if (txtSearchByAccountNumberLoanForm.Text == "") return;
            viewModel.searchAccountInfor(int.Parse(txtSearchByAccountNumberLoanForm.Text));
            if (viewModel.DataTableAccount.Rows.Count != 1) return;
            this.updateCustomerInfor(viewModel.DataTableAccount);
            if(panelPaymentLoanForm.Visible == true)
            {
                viewModel.getLoanByIdAccount();
                if(viewModel.DataTableLoan.Rows.Count != 1) return;
                this.updateLoanInfor(viewModel.DataTableLoan);

            }

        }

        private void updateLoanInfor(DataTable dt)
        {
            // Lấy hàng đầu tiên từ DataTable
            DataRow row = dt.Rows[0];

            // Cập nhật các TextBox với giá trị từ hàng
            txtAmountLoanForm.Text = row["principal_amount"].ToString();
            txtInterestRateLoanForm.Text = row["interest_rate"].ToString();

            // Định dạng ngày cho loan_date
            DateTime loan_date = DateTime.Parse(row["loan_date"].ToString());
            txtLoanDateLoanForm.Text = loan_date.ToString("dd/MM/yyyy");

            // Cập nhật các thông tin khác
            txtLoanTermLoanForm.Text = row["loan_Term"].ToString();
            txtLoanPurposeLoanForm.Text = row["note"].ToString();

            // Định dạng ngày cho last_payment_date
            DateTime last_payment_date = DateTime.Parse(row["last_payment_date"].ToString());
            txtLastPaymentDateLoanForm.Text = last_payment_date.ToString("dd/MM/yyyy");

            // Xác định ngày đến hạn tiếp theo cho khoản vay
            int daysInCurrentMonth = DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month);
            int loanDay = loan_date.Day;

            // Kiểm tra nếu ngày trong loan_date lớn hơn số ngày trong tháng hiện tại
            int dueDay = loanDay > daysInCurrentMonth ? daysInCurrentMonth : loanDay;

            // Xác định tháng và năm cho ngày đến hạn tiếp theo
            int dueMonth = DateTime.Today.Month;
            int dueYear = DateTime.Today.Year;

            // Nếu ngày đến hạn nhỏ hơn ngày hôm nay, chuyển sang tháng sau
            if (dueDay < DateTime.Today.Day)
            {
                dueMonth += 1;
                if (dueMonth > 12)
                {
                    dueMonth = 1;
                    dueYear += 1;
                }
            }

            // Tạo DateTime cho ngày đến hạn tiếp theo
            DateTime nextInterestDueDate = new DateTime(dueYear, dueMonth, dueDay);
            txtNextInterestDueDateLoanForm.Text = nextInterestDueDate.ToString("dd/MM/yyyy");

            // Tính tổng số tiền phải trả (bao gồm tiền lãi và phạt)
            float total = CalculateTotalInterest(nextInterestDueDate, last_payment_date,
                float.Parse(row["interest_rate"].ToString()) / 12 / 100, 0.05f, float.Parse(row["principal_amount"].ToString()));

            txtTotalLoanForm.Text = total.ToString();

            // Kiểm tra có phạt hay không, nếu có thì cập nhật phí phạt
            float monthlyInterest = float.Parse(row["principal_amount"].ToString()) * (float.Parse(row["interest_rate"].ToString()) / 12 / 100);
            txtPenaltyFeeLoanForm.Text = total > monthlyInterest ? "5%" : "0%";
        }

        private float CalculateTotalInterest(DateTime startDate, DateTime lastPaymentDate, float interestRate, float penaltyRate, float principalAmount)
        {
            // Tính số tháng giữa ngày hôm nay và ngày thanh toán cuối cùng
            int monthsDifference = ((DateTime.Today.Year - lastPaymentDate.Year) * 12) + DateTime.Today.Month - lastPaymentDate.Month;
            float totalInterest = 0;

            // Kiểm tra nếu ngày hiện tại lớn hơn hoặc bằng ngày bắt đầu khoản vay
            if (IsCurrentDayGreaterOrEqual(startDate.Day))
            {
                // Tính tiền lãi với phạt
                totalInterest = principalAmount * interestRate
                              + (principalAmount * interestRate * (1 + penaltyRate)) * monthsDifference;
            }
            else
            {
                // Nếu không, tính tiền lãi cho tháng trước
                totalInterest = principalAmount * interestRate
                              + (principalAmount * interestRate * (1 + penaltyRate)) * (monthsDifference - 1);
            }

            return totalInterest;
        }

        // Kiểm tra nếu ngày hiện tại lớn hơn hoặc bằng ngày cho trước
        public bool IsCurrentDayGreaterOrEqual(int loanDay)
        {
            return DateTime.Today.Day >= loanDay;
        }



        //Hiển thị thông tin của Customer trên Form
        private void updateCustomerInfor(DataTable dt)
        {
            DataRow row = dt.Rows[0]; // Lấy hàng đầu tiên (index 0)

            lbCustomerNameLoanForm.Text = row["name"].ToString();

            imgCustomerLoanForm.Image = Image.FromFile($"..\\..\\Image\\CustomerImage\\{row["photo"].ToString()}");
            txtCCCDLoanForm.Text = row["cccd"].ToString();
            lbAccountNumberLoanForm.Text = row["account_number"].ToString();
            txtPhoneNumberLoanForm.Text = row["phone_number"].ToString();
            txtEmailLoanForm.Text = row["email"].ToString();

            //upate id account vao viewmodel phuc vu cho viec insert
            viewModel.CustomerAccountId = int.Parse(row["id"].ToString());
            

            this.checkStatusCustomerInfor(row["status"].ToString());
        }

        private void checkStatusCustomerInfor(string status)
        {
            if (status == "Active")
            {
                imgAccountStatusLoanForm.Image = Image.FromFile("..\\..\\Resources\\checked.png");
                lbAccountStatusLoanForm.Text = status;
                lbAccountStatusLoanForm.ForeColor = Color.FromArgb(78, 167, 46);
            }
            else
            {
                imgAccountStatusLoanForm.Image = Image.FromFile("..\\..\\Resources\\x-button.png");
                lbAccountStatusLoanForm.Text = status;
                lbAccountStatusLoanForm.ForeColor = Color.FromArgb(203, 57, 53);
            }
        }

        private void btnCreateLoanForm_Click(object sender, EventArgs e)
        {
            if(viewModel.checkAccountId())
            {
                MessageBox.Show("Khách Hàng này đang vay tiền, không thể vay thêm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(lbAccountStatusLoanForm.Text == "Inactive")
            {
                MessageBox.Show("tài khoản này không còn tồn tại trong hệ thống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(txtAmountLoanForm.Text == "")
            {
                MessageBox.Show("Vui Lòng Nhập Số Tiền Cần Vay", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(txtLoanTermLoanForm.Text == "")
            {
                MessageBox.Show("Vui Lòng Nhập Số Tháng Cần Vay", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(txtLoanPurposeLoanForm.Text == "")
            {
                MessageBox.Show("Vui Lòng Nhập Lý Do Cần Vay", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            this.updateViewModelFromForm();
            viewModel.addLoan();

        }

        private void updateViewModelFromForm()
        {
            viewModel.Principal_amount = decimal.Parse(txtAmountLoanForm.Text);
            viewModel.Loan_date = DateTime.Now;
            string interestRateText = txtInterestRateLoanForm.Text;
            if (!string.IsNullOrEmpty(interestRateText))
            {
                // Loại bỏ ký tự cuối cùng
                interestRateText = interestRateText.Substring(0, interestRateText.Length - 1);
                viewModel.Interest_Rate = float.Parse(interestRateText);
            }
            viewModel.Note = txtLoanPurposeLoanForm.Text;
            viewModel.StaffAccountId = this.staffId;
            viewModel.LastPaymentDate = DateTime.Now;
            viewModel.Paid_status = false;
            viewModel.LoanTerm = int.Parse(txtLoanTermLoanForm.Text);
        }
    }
}
