using BankManagement.Language;
using BankManagement.ViewModel;
using Guna.UI2.WinForms;
using System;
using System.Data;
using System.Drawing;
using System.Configuration;
using System.Windows.Forms;

namespace BankManagement.View
{
    public partial class LogForm : Form
    {
        private LogViewModel viewModel;
        private int id;
        public LogForm(int id)
        {
            viewModel = new LogViewModel();
            InitializeComponent();
            SetupForm();
            this.id = id;
        }

        private void SetupForm()
        {
            flowPanelLogForm.FlowDirection = FlowDirection.TopDown; // Xếp các thông báo từ trên xuống
            flowPanelLogForm.WrapContents = false; // Không quấn các phần tử

            dateTimeFrom.MaxDate = DateTime.Today;
            dateTimeFrom.MinDate = DateTime.Today.AddYears(-1);
            dateTimeTo.MaxDate = DateTime.Today;
            dateTimeTo.MinDate = DateTime.Today.AddYears(-1);

            dateTimeFrom.Value = DateTime.Today.AddMonths(-1);
            dateTimeTo.Value = DateTime.Today;
        }

        private void LogForm_Load(object sender, EventArgs e)
        {
            lbHistoryLogForm.Text = LangHelper.Instance.GetString("History");
            txtSearchLogForm.PlaceholderText = LangHelper.Instance.GetString("Search anything");
            viewModel.searchLogByStaffId(this.id, dateTimeFrom.Value, dateTimeTo.Value.AddDays(1));
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
            //this.reset();
            //this.Hide();
        }

        private void btnSearchByAnyThingLogFormForm_Click(object sender, EventArgs e)
        {
            string keyword = txtSearchLogForm.Text.Trim().ToLower(); // Lấy từ khóa tìm kiếm, chuyển về chữ thường

            // Duyệt qua tất cả các Control (TextBox) trong flowPanelLogForm
            foreach (Control control in flowPanelLogForm.Controls)
            {
                if (control is Guna2TextBox txtLog) // Kiểm tra nếu control là Guna2TextBox
                {
                    string logContent = txtLog.Text.ToLower(); // Lấy nội dung thông báo và chuyển về chữ thường

                    // Nếu nội dung chứa từ khóa tìm kiếm, hiển thị TextBox; ngược lại, ẩn TextBox
                    if (logContent.Contains(keyword))
                    {
                        txtLog.Visible = true; // Hiển thị
                    }
                    else
                    {
                        txtLog.Visible = false; // Ẩn
                    }
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnCloseLogForm_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dateTimeTo_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimeFrom.Value > dateTimeTo.Value)
            {
                dateTimeTo.Value = dateTimeFrom.Value;
                return;
            }
            try
            {
                viewModel.searchLogByStaffId(this.id, dateTimeFrom.Value, dateTimeTo.Value.AddDays(1));
                flowPanelLogForm.Controls.Clear();
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
            catch (Exception ex)
            {
                CustomMessageBox.ShowBox(ex.Message, "Error");
            }
        }

        private void dateTimeFrom_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimeFrom.Value > dateTimeTo.Value)
            {
                dateTimeFrom.Value = dateTimeTo.Value;
                return;
            }
            try
            {
                viewModel.searchLogByStaffId(this.id, dateTimeFrom.Value, dateTimeTo.Value.AddDays(1));
                flowPanelLogForm.Controls.Clear();
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
            catch (Exception ex)
            {
                CustomMessageBox.ShowBox(ex.Message, "Error");
            }
        }
    }
}