using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankManagement.View
{
    public partial class FeedbackForm : Form
    {
        public FeedbackForm()
        {
            InitializeComponent();
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

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture(); //Nếu không có hàm này thì mọi sự kiện chuột ("kéo thả") vẫn sẽ được gửi đến title bar
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0); //Gửi thông điệp đến hđh để bắt đầu di chuyển form
        }



        //Đóng form
        private void btnCloseFeedbackForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        //Sự kiện ratting
        private void btnStarFeedbackForm_Click(object sender, EventArgs e)
        {
            // Ép kiểu sender về Button
            Guna.UI2.WinForms.Guna2Button clickedButton = sender as Guna.UI2.WinForms.Guna2Button;
            int n = int.Parse(clickedButton.Name[7].ToString());

            for (int i = 1; i < n + 1; i++)
            {
                // Tạo tên button động
                string buttonName = $"btnStar{i}FeedbackForm";

                // Tìm button theo tên
                var button = this.Controls.Find(buttonName, true).FirstOrDefault() as Guna.UI2.WinForms.Guna2Button;

                // Kiểm tra nếu tìm thấy button
                if (button != null)
                {
                    // Thay đổi hình ảnh của button
                    button.Image = Image.FromFile("..\\..\\Resources\\star_yellow.png");
                }
            }
            for (int i = n + 1; i < 6; i++)
            {
                // Tạo tên button động
                string buttonName = $"btnStar{i}FeedbackForm";

                // Tìm button theo tên
                var button = this.Controls.Find(buttonName, true).FirstOrDefault() as Guna.UI2.WinForms.Guna2Button;

                // Kiểm tra nếu tìm thấy button
                if (button != null)
                {
                    // Thay đổi hình ảnh của button
                    button.Image = Image.FromFile("..\\..\\Resources\\star_white.png");
                }
            }
        }
    }
}
