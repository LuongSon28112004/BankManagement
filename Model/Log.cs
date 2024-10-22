using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement.Model
{
    internal class Log
    {
        private int id;
        private int staffId;
        private DateTime? time;
        private string content;

        public Log(int id, int staff_id, DateTime? time, string content)
        {
            this.id = id;
            this.staffId = staff_id;
            this.time = time;
            this.content = content;
        }

        public int StaffId { get => staffId; set => staffId = value; }
        public string Content { get => content; set => content = value; }
    }
}
