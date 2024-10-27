using BankManagement.ViewModel;
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
        private int StaffId;
        private NotifyViewModel viewModel;
        public NotifyForm(int staffId)
        {
            InitializeComponent();
            viewModel = new NotifyViewModel();
            SetupForm();
            this.StaffId = staffId;
        }

        private void SetupForm()
        {
            flowPanelNotifyForm.FlowDirection = FlowDirection.TopDown; // Xếp các thông báo từ trên xuống
            flowPanelNotifyForm.WrapContents = false; // Không quấn các phần tử
        }

        private void NotifyForm_Load(object sender, EventArgs e)
        {
            //AddItem("CHÍNH SÁCH LÀM VIỆC MỚI!\r\nThông báo về việc thay đổi hệ số lương tăng ca\r\n25/10/2024 19:56", "Cập nhật mới nhất!\r\nThông báo về việc thay đổi hệ số lương tăng ca...", 1);
            //AddItem("CHÍNH SÁCH LÀM VIỆC MỚI!\r\nThông báo về việc thay đổi hệ số lương tăng ca\r\n25/10/2024 19:56", "Cập nhật mới nhất!\r\nThông báo về việc thay đổi hệ số lương tăng ca...", 1);
            //AddItem("CHÍNH SÁCH LÀM VIỆC MỚI!\r\nThông báo về việc thay đổi hệ số lương tăng ca\r\n25/10/2024 19:56", "Cập nhật mới nhất!\r\nThông báo về việc thay đổi hệ số lương tăng ca...", 0);
            //AddItem("CHÍNH SÁCH LÀM VIỆC MỚI!\r\nThông báo về việc thay đổi hệ số lương tăng ca\r\n25/10/2024 19:56", "Cập nhật mới nhất!\r\nThông báo về việc thay đổi hệ số lương tăng ca...", 0);
            //AddItem("CHÍNH SÁCH LÀM VIỆC MỚI!\r\nThông báo về việc thay đổi hệ số lương tăng ca\r\n25/10/2024 19:56", "Cập nhật mới nhất!\r\nThông báo về việc thay đổi hệ số lương tăng ca...", 0);
            //AddItem("CHÍNH SÁCH LÀM VIỆC MỚI!\r\nThông báo về việc thay đổi hệ số lương tăng ca\r\n25/10/2024 19:56", "Cập nhật mới nhất!\r\nThông báo về việc thay đổi hệ số lương tăng ca...", 0);
            //AddItem("CHÍNH SÁCH LÀM VIỆC MỚI!\r\nThông báo về việc thay đổi hệ số lương tăng ca\r\n25/10/2024 19:56", "Cập nhật mới nhất!\r\nThông báo về việc thay đổi hệ số lương tăng ca...", 0);
            //AddItem("CHÍNH SÁCH LÀM VIỆC MỚI!\r\nThông báo về việc thay đổi hệ số lương tăng ca\r\n25/10/2024 19:56", "Cập nhật mới nhất!\r\nThông báo về việc thay đổi hệ số lương tăng ca...", 0);
            //AddItem("CHÍNH SÁCH LÀM VIỆC MỚI!\r\nThông báo về việc thay đổi hệ số lương tăng ca\r\n25/10/2024 19:56", "Cập nhật mới nhất!\r\nThông báo về việc thay đổi hệ số lương tăng ca...", 0);
            //AddItem("CHÍNH SÁCH LÀM VIỆC MỚI!\r\nThông báo về việc thay đổi hệ số lương tăng ca\r\n25/10/2024 19:56", "Cập nhật mới nhất!\r\nThông báo về việc thay đổi hệ số lương tăng ca...", 0);
            //AddItem("CHÍNH SÁCH LÀM VIỆC MỚI!\r\nThông báo về việc thay đổi hệ số lương tăng ca\r\n25/10/2024 19:56", "Cập nhật mới nhất!\r\nThông báo về việc thay đổi hệ số lương tăng ca...", 0);
            this.updateFlowPannel();
        } 
        private void AddItem(string title, string message, int status)
        {
            Color txtColor = Color.FromArgb(215, 215, 215);
            if (status == 1) txtColor = Color.FromArgb(50, 230, 170);
            Guna2Button btn = new Guna2Button
            {
                Font = new Font("Bahnschrift SemiBold", 11),
                Text = title, // Nội dung sẽ hiển thị trên nút
                Width = flowPanelNotifyForm.Width - 20, // Đặt chiều rộng gần bằng chiều rộng của FlowLayoutPanel
                Height = 76, // Độ cao của Button
                Margin = new Padding(0, 0, 0, 7), // Khoảng cách giữa các nút thông báo
                TextAlign = HorizontalAlignment.Left, // Căn lề trái
                ForeColor = txtColor, // Màu chữ
                FillColor = Color.FromArgb(43, 43, 43), // Màu nền nút
                BorderRadius = 10, // Bo góc
                BorderThickness = 0, // Không có đường viền
                TabStop = false, // Không cho phép focus bằng Tab
                Padding = new Padding(5, 0, 5, 0)
            };

            // Đăng ký sự kiện Click cho nút btn
            DetailedNoticeForm detailsForm;
            btn.Click += (s, e) =>
            {
                detailsForm = new DetailedNoticeForm(title, message);
                detailsForm.StartPosition = FormStartPosition.Manual; // Đặt vị trí khởi động
                detailsForm.Location = this.Location; // Đặt vị trí của form mới bằng vị trí của form hiện tại
                this.Hide();
                detailsForm.ShowDialog();
            };

            // Thêm nút vào FlowLayoutPanel
            flowPanelNotifyForm.Controls.Add(btn);
        }

        private void updateFlowPannel()
        {
            flowPanelNotifyForm.Controls.Clear();
            viewModel.getAllNotifyByStaffId(this.StaffId);
            foreach (DataRow row in viewModel.NotifyTable.Rows)
            {
                // Chuyển đổi "time" thành kiểu DateTime trước
                DateTime time = DateTime.Parse(row["DateCreated"].ToString());

                // Định dạng DateTime thành chuỗi theo định dạng mong muốn: "dd/MM/yyyy HH:mm"
                string formattedTime = time.ToString("dd/MM/yyyy HH:mm");

                // Lấy nội dung title
                string title = row["title"].ToString();
                // lấy nội dung của cột message
                string message = row["message"].ToString();
                int status = Convert.ToInt32(row["isRead"]);

                AddItem(title + "\r\n" + message + "\r\n" + formattedTime, "Cập Nhật Mới Nhất!" + "\r\n" + message, status);
            }
        }

        private void NotifyForm_Deactivate(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnCloseNotifyForm_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void flowPanelNotifyForm_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
