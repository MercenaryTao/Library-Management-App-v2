using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_App_v2.Model
{
    internal class Loan
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int MemberId { get; set; }
        public DateTime? DateBorrowed { get; set; }
        public DateTime? DueDate { get; set; }


        public Loan(int id, int bookId, int memberId, DateTime? dateBorrowed, DateTime? dueDate)
        {
            Id = id;
            BookId = bookId;
            MemberId = memberId;
            DateBorrowed = dateBorrowed;
            DueDate = dueDate;
        }

    }
}
