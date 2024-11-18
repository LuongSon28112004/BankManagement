using BankManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankManagement.ViewModel
{
    internal class SettingViewModel
    {
        private StaffRepository staffRepository;

        private string username;
        private string name;
        private string position;
        private string branch;
        private string email;
        private string photo;

        public string Username { get => username; set => username = value; }
        public string Name { get => name; set => name = value; }
        public string Position { get => position; set => position = value; }
        public string Branch { get => branch; set => branch = value; }
        public string Email { get => email; set => email = value; }
        public string Photo { get => photo; set => photo = value; }

        public SettingViewModel()
        {
            staffRepository = new StaffRepository();
        }
        public void GetStaffById(int staffId)
        {
            Staff staff = staffRepository.GetStaffById(staffId);
            this.username = staff.GetUsername();
            this.name = staff.GetName();
            this.position = staff.GetJobPosition();
            this.branch = staff.GetWorkingBranch();
            this.email = staff.GetEmail();
            this.photo = staff.GetPhotoPath();
        }

        public void DisableAccount(int staffId)
        {
            staffRepository.DisableAccount(staffId);
        }
    }
}
