using BankManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement.ViewModel
{
	internal class InfoStaffViewModel
	{
		private StaffRepository staffRepository;

		//Các thuộc tính bind với InfoStaffForm
		private string staffName;
		private string userName;
		private string workingBranch;
		private string jobPosition;
		private string photoPath;

		public string GetStaffName() { return staffName; }
		public string GetUserName() { return userName; }
		public string GetWorkingBranch() { return workingBranch; }
		public string GetJobPosition() { return jobPosition; }
		public string GetPhotoPath() { return photoPath; }

		public InfoStaffViewModel()
		{
			staffRepository = new StaffRepository();
		}



		//Lấy thông tin từ repository
		public void LoadInfoStaff(int staffId)
		{
			Staff staff = staffRepository.GetStaffById(staffId);

			if (staff != null)
			{
				this.staffName = staff.GetName();
				this.userName = staff.GetUsername();
				this.workingBranch = staff.GetWorkingBranch();
				this.jobPosition = staff.GetJobPosition();
				this.photoPath = staff.GetPhotoPath();
			}
		}
	}
}
