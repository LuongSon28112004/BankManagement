using BankManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement.ViewModel
{
    internal class FeedBackViewModel
    {
        //model------------------------------------------------------------------------------------------------------------------------
        FeedBackReponsitory feedBackReponsitory;

        //các thuộc tính bind với FeedBackForm
        private int staffId;
        private string title;
        private string description;
        private int rating;


        //constructor--------------------------------------------------------------------------------------------------------------------
        public FeedBackViewModel()
        {
            feedBackReponsitory = new FeedBackReponsitory();
        }

        //getter and setter--------------------------------------------------------------------------------------------------------------- 
        public int StaffId { get => staffId; set => staffId = value; }
        public string Title { get => title; set => title = value; }
        public string Description { get => description; set => description = value; }
        public int Rating { get => rating; set => rating = value; }

        //thêm một Feedback vào cơ sở dữ liệu bằng việc gọi đến model tương ứng ------------------------------------------------------------------------------------------------
        public void addFeedBack()
        {
            FeedBack feedBack = new FeedBack(0,this.title,this.description,this.rating,this.staffId);
            feedBackReponsitory.addFeedBack(feedBack);
        }
    }
}
