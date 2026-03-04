using Library_Management_App_v2.Controller;
using Library_Management_App_v2.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_App_v2.Service
{
    internal class BusinessLogic
    {
        public JSONStorage JSONStorage = new JSONStorage();
        BindingList<Model.Book> books = new BindingList<Book>();
        BindingList<Model.Member> members = new BindingList<Member>();
        public BusinessLogic(BindingList<Book> loadedBooks, BindingList<Member> loadedMembers)
        {
            books = loadedBooks;
            members = loadedMembers;
        }
        public void deleteBook(int id)
        {

            var bookToDelete = books.FirstOrDefault(b => b.Id == id);
            if (bookToDelete != null)
            {
                books.Remove(bookToDelete);
                JSONStorage.SaveData(books, "books.json");
            }
            else
            {
                MessageBox.Show("Book not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void addBook(Model.Book book)
        {

            books.Add(book);
            JSONStorage.SaveData(books, "books.json");
        }

        public int idGen()
        {

            int bookId = 0;
            if (books.Count == 0)
            {
                return 1;
            }
            else
            {
                if (books.Count > 0)
                {
                    bookId = books.Max(b => b.Id) + 1;
                }
                else
                {
                    MessageBox.Show("Empty DataBase");
                }
            }
            return bookId;
        }
        public List<Book> SearchMethod(string srchPar, int sel)
        {

            var searchResults = new List<Book>();
            searchResults.Clear();

            if (sel == -1)
                return searchResults;

            if (string.IsNullOrWhiteSpace(srchPar))
                return searchResults;

            switch (sel)
            {
                case 0:
                    if (int.TryParse(srchPar, out int id))
                        return books.Where(b => b.Id == id).ToList();
                    break;

                case 1:
                    return books.Where(b =>
                        b.Title.IndexOf(srchPar, StringComparison.OrdinalIgnoreCase) >= 0)
                        .ToList();

                case 2:
                    return books.Where(b =>
                        b.Author.IndexOf(srchPar, StringComparison.OrdinalIgnoreCase) >= 0)
                        .ToList();

                case 3:
                    return books.Where(b =>
                        b.Genre.IndexOf(srchPar, StringComparison.OrdinalIgnoreCase) >= 0)
                        .ToList();
            }


            return searchResults;
        }

        public void borrowBook(Book book)
        {

            if (book != null && !book.IsBorrowed)
            {
                book.IsBorrowed = true;
                book.DateBorrowed = DateTime.Now;
                book.DueDate = DateTime.Now.AddDays(14);
                JSONStorage.SaveData(books, "books.json");
            }
            else
            {
                MessageBox.Show("Book not found or already borrowed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void returnBook(Book book)
        {
            var bookToReturn = books.FirstOrDefault(b => b == book);
            if (bookToReturn != null && bookToReturn.IsBorrowed)
            {
                bookToReturn.IsBorrowed = false;
                bookToReturn.IsOverdue = false;
                bookToReturn.DateBorrowed = null;
                bookToReturn.DueDate = null;
                bookToReturn.DateReturned = DateTime.Now;
                JSONStorage.SaveData(books, "books.json");
            }
            else
            {
                MessageBox.Show("Book not found or not currently borrowed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void addMember(Member member)
        {

            members.Add(member);
            JSONStorage.SaveMembersData(members, "members.json");
        }


        public int memberIdGen()
        {

            int memId = 0;
            if (members.Count == 0)
            {
                return 1;
            }
            else
            {
                if (members.Count > 0)
                {
                    memId = members.Max(b => b.MemberId) + 1;
                }
                else
                {
                    MessageBox.Show("Empty DataBase");
                }
            }
            return memId;
        }

        public void deleteMember(int id)
        {
            var memberToDelete = members.FirstOrDefault(m => m.MemberId == id);
            if (memberToDelete != null)
            {
                members.Remove(memberToDelete);
                JSONStorage.SaveMembersData(members, "members.json");
            }
            else
            {
                MessageBox.Show("Member not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public bool isOverdue(Book book)
        {
            bool isOverdue = false;
            if (book.IsBorrowed && book.DueDate < DateTime.Now)
            {
               book.IsOverdue = true;
                isOverdue = true;
            }
            return isOverdue;
        }
    }
}
