using BankManagement.Language;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;

namespace BankManagement.View
{
    public partial class DetailedNoticeForm : Form
    {
        LangHelper langHelper;
        public DetailedNoticeForm(string title, string message)
        {
            InitializeComponent();
            langHelper = new LangHelper();
            if (ConfigurationManager.AppSettings["Language"] != "")
            {
                langHelper.ChangeLanguage(ConfigurationManager.AppSettings["Language"]);
            }
            txtTitleDetailedNoticeForm.Text = title;
            txtContentDetailedNoticeForm.Text = message;
        }
        private void DetailedNoticeForm_Load(object sender, EventArgs e)
        {
            lbNotifications.Focus();
            lbNotifications.Text = langHelper.GetString("Notifications");
        }

        private void btnCloseDetailedNoticeForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
