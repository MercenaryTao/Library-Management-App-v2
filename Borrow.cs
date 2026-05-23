using Library_Management_App_v2.Controller;
using Library_Management_App_v2.Data;
using Library_Management_App_v2.Model;
using Library_Management_App_v2.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
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
            //members = storage.loadMembersData("members.json");
            //businessLogic = new BusinessLogic(books, members, loans);
            //bookDgv.DataSource = books;
            //memberView.DataSource = members;
            //loanedDgv.DataSource = loans;
            //businessLogic.overDueCheck();
            bookDgv.DataSource = library.showAll();
            memberView.DataSource = library.showMembers();
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
            int bookId = 0;
            int memberId = 0;
            try
            {
                if (bookDgv.SelectedRows.Count == 1 && memberView.SelectedRows.Count == 1)
                {
                    //Book selectedBook = (Book)bookDgv.SelectedRows[0].DataBoundItem;
                    ////int bookId = selectedBook.Id;

                    //Member selectedMember = (Member)memberView.SelectedRows[0].DataBoundItem;

                    ////businessLogic.CheckMemberPenalty(selectedMember);
                    //if (!businessLogic.CanBorrow(selectedMember))
                    //{
                    //    MessageBox.Show($"Member is suspended until {selectedMember.SuspensionEndDate}");
                    //    return;
                    //}

                    //if (selectedMember.BorrowedBooksCount == 5)
                    //{
                    //    MessageBox.Show("Borrowing limit reached for this member. Please return a book before borrowing another one.", "Borrowing Limit Reached", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    return;
                    //}
                    //if (selectedBook.availableCopies == 0)
                    //{
                    //    MessageBox.Show("No available copies of this book. Please try again later.", "Book Unavailable", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    return;
                    //}

                    var bookRow = bookDgv.SelectedRows[0];
                  
                    if (bookRow != null)
                    {
                        bookId = Convert.ToInt32(bookRow.Cells["BookId"].Value);
                    }
                    else
                    {
                        MessageBox.Show("Select a book to borrow");
                        return;
                    }

                        var memberRow = memberView.SelectedRows[0];
                    if (memberRow != null)
                    {
                       memberId = Convert.ToInt32(memberRow.Cells["MemberId"].Value);
                    }
                    else
                    {
                        MessageBox.Show("Select a Member to borrow to");
                        return;
                    }
                   
                    if (library.checkMemberBorrowedCount(bookId, memberId))
                    {
                        MessageBox.Show("Member Has Exceed Total Number of Loans", "Loan Exeeded", MessageBoxButtons.OK);
                        return;
                    }
                    library.checkMemberBorrowedCount(bookId, memberId);

                    if (library.checkBookAvailability())
                    {
                        MessageBox.Show("There Are No More Available Copies");
                        return;
                    }
                    bool booksOverdue = library.Suspension();
                    if (booksOverdue)
                    {
                        MessageBox.Show("Member under suspension", "Suspension", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                 
                    library.checkBookAvailability();

                    library.LoanBook(bookId, memberId);
                }
            }
            catch (Exception ne)
            {
                MessageBox.Show("Operation unsuccessful \n" + ne.Message, "Error",MessageBoxButtons.OK , MessageBoxIcon.Exclamation);
            }

         
            bookDgv.DataSource = null;
            bookDgv.DataSource = library.showAll();

            memberView.DataSource = null;
            memberView.DataSource = library.showMembers();
        }

        private void Returnbtn_Click(object sender, EventArgs e)
        {
            int bookId = 0;
            int memberId = 0;
            if (bookDgv.SelectedRows.Count == 1)
              {
                var bookRow = bookDgv.SelectedRows[0];

                if (bookRow != null)
                {
                    bookId = Convert.ToInt32(bookRow.Cells["BookId"].Value);
                }
                else
                {
                    MessageBox.Show("Select a book to borrow");
                    return;
                }

                var memberRow = memberView.SelectedRows[0];
                if (memberRow != null)
                {
                    memberId = Convert.ToInt32(memberRow.Cells["MemberId"].Value);
                }
                else
                {                    
                    MessageBox.Show("Select a Member to borrow to");
                    return;
                }
                //businessLogic.CheckMemberPenalty(selectedMember);
                //  businessLogic.returnBook(selectedBook, selectedMember);
                bool hasBeenBorrowedByMember = library.returnLoaned(bookId, memberId);
                if (!hasBeenBorrowedByMember)
                {
                    MessageBox.Show("Book has not been borrowed by Member");
                    return;
                }

                MessageBox.Show("Book successfully returned!", "Operation Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
              }

            bookDgv.DataSource = null;
            bookDgv.DataSource = library.showAll();

            memberView.DataSource = null;
            memberView.DataSource = library.showMembers();

        }


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            loanedDgv.DataSource = library.displayLoans();
        }

        private void loanedDgv_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var row = loanedDgv.Rows[e.RowIndex];
            DateTime dueDate = Convert.ToDateTime(row.Cells["DueDate"].Value);

            bool isOverdue = Convert.ToBoolean(row.Cells["IsReturned"].Value);


            //var book = row.DataBoundItem as Loan;

            if (dueDate < DateTime.Now && isOverdue == false)
            { row.DefaultCellStyle.BackColor = Color.Red; }
            else
            {
                row.DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            library.reset();
        }
    }
}
