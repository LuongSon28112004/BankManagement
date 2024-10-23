using Guna.UI2.WinForms;
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
    public partial class NotifyForm : Form
    {
        public NotifyForm()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            flowPanelNotifyForm.FlowDirection = FlowDirection.TopDown; // Xếp các thông báo từ trên xuống
            flowPanelNotifyForm.WrapContents = false; // Không quấn các phần tử
        }

        private void NotifyForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 15; i++) 
            {
                AddItem("Thông báo Toàn thể nhân viên được nghỉ 20/10! Thông báo Toàn thể nhân viên được nghỉ 20/10! Thông báo Toàn thể nhân viên được nghỉ 20/10! Thông báo Toàn thể nhân viên được nghỉ 20/10 Thông báo Toàn thể nhân viên được nghỉ 20/10! Thông báo Toàn thể nhân viên được nghỉ 20/10! Thông báo Toàn thể nhân viên được nghỉ 20/10! Thông báo Toàn thể nhân viên được nghỉ 20/10!");
            }
        }
        private void AddItem(string content)
        {
            Guna2TextBox txtLog = new Guna2TextBox
            {
                Font = new Font("Bahnschrift SemiBold", 11),
                Text = content,
                Width = flowPanelNotifyForm.Width - 20, // Đặt chiều rộng gần bằng chiều rộng của FlowLayoutPanel
                Height = 40, // Độ cao của TextBox
                Margin = new Padding(0, 0, 0, 10), // Khoảng cách giữa các thông báo
                TextAlign = HorizontalAlignment.Left, // Căn lề trái
                ForeColor = Color.White,
                FillColor = Color.FromArgb(43, 43, 43), // Màu nền
                BorderRadius = 10, // Bo góc
                ReadOnly = true, // Đặt là chỉ đọc để không thể chỉnh sửa
                Cursor = Cursors.Default, // Đổi con trỏ thành dạng mặc định
                BorderThickness = 0, // Không có đường viền
                Padding = new Padding(5)// Điều chỉnh padding nếu cần
            };
            flowPanelNotifyForm.Controls.Add(txtLog);
        }
    }
}
