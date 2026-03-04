using Library_Management_App_v2.Controller;
using Library_Management_App_v2.Model;
using Library_Management_App_v2.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public Borrow()
        {            
            InitializeComponent();
            members = storage.loadMembersData("members.json");
            businessLogic = new BusinessLogic(books, members);
            bookDgv.DataSource = books;
            memberView.DataSource = members;
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
            
            var results = businessLogic.SearchMethod(searchParam, searchItem);

            bookDgv.DataSource = results;
        }

        private void BorrowBtn_Click(object sender, EventArgs e)
        {
            if (bookDgv.SelectedRows.Count == 1)
            {       
                Book selectedBook = (Book)bookDgv.SelectedRows[0].DataBoundItem;
                selectedBook.DateReturned = null;
                businessLogic.borrowBook(selectedBook);
            }
            bookDgv.Refresh();
        }

        private void Returnbtn_Click(object sender, EventArgs e)
        {
            if (bookDgv.SelectedRows.Count == 1)
            {
                Book selectedBook = (Book)bookDgv.SelectedRows[0].DataBoundItem;
                businessLogic.returnBook(selectedBook);
                
            }
            bookDgv.Refresh();
        }

        private void bookDgv_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {

            var row = bookDgv.Rows[e.RowIndex];
            var book = row.DataBoundItem as Book;

            if (businessLogic.isOverdue(book))
            { row.DefaultCellStyle.BackColor = Color.Red; }
            else
            {
                row.DefaultCellStyle.BackColor = Color.White;
            }
        }
    }
}
