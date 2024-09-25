using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using BankManagement.ViewModel;
using BankManagement.Model;


namespace BankManagement
{
    public partial class LoginForm : Form
    {
		private LoginViewModel viewModel;
		public LoginForm()
        {
            InitializeComponent();
            //this.BackColor = ColorTranslator.FromHtml("#34AB53");
            btnCloseLogin.HoverState.FillColor = Color.FromArgb(255, 90, 90); //Thuộc tính hover btnClose "đỏ"

			viewModel = new LoginViewModel();
        }



		//Btn đóng, thu nhỏ ứng dụng
		private void btnLoginClose_Click(object sender, EventArgs e)
		{
            Application.Exit(); //Đóng ứng dụng
		}

		private void btnLoginMinimize_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;  //Thu nhỏ ứng dụng
		}



        //Begin - Hỗ trợ kéo thả khi giữ click vào thanh title
        public const int WM_NCLBUTTONDOWN = 0xA1; 
        //0xA1 là mã Hex đại diện cho sự kiện khi Windows khi nhấn nút trái chuột vào vùng không chứa title bar

        public const int HT_CAPTION = 0x2; 
        //Tương tự là khi người dùng nhấn vào thanh title bar

        [DllImportAttribute("user32.dll")] 
        //Gọi hàm API từ thư viện user32.dll
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
		//hWnd là một handle ("giống như ID định danh cho một loại tài nguyên, ở đây là form hiện tại)
		//Msg gửi thông điệp WM_NCLBUTTONDOWN (0xA1) là mã để báo hiệu click chuột trái vào title bar
		//wParam, lParam  Là các tham số bổ sung, thường mang thông tin về sự kiện chuột hoặc bàn phím, hoặc các chi tiết khác phụ thuộc vào thông điệp bạn đang gửi

		[DllImportAttribute("user32.dll")] 
        //Mỗi lần import chỉ hoạt động cho một hàm cụ thể nên phải import nhiều lần
        public static extern bool ReleaseCapture();
        //Giải phóng việc bắt giữ chuột từ control hiện tại
        private void PanelTitleBarLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture(); //Nếu không có hàm này thì mọi sự kiện chuột ("kéo thả") vẫn sẽ được gửi đến title bar
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0); //Gửi thông điệp đến hđh để bắt đầu di chuyển form
        }
		//End - Hỗ trợ kéo thả khi giữ click vào thanh title



		//Sự kiện login
		private void btnLogin_Click(object sender, EventArgs e)
        {
			string username = txtUsername.Text; //Lấy username từ TextBox
			string password = txtPassword.Text; //Lấy password từ TextBox

			if (username == "" || password == "")
			{
				lblWarningLogin.Text = "Enter username and password!";
				return;
			}
			try
			{
				viewModel.LoadLogin(username, password); //Thực hiện truy vấn với username và password từ người dùng nhập
				if (viewModel.GetID() != 0) //Nếu có tài khoản này trong csdl đồng nghĩa với việc lấy ra được ID của tk đó
				{
					lblWarningLogin.Text = "";
					MainForm main = new MainForm(Convert.ToInt32(viewModel.GetID())); //Chuẩn bị truyền dữ liệu (ID) cho form Main
					main.Show();
					this.Hide();
				}
				else
				{
					lblWarningLogin.Text = "Wrong username or password!";
				}
			}
			catch (Exception ex)
			{
				// Xử lý lỗi và hiển thị thông báo
				lblWarningLogin.Text = "Lỗi: " + ex.Message;
			}
		}
	}
}
