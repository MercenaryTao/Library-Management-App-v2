using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_App_v2.Model
{
    internal class Book
    {
        public string ISBN { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public bool IsBorrowed { get; set; }

        public DateTime? DateBorrowed { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? DateReturned { get; set; }
        
        public Book(int id,string isbn, string title, string author, string genre, string desc, bool isBorrowed, DateTime? dateBorrowed, DateTime? dueDate,DateTime? dateReturned)
        {
            Id = id;
            ISBN = isbn;
            Title = title;
            Author = author;
            IsBorrowed = isBorrowed;
                Genre = genre;
            Description = desc;
            DateBorrowed = dateBorrowed;
            DueDate = dueDate;
            DateReturned = dateReturned;
        }
    }
}
