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
        BusinessLogic businessLogic;
        BindingList<Model.Book> books = JSONStorage.books;
        BindingList<Model.Member> members = JSONStorage.members;
        public Borrow()
        {
            businessLogic = new BusinessLogic(books, members);
            InitializeComponent();
    bookDgv.DataSource = books;
            businessLogic.overDueCheck();
           
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
                // Get the actual Book object from the selected row
                Book selectedBook = (Book)bookDgv.SelectedRows[0].DataBoundItem;

                // Now borrow that exact book
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
            bool isOverdue = true;
            if (isOverdue)
            {
                
            }
        }
    }
}
