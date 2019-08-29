using System;
using System.Collections.Generic;
using System.Text;

namespace AHBC_2019_Midterm_JulyBC
{
    public static class AddRemove
    {
        public static void ManageLibrary(List<Book> books)
        {
            Console.Clear();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Add book to library");
            Console.WriteLine("2. Remove book from library");

            bool isValidInput = false;
            do
            {
                string userInput = Console.ReadLine();
                if ((userInput.Equals("1", StringComparison.OrdinalIgnoreCase)))
                {
                    AddBook(books);
                    isValidInput = true;

                }
                else if ((userInput.Equals("2", StringComparison.OrdinalIgnoreCase)))
                {
                    RemoveBook(books);
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Not a valid input, try again.");
                    isValidInput = false;
                }
            } while (!isValidInput);
            return;
        }

        public static void AddBook(List<Book> books)
        {
            string title;
            string author;
            Console.Clear();
            Console.WriteLine("Add a new book to the library:");

            Console.Write("Book title: ");
            do
            {
                title = Console.ReadLine();
                if (title == "")
                {
                    Console.WriteLine("Please enter something for title.");
                }
                if (title.Contains("//"))
                {
                    Console.WriteLine("I'm sorry, but the title can not contain '//'.");
                }
            } while (title == "" && !title.Contains("//"));

            Console.Write("Author: ");
            do
            {
                author = Console.ReadLine();
                if (author == "")
                {
                    Console.WriteLine("Please enter something for author.");
                }
                if (author.Contains("//"))
                {
                    Console.WriteLine("I'm sorry, but the author can not contain '//'.");
                }

            } while (author == "" && !title.Contains("//"));

            Book book = new Book(title, author, false);
            books.Add(book);

            Console.Clear();
            Console.WriteLine($"You've added {book.Title} by {book.Author} to the library.");
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();

            return;
        }

        public static void RemoveBook(List<Book> books)
        {
            Console.Clear();
            Console.WriteLine("How do you want to find a book to remove?");
            Console.WriteLine("1. Display all books");
            Console.WriteLine("2. Search by author");
            Console.WriteLine("3. Search by title");
            Book selectedBook = RemoveBookOptions(books);

            Console.WriteLine($"Are you sure you want to remove {selectedBook.Title} from the library? [Y/N]");
            bool validInput = false;
            do
            {
                string userInput = Console.ReadLine();
                if ((userInput.Equals("Y", StringComparison.OrdinalIgnoreCase)))
                {
                    books.Remove(selectedBook);
                  
                }
                else if ((userInput.Equals("N", StringComparison.OrdinalIgnoreCase)))
                {    
                    return;
                }
                else
                {
                    Console.WriteLine("Not a valid input, try again.");
                    validInput = false;
                }
            } while(!validInput);

            Console.WriteLine($"You've removed {selectedBook} from the library.");
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }

        private static Book RemoveBookOptions(List<Book> books)
        {
            bool isValidOption = true;

            do
            {
                switch (Console.ReadLine().ToLower())
                {
                    case "one":
                    case "1":
                        return LibraryMember.SelectBook(books);
                        
                    case "two":
                    case "2":
                        return LibraryMember.SelectBook(LibraryMember.MemberSearchByAuthor(books));
                       
                    case "three":
                    case "3":
                        return LibraryMember.SelectBook(LibraryMember.MemberSearchByTitle(books));
                        
                    default:
                        Console.WriteLine("That is not a valid entry. Please try again:");
                        isValidOption = false;
                        break;
                }
                return new Book("title", "author", false);

            } while (!isValidOption);
        }
    }
}
