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
using System.Net.Mail;

namespace Library_Management_App_v2
{
    public partial class AddMember : Form
    {
        string memberPath = @"C:\Users\sirlv\source\repos\Library Management App v2\bin\Debug\members.json";
        BusinessLogic businessLogic;
        JSONStorage storage = new JSONStorage();
        Member member;
        BindingList<Model.Book> books = JSONStorage.books;
        BindingList <Member> members = JSONStorage.members;
        public AddMember()
        {
            InitializeComponent();
            members = storage.loadMembersData("members.json");

            businessLogic = new BusinessLogic(books, members);
          
            memberView.DataSource = members;
        }

        private void AddMember_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            this.Close();
            Form1 form1 = new Form1();
            form1.Show();
   
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string name = fNameBx.Text;
                if (string.IsNullOrEmpty(name))
                {
                    MessageBox.Show("Please enter a name.");
                    return;
                }
                string surname = lNameBx.Text;
                if (string.IsNullOrEmpty(surname))
                {
                    MessageBox.Show("Please enter a surname.");
                    return;
                }

                string email = emailBx.Text;
                if (string.IsNullOrEmpty(email))
                {
                    MessageBox.Show("Please enter an email address.");
                    return;
                }
                IsValidEmail(email);
                member = new Member(businessLogic.memberIdGen(), name, surname, email);
                businessLogic.addMember(member);
                MessageBox.Show("Member added successfully.");
            }
            catch (Exception m)
            {
                MessageBox.Show($"Operation unsuccessful.\n{m.Message}");
                throw;
            }
         
        }

        public bool IsValidEmail(string email)
        {
            try
            {
                var mailAddress = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid email address", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void dltBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
