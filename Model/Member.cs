using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_App_v2.Model
{
    internal class Member
    {
       //public int MemberId { get; set; }
       public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int BorrowedBooksCount { get; set; }
        public DateTime? SuspensionEndDate { get; set; }
        public Member( string name, string surname, string email, int bbCount, DateTime? suspensionEndDate)
        {
            //MemberId = memberId;
            Name = name;
            Surname = surname;
            Email = email;
            BorrowedBooksCount = bbCount;
            SuspensionEndDate = suspensionEndDate;
        }
        public bool IsSuspended
        {
            get
            {
                return SuspensionEndDate != null && SuspensionEndDate > DateTime.Now;
            }
        }
    }
}
