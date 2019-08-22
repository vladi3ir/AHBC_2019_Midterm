using System;
namespace AHBC_2019_Midterm_JulyBC
{
    public class LibraryMember
    {
        public static MenuOptions GetMenuSelection()
        {
            Console.WriteLine("What would you like to do? Select a number from the following options:");
            Menu.DisplayMenuOptions();
            bool isValidOption;

            do
            {
                switch (Console.ReadLine().ToLower())
                {
                    case "one":
                    case "1":
                        return MenuOptions.DisplayAll;
                    case "two":
                    case "2":
                        return MenuOptions.SearchByAuthor;
                    case "three":
                    case "3":
                        return MenuOptions.SearchByTitle;
                    case "four":
                    case "4":
                        return MenuOptions.CheckOutBook;
                    case "five":
                    case "5":
                        return MenuOptions.ReturnBook;
                    case "six":
                    case "6":
                        return MenuOptions.Quit;
                    default:
                        Console.WriteLine("That is not a valid entry. Please try again:");
                        isValidOption = false;
                        break;
                }
            } while (!isValidOption);

            return MenuOptions.Quit;
        }
    }
}
