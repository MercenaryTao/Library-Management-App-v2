using Library_Management_App_v2.Controller;
using Library_Management_App_v2.Data;
using Library_Management_App_v2.Model;
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
 
        BindingList<Model.Book> books = JSONStorage.books;
        BindingList<Model.Member> members = JSONStorage.members;
        BindingList<Model.Loan> loans = JSONStorage.loans;
        Library library = new Library(); 
        public Borrow()
        {            
            InitializeComponent();
  
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



                    bool hasBeenBorrowed = library.ExistingBorrow(bookId, memberId);
                    bool booksAvailable = library.checkBookAvailability(bookId);
                    if (hasBeenBorrowed)
                    {
                        MessageBox.Show("Member cannot borrow books of the same type"); return;
                    }
                    if (!booksAvailable)
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

           
                    bool operationResult = library.LoanBook(bookId, memberId);

                if (operationResult)
                {
       
                        MessageBox.Show("Book successcully loaned", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Member has reached loan limit", "Loan Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }   
        catch (Exception)
        {
                MessageBox.Show("Operation unsuccessful", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
   
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
         
                bool hasBeenBorrowedByMember = library.returnLoaned(bookId, memberId);
                if (!hasBeenBorrowedByMember)
                {
                    MessageBox.Show("Book has not been borrowed by Member");
                    return;
                }

                MessageBox.Show("Book successfully returned!", "Operation Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
