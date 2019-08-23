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
                    return;
                case MenuOptions.Quit:
                    return;
                default:
                    break;
            }

            
          

        }

    }
}
