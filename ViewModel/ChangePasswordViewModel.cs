using BankManagement.Language;
using BankManagement.Model;
using BankManagement.View;
using Org.BouncyCastle.Asn1.Pkcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Windows.Forms;

namespace BankManagement.ViewModel
{
    internal class ChangePasswordViewModel
    {
        private StaffRepository staffRepository;
        private int staffId;
        private string currentPassword;
        private string newPassword;
        private string reType;
        private string password;

        public string CurrentPassword { get => currentPassword; set => currentPassword = value;}
        public string NewPassword { get => newPassword; set => newPassword = value;}
        public string ReType { get => reType; set => reType = value;}
        public int StaffId { get => staffId; set => staffId = value;}

        public ChangePasswordViewModel()
        {
            staffRepository = new StaffRepository();
        }

        public bool ChangePassword()
        {
            Staff staff = staffRepository.GetStaffById(staffId);
            this.password = staff.GetPassword();
            this.newPassword = ComputeSha256Hash(this.newPassword);
            this.currentPassword = ComputeSha256Hash(this.currentPassword);
            if (this.currentPassword != this.password)
            {
                CustomMessageBox.ShowBox(LangHelper.Instance.GetString("Incorrect password!"), "Error");
                return false;
            }
            staffRepository.ChangePassword(this.newPassword, this.staffId);
            return true;
        }

        // Hàm mã hóa mật khẩu bằng SHA-256
        private static string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public void GetStaffById(int staffId)
        {
            
        }
    }
}
