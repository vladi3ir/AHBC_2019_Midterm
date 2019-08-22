using System;
using System.Collections.Generic;
using System.Text;

namespace AHBC_2019_Midterm_JulyBC
{
    public class BookList
    {

        List<Books> books = new List<Books>
        {
            new Books("20 Love Poems and a Song of Despair", "Pablo Neruda", true, new DateTime()),
            new Books("1984", "Geogre Orwell", false, new DateTime(2019,9,30)),
            new Books("The Art of War", "Sun Tsu", false, new DateTime(2019,8,25)),
            new Books("48 Laws of Power", "Robert Greene", true, new DateTime()),
            new Books("Moby Dick", "Herman Melville", true,new DateTime()),
            new Books("War and Peace","Leo Tolstoy", false, new DateTime(2019,8,28)),
            new Books("Hamlet", "william Shakespare", true, new DateTime()),
            new Books("Heart of Darkness", "Joseph Conrad",true, new DateTime()),
            new Books("Invisible Man", "Ralah Ellison", false, new DateTime(2019,12,1)),
            new Books("To Kill a Mockingbird", "Harper Lee", true, new DateTime()),
            new Books("As I Lay Dying", "William Faulkner", true, new DateTime()),
            new Books("The Lord of the Rings", "J.R.R. Tolkien", true, new DateTime())
        };

        
    }

}

