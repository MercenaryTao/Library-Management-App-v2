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
        private string filePath = @"C:\Users\sirlv\source\repos\Library Management App v2\bin\Debug\books.json";
        JSONStorage JSONStorage = new JSONStorage();
        BusinessLogic businessLogic;
        BindingList<Model.Book> books = new BindingList<Book>();

        public Form1()
        {
            InitializeComponent();
            
            //createCols();
            books = JSONStorage.loadData("books.json");
            dataDisplay.DataSource = JSONStorage.loadData(filePath);
            srchCombo.DropDownStyle = ComboBoxStyle.DropDownList;
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
                    Model.Book book = new Model.Book(id, isbn, title, author, genre, desc, false, dateTime, dueDate, dateReturned);
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
            dataDisplay.DataSource = JSONStorage.loadData(filePath);
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
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            businessLogic = new BusinessLogic(books);

            //if (srchCombo.SelectedItem != null)
            //{

            //    switch (searchItem)
            //    {case 0:

            //            if (!string.IsNullOrEmpty(searchParam))
            //            {
            //                if (int.TryParse(srchParam.Text, out int idValue))
            //                {
            //                    var searchResults = books.Where(b => b.Id.Equals(int.Parse(searchParam))).ToList();
            //                    MessageBox.Show($"Search yielded {searchResults.Count} results");
            //                    dataDisplay.DataSource = searchResults;
            //                }
            //                else
            //                {
            //                    MessageBox.Show("Please enter a valid id.");
            //                }
            //            }
            //            else
            //            {
            //                MessageBox.Show("Please enter a search parameter.");
            //            }
            //                break;
            //        default:
            //            break;
            //      case 1:
            //            var searchResults2 = books.Where(b => b.Title.IndexOf(searchParam, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            //            MessageBox.Show($"Search yielded {searchResults2.Count} results");
            //            dataDisplay.DataSource = searchResults2;
            //            break;
            //        case 2:
            //            var searchResults3 = books.Where(b => b.Author.IndexOf(searchParam, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            //            MessageBox.Show($"Search yielded {searchResults3.Count} results");
            //            dataDisplay.DataSource = searchResults3;
            //            break;
            //        case 3:
            //            var searchResults4 = books.Where(b => b.Genre.IndexOf(searchParam, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            //            MessageBox.Show($"Search yielded {searchResults4.Count} results");
            //            dataDisplay.DataSource = searchResults4;
            //            break;
            //    }

            //}
            //else
            //{
            //    MessageBox.Show("Please select a search criteria.");
            //    return;
            //}
            int searchItem = srchCombo.SelectedIndex;
            string searchParam = srchParam.Text;
            var results = businessLogic.SearchMethod(searchParam, searchItem);     
            dataDisplay.DataSource = results;
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

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
