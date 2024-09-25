using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagement.Model
{
    internal class CustomerInfor
    {
        private int id;
        private string name;
        private string phoneNumber;
        private DateTime dateOfBirth;
        private string cccd;
        private string email;
        private string job;
        private string nationality;
        private string address;
        private string photoPath;

        public CustomerInfor(int id, string name, string cccd, string phoneNumber, string email, string job, string nationality, string address, DateTime dateOfBoth, string photoPath)
        {
            this.id = id;
            this.name = name;
            this.cccd = cccd;
            this.phoneNumber = phoneNumber;
            this.email = email;
            this.job = job;
            this.nationality = nationality;
            this.address = address;
            this.dateOfBirth = dateOfBoth;
            this.photoPath = photoPath;
        }

        public int Id { get => id; }
        public string Name { get => name; }
        public string Cccd { get => cccd; }
        public string PhoneNumber { get => phoneNumber; }
        public string Email { get => email; }
        public string Job { get => job; }
        public string Nationality { get => nationality; }
        public string Address { get => address; }
        public DateTime DateOfBirth { get => dateOfBirth; }
        public string PhotoPath { get => photoPath; }
    }
}
