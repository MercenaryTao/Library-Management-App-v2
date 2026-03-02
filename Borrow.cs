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
    public partial class Borrow : Form
    {
        BusinessLogic businessLogic;
        BindingList<Model.Book> books = JSONStorage.books;
        public Borrow()
        {
            businessLogic = new BusinessLogic(books);
            InitializeComponent();
    bookDgv.DataSource = books;
        }

        private void Borrow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form1 mainForm = new Form1();
            mainForm.Show();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            int searchItem = srchCombo.SelectedIndex;
            string searchParam = srchParam.Text;
            var results = businessLogic.SearchMethod(searchParam, searchItem);
            bookDgv.DataSource = results;
        }
    }
}
