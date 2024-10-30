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
            DataRow row = dt.Rows[0]; // Lấy hàng đầu tiên (index 0)

            txtAmountLoanForm.Text = row["principal_amount"].ToString();
            txtInterestRateLoanForm.Text = row["interest_rate"].ToString();
            DateTime loan_date = DateTime.Parse(row["loan_date"].ToString());
            string loanDateFormat = loan_date.ToString("dd/MM/yyyy");
            txtLoanDateLoanForm.Text = loanDateFormat;
            txtLoanTermLoanForm.Text = row["loan_Term"].ToString();
            txtLoanPurposeLoanForm.Text = row["note"].ToString();
            DateTime last_payment_date = DateTime.Parse(row["last_payment_date"].ToString());
            string lastPaymentDateFormat = last_payment_date.ToString("dd/MM/yyyy");
            txtLastPaymentDateLoanForm.Text = lastPaymentDateFormat;

            float total = tinhlai(loan_date, last_payment_date, float.Parse(row["interest_rate"].ToString()) / 100, 0.05f, float.Parse(row["principal_amount"].ToString()));
            txtTotalLoanForm.Text = total.ToString();
        }

        private float tinhlai(DateTime ngayBatDau, DateTime ngayCuoiCungDong, float laiSuat, float tienphat, float tienGoc)
        {
            int soThang = ((DateTime.Today.Year - ngayBatDau.Year) * 12) + DateTime.Today.Month - ngayBatDau.Month;
            float tienLai = 0;

           
            int a = ngayBatDau.Day;
            int b = ngayCuoiCungDong.Day;
            if (checkngay(a, b))
            {
                tienLai = tienGoc * laiSuat + (tienGoc * laiSuat + (tienGoc * laiSuat * tienphat)) * soThang;
            }
            else tienLai = tienGoc * laiSuat +(tienGoc * laiSuat + (tienGoc * laiSuat * tienphat)) * (soThang-1);

            return tienLai;

        }

        public bool checkngay(int a , int b)
        {
            if(a< b) return true;
            else return false;
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
