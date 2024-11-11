using BankManagement.Language;
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
using System.Web.Configuration;
using System.Windows.Forms;

using Excel = Microsoft.Office.Interop.Excel;

namespace BankManagement.View
{
    public partial class CustomerAccountForm : Form
    {
        LangHelper langHelper;
        AccountViewModel viewModel;
        private int staffId;
        private int accountCustomerId;

        public CustomerAccountForm(int staffId)
        {
            InitializeComponent();
            langHelper = new LangHelper();
            if (WebConfigurationManager.AppSettings["Language"] != "")
            {
                langHelper.ChangeLanguage(WebConfigurationManager.AppSettings["Language"]);
            }
            viewModel = new AccountViewModel();
            this.reset();
            this.ShowInTaskbar = false; //Ẩn khỏi thanh taskbar
            this.staffId = staffId;
        }


        private void CustomerAccountForm_Load(object sender, EventArgs e)
        {
            //Đăng ký sự kiện ScrollBar vertical của dataGridView
            dataGridViewCustomerAccountForm.MouseWheel += dataGridViewCustomerAccountForm_MouseWheel;
            ChangeLanguage();
        }




        //Thay đổi ngôn ngữ------------------------------------------------------------------------------------------------------------------------------------------------
        void ChangeLanguage()
        {
            lbCustomerAccountCustomerAccountForm.Text = langHelper.GetString("Customer Account");
            txtSearchByCCCDCustomerAccountForm.PlaceholderText = langHelper.GetString("Search by CCCD");
            btnSearchByCCCDCustomerAccountForm.Text = langHelper.GetString("Search");
            lbCustomerNameCustomerAccountForm.Text = langHelper.GetString("Customer Name");
            lbDateOfBirthCustomerAccountForm.Text = langHelper.GetString("Date of birth");
            lbAddressCustomerAccountForm.Text = langHelper.GetString("Address");
            txtAddressCustomerAccountForm.PlaceholderText = langHelper.GetString("Ward - District - City");
            lbAccountNumberCustomerAccountForm.Text = langHelper.GetString("Account Number");
            lbOpenDateCustomerAccountForm.Text = langHelper.GetString("Open date");
            lbUsernameCustomerAccountForm.Text = langHelper.GetString("Username");
            txtUsernameCustomerAccountForm.PlaceholderText = langHelper.GetString("Customise");
            lbBalanceCustomerAccountForm.Text = langHelper.GetString("Balance");
            btnActiveCustomerAccountForm.Text = langHelper.GetString("Active");
            btnStatementCustomerAccountForm.Text = langHelper.GetString("Statement");
            btnAddCustomerAccountForm.Text = langHelper.GetString("Add");
            btnDeleteCustomerAccountForm.Text = langHelper.GetString("Delete");
            btnSearchByAccountNumberCustomerAccountForm.Text = langHelper.GetString("Search");
            txtSearchAccountNumberAccountCustomerForm.PlaceholderText = langHelper.GetString("Account Number");
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
            if (txtSearchAccountNumberAccountCustomerForm.Text == "") return;
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
                CustomMessageBox.ShowBox("Error: " + ex.Message, "Error");
            } 
        }





        //Tìm kiếm thông tin khách hàng bằng CCCD và cập nhật Panel chứa thông tin khách hàng-----------------------------------------------------------------
        private void btnSearchByCCCDCustomerAccountForm_Click(object sender, EventArgs e)
        {
            if (txtSearchByCCCDCustomerAccountForm.Text == "") return;
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

            this.accountCustomerId = int.Parse(row["id"].ToString());
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
                CustomMessageBox.ShowBox(langHelper.GetString("Please fill in all information!"), "Error"); 
                return;
            }
            //Khi khách hàng không còn tồn tại trong hệ thống
            if (lbCustomerInfStatusCustomerAccountForm.Text == "Inactive") 
            {
                CustomMessageBox.ShowBox(langHelper.GetString("This customer no longer exists in the system!"), "Error");
                return;
            }

