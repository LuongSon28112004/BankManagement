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

        }

        private void btnDepositWithdrawTaskBarTransactionForm_Click(object sender, EventArgs e)
        {
            panelCustomerReceiveTransactionForm.Visible = false;
            btnDepositWithdrawTaskBarTransactionForm.CustomBorderThickness = new Padding(0, 0, 0, 1);
            btnTransferTaskBarTransactionForm.CustomBorderThickness = new Padding(0, 0, 0, 0);
            btnDepositWithdrawTaskBarTransactionForm.CustomBorderColor = Color.Aquamarine;
        }

        private void btnTransferTaskBarTransactionForm_Click(object sender, EventArgs e)
        {
            panelCustomerReceiveTransactionForm.Visible = true;
            btnDepositWithdrawTaskBarTransactionForm.CustomBorderThickness = new Padding(0, 0, 0, 0);
            btnTransferTaskBarTransactionForm.CustomBorderThickness = new Padding(0, 0, 0, 1);
            btnTransferTaskBarTransactionForm.CustomBorderColor = Color.Aquamarine;
            panelCustomerSendTransactionForm.Visible = false;
            panelCustomerSendTransactionForm.Visible = true;
        }
    }
}
