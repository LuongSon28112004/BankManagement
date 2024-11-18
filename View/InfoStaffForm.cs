using BankManagement.Language;
using BankManagement.Model;
using BankManagement.View;
using BankManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;

namespace BankManagement
{
    public partial class InfoStaffForm : Form
    {
        private int staffId;
        private InfoStaffViewModel viewModel;
        public InfoStaffForm(int staffId)
        {
            InitializeComponent();
            this.staffId = staffId; //Nhận dữ liệu từ Main

            this.ShowInTaskbar = false; // Ẩn form khỏi thanh taskbar 
            this.Deactivate += new EventHandler(InfoStaff_Deactivate); // Đăng ký sự kiện Deactivate để đóng form khi mất focus

            viewModel = new InfoStaffViewModel();
		}



        //Cập nhật dữ liệu form
		private void InfoStaff_Load(object sender, EventArgs e)
		{
            viewModel.LoadInfoStaff(this.staffId);

            //Cập nhật các thuộc tính bind với form
            lbStaffNameInfoStaffForm.Text = viewModel.GetStaffName();
            lbUserNameInfoStaffForm.Text = viewModel.GetUserName();
            lbBranchInfoStaffForm.Text = LangHelper.Instance.GetString("Branch") + ": " + viewModel.GetWorkingBranch();
            lbJobPositionInfoStaffForm.Text = LangHelper.Instance.GetString("Position") + ": " + viewModel.GetJobPosition();
            btnLogOutInfoStaffForm.Text = LangHelper.Instance.GetString("Log out");


			// Cập nhật ảnh của PictureBox từ file
			try
			{
				// Lấy đường dẫn ảnh từ viewModel
				string photoPath = viewModel.GetPhotoPath(); 


                if (File.Exists(photoPath))
                {
                    imgStaffAvatarInfoStaffForm.ImageLocation = $@"{photoPath}";
				}
				else
				{
                    CustomMessageBox.ShowBox(LangHelper.Instance.GetString("Error image file not found!"), "Error");
                }
			}
			catch (Exception ex)
			{
                CustomMessageBox.ShowBox("Error: " + ex.Message, "Error");
            }
		}




		//Hàm xử lý sự kiện Deactivate
		private void InfoStaff_Deactivate(object sender, EventArgs e)
        {
            this.Close(); //Đóng form khi mất tiêu điểm
        }



        //Xử lí sự kiện logout
        private void btnLogOutInfoStaffForm_Click(object sender, EventArgs e)
        {
            // Đóng tất cả các form đang mở
            foreach (Form form in Application.OpenForms.Cast<Form>().ToList())
            {
                form.Close(); // Đóng từng form
            }

            // Khởi động lại ứng dụng
            RestartApplication();
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
