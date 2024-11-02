using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankManagement.Model
{
    internal class LoanRepository
    {
        //Chuỗi kết nối database
        private string connectionString = $@"Data Source={getServerName.serverName};Initial Catalog=UTCBank;Integrated Security=True;Encrypt=False";


        //Tạo 1 khoản vay
        public void addLoan(Loan loan)
        {
            string query = "insert into Loan(principal_amount, loan_date, interest_rate, note, account_customer_loan_id, staff_account_loan_id, last_payment_date, paid_status, loan_term) " +
                           "values(@Principal_amount, @Loan_date, @Interest_rate, @Note, @Account_customer_loan_id, @Staff_account_loan_id, @Last_payment_date, @Paid_status, @Loan_Term)";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add(new SqlParameter("@Principal_amount", SqlDbType.Money) { Value = loan.Principal_amount });
                        cmd.Parameters.Add(new SqlParameter("@Loan_date", SqlDbType.Date) { Value = loan.Loan_date });
                        cmd.Parameters.Add(new SqlParameter("@Interest_rate", SqlDbType.Float) { Value = loan.Interest_Rate });
                        cmd.Parameters.Add(new SqlParameter("@Note", SqlDbType.NVarChar) { Value = loan.Note });
                        cmd.Parameters.Add(new SqlParameter("@Account_customer_loan_id", SqlDbType.Int) { Value = loan.CustomerAccountId });
                        cmd.Parameters.Add(new SqlParameter("@Staff_account_loan_id", SqlDbType.Int) { Value = loan.StaffAccountId });
                        cmd.Parameters.Add(new SqlParameter("@Last_payment_date", SqlDbType.Date) { Value = loan.LastPaymentDate });
                        cmd.Parameters.Add(new SqlParameter("@Paid_status", SqlDbType.Bit) { Value = loan.Paid_status });
                        cmd.Parameters.Add(new SqlParameter("@Loan_Term", SqlDbType.Int) { Value = loan.LoanTerm });

                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Ném lại ngoại lệ để form cha có thể xử lý
                throw new Exception("Lỗi: " + ex.Message, ex);
            }
        }





        //Kiểm tra xem tài khoản này có đang phải trả khoản vay nào không
        public bool InPaymentPeriod(int id)
        {
            string query = "select count(*) from Loan where account_customer_loan_id = @Id AND paid_status = 0";
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id); // Thêm tham số cho câu truy vấn
                        return (int)cmd.ExecuteScalar() != 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message, ex); // Chỉ ném ngoại lệ mà không trả về false
            }
        }

        public DataTable getLoanByIdAccount(int idAccount)
        {
            DataTable dt = new DataTable();
            string query = "select * from Loan where account_customer_loan_id = @IdAccount and paid_status = 0";
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add(new SqlParameter("@IdAccount", SqlDbType.Int) { Value = idAccount });
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message, ex);
            }
            return dt;
        }

        public void updateLoan(DateTime lastPaymentDate, bool paid_status , bool isPaid , int loanId)
        {
            string query = "UPDATE loan SET last_payment_date = @LastPaymentDate, paid_status = @Status , isPaid = @IsPaid WHERE id = @LoanId";
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.Add(new SqlParameter("@LastPaymentDate", SqlDbType.Date) { Value = lastPaymentDate });
                        cmd.Parameters.Add(new SqlParameter("@Status", SqlDbType.Bit) { Value = paid_status });
                        cmd.Parameters.Add(new SqlParameter("@IsPaid", SqlDbType.Bit) { Value = isPaid });
                        cmd.Parameters.Add(new SqlParameter("@LoanId", SqlDbType.Int) { Value = loanId }); // Đảm bảo loanId có giá trị trước khi gọi hàm

                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message, ex);
            }
        }

        //cap nhat xem nau da dong lai dung han thi cho column isPaid = true;
        public void updateIsPaid(bool isPaid , int loanId)
        {
            string query = "UPDATE loan set isPaid = @IsPaid WHERE id = @LoanId";
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open() ;
                    using (SqlCommand cmd = new SqlCommand(query,con))
                    {
                        cmd.Parameters.Add(new SqlParameter("@IsPaid", SqlDbType.Bit) { Value = isPaid });
                        cmd.Parameters.Add(new SqlParameter("@LoanId", SqlDbType.Int) { Value = loanId }); // Đảm bảo loanId có giá trị trước khi gọi hàm

                        cmd.ExecuteNonQuery();
                    }
                }
            }catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message, ex);
            }
        }

    }
}
