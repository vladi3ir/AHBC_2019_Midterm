using System;
using System.Collections.Generic;

namespace AHBC_2019_Midterm_JulyBC
{
    public static class Checkout
    {

        public static void CheckoutBook(List<Book> cart)
        {
            foreach (var item in cart)
            {
                item.IsCheckedOut = true;
                item.ReturnDate = DateTime.Now.AddDays(14);
            }
        }

        public static void RetrunBook(List<Book> cart)

        {

            foreach (var item in cart)
            {

                item.IsCheckedOut = false;

            }

        }
    }
}

