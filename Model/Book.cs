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
        public int availableCopies { get; set; }
        public int TotalCopies { get; set; }


        public Book(int id,string isbn, string title, string author, string genre, string desc, int availCopies, int copies)
        {
            Id = id;
            ISBN = isbn;
            Title = title;
            Author = author;      
            Genre = genre;
            Description = desc;    
            availableCopies = availCopies;
            TotalCopies = copies;
        }
    }
}
