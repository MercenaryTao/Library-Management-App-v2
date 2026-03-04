using Library_Management_App_v2.Controller;
using Library_Management_App_v2.Model;
using Library_Management_App_v2.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_App_v2
{
    public partial class Form1 : Form
    {
        private string bookPath = @"C:\Users\sirlv\source\repos\Library Management App v2\bin\Debug\books.json";
        JSONStorage JSONStorage = new JSONStorage();
        BusinessLogic businessLogic;

        BindingList<Model.Book> books = JSONStorage.books;
        BindingList<Model.Member> members = JSONStorage.members;    
        BindingList<Model.Loan> loans = JSONStorage.loans;

        public Form1()
        {
            InitializeComponent();
            srchCombo1.DropDownStyle = ComboBoxStyle.DropDownList;

            JSONStorage.loadLoanData("loans.json");

            books = JSONStorage.loadData("books.json"); 

            businessLogic = new BusinessLogic(books, members, loans);

            dataDisplay.DataSource = books;
        }

        private void createCols()
        {
            dataDisplay.Columns.Add("Id", "ID");
            dataDisplay.Columns.Add("Title", "Title");
            dataDisplay.Columns.Add("Author", "Author");
            dataDisplay.Columns.Add("Genre", "Genre");
            dataDisplay.Columns.Add("Description", "Description");
            dataDisplay.Columns.Add("IsBorrowed", "Is Borrowed");
            dataDisplay.Columns.Add("DateBorrowed", "Date Borrowed");
            dataDisplay.Columns.Add("DueDate", "Due Date");
            dataDisplay.Columns.Add("DateReturned", "Date Returned");
        }

        private void addBtn_Click(object sender, EventArgs e)
        {

            int id = businessLogic.idGen();
            string title = titleBx.Text;
            string author = authorBx.Text;
            var genre = "";
            string isbn = isbnBx.Text;
            int totalCopies = numDial.Value > 0 ? (int)numDial.Value : 1;
            int availCopies = totalCopies;
            string desc = descrBx.Text;
            DateTime? dateTime = null;
            DateTime? dueDate = null;
            DateTime? dateReturned = null;

            genreCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            
          
            //MessageBox.Show($"Genre selected: {genre}");
            try
            {
                if (string.IsNullOrEmpty(title) || title == " ")
                {
                    MessageBox.Show("Please enter a title.");
                    return;
                }
                if (string.IsNullOrEmpty(isbn) || isbn == " ")
                {
                    MessageBox.Show("Please enter an ISBN.");
                }
              
                if (string.IsNullOrEmpty(author) || author ==" ")
                {
                    MessageBox.Show("Please enter an author");
                }

                if (genreCombo.SelectedItem == null)
                {
                    MessageBox.Show("Please select a genre.");
                    return;
                }
                genre = genreCombo.SelectedItem.ToString();

                if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(author) && !string.IsNullOrEmpty(genre))
                {
                    Model.Book book = new Model.Book(id, isbn, title, author, genre, desc, false, dateTime, dueDate, dateReturned, availCopies,totalCopies);
                    businessLogic.addBook(book);
                }
                else
                {
                    MessageBox.Show("Please fill in all required fields.");
                }

            }
            catch (Exception b)
            {
                MessageBox.Show($"Catastrophic Failure {b.Message}");
                throw;
            }

           dataDisplay.DataSource = null;
            dataDisplay.DataSource = JSONStorage.loadData(bookPath);
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this entry? This process cannot be undone!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            var selectedBook = dataDisplay.CurrentRow?.DataBoundItem as Model.Book;
            int id = selectedBook.Id;
            if (selectedBook != null)
            {
                if (dialogResult == DialogResult.Yes)
                {
                    businessLogic.deleteBook(id);
                }
                else
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("Please select a book to delete.");
            }
            dataDisplay.Refresh();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
    
            int searchItem = srchCombo1.SelectedIndex;
            string searchParam = srchParam.Text;
            
            var results1 = businessLogic.SearchMethod(searchParam, searchItem);
            
            dataDisplay.DataSource = results1;
        }

        private void borrowMenu_Click(object sender, EventArgs e)
        {
            this.Hide();
            Borrow borrowForm = new Borrow();
            borrowForm.ShowDialog();

        }

        private void addNewMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddMember addMemberForm = new AddMember();
            addMemberForm.ShowDialog();

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
