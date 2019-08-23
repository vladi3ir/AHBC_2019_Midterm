using System;
using System.Collections.Generic;

namespace AHBC_2019_Midterm_JulyBC
{
    public class Checkout
    {

        public static void Checkout(List<Book> cart)
        {
            foreach (var item in cart)
            {
                item.IsCheckedOut = true;
                item.ReturnDate = DateTime.Now.AddDays(14);
            }
        }
    }
}

