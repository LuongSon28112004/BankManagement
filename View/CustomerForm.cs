using BankManagement.Model;
using BankManagement.Properties;
using BankManagement.ViewModel;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Xml.Linq;
using Image = System.Drawing.Image;

namespace BankManagement
{
	public partial class CustomerForm : Form
	{
		CustomerViewModel viewModel;
        string filePath;


		public CustomerForm()
		{
			InitializeComponent();
			viewModel = new CustomerViewModel();
			this.ShowInTaskbar = false; //Ẩn khỏi thanh taskbar
		}


        private void CustomerForm_Load(object sender, EventArgs e)
        {

            //Load gender default
            this.LoadGender();

            //reset các textbox và combo box
            this.reset();
            //Load danh sach tat ca cac customer khi form duoc load len
            this.LoadAllCustomer();

            //Hover IMG customer none
            imgCustomerCustomerForm.HoverState.FillColor = Color.FromArgb(40, 42, 45);

            //Đăng ký sự kiện ScrollBar vertical của dataGridView
            dataGridViewCustomerInforCustomerForm.MouseWheel += dataGridViewCustomerInforCustomerForm_MouseWheel;
        }





        //Thêm lựa chọn giới tính
        public void LoadGender()
        {
            cbGenderCustomerForm.Items.Add("Male");
            cbGenderCustomerForm.Items.Add("Female");
        }




        //Ẩn lbGender = "Gender" khi cbGender được chọn
        private void cbGenderCustomerForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu không có mục nào được chọn (SelectedIndex == -1)
            if (cbGenderCustomerForm.SelectedIndex == -1)
            {
                lbGenderCustomerForm.Visible = true;
            }
            else
            {
                lbGenderCustomerForm.Visible = false;
            }
        }




