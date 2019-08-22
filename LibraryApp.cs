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
      
            MenuOptions choice = LibraryMember.GetMenuSelection();

            switch (choice)
            {
                case MenuOptions.DisplayAll:
                    return; 
                case MenuOptions.SearchByAuthor:
                    LibraryMember.MemberSearchByAuthor(bookList);
                    return;
                case MenuOptions.SearchByTitle:
                    LibraryMember.MemberSearchByTitle(bookList);
                    return;
                case MenuOptions.CheckOutBook:
                    return;
                case MenuOptions.ReturnBook:
                    return;
                case MenuOptions.Quit:
                    return;

                default:
                    break;
            }

          

        }

    }
}
