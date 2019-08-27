using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AHBC_2019_Midterm_JulyBC
{
    public class LibraryApp
    {
      
        Search search = new Search();
        List<Book> bookList = SaveLoad.Load();
        List<Book> searchResults = new List<Book>();
        List<Book> cart = new List<Book>();
        bool appRunning = false;

        public void StartApp()
        {
            do
            {
                MenuOptions choice = LibraryMember.GetMenuSelection();
                ExecuteMainMenuChoice(choice, bookList);
            } while (appRunning); 
        }

        public void ExecuteMainMenuChoice(MenuOptions choice, List<Book> bookList)
        {
            var searchResults = new List<Book>();
            switch (choice)
            {
                case MenuOptions.DisplayAll:
                    Console.Clear();
                    Menu.DisplayBookList(bookList);
                    searchResults = bookList;
                    LibraryMember.SelectFromList(searchResults, cart);
                    appRunning = true;
                    return;

                case MenuOptions.SearchByAuthor:
                    Console.Clear();
                    searchResults = LibraryMember.MemberSearchByAuthor(bookList);
                    LibraryMember.SelectFromList(searchResults, cart);
                    appRunning = true;
                    return;

                case MenuOptions.SearchByTitle:
                    Console.Clear();
                    searchResults = LibraryMember.MemberSearchByTitle(bookList);
                    LibraryMember.SelectFromList(searchResults, cart);
                    appRunning = true;
                    return;

                case MenuOptions.GoToCart:
                    Cart.BringUpCart(cart);
                    appRunning = true;
                    SaveLoad.Save(bookList);
                    return;

                case MenuOptions.Quit:
                    appRunning = false;
                    return;

                default: return;
            }

            }
    }

}
