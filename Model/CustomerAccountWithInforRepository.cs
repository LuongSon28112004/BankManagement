using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BankManagement.Model
{
    internal class CustomerAccountWithInforRepository
    {
        //Chuỗi kết nối database
        private string connectionString = $@"Data Source={getServerName.serverName};Initial Catalog=UTCBank;Integrated Security=True;Encrypt=False";

        public CustomerAccountWithInforRepository()
        {
        }





        //Tìm kiếm theo account number và trả về một danh sách thông tin khách hàng và tài khoản tương ứng-------------------------------------------------------------------------------------------
        public DataTable SearchCustomerAccountByAccountNumber(int account_number)
        {
            DataTable dataTableCustomerAccountInfor = new DataTable();

            string query = "SELECT a.id ,b.cccd ,b.name ,b.gender ,a.account_number, a.username, a.account_status," +
                " b.date_of_birth, b.address, b.email, b.photo, b.status, a.date_opened, a.balance " +
                "FROM customer_account a inner join customer_infor b ON a.customer_id = b.id " +
                "Where cast(account_number as nvarchar) LIKE @Account_number ";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString)) // Đảm bảo ngắt kết nối khi kết thúc khối lệnh
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn)) // Truy vấn
                    {
                        // Thêm tham số AccountNumber vào truy vấn
                        cmd.Parameters.Add(new SqlParameter("@Account_number", SqlDbType.NVarChar) { Value = "%" + account_number.ToString() + "%" });
                        // Sử dụng SqlDataAdapter để điền dữ liệu vào DataTable
                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd))
                        {
                            sqlDataAdapter.Fill(dataTableCustomerAccountInfor);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                Console.WriteLine("Error: " + ex.Message);
            }

            return dataTableCustomerAccountInfor; // Trả về danh sách thông tin khách hàng và tài khoản tương ứng
        }





        //Tìm kiếm theo account number và trả về một danh sách thông tin khách hàng và tài khoản tương ứng-------------------------------------------------------------------------------------------
        public DataTable SearchCustomerAccountByCccd(string cccd)
        {
            DataTable dataTableCustomerAccountInfor = new DataTable();

            string query = "SELECT a.id ,b.cccd ,b.name ,b.gender ,a.account_number, a.username, a.account_status," +
                " b.date_of_birth, b.address, b.email, b.photo, b.status, a.date_opened, a.balance " +
                "FROM customer_account a INNER JOIN customer_infor b ON a.customer_id = b.id " +
                "WHERE b.cccd LIKE @Cccd";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString)) // Đảm bảo ngắt kết nối khi kết thúc khối lệnh
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn)) // Truy vấn
                    {
                        // Thêm tham số CCCD vào truy vấn
                        cmd.Parameters.Add(new SqlParameter("@Cccd", SqlDbType.NVarChar) { Value = "%" + cccd + "%" });
                        // Sử dụng SqlDataAdapter để điền dữ liệu vào DataTable
                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd))
                        {
                            sqlDataAdapter.Fill(dataTableCustomerAccountInfor);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                Console.WriteLine("Error: " + ex.Message);
            }

            return dataTableCustomerAccountInfor; // Trả về danh sách thông tin khách hàng và tài khoản tương ứng
        }






        //Lấy ra thông tin tất cả các khách hàng và tài khoản tương ứng--------------------------------------------------------------------------------------------------------------------------------------------
        public DataTable LoadAllAccount()
        {
            DataTable dataTableAccount = new DataTable();
            string query = "select a.id, b.cccd, b.name, b.gender, a.account_number, a.username, a.account_status, b.date_of_birth, b.address, b.email, b.photo, b.status, a.date_opened, a.balance " +
                "FROM customer_account a inner join customer_infor b ON a.customer_id = b.id";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd))
                        {
                            sqlDataAdapter.Fill(dataTableAccount);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return dataTableAccount;
        }





        //Thêm một tài khoản----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public void AddCustomerAccount(CustomerAccount customerAccount)
        {
            string query = "INSERT INTO customer_account (username, password, balance, date_opened, customer_id, account_status, account_number)" +
                " VALUES (@Username, @Password, @Balance, @Date_opened, @Customer_id, @Account_status ,@Account_number);";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add(new SqlParameter("@Username", SqlDbType.NVarChar) { Value = customerAccount.Username });
                        cmd.Parameters.Add(new SqlParameter("@Password", SqlDbType.NVarChar) { Value = customerAccount.Password });
                        cmd.Parameters.Add(new SqlParameter("@Balance", SqlDbType.Decimal) { Value = customerAccount.Balance });
                        cmd.Parameters.Add(new SqlParameter("@Date_opened", SqlDbType.Date) { Value = customerAccount.Date_opened.ToString("yyyy-MM-dd") });
                        cmd.Parameters.Add(new SqlParameter("@Customer_id", SqlDbType.Int) { Value = customerAccount.Customer_id });
                        cmd.Parameters.Add(new SqlParameter("@Account_status", SqlDbType.NVarChar) {  Value = customerAccount.Account_status });
                        cmd.Parameters.Add(new SqlParameter("@Account_number", SqlDbType.NVarChar) { Value = customerAccount.Account_number });

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
        //Lấy ra số tài khoản lớn nhất
        public int getMaxAccountNumber()
        {
            int maxAccountNumber = 0;
            string query = "SELECT MAX(account_number) FROM customer_account";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            maxAccountNumber = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                Console.WriteLine("Error: " + ex.Message);
            }

            return maxAccountNumber;
        }





        //Lấy ra 1 tài khoản bằng userName------------------------------------------------------------------------------------------------------------------------------
        public CustomerAccount getCustomerAccountByUserName(string user_name)
        {
            CustomerAccount customerAccount = null;
            string query = "SELECT * from customer_account where username = @Username";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add(new SqlParameter("@Username", SqlDbType.NVarChar) { Value = user_name });
                        using(SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string username = reader.GetString(1);
                                string password = reader.GetString(2);
                                Decimal balance = reader.GetDecimal(3);
                                DateTime date_opened = reader.GetDateTime(4);
                                int customerId = reader.GetInt32(5);
                                string account_status = reader.GetString(6);
                                int accountNumber = reader.GetInt32(7);
                                customerAccount = new CustomerAccount(id, username, password, balance, date_opened, customerId, account_status, accountNumber);
                            }
                        }
                    }
                }    
            }
            catch(Exception ex)
            {
                // Xử lý lỗi nếu có
                Console.WriteLine("Error: " + ex.Message);
            }
            return customerAccount;
        }





        //Xoá tài khoản----------------------------------------------------------------------------------------------------------------------------------------------------
        public void deleteCustomerAccount(int accountNumber)
        {
            string query = "Update customer_account SET account_status = @Status WHERE account_number = @AccountNumber";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add(new SqlParameter("@AccountNumber", SqlDbType.Int) { Value = accountNumber });
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





        //Active tài khoản---------------------------------------------------------------------------------------------------------------------------------------------------------
        public void updateStatusAccountCustomer(int accountNumber)
        {
            string query = "Update customer_account SET account_status = @Status WHERE account_number = @AccountNumber";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add(new SqlParameter("@AccountNumber", SqlDbType.Int) { Value = accountNumber });
                        cmd.Parameters.Add(new SqlParameter("@Status", SqlDbType.NVarChar) { Value = "Active" });
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Khôi phục tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

		public bool updateAccountBalance(Decimal amount, int accountNumber)
		{
			// Cập nhật câu lệnh SQL với tham số @Amount
			string query = "UPDATE customer_account SET balance = balance + @Amount WHERE account_number = @AccountNumber";

			try
			{
				using (SqlConnection conn = new SqlConnection(connectionString))
				{
					conn.Open();

					using (SqlCommand cmd = new SqlCommand(query, conn))
					{
						// Thêm tham số @AccountNumber
						cmd.Parameters.Add(new SqlParameter("@AccountNumber", SqlDbType.Int) { Value = accountNumber });

						// Thêm tham số @Amount
						cmd.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Int) { Value = amount });

						int rowsAffected = cmd.ExecuteNonQuery();
						if (rowsAffected > 0)
						{
							return true;
						}
						return false;
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
				return false;
			}
		}


	}
}
