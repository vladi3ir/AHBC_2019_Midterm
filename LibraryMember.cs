using System;
using System.Collections.Generic;

namespace AHBC_2019_Midterm_JulyBC
{
    public class LibraryMember
    {
        public static MenuOptions GetMenuSelection()
        {
            Console.ForegroundColor = ConsoleColor.Green;

            #region INTRO

            Console.WriteLine(@"  ___  ____   __   __ _  ____     ___  __  ____   ___  _  _  ____    __    __  ____  ____   __   ____  _  _");
            Console.WriteLine(@" / __)(  _ \ / _\ (  ( \(    \   / __)(  )(  _ \ / __)/ )( \/ ___)  (  )  (  )(  _ \(  _ \ / _\ (  _ \( \/ )");
            Console.WriteLine(@"( (_ \ )   //    \/    / ) D (  ( (__  )(  )   /( (__ ) \/ (\___ \  / (_/\ )(  ) _ ( )   //    \ )   / )  / ");
            Console.WriteLine(@" \___/(__\_)\_/\_/\_)__)(____/   \___)(__)(__\_) \___)\____/(____/  \____/(__)(____/(__\_)\_/\_/(__\_)(__/  ");
            Console.WriteLine("       ");

            Console.WriteLine(@"                                ____________________________________________________");
            Console.WriteLine(@"                               |____________________________________________________|");
            Console.WriteLine(@"                               | __     __   ____   ___ ||  ____    ____     _  __  |");
            Console.WriteLine(@"                               ||  |__ |--|_| || |_|   |||_|**|*|__|+|+||___| ||  | |");
            Console.WriteLine(@"                               ||==|^^||--| |=||=| |=*=||| |~~|~|  |=|=|| | |~||==| |");
            Console.WriteLine(@"                               ||  |##||  | | || | |ED |||-|  | |==|+|+||-|-|~||__| |");
            Console.WriteLine(@"                               ||__|__||__|_|_||_|_|___|||_|__|_|__|_|_||_|_|_||__|_|");
            Console.WriteLine(@"                               ||_______________________||__________________________|");
            Console.WriteLine(@"                               | _____________________  ||      __   __  _  __    _ |");
            Console.WriteLine(@"                               ||=|=|=|=|=|=|=|=|=|=|=| __..\/ |  |_|  ||#||==|  / /|");
            Console.WriteLine(@"                               || | | | | | | | | | | |/\ \  \\|++|=|  || ||==| / / |");
            Console.WriteLine(@"                               ||_|_|_|_|_|_|_|_|_|_|_/_/\_.___\__|_|__||_||__|/_/__|");
            Console.WriteLine(@"                               |____________________ /\~()/()~//\ __________________|");
            Console.WriteLine(@"                               | __   __    _  _     \_  (_ .  _/ _      _     _____|");
            Console.WriteLine(@"                               ||~~|_|..|__| || |_ _   \ //\\ /  |=|_  /) |___| | | |");
            Console.WriteLine(@"                               ||--|+|^^|==|1||2| | |__/\ __ /\__| |(\/((\ +|+|=|=|=|");
            Console.WriteLine(@"                               ||__|_|__|__|_||_|_| /  \ \  / /  \_|_\___/|_|_|_|_|_|");
            Console.WriteLine(@"                               |_________________ _/    \/\/\/    \_ /   /__________|");
            Console.WriteLine(@"                               | _____   _   __  |/      \../      \/   /   __   ___|");
            Console.WriteLine(@"                               ||_____|_| |_|##|_||   |   \/ __\       /=|_|++|_|-|||");
            Console.WriteLine(@"                               ||______||=|#|--| |\   \   o     \_____/  |~|  | | |||");
            Console.WriteLine(@"                               ||______||_|_|__|_|_\   \  o     | |_|_|__|_|__|_|_|||");
            Console.WriteLine(@"                               |_________ __________\___\_______|____________ ______|");
            Console.WriteLine(@"                               |__    _  /    ________     ______           /| _ _ _|");
            Console.WriteLine(@"                               |\ \  |=|/   //    /| //   /  /  / |        / ||%|%|%|");
            Console.WriteLine(@"                               | \/\ |*/  .//____// //   /__/__/ (_)      /  ||=|=|=|");
            Console.WriteLine(@"                               |  \/\|/   /(____|/ //                    /  /||~|~|~|");
            Console.WriteLine(@"                               | ___\_/   /________//   ________         /  /||_|_|_|");
            Console.WriteLine(@"                               | ___ /   (|________/  |\_______\       /  /| |______|");
            Console.WriteLine(@"                                   /                  \|________)     /  / | |______|");
            Console.WriteLine("");
            Console.WriteLine("");
            #endregion

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
                        return MenuOptions.GoToCart;
                    case "five":
                    case "5":
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
                        Checkout.ReturnBook(selectedBook);
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