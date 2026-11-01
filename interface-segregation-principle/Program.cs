using System;

namespace ISP
{
    // ==================================================
    // EXAMPLE: VIOLATING ISP
    // ==================================================

    #region Violating ISP

    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
    }

    // A large interface containing multiple responsibilities.
    public interface IUser
    {
        void BorrowBook(string bookId);
        void ReturnBook(string bookId);
        void SearchCatalog(string searchTerm);
        void AddBook(Book book);
        void RemoveBook(string bookId);
    }

    // Guest is forced to implement methods it does not need.
    public class Guest : IUser
    {
        public void BorrowBook(string bookId)
        {
            throw new NotImplementedException(
                "Guests cannot borrow books.");
        }

        public void ReturnBook(string bookId)
        {
            throw new NotImplementedException(
                "Guests cannot return books.");
        }

        public void SearchCatalog(string searchTerm)
        {
            Console.WriteLine(
                $"Guest Search Book, Search Catalog: {searchTerm}");
        }

        public void AddBook(Book book)
        {
            throw new NotImplementedException(
                "Guests cannot add books.");
        }

        public void RemoveBook(string bookId)
        {
            throw new NotImplementedException(
                "Guests cannot remove books.");
        }
    }

    #endregion

    // ==================================================
    // EXAMPLE 2: FOLLOWING ISP
    // ==================================================

    #region Following ISP

    public class BookIsp
    {
        public string BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }

        public override string ToString()
        {
            return $"[BookId: {BookId}, Title: {Title}, Author: {Author}, ISBN: {ISBN}]";
        }
    }

    // Each interface represents a specific capability.

    public interface IBorrowReturn
    {
        void BorrowBook(string bookId);
        void ReturnBook(string bookId);
    }

    public interface ISearchable
    {
        void SearchCatalog(string searchTerm);
    }

    public interface IManageInventory
    {
        void AddBook(BookIsp book);
        void RemoveBook(string bookId);
    }

    // Member can borrow, return and search books.
    public class Member : IBorrowReturn, ISearchable
    {
        public void BorrowBook(string bookId)
        {
            Console.WriteLine(
                $"Member Borrow Book, BookId: {bookId}");
        }

        public void ReturnBook(string bookId)
        {
            Console.WriteLine(
                $"Member Return Book, BookId: {bookId}");
        }

        public void SearchCatalog(string searchTerm)
        {
            Console.WriteLine(
                $"Member Search Book, Search Catalog: {searchTerm}");
        }
    }

    // Librarian can perform all available operations.
    public class Librarian : IBorrowReturn, ISearchable, IManageInventory
    {
        public void BorrowBook(string bookId)
        {
            Console.WriteLine(
                $"Librarian Borrow Book, BookId: {bookId}");
        }

        public void ReturnBook(string bookId)
        {
            Console.WriteLine(
                $"Librarian Return Book, BookId: {bookId}");
        }

        public void SearchCatalog(string searchTerm)
        {
            Console.WriteLine(
                $"Librarian Search Book, Search Catalog: {searchTerm}");
        }

        public void AddBook(BookIsp book)
        {
            Console.WriteLine(
                $"Librarian Add Book, {book}");
        }

        public void RemoveBook(string bookId)
        {
            Console.WriteLine(
                $"Librarian Remove Book, BookId: {bookId}");
        }
    }

    // Guest only needs the search capability.
    public class GuestIsp : ISearchable
    {
        public void SearchCatalog(string searchTerm)
        {
            Console.WriteLine(
                $"Guest Search Book, Search Catalog: {searchTerm}");
        }
    }

    #endregion

    // ==================================================
    // PROGRAM
    // ==================================================

    class Program
    {
        static void Main(string[] args)
        {
            // ==========================================
            // CASE 1: VIOLATING ISP
            // ==========================================

            Console.WriteLine("======================================");
            Console.WriteLine("       CASE 1: VIOLATING ISP");
            Console.WriteLine("======================================");

            Book book = new Book
            {
                Title = "SOLID Principle using C#",
                Author = "Pranaya Rout",
                ISBN = "ISBN-Demo"
            };

            Guest guest = new Guest();

            Console.WriteLine("\nGuest:");

            // Supported operation.
            guest.SearchCatalog("SOLID");

            // Unsupported operations.
            // Guest must implement these methods because
            // IUser forces it to implement every method.

            Console.WriteLine("\nTrying unsupported operations:");

            try
            {
                guest.BorrowBook("BK-10001");
            }
            catch (NotImplementedException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            try
            {
                guest.ReturnBook("BK-10001");
            }
            catch (NotImplementedException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            try
            {
                guest.AddBook(book);
            }
            catch (NotImplementedException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            try
            {
                guest.RemoveBook("BK-10001");
            }
            catch (NotImplementedException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            // ==========================================
            // CASE 2: FOLLOWING ISP
            // ==========================================

            Console.WriteLine("\n======================================");
            Console.WriteLine("       CASE 2: FOLLOWING ISP");
            Console.WriteLine("======================================");

            BookIsp bookIsp = new BookIsp
            {
                BookId = "BK-10001",
                Title = "SOLID Principle using C#",
                Author = "Pranaya Rout",
                ISBN = "ISBN-Demo"
            };

            // ------------------------------------------
            // Guest: Search only.
            // ------------------------------------------

            Console.WriteLine("\nGuest:");

            GuestIsp guestIsp = new GuestIsp();

            guestIsp.SearchCatalog("SOLID");

            // Compile-time error:
            // GuestIsp does not implement IBorrowReturn.
            // guestIsp.BorrowBook(bookIsp.BookId);

            // Compile-time error:
            // GuestIsp does not implement IManageInventory.
            // guestIsp.AddBook(bookIsp);

            // ------------------------------------------
            // Member: Borrow, Return and Search.
            // ------------------------------------------

            Console.WriteLine("\nMember:");

            Member member = new Member();

            member.BorrowBook(bookIsp.BookId);
            member.SearchCatalog("SOLID");
            member.ReturnBook(bookIsp.BookId);

            // Compile-time error:
            // Member does not implement IManageInventory.
            // member.AddBook(bookIsp);

            // member.RemoveBook(bookIsp.BookId);

            // ------------------------------------------
            // Librarian: All available operations.
            // ------------------------------------------

            Console.WriteLine("\nLibrarian:");

            Librarian librarian = new Librarian();

            librarian.AddBook(bookIsp);
            librarian.BorrowBook(bookIsp.BookId);
            librarian.SearchCatalog("SOLID");
            librarian.ReturnBook(bookIsp.BookId);
            librarian.RemoveBook(bookIsp.BookId);

            // ==========================================
            // END
            // ==========================================

            Console.WriteLine("\n======================================");
            Console.WriteLine("          PROGRAM FINISHED");
            Console.WriteLine("======================================");

            Console.ReadKey();
        }
    }
}
