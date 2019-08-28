using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AHBC_2019_Midterm_JulyBC
{
    public class LibraryApp
    {
        public Search search { get; set; }
        public List<Book> bookList { get; set; }
        public List<Book> searchResults { get; set; }
        public List<Book> cart { get; set; }
        public bool appRunning { get; set; }     

        public void StartApp()
        {
            search = new Search();
            bookList = SaveLoad.Load();
            searchResults = new List<Book>();
            cart = new List<Book>();
            appRunning = false;

            #region INTRO

            Console.WriteLine(@"  ___  ____   __   __ _  ____     ___  __  ____   ___  _  _  ____    __    __  ____  ____   __   ____  _  _");
            Console.WriteLine(@" / __)(  _ \ / _\ (  ( \(    \   / __)(  )(  _ \ / __)/ )( \/ ___)  (  )  (  )(  _ \(  _ \ / _\ (  _ \( \/ )");
            Console.WriteLine(@"( (_ \ )   //    \/    / ) D (  ( (__  )(  )   /( (__ ) \/ (\___ \  / (_/\ )(  ) _ ( )   //    \ )   / )  / ");
            Console.WriteLine(@" \___/(__\_)\_/\_/\_)__)(____/   \___)(__)(__\_) \___)\____/(____/  \____/(__)(____/(__\_)\_/\_/(__\_)(__/  ");
            Console.WriteLine("       ");

            Console.WriteLine(@"                                ____________________________________________________");
            Console.WriteLine(@"                               |____________________________________________________|");
            Console.WriteLine(@"                               | __     __   ____   ___ ||  ____    ____     _  __  |");
            Console.WriteLine(@"                               ||  |__ |--|_| || |_|   |||_|**|*|__|+|+||___| ||  | |");
            Console.WriteLine(@"                               ||==|^^||--| |=||=| |=*=||| |~~|~|  |=|=|| | |~||==| |");
            Console.WriteLine(@"                               ||  |##||  | | || | |ED |||-|  | |==|+|+||-|-|~||__| |");
            Console.WriteLine(@"                               ||__|__||__|_|_||_|_|___|||_|__|_|__|_|_||_|_|_||__|_|");
            Console.WriteLine(@"                               ||_______________________||__________________________|");
            Console.WriteLine(@"                               | _____________________  ||      __   __  _  __    _ |");
            Console.WriteLine(@"                               ||=|=|=|=|=|=|=|=|=|=|=| __..\/ |  |_|  ||#||==|  / /|");
            Console.WriteLine(@"                               || | | | | | | | | | | |/\ \  \\|++|=|  || ||==| / / |");
            Console.WriteLine(@"                               ||_|_|_|_|_|_|_|_|_|_|_/_/\_.___\__|_|__||_||__|/_/__|");
            Console.WriteLine(@"                               |____________________ /\~()/()~//\ __________________|");
            Console.WriteLine(@"                               | __   __    _  _     \_  (_ .  _/ _      _     _____|");
            Console.WriteLine(@"                               ||~~|_|..|__| || |_ _   \ //\\ /  |=|_  /) |___| | | |");
            Console.WriteLine(@"                               ||--|+|^^|==|1||2| | |__/\ __ /\__| |(\/((\ +|+|=|=|=|");
            Console.WriteLine(@"                               ||__|_|__|__|_||_|_| /  \ \  / /  \_|_\___/|_|_|_|_|_|");
            Console.WriteLine(@"                               |_________________ _/    \/\/\/    \_ /   /__________|");
            Console.WriteLine(@"                               | _____   _   __  |/      \../      \/   /   __   ___|");
            Console.WriteLine(@"                               ||_____|_| |_|##|_||   |   \/ __\       /=|_|++|_|-|||");
            Console.WriteLine(@"                               ||______||=|#|--| |\   \   o     \_____/  |~|  | | |||");
            Console.WriteLine(@"                               ||______||_|_|__|_|_\   \  o     | |_|_|__|_|__|_|_|||");
            Console.WriteLine(@"                               |_________ __________\___\_______|____________ ______|");
            Console.WriteLine(@"                               |__    _  /    ________     ______           /| _ _ _|");
            Console.WriteLine(@"                               |\ \  |=|/   //    /| //   /  /  / |        / ||%|%|%|");
            Console.WriteLine(@"                               | \/\ |*/  .//____// //   /__/__/ (_)      /  ||=|=|=|");
            Console.WriteLine(@"                               |  \/\|/   /(____|/ //                    /  /||~|~|~|");
            Console.WriteLine(@"                               | ___\_/   /________//   ________         /  /||_|_|_|");
            Console.WriteLine(@"                               | ___ /   (|________/  |\_______\       /  /| |______|");
            Console.WriteLine(@"                                   /                  \|________)     /  / | |______|");
            Console.WriteLine("");
            Console.WriteLine("");
            #endregion

            do
            {
                MenuOptions choice = LibraryMember.GetMenuSelection();
                ExecuteMainMenuChoice(choice, bookList);
            } while (appRunning); 
        }

        public void ExecuteMainMenuChoice(MenuOptions choice, List<Book> bookList)
        {
            var searchResults = new List<Book>();
            switch (choice)
            {
                case MenuOptions.DisplayAll:
                    Console.Clear();
                    Menu.DisplayBookList(bookList);
                    searchResults = bookList;
                    LibraryMember.SelectFromList(searchResults, cart);
                    appRunning = true;
                    return;

                case MenuOptions.SearchByAuthor:
                    Console.Clear();
                    searchResults = LibraryMember.MemberSearchByAuthor(bookList);
                    LibraryMember.SelectFromList(searchResults, cart);
                    appRunning = true;
                    return;

                case MenuOptions.SearchByTitle:
                    Console.Clear();
                    searchResults = LibraryMember.MemberSearchByTitle(bookList);
                    LibraryMember.SelectFromList(searchResults, cart);
                    appRunning = true;
                    return;

                case MenuOptions.GoToCart:
                    Console.Clear();
                    Cart.BringUpCart(cart);
                    appRunning = true;
                    SaveLoad.Save(bookList);
                    return;

                case MenuOptions.Quit:
                    appRunning = false;
                    SaveLoad.Save(bookList);
                    return;

                default: return;
            }
        }
    }
}
