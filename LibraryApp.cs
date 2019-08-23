using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AHBC_2019_Midterm_JulyBC
{
    public class LibraryApp
    {
        public void StartApp()
        {
            var search = new Search();
            
            List<Book> bookList = SaveLoad.Load();
            var searchResults = new List<Book>();
      
            MenuOptions choice = LibraryMember.GetMenuSelection();

            switch (choice)
            {
                case MenuOptions.DisplayAll:
                    Menu.DisplayBookList(bookList);
                    return; 
                case MenuOptions.SearchByAuthor:
                    searchResults = LibraryMember.MemberSearchByAuthor(bookList);
                    return;
                case MenuOptions.SearchByTitle:
                    searchResults = LibraryMember.MemberSearchByTitle(bookList);
                    Console.WriteLine("Select a book");
                    int choice2 = Int32.Parse(Console.ReadLine());
                    if (searchResults[choice2 - 1].IsCheckedOut)
                    {
                        Console.WriteLine($"Would you like to return {searchResults[choice2 - 1].}");
                    }
                    else
                    {
                        Console.WriteLine("Would you like to check this book out?");
                    }
                    return;
                case MenuOptions.Quit:
                    return;

                default:
                    break;
            }

            
          

        }

    }
}
