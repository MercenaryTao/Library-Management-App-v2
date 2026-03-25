using Library_Management_App_v2.Controller;
using Library_Management_App_v2.Model;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing.Drawing2D;
using System.IO;
using System.Net;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Policy;
using System.Windows.Forms;



namespace Library_Management_App_v2.Data
{
    internal class Library
    {
        static string dbPath = Path.Combine(
          AppDomain.CurrentDomain.BaseDirectory,
          "LibraryAppDB.sqlite"
      );

    
        private SQLiteConnection conn = new SQLiteConnection($"Data Source={dbPath};Version=3;");


        public SQLiteConnection connection
        {
            get
            {
                if (conn == null)
                {

                    conn = new SQLiteConnection($"Data Source=LibraryAppDB.sqlite;Version=3;");
                }
                return conn;
            }
        }


        public void yes()
        {
            using (var cmd = new SQLiteCommand("PRAGMA table_info(Books);", connection))
            {
                connection.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    Console.WriteLine("Columns in Books table:");
                    while (reader.Read())
                    {
                        
                        string columnName = reader["name"].ToString();
                        string columnType = reader["type"].ToString();
                        bool isPrimaryKey = Convert.ToInt32(reader["pk"]) == 1;

                        Console.WriteLine($"{columnName} ha ha ha | {columnType} | PK: {isPrimaryKey}");
                        Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
                    }
                }
                connection.Close();
            }
        }

