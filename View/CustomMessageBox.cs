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
    public partial class CustomMessageBox : Form
    {
        public CustomMessageBox()
        {
            InitializeComponent();
        }

        static CustomMessageBox newMessageBox;
        static string Button_id;

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
                newMessageBox.lbTitle.Text = "Something went wrong!";
                newMessageBox.btnOk.FillColor = Color.FromArgb(255, 50, 70);
            }
            if (icon == "Success")
            {
                newMessageBox.imgIcon.Image = Image.FromFile("..\\..\\Resources\\success_icon.png");
                newMessageBox.lbTitle.Text = "Success!";
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
    }
}
