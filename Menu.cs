using System;
using System.Collections.Generic;

namespace AHBC_2019_Midterm_JulyBC
{
    public class Menu
    {
        public static void DisplayMenuOptions()
        {
            Console.WriteLine("1. Display all books");
            Console.WriteLine("2. Search by author");
            Console.WriteLine("3. Search by title");
            Console.WriteLine("4. Quit");
        }

        public static void DisplayBookList(List<Book> bookList)
        {
            int i = 1;

            foreach(Book book in bookList)
            {
                string bookStatus = "Available";

                if (book.IsCheckedOut)
                {
                    bookStatus = "Checked Out";
                }

                Console.WriteLine($"{i}. {book.Title} by {book.Author} | Status: {bookStatus}");
                i++;
            }
        }
    }
}
