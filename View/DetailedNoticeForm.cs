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
    public partial class DetailedNoticeForm : Form
    {
        public DetailedNoticeForm(string title, string message)
        {
            InitializeComponent();
            txtTitleDetailedNoticeForm.Text = title;
            txtContentDetailedNoticeForm.Text = message;
        }

        private void btnCloseDetailedNoticeForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DetailedNoticeForm_Load(object sender, EventArgs e)
        {
            lbNotificationsLogForm.Focus();
        }
    }
}
