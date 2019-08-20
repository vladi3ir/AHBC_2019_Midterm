using System;

namespace AHBC_2019_Midterm_JulyBC
{
    public class Validator
    {
        public bool IsSearchType(string userInput, out string result)
        {
            result = userInput;

            return (userInput.Contains("Title", StringComparison.OrdinalIgnoreCase) ||
                userInput.Contains("Keyword", StringComparison.OrdinalIgnoreCase) ||
                userInput.Equals("Author", StringComparison.OrdinalIgnoreCase));
        }

        public bool IsReturnable(Book userChoice)
        {
            return userChoice.IsCheckedOut;
        }
    }
}