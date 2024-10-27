using BankManagement.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement.ViewModel
{
    internal class NotifyViewModel
    {
        private NotifyReponsitory notifyReponsitory;
        private DataTable notifyTable;
        public NotifyViewModel()
        {
            notifyReponsitory = new NotifyReponsitory();
        }

        public DataTable NotifyTable { get => notifyTable; set => notifyTable = value; }

        public void getAllNotifyByStaffId(int SatffId)
        {
            notifyTable = notifyReponsitory.getAllNotifyByStaffId(SatffId);
        }
    }
}