            this.updateViewModelFromForm();
            if(txtUsernameCustomerAccountForm.Text == "")
            {
                CustomMessageBox.ShowBox(langHelper.GetString("Please enter username!"), "Error");
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
                CustomMessageBox.ShowBox("Error: " + ex.Message, "Error");
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
                CustomMessageBox.ShowBox(langHelper.GetString("Please select the account to delete!"), "Error");
                return;
            }    
            if (lbAccountStatusCustomerAccountForm.Text == "Inactive")
            {
                CustomMessageBox.ShowBox(langHelper.GetString("This account has been deleted!"), "Error");
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
                CustomMessageBox.ShowBox("Error: " + ex.Message, "Error");
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
            lbCustomerNameCustomerAccountForm.Text = langHelper.GetString("Customer Name");
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
                CustomMessageBox.ShowBox(langHelper.GetString("Please select an account!"), "Error");
                return;
            }
            if (lbCustomerInfStatusCustomerAccountForm.Text == "Inactive")
            {
                CustomMessageBox.ShowBox(langHelper.GetString("This account cannot be activated because the customer is no longer active!"), "Error");
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
                CustomMessageBox.ShowBox("Error: " + ex.Message, "Error");
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
                    //lay thong tin id account
                    this.accountCustomerId = int.Parse(selectedRow.Cells["accountId"].Value.ToString());
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
            //viewModel.LoadAllCustomerAccount();
            //this.updateDataGridView(viewModel.DataTableAccountInfor);
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

        private void txtSearchByCCCDCustomerAccountForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra xem ký tự nhập vào có phải là chữ số hay không
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Ngăn các ký tự không phải là chữ số
                e.Handled = true;
            }
        }

        private void BtnStatementCustomerAccountForm_Click(object sender, EventArgs e)
        {
            if(lbCustomerNameCustomerAccountForm.Text == langHelper.GetString("Customer Name"))
            {
                CustomMessageBox.ShowBox(langHelper.GetString("Please select the account you want to statement!") , "Error");
                return;
            }
            viewModel.getAllTransferByIdAccount(this.accountCustomerId);
            viewModel.getAllDepositByIdAccount(this.accountCustomerId);
            viewModel.getAllWithDrawByIdAccount(this.accountCustomerId);
            this.ExportToExcel(viewModel.DataTableAllTransfer,viewModel.DatatableAllDeposit,viewModel.DatatableAllWithdraw);
        }

        private void ExportToExcel(DataTable transfer, DataTable deposit, DataTable withdraw)
        {
            // Khởi tạo ứng dụng Excel
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Add(Type.Missing);
            Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];

            // Thiết lập thông tin tiêu đề chung
            Excel.Range titleRange = worksheet.Range["A1", "F1"];
            titleRange.Merge();
            titleRange.Value = "Lịch Sử Giao Dịch Của Khách Hàng";
            titleRange.Font.Bold = true;
            titleRange.Font.Size = 18;
            titleRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            titleRange.Interior.Color = Excel.XlRgbColor.rgbLightSteelBlue;

            // Thêm tiêu đề "Lịch Sử Chuyển Tiền"
            Excel.Range titleTransfer = worksheet.Range["A2", "F2"];
            titleTransfer.Merge();
            titleTransfer.Value = "Lịch Sử Chuyển Tiền";
            titleTransfer.Font.Bold = true;
            titleTransfer.Font.Size = 16;

            // Thêm tiêu đề cột cho bảng transfer
            for (int i = 0; i < transfer.Columns.Count; i++)
            {
                worksheet.Cells[3, i + 1] = transfer.Columns[i].ColumnName;
                Excel.Range cell = (Excel.Range)worksheet.Cells[3, i + 1];
                cell.Font.Bold = true;
                cell.Interior.Color = Excel.XlRgbColor.rgbLightGray;
                cell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                cell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            }

            // Thêm dữ liệu từ bảng transfer
            int currentRow = 4;
            for (int k = 0; k < transfer.Rows.Count; k++)
            {
                for (int j = 0; j < transfer.Columns.Count; j++)
                {
                    Excel.Range cell = (Excel.Range)worksheet.Cells[currentRow, j + 1];
                    cell.Value = transfer.Rows[k][j]?.ToString() ?? "";
                    cell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    cell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                }
                currentRow++;
            }

            // Thêm tiêu đề "Lịch Sử Nạp Tiền"
            Excel.Range titleDeposit = worksheet.Range[$"A{currentRow + 1}", $"F{currentRow + 1}"];
            titleDeposit.Merge();
            titleDeposit.Value = "Lịch Sử Nạp Tiền";
            titleDeposit.Font.Bold = true;
            titleDeposit.Font.Size = 16;

            // Thêm tiêu đề cột cho bảng deposit
            currentRow += 2;
            for (int i = 0; i < deposit.Columns.Count; i++)
            {
                worksheet.Cells[currentRow, i + 1] = deposit.Columns[i].ColumnName;
                Excel.Range cell = (Excel.Range)worksheet.Cells[currentRow, i + 1];
                cell.Font.Bold = true;
                cell.Interior.Color = Excel.XlRgbColor.rgbLightGray;
                cell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                cell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            }

            // Thêm dữ liệu từ bảng deposit
            currentRow++;
            for (int k = 0; k < deposit.Rows.Count; k++)
            {
                for (int j = 0; j < deposit.Columns.Count; j++)
                {
                    Excel.Range cell = (Excel.Range)worksheet.Cells[currentRow, j + 1];
                    cell.Value = deposit.Rows[k][j]?.ToString() ?? "";
                    cell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    cell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                }
                currentRow++;
            }

            // Thêm tiêu đề "Lịch Sử Rút Tiền"
            Excel.Range titleWithdraw = worksheet.Range[$"A{currentRow + 1}", $"F{currentRow + 1}"];
            titleWithdraw.Merge();
            titleWithdraw.Value = "Lịch Sử Rút Tiền";
            titleWithdraw.Font.Bold = true;
            titleWithdraw.Font.Size = 16;

            // Thêm tiêu đề cột cho bảng withdraw
            currentRow += 2;
            for (int i = 0; i < withdraw.Columns.Count; i++)
            {
                worksheet.Cells[currentRow, i + 1] = withdraw.Columns[i].ColumnName;
                Excel.Range cell = (Excel.Range)worksheet.Cells[currentRow, i + 1];
                cell.Font.Bold = true;
                cell.Interior.Color = Excel.XlRgbColor.rgbLightGray;
                cell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                cell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            }

            // Thêm dữ liệu từ bảng withdraw
            currentRow++;
            for (int k = 0; k < withdraw.Rows.Count; k++)
            {
                for (int j = 0; j < withdraw.Columns.Count; j++)
                {
                    Excel.Range cell = (Excel.Range)worksheet.Cells[currentRow, j + 1];
                    cell.Value = withdraw.Rows[k][j]?.ToString() ?? "";
                    cell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    cell.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                }
                currentRow++;
            }

            // Căn chỉnh cột và tự động điều chỉnh kích thước
            worksheet.Columns.AutoFit();

            // Hiển thị Excel
            excelApp.Visible = true;

            // Giải phóng tài nguyên
            System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

            GC.Collect();
        }

        private void imgCustomerCustomerAccountForm_Click(object sender, EventArgs e)
        {

        }
    }
}
