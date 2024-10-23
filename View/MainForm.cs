using BankManagement.View;
using BankManagement.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankManagement
{
    public partial class MainForm : Form
    {
		private int staffId; //Nhận dữ liệu truyền từ LoginForm

		private MainViewModel viewModel;

		public Color initialButtonColor = Color.FromArgb(31, 31, 31); //Màu của các btn không được chọn
		public Color clickedButtonColor = Color.FromArgb(255, 130, 37); //Màu của các btn được chọn

        public MainForm(int staffId)
        {
            InitializeComponent();
            this.Load += Main_Load;

			this.staffId = staffId;//Nhận dữ liệu từ LoginForm
			viewModel = new MainViewModel(); //Hàm tạo ViewModel
		}
		private void Main_Load(object sender, EventArgs e)
		{
			// Lưu trữ kích thước và vị trí ban đầu của form
			normalBounds = this.Bounds;

			//Đổi màu hover
			btnCloseMain.HoverState.FillColor = Color.FromArgb(255, 90, 90); 
			btnStaffAvatarMain.HoverState.FillColor = Color.FromArgb(200, 200, 200);
			btnNotifyMainForm.HoverState.FillColor = Color.FromArgb(100, 100, 100);

			// Gọi trực tiếp phương thức xử lý sự kiện Click của btnCustomer để mặc địch Form CustomerForm được mở khi load MainForm
			btnCustomer_Click(this, EventArgs.Empty);


			//Cập nhật data binding
			viewModel.LoadStaff(staffId);
			lbStaffName.Text = viewModel.GetStaffName(); //Cập nhật tên nhân viên 

			// Cập nhật ảnh của PictureBox từ file
			try
			{
				// Lấy đường dẫn ảnh từ viewModel
				string photoPath = viewModel.GetPhotoPath();


				if (File.Exists(photoPath))
				{
					btnStaffAvatarMain.Image = Bitmap.FromFile(photoPath);
				}
				else
				{
					MessageBox.Show("Không tìm thấy file ảnh.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Có lỗi khi tải ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

        }



		//Hỗ trợ kéo thả khi giữ click vào thanh title -------------------------------------------------------------------------------------------------------------------------
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
		private void panelTitleBarMain_MouseDown(object sender, MouseEventArgs e)
        {
			ReleaseCapture(); //Nếu không có hàm này thì mọi sự kiện chuột ("kéo thả") vẫn sẽ được gửi đến title bar
			SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0); //Gửi thông điệp đến hđh để bắt đầu di chuyển form
		    //End - Hỗ trợ kéo thả khi giữ click vào thanh title



			//Su kien double click vao thanh title
			if (e.Clicks == 2)
            {
                if (isMaximized) //Khi form ở trạng thái phóng to
                {
                    this.Bounds = normalBounds; // Chuyển về kích thước bình thường
                    isMaximized = false; //Cập nhật trạng thái không còn là phóng to
                }
                else
                {
                    // Phóng to cửa sổ
                    normalBounds = this.Bounds; // Lưu lại kích thước bình thường
                    this.Bounds = Screen.PrimaryScreen.WorkingArea; // Phóng to ra toàn màn hình
                    isMaximized = true; //Cập nhật trạng thái không còn là thu nhỏ
                }
            }
        }
        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            // Đặt lại con trỏ về dạng mặc định sau khi kết thúc resize
            this.Cursor = Cursors.Default;
        }





        //Sự kiện click StaffAvatarMain mở ra form thông tin nhân viên---------------------------------------------------------------------------------------------------------
        private void btnStaffAvatarMain_Click(object sender, EventArgs e)
        {
            InfoStaffForm infoStaff = new InfoStaffForm(staffId); //Truyền dữ liệu đến InfoStaffForm
            // Lấy tọa độ và điều chỉnh vị trí
            var buttonScreenPos = btnStaffAvatarMain.PointToScreen(new System.Drawing.Point(-35, btnStaffAvatarMain.Height + 20));

            // Đặt vị trí của InfoStaff ngay dưới nút btnStaffAvatar
            infoStaff.StartPosition = FormStartPosition.Manual;
            infoStaff.Location = buttonScreenPos;

            // Hiển thị InfoStaff
            infoStaff.Show(this);
        }





        //Sự kiện 3 button đóng, phóng to, thu nhỏ ứng dụng-------------------------------------------------------------------------------------------------------------------
        //Các biến trạng thái
        private bool isMaximized = false;
        private Rectangle normalBounds; //Lưu trữ kích thước form
        private void btnClose_Click(object sender, EventArgs e)
		{
			Application.Exit(); //Đóng ứng dụng
		}

		private void btnMinimize_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized; //Thu nhỏ ứng dụng
		}
		private void btnMaximize_Click(object sender, EventArgs e)
		{
			if (isMaximized) //Khi form ở trạng thái phóng to
			{
				this.Bounds = normalBounds; // Chuyển về kích thước bình thường
				isMaximized = false; //Cập nhật trạng thái không còn là phóng to
			}
			else
			{
				// Phóng to cửa sổ
				normalBounds = this.Bounds; // Lưu lại kích thước bình thường
				this.Bounds = Screen.PrimaryScreen.WorkingArea; // Phóng to ra toàn màn hình
				isMaximized = true; //Cập nhật trạng thái không còn là thu nhỏ
			}
		}





        //Sự kiện click btnCustomer-----------------------------------------------------------------------------------------------------------------------------------------------
		private CustomerForm customerForm;
		private void btnCustomer_Click(object sender, EventArgs e)
		{
			btnCustomer.FillColor = clickedButtonColor; //Đổi màu khi click, set màu các btn khác về ban đầu
			btnAccount.FillColor = initialButtonColor;
			btnTransaction.FillColor = initialButtonColor;
            btnLoan.FillColor = initialButtonColor;

            //Mở form CustomerForm
            if (customerForm == null || customerForm.IsDisposed) // Kiểm tra nếu form chưa được khởi tạo hoặc đã bị đóng
			{
				customerForm = new CustomerForm(this.staffId);
				customerForm.StartPosition = FormStartPosition.Manual;
                customerForm.Height = this.Height - 63; //Chỉnh độ cao của form CustomerForm
				customerForm.Width = this.Width - panelLeftBarMain.Width - 3;
                customerForm.Location = new Point(this.Location.X + panelLeftBarMain.Width + (this.Width - panelLeftBarMain.Width - customerForm.Width) / 2, this.Location.Y + 60);
				customerForm.Show(this);
			}
			else
			{
				// Nếu form đã mở, chỉ cần kích hoạt và đưa nó lên trên cùng
				customerForm.BringToFront();
				customerForm.Activate();
			}


			//Đóng các form khác
			if (customerAccountForm != null && !customerAccountForm.IsDisposed)
			{
                customerAccountForm.Close();
            }
            if (transactionForm != null && !transactionForm.IsDisposed)
            {
                transactionForm.Close();
            }

        }





		//Sự kiện click btnAccount-------------------------------------------------------------------------------------------------------------------------------------------------
		private CustomerAccountForm customerAccountForm;
		private void btnAccount_Click(object sender, EventArgs e)
        {
			btnCustomer.FillColor = initialButtonColor;
            btnAccount.FillColor = clickedButtonColor; //Đổi màu khi click, set màu các btn khác về ban đầu
            btnTransaction.FillColor = initialButtonColor;
            btnLoan.FillColor = initialButtonColor;


            //Mở form CustomerAccountForm
            if (customerAccountForm == null || customerAccountForm.IsDisposed) // Kiểm tra nếu form chưa được khởi tạo hoặc đã bị đóng
            {
                customerAccountForm = new CustomerAccountForm(staffId);
                customerAccountForm.StartPosition = FormStartPosition.Manual;
                customerAccountForm.Height = this.Height - 63; //Chỉnh độ cao của form CustomerAccountForm
                customerAccountForm.Width = this.Width - panelLeftBarMain.Width - 3;
                customerAccountForm.Location = new Point(this.Location.X + panelLeftBarMain.Width + (this.Width - panelLeftBarMain.Width - customerAccountForm.Width) / 2, this.Location.Y + 60);
                customerAccountForm.Show(this);
            }
            else
            {
                // Nếu form đã mở, chỉ cần kích hoạt và đưa nó lên trên cùng
                customerAccountForm.BringToFront();
                customerAccountForm.Activate();
            }


            //Đóng các form khác
            if (customerForm != null && !customerForm.IsDisposed)
            {
                customerForm.Close();
            }
            if (transactionForm != null && !transactionForm.IsDisposed)
            {
                transactionForm.Close();
            }
        }





        //Sự kiện click btnTransaction---------------------------------------------------------------------------------------------------------------------------------------------
        private TransactionForm transactionForm;
        private void btnTransaction_Click(object sender, EventArgs e)
        {
			btnCustomer.FillColor = initialButtonColor;
            btnAccount.FillColor = initialButtonColor;
            btnTransaction.FillColor = clickedButtonColor; //Đổi màu khi click, set màu các btn khác về ban đầu
            btnLoan.FillColor = initialButtonColor;

            //Mở form CustomerAccountForm
            if (transactionForm == null || transactionForm.IsDisposed) // Kiểm tra nếu form chưa được khởi tạo hoặc đã bị đóng
            {
                transactionForm = new TransactionForm(staffId);
                transactionForm.StartPosition = FormStartPosition.Manual;
                transactionForm.Height = this.Height - 63; //Chỉnh độ cao của form CustomerAccountForm
                transactionForm.Width = this.Width - panelLeftBarMain.Width - 3;
                transactionForm.Location = new Point(this.Location.X + panelLeftBarMain.Width + (this.Width - panelLeftBarMain.Width - transactionForm.Width) / 2, this.Location.Y + 60);
                transactionForm.Show(this);
            }
            else
            {
                // Nếu form đã mở, chỉ cần kích hoạt và đưa nó lên trên cùng
                transactionForm.BringToFront();
                transactionForm.Activate();
            }

            //Đóng các form khác
            if (customerAccountForm != null && !customerAccountForm.IsDisposed)
            {
                customerAccountForm.Close();
            }
            if (customerForm != null && !customerForm.IsDisposed)
            {
                customerForm.Close();
            }
        }





		//Sự kiện click btn Loan---------------------------------------------------------------------------------------------------------------------------------------------------
        private void btnLoan_Click(object sender, EventArgs e)
        {
			btnCustomer.FillColor = initialButtonColor;
            btnAccount.FillColor = initialButtonColor;
            btnTransaction.FillColor = initialButtonColor;
            btnLoan.FillColor = clickedButtonColor; //Đổi màu khi click, set màu các btn khác về ban đầu

            //Đóng các form khác
            if (customerAccountForm != null && !customerAccountForm.IsDisposed)
            {
                customerAccountForm.Close();
            }
            if (customerForm != null && !customerForm.IsDisposed)
            {
                customerForm.Close();
            }
            if (transactionForm != null && !transactionForm.IsDisposed)
            {
                transactionForm.Close();
            }
        }



		



		//Cập nhật trạng thái của các form con: resize, location change...
		private void Main_LocationChanged(object sender, EventArgs e) //Cập nhật form con khi di chuyển form
		{
            panelLeftBarMain.Width = 200 + (this.Width - 999 - 200) / 4;
            UpdateCustomerFormSizeAndPosition(); //Cập nhật CustomerForm
			UpdateCustomerAccountFormSizeAndPosition(); //Cập nhật CustomerAccountForm
            UpdateTransactionFormSizeAndPosition(); //Cập nhật TransactionForm


        }

		private void Main_Resize(object sender, EventArgs e) //Cập nhật form con khi resize
		{
            panelLeftBarMain.Width = 200 + (this.Width - 999 - 200) / 4;
            UpdateCustomerFormSizeAndPosition(); //Cập nhật CustomerForm
			UpdateCustomerAccountFormSizeAndPosition(); //Cập nhật CustomerAccountForm
            UpdateTransactionFormSizeAndPosition(); //Cập nhật TransactionForm
        }





        //Hàm cập nhật trạng thái CustomerForm
        private void UpdateCustomerFormSizeAndPosition()
		{
			if (customerForm != null && !customerForm.IsDisposed)
			{
                //customerForm.Size = new Size(this.Width - 210, this.Height - 63);
                // Đặt vị trí của Form con và chỉnh size
                customerForm.Height = this.Height - 63; //Chỉnh độ cao của form CustomerForm
                customerForm.Width = this.Width - panelLeftBarMain.Width - 3;
                customerForm.Location = new Point(this.Location.X + panelLeftBarMain.Width + (this.Width - panelLeftBarMain.Width - customerForm.Width) / 2, this.Location.Y + 60);
			}
		}





        //Hàm cập nhật trạng thái CustomerForm
        private void UpdateCustomerAccountFormSizeAndPosition()
        {
            if (customerAccountForm != null && !customerAccountForm.IsDisposed)
            {
                // Đặt vị trí của Form con và chỉnh size
                customerAccountForm.Height = this.Height - 63; //Chỉnh độ cao của form CustomerForm
                customerAccountForm.Width = this.Width - panelLeftBarMain.Width - 3;
                customerAccountForm.Location = new Point(this.Location.X + panelLeftBarMain.Width + (this.Width - panelLeftBarMain.Width - customerAccountForm.Width) / 2, this.Location.Y + 60);
            }
        }





        //Hàm cập nhật trạng thái TransactionForm
        private void UpdateTransactionFormSizeAndPosition()
        {
            if (transactionForm != null && !transactionForm.IsDisposed)
            {
                // Đặt vị trí của Form con và chỉnh size
                transactionForm.Height = this.Height - 63; //Chỉnh độ cao của form CustomerForm
                transactionForm.Width = this.Width - panelLeftBarMain.Width - 3;
                transactionForm.Location = new Point(this.Location.X + panelLeftBarMain.Width + (this.Width - panelLeftBarMain.Width - transactionForm.Width) / 2, this.Location.Y + 60);
            }
        }






        private void btnNotifyMain_Click(object sender, EventArgs e)
        {

        }

        private void panelTitleBarMain_MouseEnter(object sender, EventArgs e)
        {
			this.Cursor = Cursors.Default;
        }





        //Hiển thị LogForm-----------------------------------------------------------------------------------------------------------------------------------------------------------------
        private LogForm logForm;
        private void btnLogMainForm_Click(object sender, EventArgs e)
        {
            //Mở form CustomerForm
            if (logForm == null || logForm.IsDisposed) // Kiểm tra nếu form chưa được khởi tạo hoặc đã bị đóng
            {
                logForm = new LogForm(this.staffId);
                // Đặt vị trí của InfoStaff ngay dưới nút btnStaffAvatar
                logForm.StartPosition = FormStartPosition.Manual;

                // Lấy tọa độ và điều chỉnh vị trí
                var startPos = btnLogMainForm.PointToScreen(new System.Drawing.Point(50, btnLogMainForm.Height - 343));
                logForm.Location = startPos;
                logForm.Show();
            }
            else
            {
                UpdateLogFormSizeAndPosition();
                logForm.UpdateFlowPanel();
                logForm.Show();
            }
        }
        private void UpdateLogFormSizeAndPosition()
        {
            if (logForm != null && !logForm.IsDisposed)
            {
                // Lấy tọa độ và điều chỉnh vị trí
                var startPos = btnLogMainForm.PointToScreen(new System.Drawing.Point(50, btnLogMainForm.Height - 343));
                logForm.Location = new Point(startPos.X, startPos.Y);
            }
        }





        //Hiển thị FeedbackForm-----------------------------------------------------------------------------------------------------------------------------------------------------------------
        FeedbackForm feedbackForm;
        private void btnFeedbackMain_Click(object sender, EventArgs e)
        {
            //Mở form FeedbackForm
            if (feedbackForm == null || feedbackForm.IsDisposed) // Kiểm tra nếu form chưa được khởi tạo hoặc đã bị đóng
            {
                feedbackForm = new FeedbackForm();
                feedbackForm.Show(this);
            }
            else
            {
                // Nếu form đã mở, chỉ cần kích hoạt và đưa nó lên trên cùng
                feedbackForm.BringToFront();
                feedbackForm.Activate();
            }

        }
    }
}
