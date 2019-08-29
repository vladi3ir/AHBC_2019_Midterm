using System;
using System.Collections.Generic;

namespace AHBC_2019_Midterm_JulyBC
{
    public static class Checkout
    {

        public static void CheckoutBook(List<Book> book)
        {
            foreach (var item in book)
            {
                item.IsCheckedOut = true;
                item.ReturnDate = DateTime.Now.AddDays(14);
            }
        }

        public static void ReturnBook(Book book)
        {
            book.IsCheckedOut = false;
        }
    }
}