        public void createTables()
        {
            try
            {
                connection.Open();
              
                using (var transaction = connection.BeginTransaction())
                {

                   var tableCommand = new SQLiteCommand(@"
       CREATE TABLE IF NOT EXISTS Books (
    BookId INTEGER PRIMARY KEY AUTOINCREMENT,
    ISBN VARCHAR NOT NULL UNIQUE,
    Title VARCHAR NOT NULL,
    Author VARCHAR NOT NULL,
    Genre VARCHAR NOT NULL,
    Description VARCHAR,
    AvailableCopies INTEGER NOT NULL CHECK (AvailableCopies >= 0 AND AvailableCopies <= 20),
    TotalCopies INTEGER NOT NULL CHECK (TotalCopies >= 0 AND TotalCopies <= 20)
);", connection, transaction);
                    tableCommand.ExecuteNonQuery();



               
                   var memberCommand = new SQLiteCommand(@"
CREATE TABLE IF NOT EXISTS Members (
    MemberId INTEGER PRIMARY KEY AUTOINCREMENT,
    Name VARCHAR NOT NULL,
    Surname VARCHAR NOT NULL,
    Email VARCHAR NOT NULL,
    BorrowedBooksCount INTEGER DEFAULT 0 CHECK (BorrowedBooksCount >= 0 AND BorrowedBooksCount <= 3),
    SuspensionEndDate DATETIME
);", connection, transaction);
                    memberCommand.ExecuteNonQuery();



                    var loanCommand = new SQLiteCommand(@"
CREATE TABLE IF NOT EXISTS Loans (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    BookId INTEGER NOT NULL,
    MemberId INTEGER NOT NULL,
    IsReturned BOOLEAN DEFAULT 0,
    DateBorrowed DATETIME,
    DueDate DATETIME,
    ReturnDate DATETIME,
    FOREIGN KEY(BookId) REFERENCES Books(BookId),
    FOREIGN KEY(MemberId) REFERENCES Members(MemberId)
);", connection, transaction);
                    loanCommand.ExecuteNonQuery();

                    transaction.Commit();
                }
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }

            connection.Close();
            Console.WriteLine("Tables created successfully!");
        }
        public bool LoanBook(int bookId, int memberId)
        {
            bool isReturned = false;
            DateTime dateBorrowed = DateTime.Now, dueDate = dateBorrowed.AddDays(14);
           
            try
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {

                    var updMem = new SQLiteCommand(@"SELECT BorrowedBooksCount
FROM Members
WHERE MemberId = @memberId", connection);

                    updMem.Parameters.AddWithValue(@"memberId", memberId);
                    long bookCount = (long)updMem.ExecuteScalar();

                    if (bookCount >= 4)
                    {
                        return false;
                    }

                    var insertCmd = new SQLiteCommand(@"
                INSERT INTO Loans (BookId, MemberId, IsReturned, DateBorrowed, DueDate, ReturnDate)
                VALUES (@BookId, @MemberId, @IsReturned, @DateBorrowed, @DueDate, @DateReturned)",
                                   connection, transaction);
                    {
                        insertCmd.Parameters.AddWithValue("@BookId", bookId);
                        insertCmd.Parameters.AddWithValue("@MemberId", memberId);
                        insertCmd.Parameters.AddWithValue("@IsReturned", isReturned ? 1 : 0);
                        insertCmd.Parameters.AddWithValue("@DateBorrowed", dateBorrowed.ToString("yyyy-MM-dd"));
                        insertCmd.Parameters.AddWithValue("@DueDate", dueDate.ToString("yyyy-MM-dd"));
                        insertCmd.Parameters.AddWithValue("@DateReturned", DBNull.Value);

                        insertCmd.ExecuteNonQuery();
                    }

                    var updateBook = new SQLiteCommand(
                        "UPDATE Books SET AvailableCopies = AvailableCopies - 1 WHERE BookId = @BookId",
                        connection, transaction);

                    updateBook.Parameters.AddWithValue("@BookId", bookId);
                    updateBook.ExecuteNonQuery();

                    var updateMember = new SQLiteCommand(
                        "UPDATE Members SET BorrowedBooksCount = BorrowedBooksCount + 1 WHERE MemberId = @MemberId",
                        connection, transaction);

                    updateMember.Parameters.AddWithValue("@MemberId", memberId);

                    updateMember.ExecuteNonQuery();

                    transaction.Commit();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
        public bool checkBookAvailability(int bookId)
        {
            try
            {
                    connection.Open();
                    var upd = new SQLiteCommand(@"
                                                 SELECT COUNT(*) FROM Books
                                                 WHERE BookId = @bookId AND AvailableCopies > 0
                                                 ", connection);
                upd.Parameters.AddWithValue(@"bookId", bookId);
                    long bookAvailable = (long)upd.ExecuteScalar();
                if (bookAvailable > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception m){ return false; throw new Exception(m.Message);  }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
        public long LoanCount(int memberId)
        {
            try
            {
                connection.Open();
                var updMem = new SQLiteCommand(@"SELECT BorrowedBooksCount
FROM Members
WHERE MemberId = @memberId", connection);

                updMem.Parameters.AddWithValue(@"memberId", memberId);
                long bookCount = (long)updMem.ExecuteScalar();
            
                return bookCount;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
        public bool ExistingBorrow(int bookId, int memberId)
        {
            try
            {
                connection.Open();
                var checkLoan = new SQLiteCommand(@"
    SELECT COUNT(*) 
    FROM Loans 
    WHERE BookId = @BookId 
      AND MemberId = @MemberId
      AND IsReturned = 0;", connection);

                checkLoan.Parameters.AddWithValue("@BookId", bookId);
                checkLoan.Parameters.AddWithValue("@MemberId", memberId);

                long existing = (long)checkLoan.ExecuteScalar();
                if (existing == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public bool Suspension()
        {
            DateTime today = DateTime.Now;
            DateTime suspenEnd = today.AddDays(14);
            try
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    var updateMember = new SQLiteCommand(@"
                UPDATE Members
                SET SuspensionEndDate = @suspenEnd
                WHERE MemberId IN (
                    SELECT MemberId
                    FROM Loans
                    WHERE IsReturned = 0
                      AND DueDate < @Today
                    GROUP BY MemberId
                    HAVING COUNT(*) >= 3
                );", conn, transaction);

                    updateMember.Parameters.AddWithValue("@Today", today);
                    updateMember.Parameters.AddWithValue("@suspenEnd", suspenEnd);

                    int rowsAffected = updateMember.ExecuteNonQuery();

                    transaction.Commit();

                    if (rowsAffected > 0)
                    {
                        transaction.Rollback();
                        return true;
                    }
                else
                    {
                        return false;
                    }
                }
                
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }
   
        public bool returnLoaned(int bookId, int memberId)
        {

            DateTime dateBorrowed = DateTime.Now, dueDate = dateBorrowed.AddDays(14), dateReturned = DateTime.Now;
            try
            {
                connection.Open();

                using (var fkCmd = new SQLiteCommand("PRAGMA foreign_keys = ON;", connection))
                {
                    fkCmd.ExecuteNonQuery();
                }

                using (var transaction = connection.BeginTransaction())
                {

                    var updateLoan = new SQLiteCommand(@"
    UPDATE Loans
    SET IsReturned = 1,
        ReturnDate = @ReturnDate
    WHERE Id = (
        SELECT Id FROM Loans
        WHERE BookId = @BookId
          AND MemberId = @MemberId
          AND IsReturned = 0
        ORDER BY DateBorrowed ASC
    );", connection, transaction);

                    updateLoan.Parameters.AddWithValue("@ReturnDate", DateTime.Now.ToString("yyyy-MM-dd"));
                    updateLoan.Parameters.AddWithValue("@BookId", bookId);
                    updateLoan.Parameters.AddWithValue("@MemberId", memberId);

                    int rowsAffected = updateLoan.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        transaction.Rollback();
                        return false;
                    }
                    var updateBook = new SQLiteCommand(
                        "UPDATE Books SET AvailableCopies = AvailableCopies + 1 WHERE BookId = @BookId",
                        connection, transaction);

                    updateBook.Parameters.AddWithValue("@BookId", bookId);
                    updateBook.ExecuteNonQuery();

                    var updateMember = new SQLiteCommand(
                        "UPDATE Members SET BorrowedBooksCount = BorrowedBooksCount - 1 WHERE MemberId = @MemberId",
                        connection, transaction);

                    updateMember.Parameters.AddWithValue("@MemberId", memberId);
                    updateMember.ExecuteNonQuery();


                    transaction.Commit();
                    return true;
                }
                }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        public DataTable displayLoans()
        {
            DataTable dt = new DataTable();

            try
            {
                connection.Open();
                var displayLoaned = new SQLiteCommand(@"SELECT * FROM Loans", connection);
                displayLoaned.ExecuteNonQuery();
                SQLiteDataAdapter da = new SQLiteDataAdapter(displayLoaned);
                da.Fill(dt);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return dt;
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

        //mothod disfunctional
        public void UpdateBook(string isbn, int addedCopies)
        {
            try
            {
                connection.Open();
                var updBook = new SQLiteCommand(@"UPDATE Books SET TotalCopies = TotalCopies + @addedCopies,
        AvailableCopies = AvailableCopies + @addedCopies
                                                      WHERE ISBN = @isbn
                                                 ", connection);
                updBook.Parameters.AddWithValue("@isbn", isbn);
                updBook.Parameters.AddWithValue("@addedCopies", addedCopies);
                updBook.ExecuteNonQuery();
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
                                        WHERE BookId LIKE @srchPar

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
                    var command = new SQLiteCommand(@"
                        INSERT INTO Books (ISBN, Title, Author, Genre, Description, AvailableCopies, TotalCopies)
                        VALUES (@ISBN, @Title, @Author, @Genre, @Description, @AvailableCopies, @TotalCopies)", connection, transaction);

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
                    //var clearBooks = new SQLiteCommand("DELETE FROM Books", connection);
                    //clearBooks.ExecuteNonQuery();
                    //var command3 = new SQLiteCommand(@"DROP TABLE Loans", connection); command3.ExecuteNonQuery();
                    //var command1 = new SQLiteCommand(@"DROP TABLE Books", conn); command1.ExecuteNonQuery();
                    transaction.Commit();
                 
                }

            }
            catch (Exception m)
            {
                MessageBox.Show(m.Message);
                throw new Exception($"operation unsuccessful {m.Message}");
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }


        }
   
        public void reset()
        {
            try
            {
                connection.Open();
                var resetValues = new SQLiteCommand(@"UPDATE Members SET BorrowedBooksCount = 0 WHERE BorrowedBooksCount < 10", connection);
                resetValues.ExecuteNonQuery();
                int updates = resetValues.ExecuteNonQuery();
                Console.WriteLine(updates);
            }
            catch (Exception e){ Console.WriteLine(e.Message); }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

    }
}
