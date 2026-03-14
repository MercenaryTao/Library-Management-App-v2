using Library_Management_App_v2.Controller;
using Library_Management_App_v2.Data;
using Library_Management_App_v2.Model;
using Library_Management_App_v2.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_App_v2
{
    public partial class Borrow : Form
    {
        JSONStorage storage = new JSONStorage();
        BusinessLogic businessLogic;
        BindingList<Model.Book> books = JSONStorage.books;
        BindingList<Model.Member> members = JSONStorage.members;
        BindingList<Model.Loan> loans = JSONStorage.loans;
        Library library = new Library(); 
        public Borrow()
        {            
            InitializeComponent();
            members = storage.loadMembersData("members.json");
            businessLogic = new BusinessLogic(books, members, loans);
            bookDgv.DataSource = books;
            memberView.DataSource = members;
            loanedDgv.DataSource = loans;
            //businessLogic.overDueCheck();
           
        }

        private void Borrow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 mainForm = new Form1();
            mainForm.Show();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
           
            int searchItem = srchCombo2.SelectedIndex;
            string searchParam = srchParam.Text;
            
            var results = library.SearchBooks(searchParam, searchItem);

            bookDgv.DataSource = results;
        }

        private void BorrowBtn_Click(object sender, EventArgs e)
        {

            try
            {
                if (bookDgv.SelectedRows.Count == 1 && memberView.SelectedRows.Count == 1)
                {
                    Book selectedBook = (Book)bookDgv.SelectedRows[0].DataBoundItem;
                    //int bookId = selectedBook.Id;

                    Member selectedMember = (Member)memberView.SelectedRows[0].DataBoundItem;

                    //businessLogic.CheckMemberPenalty(selectedMember);
                    if (!businessLogic.CanBorrow(selectedMember))
                    {
                        MessageBox.Show($"Member is suspended until {selectedMember.SuspensionEndDate}");
                        return;
                    }

                    if (selectedMember.BorrowedBooksCount == 5)
                    {
                        MessageBox.Show("Borrowing limit reached for this member. Please return a book before borrowing another one.", "Borrowing Limit Reached", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (selectedBook.availableCopies == 0)
                    {
                        MessageBox.Show("No available copies of this book. Please try again later.", "Book Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    MessageBox.Show($"Book '{selectedBook.Title}' has been successfully borrowed by {selectedMember.Name} {selectedMember.Surname}.", "Book Borrowed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    businessLogic.borrowBook(selectedBook, selectedMember);
                }
            }
            catch (Exception)
            {
                throw;
            }

            bookDgv.Refresh();
            memberView.Refresh();

        }

        private void Returnbtn_Click(object sender, EventArgs e)
        {
            
              if (bookDgv.SelectedRows.Count == 1)
              {
                  Book selectedBook = (Book)bookDgv.SelectedRows[0].DataBoundItem;
                  Member selectedMember = (Member)memberView.SelectedRows[0].DataBoundItem;

                  if (selectedMember.BorrowedBooksCount == 0 && selectedMember.BorrowedBooksCount <= 3)
                  {
                      MessageBox.Show("This member has no borrowed books to return.", "No Books to Return", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                      return;
                  }
                  if (selectedBook.TotalCopies == selectedBook.availableCopies)
                  {
                      MessageBox.Show("All books have been returned");
                      return;
                  }
                //businessLogic.CheckMemberPenalty(selectedMember);
                //  businessLogic.returnBook(selectedBook, selectedMember);
                MessageBox.Show("Book successfully returned!", "Operation Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
              }
              bookDgv.Refresh();
              memberView.Refresh();


        }


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            loanedDgv.Refresh();
        }

        private void loanedDgv_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            //var row = loanedDgv.Rows[e.RowIndex];
            //var book = row.DataBoundItem as Loan;

            //if (businessLogic.IsOverdue(book))
            //{ row.DefaultCellStyle.BackColor = Color.Red; }
            //else
            //{
            //    row.DefaultCellStyle.BackColor = Color.White;
            //}
        }
    }
}
