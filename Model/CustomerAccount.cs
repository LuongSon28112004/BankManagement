using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement.Model
{
    internal class CustomerAccount
    {
        private int id;
        private string username;
        private string password;
        private Decimal balance;
        private DateTime date_opened;
        private int customer_id;
        private string account_status;
        private int account_number;

        public CustomerAccount(int id, string username, string password, Decimal balance, DateTime date_opened, int customer_id, string account_status, int account_number)
        {
            this.id = id;
            this.username = username;
            this.password = password;
            this.balance = balance;
            this.date_opened = date_opened;
            this.customer_id = customer_id;
            this.account_status = account_status;
            this.account_number = account_number;
        }

        public int Id { get => id; }
        public string Username { get => username; }
        public string Password { get => password; }
        public Decimal Balance { get => balance; }
        public DateTime Date_opened { get => date_opened; }
        public int Customer_id { get => customer_id; }
        public string Account_status { get => account_status; }
        public int Account_number { get => account_number; }
    }
}
