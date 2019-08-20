using System;

namespace AHBC_2019_Midterm_JulyBC
{
    class Program
    {
        static void Main(string[] args)
        {
            Book eastOfEden = new Book("East of Eden", "John Steinbeck", true, new DateTime(2019, 10, 19));
            Validator validator = new Validator();
            Console.WriteLine($"Can you return {eastOfEden.Title}? {validator.IsReturnable(eastOfEden)}.");
        }
    }
}