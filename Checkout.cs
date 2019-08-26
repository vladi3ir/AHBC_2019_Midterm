using System;
using System.Collections.Generic;

namespace AHBC_2019_Midterm_JulyBC
{
    public static class Checkout
    {

        public static void CheckoutBook(Book book)
        {
            book.IsCheckedOut = true;
            book.ReturnDate = DateTime.Now.AddDays(14);
        }

        public static void ReturnBook(Book book)
        {
            book.IsCheckedOut = false;
        }

        public static List<Book> EmptyCart(List<Book> cart)
        {
            List<Book> emptyCart = new List<Book>();
            return emptyCart;
        }
    }

}