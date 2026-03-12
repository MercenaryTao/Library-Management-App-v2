using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using Library_Management_App_v2.Model;
using System.Data;
using System.Data.Common;



namespace Library_Management_App_v2.Data
{
    internal class Library
    {
        private SQLiteConnection conn = new SQLiteConnection("Data Source=LibraryDB.sqlite;Version=3;");

        public SQLiteConnection connection
        {
            get { return conn; }
        }

        public void createDb()
        {

           
            connection.Open();

            var tableCommand = new SQLiteCommand(connection);
            
                tableCommand.CommandText = @"
        CREATE TABLE IF NOT EXISTS Books (
            BookId INTEGER PRIMARY KEY AUTOINCREMENT,
            ISBN VARCHAR NOT NULL,
            Title VARCHAR NOT NULL,
            Author VARCHAR NOT NULL,      
            Genre VARCHAR NOT NULL,
            Description VARCHAR,    
            AvailableCopies INTEGER NOT NULL,
            TotalCopies INTEGER NOT NULL
        );";
                tableCommand.ExecuteNonQuery();


                // 2️⃣ Members table
                var memberCommand = new SQLiteCommand(connection);            
                memberCommand.CommandText = @"
        CREATE TABLE IF NOT EXISTS Members (
            MemberId INTEGER PRIMARY KEY AUTOINCREMENT,
            Name VARCHAR NOT NULL,
            Surname VARCHAR NOT NULL,
            Email VARCHAR NOT NULL,
            BorrowedBooksCount INTEGER DEFAULT 0,
            SuspensionEndDate DATETIME
        );";
                memberCommand.ExecuteNonQuery();


            // 3️⃣ Loan table
            var loanCommand = new SQLiteCommand(connection);
            loanCommand.CommandText = @"
        CREATE TABLE IF NOT EXISTS Loan (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            BookId INTEGER NOT NULL,
            MemberId INTEGER NOT NULL,
            IsReturned BOOLEAN DEFAULT 0,
            DateBorrowed DATETIME,
            DueDate DATETIME,
            ReturnDate DATETIME,
            FOREIGN KEY(BookId) REFERENCES Books(Id),
            FOREIGN KEY(MemberId) REFERENCES Members(MemberId)
        );";
                loanCommand.ExecuteNonQuery();
            

            connection.Close();
            Console.WriteLine("Tables created successfully!");
        }

        public void addBook(Book book)
        {
            try
            {
               
                    connection.Open();
                var command = new SQLiteCommand(connection);
                        command.CommandText = @"
INSERT INTO Books (ISBN, Title, Author, Genre, Description, AvailableCopies, TotalCopies)
VALUES (@ISBN, @Title, @Author, @Genre, @Description, @AvailableCopies, @TotalCopies)";
                    //command.Parameters.AddWithValue("@BookId", book.Id);
                    command.Parameters.AddWithValue("@ISBN", book.ISBN);
                    command.Parameters.AddWithValue("@Title", book.Title);
                    command.Parameters.AddWithValue("@Author", book.Author);
                    command.Parameters.AddWithValue("@Genre", book.Genre);
                    command.Parameters.AddWithValue("@Description", book.Description);
                    command.Parameters.AddWithValue("@AvailableCopies", book.availableCopies);
                    command.Parameters.AddWithValue("@TotalCopies", book.TotalCopies);
                    command.ExecuteNonQuery();
            
            }
            catch (Exception m)
            {

                throw new Exception($"operation unsuccessful {m.Message}");
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }

        }

        public DataTable showAll()
        {
            DataTable dt = new DataTable();
            try
            {
               
                    connection.Open();
                 
                        string qry = $@"
                        SELECT * FROM Books";

                        var newCommand = new SQLiteCommand(qry, connection);

                        SQLiteDataAdapter da = new SQLiteDataAdapter(newCommand);
                      
                        da.Fill(dt);
         
            }
            catch (Exception m)
            {

                throw new Exception($"operation unsuccessful {m.Message}");
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return dt;

        }

        public void AddMember(Member member)
        {
            try
            {
                connection.Open();
                var command = new SQLiteCommand(connection);
                command.CommandText = @"
INSERT INTO Members(Name, Surname, Email, BorrowedBooksCount, SuspensionEndDate)
VALUES (@Name, @Surname, @Email, @BorrowedBooksCount, @SuspensionEndDate)
";
                command.Parameters.AddWithValue("@Name", member.Name);
                command.Parameters.AddWithValue("@Surname", member.Surname);
                command.Parameters.AddWithValue("@Email", member.Email);
                command.Parameters.AddWithValue("@BorrowedBooksCount", member.BorrowedBooksCount);
                command.Parameters.AddWithValue(@"SuspensionEndDate", member.SuspensionEndDate);
                command.ExecuteNonQuery();
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
        public void DeleteMember(Member member)
        {
            try
            {
                connection.Open();
                var command = new SQLiteCommand(connection);
                command.CommandText = @"
DELETE FROM Members
WHERE MemberId = VALUE (@MemberId))
";
                command.Parameters.AddWithValue("@MemberId", member.MemberId);
                command.ExecuteNonQuery();
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
        public DataTable showMembers()
        {
            DataTable dt = new DataTable();
            try
            {

                connection.Open();

                string qry = $@"
                        SELECT * FROM Members";

                var newCommand = new SQLiteCommand(qry, connection);

                SQLiteDataAdapter da = new SQLiteDataAdapter(newCommand);

                da.Fill(dt);

            }
            catch (Exception m)
            {

                throw new Exception($"operation unsuccessful {m.Message}");
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return dt;

        }
    }
}
