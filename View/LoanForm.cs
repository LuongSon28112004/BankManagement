using BankManagement.Language;
using BankManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
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
            DateTime time = DateTime.Today;
        }


        private void LoanFrom_Load(object sender, EventArgs e)
        {
            btnCreateTaskBarLoanForm_Click(this, EventArgs.Empty);
            btnCreateTaskBarLoanForm.HoverState.FillColor = Color.FromArgb(50, 50, 50);
            btnPaymentTaskBarLoanForm.HoverState.FillColor = Color.FromArgb(50, 50, 50);

            ChangeLanguage();
        }
        void ChangeLanguage()
        {
            lbLoanLoanForm.Text = LangHelper.Instance.GetString("Loan");
            btnCreateTaskBarLoanForm.Text = LangHelper.Instance.GetString("Create");
            btnPaymentTaskBarLoanForm.Text = LangHelper.Instance.GetString("Payment");
            txtSearchByAccountNumberLoanForm.PlaceholderText = LangHelper.Instance.GetString("Account Number");
            btnSearchByAccountNumberLoanForm.Text = LangHelper.Instance.GetString("Search");
            lbCustomerNameLoanForm.Text = LangHelper.Instance.GetString("Customer Name");
            lbPhoneNumberLoanForm.Text = LangHelper.Instance.GetString("Phone number");
            lbAmountLoanForm.Text = LangHelper.Instance.GetString("Amount");
            lbInterestRateLoanForm.Text = LangHelper.Instance.GetString("Interest rate");
            lbLoanDateLoanForm.Text = LangHelper.Instance.GetString("Loan date");
            lbLoanTermLoanForm.Text = LangHelper.Instance.GetString("Loan term");
            txtLoanTermLoanForm.PlaceholderText = LangHelper.Instance.GetString("Month");
            lbLoanPurposeLoanForm.Text = LangHelper.Instance.GetString("Loan purpose");
            txtLoanPurposeLoanForm.PlaceholderText = LangHelper.Instance.GetString("Borrow money to...");
            btnCreateLoanForm.Text = LangHelper.Instance.GetString("Create");
            lbNextInterestDueDateLoanForm.Text = LangHelper.Instance.GetString("Next interest due date");
            lbLastPaymentDateLoanForm.Text = LangHelper.Instance.GetString("Last payment date");
            lbInterestDueAmountLoanForm.Text = LangHelper.Instance.GetString("Interest due amount");
            lbPenaltyFeeLoanForm.Text = LangHelper.Instance.GetString("Penalty fee");
            lbTotalLoanForm.Text = LangHelper.Instance.GetString("Total");
            btnPaymentLoanForm.Text = LangHelper.Instance.GetString("Payment");
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

            btnResetLoanForm.Visible = true;
            btnCreateLoanForm.Visible = false;
            panelPaymentLoanForm.Visible = true;

            txtAmountLoanForm.ReadOnly = true;
            txtLoanTermLoanForm.ReadOnly = true;
            txtLoanPurposeLoanForm.ReadOnly = true;
        }





        //Reset cac view-----------------------------------------------------------------------------------------------------------------------------------------------
        private void reset()
        {
            imgCustomerLoanForm.Image = System.Drawing.Image.FromFile($"..\\..\\Resources\\avatar_customer_default.png");
            lbCustomerNameLoanForm.Text = LangHelper.Instance.GetString("Customer Name");
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
            btnPaymentLoanForm.Enabled = false;
            lbLoanStatusLoanForm.Visible = false;
            imgLoanStatusLoanForm.Visible= false;
        }
        //Btn reset-------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void btnResetLoanForm_Click(object sender, EventArgs e)
        {
            this.reset();
            if (panelPaymentLoanForm.Visible == false)
            {
                DateTime time = DateTime.Today;
                txtLoanDateLoanForm.Text = time.ToString("dd/MM/yyyy");
            }
        }





        //Tìm kiếm một khoản vay
        private void btnSearchByAccountNumberLoanForm_Click(object sender, EventArgs e)
        {
            try
            {
                btnResetLoanForm_Click(null, EventArgs.Empty);
                if (txtSearchByAccountNumberLoanForm.Text == "") return;
                viewModel.CustomerAccountId = int.Parse(txtSearchByAccountNumberLoanForm.Text);
                viewModel.searchAccountInfor(int.Parse(txtSearchByAccountNumberLoanForm.Text));
                if (viewModel.DataTableAccount.Rows.Count != 1) return;
                this.updateCustomerInfor(viewModel.DataTableAccount);

                if (panelPaymentLoanForm.Visible == true)
                {
                    viewModel.getLoanByIdAccount();
                    if (viewModel.DataTableLoan.Rows.Count != 1)
                    {
                        return;
                    }
                    this.updateLoanInfor();
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu cần
                CustomMessageBox.ShowBox("Error: " + ex.Message, "Error");
            }
        }

        private void updateLoanInfor()
        {
            txtAmountLoanForm.Text = viewModel.Principal_amount.ToString("#,##0", new CultureInfo("vi-VN"));
            txtLoanDateLoanForm.Text = viewModel.Loan_date.Date.ToString("dd/MM/yyyy");
            txtLoanTermLoanForm.Text= viewModel.LoanTerm.ToString();
            txtLoanPurposeLoanForm.Text = viewModel.Note;
            txtLastPaymentDateLoanForm.Text = viewModel.LastPaymentDate.ToString("dd/MM/yyyy");
            txtNextInterestDueDateLoanForm.Text = viewModel.NextInterestDueDate.ToString("dd/MM/yyyy");
            txtInterestDueAmountLoanForm.Text = viewModel.InterestDueAmount.ToString("#,##0", new CultureInfo("vi-VN"));
            txtPenaltyFeeLoanForm.Text = viewModel.PenaltyFee.ToString("#,##0", new CultureInfo("vi-VN"));
            txtTotalLoanForm.Text = viewModel.Total.ToString("#,##0", new CultureInfo("vi-VN"));
            updateStatusLoan(viewModel.Paid_status);

            DateTime time = DateTime.Today;
            DateTime aMonthAgo = viewModel.NextInterestDueDate.AddMonths(-1);
            //Nếu trong 1 tháng từ NextInterestDueDate trở lại
            if (time > aMonthAgo && time <= viewModel.NextInterestDueDate)
            {
                btnPaymentLoanForm.Enabled = true;
            }
            else
            {
                btnPaymentLoanForm.Enabled= false;
            }
        }

        //Cập nhật view với từng trạng thái
        void updateStatusLoan(bool status)
        {
            if (status)
            {
                imgLoanStatusLoanForm.Image = Image.FromFile("..\\..\\Resources\\checked.png");
                lbLoanStatusLoanForm.Text = "isCompleted";
                lbLoanStatusLoanForm.ForeColor = Color.FromArgb(78, 167, 46);
                btnPaymentLoanForm.Enabled = false;
            }
            else
            {
                imgLoanStatusLoanForm.Image = Image.FromFile("..\\..\\Resources\\process.png");
                lbLoanStatusLoanForm.Text = "Within Term";
                lbLoanStatusLoanForm.ForeColor = Color.FromArgb(255, 100, 30);
                btnPaymentLoanForm.Enabled = true;
                lbLoanStatusLoanForm.Visible = true;
                imgLoanStatusLoanForm.Visible = true;
            }
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





        //Tạo 1 khoản vay mới--------------------------------------------------------------------------------------------------------------------------------------------------
        private void btnCreateLoanForm_Click(object sender, EventArgs e)
        {
            //Kiểm tra xem tài khoản này có đang phải trả khoản vay nào không
            if (viewModel.InPaymentPeriod())
            {
                CustomMessageBox.ShowBox(LangHelper.Instance.GetString("This customer is in a loan period and cannot borrow more!"), "Error");
                return;
            }

            if(lbAccountStatusLoanForm.Text == "Inactive")
            {
                CustomMessageBox.ShowBox(LangHelper.Instance.GetString("This account has been deleted!"), "Error");
                return;
            }

            if(txtAmountLoanForm.Text == "")
            {
                CustomMessageBox.ShowBox(LangHelper.Instance.GetString("Please enter the amount you need to borrow!"), "Error");
                return;
            }

            if(txtLoanTermLoanForm.Text == "")
            {
                CustomMessageBox.ShowBox(LangHelper.Instance.GetString("Please enter loan term!"), "Error");
                return;
            }

            if(txtLoanPurposeLoanForm.Text == "")
            {
                CustomMessageBox.ShowBox(LangHelper.Instance.GetString("Please enter loan purpose!"), "Error");
                return;
            }
            this.updateViewModelFromForm();
            try
            {
                viewModel.addLoan();
                viewModel.AddLog($"Tạo khoản vay với Account Number: {lbAccountNumberLoanForm.Text}", staffId);
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu cần
                CustomMessageBox.ShowBox("Error: " + ex.Message, "Error");
            }
        }
        //Chỉ cho nhập số
        private void txtSearchByAccountNumberLoanForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra xem ký tự nhập vào có phải là chữ số hay không
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Ngăn các ký tự không phải là chữ số
                e.Handled = true;
            }
        }
        private void txtAmountLoanForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra xem ký tự nhập vào có phải là chữ số hay không
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Ngăn các ký tự không phải là chữ số
                e.Handled = true;
            }
        }
        private void txtLoanTermLoanForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra xem ký tự nhập vào có phải là chữ số hay không
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Ngăn các ký tự không phải là chữ số
                e.Handled = true;
            }
        }
        //Không thể nhập quá 420 tháng
        private void txtLoanTermLoanForm_TextChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu giá trị nhập vào vượt quá 420
            if (int.TryParse(txtLoanTermLoanForm.Text, out int value) && value > 420)
            {
                // Đặt lại giá trị về 420 nếu nhập vượt quá giới hạn
                txtLoanTermLoanForm.Text = "420";
                // Đưa con trỏ chuột về cuối
                txtLoanTermLoanForm.SelectionStart = txtLoanTermLoanForm.Text.Length;
            }
        }
        //Chuyển đổi khi nhập 50000 -> 50.000
        private void txtAmountLoanForm_TextChanged(object sender, EventArgs e)
        {
            // Thử chuyển đổi sang decimal
            if (Decimal.TryParse(txtAmountLoanForm.Text, out decimal amount))
            {
                txtAmountLoanForm.Text = amount.ToString("#,0", new CultureInfo("vi-VN"));
                //Đặt con trỏ về cuối
                txtAmountLoanForm.SelectionStart = txtAmountLoanForm.Text.Length;
            }
        }




        //Cập nhật các view vào viewModel
        private void updateViewModelFromForm()
        {
            viewModel.Principal_amount = Decimal.Parse(txtAmountLoanForm.Text, new CultureInfo("vi-VN"));
            viewModel.Loan_date = DateTime.Parse(txtLoanDateLoanForm.Text);
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





        //Thanh toán khoản vay theo kỳ
        private void btnPaymentLoanForm_Click(object sender, EventArgs e)
        {
            try
            {
                viewModel.payment();
                viewModel.AddLog($"Đóng lãi cho Account Number: {lbAccountNumberLoanForm.Text}", staffId);
                btnPaymentLoanForm.Enabled = false;
                viewModel.CustomerAccountId.ToString();
                btnSearchByAccountNumberLoanForm_Click(null, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu cần
                CustomMessageBox.ShowBox("Error: " + ex.Message, "Error");
            }
        }
    }
}
