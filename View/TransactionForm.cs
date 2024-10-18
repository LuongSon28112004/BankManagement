using BankManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace BankManagement.View
{
    public partial class TransactionForm : Form
    {
        TransactionViewModel viewModel;
		int staffId;

		//constructor
        public TransactionForm(int staffId)
        {
			this.staffId = staffId;
            InitializeComponent();
            viewModel = new TransactionViewModel();
            this.ShowInTaskbar = false;
        }


		//load form
        private void TransactionForm_Load(object sender, EventArgs e)
        {
            btnDepositWithdrawTaskBarTransactionForm.HoverState.FillColor = Color.FromArgb(50, 50, 50);
            btnTransferTaskBarTransactionForm.HoverState.FillColor = Color.FromArgb(50, 50, 50);
        }

		//event click button depositWithdraw
        private void btnDepositWithdrawTaskBarTransactionForm_Click(object sender, EventArgs e)
        {
			//reset lai cac label va textbox
			this.reset();
            btnDepositWithdrawTaskBarTransactionForm.ForeColor = Color.FromArgb(255, 255, 255);
            btnTransferTaskBarTransactionForm.ForeColor = Color.FromArgb(170, 170, 170);
            btnDepositWithdrawTaskBarTransactionForm.CustomBorderThickness = new Padding(0, 0, 0, 1);
            btnTransferTaskBarTransactionForm.CustomBorderThickness = new Padding(0, 0, 0, 0);
            btnDepositWithdrawTaskBarTransactionForm.CustomBorderColor = Color.Aquamarine;

            panelCustomerReceiveTransactionForm.Visible = false; //Ẩn panel người nhận
            //hiện 2 nút nạp và rút 
			btnDepositTransactionForm.Visible = true;
			btnWithDrawTransactionForm.Visible = true;
			//reset content
			txtContentTransactionForm.PlaceholderText = "Nội Dung";

		}

		//event click button transferTaskBar
        private void btnTransferTaskBarTransactionForm_Click(object sender, EventArgs e)
        {
			//reset lai cac label va textbox
			this.reset();
			btnDepositWithdrawTaskBarTransactionForm.ForeColor = Color.FromArgb(170, 170, 170);
            btnTransferTaskBarTransactionForm.ForeColor = Color.FromArgb(255, 255, 255);
            btnDepositWithdrawTaskBarTransactionForm.CustomBorderThickness = new Padding(0, 0, 0, 0);
            btnTransferTaskBarTransactionForm.CustomBorderThickness = new Padding(0, 0, 0, 1);
            btnTransferTaskBarTransactionForm.CustomBorderColor = Color.Aquamarine;

            panelCustomerReceiveTransactionForm.Visible = true; //Hiện panel người nhận

            //Tạo hiệu ứng bật lại
            panelCustomerSendTransactionForm.Visible = false;
            panelCustomerSendTransactionForm.Visible = true;
            //tắt 2 nút nạp và rút 
            btnDepositTransactionForm.Visible = false;
            btnWithDrawTransactionForm.Visible = false;

			//reset content
			txtContentTransactionForm.PlaceholderText = "Customer Name transfer to...";
		}


		//reset các textbox và label
		private void reset()
		{
			imgCustomerSendTracsactionForm.Image = System.Drawing.Image.FromFile($"..\\..\\Image\\CustomerImage\\img_customer_default.png");
			txtSearchAccountNumberSendTransactionForm.Text = "";
			lbCustomerNameSendTransactionForm.Text = "Customer Name";
			lbCCCDCustomerSendTransactionForm.Text = "024xxxxxxxxx";
			this.SetAccountSendStatus("Active");
			txtAccountNumberSendTransactionForm.Text = "";
			txtBalanceTransactionForm.Text = "";
			txtAmountTransactionForm.Text = "";
			txtContentTransactionForm.Text = "";
		}


		//event khi click vào nút chuyển tiền , kiểm tra dữ liệu các ô
		private void btnTransferTransactionForm_Click(object sender, EventArgs e)
		{
			if(lbCustomerNameSendTransactionForm.Text == "Customer Name" || lbCustomerNameReceiveTransactionForm.Text == "Customer Name")
			{
				MessageBox.Show("Vui lòng nhập đầy đủ các thông tin ", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
            if(txtAccountNumberSendTransactionForm.Text == txtAccountNumberReceiveTransactionForm.Text)
            {
                MessageBox.Show("Không thể chuyển tiền giữa 2 tài khoản giống nhau" , "thông báo", MessageBoxButtons.OK  ,MessageBoxIcon.Error);
                return;
            }
			if(txtAmountTransactionForm.Text == "")
			{
				MessageBox.Show("vui lòng nhập số tiền cần chuyển", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			if(lbCustomerSendStatusTransactionForm.Text == "Inactive")
			{
				MessageBox.Show("tài khoản gửi tiền không còn tồn tại trong hệ thống", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if(lbCustomerReceiveStatusTransactionForm.Text == "Inactive")
			{
				MessageBox.Show("tài khoản nhận tiền không còn tồn tại trong hệ thống", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if(Decimal.Parse(txtBalanceTransactionForm.Text) < Decimal.Parse(txtAmountTransactionForm.Text))
			{
				MessageBox.Show("không đủ tiền để giao dịch", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			this.updateViewModelFromForm();
			viewModel.addTransactionTransfer();
			//reset textbox va label
			this.reset();
		}


		//update viewModel từ form 
		private void updateViewModelFromForm()
		{
			viewModel.Amount = decimal.Parse(txtAmountTransactionForm.Text);
			viewModel.Note = txtContentTransactionForm.Text == "" ? lbCustomerNameSendTransactionForm.Text + " Chuyển tiền đến " + lbCustomerNameReceiveTransactionForm.Text : txtContentTransactionForm.Text;
			viewModel.Account_customer_send = txtAccountNumberSendTransactionForm.Text == "" ? 0 : int.Parse(txtAccountNumberSendTransactionForm.Text);
			viewModel.Account_customer_receive = txtAccountNumberReceiveTransactionForm.Text == "" ? 0 : int.Parse(txtAccountNumberReceiveTransactionForm.Text);
			viewModel.Staff_account_transfer_id = staffId;

		}

		//event khi ấn vào nút tìm kiếm tài khoản gửi tiền
		private void btnSearchByAccountSendNumberTransactionForm_Click(object sender, EventArgs e)
		{
            int accountNumber =int.Parse(txtSearchAccountNumberSendTransactionForm.Text);
            viewModel.searchAccountSend(accountNumber);
            if(viewModel.DatatableAccountSend.Rows.Count == 1)
            {
                this.updateCustomerAccountSend(viewModel.DatatableAccountSend);
            }
		}


		//event khi nhấn vào nút tài khoản nhận tiền
		private void btnSearchByAccountNumberReceiveTransactionForm_Click(object sender, EventArgs e)
		{
            int accountNumber = int.Parse(txtAccountNumberReceiveTransactionForm.Text);
            viewModel.searchAccountReceive(accountNumber);
            if(viewModel.DatatableAccountReceive.Rows.Count == 1)
            {
                this.updateCustomerAccountReceive(viewModel.DatatableAccountReceive);
            }
		}


		//lấy thông tin và hiển thị ra form 
        private void updateCustomerAccountReceive(DataTable dt)
        {
			DataRow row = dt.Rows[0]; // Lấy hàng đầu tiên
			// Lấy thông tin hiển thị ra form
            lbCustomerNameReceiveTransactionForm.Text = row["name"].ToString();
            lbCCCDCustomerReceiveTransactionForm.Text = row["cccd"].ToString();
			imgCustomerReceiveTransactionForm.Image = System.Drawing.Image.FromFile($"..\\..\\Image\\CustomerImage\\{row["photo"].ToString()}");
			this.SetAccountReceiveStatus(row["account_status"].ToString());
            txtAccountNumberReceiveTransactionForm.Text = row["account_number"].ToString();

			//lấy thông tin của id gửi vào viewModel
			viewModel.Account_customer_receive_id = int.Parse(row["id"].ToString());

		}

		//set status của tài khoản nhận 
        private void SetAccountReceiveStatus(string status)
        {
			if (status == "Active")
			{
				imgCustomerReceiveStatusTransactionForm.Image = System.Drawing.Image.FromFile("..\\..\\Resources\\checked.png");
				lbCustomerReceiveStatusTransactionForm.Text = status;
				lbCustomerReceiveStatusTransactionForm.ForeColor = Color.FromArgb(78, 167, 46);
			}
			else
			{
				imgCustomerReceiveStatusTransactionForm.Image = System.Drawing.Image.FromFile("..\\..\\Resources\\x-button.png");
				lbCustomerReceiveStatusTransactionForm.Text = status;
				lbCustomerReceiveStatusTransactionForm.ForeColor = Color.FromArgb(203, 57, 53);
			}
		}

		//lấy thông tin tài khoản gửi và hiển thị ra form
		private void updateCustomerAccountSend(DataTable dt)
		{
			DataRow row = dt.Rows[0]; // Lấy hàng đầu tiên
			// Lấy thông tin hiển thị ra form
			lbCustomerNameSendTransactionForm.Text = row["name"].ToString();
			lbCCCDCustomerSendTransactionForm.Text = row["cccd"].ToString();
		    imgCustomerSendTracsactionForm.Image = System.Drawing.Image.FromFile($"..\\..\\Image\\CustomerImage\\{row["photo"].ToString()}");
			this.SetAccountSendStatus(row["account_status"].ToString());
			txtAccountNumberSendTransactionForm.Text = row["account_number"].ToString();
			txtBalanceTransactionForm.Text = row["balance"].ToString();

			//lấy thông tin của id gửi vào viewModel
			viewModel.Account_customer_send_id = int.Parse(row["id"].ToString());

		}


		//set status của tài khoản gửi 
		private void SetAccountSendStatus(string status)
		{
			if (status == "Active")
			{
				imgCustomerSendStatusTransactionForm.Image = System.Drawing.Image.FromFile("..\\..\\Resources\\checked.png");
				lbCustomerSendStatusTransactionForm.Text = status;
				lbCustomerSendStatusTransactionForm.ForeColor = Color.FromArgb(78, 167, 46);
			}
			else
			{
				imgCustomerSendStatusTransactionForm.Image = System.Drawing.Image.FromFile("..\\..\\Resources\\x-button.png");
				lbCustomerSendStatusTransactionForm.Text = status;
				lbCustomerSendStatusTransactionForm.ForeColor = Color.FromArgb(203, 57, 53);
			}
		}


		//chỉ cho phép nhập số , nhập 1 dấu phẩy và dấu phẩy và số 0 không được nằm ở đầu
		private void txtAmountTransactionForm_KeyPress(object sender, KeyPressEventArgs e)
		{

			// Kiểm tra nếu ký tự không phải là số, không phải là điều khiển và không phải là dấu phẩy
			if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',')
			{
				e.Handled = true; // Chặn kí tự không hợp lệ
			}

			// Đảm bảo chỉ có một dấu phẩy được nhập vào
			if (e.KeyChar == ',' && txtAmountTransactionForm.Text.Contains(","))
			{
				e.Handled = true; // Chặn nếu đã có dấu phẩy
			}

			// Không cho nhập dấu phẩy ở đầu
			if (e.KeyChar == ',' && txtAmountTransactionForm.Text.Length == 0)
			{
				e.Handled = true; // Chặn nếu dấu phẩy ở đầu
			}

			// Không cho nhập số 0 ở đâù
			if (e.KeyChar == '0' && txtAmountTransactionForm.Text.Length == 0)
			{
				e.Handled = true; // Chặn nếu dấu phẩy ở đầu
			}


		}


		//event khi nhấn vào nút deposit , kiểm tra dữ liệu các ô 
		private void btnDepositTransactionForm_Click(object sender, EventArgs e)
		{
			if (lbCustomerNameSendTransactionForm.Text == "Customer Name")
			{
				MessageBox.Show("Vui lòng nhập đầy đủ các thông tin ", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (txtAmountTransactionForm.Text == "")
			{
				MessageBox.Show("vui lòng nhập số tiền cần gửi", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			if (lbCustomerSendStatusTransactionForm.Text == "Inactive")
			{
				MessageBox.Show("tài khoản gửi tiền không còn tồn tại trong hệ thống", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			this.updateViewModelFromForm();
			viewModel.addTransactionDeposit();
			//reset textbox va label
			this.reset();
		}


		//event khi nhấn vào nút withdraw , kiểm tra dữ liệu các ô 
		private void btnWithDrawTransactionForm_Click(object sender, EventArgs e)
		{
			if (lbCustomerNameSendTransactionForm.Text == "Customer Name")
			{
				MessageBox.Show("Vui lòng nhập đầy đủ các thông tin ", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			if (txtAmountTransactionForm.Text == "")
			{
				MessageBox.Show("vui lòng nhập số tiền cần rút", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			if (lbCustomerSendStatusTransactionForm.Text == "Inactive")
			{
				MessageBox.Show("tài khoản rút tiền không còn tồn tại trong hệ thống", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			if (Decimal.Parse(txtBalanceTransactionForm.Text) < Decimal.Parse(txtAmountTransactionForm.Text))
			{
				MessageBox.Show("không đủ tiền để rút", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			this.updateViewModelFromForm();
			viewModel.addTransactionWithdraw();
			//reset textbox va label
			this.reset();
		}
	}
}
