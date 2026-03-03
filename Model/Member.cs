using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_App_v2.Model
{
    internal class Member
    {
       public int MemberId { get; set; }
       public string Name { get; set; }
        public string Surname { get; set; }

        public string Email { get; set; }
        public Member(int memberId, string name, string surname, string email)
        {
            MemberId = memberId;
            Name = name;
            Surname = surname;
            Email   = email;
        }

    }
}
