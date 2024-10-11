using BankManagement.Model;
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
    public partial class CustomerAccountForm : Form
    {
        // format account
        const int ACCOUNT_NUMBER = 101000000;
        AccountViewModel viewModel;
        bool foundCustomerInfor;
        int customer_id;
        public CustomerAccountForm()
        {
            InitializeComponent();
            foundCustomerInfor = false;
            viewModel = new AccountViewModel();
            this.reset();
            this.ShowInTaskbar = false; //Ẩn khỏi thanh taskbar
        }

        private void CustomerAccountForm_Load(object sender, EventArgs e)
        {
            //Đăng ký sự kiện ScrollBar vertical của dataGridView
            dataGridViewCustomerAccountForm.MouseWheel += dataGridViewCustomerAccountForm_MouseWheel;
        }






        //Sự kiện sử dụng con lăn chuột để kéo dataGridView--------------------------------------------------------------------------------------------
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

        //search accountnumber , hiển thị thông tin của các tài khoản nếu nó có các thành phần giống nhau
        private void btnSearchByAccountNumberCustomerAccountForm_Click(object sender, EventArgs e)
        {
            if (txtSearchAccountNumberAccountCustomerForm.Text == "") return;
            viewModel.searchCustomerAccountByAccountNumber(Convert.ToInt32(txtSearchAccountNumberAccountCustomerForm.Text));

            dataGridViewCustomerAccountForm.Rows.Clear();

            this.updateDataGridView(viewModel.DataTableAccountInfor);
        }

        //search customerinfor và hiển thị thông tin khi chỉ có một khách hàng được tìm thấy
        private void btnSearchByCCCDCustomerAccountForm_Click(object sender, EventArgs e)
        {
            viewModel.searchCustomerInforByCccd(txtSearchByCCCDCustomerAccountForm.Text);
            if (viewModel.DataTableCustomerInfor.Rows.Count != 1) return;
            this.updateCustomerInfor(viewModel.DataTableCustomerInfor);
        }

        
        //thêm một tài khoản vào ngân hàng
        private void btnAddCustomerAccountForm_Click(object sender, EventArgs e)
        {
            if(lbCustomerInfStatusCustomerAccountForm.Text == "Inactive")
            {
                MessageBox.Show("khách hàng này không còn tồn tại trong hệ thống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (foundCustomerInfor)
            {
                this.updateViewModelFromForm();
                if(txtUsernameCustomerAccountForm.Text == "")
                {
                    MessageBox.Show("vui lòng điền tên username", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                viewModel.AddCustomerAccount(customer_id);
                //Thay thế tất cả các dữ liệu trong datagridview
                dataGridViewCustomerAccountForm.Rows.Clear();
                this.LoadAllAccount();
                this.updateAccountNumber();
            }
        }
        
        // reset tất cả các textbox
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
            if (Decimal.Parse(txtBalanceCustomerAccountForm.Text) != 0)
            {
                MessageBox.Show("Tài Khoản này vẫn còn tiền vui lòng rút hết tiền trước khi xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.updateViewModelFromForm();
            viewModel.deleteCustomerAccount();

            //Thay thế tất cả các dữ liệu trong datagridview
            dataGridViewCustomerAccountForm.Rows.Clear();
            this.LoadAllAccount();

        }


        //mothod reset
        private void reset()
        {
            this.LoadAllAccount();
            this.updateAccountNumber();
            this.updateDateOpened();
            this.updateBalance();
            txtSearchByCCCDCustomerAccountForm.Text = "";
            lbCustomerNameCustomerAccountForm.Text = "Customer Name";
            lbCCCDCustomerAccountForm.Text = "024xxxxxxxxx";
            txtDateOfBirthCustomerAccountForm.Text = "";
            txtGenderCustomerAccountForm.Text = "";
            txtEmailCustomerAccountForm.Text = "";
            txtAddressCustomerAccountForm.Text = "";
            txtUsernameCustomerAccountForm.Text = "";
            txtSearchAccountNumberAccountCustomerForm.Text = "";
            imgCustomerCustomerAccountForm.Image = Image.FromFile("..\\..\\Image\\CustomerImage\\img_customer_default.png");
        }

        //method update dateopened default
        private void updateDateOpened()
        {
            DateTime today = DateTime.Today;
            string formattedDateOpened = today.ToString("dd/MM/yyyy");
            txtOpenDateCustomerAccountForm.Text = formattedDateOpened;
        }

        //method update accountnumber default is today
        private void updateAccountNumber()
        {
            viewModel.LoadAllCustomerAccount();
            int accountNumber = viewModel.DataTableAccount.Rows.Count + ACCOUNT_NUMBER;
            txtAccountNumberCustomerAccountForm.Text = accountNumber.ToString();
        }

        //method update balance default = 50,00
        private void updateBalance()
        {
            txtBalanceCustomerAccountForm.Text = Decimal.Parse("50,00").ToString();
        }

        // active customerAccount
        private void btnActiveCustomerAccountForm_Click(object sender, EventArgs e)
        {
            this.updateViewModelFromForm();
            viewModel.updateStatusAccountCustomer();

            //Thay thế tất cả các dữ liệu trong datagridview
            dataGridViewCustomerAccountForm.Rows.Clear();
            this.LoadAllAccount();

        }

        //khi chọn vào một hàng trong table thì nó sẽ hiển thị thông tin lên các textbox 
        private void dataGridViewCustomerAccountForm_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem chỉ số hàng hợp lệ
            if (e.RowIndex >= 0)
            {
                // Lấy hàng được chọn
                DataGridViewRow selectedRow = dataGridViewCustomerAccountForm.Rows[e.RowIndex];

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
                    string balance = selectedRow.Cells["Balance"].Value.ToString();

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
                    txtBalanceCustomerAccountForm.Text = balance;
                    

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

       

        //load tất cả các tài khoản
        private void LoadAllAccount()
        {
            viewModel.LoadAllCustomerAccount();
            this.updateDataGridView(viewModel.DataTableAccount);
        }
        
        //update attribute of viewmodel from Form
        private void updateViewModelFromForm()
        {

            viewModel.Account_number = int.Parse(txtAccountNumberCustomerAccountForm.Text);
            viewModel.Username = txtUsernameCustomerAccountForm.Text;
            viewModel.Date_opened = DateTime.Parse(txtDateOfBirthCustomerAccountForm.Text);
            viewModel.Balance = Decimal.Parse(txtBalanceCustomerAccountForm.Text);
        }


        // update dataGridView hiển thị thông tin các account 
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
                Decimal balance = Decimal.Parse(row["balance"].ToString());
                dataGridViewCustomerAccountForm.Rows.Add(id, cccd, name, gender, account_number, username, account_status, formattedDateOfBirth, address, email, photo, customer_status, formattedDateOpened, balance);
            }
        }

        //hiển thị lên các textbox thông tin của customer
        private void updateCustomerInfor(DataTable dt)
        {

            foreach (DataRow row in dt.Rows)
            {
                lbCustomerNameCustomerAccountForm.Text = row["name"].ToString();

                imgCustomerCustomerAccountForm.Image = Image.FromFile($"..\\..\\Image\\CustomerImage\\{row["photo"].ToString()}");
                lbCCCDCustomerAccountForm.Text = row["cccd"].ToString();
                DateTime dateOfBirth = DateTime.Parse(row["date_of_birth"].ToString());
                string formattedDateOfBirth = dateOfBirth.ToString("dd/MM/yyyy");
                txtDateOfBirthCustomerAccountForm.Text = formattedDateOfBirth;
                txtGenderCustomerAccountForm.Text = row["gender"].ToString();
                txtEmailCustomerAccountForm.Text = row["email"].ToString();
                txtAddressCustomerAccountForm.Text = row["address"].ToString();
                this.customer_id = Convert.ToInt32(row["id"]);
                this.checkStatusCustomerInfor(row["status"].ToString());
                foundCustomerInfor = true;
            }

        }

        // set status of customerInfor
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

        //set status of customerAccount
        private void checkStatusCustomerAccount(string status)
        {
            if (status == "active")
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

        //check active of customerAccount
        private void checkActive()
        {
            if (lbAccountStatusCustomerAccountForm.Text == "active")
            {
                btnActiveCustomerAccountForm.Visible = false;
            }
            else
            {
                btnActiveCustomerAccountForm.Visible = true;
            }
        }
    }
}
