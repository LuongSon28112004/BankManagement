using BankManagement.Model;
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
using System.Windows.Forms;

namespace BankManagement.View
{
    public partial class CustomerAccountForm : Form
    {
        AccountViewModel viewModel;
        private int staffId;
        public CustomerAccountForm(int staffId)
        {
            InitializeComponent();
            viewModel = new AccountViewModel();
            this.reset();
            this.ShowInTaskbar = false; //Ẩn khỏi thanh taskbar
            this.staffId = staffId;
        }


        private void CustomerAccountForm_Load(object sender, EventArgs e)
        {
            //Đăng ký sự kiện ScrollBar vertical của dataGridView
            dataGridViewCustomerAccountForm.MouseWheel += dataGridViewCustomerAccountForm_MouseWheel;
        }





        //Sự kiện sử dụng con lăn chuột để kéo dataGridView---------------------------------------------------------------------------------------------------------
        private void dataGridViewCustomerAccountForm_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                if (dataGridViewCustomerAccountForm.FirstDisplayedScrollingRowIndex > 0)
                {
                    dataGridViewCustomerAccountForm.FirstDisplayedScrollingRowIndex--;
                }
            }
            else if (e.Delta < 0)
            {
                if (dataGridViewCustomerAccountForm.FirstDisplayedScrollingRowIndex < dataGridViewCustomerAccountForm.RowCount - 1)
                {
                    dataGridViewCustomerAccountForm.FirstDisplayedScrollingRowIndex++;
                }
            }
        }





        //Tìm kiếm theo account number và trả về danh sách các tài khoản---------------------------------------------------------------------------------------------------
        private void btnSearchByAccountNumberCustomerAccountForm_Click(object sender, EventArgs e)
        {
            int accountNumber;

            // Thử chuyển đổi giá trị từ txtSearchAccountNumberSendTransactionForm
            bool isValid = int.TryParse(txtSearchAccountNumberAccountCustomerForm.Text, out accountNumber);

            // Kiểm tra xem giá trị có hợp lệ không
            if (!isValid)
            {
                return;
            }

            try
            {
                //Cập nhật DataTableAccountInfor của viewModel chứa các thông tin về tài khoản và thông tin người dùng
                viewModel.searchCustomerAccountByAccountNumber(accountNumber);

                //Cập nhật dataGridView
                dataGridViewCustomerAccountForm.Rows.Clear();
                this.updateDataGridView(viewModel.DataTableAccountInfor);
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu cần
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }





        //Tìm kiếm thông tin khách hàng bằng CCCD và cập nhật Panel chứa thông tin khách hàng-----------------------------------------------------------------
        private void btnSearchByCCCDCustomerAccountForm_Click(object sender, EventArgs e)
        {
            viewModel.searchCustomerInforByCccd(txtSearchByCCCDCustomerAccountForm.Text); //Trả về một DataTable
            if (viewModel.DataTableCustomerInfor.Rows.Count == 1) //Nếu có 1 bản ghi duy nhất thì cập nhật thông tin khách hàng
            {
                this.updateCustomerInfor(viewModel.DataTableCustomerInfor);
            }
            viewModel.searchCustomerAccountByCCCD(txtSearchByCCCDCustomerAccountForm.Text);
            //Cập nhật dataGridView
            dataGridViewCustomerAccountForm.Rows.Clear();
            this.updateDataGridView(viewModel.DataTableAccountInfor);
        }
        //Hiển thị thông tin của Customer trên Form
        private void updateCustomerInfor(DataTable dt)
        {
            DataRow row = dt.Rows[0]; // Lấy hàng đầu tiên (index 0)

            lbCustomerNameCustomerAccountForm.Text = row["name"].ToString();

            imgCustomerCustomerAccountForm.Image = Image.FromFile($"..\\..\\Image\\CustomerImage\\{row["photo"].ToString()}");
            lbCCCDCustomerAccountForm.Text = row["cccd"].ToString();

            DateTime dateOfBirth = DateTime.Parse(row["date_of_birth"].ToString());
            string formattedDateOfBirth = dateOfBirth.ToString("dd/MM/yyyy");
            txtDateOfBirthCustomerAccountForm.Text = formattedDateOfBirth;

            txtGenderCustomerAccountForm.Text = row["gender"].ToString();
            txtEmailCustomerAccountForm.Text = row["email"].ToString();
            txtAddressCustomerAccountForm.Text = row["address"].ToString();

            this.checkStatusCustomerInfor(row["status"].ToString());
        }





        //Thêm một tài khoản--------------------------------------------------------------------------------------------------------------------------
        private void btnAddCustomerAccountForm_Click(object sender, EventArgs e)
        {
            if (lbCCCDCustomerAccountForm.Text == "024xxxxxxxxx")
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //Khi khách hàng không còn tồn tại trong hệ thống
            if (lbCustomerInfStatusCustomerAccountForm.Text == "Inactive") 
            {
                MessageBox.Show("Khách hàng này không còn tồn tại trong hệ thống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.updateViewModelFromForm();
            if(txtUsernameCustomerAccountForm.Text == "")
            {
                MessageBox.Show("Vui lòng điền Username!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                viewModel.AddCustomerAccount();
                viewModel.AddLog("Thêm tài khoản có Account Number: ");

                //Thay thế tất cả các dữ liệu trong dataGridView
                this.reset();
                dataGridViewCustomerAccountForm.Rows.Clear();
                this.LoadAllAccount();
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu cần
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        // Reset các component trong View-----------------------------------------------------------------------------------------------------------------------------
        private void btnResetCustomerAccountForm_Click(object sender, EventArgs e)
        {
            this.reset();
            //Thay thế tất cả các dữ liệu trong datagridview
            dataGridViewCustomerAccountForm.Rows.Clear();
            this.LoadAllAccount();
        }





        // xóa một tài khoản khỏi ngân hàng
        private void btnDeleteCustomerAccountForm_Click(object sender, EventArgs e)
        {
            if (txtAccountNumberCustomerAccountForm.Text == "0000000000" || lbCCCDCustomerAccountForm.Text == "024xxxxxxxxx")
            {
                MessageBox.Show("Chưa có tài khoản nào được chọn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }    
            this.updateViewModelFromForm();
            try
            {
                viewModel.deleteCustomerAccount();

                viewModel.AddLog("Xoá tài khoản có Account Number: ");

                //Thay thế tất cả các dữ liệu trong datagridview
                checkStatusCustomerAccount("Inactive");
                dataGridViewCustomerAccountForm.Rows.Clear();
                this.LoadAllAccount();
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu cần
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        //Reset View---------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void reset()
        {
            this.LoadAllAccount();
            this.updateDateOpened();
            this.updateBalance();

            txtUsernameCustomerAccountForm.ReadOnly = false;
            txtAccountNumberCustomerAccountForm.Text = "000xxxxxxx";
            txtSearchByCCCDCustomerAccountForm.Text = "";
            lbCustomerNameCustomerAccountForm.Text = "Customer Name";
            lbCCCDCustomerAccountForm.Text = "024xxxxxxxxx";
            txtDateOfBirthCustomerAccountForm.Text = "";
            txtGenderCustomerAccountForm.Text = "";
            txtEmailCustomerAccountForm.Text = "";
            txtAddressCustomerAccountForm.Text = "";
            txtUsernameCustomerAccountForm.Text = "";
            txtSearchAccountNumberAccountCustomerForm.Text = "";
            imgCustomerCustomerAccountForm.Image = Image.FromFile("..\\..\\Resources\\avatar_customer_default.png");
            lbCustomerInfStatusCustomerAccountForm.Text = "Status";
            lbCustomerInfStatusCustomerAccountForm.ForeColor = Color.FromArgb(90, 190, 40);
            lbAccountStatusCustomerAccountForm.Text = "Status";
            lbAccountStatusCustomerAccountForm.ForeColor = Color.FromArgb(90, 190, 40);
            imgCustomerInfStatusCustomerAccountForm.Image = Image.FromFile("..\\..\\Resources\\checked.png");
            imgAccountStatusCustomerAccountForm.Image = Image.FromFile("..\\..\\Resources\\checked.png");
            btnActiveCustomerAccountForm.Visible = false;

        }
        //Cập nhật ngày hiện tại
        private void updateDateOpened()
        {
            DateTime today = DateTime.Today;
            string formattedDateOpened = today.ToString("dd/MM/yyyy");
            txtOpenDateCustomerAccountForm.Text = formattedDateOpened;
        }
        //Cập nhật số dư mặc định khi thêm tài khoản
        private void updateBalance()
        {
            decimal balance = 50000.0000m; // Số decimal
            txtBalanceCustomerAccountForm.Text = balance.ToString("#,##0", new CultureInfo("vi-VN")); // Hiển thị với định dạng dấu chấm phân cách
        }





        //Active account----------------------------------------------------------------------------------------------------------------------------------------------------
        private void btnActiveCustomerAccountForm_Click(object sender, EventArgs e)
        {
            if (txtAccountNumberCustomerAccountForm.Text == "000xxxxxxx" || lbCCCDCustomerAccountForm.Text == "024xxxxxxxxx")
            {
                MessageBox.Show("Chưa có tài khoản nào được chọn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (lbCustomerInfStatusCustomerAccountForm.Text == "Inactive")
            {
                MessageBox.Show("Không thể kích hoạt tài khoản do khách hàng này không còn hoạt động!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.updateViewModelFromForm();
            try
            {
                viewModel.updateStatusAccountCustomer();

                viewModel.AddLog("Active tài khoản có Account Number: ");

                
                checkStatusCustomerAccount("Active");

                btnActiveCustomerAccountForm.Visible = false;

                //Thay thế tất cả các dữ liệu trong datagridview
                dataGridViewCustomerAccountForm.Rows.Clear();
                this.LoadAllAccount();
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu cần
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        //Cập nhật các view khi click vào một cell trong DataGridView--------------------------------------------------------------------------------------------------------------------
        private void dataGridViewCustomerAccountForm_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem chỉ số hàng hợp lệ
            if (e.RowIndex >= 0)
            {
                // Lấy hàng được chọn
                DataGridViewRow selectedRow = dataGridViewCustomerAccountForm.Rows[e.RowIndex];
                txtUsernameCustomerAccountForm.ReadOnly = true;

                if (selectedRow.Cells["cccd"].Value != null)
                {
                    // Lấy dữ liệu từ các cột trong hàng với kiểm tra null
                    string cccd = selectedRow.Cells["cccd"].Value.ToString();
                    string name = selectedRow.Cells["customerName"].Value.ToString();
                    string dateOfBirth = selectedRow.Cells["dateOfBirth"].Value.ToString();
                    string address = selectedRow.Cells["address"].Value.ToString();
                    string email = selectedRow.Cells["email"].Value.ToString();
                    string gender = selectedRow.Cells["Gender"].Value.ToString();
                    string accountstatus = selectedRow.Cells["status"].Value.ToString();
                    string customerStatus = selectedRow.Cells["CustomerStatus"].Value.ToString();
                    string photo = selectedRow.Cells["Photo"].Value.ToString();
                    string account_number = selectedRow.Cells["AccountNumber"].Value.ToString();
                    string date_opened = selectedRow.Cells["OpenDate"].Value.ToString();
                    string username = selectedRow.Cells["Username"].Value.ToString();
                    string balanceString = selectedRow.Cells["Balance"].Value.ToString();

                    // Chuyển đổi chuỗi thành decimal
                    if (Decimal.TryParse(balanceString, NumberStyles.Any, new CultureInfo("vi-VN"), out decimal balance))
                    {
                        // Định dạng lại thành chuỗi với dấu phân cách hàng nghìn
                        string formattedBalance = balance.ToString("#,##0", new CultureInfo("vi-VN"));
                        txtBalanceCustomerAccountForm.Text = formattedBalance;
                    }

                    // Hiển thị dữ liệu.
                    lbCustomerNameCustomerAccountForm.Text = name;
                    lbCCCDCustomerAccountForm.Text = cccd;
                    txtDateOfBirthCustomerAccountForm.Text = dateOfBirth;
                    txtGenderCustomerAccountForm.Text = gender;
                    txtEmailCustomerAccountForm.Text = email;
                    txtAddressCustomerAccountForm.Text = address;
                    txtAccountNumberCustomerAccountForm.Text = account_number;
                    txtOpenDateCustomerAccountForm.Text = date_opened;
                    txtUsernameCustomerAccountForm.Text = username;
                    
                    

                    try
                    {
                        if (photo != "")
                        {
                            imgCustomerCustomerAccountForm.Image = Image.FromFile(photo);
                        }
                        else
                        {
                            imgCustomerCustomerAccountForm.Image = Image.FromFile("..\\..\\Image\\CustomerImage\\img_customer_default.png");
                        }
                    }
                    catch (Exception ex)
                    {
                        // Nếu có lỗi xảy ra, sử dụng hình ảnh mặc định
                        imgCustomerCustomerAccountForm.Image = Image.FromFile("..\\..\\Image\\CustomerImage\\img_customer_default.png");

                        // Bạn có thể log hoặc xử lý lỗi nếu cần thiết
                        Console.WriteLine(ex.Message);
                    }
                    checkStatusCustomerInfor(customerStatus);
                    checkStatusCustomerAccount(accountstatus);
                    checkActive();
                }
            }
        }
        //Cập nhật customerStatus View
        private void checkStatusCustomerInfor(string status)
        {
            if (status == "Active")
            {
                imgCustomerInfStatusCustomerAccountForm.Image = Image.FromFile("..\\..\\Resources\\checked.png");
                lbCustomerInfStatusCustomerAccountForm.Text = status;
                lbCustomerInfStatusCustomerAccountForm.ForeColor = Color.FromArgb(78, 167, 46);
            }
            else
            {
                imgCustomerInfStatusCustomerAccountForm.Image = Image.FromFile("..\\..\\Resources\\x-button.png");
                lbCustomerInfStatusCustomerAccountForm.Text = status;
                lbCustomerInfStatusCustomerAccountForm.ForeColor = Color.FromArgb(203, 57, 53);
            }
        }
        //Cập nhật customerAccountStatus View
        private void checkStatusCustomerAccount(string status)
        {
            if (status == "Active")
            {
                imgAccountStatusCustomerAccountForm.Image = Image.FromFile("..\\..\\Resources\\checked.png");
                lbAccountStatusCustomerAccountForm.Text = status;
                lbAccountStatusCustomerAccountForm.ForeColor = Color.FromArgb(78, 167, 46);
            }
            else
            {
                imgAccountStatusCustomerAccountForm.Image = Image.FromFile("..\\..\\Resources\\x-button.png");
                lbAccountStatusCustomerAccountForm.Text = status;
                lbAccountStatusCustomerAccountForm.ForeColor = Color.FromArgb(203, 57, 53);
            }
        }
        //Kiếm tra trạng thái của tài khoản, nếu đã Active thì ẩn btnActive
        private void checkActive()
        {
            if (lbAccountStatusCustomerAccountForm.Text == "Active")
            {
                btnActiveCustomerAccountForm.Visible = false;
            }
            else
            {
                btnActiveCustomerAccountForm.Visible = true;
            }
        }





        //Load thông tin tất cả các khách hàng và tài khoản tương ứng--------------------------------------------------------------------------------------------------------------------------------------------
        private void LoadAllAccount()
        {
            viewModel.LoadAllCustomerAccount();
            this.updateDataGridView(viewModel.DataTableAccountInfor);
        }
        




        //Cập nhật các thuộc tính của viewModel từ Form-----------------------------------------------------------------------------------------------------------------------------
        private void updateViewModelFromForm()
        {
            if (int.TryParse(txtAccountNumberCustomerAccountForm.Text, out int accountNumber))
            {
                viewModel.Account_number = accountNumber;
            }
            viewModel.StaffId = staffId;
            viewModel.Username = txtUsernameCustomerAccountForm.Text;
            viewModel.Date_opened = DateTime.Parse(txtDateOfBirthCustomerAccountForm.Text);
            viewModel.Balance = Decimal.Parse(txtBalanceCustomerAccountForm.Text, new CultureInfo("vi-VN"));
        }





        //Cập nhật DataGridView------------------------------------------------------------------------------------------------------------------------------------------------
        private void updateDataGridView(DataTable dt)
        {
            foreach (DataRow row in dt.Rows)
            {
                int id = Convert.ToInt32(row["id"]);
                string cccd = row["cccd"].ToString();
                string name = row["name"].ToString();
                string gender = row["gender"].ToString();
                string username = row["username"].ToString();
                int account_number = Convert.ToInt32(row["account_number"]);
                string account_status = row["account_status"].ToString();
                string customer_status = row["status"].ToString();
                DateTime dateOfBirth = DateTime.Parse(row["date_of_birth"].ToString());
                string formattedDateOfBirth = dateOfBirth.ToString("dd/MM/yyyy");
                string address = row["address"].ToString();
                string photo = row["photo"].ToString();
                string email = row["email"].ToString();
                DateTime date_opened = DateTime.Parse(row["date_opened"].ToString());
                string formattedDateOpened = date_opened.ToString("dd/MM/yyyy");
                Decimal balance = Decimal.Parse(row["balance"].ToString(), new CultureInfo("vi-VN"));
                dataGridViewCustomerAccountForm.Rows.Add(id, cccd, name, gender, account_number, username, account_status, formattedDateOfBirth, address, email, photo, customer_status, formattedDateOpened, balance);
            }
        }
    }
}
