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
        public LoanFrom(int staffId)
        {
            InitializeComponent();
            this.staffId = staffId;
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
    }
}
