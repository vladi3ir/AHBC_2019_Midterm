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

            Console.WriteLine($"\r\nHere is your whats in your cart:");
            Menu.DisplayBookList(cart);


            if (cart.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Your cart is Empty! Press enter to continue.");
                Console.ReadLine();
            }
            else
            {

                do
                {
                    Console.WriteLine("would you like to: \r\n 1. Checkout \r\n 2. Empty Cart \r\n 3. Go Back");
                    string cartChoice = Console.ReadLine().ToLower();

                    if (cartChoice == "1" || cartChoice == "one")
                    {
                        Checkout.CheckoutBook(cart);
                        validInput = true;
                        Console.Clear();
                        Console.WriteLine($"The following books have been checked out.");
                        Menu.DisplayBookList(cart);
                        Console.WriteLine("Press enter to continue.");
                        Console.ReadLine();
                        Console.Clear();
                        cart.Clear();
                    }
                    else if (cartChoice == "2" || cartChoice == "two")
                    {
                        Console.Clear();
                        Console.WriteLine("You cart have been cleared. Press enter to continue.");
                        Console.ReadLine();
                        cart.Clear();
                        validInput = true;
                    }
                    else if (cartChoice == "3" || cartChoice == "three")
                    {
                        validInput = true;
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("That is not a valid entry. Please press enter to try again.");
                        Console.ReadLine();
                        validInput = false;
                    }
                } while (!validInput);
            }
        }
                   
    }
    
}
