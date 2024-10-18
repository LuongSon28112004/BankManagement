using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankManagement.Model
{
	internal class TransactionReponsitory
	{
		//Chuỗi kết nối database
		private string connectionString = $@"Data Source={getServerName.serverName};Initial Catalog=UTCBank;Integrated Security=True;Encrypt=False";

		//thêm một transaction transfer vào trong cơ sở dữ liệu 
		public void addTransactionTransfer(Transaction transaction)
		{
			string query = "INSERT INTO transaction_transfer (amount , date , note ,account_customer_send, account_customer_receive , staff_account_transfer_id)" +
				"VALUES(@Amount,@Date,@Note,@Account_customer_send,@Account_customer_receive,@Staff_account_transfer_id)";
			try
			{
				using (SqlConnection conn = new SqlConnection(connectionString))
				{
					conn.Open();
					using (SqlCommand cmd = new SqlCommand(query, conn))
					{
						cmd.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Decimal) { Value = transaction.Amount });
						cmd.Parameters.Add(new SqlParameter("@Date", SqlDbType.Date) { Value = transaction.Date });
						cmd.Parameters.Add(new SqlParameter("@Note", SqlDbType.NVarChar) { Value = transaction.Note });
						cmd.Parameters.Add(new SqlParameter("@Account_customer_send", SqlDbType.Int) { Value = transaction.Account_customer_send_id });
						cmd.Parameters.Add(new SqlParameter("@Account_customer_receive", SqlDbType.Int) { Value = transaction.Account_customer_receive_id });
						cmd.Parameters.Add(new SqlParameter("@Staff_account_transfer_id", SqlDbType.Int) { Value = transaction.Staff_account_transfer_id });
						cmd.ExecuteNonQuery();
					}
				}
				MessageBox.Show("Thêm giao dịch thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}

		}

		//thêm một transaction deposit vào trong sơ sở dữ liệu
		public void addTransactionDeposit(Transaction transaction)
		{
			string query = "INSERT INTO transaction_deposit (amount , date , note ,account_customer_deposit_id , staff_account_deposit_id)" +
				"VALUES(@Amount,@Date,@Note,@Account_customer_deposit_id,@Staff_account_deposit_id)";
			try
			{
				using (SqlConnection conn = new SqlConnection(connectionString))
				{
					conn.Open();
					using (SqlCommand cmd = new SqlCommand(query, conn))
					{
						cmd.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Decimal) { Value = transaction.Amount });
						cmd.Parameters.Add(new SqlParameter("@Date", SqlDbType.Date) { Value = transaction.Date });
						cmd.Parameters.Add(new SqlParameter("@Note", SqlDbType.NVarChar) { Value = transaction.Note });
						cmd.Parameters.Add(new SqlParameter("@Account_customer_deposit_id", SqlDbType.Int) { Value = transaction.Account_customer_send_id });
						cmd.Parameters.Add(new SqlParameter("@Staff_account_deposit_id", SqlDbType.Int) { Value = transaction.Staff_account_transfer_id });
						cmd.ExecuteNonQuery();
					}
				}
				MessageBox.Show("Thêm giao dịch thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}

		}

		//thêm một transaction withdraw vào trong cơ sở dữ liệu
		public void addTransactionWithdraw(Transaction transaction)
		{
			string query = "INSERT INTO transaction_withdraw (amount , date , note ,account_customer_withdraw_id , staff_account_withdraw_id)" +
				"VALUES(@Amount,@Date,@Note,@Account_customer_withdraw_id,@Staff_account_withdraw_id)";
			try
			{
				using (SqlConnection conn = new SqlConnection(connectionString))
				{
					conn.Open();
					using (SqlCommand cmd = new SqlCommand(query, conn))
					{
						cmd.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Decimal) { Value = transaction.Amount });
						cmd.Parameters.Add(new SqlParameter("@Date", SqlDbType.Date) { Value = transaction.Date });
						cmd.Parameters.Add(new SqlParameter("@Note", SqlDbType.NVarChar) { Value = transaction.Note });
						cmd.Parameters.Add(new SqlParameter("@Account_customer_withdraw_id", SqlDbType.Int) { Value = transaction.Account_customer_send_id });
						cmd.Parameters.Add(new SqlParameter("@Staff_account_withdraw_id", SqlDbType.Int) { Value = transaction.Staff_account_transfer_id });
						cmd.ExecuteNonQuery();
					}
				}
				MessageBox.Show("Thêm giao dịch thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}

		}
	}
}
