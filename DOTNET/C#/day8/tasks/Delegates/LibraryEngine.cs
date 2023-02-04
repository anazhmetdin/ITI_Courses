using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    public delegate string BookDelegate (Book book);
    internal class LibraryEngine
    {
        public static void ProcessBooks(List<Book> bList
        , BookDelegate fPtr)

        {
            foreach (Book B in bList)
            {
                Console.WriteLine(fPtr?.Invoke(B)??"");
            }
        }

        public static void ProcessBooksBCL(List<Book> bList
        , Func<Book, string> fPtr)

        {
            foreach (Book B in bList)
            {
                Console.WriteLine(fPtr?.Invoke(B) ?? "");
            }
        }
    }
}
