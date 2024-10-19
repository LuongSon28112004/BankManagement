using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace BankManagement.Model
{
	internal class Transaction
	{
		//Các thuộc tính của transaction
		private int id;
		private Decimal amount;
		private DateTime date;
		string note;
		private int account_customer_send_id;
		private int account_customer_receive_id;
		private int staff_account_transfer_id;

		//constructor
		public Transaction(int id, decimal amount, DateTime date, string note, int account_customer_send_id, int account_customer_receive_id, int staff_account_transfer)
		{
			this.id = id;
			this.amount = amount;
			this.date = date;
			this.note = note;
			this.account_customer_send_id = account_customer_send_id;
			this.account_customer_receive_id = account_customer_receive_id;
			this.staff_account_transfer_id = staff_account_transfer;
		}

		//getter and setter
		public int Id { get => id; set => id = value; }
		public decimal Amount { get => amount;  }
		public DateTime Date { get => date;  }
		public string Note { get => note;  }
		public int Account_customer_send_id { get => account_customer_send_id; }
		public int Account_customer_receive_id { get => account_customer_receive_id; }
		public int Staff_account_transfer_id { get => staff_account_transfer_id; }
	}
}
