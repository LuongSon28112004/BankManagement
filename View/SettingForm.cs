using BankManagement.Language;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;
using BankManagement.ViewModel;
using System.IO;
using System.Xml;

namespace BankManagement.View
{
    public partial class SettingForm : Form
    {
        private int staffId;
        private SettingViewModel viewModel;

        public SettingForm(int staffId)
        {
            InitializeComponent();
            this.staffId = staffId;
            viewModel = new SettingViewModel();
            this.ShowInTaskbar = false;
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            if (ConfigurationManager.AppSettings["Language"] == "vi") radVietnamese.Checked = true;
            if (ConfigurationManager.AppSettings["Language"] == "") radEnglish.Checked = true;
            ChangeLanguage();
            //Lấy ra thông tin nhân viên
            try
            {
                viewModel.GetStaffById(staffId);
                // Lấy đường dẫn ảnh từ viewModel
                string photoPath = viewModel.Photo;


                if (File.Exists(photoPath))
                {
                    imgStaff.Image = Bitmap.FromFile(photoPath);
                }
                else
                {
                    CustomMessageBox.ShowBox(LangHelper.Instance.GetString("Error image file not found!"), "Error");
                }
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
            lbMyProfile.Text = LangHelper.Instance.GetString("My Profile");
            lbUsername.Text = LangHelper.Instance.GetString("Username");
            lbPosition.Text = LangHelper.Instance.GetString("Position");
            lbWorkingBranch.Text = LangHelper.Instance.GetString("Branch");
            lbAccountAndPassword.Text = LangHelper.Instance.GetString("Account and Password");
            btnChangePassword.Text = LangHelper.Instance.GetString("Change password");
            lbStopUsing.Text = LangHelper.Instance.GetString("STOP USING ACCOUNT");
            btnDisableAccount.Text = LangHelper.Instance.GetString("Disable account");
            btnDeleteAccount.Text = LangHelper.Instance.GetString("Delete account");
            lbLanguage.Text = LangHelper.Instance.GetString("Language");
        }

        private void btnCloseMain_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //Đổi sang tiếng việt---------------------------------------------------------------------------------------------------------------------------------------------------
        private void btnVietnamese_Click(object sender, EventArgs e)
        {
            if (ConfigurationManager.AppSettings["Language"] == "vi") return;
            string btn_id = CustomMessageBox.ShowBox(LangHelper.Instance.GetString("Restart the app to change the language!"), "Error");
            if (btn_id == "1")
            {
                // Mở tệp cấu hình hiện tại
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None); 
                
                // Cập nhật giá trị cho `Language`
                config.AppSettings.Settings["Language"].Value = "vi";

                // Lưu thay đổi vào tệp cấu hình
                config.Save(ConfigurationSaveMode.Modified);
                UpdateAppConfig("Language", "vi");

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
            if (ConfigurationManager.AppSettings["Language"] == "") return;
            string btn_id = CustomMessageBox.ShowBox(LangHelper.Instance.GetString("Restart the app to change the language!"), "Error");
            if (btn_id == "1")
            {
                // Mở tệp cấu hình hiện tại
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                // Cập nhật giá trị cho `Language`
                config.AppSettings.Settings["Language"].Value = "";

                //Lưu thay đổi vào tệp cấu hình
                config.Save(ConfigurationSaveMode.Modified);
                UpdateAppConfig("Language", "");


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
            // Khởi động lại ứng dụng
            System.Diagnostics.Process.Start("cmd.exe", "/C start \"\" \"" + System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName + "\"");

            // Thoát ứng dụng hiện tại
            Application.Exit();
        }



        //Vô hiệu hoá tài khoản
        private void btnDisableAccount_Click(object sender, EventArgs e)
        {
            string btn_id = CustomMessageBox.ShowBox(LangHelper.Instance.GetString("Are you sure you want to disable your account?"), "Error");
            if (btn_id == "1")
            {
                try
                {
                    viewModel.DisableAccount(staffId);
                    CustomMessageBox.ShowBox(LangHelper.Instance.GetString("Account disabled successfully!"), "Success");
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


        private void UpdateAppConfig(string key, string value)
        {
            // Đường dẫn tới file App.config
            string appConfigPath = "..\\..\\App.config"; // Thay đường dẫn bằng chính xác tệp App.config của bạn

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(appConfigPath);

            // Tìm phần tử appSettings
            XmlNode appSettingsNode = xmlDoc.SelectSingleNode("configuration/appSettings");

            if (appSettingsNode != null)
            {
                // Tìm khóa cần cập nhật
                XmlNode settingNode = appSettingsNode.SelectSingleNode($"add[@key='{key}']");

                if (settingNode != null)
                {
                    // Nếu tồn tại, cập nhật giá trị
                    XmlAttribute valueAttribute = settingNode.Attributes["value"];
                    if (valueAttribute != null)
                    {
                        valueAttribute.Value = value;
                    }
                }
                else
                {
                    // Nếu không tồn tại, thêm mới
                    XmlElement newSetting = xmlDoc.CreateElement("add");
                    newSetting.SetAttribute("key", key);
                    newSetting.SetAttribute("value", value);
                    appSettingsNode.AppendChild(newSetting);
                }

                // Lưu lại tệp App.config
                xmlDoc.Save(appConfigPath);
            }
        }
    }
}
