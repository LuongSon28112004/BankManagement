using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;

namespace BankManagement.Model
{
    internal class CustomerInforRepository
    {
        //Chuỗi kết nối database
        private string connectionString = $@"Data Source={getServerName.serverName};Initial Catalog=UTCBank;Integrated Security=True;Encrypt=False";

        //
        //private CustomerAccountWithInforRepository customerAccountWithInforRepository;

        //public CustomerInforRepository()
        //{
        //    customerAccountWithInforRepository = new CustomerAccountWithInforRepository();
        //}

        //Lấy ra thông tin của một khách hàng bằng CCCD----------------------------------------------------------------------------------------------------------------------------
        public CustomerInfor getCustomerInforByCccd(string customerInforCccd)//moi lan truy van chi duoc 1 customer
        {
            CustomerInfor customerInfor = null;

            string query = "SELECT id, name, cccd, phone_number, email, job, nationality , address, date_of_birth, photo , status , gender FROM customer_infor WHERE cccd = @Cccd";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString)) // Đảm bảo ngắt kết nối khi kết thúc khối lệnh
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn)) // Truy vấn
                    {
                        // Thêm tham số cccd vào truy vấn
                        cmd.Parameters.Add(new SqlParameter("@Cccd", SqlDbType.NVarChar) { Value = customerInforCccd });

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Lấy các cột từ kết quả truy vấn và khởi tạo đối tượng CustomerInfor
                                int id = reader.GetInt32(0);
                                string name = reader.GetString(1);
                                string cccd = reader.GetString(2);
                                string phone_number = reader.GetString(3);
                                string email = reader.GetString(4);
                                string job = reader.GetString(5);
                                string nationality = reader.GetString(6);
                                string address = reader.GetString(7);
                                DateTime date_of_birth = reader.GetDateTime(8);

                                // Kiểm tra nếu cột "photo" là DBNull, nếu không thì lấy giá trị của nó
                                string photo = reader.IsDBNull(9) ? null : reader.GetString(9);
                                string status = reader.GetString(10);
                                string gender = reader.GetString(11);

                                // Tạo đối tượng CustomerInfor từ dữ liệu truy vấn
                                customerInfor = new CustomerInfor(id, name, cccd, phone_number, email, job, nationality, address, date_of_birth, photo , status , gender);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                Console.WriteLine("Error: " + ex.Message);
            }

            return customerInfor; // Trả về đối tượng CustomerInfor hoặc null nếu không tìm thấy
        }





        //Lấy ra một list khách hàng bằng CCCD-------------------------------------------------------------------------------------------------------------------------------------------------
        public DataTable searchCustomerByCccd(string cccd)//moi lan truy van duoc nhieu customer voi chuoi tuong tu 
        {
            DataTable dataTableCustomerInfor = new DataTable();
            // Tạo truy vấn SQL sử dụng LIKE để tìm kiếm chuỗi tương tự
            string query = "SELECT id, name, cccd, phone_number, email, job, nationality, address, date_of_birth, photo , status , gender " + "FROM customer_infor " +"WHERE cccd LIKE @Cccd";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Sử dụng LIKE với ký tự `%` để tìm kiếm chuỗi cccd chứa chuỗi đầu vào
                        cmd.Parameters.AddWithValue("@Cccd", "%" + cccd + "%");

                        // Mở kết nối đến cơ sở dữ liệu
                        conn.Open();

                        // Sử dụng SqlDataAdapter để điền dữ liệu vào DataTable
                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd))
                        {
                            sqlDataAdapter.Fill(dataTableCustomerInfor);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý các ngoại lệ khác
                Console.WriteLine("Error: " + ex.Message);
            }

            // Trả về DataTable chứa các bản ghi tìm kiếm được
            return dataTableCustomerInfor;
        }





        //Lấy ra tất cả khách hàng để load lên dataGridView------------------------------------------------------------------------------------------------------------------------
        public DataTable LoadAllCustomer()
        {
            DataTable dt = new DataTable();
            string query = "SELECT * FROM customer_infor";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        conn.Open();

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý các ngoại lệ khác
                Console.WriteLine("Error: " + ex.Message);
            }

            return dt;
        }





        //Thêm một khách hàng------------------------------------------------------------------------------------------------------------------------------------------------------------
        public void addCustomer(CustomerInfor customerInfor)
        {
            string query = "INSERT INTO customer_Infor (name, cccd, phone_number, email, job, nationality, address, date_of_birth, photo, gender)" +
               "VALUES (@Name, @Cccd, @PhoneNumber, @Email, @Job, @Nationality, @Address, @DateOfBirth, @PhotoPath, @Gender)";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar) { Value = customerInfor.Name });
                        cmd.Parameters.Add(new SqlParameter("@Cccd", SqlDbType.NVarChar) { Value = customerInfor.Cccd });
                        cmd.Parameters.Add(new SqlParameter("@PhoneNumber", SqlDbType.NVarChar) { Value = customerInfor.PhoneNumber });
                        cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar) { Value = customerInfor.Email });
                        cmd.Parameters.Add(new SqlParameter("@Job", SqlDbType.NVarChar) { Value = customerInfor.Job });
                        cmd.Parameters.Add(new SqlParameter("@Nationality", SqlDbType.NVarChar) { Value = customerInfor.Nationality });
                        cmd.Parameters.Add(new SqlParameter("@Address", SqlDbType.NVarChar) { Value = customerInfor.Address });
                        cmd.Parameters.Add(new SqlParameter("@DateOfBirth", SqlDbType.Date) { Value = customerInfor.DateOfBirth.ToString("yyyy-MM-dd") });
                        if (customerInfor.PhotoPath != "")
                        {
                            cmd.Parameters.Add(new SqlParameter("@PhotoPath", SqlDbType.NVarChar) { Value = customerInfor.PhotoPath });
                        }
                        else
                        {
                            cmd.Parameters.Add(new SqlParameter("@PhotoPath", SqlDbType.NVarChar) { Value = DBNull.Value });
                        }
                        cmd.Parameters.Add(new SqlParameter("@Gender", SqlDbType.NVarChar) { Value = customerInfor.Gender });

                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }





        //Xoá một khách hàng--------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public void deleteCustomer(string cccd)
        {
            string query = "Update customer_Infor SET status = @Status WHERE cccd = @Cccd";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add(new SqlParameter("@Cccd", SqlDbType.NVarChar) { Value = cccd });
                        cmd.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar) { Value = "Inactive" });
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }





        //Cập nhật thông tin khách hàng-------------------------------------------------------------------------------------------------------------------------------------------------------------
        public void updateCustomer(CustomerInfor customerInfor)
        {
            string query = "UPDATE customer_Infor SET name = @Name, phone_number = @PhoneNumber, email = @Email, " +
                   "job = @Job, nationality = @Nationality, address = @Address, date_of_birth = @DateOfBirth, " +
                   "photo = @PhotoPath, gender = @Gender , status = @Status " +
                   "WHERE cccd = @Cccd"; // Không thay đổi cccd

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar) { Value = customerInfor.Name });
                        cmd.Parameters.Add(new SqlParameter("@Cccd", SqlDbType.NVarChar) { Value = customerInfor.Cccd });
                        cmd.Parameters.Add(new SqlParameter("@PhoneNumber", SqlDbType.NVarChar) { Value = customerInfor.PhoneNumber });
                        cmd.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar) { Value = customerInfor.Email });
                        cmd.Parameters.Add(new SqlParameter("@Job", SqlDbType.NVarChar) { Value = customerInfor.Job });
                        cmd.Parameters.Add(new SqlParameter("@Nationality", SqlDbType.NVarChar) { Value = customerInfor.Nationality });
                        cmd.Parameters.Add(new SqlParameter("@Address", SqlDbType.NVarChar) { Value = customerInfor.Address });
                        cmd.Parameters.Add(new SqlParameter("@DateOfBirth", SqlDbType.Date) { Value = customerInfor.DateOfBirth });

                        if (!string.IsNullOrEmpty(customerInfor.PhotoPath))
                        {
                            cmd.Parameters.Add(new SqlParameter("@PhotoPath", SqlDbType.NVarChar) { Value = customerInfor.PhotoPath });
                        }
                        else
                        {
                            cmd.Parameters.Add(new SqlParameter("@PhotoPath", SqlDbType.NVarChar) { Value = DBNull.Value });
                        }

                        cmd.Parameters.Add(new SqlParameter("@Gender", SqlDbType.NVarChar) { Value = customerInfor.Gender });
                        cmd.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar) { Value = "Active" });
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Update customer successful!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        // lấy một thông tin tài khoản khách hàng ra

        //public CustomerAccount getAccountCustomerBycustomerId(int customerId)
        //{
        //    return customerAccountWithInforRepository.getCustomerAccountByCustomerId(customerId);
        //}




    }
}
