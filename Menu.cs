using System;
using System.Collections.Generic;

namespace AHBC_2019_Midterm_JulyBC
{
    public class Menu
    {
        public static void DisplayMenuOptions()
        {
            Console.WriteLine("What would you like to do today? Select from the following options:");
            Console.WriteLine("1. Display all books");
            Console.WriteLine("2. Search by author");
            Console.WriteLine("3. Search by title");
            Console.WriteLine("4. Check out a book");
            Console.WriteLine("5. Return a book");
        }

        public static void DisplayBookList(List<Book> bookList)
        {
            foreach(Book book in bookList)
            {
                Console.WriteLine($"{book.Title} by {book.Author}");
            }
        }
    }
}
