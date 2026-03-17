using Library_Management_App_v2.Controller;
using Library_Management_App_v2.Data;
using Library_Management_App_v2.Model;
using Library_Management_App_v2.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;


namespace Library_Management_App_v2
{
    public partial class Form1 : Form
    {

        //BusinessLogic businessLogic;
        Library library = new Library();
        //JSONStorage storage = new JSONStorage();
        //BindingList<Model.Book> books = JSONStorage.books;
        //BindingList<Model.Member> members = JSONStorage.members;
        //BindingList<Model.Loan> loans = JSONStorage.loans;
        List<string> allGenres = new List<string>();
        List<string> genreList;
        public Form1()
        {
            InitializeComponent();
            library.createDb();
            srchCombo1.DropDownStyle = ComboBoxStyle.DropDownList;

            //JSONStorage.loadLoanData("loans.json");

            //books = storage.loadData("books.json");

            //businessLogic = new BusinessLogic(books, members, loans);

            dataDisplay.DataSource = library.showAll();
            //library.loadtoDB();
            genreList = GetGenres();
            genreCombo.DataSource = GetGenres();
            genreCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            library.yes();
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

            //int id = businessLogic.idGen();
            string title = titleBx.Text;
            string author = authorBx.Text;
          var genre = genreCombo.SelectedItem;
            string isbn = isbnBx.Text;
            int totalCopies = numDial.Value > 0 ? (int)numDial.Value : 1;
            int availCopies = totalCopies;
            string desc = descrBx.Text;
       
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
              

            

                if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(author) && !string.IsNullOrEmpty(genre.ToString()))
                {
                    Model.Book book = new Model.Book(isbn, title, author, genre.ToString(), desc, availCopies,totalCopies);

                    //businessLogic.addBook(book);
                    library.addBook(book);
                    //dataDisplay.DataSource = library.showAll();
                    MessageBox.Show("Book added successfully");
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
            dataDisplay.DataSource = library.showAll();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this entry? This process cannot be undone!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dataDisplay.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dataDisplay.SelectedRows[0];
                string isbn = row.Cells["ISBN"].Value.ToString();
                if (isbn != null)
                {
                    if (dialogResult == DialogResult.Yes)
                    {
                        library.DeleteBook(isbn);
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a book to delete.");
            }
            dataDisplay.DataSource = library.showAll();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
    
            int searchItem = srchCombo1.SelectedIndex;
            string searchParam = srchParam.Text;
            if (searchItem == -1 || string.IsNullOrWhiteSpace(searchParam))
            {
                MessageBox.Show("Please select a search option and enter a value.");
                return;
            }

            var results1 = library.SearchBooks(searchParam, searchItem);
            
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

        private void updateBtn_Click(object sender, EventArgs e)
        {
            var selectedBook = dataDisplay.CurrentRow?.DataBoundItem as Model.Book;
            int totalCopies = (int)numDial.Value;
            MessageBox.Show($"Selected the book you want to edit and fill the above properties you wish to update\nPlease note that only a book's availble copies can be editted");
            if (selectedBook != null)
            {
             //businessLogic.updateBook(selectedBook, totalCopies);
                MessageBox.Show($"Book has been updated.");
            }
            else
            {
                MessageBox.Show("Select the book you wish to edit", "Incorrect Selection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dataDisplay_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataDisplay.CurrentCell = null;

        }

        private void reloadBtn_Click(object sender, EventArgs e)
        {
            //library.loadtoDB(books);
            dataDisplay.DataSource = library.showAll();
        }
        public List<string> GetGenres()
        {
            foreach (DataGridViewRow row in dataDisplay.Rows)
            {
                if (!row.IsNewRow && row.Cells["Genre"].Value != null)
                {
                    string genre = row.Cells["Genre"].Value.ToString();
                    allGenres.Add(genre);
                }
            }
            var tempGenre = allGenres
                .Select(b => b)
                .Where(g => !string.IsNullOrEmpty(g))
                .Distinct()
                .OrderBy(g => g)
                .ToList();

            return tempGenre;
        }
    }
}
