using System;
using System.Collections.Generic;
using System.Text;

namespace AHBC_2019_Midterm_JulyBC
{
    public class LibraryApp
    {
        public void StartApp()
        {
            
            var search = new Search();

            List<Book> books = new List<Book>
            {
            new Book("20 Love Poems and a Song of Despair", "Pablo Neruda", true, new DateTime()),
            new Book("1984", "Geogre Orwell", false, new DateTime(2019,9,30)),
            new Book("The Art of War", "Sun Tsu", false, new DateTime(2019,8,25)),
            new Book("48 Laws of Power", "Robert Greene", true, new DateTime()),
            new Book("Moby Dick", "Herman Melville", true,new DateTime()),
            new Book("War and Peace","Leo Tolstoy", false, new DateTime(2019,8,28)),
            new Book("Hamlet", "william Shakespare", true, new DateTime()),
            new Book("Heart of Darkness", "Joseph Conrad",true, new DateTime()),
            new Book("Invisible Man", "Ralah Ellison", false, new DateTime(2019,12,1)),
            new Book("To Kill a Mockingbird", "Harper Lee", true, new DateTime()),
            new Book("As I Lay Dying", "William Faulkner", true, new DateTime()),
            new Book("The Lord of the Rings", "J.R.R. Tolkien", true, new DateTime())
            };


            var results = search.SearchByTitle(Console.ReadLine(), books);

            foreach (var item in results)
            {
                Console.WriteLine($"{item.Author}, {item.Title}");
            }


            MenuOptions choice = LibraryMember.GetMenuSelection();

            switch (choice)
            {
                case 1:
                    return ;


                default:
                    break;
            }
          

        }

    }
}
