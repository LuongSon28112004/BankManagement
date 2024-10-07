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
    public partial class CustomerAccountForm : Form
    {
        public CustomerAccountForm()
        {
            InitializeComponent();
            this.ShowInTaskbar = false; //Ẩn khỏi thanh taskbar
        }

        private void CustomerAccountForm_Load(object sender, EventArgs e)
        {
            dataGridViewCustomerAccountForm.Rows.Add("", "024204007331", "DINH NGOC THE", "Male", "1017766701", "dinhngocthe", "Active");
            dataGridViewCustomerAccountForm.Rows.Add("", "024204007331", "TRUONG QUANG VINH", "Male", "1017766701", "dinhngocthe", "Active");
            dataGridViewCustomerAccountForm.Rows.Add("", "024204007331", "NGUYEN PHAN HAI", "Male", "1017766701", "dinhngocthe", "Active");
            dataGridViewCustomerAccountForm.Rows.Add("", "024204007331", "LUONG VAN SON", "Male", "1017766701", "dinhngocthe", "Active");
            dataGridViewCustomerAccountForm.Rows.Add("", "024204007331", "TRAN HAI DANG", "Male", "1017766701", "dinhngocthe", "Active");
            dataGridViewCustomerAccountForm.Rows.Add("", "024204007331", "NGUYEN THANH THAO", "Female", "1017766701", "dinhngocthe", "Active");dataGridViewCustomerAccountForm.Rows.Add("", "024204007331", "DINH NGOC THE", "Male", "1017766701", "dinhngocthe", "Active");
            dataGridViewCustomerAccountForm.Rows.Add("", "024204007331", "TRUONG QUANG VINH", "Male", "1017766701", "dinhngocthe", "Active");
            dataGridViewCustomerAccountForm.Rows.Add("", "024204007331", "NGUYEN PHAN HAI", "Male", "1017766701", "dinhngocthe", "Active");
            dataGridViewCustomerAccountForm.Rows.Add("", "024204007331", "LUONG VAN SON", "Male", "1017766701", "dinhngocthe", "Active");
            dataGridViewCustomerAccountForm.Rows.Add("", "024204007331", "TRAN HAI DANG", "Male", "1017766701", "dinhngocthe", "Active");
            dataGridViewCustomerAccountForm.Rows.Add("", "024204007331", "NGUYEN THANH THAO", "Female", "1017766701", "dinhngocthe", "Active");dataGridViewCustomerAccountForm.Rows.Add("", "024204007331", "DINH NGOC THE", "Male", "1017766701", "dinhngocthe", "Active");
            dataGridViewCustomerAccountForm.Rows.Add("", "024204007331", "TRUONG QUANG VINH", "Male", "1017766701", "dinhngocthe", "Active");
            dataGridViewCustomerAccountForm.Rows.Add("", "024204007331", "NGUYEN PHAN HAI", "Male", "1017766701", "dinhngocthe", "Active");
            dataGridViewCustomerAccountForm.Rows.Add("", "024204007331", "LUONG VAN SON", "Male", "1017766701", "dinhngocthe", "Active");
            dataGridViewCustomerAccountForm.Rows.Add("", "024204007331", "TRAN HAI DANG", "Male", "1017766701", "dinhngocthe", "Active");
            dataGridViewCustomerAccountForm.Rows.Add("", "024204007331", "NGUYEN THANH THAO", "Female", "1017766701", "dinhngocthe", "Active");




            //Đăng ký sự kiện ScrollBar vertical của dataGridView
            dataGridViewCustomerAccountForm.MouseWheel += dataGridViewCustomerAccountForm_MouseWheel;
        }






        //Sự kiện sử dụng con lăn chuột để kéo dataGridView--------------------------------------------------------------------------------------------
        private void dataGridViewCustomerAccountForm_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                if (dataGridViewCustomerAccountForm.FirstDisplayedScrollingRowIndex > 0)
                {
                    dataGridViewCustomerAccountForm.FirstDisplayedScrollingRowIndex--;
                }
            }
            else if (e.Delta < 0)
            {
                if (dataGridViewCustomerAccountForm.FirstDisplayedScrollingRowIndex < dataGridViewCustomerAccountForm.RowCount - 1)
                {
                    dataGridViewCustomerAccountForm.FirstDisplayedScrollingRowIndex++;
                }
            }
        }




    }
}
