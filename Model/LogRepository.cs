using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace BankManagement.Model
{
    internal class LogRepository
    {
        //Chuỗi kết nối database
        private string connectionString = $@"Data Source={getServerName.serverName};Initial Catalog=UTCBank;Integrated Security=True;Encrypt=False";

        //Lấy ra list log bằng staff_id -------------------------------------------------------------------------------------------------------------------------------------------------
        public DataTable searchLogByStaffId(int id)
        {
            DataTable dataTableLog = new DataTable();

            // Lệnh truy vấn
            string query = @"
            SELECT id, staff_id, content, time 
            FROM log 
            WHERE staff_id = @staffId 
            AND time >= DATEADD(day, -7, GETDATE()) 
            ORDER BY time DESC"; // Sắp xếp theo thời gian từ sớm nhất đến lâu nhất

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Sử dụng LIKE với ký tự `%` để tìm kiếm chuỗi cccd chứa chuỗi đầu vào
                        cmd.Parameters.AddWithValue("@staffId", id);

                        // Mở kết nối đến cơ sở dữ liệu
                        conn.Open();

                        // Sử dụng SqlDataAdapter để điền dữ liệu vào DataTable
                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd))
                        {
                            sqlDataAdapter.Fill(dataTableLog);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Ném lại ngoại lệ
                throw new Exception("Lỗi: " + ex.Message, ex);
            }

            // Trả về DataTable chứa các bản ghi tìm kiếm được
            return dataTableLog;
        }

        public void AddLog(Log log)
        {
            // Lệnh truy vấn để thêm bản ghi mới vào bảng log
            string query = "INSERT INTO log (staff_id, content) VALUES (@staffId, @content)";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Thêm tham số vào câu truy vấn
                        cmd.Parameters.AddWithValue("@staffId", log.StaffId);
                        cmd.Parameters.AddWithValue("@content", log.Content);

                        // Mở kết nối đến cơ sở dữ liệu
                        conn.Open();

                        // Thực thi câu lệnh INSERT
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ
                throw new Exception("Lỗi: " + ex.Message, ex);
            }
        }
    }
}
