﻿using System;
using System.Collections.Generic;
using System.Linq;

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
                        return MenuOptions.GoToCart;
                    case "five":
                    case "5":
                        return MenuOptions.ManageLibrary;
                    case "six":
                    case "6":
                        return MenuOptions.Quit;
                    default:
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine("That is not a valid entry. Please try again:");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Green;
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
                Console.WriteLine("No results found. Press enter to continue.");
                Console.ReadLine();
            }
            else
            {

                Console.Clear();
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
                Console.WriteLine("No results found. Press enter to continue.");
                Console.ReadLine();
            }
            else
            {

                Console.Clear();
                Console.WriteLine("Search results:");
                Menu.DisplayBookList(searchResults);
            }

            return searchResults;
        }

        public static void SelectFromList(List<Book> bookList, List<Book> cart)
        {
            if (bookList.Any())
            {
                var selectAgain = false;
                string userChoice = "";

                Console.WriteLine("Would you like to select a book (Y/N)?");
                do
                {
                    bool isValidInput;

                    do
                    {
                        if (selectAgain == false)
                        {
                            userChoice = Console.ReadLine();
                        }
                        if (userChoice.Equals("Y", StringComparison.OrdinalIgnoreCase))
                        {
                            isValidInput = true;
                            Console.WriteLine("Select a book by number from the list above.");
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
                                        Console.WriteLine($"You've returned {selectedBook.Title}. Press enter to continue.");
                                        Console.ReadLine();
                                    }
                                    else if (userInput.Equals("N", StringComparison.OrdinalIgnoreCase))
                                    {
                                        validInput = true;
                                    }
                                    else
                                    {
                                        Console.BackgroundColor = ConsoleColor.Red;
                                        Console.ForegroundColor = ConsoleColor.Black;
                                        Console.WriteLine("That is not a valid entry. Please try again:");
                                        Console.BackgroundColor = ConsoleColor.Black;
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine();
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
                                        if (!cart.Contains(selectedBook))
                                        {
                                            cart.Add(selectedBook);
                                            Console.WriteLine($"You've added {selectedBook.Title} to the cart. Press enter to continue.");
                                            Console.ReadLine();
                                        }
                                        else
                                        {
                                            Console.WriteLine("That book is already in the cart. Press enter to continue.");
                                            Console.ReadLine();
                                        }
                                    }
                                    else if (userInput.Equals("N", StringComparison.OrdinalIgnoreCase))
                                    {
                                        validInput = true;
                                    }
                                    else
                                    {
                                        Console.BackgroundColor = ConsoleColor.Red;
                                        Console.ForegroundColor = ConsoleColor.Black;
                                        Console.WriteLine("That is not a valid entry. Please try again:");
                                        Console.BackgroundColor = ConsoleColor.Black;
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine();

                                    }
                                } while (!validInput);
                            }
                        }
                        else if (userChoice.Equals("N", StringComparison.OrdinalIgnoreCase))
                        {
                            return;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine("That is not a valid entry. Please try again:");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine();

                            isValidInput = false;
                        }
                    } while (!isValidInput);

                    Console.WriteLine("Would you like to select another book from the list (Y/N)?");
                    bool isValid;
                    do
                    {
                        userChoice = Console.ReadLine();
                        if (userChoice.Equals("Y", StringComparison.OrdinalIgnoreCase))
                        {
                            isValid = true;
                            selectAgain = true;
                        }
                        else if (userChoice.Equals("N", StringComparison.OrdinalIgnoreCase))
                        {
                            isValid = true;
                            selectAgain = false;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine("That is not a valid entry. Please try again:");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine();
                            isValid = false;
                        }
                    } while (!isValid);   
                } while (selectAgain);
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

                    if (bookList.Count >= userInput)
                    {
                        return bookList[userInput - 1];
                    }

                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("That is not a valid entry. Please try again:");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine();
                    validInput = false;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("That is not a valid entry. Please try again:");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine();
                }
            } while (!validInput);

            return new Book("", "", false);
        }
    }
}