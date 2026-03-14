using Library_Management_App_v2.Model;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Security.Policy;



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
            ISBN VARCHAR NOT NULL UNIQUE,
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
        public void DeleteBook(string ISBN)
        {
            try
            {
                connection.Open();
                var command = new SQLiteCommand(connection);
                command.CommandText = @"
DELETE FROM Books
WHERE ISBN = @ISBN
";

                command.Parameters.AddWithValue("@ISBN", ISBN);
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

        public DataTable SearchBooks(string srchPar, int sel)
        {
            DataTable dt = new DataTable();
      
            try
            {
                connection.Open();
                switch (sel)
                {
                    case 0:
                        var qry1 = new SQLiteCommand(@"
                                        SELECT * FROM Books
                                        WHERE Id LIKE @srchPar

                        ", connection);

                        qry1.Parameters.AddWithValue("@srchPar", $"%{srchPar}%");
                        SQLiteDataAdapter da1 = new SQLiteDataAdapter(qry1);
                        da1.Fill(dt);
                        break;
                    case 1:
                        var qry2 = new SQLiteCommand(@"
                SELECT * FROM Books
                WHERE Title LIKE @srchPar
", connection);
                        qry2.Parameters.AddWithValue("@srchPar", $"%{srchPar}%");
                        SQLiteDataAdapter da2 = new SQLiteDataAdapter(qry2);
                        da2.Fill(dt);
                        break; 
                    case 2:
                        var qry3 = new SQLiteCommand(@"
                SELECT * FROM Books
                WHERE Author LIKE @srchPar
", connection);
                        qry3.Parameters.AddWithValue("@srchPar", $"%{srchPar}%");
                        SQLiteDataAdapter da3 = new SQLiteDataAdapter(qry3);
                        da3.Fill(dt);
                        break;
                    case 3:
                        var qry4 = new SQLiteCommand(@"
                SELECT * FROM Books
                WHERE Genre LIKE @srchPar
", connection);
                        qry4.Parameters.AddWithValue("@srchPar", $"%{srchPar}%");
                        SQLiteDataAdapter da4 = new SQLiteDataAdapter(qry4);
                        da4.Fill(dt);
                        break;
                    default:
                        break;
             
                }
                return dt;
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
        public void DeleteMember(int memberId)
        {
            try
            {
                connection.Open();
                var command = new SQLiteCommand(connection);
                command.CommandText = @"
DELETE FROM Members
WHERE MemberId = @MemberId
";

                command.Parameters.AddWithValue("@MemberId", memberId);
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

        public void loadtoDB(BindingList<Book> books)
        {
            try
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    //var command = new SQLiteCommand( @"DELETE FROM Books", connection);

                    var command = new SQLiteCommand(@"
                    INSERT INTO Books (ISBN, Title, Author, Genre, Description, AvailableCopies, TotalCopies)
                    VALUES (@ISBN, @Title, @Author, @Genre, @Description, @AvailableCopies, @TotalCopies)", connection);

                    foreach (var item in books)
                    {
                        command.Parameters.Clear();

                        command.Parameters.AddWithValue("@ISBN", item.ISBN);
                        command.Parameters.AddWithValue("@Title", item.Title);
                        command.Parameters.AddWithValue("@Author", item.Author);
                        command.Parameters.AddWithValue("@Genre", item.Genre);
                        command.Parameters.AddWithValue("@Description", item.Description);
                        command.Parameters.AddWithValue("@AvailableCopies", item.availableCopies);
                        command.Parameters.AddWithValue("@TotalCopies", item.TotalCopies);

                        command.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }

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


    }
}
