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
        //public int BookId { get; set; }
        //public int MemberId { get; set; }
        public bool IsReturned { get; set; }
        public DateTime? DateBorrowed { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
      

        public Loan(int id, bool isReturned, DateTime? dateBorrowed, DateTime? dueDate, DateTime? returnDate)
        {
            Id = id;
            //BookId = bookId;
            //MemberId = memberId;
            IsReturned = isReturned;
            DateBorrowed = dateBorrowed;
            DueDate = dueDate;
            ReturnDate = returnDate;
        }

    }
}
