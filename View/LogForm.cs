using BankManagement.ViewModel;
using Guna.UI2.WinForms;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace BankManagement.View
{
    public partial class LogForm : Form
    {
        private LogViewModel viewModel;
        private int id;
        public LogForm(int id)
        {
            InitializeComponent();
            SetupForm();
            viewModel = new LogViewModel();
            this.id = id;
        }

        private void SetupForm()
        {
            flowPanelLogForm.FlowDirection = FlowDirection.TopDown; // Xếp các thông báo từ trên xuống
            flowPanelLogForm.WrapContents = false; // Không quấn các phần tử
        }

        private void LogForm_Load(object sender, EventArgs e)
        {
            viewModel.searchLogByStaffId(this.id);
            foreach (DataRow row in viewModel.LogTable.Rows)
            {
                // Chuyển đổi "time" thành kiểu DateTime trước
                DateTime time = DateTime.Parse(row["time"].ToString());

                // Định dạng DateTime thành chuỗi theo định dạng mong muốn: "dd/MM/yyyy HH:mm"
                string formattedTime = time.ToString("dd/MM/yyyy HH:mm");

                // Lấy nội dung thông báo
                string content = row["content"].ToString();

                AddItem("  " + formattedTime + "  " + content);
            }
        }

        private void AddItem(string content)
        {
            Guna2TextBox txtLog = new Guna2TextBox
            {
                Font = new Font("Bahnschrift SemiBold", 11),
                Text = content,
                Width = flowPanelLogForm.Width - 20, // Đặt chiều rộng gần bằng chiều rộng của FlowLayoutPanel
                Height = 40, // Độ cao của TextBox
                Margin = new Padding(0, 0, 0, 10), // Khoảng cách giữa các thông báo
                TextAlign = HorizontalAlignment.Left, // Căn lề trái
                ForeColor = Color.White,
                FillColor = Color.FromArgb(43, 43, 43), // Màu nền
                BorderRadius = 10, // Bo góc
                ReadOnly = true, // Đặt là chỉ đọc để không thể chỉnh sửa
                Cursor = Cursors.Default, // Đổi con trỏ thành dạng mặc định
                BorderThickness = 0, // Không có đường viền
                Padding = new Padding(5), // Điều chỉnh padding nếu cần
            };
            flowPanelLogForm.Controls.Add(txtLog);
        }

        private void LogForm_Deactivate(object sender, EventArgs e)
        {
            this.Hide();
        }

        public void UpdateFlowPanel()
        {
            flowPanelLogForm.Controls.Clear();
            viewModel.searchLogByStaffId(this.id);
            foreach (DataRow row in viewModel.LogTable.Rows)
            {
                // Chuyển đổi "time" thành kiểu DateTime trước
                DateTime time = DateTime.Parse(row["time"].ToString());

                // Định dạng DateTime thành chuỗi theo định dạng mong muốn: "dd/MM/yyyy HH:mm"
                string formattedTime = time.ToString("dd/MM/yyyy HH:mm");

                // Lấy nội dung thông báo
                string content = row["content"].ToString();

                AddItem("  " + formattedTime + "  " + content);
            }
        }
    }
}
