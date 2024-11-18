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
    public partial class CustomMessageBox : Form
    {
        static CustomMessageBox newMessageBox;
        static string Button_id;
        public CustomMessageBox()
        {
            InitializeComponent();
        }

        private void CustomMessageBox_Load(object sender, EventArgs e)
        {

        }

        public static string ShowBox(string txtMessage)
        {
            newMessageBox = new CustomMessageBox();
            newMessageBox.txtMessage.Text = txtMessage;
            newMessageBox.ShowDialog();
            return Button_id;
        }

        public static string ShowBox(string txtMessage, string icon)
        {
            newMessageBox = new CustomMessageBox();
            if (icon == "Error")
            {
                newMessageBox.imgIcon.Image = Image.FromFile("..\\..\\Resources\\warning_icon.png");
                newMessageBox.lbTitle.Text = LangHelper.Instance.GetString("Warning!");
                newMessageBox.btnOk.FillColor = Color.FromArgb(255, 50, 70);
            }
            if (icon == "Success")
            {
                newMessageBox.imgIcon.Image = Image.FromFile("..\\..\\Resources\\success_icon.png");
                newMessageBox.lbTitle.Text = LangHelper.Instance.GetString("Success!");
                newMessageBox.btnOk.FillColor = Color.FromArgb(70, 180, 110);
            }

            newMessageBox.txtMessage.Text = txtMessage;
            newMessageBox.ShowDialog();
            return Button_id;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Button_id = "1";
            newMessageBox.Dispose();
        }

        private void txtMessage_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void txtMessage_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Button_id = "0";
            newMessageBox.Dispose();
        }
    }
}
