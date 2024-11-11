using BankManagement.Language;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Windows.Forms;
using System.Configuration;
using BankManagement.ViewModel;

namespace BankManagement.View
{
    public partial class SettingForm : Form
    {
        private int staffId;
        LangHelper langHelper;
        private SettingViewModel viewModel;

        public SettingForm(int staffId)
        {
            InitializeComponent();
            langHelper = new LangHelper();
            if (WebConfigurationManager.AppSettings["Language"] != "")
            {
                langHelper.ChangeLanguage(WebConfigurationManager.AppSettings["Language"]);
            }
            this.staffId = staffId;
            viewModel = new SettingViewModel();
            this.ShowInTaskbar = false;
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            if (WebConfigurationManager.AppSettings["Language"] == "vi") radVietnamese.Checked = true;
            if (WebConfigurationManager.AppSettings["Language"] == "") radEnglish.Checked = true;
            ChangeLanguage();
            //Lấy ra thông tin nhân viên
            try
            {
                viewModel.GetStaffById(staffId);
                txtStaffName.Text = viewModel.Name;
                txtUsername.Text = viewModel.Username;
                txtPosition.Text = viewModel.Position;
                txtWorkingBranch.Text = viewModel.Branch;
                txtEmail.Text = viewModel.Email;
            }
            catch (Exception ex)
            {
                CustomMessageBox.ShowBox("Error: " + ex.Message, "Error");
            }
        }
        void ChangeLanguage()
        {
            lbMyProfile.Text = langHelper.GetString("My Profile");
            lbUsername.Text = langHelper.GetString("Username");
            lbPosition.Text = langHelper.GetString("Position");
            lbWorkingBranch.Text = langHelper.GetString("Branch");
            lbAccountAndPassword.Text = langHelper.GetString("Account and Password");
            btnChangePassword.Text = langHelper.GetString("Change password");
            lbStopUsing.Text = langHelper.GetString("STOP USING ACCOUNT");
            btnDisableAccount.Text = langHelper.GetString("Disable account");
            btnDeleteAccount.Text = langHelper.GetString("Delete account");
            lbLanguage.Text = langHelper.GetString("Language");
        }

        private void btnCloseMain_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //Đổi sang tiếng việt---------------------------------------------------------------------------------------------------------------------------------------------------
        private void btnVietnamese_Click(object sender, EventArgs e)
        {
            if (WebConfigurationManager.AppSettings["Language"] == "vi") return;
            string btn_id = CustomMessageBox.ShowBox(langHelper.GetString("Restart the app to change the language!"), "Error");
            if (btn_id == "1")
            {
                // Mở tệp cấu hình hiện tại
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None); 

                // Cập nhật giá trị cho `Language`
                config.AppSettings.Settings["Language"].Value = "vi";

                // Lưu thay đổi vào tệp cấu hình
                config.Save(ConfigurationSaveMode.Modified);

                // Yêu cầu tải lại các cài đặt để thay đổi có hiệu lực
                ConfigurationManager.RefreshSection("appSettings");
                // Đóng tất cả các form đang mở
                foreach (Form form in Application.OpenForms.Cast<Form>().ToList())
                {
                    form.Close(); // Đóng từng form
                }

                // Khởi động lại ứng dụng
                RestartApplication();
            }
        }


        //Đổi sang tiếng anh------------------------------------------------------------------------------------------------------------------------------------------------------
        private void btnEnglish_Click(object sender, EventArgs e)
        {
            if (WebConfigurationManager.AppSettings["Language"] == "") return;
            string btn_id = CustomMessageBox.ShowBox(langHelper.GetString("Restart the app to change the language!"), "Error");
            if (btn_id == "1")
            {
                // Mở tệp cấu hình hiện tại
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                // Cập nhật giá trị cho `Language`
                config.AppSettings.Settings["Language"].Value = "";

                // Lưu thay đổi vào tệp cấu hình
                config.Save(ConfigurationSaveMode.Modified);

                // Yêu cầu tải lại các cài đặt để thay đổi có hiệu lực
                ConfigurationManager.RefreshSection("appSettings");
                // Đóng tất cả các form đang mở
                foreach (Form form in Application.OpenForms.Cast<Form>().ToList())
                {
                    form.Close(); // Đóng từng form
                }

                // Khởi động lại ứng dụng
                RestartApplication();
            }
                
        }
        private void RestartApplication()
        {
            // Khởi động lại ứng dụng bằng cách sử dụng lệnh debug của Visual Studio
            System.Diagnostics.Process.Start("cmd.exe", "/C start \"\" \"" + System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName + "\"");

            // Thoát ứng dụng hiện tại
            Application.Exit();
        }


        //Vô hiệu hoá tài khoản
        private void btnDisableAccount_Click(object sender, EventArgs e)
        {
            string btn_id = CustomMessageBox.ShowBox(langHelper.GetString("Are you sure you want to disable your account?"), "Error");
            if (btn_id == "1")
            {
                try
                {
                    viewModel.DisableAccount(staffId);
                    CustomMessageBox.ShowBox(langHelper.GetString("Account disabled successfully!"), "Success");
                    // Khởi động lại ứng dụng
                    RestartApplication();
                }
                catch (Exception ex)
                {
                    CustomMessageBox.ShowBox("Error: " + ex.Message, "Error");
                }
            }
            
        }


        //Đổi mật khẩu
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            ChangePasswordForm changePasswordForm = new ChangePasswordForm(staffId);
            // Đặt vị trí của InfoStaff ngay dưới nút btnStaffAvatar
            changePasswordForm.StartPosition = FormStartPosition.Manual;

            // Lấy tọa độ và điều chỉnh vị trí
            var startPos = new Point(this.Location.X + (this.Width - changePasswordForm.Width) / 2 + 1, this.Location.Y + 36);
            changePasswordForm.Location = startPos;
            changePasswordForm.ShowDialog();
        }
    }
}
