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

namespace BankManagement.View
{
    public partial class SettingForm : Form
    {
        private int staffId;
        LangHelper langHelper;
        public SettingForm(int staffId)
        {
            InitializeComponent();
            langHelper = new LangHelper();
            if (WebConfigurationManager.AppSettings["Language"] != "")
            {
                langHelper.ChangeLanguage(WebConfigurationManager.AppSettings["Language"]);
            }
            this.staffId = staffId;
            this.ShowInTaskbar = false;
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            if (WebConfigurationManager.AppSettings["Language"] == "vi") radVietnamese.Checked = true;
            if (WebConfigurationManager.AppSettings["Language"] == "") radEnglish.Checked = true;
        }


        private void btnCloseMain_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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
    }
}
