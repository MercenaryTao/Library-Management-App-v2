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
        BusinessLogic businessLogic;
        JSONStorage storage = new JSONStorage();
        Member member;
        BindingList<Model.Book> books = JSONStorage.books;
        BindingList <Member> members = JSONStorage.members;
            BindingList<Loan> loans = JSONStorage.loans;
        public AddMember()
        {
            InitializeComponent();
            members = storage.loadMembersData("members.json");

            businessLogic = new BusinessLogic(books, members, loans);
          
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
                member = new Member(businessLogic.memberIdGen(), name, surname, email, 0);
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

            try
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this entry? This process cannot be undone!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                var selectedMember= memberView.CurrentRow?.DataBoundItem as Member;
                int id = selectedMember.MemberId;
                if (selectedMember!= null)
                {
                    if (dialogResult == DialogResult.Yes)
                    {
                        businessLogic.deleteMember(id);
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Please select a Member to delete.");
                }
                memberView.Refresh();
            }
            catch (Exception m)
            {
                MessageBox.Show($"Operation unsuccessful.\n{m.Message}");
                throw;
            }
        }
    }
}
