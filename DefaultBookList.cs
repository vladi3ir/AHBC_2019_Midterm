using System;
using System.Collections.Generic;

namespace AHBC_2019_Midterm_JulyBC
{
    public static class DefaultBookList
    {
        public static List<Book> PopulateDefaultBookList()
        {
            List<Book> books = new List<Book>
            {
            new Book("20 Love Poems and a Song of Despair", "Pablo Neruda", false),
            new Book("1984", "Geogre Orwell", true, new DateTime(2019,9,30)),
            new Book("The Art of War", "Sun Tsu", true, new DateTime(2019,8,25)),
            new Book("48 Laws of Power", "Robert Greene", false),
            new Book("Moby Dick", "Herman Melville",false),
            new Book("War and Peace","Leo Tolstoy", true, new DateTime(2019,8,28)),
            new Book("Hamlet", "william Shakespare", false),
            new Book("Heart of Darkness", "Joseph Conrad",false),
            new Book("Invisible Man", "Ralah Ellison", true, new DateTime(2019,12,1)),
            new Book("To Kill a Mockingbird", "Harper Lee", false),
            new Book("As I Lay Dying", "William Faulkner", false),
            new Book("The Lord of the Rings", "J.R.R. Tolkien", false)
            };

            SaveLoad.Save(books);
            return books;
        }
    }
}
