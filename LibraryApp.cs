using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AHBC_2019_Midterm_JulyBC
{
    public class LibraryApp
    {
        public Search search { get; set; }
        public List<Book> bookList { get; set; }
        public List<Book> searchResults { get; set; }
        public List<Book> cart { get; set; }
        public bool appRunning { get; set; }     

        public void StartApp()
        {
            search = new Search();
            bookList = SaveLoad.Load();
            searchResults = new List<Book>();
            cart = new List<Book>();
            appRunning = false;

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
                    Console.Clear();
                    Cart.BringUpCart(cart);
                    appRunning = true;
                    SaveLoad.Save(bookList);
                    return;

                case MenuOptions.Quit:
                    appRunning = false;
                    SaveLoad.Save(bookList);
                    return;

                default: return;
            }
        }
    }
}
