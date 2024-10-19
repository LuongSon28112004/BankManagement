using BankManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

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


		//event click button depositWithdraw----------------------------------------------------------------------------------------------------------------------------
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
			txtContentTransactionForm.PlaceholderText = "Customer Name deposit/withdraw...";

		}





		//event click button transferTaskBar---------------------------------------------------------------------------------------------------------------------------------
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


		


		//event khi click vào nút chuyển tiền, kiểm tra dữ liệu các ô------------------------------------------------------------------------------------------------------
		private async void btnTransferTransactionForm_Click(object sender, EventArgs e)
		{
            // Vô hiệu hóa nút để tránh click nhiều lần
            btnTransferTransactionForm.Enabled = false;

            if (lbCustomerNameSendTransactionForm.Text == "Customer Name" || lbCustomerNameReceiveTransactionForm.Text == "Customer Name")
			{
				MessageBox.Show("Vui lòng nhập đầy đủ các thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnTransferTransactionForm.Enabled = true;
                return;
			}
            if(txtAccountNumberSendTransactionForm.Text == txtAccountNumberReceiveTransactionForm.Text)
            {
                MessageBox.Show("Không thể chuyển tiền giữa 2 tài khoản giống nhau!" , "Thông báo", MessageBoxButtons.OK  ,MessageBoxIcon.Error);
                btnTransferTransactionForm.Enabled = true;
                return;
            }
			if(txtAmountTransactionForm.Text == "")
			{
				MessageBox.Show("Vui lòng nhập số tiền cần chuyển!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnTransferTransactionForm.Enabled = true;
                return;
			}
			if(lbCustomerSendStatusTransactionForm.Text == "Inactive")
			{
				MessageBox.Show("Tài khoản gửi tiền không còn tồn tại trong hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnTransferTransactionForm.Enabled = true;
                return;
			}
			if(lbCustomerReceiveStatusTransactionForm.Text == "Inactive")
			{
				MessageBox.Show("Tài khoản nhận tiền không còn tồn tại trong hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnTransferTransactionForm.Enabled = true;
                return;
			}
            // Chuyển đổi số tiền từ định dạng "50.000" sang decimal
            decimal checkAmount;
            if (decimal.TryParse(txtAmountTransactionForm.Text.Replace(".", ""), NumberStyles.Any, CultureInfo.InvariantCulture, out checkAmount))
            {
                if (checkAmount < 10000)
                {
                    MessageBox.Show("Số tiền giao dịch quá nhỏ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnTransferTransactionForm.Enabled = true;
                    return;
                }
            }
            decimal balance;
            decimal amount;

            // Thử chuyển đổi giá trị từ txtBalanceTransactionForm
            bool isBalanceValid = Decimal.TryParse(txtBalanceTransactionForm.Text, NumberStyles.Any, new CultureInfo("vi-VN"), out balance);

            // Thử chuyển đổi giá trị từ txtAmountTransactionForm
            bool isAmountValid = Decimal.TryParse(txtAmountTransactionForm.Text, NumberStyles.Any, new CultureInfo("vi-VN"), out amount);

            // So sánh chỉ khi cả hai giá trị đều hợp lệ
            if (isBalanceValid && isAmountValid)
            {
                if (balance < amount)
                {
                    MessageBox.Show("Không đủ tiền để chuyển!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnTransferTransactionForm.Enabled = true;
                    return;
                }
            }
            if (txtContentTransactionForm.Text == "")
			{
                MessageBox.Show("Vui lòng nhập nội dung giao dịch!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnTransferTransactionForm.Enabled = true;
                return;
            }
			this.updateViewModelFromForm();
            DateTime time = DateTime.Now;
			viewModel.addTransactionTransfer(time);

            BillForm billForm = new BillForm(viewModel.Id, time, txtAccountNumberSendTransactionForm.Text, "", lbCustomerNameSendTransactionForm.Text, "", txtAmountTransactionForm.Text, txtContentTransactionForm.Text, "Chuyển tiền thành công!");

            balance = decimal.Parse(txtBalanceTransactionForm.Text, NumberStyles.Number, new CultureInfo("vi-VN"));
            amount = decimal.Parse(txtAmountTransactionForm.Text, NumberStyles.Number, new CultureInfo("vi-VN"));

            // Thực hiện phép cộng
            decimal total = balance - amount;

            // Định dạng lại và gán kết quả vào TextBox
            txtBalanceTransactionForm.Text = total.ToString("#,0", new CultureInfo("vi-VN"));

            // Delay 500ms trước khi hiển thị BillForm
            await Task.Delay(500);
            billForm.ShowDialog();

            // Kích hoạt lại nút sau khi hoàn thành
            btnTransferTransactionForm.Enabled = true;

            // Reset textbox và label
            this.reset();
        }

		



		//update viewModel từ form -----------------------------------------------------------------------------------------------------------------------------------------
		private void updateViewModelFromForm()
		{
            // Khai báo biến amount
            decimal amount;

            // Thử chuyển đổi giá trị từ txtAmountTransactionForm
            bool isAmountValid = decimal.TryParse(txtAmountTransactionForm.Text, NumberStyles.Any, new CultureInfo("vi-VN"), out amount);

            // Kiểm tra xem giá trị có hợp lệ không
            if (isAmountValid)
            {
                viewModel.Amount = amount; // Gán giá trị cho viewModel.Amount
            }
            else
            {
                // Xử lý trường hợp giá trị không hợp lệ
                MessageBox.Show("Giá trị không hợp lệ. Vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            viewModel.Note = txtContentTransactionForm.Text == "" ?  "" : txtContentTransactionForm.Text;
			viewModel.Account_customer_send = txtAccountNumberSendTransactionForm.Text == "" ? 0 : int.Parse(txtAccountNumberSendTransactionForm.Text);
			viewModel.Account_customer_receive = txtAccountNumberReceiveTransactionForm.Text == "" ? 0 : int.Parse(txtAccountNumberReceiveTransactionForm.Text);
			viewModel.Staff_account_transfer_id = staffId;

		}





		//event khi ấn vào nút tìm kiếm tài khoản gửi tiền---------------------------------------------------------------------------------------------------------------------
		private void btnSearchByAccountSendNumberTransactionForm_Click(object sender, EventArgs e)
		{
            int accountNumber;

            // Thử chuyển đổi giá trị từ txtSearchAccountNumberSendTransactionForm
            bool isValid = int.TryParse(txtSearchAccountNumberSendTransactionForm.Text, out accountNumber);

            // Kiểm tra xem giá trị có hợp lệ không
            if (!isValid)
            {
                return;
            }
            viewModel.searchAccountSend(accountNumber);
            if(viewModel.DatatableAccountSend.Rows.Count == 1)
            {
                this.updateCustomerAccountSend(viewModel.DatatableAccountSend);
				txtContentTransactionForm.Text = viewModel.DatatableAccountSend.Rows[0]["name"].ToString(); 
            }
            txtAmountTransactionForm.Text = "";
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
            // Giả sử row["balance"] chứa giá trị kiểu string với định dạng "55,00"
            string balanceString = row["balance"].ToString();

            // Thay thế dấu phẩy bằng dấu chấm và loại bỏ phần thập phân
            balanceString = balanceString.Replace(',', '.');

            // Chuyển đổi sang decimal
            if (Decimal.TryParse(balanceString, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal balance))
            {
                // Định dạng lại thành chuỗi với dấu phân cách hàng nghìn
                txtBalanceTransactionForm.Text = balance.ToString("#,0", new CultureInfo("vi-VN"));
            }

            //lấy thông tin của id gửi vào viewModel
            viewModel.Account_customer_send_id = int.Parse(row["id"].ToString());

        }





        //event khi nhấn vào nút tài khoản nhận tiền-------------------------------------------------------------------------------------------------------------------------------------
        private void btnSearchByAccountNumberReceiveTransactionForm_Click(object sender, EventArgs e)
		{
			if (txtAccountNumberReceiveTransactionForm.Text == "") return;
			if (txtAccountNumberSendTransactionForm.Text == "")
			{
                MessageBox.Show("Vui lòng nhập tài khoản chuyển!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int accountNumber;

            // Thử chuyển đổi giá trị từ txtSearchAccountNumberSendTransactionForm
            bool isValid = int.TryParse(txtAccountNumberReceiveTransactionForm.Text, out accountNumber);

            // Kiểm tra xem giá trị có hợp lệ không
            if (!isValid)
            {
                return; 
            }

            viewModel.searchAccountReceive(accountNumber);
            if(viewModel.DatatableAccountReceive.Rows.Count == 1)
            {
                this.updateCustomerAccountReceive(viewModel.DatatableAccountReceive);
				if (lbCustomerNameSendTransactionForm.Text != "Customer Name" && lbCustomerNameReceiveTransactionForm.Text != "Customer Name")
				{
                    txtContentTransactionForm.Text += " chuyen tien den " + viewModel.DatatableAccountReceive.Rows[0]["name"].ToString();
                }
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
		


		


		//chỉ cho phép nhập số, nhập 1 dấu phẩy và dấu phẩy và số 0 không được nằm ở đầu------------------------------------------------------------------------------------------------------
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





        //event khi nhấn vào nút deposit, kiểm tra dữ liệu các ô -------------------------------------------------------------------------------------------------------------------
        private async void btnDepositTransactionForm_Click(object sender, EventArgs e)
        {
            // Vô hiệu hóa nút để tránh click nhiều lần
            btnDepositTransactionForm.Enabled = false;
            btnWithDrawTransactionForm.Enabled = false;

            if (lbCustomerNameSendTransactionForm.Text == "Customer Name")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ các thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnDepositTransactionForm.Enabled = true;
                btnWithDrawTransactionForm.Enabled = true; // Kích hoạt lại nút
                return;
            }

            if (txtAmountTransactionForm.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số tiền cần gửi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnDepositTransactionForm.Enabled = true;
                btnWithDrawTransactionForm.Enabled = true; // Kích hoạt lại nút
                return;
            }

            if (lbCustomerSendStatusTransactionForm.Text == "Inactive")
            {
                MessageBox.Show("Tài khoản gửi tiền không còn tồn tại trong hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnDepositTransactionForm.Enabled = true;
                btnWithDrawTransactionForm.Enabled = true; // Kích hoạt lại nút
                return;
            }

            if (txtContentTransactionForm.Text == "")
            {
                MessageBox.Show("Vui lòng nhập nội dung giao dịch!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnDepositTransactionForm.Enabled = true;
                btnWithDrawTransactionForm.Enabled = true; // Kích hoạt lại nút
                return;
            }

            // Chuyển đổi số tiền từ định dạng "50.000" sang decimal
            decimal checkAmount;
            if (decimal.TryParse(txtAmountTransactionForm.Text.Replace(".", ""), NumberStyles.Any, CultureInfo.InvariantCulture, out checkAmount))
            {
                if (checkAmount < 10000)
                {
                    MessageBox.Show("Số tiền giao dịch quá nhỏ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnDepositTransactionForm.Enabled = true;
                    btnWithDrawTransactionForm.Enabled = true; // Kích hoạt lại nút
                    return;
                }
            }

            this.updateViewModelFromForm();
            DateTime time = DateTime.Now;
            viewModel.addTransactionDeposit(time);
            BillForm billForm = new BillForm(viewModel.Id, time, txtAccountNumberSendTransactionForm.Text, "", lbCustomerNameSendTransactionForm.Text, "", txtAmountTransactionForm.Text, txtContentTransactionForm.Text, "Nạp tiền thành công!");

            decimal balance = decimal.Parse(txtBalanceTransactionForm.Text, NumberStyles.Number, new CultureInfo("vi-VN"));
            decimal amount = decimal.Parse(txtAmountTransactionForm.Text, NumberStyles.Number, new CultureInfo("vi-VN"));

            // Thực hiện phép cộng
            decimal total = balance + amount;

            // Định dạng lại và gán kết quả vào TextBox
            txtBalanceTransactionForm.Text = total.ToString("#,0", new CultureInfo("vi-VN"));

            // Delay 500ms trước khi hiển thị BillForm
            await Task.Delay(500);
            billForm.ShowDialog();

            // Kích hoạt lại nút sau khi hoàn thành
            btnDepositTransactionForm.Enabled = true;
            btnWithDrawTransactionForm.Enabled = true;

            // Reset textbox và label
            this.reset();
        }






        //event khi nhấn vào nút withdraw , kiểm tra dữ liệu các ô--------------------------------------------------------------------------------------------------------------
        private async void btnWithDrawTransactionForm_Click(object sender, EventArgs e)
		{
            // Vô hiệu hóa nút để tránh click nhiều lần
            btnDepositTransactionForm.Enabled = false;
            btnWithDrawTransactionForm.Enabled = false;

            if (lbCustomerNameSendTransactionForm.Text == "Customer Name")
			{
				MessageBox.Show("Vui lòng nhập đầy đủ các thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnDepositTransactionForm.Enabled = true;
                btnWithDrawTransactionForm.Enabled = true;
                return;
			}

			if (txtAmountTransactionForm.Text == "")
			{
				MessageBox.Show("Vui lòng nhập số tiền cần rút!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnDepositTransactionForm.Enabled = true;
                btnWithDrawTransactionForm.Enabled = true;
                return;
			}
			if (lbCustomerSendStatusTransactionForm.Text == "Inactive")
			{
				MessageBox.Show("Tài khoản rút tiền không còn tồn tại trong hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnDepositTransactionForm.Enabled = true;
                btnWithDrawTransactionForm.Enabled = true;
                return;
			}
            if (txtContentTransactionForm.Text == "")
            {
                MessageBox.Show("Vui lòng nhập nội dung giao dịch!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnDepositTransactionForm.Enabled = true;
                btnWithDrawTransactionForm.Enabled = true; // Kích hoạt lại nút
                return;
            }

            // Chuyển đổi số tiền từ định dạng "50.000" sang decimal
            decimal checkAmount;
            if (decimal.TryParse(txtAmountTransactionForm.Text.Replace(".", ""), NumberStyles.Any, CultureInfo.InvariantCulture, out checkAmount))
            {
                if (checkAmount < 10000)
                {
                    MessageBox.Show("Số tiền giao dịch quá nhỏ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnDepositTransactionForm.Enabled = true;
                    btnWithDrawTransactionForm.Enabled = true; // Kích hoạt lại nút
                    return;
                }
            }
            decimal balance;
            decimal amount;

            // Thử chuyển đổi giá trị từ txtBalanceTransactionForm
            bool isBalanceValid = Decimal.TryParse(txtBalanceTransactionForm.Text, NumberStyles.Any, new CultureInfo("vi-VN"), out balance);

            // Thử chuyển đổi giá trị từ txtAmountTransactionForm
            bool isAmountValid = Decimal.TryParse(txtAmountTransactionForm.Text, NumberStyles.Any, new CultureInfo("vi-VN"), out amount);

            // So sánh chỉ khi cả hai giá trị đều hợp lệ
            if (isBalanceValid && isAmountValid)
            {
                if (balance < amount)
                {
                    MessageBox.Show("Không đủ tiền để rút!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnDepositTransactionForm.Enabled = true;
                    btnWithDrawTransactionForm.Enabled = true;
                    return;
                }
            }
            this.updateViewModelFromForm();
            DateTime time = DateTime.Now;
            viewModel.addTransactionWithdraw(time);
            BillForm billForm = new BillForm(viewModel.Id, time, txtAccountNumberSendTransactionForm.Text, "", lbCustomerNameSendTransactionForm.Text, "", txtAmountTransactionForm.Text, txtContentTransactionForm.Text, "Rút tiền thành công!");

            balance = decimal.Parse(txtBalanceTransactionForm.Text, NumberStyles.Number, new CultureInfo("vi-VN"));
            amount = decimal.Parse(txtAmountTransactionForm.Text, NumberStyles.Number, new CultureInfo("vi-VN"));

            // Thực hiện phép cộng
            decimal total = balance - amount;

            // Định dạng lại và gán kết quả vào TextBox
            txtBalanceTransactionForm.Text = total.ToString("#,0", new CultureInfo("vi-VN"));

            // Delay 500ms trước khi hiển thị BillForm
            await Task.Delay(500);
            billForm.ShowDialog();

            // Kích hoạt lại nút sau khi hoàn thành
            btnDepositTransactionForm.Enabled = true;
            btnWithDrawTransactionForm.Enabled = true;

            // Reset textbox và label
            this.reset();
        }





		//Btn Reset---------------------------------------------------------------------------------------------------------------------------------------------------------
        private void btnResetTransactionForm_Click(object sender, EventArgs e)
        {
			this.reset();
        }
        //reset các textbox và label
        private void reset()
        {
            imgCustomerSendTracsactionForm.Image = System.Drawing.Image.FromFile($"..\\..\\Resources\\avatar_customer_default.png");
            imgCustomerReceiveTransactionForm.Image = System.Drawing.Image.FromFile($"..\\..\\Resources\\avatar_customer_default.png");
            txtSearchAccountNumberSendTransactionForm.Text = "";
            lbCustomerNameSendTransactionForm.Text = "Customer Name";
            lbCCCDCustomerSendTransactionForm.Text = "024xxxxxxxxx";
            this.SetAccountSendStatus("Status");
            txtAccountNumberSendTransactionForm.Text = "";
            txtBalanceTransactionForm.Text = "";
            txtAmountTransactionForm.Text = "";
            txtContentTransactionForm.Text = "";
			txtAccountNumberReceiveTransactionForm.Text = "";
        }
        //set status của tài khoản gửi 
        private void SetAccountSendStatus(string status)
        {
            if (status == "Inactive")
            {
                imgCustomerSendStatusTransactionForm.Image = System.Drawing.Image.FromFile("..\\..\\Resources\\x-button.png");
                lbCustomerSendStatusTransactionForm.Text = status;
                lbCustomerSendStatusTransactionForm.ForeColor = Color.FromArgb(203, 57, 53);
            }
            else
            {
                imgCustomerSendStatusTransactionForm.Image = System.Drawing.Image.FromFile("..\\..\\Resources\\checked.png");
                lbCustomerSendStatusTransactionForm.Text = status;
                lbCustomerSendStatusTransactionForm.ForeColor = Color.FromArgb(90, 190, 40);
            }
        }
        //set status của tài khoản nhận 
        private void SetAccountReceiveStatus(string status)
        {
            if (status == "Inactive")
            {
                imgCustomerReceiveStatusTransactionForm.Image = System.Drawing.Image.FromFile("..\\..\\Resources\\x-button.png");
                lbCustomerReceiveStatusTransactionForm.Text = status;
                lbCustomerReceiveStatusTransactionForm.ForeColor = Color.FromArgb(203, 57, 53);
            }
            else
            {
                imgCustomerReceiveStatusTransactionForm.Image = System.Drawing.Image.FromFile("..\\..\\Resources\\checked.png");
                lbCustomerReceiveStatusTransactionForm.Text = status;
                lbCustomerReceiveStatusTransactionForm.ForeColor = Color.FromArgb(90, 190, 40);
            }
        }





        //Tự động chuyển 5000 thành 5.000 --------------------------------------------------------------------------------------------------------------------------------------------------------------
        private bool isUpdating = false;
        private void txtAmountTransactionForm_TextChanged(object sender, EventArgs e)
        {
            if (isUpdating) return; // Nếu đang cập nhật thì bỏ qua

            // Lưu giá trị tạm thời
            string input = txtAmountTransactionForm.Text;

            // Thay thế dấu phẩy thành dấu chấm (nếu có)
            input = input.Replace(',', '.');

            // Xóa các ký tự không phải số
            input = new string(input.Where(char.IsDigit).ToArray());

            // Thử chuyển đổi sang decimal
            if (Decimal.TryParse(input, out decimal amount))
            {
                // Định dạng lại thành chuỗi với dấu phân cách hàng nghìn
                isUpdating = true; // Đánh dấu là đang cập nhật
                txtAmountTransactionForm.Text = amount.ToString("#,0", new CultureInfo("vi-VN"));

                // Đặt con trỏ vào cuối TextBox
                txtAmountTransactionForm.SelectionStart = txtAmountTransactionForm.Text.Length;
                isUpdating = false; // Kết thúc cập nhật
            }
        }
    }
}
