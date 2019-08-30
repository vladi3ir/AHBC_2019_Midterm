using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AHBC_2019_Midterm_JulyBC
{
    public static class SaveLoad
    {
        public static void Save(List<Book> bookList) 
        {
            using (var writer = new StreamWriter("./LibrarySaveFile.txt", false))
            {
                IEnumerable<Book> orderedList = bookList.OrderBy(Book => Book.Title).ToList();
                foreach (var item in orderedList)
                {
                    string title = item.Title;
                    string author = item.Author;
                    string status = item.IsCheckedOut.ToString();
                    string returnDate = item.ReturnDate.ToString();

                    string saveLine = ($"{title}//{author}//{status}//{returnDate}");

                    writer.WriteLine(saveLine);
                }
            }
        }

        public static List<Book> Load()
        {      
            bool shouldGenerateList = !File.Exists("./LibrarySaveFile.txt");
            if (shouldGenerateList)
            {
                DefaultBookList.PopulateDefaultBookList();
            }

            using (var reader = new StreamReader("./LibrarySaveFile.txt"))
            {
                var entireFile = reader.ReadToEnd();
                var linesArray = entireFile.Split("\n");

                List<Book> _BookList = new List<Book>();
                
                foreach (var _line in linesArray)
                {
                    string[] bookInfo = _line.Split("//");

                    if (bookInfo.Length == 4)
                    {
                        string title = bookInfo[0];
                        string author = bookInfo[1];
                        bool isCheckedOut = Convert.ToBoolean(bookInfo[2]);
                        DateTime returnDate = Convert.ToDateTime(bookInfo[3]);

                        _BookList.Add(new Book(title, author, isCheckedOut, returnDate));
                    }
                }
                return _BookList;  
            }
        }
    }
}