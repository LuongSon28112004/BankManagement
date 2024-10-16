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
    public partial class TransactionForm : Form
    {
        public TransactionForm()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
        }

        private void TransactionForm_Load(object sender, EventArgs e)
        {
            btnDepositWithdrawTaskBarTransactionForm.HoverState.FillColor = Color.FromArgb(50, 50, 50);
            btnTransferTaskBarTransactionForm.HoverState.FillColor = Color.FromArgb(50, 50, 50);
        }

        private void btnDepositWithdrawTaskBarTransactionForm_Click(object sender, EventArgs e)
        {
            btnDepositWithdrawTaskBarTransactionForm.ForeColor = Color.FromArgb(255, 255, 255);
            btnTransferTaskBarTransactionForm.ForeColor = Color.FromArgb(170, 170, 170);
            btnDepositWithdrawTaskBarTransactionForm.CustomBorderThickness = new Padding(0, 0, 0, 1);
            btnTransferTaskBarTransactionForm.CustomBorderThickness = new Padding(0, 0, 0, 0);
            btnDepositWithdrawTaskBarTransactionForm.CustomBorderColor = Color.Aquamarine;

            panelCustomerReceiveTransactionForm.Visible = false; //Ẩn panel người nhận

        }

        private void btnTransferTaskBarTransactionForm_Click(object sender, EventArgs e)
        {
            btnDepositWithdrawTaskBarTransactionForm.ForeColor = Color.FromArgb(170, 170, 170);
            btnTransferTaskBarTransactionForm.ForeColor = Color.FromArgb(255, 255, 255);
            btnDepositWithdrawTaskBarTransactionForm.CustomBorderThickness = new Padding(0, 0, 0, 0);
            btnTransferTaskBarTransactionForm.CustomBorderThickness = new Padding(0, 0, 0, 1);
            btnTransferTaskBarTransactionForm.CustomBorderColor = Color.Aquamarine;

            panelCustomerReceiveTransactionForm.Visible = true; //Hiện panel người nhận

            //Tạo hiệu ứng bật lại
            panelCustomerSendTransactionForm.Visible = false;
            panelCustomerSendTransactionForm.Visible = true;
        }
    }
}
