using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement.Model
{
    internal class FeedBack
    {
        private int id;
        private string title;
        private string description;
        private int rating;
        private int staffId;

        public FeedBack(int id, string title, string description,int rating, int staffId)
        {
            this.id = id;
            this.title = title;
            this.description = description;
            this.rating = rating;
            this.staffId = staffId;
        }

        public string Title { get => title; }
        public string Description { get => description;}
        public int StaffId { get => staffId; }
        public int Rating { get => rating; }
    }
}
