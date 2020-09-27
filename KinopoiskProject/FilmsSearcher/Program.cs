using SeleniumWrapper;
using System;

namespace FilmsSearcher
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput;

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Hello! This is Kinopoisk Search Project.");
            Console.WriteLine($"Please enter a film name to search for:{Environment.NewLine}");
            Console.ForegroundColor = ConsoleColor.White;

            userInput = Console.ReadLine();

            Console.WriteLine($"Searching for '{userInput}'...{Environment.NewLine}");

            using (var film = new FindFilm(userInput)) {
                var films = film.Find();

                Console.WriteLine($"Collecting films data...{Environment.NewLine}");

                foreach (var f in films)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{f.Name}");

                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"Name:\t{f.Name}");
                    Console.WriteLine($"Year:\t{f.Year}");
                    //Console.WriteLine($"Rating:\t{f.Rating}{Environment.NewLine}");
                    //Console.WriteLine($"Country:\t{f.Country}");
                    //Console.WriteLine($"Rating:\t{f.Rating}");
                    //Console.WriteLine($"Actors:\t{string.Join(", ", f.Actors)}");
                }
            }

            //Console.ReadLine();
        }
    }
}
