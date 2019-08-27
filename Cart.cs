using System;
using System.Collections.Generic;
using System.Text;

namespace AHBC_2019_Midterm_JulyBC
{
    public static class Cart
    {
        public static void BringUpCart(List<Book> cart)
        {
            bool validInput = false;

            Console.WriteLine(@"    \________ ");
            Console.WriteLine(@" ~   \######/ ");
            Console.WriteLine(@"  ~   |####/");
            Console.WriteLine(@" ~    |____.");
            Console.WriteLine(@"______o____o___");

            Console.WriteLine($"Here is your whats in your cart:");
            Menu.DisplayBookList(cart);

            do
            {
                Console.WriteLine("would you like to: \r\n 1. Checkout \r\n 2. Empty Cart \r\n 3. Go Back");
                string cartChoice = Console.ReadLine().ToLower();

                if (cartChoice == "1" || cartChoice == "one")
                {
                    Checkout.CheckoutBook(cart);
                    validInput = true;
                    Console.WriteLine("Your book(s) have been checked out");
                }
                else if (cartChoice == "2" || cartChoice == "two")
                {
                    cart.Clear();
                    validInput = true;
                }
                else if (cartChoice == "3" || cartChoice == "three")
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("That is not a valid entry. Please try again:");
                    validInput = false;
                }
            } while (!validInput);
        }

                   
    }
    
}
