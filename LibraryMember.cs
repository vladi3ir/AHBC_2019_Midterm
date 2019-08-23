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

        public static Book SelectBook(List<Book> bookList)
        {
            int userInput = 0;
            bool validInput;
            bool isBook = false;

            do
            {
                validInput = int.TryParse(Console.ReadLine(), out int result);

                if (validInput)
                {
                    userInput = result;
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("That was not a valid entry. Please try again:");
                }
            } while (!validInput);

            do
            {
                if (bookList.Count >= (userInput))
                {
                    return bookList[userInput - 1];
                }
                else
                {
                    Console.WriteLine("That is not a valid entry. Please try again:");
                }
            } while (!isBook);

            return new Book("", "", false);
        }
    }
}