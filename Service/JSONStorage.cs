using Library_Management_App_v2.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_App_v2.Controller
{
    internal class JSONStorage
    {
      
        public static string bookFilePath = Path.Combine(
     AppDomain.CurrentDomain.BaseDirectory,
     "books.json"
 );
        public static string membersFilePath= Path.Combine(
    AppDomain.CurrentDomain.BaseDirectory,
    "members.json"
);
        public static string loansFilePath = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            "loans.json"
            );

        public static BindingList<Model.Book> books = new BindingList<Book>();
        public static BindingList<Model.Member> members = new BindingList<Member>();
        public static BindingList<Model.Loan> loans = new BindingList<Loan>();

      
        public void SaveLoansData<T>(BindingList<T> data, string filePath)
        {
            try
            {
                string jsonLoanData = JsonConvert.SerializeObject(data, Formatting.Indented);
                System.IO.File.WriteAllText(filePath, jsonLoanData);
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while saving data to the file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }   

        public void loadLoanData(string filePath)
        {
            if (!System.IO.File.Exists(filePath))
            {
                new BindingList<Model.Loan>();
                System.IO.File.WriteAllText(filePath, "[]");
            }
            string jsonLoanData = System.IO.File.ReadAllText(filePath);
            loans = JsonConvert.DeserializeObject<BindingList<Model.Loan>>(jsonLoanData);
        }

        public static void SaveData<T>(BindingList<T> data, string filePath)
        {
            try
            {
                string jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);
                System.IO.File.WriteAllText(filePath, jsonData);
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while saving data to the file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        public BindingList<Model.Book> loadData(string filePath)
        {
            if (!System.IO.File.Exists(filePath))
            {
                new BindingList<Model.Book>();
            }
            string jsonData = System.IO.File.ReadAllText(filePath);

            return books = JsonConvert.DeserializeObject<BindingList<Model.Book>>(jsonData);
        }

        public static void SaveMembersData<T>(BindingList<T> data, string filePath)
        {
            try
            {
                string jsonMemberData = JsonConvert.SerializeObject(data, Formatting.Indented);
                System.IO.File.WriteAllText(filePath, jsonMemberData);
            }
            catch (Exception)
            {
                MessageBox.Show("An error occurred while saving data to the file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }
        public BindingList<Model.Member> loadMembersData(string filePath)
        {
            if (!System.IO.File.Exists(filePath))
            {
                new BindingList<Model.Member>();
            }
            string jsonMemberData = System.IO.File.ReadAllText(filePath);

            return members = JsonConvert.DeserializeObject<BindingList<Model.Member>>(jsonMemberData);

        }
    }
}
