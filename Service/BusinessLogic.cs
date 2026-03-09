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
        BindingList<Loan> loans = new BindingList<Loan>();

        public BusinessLogic(BindingList<Book> loadedBooks, BindingList<Member> loadedMembers, BindingList<Loan> loaned)
        {
            books = loadedBooks;
            members = loadedMembers;
            loans = loaned;
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
        public void addMember(Member member)
        {

            members.Add(member);
            JSONStorage.SaveMembersData(members, "members.json");
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

        public void borrowBook(Book book, Member member)
        {

            try
            {

                if (member.BorrowedBooksCount >= 5)
                {
                    throw new Exception("Member cannot borrow more than 5 books.");

                }
                if (book.availableCopies <= 0)
                { 
                    throw new Exception("No available copies of the book.");
                }
                if (member.IsSuspended)
                {
                    return;
               
                }
                int id = loans.Any() ? loans.Max(l => l.Id) + 1 : 1;

                loans.Add(new Loan(id, book.Id, member.MemberId, false, DateTime.Now, DateTime.Now.AddDays(14), null));

                book.availableCopies--;
                member.BorrowedBooksCount++;

                JSONStorage.SaveData(books, "books.json");
                JSONStorage.SaveMembersData(members, "members.json");
                JSONStorage.SaveLoansData(loans, "loans.json");


            }
            catch (Exception)
            {
                throw new Exception("An error occurred while trying to borrow the book. Please check the member's borrowing status and the book's availability.");
            }

        }

        public void returnBook(Book book, Member member)
        {
            int memberId = member.MemberId;
            var activeLoan = loans.FirstOrDefault(l => l.MemberId == memberId && l.BookId == book.Id);
            activeLoan.ReturnDate = DateTime.Now;
            activeLoan.IsReturned = true;
            if (activeLoan == null)
            {
                return;
                throw new Exception("This member did not borrow this book.");

            }

            var bookToReturn = books.FirstOrDefault(b => b.Id == book.Id);
            if (bookToReturn != null)
            {
                bookToReturn.availableCopies++;
                member.BorrowedBooksCount--;
            }
            else
            {
                throw new Exception("Book not found in the system.");
            }
            JSONStorage.SaveData(books, "books.json");
            JSONStorage.SaveLoansData(loans, "loans.json");
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
    
        

        public List<string> GetGenres()
        {
            // Get all genres, remove duplicates, and sort
            var allGenres = books
                .Select(b => b.Genre)
                .Where(g => !string.IsNullOrEmpty(g))
                .Distinct()
                .OrderBy(g => g)
                .ToList();

            return allGenres;
        }
        public void updateBook(Book updatedBook, int totCopies)
        {
            var existingBook = books.FirstOrDefault(b => b.Id == updatedBook.Id);
            if (existingBook != null)
            {
                existingBook.TotalCopies = totCopies;
                JSONStorage.SaveData(books, "books.json");
            }
            else
            {
                throw new Exception("Book not found.");
            }
            
        }
   

        public void CheckMemberPenalty(Member member)
        {
            int overdueCount = GetOverdueCount(member.MemberId);

            if (overdueCount > 3)
            {
                member.SuspensionEndDate = DateTime.Now.AddDays(7);
            }
        }

        public int GetOverdueCount(int memberId)
        {
            return loans
                .Where(l => l.MemberId == memberId && !l.IsReturned && l.DueDate < DateTime.Now)
                .Count();
        }

        public bool IsOverdue(Loan loan)
        {
            return !loan.IsReturned && loan.DueDate < DateTime.Now;
        }

        public bool CanBorrow(Member member)
        {
            if (member == null)
                return false;

            return !member.IsSuspended;
        }
    }
}
