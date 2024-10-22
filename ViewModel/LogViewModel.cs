using BankManagement.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement.ViewModel
{
    internal class LogViewModel
    {
        private LogRepository logRepository;

        private DataTable logTable;

        public LogViewModel()
        {
            logRepository = new LogRepository();
        }

        public DataTable LogTable { get => logTable; set => logTable = value;}

        public void searchLogByStaffId(int id)
        {
            this.logTable = logRepository.searchLogByStaffId(id);
        }
    }
}
