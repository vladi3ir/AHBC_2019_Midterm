using System;
using System.Collections.Generic;

namespace AHBC_2019_Midterm_JulyBC
{
    public class Search
    {
        public List<Book> SearchByTitle(string userInput, List<Book> listOfBooks)
        {
            List<Book> searchResults = new List<Book>();
            foreach (Book book in listOfBooks)
            {
                if (book.Title.Contains(userInput, StringComparison.OrdinalIgnoreCase))
                {
                    searchResults.Add(book);
                }
            }

            return searchResults;
        }

        public List<Book> SearchByAuthor(string userInput, List<Book> listOfBooks)
        {
            List<Book> searchResults = new List<Book>();
            foreach (Book book in listOfBooks)
            {
                if (book.Author.Contains(userInput, StringComparison.OrdinalIgnoreCase))
                {
                    searchResults.Add(book);
                }
            }

            return searchResults;
        }
    }
}