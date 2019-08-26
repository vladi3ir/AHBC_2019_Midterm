using System;
using System.Collections.Generic;

namespace AHBC_2019_Midterm_JulyBC
{
    public class LibraryMember
    {
        public static MenuOptions GetMenuSelection()
        {
            Console.WriteLine("What would you like to do? Select a number from the following options:");
            Menu.DisplayMenuOptions();
            bool isValidOption;

            do
            {
                switch (Console.ReadLine().ToLower())
                {
                    case "one":
                    case "1":
                        return MenuOptions.DisplayAll;
                    case "two":
                    case "2":
                        return MenuOptions.SearchByAuthor;
                    case "three":
                    case "3":
                        return MenuOptions.SearchByTitle;
                    case "four":
                    case "4":
                        return MenuOptions.Quit;
                    default:
                        Console.WriteLine("That is not a valid entry. Please try again:");
                        isValidOption = false;
                        break;
                }
            } while (!isValidOption);

            return MenuOptions.Quit;
        }

        public static List<Book> MemberSearchByAuthor(List<Book> allBooksList)
        {
            Console.WriteLine("Enter the author you'd like to search:");
            string userInput = Console.ReadLine();
            var searcher = new Search();
            var searchResults = searcher.SearchByAuthor(userInput, allBooksList);

            if (searchResults.Count == 0)
            {
                Console.WriteLine("No results found.");
            }
            else
            {
                Console.WriteLine("Search results:");
                Menu.DisplayBookList(searchResults);
            }

            return searchResults;
        }

        public static List<Book> MemberSearchByTitle(List<Book> allBooksList)
        {
            Console.WriteLine("Enter the keyword you'd like to search:");
            string userInput = Console.ReadLine();
            var searcher = new Search();
            var searchResults = searcher.SearchByTitle(userInput, allBooksList);

            if (searchResults.Count == 0)
            {
                Console.WriteLine("No results found.");
            }
            else
            {
                Console.WriteLine("Search results:");
                Menu.DisplayBookList(searchResults);
            }

            return searchResults;
        }

        public static void SelectFromList(List<Book> bookList, List<Book> cart)
        {
            Console.WriteLine("Select a book from the list above.");
            var selectedBook = SelectBook(bookList);
            bool validInput = false;

            if (selectedBook.IsCheckedOut)
            {
                Console.WriteLine("Would you like to return this book (Y/N)?");
                do
                {
                    var userInput = Console.ReadLine();
                    if (userInput.Equals("Y", StringComparison.OrdinalIgnoreCase))
                    {
                        validInput = true;
                        Checkout.RetrunBook(selectedBook);
                    }
                    else if (userInput.Equals("N", StringComparison.OrdinalIgnoreCase))
                    {
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("That is not a valid entry. Please try again:");
                    }
                } while (!validInput);
            }
            else
            {
                Console.WriteLine("Add book to cart (Y/N)?");
                do
                {
                    var userInput = Console.ReadLine();
                    if (userInput.Equals("Y", StringComparison.OrdinalIgnoreCase))
                    {
                        validInput = true;
                        cart.Add(selectedBook);
                    }
                    else if (userInput.Equals("N", StringComparison.OrdinalIgnoreCase))
                    {
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("That is not a valid entry. Please try again:");
                    }
                } while (!validInput);
            }
        }

        public static Book SelectBook(List<Book> bookList)
        {
            int userInput;
            bool validInput;

            do
            {
                validInput = int.TryParse(Console.ReadLine(), out int result);

                if (validInput)
                {
                    userInput = result;

                    if (bookList.Count >= (userInput))
                    {
                        return bookList[userInput - 1];
                    }
                    else
                    {
                        Console.WriteLine("That is not a valid entry. Please try again:");
                        validInput = false;
                    }
                }
                else
                {
                    Console.WriteLine("That was not a valid entry. Please try again:");
                }
            } while (!validInput);

            return new Book("", "", false);
        }
    }
}