using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement.Model
{
    internal class NotifyReponsitory
    {
        //Chuỗi kết nối database
        private string connectionString = $@"Data Source={getServerName.serverName};Initial Catalog=UTCBank;Integrated Security=True;Encrypt=False";

        public DataTable getAllNotifyByStaffId(int Id)
        {
            DataTable dt = new DataTable();
            // Thêm ORDER BY để sắp xếp thông báo theo thời gian tạo mới nhất đến sớm nhất
            string query = "SELECT title, message, DateCreated, isRead FROM staff_account sa JOIN staff_notification sn ON sa.id = sn.staff_id JOIN notifications n ON sn.notification_id = n.notificationID WHERE sa.id = @Id ORDER BY DateCreated DESC;";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", Id);
                        // Sử dụng SqlDataAdapter để điền dữ liệu vào DataTable
                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd))
                        {
                            sqlDataAdapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
			{
                // Xử lý lỗi nếu có
                Console.WriteLine("Error: " + ex.Message);
                throw;
            }
            return dt;
        }
    }
}
