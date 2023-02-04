using static System.Runtime.InteropServices.JavaScript.JSType;
using System;

namespace Delegates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = new() {
                new Book("12345", "book1 title", new string[] { "author1", "author2", "author3" }, DateTime.Now, 100),
                new Book("67890", "book2 title", new string[] { "author4", "author5", "author6" }, DateTime.Now, 150),
                new Book("13579", "book3 title", new string[] { "author7", "author8", "author9" }, DateTime.Now, 50)
            };

            BookDelegate fptr = new BookDelegate(BookFunctions.GetTitle);

            Console.WriteLine("\n________User Defined Delegate Datatype_______");
            LibraryEngine.ProcessBooks(books, fptr);


            fptr = BookFunctions.GetAuthors;

            Console.WriteLine("\n________User Defined Delegate Datatype_______");
            LibraryEngine.ProcessBooks(books, fptr);


            Func<Book, string> fptr1 = BookFunctions.GetPrice;

            Console.WriteLine("\n________BCL Delegates_______");
            LibraryEngine.ProcessBooksBCL(books, fptr1);


            fptr1 = delegate (Book book) { return book.ISBN; };

            Console.WriteLine("\n________Anonymous Method_______");
            LibraryEngine.ProcessBooksBCL(books, fptr1);


            fptr1 = book => book.PublicationDate.ToString();

            Console.WriteLine("\n________Lambda Expression_______");
            LibraryEngine.ProcessBooksBCL(books, fptr1);
        }
    }
}