using BankManagement.Model;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement.ViewModel
{
	internal class LoginViewModel
	{
		private StaffRepository staffRepository;

		//Các thuộc tính bind với LoginForm
		private int id;

		public int GetID() { return id; }

		public LoginViewModel()
		{
			staffRepository = new StaffRepository();
		}

		public void LoadLogin(string username, string password)
		{
			//Chuyển password sang chuỗi mã hoá
			string hashedPassword = ComputeSha256Hash(password);

			//Truy vấn thông tin từ txtUsername và txtPassword
			Staff staff = staffRepository.GetStaffByUsernamePassword(username, hashedPassword);

			if (staff != null)
			{
				this.id = staff.GetId(); //Nếu có tài khoản này trong csdl thì lấy ra ID
			}
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
	}
}
