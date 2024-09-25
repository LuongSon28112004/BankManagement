using BankManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement.ViewModel
{
	internal class MainViewModel
	{
		private StaffRepository staffRepository;

		//Các thuộc tính bind với MainForm
		private string photoPath;
		private string staffName;

		public string GetPhotoPath() {  return photoPath; }
		public string GetStaffName() { return staffName; }

		public MainViewModel()
		{
			staffRepository = new StaffRepository();
		}

		public void LoadStaff(int staffId)
		{
			Staff staff = staffRepository.GetStaffById(staffId);
			
			if (staff != null)
			{
				this.photoPath = staff.GetPhotoPath();
				this.staffName = staff.GetName();
			}
		}
	}
}
