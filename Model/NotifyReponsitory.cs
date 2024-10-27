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
            string query = "SELECT staff_id, notification_id, title, message, DateCreated, isRead FROM staff_account sa JOIN staff_notification sn ON sa.id = sn.staff_id JOIN notifications n ON sn.notification_id = n.notificationID WHERE sa.id = @Id ORDER BY DateCreated DESC;";
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
                // Ném lại ngoại lệ để form cha có thể xử lý
                throw new Exception("Lỗi: " + ex.Message, ex);
            }
            return dt;
        }

        public void markAsRead(int staffId, int notificationId)
        {
            string query = "UPDATE staff_notification SET isRead = 1 WHERE staff_id = @staffId AND notification_id = @notificationId;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Thêm tham số vào câu truy vấn
                        cmd.Parameters.Add("@staffId", SqlDbType.Int).Value = staffId;
                        cmd.Parameters.Add("@notificationId", SqlDbType.Int).Value = notificationId;

                        // Thực thi câu lệnh
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có
                throw new Exception("Lỗi khi đánh dấu là đã đọc: " + ex.Message, ex);
            }
        }
    }
}
