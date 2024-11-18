using BankManagement.Language;
using BankManagement.View;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Windows.Forms;

namespace BankManagement.Model
{
	internal class StaffRepository
	{
		//Chuỗi kết nối database
		private string connectionString = getConnectionString.connectionString;

		public StaffRepository()
		{
        }


		// Phương thức lấy thông tin Staff từ bảng staff_account bằng ID
		public Staff GetStaffById(int staffId)
		{
			Staff staff = null;

			string query = "SELECT TOP 1 id, name, username, password, working_branch, job_position, staff_photo, email, status FROM staff_account WHERE id = @id";

			try
			{
				using (SqlConnection conn = new SqlConnection(connectionString)) //Đảm bảo ngắt kết nối khi kết thúc khối lệnh
				{
					conn.Open();

					using (SqlCommand cmd = new SqlCommand(query, conn)) //Truy vấn
					{
						// Thêm tham số id vào truy vấn
						cmd.Parameters.AddWithValue("@id", staffId);

						using (SqlDataReader reader = cmd.ExecuteReader())
						{
							if (reader.Read())
							{
								// Lấy các cột từ kết quả truy vấn và khởi tạo đối tượng Staff
								int id = reader.GetInt32(0);
								string name = reader.GetString(1);
								string username = reader.GetString(2);
								string password = reader.GetString(3);
								string workingBranch = reader.GetString(4);
								string jobPosition = reader.GetString(5);
								string staffPhoto = reader.GetString(6);
								string email = reader.GetString(7);
								string status = reader.GetString(8);
								// Tạo đối tượng Staff từ dữ liệu truy vấn
								staff = new Staff(id, name, username, password, workingBranch, jobPosition, staffPhoto, email, status);
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
                // Ném lại ngoại lệ để form cha có thể xử lý
                throw new Exception("Error: " + ex.Message, ex);
            }

			return staff; // Trả về đối tượng Staff hoặc null nếu không tìm thấy
		}



		//Phương thức lấy thông tin staff bằng username và password
		public Staff GetStaffByUsernamePassword(string username, string password)
		{
			Staff staff = null;

			string query = "SELECT TOP 1 id, name, username, password, working_branch, job_position, staff_photo, email, status FROM staff_account WHERE username = @username AND password = @password";

			try
			{
				using (SqlConnection conn = new SqlConnection(connectionString)) //Đảm bảo ngắt kết nối khi kết thúc khối lệnh
				{
					conn.Open();

					using (SqlCommand cmd = new SqlCommand(query, conn)) //Truy vấn
					{
						// Thêm tham số vào truy vấn
						cmd.Parameters.AddWithValue("@username", username);
						cmd.Parameters.AddWithValue("@password", password);

						using (SqlDataReader reader = cmd.ExecuteReader())
						{
							if (reader.Read())
							{
								// Lấy các cột từ kết quả truy vấn và khởi tạo đối tượng Staff
								int id = reader.GetInt32(0);
								string name = reader.GetString(1);
								string staffUsername = reader.GetString(2);
								string staffPassword = reader.GetString(3);
								string workingBranch = reader.GetString(4);
								string jobPosition = reader.GetString(5);
								string staffPhoto = reader.GetString(6);
								string email = reader.GetString(7);
								string status = reader.GetString(8);

								// Tạo đối tượng Staff từ dữ liệu truy vấn
								staff = new Staff(id, name, username, password, workingBranch, jobPosition, staffPhoto, email, status);
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
                // Ném lại ngoại lệ để form cha có thể xử lý
                throw new Exception("Error: " + ex.Message, ex);
            }

			return staff; // Trả về đối tượng Staff hoặc null nếu không tìm thấy
		}



		//Phương thức vô hiệu hoá tài khoản
        public void DisableAccount(int staffId)
        {
            string query = "UPDATE staff_account SET status = 'disabled' WHERE id = @id";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString)) // Đảm bảo ngắt kết nối sau khi thực thi
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn)) // Thực thi truy vấn
                    {
                        // Thêm tham số vào truy vấn
                        cmd.Parameters.AddWithValue("@id", staffId);
                        // Thực thi truy vấn
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Ném lại ngoại lệ để form cha có thể xử lý
                throw new Exception("Error: " + ex.Message, ex);
            }
        }





        //Phương thức đổi mật khẩu
        public void ChangePassword(string password, int staffId)
        {
            string query = "UPDATE staff_account SET password = @password WHERE id = @id";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString)) // Đảm bảo ngắt kết nối sau khi thực thi
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn)) // Thực thi truy vấn
                    {
                        // Thêm tham số vào truy vấn
                        cmd.Parameters.AddWithValue("@id", staffId);
                        cmd.Parameters.AddWithValue("@password", password);
                        // Thực thi truy vấn
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Ném lại ngoại lệ để form cha có thể xử lý
                throw new Exception("Error: " + ex.Message, ex);
            }
        }
    }
}
