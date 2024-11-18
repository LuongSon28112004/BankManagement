using BankManagement.Language;
using BankManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;

namespace BankManagement.View
{
    public partial class ChangePasswordForm : Form
    {
        private int staffId;
        ChangePasswordViewModel viewModel;
        public ChangePasswordForm(int staffId)
        {
            InitializeComponent();
            this.staffId = staffId;
            viewModel = new ChangePasswordViewModel();
        }

        private void ChangePasswordForm_Load(object sender, EventArgs e)
        {
            lbWarning.Text = "";
            txtCurrentPassword.Focus();
            ChangeLanguage();
        }
        void ChangeLanguage()
        {
            lbChangePassword.Text = LangHelper.Instance.GetString("Change password");
            lbCurrentPassword.Text = LangHelper.Instance.GetString("Current password");
            lbNewPassword.Text = LangHelper.Instance.GetString("New password");
            lbReType.Text = LangHelper.Instance.GetString("Re-type new password");
            btnConfirm.Text = LangHelper.Instance.GetString("Confirm");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateViewModelFromForm()
        {
            viewModel.StaffId = staffId;
            viewModel.CurrentPassword = txtCurrentPassword.Text;
            viewModel.NewPassword = txtNewPassword.Text;
            viewModel.ReType = txtReType.Text;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtCurrentPassword.Text == "")
            {
                CustomMessageBox.ShowBox(LangHelper.Instance.GetString("Please enter current password!"), "Error");
                txtCurrentPassword.Focus();
                return;
            }
            if (txtNewPassword.Text == "")
            {
                CustomMessageBox.ShowBox(LangHelper.Instance.GetString("Please enter new password!"), "Error");
                txtNewPassword.Focus();
                return;
            }
            if (txtReType.Text == "")
            {
                CustomMessageBox.ShowBox(LangHelper.Instance.GetString("Please re-type new password!"), "Error");
                txtReType.Focus();
                return;
            }
            if (txtNewPassword.Text.Length < 8)
            {
                CustomMessageBox.ShowBox(LangHelper.Instance.GetString("New password must be at least 8 characters!"), "Error");
                txtNewPassword.Focus();
                return;
            }
            if (txtNewPassword.Text != txtReType.Text)
            {
                CustomMessageBox.ShowBox(LangHelper.Instance.GetString("The password does not match!"), "Error");
                txtReType.Focus();
                return;
            }
            if (txtCurrentPassword.Text == txtNewPassword.Text)
            {
                CustomMessageBox.ShowBox(LangHelper.Instance.GetString("New password duplicates old password!"), "Error");
                txtNewPassword.Focus();
                return;
            }
            try
            {

                this.UpdateViewModelFromForm();
                if (viewModel.ChangePassword())
                {
                    CustomMessageBox.ShowBox(LangHelper.Instance.GetString("Password changed successfully!"), "Success");
                    // Đóng tất cả các form đang mở
                    foreach (Form form in Application.OpenForms.Cast<Form>().ToList())
                    {
                        form.Close(); // Đóng từng form
                    }

                    // Khởi động lại ứng dụng
                    RestartApplication();
                }
            }
            catch (Exception ex)
            {
                CustomMessageBox.ShowBox("Error: " + ex.Message, "Error");
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
