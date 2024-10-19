using iTextSharp.text.pdf;
using iTextSharp.text;
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
using System.Drawing.Imaging;
using Rectangle = iTextSharp.text.Rectangle;
using System.IO;


namespace BankManagement.View
{
    public partial class BillForm : Form
    {
        DateTime time;
        int id;
        string accountNumberSend;
        string accountNumberReceive;
        string customerNameSend;
        string customerNameReceive;
        string amount;
        string content;
        string typeTransaction;

        public BillForm(int id, DateTime time, string accountNumberSend, string accountNumberReceive, string customerNameSend, string customerNameReceive, string amount, string content, string typeTransaction)
        {
            InitializeComponent();
            this.id = id;
            this.time = time;
            this.accountNumberSend = accountNumberSend;
            this.accountNumberReceive = accountNumberReceive;
            this.customerNameSend = customerNameSend;
            this.customerNameReceive = customerNameReceive;
            this.amount = amount;
            this.content = content;
            this.typeTransaction = typeTransaction;
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

        private void panelTitleBarBillForm_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture(); //Nếu không có hàm này thì mọi sự kiện chuột ("kéo thả") vẫn sẽ được gửi đến title bar
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0); //Gửi thông điệp đến hđh để bắt đầu di chuyển form
        }





        //Load bill---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private void BillForm_Load(object sender, EventArgs e)
        {
            txtTimeBillForm.Text = this.time.ToString().Substring(0, txtTimeBillForm.Text.Length - 4);
            string transactionCode = GenerateTransactionCode(this.id);
            txtTransactionCodeBillForm.Text = transactionCode;
            txtGiaoDichThanhCongBillForm.Text = "  " + this.typeTransaction;
            txtAccountNumberSendBillForm.Text = this.accountNumberSend;
            txtCustomerNameSendBillForm.Text = this.customerNameSend;
            txtAmountBillForm.Text = this.amount + " VNĐ";
            txtContentBillForm.Text = this.content;
            if (this.accountNumberReceive != "")
            {
                txtCustomerNameReceiveBillForm.Visible = true;
                txtAccountNumberReceiveBillForm.Visible = true;
                lbDenTaiKhoanBillForm.Visible = true;
                txtAccountNumberReceiveBillForm.Text = this.accountNumberReceive;
                txtCustomerNameReceiveBillForm.Text = this.customerNameReceive;
            }
            else
            {
                txtCustomerNameReceiveBillForm.Visible = false;
                txtAccountNumberReceiveBillForm.Visible = false;
                lbDenTaiKhoanBillForm.Visible = false;
            }
        }
        private static string GenerateTransactionCode(int id)
        {
            // Chuyển số giao dịch sang hệ Base36 (gồm số và chữ cái)
            string base36Code = ConvertToBase36(id);

            // Thêm tiền tố và pad để tạo chuỗi đủ 12 ký tự
            string prefix = "TX";  // Prefix đại diện cho Transaction
            return prefix + base36Code.PadLeft(10, '0');  // Tạo mã 12 ký tự
        }

        private static string ConvertToBase36(int value)
        {
            const string chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string result = string.Empty;

            // Chuyển đổi giá trị sang Base36
            while (value > 0)
            {
                result = chars[value % 36] + result;
                value /= 36;
            }

            return result;
        }

        private void btnCloseBillForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }




        //Lưu file .pdf giao dịch--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        private Bitmap CaptureForm()
        {
            // Tính toán chiều cao mới để chụp toàn bộ form
            int heightToCapture = this.ClientSize.Height; 

            // Tạo bitmap với chiều rộng của form và chiều cao đã điều chỉnh
            Bitmap bitmap = new Bitmap(this.ClientSize.Width, heightToCapture);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.CopyFromScreen(this.Location.X, this.Location.Y + 26, 0, 0, new Size(this.ClientSize.Width, heightToCapture));
            }
            return bitmap;
        }


        private void btnExportPdfBillForm_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = CaptureForm();
            // Mở hộp thoại chọn vị trí lưu
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                saveFileDialog.Title = "Save a PDF File";
                saveFileDialog.FileName = "Bill.pdf";
                
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Tạo tài liệu PDF
                    Document pdfDoc = new Document();
                    PdfWriter.GetInstance(pdfDoc, new FileStream(saveFileDialog.FileName, FileMode.Create));

                    pdfDoc.Open();

                    // Thêm hình ảnh vào PDF
                    using (MemoryStream stream = new MemoryStream())
                    {
                        bitmap.Save(stream, ImageFormat.Png);
                        iTextSharp.text.Image pdfImage = iTextSharp.text.Image.GetInstance(stream.ToArray());
                        pdfImage.ScaleToFit(pdfDoc.PageSize.Width, pdfDoc.PageSize.Height);
                        pdfDoc.Add(pdfImage);
                    }

                    pdfDoc.Close();
                }
            }
        }





    }
}