        //Sự kiện sử dụng con lăn chuột để kéo dataGridView--------------------------------------------------------------------------------------------
        private void dataGridViewCustomerInforCustomerForm_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                if (dataGridViewCustomerInforCustomerForm.FirstDisplayedScrollingRowIndex > 0)
                {
                    dataGridViewCustomerInforCustomerForm.FirstDisplayedScrollingRowIndex--;
                }
            }
            else if (e.Delta < 0)
            {
                if (dataGridViewCustomerInforCustomerForm.FirstDisplayedScrollingRowIndex < dataGridViewCustomerInforCustomerForm.RowCount - 1)
                {
                    dataGridViewCustomerInforCustomerForm.FirstDisplayedScrollingRowIndex++;
                }
            }
        }





        //Tìm kiếm theo cccd---------------------------------------------------------------------------------------------------------------------------
        private void btnSearchCustomerForm_Click(object sender, EventArgs e)
        {
            //Lấy ra các Customer phù hợp
            viewModel.SearchCustomer(txtSearchCustomerForm.Text);

            //xóa tất cả các dữ liệu trong datagridview
            dataGridViewCustomerInforCustomerForm.Rows.Clear();

            this.UpdateDataGridView(viewModel.DataTableCustomerInfor);
        }





        //Thêm khách hàng-------------------------------------------------------------------------------------------------------------------------------
        private void btnAddCustomerForm_Click(object sender, EventArgs e)
		{
            // Kiểm tra nếu ComboBox Gender không chọn thì gán "" cho Gender
            string gender = cbGenderCustomerForm.SelectedItem != null ? cbGenderCustomerForm.SelectedItem.ToString() : "";
            string error = viewModel.CheckFormatCustomerForm(txtCCCDCustomerForm.Text,
                                                             txtCustomerNameCustomerForm.Text,
                                                             txtEmailCustomerForm.Text,
                                                             txtJobCustomerForm.Text,
                                                             txtPhoneNumberCustomerForm.Text,
                                                             txtDateOfBirthCustomerForm.Text,
                                                             txtNationalityCustomerForm.Text,
                                                             txtAddressCustomerForm.Text, 
                                                             gender);

            if (error != "0")
            {
                MessageBox.Show($"{error}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //Lấy các thông tin từ các textBox
            this.UpdateViewModelFromForm();
            if(filePath != "") MoveImageToFolder(filePath, "\\Image\\CustomerImage");

            //add customer form viewModel
            viewModel.addCustomer();

            //Thay thế tất cả các dữ liệu trong datagridview
            dataGridViewCustomerInforCustomerForm.Rows.Clear();
            this.LoadAllCustomer();
        }





        //Cập nhật các lb, txt... chứa thông tin khách hàng khi click vào 1 row trong dataGridView------------------------------------------------------------------------------
        private void dataGridViewCustomerInforCustomerForm_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem chỉ số hàng hợp lệ
            if (e.RowIndex >= 0)
            {
                // Lấy hàng được chọn
                DataGridViewRow selectedRow = dataGridViewCustomerInforCustomerForm.Rows[e.RowIndex];

                if (selectedRow.Cells["cccd"].Value != null)
                {
                    // Lấy dữ liệu từ các cột trong hàng với kiểm tra null
                    int id = Convert.ToInt32(selectedRow.Cells["id"].Value);
                    string cccd = selectedRow.Cells["cccd"].Value.ToString();
                    string name = selectedRow.Cells["customerName"].Value.ToString();
                    string phone_number = selectedRow.Cells["phoneNumber"].Value.ToString();
                    string dateOfBirth = selectedRow.Cells["dateOfBirth"].Value.ToString();
                    string address = selectedRow.Cells["address"].Value.ToString();
                    string nationality = selectedRow.Cells["nationality"].Value.ToString();
                    string job = selectedRow.Cells["job"].Value.ToString();
                    string email = selectedRow.Cells["email"].Value.ToString();
                    string gender = selectedRow.Cells["Gender"].Value.ToString();
                    string status = selectedRow.Cells["Status"].Value.ToString();
                    string photo = selectedRow.Cells["Photo"].Value.ToString();
                    filePath = photo;



                    // Hiển thị dữ liệu.
                    txtCCCDCustomerForm.Text = cccd;
                    //không cho phép chỉnh sửa dữ liệu căn cước công dân.
                    txtCCCDCustomerForm.ReadOnly = true;
                    txtCustomerNameCustomerForm.Text = name;
                    txtPhoneNumberCustomerForm.Text = phone_number;
                    txtDateOfBirthCustomerForm.Text = dateOfBirth;
                    txtAddressCustomerForm.Text = address;
                    txtNationalityCustomerForm.Text = nationality;
                    txtJobCustomerForm.Text = job;
                    txtEmailCustomerForm.Text = email;
                    cbGenderCustomerForm.SelectedItem = gender;
                    try
                    {
                        if (photo != "")
                        {
                            imgCustomerCustomerForm.Image = Image.FromFile(photo);
                        }
                        else
                        {
                            imgCustomerCustomerForm.Image = Image.FromFile("..\\..\\Image\\CustomerImage\\img_customer_default.png");
                        }
                    }
                    catch (Exception ex)
                    {
                        // Nếu có lỗi xảy ra, sử dụng hình ảnh mặc định
                        imgCustomerCustomerForm.Image = Image.FromFile("..\\..\\Image\\CustomerImage\\img_customer_default.png");

                        // Bạn có thể log hoặc xử lý lỗi nếu cần thiết
                        Console.WriteLine(ex.Message);
                    }
                    checkStatus(status);
                }
            }
        }
        private void checkStatus(string status)
        {
            if (status == "Active")
            {
                imgStatusCustomerForm.Image = Image.FromFile("..\\..\\Resources\\checked.png");
                lbStatusCustomerForm.Text = status;
                lbStatusCustomerForm.ForeColor = Color.FromArgb(78, 167, 46);
                btnActiveCustomerForm.Visible = false; //show button active
            }
            else
            {
                imgStatusCustomerForm.Image = Image.FromFile("..\\..\\Resources\\x-button.png");
                lbStatusCustomerForm.Text = status;
                lbStatusCustomerForm.ForeColor = Color.FromArgb(203, 57, 53);
                btnActiveCustomerForm.Visible = true; // hide button active
            }
        }





        //Cập nhật thông tin khách hàng----------------------------------------------------------------------------------------------------------------
        private void btnUpdateCustomerForm_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu ComboBox Gender không chọn thì gán "" cho Gender
            string gender = cbGenderCustomerForm.SelectedItem != null ? cbGenderCustomerForm.SelectedItem.ToString() : "";
            string error = viewModel.CheckFormatCustomerForm(txtCCCDCustomerForm.Text,
                                                             txtCustomerNameCustomerForm.Text,
                                                             txtEmailCustomerForm.Text,
                                                             txtJobCustomerForm.Text,
                                                             txtPhoneNumberCustomerForm.Text,
                                                             txtDateOfBirthCustomerForm.Text,
                                                             txtNationalityCustomerForm.Text,
                                                             txtAddressCustomerForm.Text,
                                                             gender);

            if (error != "0")
            {
                MessageBox.Show($"{error}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            //lấy dữ liệu từ các textBox
            this.UpdateViewModelFromForm();
            if (filePath != "")
            {
                MoveImageToFolder(filePath, "\\Image\\CustomerImage");
            }


            //this.MoveImageToFolder(filePath, "\\Image\\CustomerImage");
            //Check xem đã có thông tin trong database chưa thông qua cccd
            viewModel.SearchCustomer(viewModel.Cccd);
            if (viewModel.DataTableCustomerInfor.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng nhập một tài khoản có sẵn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            viewModel.updateCustomer();
            //xóa tất cả các dữ liệu trong datagridview
            dataGridViewCustomerInforCustomerForm.Rows.Clear();
            this.LoadAllCustomer();
        }





        //Xoá khách hàng khỏi hệ thống----------------------------------------------------------------------------------------------------------------
        private void btnDeleteCustomerForm_Click(object sender, EventArgs e)
        {
            //Check xem đã có thông tin trong data base chưa thông qua cccd
            viewModel.SearchCustomer(viewModel.Cccd);
            if (viewModel.DataTableCustomerInfor.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng nhập một tài khoản có sẵn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //lấy dữ liệu từ các textBox
            this.UpdateViewModelFromForm();

            viewModel.deleteCustomer();

            //xóa tất cả các dữ liệu trong datagridview
            dataGridViewCustomerInforCustomerForm.Rows.Clear();
            this.LoadAllCustomer();
        }




        //Reset các lb, txt để chuẩn bị add khách hàng...-----------------------------------------------------------------------------------------------
        private void btnResetCustomerForm_Click_1(object sender, EventArgs e)
        {
            this.reset();
            //xóa tất cả các dữ liệu trong datagridview
            dataGridViewCustomerInforCustomerForm.Rows.Clear();
            this.LoadAllCustomer();
        }
        private void reset()
        {
            filePath = "";
            txtSearchCustomerForm.Text = "";
            txtCCCDCustomerForm.Text = "";
            txtCCCDCustomerForm.ReadOnly = false;
            txtCustomerNameCustomerForm.Text = "";
            txtPhoneNumberCustomerForm.Text = "";
            txtDateOfBirthCustomerForm.Text = "";
            txtAddressCustomerForm.Text = "";
            txtNationalityCustomerForm.Text = "";
            txtJobCustomerForm.Text = "";
            txtEmailCustomerForm.Text = "";
            cbGenderCustomerForm.SelectedIndex = -1;
            imgCustomerCustomerForm.Image = Image.FromFile("..\\..\\Resources\\avatar_customer_default.png");
            btnActiveCustomerForm.Visible = false;
            imgStatusCustomerForm.Image = null;
            lbStatusCustomerForm.Text = "";
        }





        //Cập nhật toàn bộ khách hàng lên dataGridView--------------------------------------------------------------------------------------------------
        public void LoadAllCustomer()
        {
            viewModel.LoadAllCustomer();
            //duyệt datatable để lấy các thông tin hiển thị lên datagridview
            this.UpdateDataGridView(viewModel.DataTableCustomerInfor);

        }
        private void UpdateDataGridView(DataTable dataTable)
        {
            foreach (DataRow row in dataTable.Rows)
            {
                int id = Convert.ToInt32(row["id"]);
                string cccd = row["cccd"].ToString();
                string name = row["name"].ToString();
                string phone_number = row["phone_number"].ToString();
                // Parse and format the dateOfBirth to only display the date part
                DateTime dateOfBirth = DateTime.Parse(row["date_of_birth"].ToString());
                string formattedDateOfBirth = dateOfBirth.ToString("dd/MM/yyyy");
                string address = row["address"].ToString();
                string nationality = row["nationality"].ToString();
                string job = row["job"].ToString();
                string email = row["email"].ToString();
                string gender = row["gender"].ToString();
                string status = row["status"].ToString();
                string photo = row["photo"].ToString();

                dataGridViewCustomerInforCustomerForm.Rows.Add(id, cccd, name, gender, formattedDateOfBirth, address, phone_number, nationality, job, email, status, photo);
            }
        }





        //Cập nhật các thông tin khách hàng từ form vào viewModel-------------------------------------------------------------------------------------
        private void UpdateViewModelFromForm()
        {
            viewModel.Cccd = txtCCCDCustomerForm.Text;
            viewModel.Name = txtCustomerNameCustomerForm.Text;
            viewModel.Email = txtEmailCustomerForm.Text;
            viewModel.Job = txtJobCustomerForm.Text;
            viewModel.PhoneNumber = txtPhoneNumberCustomerForm.Text;
            viewModel.DateOfBirth = DateTime.Parse(txtDateOfBirthCustomerForm.Text);
            viewModel.Nationality = txtNationalityCustomerForm.Text;
            viewModel.Address = txtAddressCustomerForm.Text;
            viewModel.Gender = cbGenderCustomerForm.SelectedItem.ToString();
            if(filePath != "")
            {
                viewModel.Photo = $"..\\\\..\\\\Image\\\\CustomerImage\\\\{Path.GetFileName(filePath)}";
            }
            else
            {
                viewModel.Photo = $"..\\\\..\\\\Image\\\\CustomerImage\\\\img_customer_default.png";
            }
        }
        //private void UpdateFormFromViewModel()
        //{
        //    txtCCCDCustomerForm.Text = viewModel.Cccd;
        //    txtCustomerNameCustomerForm.Text = viewModel.Name;
        //    txtEmailCustomerForm.Text = viewModel.Email;
        //    txtJobCustomerForm.Text = viewModel.Job;
        //    txtPhoneNumberCustomerForm.Text = viewModel.PhoneNumber;
        //    txtDateOfBirthCustomerForm.Text = viewModel.DateOfBirth.ToString("yyyy-MM-dd");
        //    txtNationalityCustomerForm.Text = viewModel.Nationality;
        //    txtAddressCustomerForm.Text = viewModel.Address;
        //}





        //Xử lý ảnh của khách hàng-----------------------------------------------------------------------------------------------------------------------
        private void imgCustomerCustomerForm_Click(object sender, EventArgs e)
        {
            // Tạo đối tượng OpenFileDialog để chọn ảnh
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            openFileDialog.Title = "Select a Picture";

            // Kiểm tra xem người dùng đã chọn file hay chưa
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lấy đường dẫn file
                filePath = openFileDialog.FileName;

                // Sử dụng FileStream để load ảnh và tránh bị khóa file
                using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    // Hiển thị hình ảnh trên PictureBox (imgCustomerCustomerForm)
                    imgCustomerCustomerForm.Image = Image.FromStream(stream);
                }
            }
        }
        private void MoveImageToFolder(string filePath , string folderName)
        {
            if (filePath == null) return;
            try
            {
                // Đường dẫn tới thư mục CustomerImage trong dự án
                string projectDirectory = Directory.GetParent(Application.StartupPath).Parent.Parent.FullName;
                string destinationFolder = Path.Combine(projectDirectory, $@"BankManagement{folderName}");


                // Hiển thị đường dẫn đích để kiểm tra
                //MessageBox.Show("Đường dẫn lưu ảnh: " + destinationFolder);

                // Kiểm tra và tạo thư mục nếu chưa tồn tại
                if (!Directory.Exists(destinationFolder))
                {
                    Directory.CreateDirectory(destinationFolder);
                }

                // Copy ảnh vào thư mục CustomerImage
           

                // Tạo đường dẫn đầy đủ cho file ảnh mới
                string destinationPath = Path.Combine(destinationFolder, Path.GetFileName(filePath));

                //// Kiểm tra nếu ảnh đã tồn tại, thì xóa ảnh cũ trước khi sao chép
                if (File.Exists(destinationPath))
                {
                    //File.Delete(destinationPath);
                    return;
                }

                // Sao chép ảnh vào thư mục đích
                File.Copy(filePath, destinationPath);
                //MessageBox.Show("Ảnh đã được lưu vào thư mục CustomerImage.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lưu ảnh: " + ex.Message);
                }
        }

        
    }
}
