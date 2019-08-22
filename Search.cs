using System;
using System.Collections.Generic;

namespace AHBC_2019_Midterm_JulyBC
{
    class Search
    {
        public string _list { get; set; }
        public Search(string list)
        {
            _list = list;

        }
        ////public static List<string> SearchList(string userSearchInput, List<string> author, List<string>title, List<string> keyword)
        ////{
        ////    List<string> tempList = new List<string>();

        ////    //Console.WriteLine("Search by Title, Author, or keyword");
        ////    //string userInput = Console.ReadLine();

        ////    foreach (var item in author)
        ////    {
        ////        author.Contains(userSearchInput);
        ////        title.Contains(userSearchInput);
        ////    }

        ////    return tempList;
        ////}

        //    public List<Book> SearchByTitle(string userInput, List<Book> listOfBooks)
        //    {
        //        List<Book> searchResults = new List<Book>();
        //        foreach (Book book in listOfBooks)
        //        {
        //            if (book.Title.Contains(userInput, StringComparison.OrdinalIgnoreCase))
        //            {
        //                searchResults.Add(book);
        //            }
        //        }

        //        return searchResults;
        //    }
        //}
    }
}
