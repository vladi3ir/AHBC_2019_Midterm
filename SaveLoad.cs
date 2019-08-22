using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AHBC_2019_Midterm_JulyBC
{
    class SaveLoad 
    {
        public List<String> BooksStringList { get; set; }
        public List<Books> BooksList { get; set; }

        public void Save(List<Books> bookList) 
        {
            using (var writer = new StreamWriter("./LibrarySaveFile.txt", false))  //  (file location, bool for overwrite[false] or append[true])
            {
                foreach (var item in bookList)
                {
                    string title = item.Title.ToString();
                    string author = item.Author.ToString();
                    string status = item.IsCheckedOut.ToString();
                    string returnDate = item.ReturnDate.ToString();

                    var saveLine = (title, author, status, returnDate);

                    writer.WriteLine(saveLine);
                }
            }
        }

        public List<Books> Load()  //Probably going to output a list of books
        {
            using (var reader = new StreamReader("./LibrarySaveFile.txt"))
            {
                var entireFile = reader.ReadToEnd();
                var linesArray = entireFile.Split("\r\n");
                List<Books> _BookList = new List<Books>();

                var line = reader.ReadLine();

                foreach (var _line in linesArray)
                {
                    string[] bookInfo = _line.Split(",");

                    string title = bookInfo[0];
                    string author = bookInfo[1];
                    bool isCheckedOut = Convert.ToBoolean(bookInfo[2]);
                    DateTime returnDate = Convert.ToDateTime(bookInfo[3]);

                    _BookList.Add(new Books(title, author, isCheckedOut, returnDate));

                }


                return _BookList;

            }
        }


    }
}
