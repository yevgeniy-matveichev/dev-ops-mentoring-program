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
                    Console.WriteLine($"Year:\t{f.Year}{Environment.NewLine}");
                }
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"{Environment.NewLine}If you need more information about any film in a list, enter its' name, otherwise enter 'exit':{Environment.NewLine}");
            Console.ForegroundColor = ConsoleColor.White;

            var userInput2 = Console.ReadLine();

            while(!userInput2.Equals("exit"))
            {
                Console.WriteLine($"Searching for {userInput2}...{Environment.NewLine}");

                using var film = new FindFilm(userInput2);
                var f = film.FilmInfo(userInput2);

                Console.WriteLine($"Name:\t{f.Name}");
                Console.WriteLine($"Year:\t{f.Year}");
                Console.WriteLine($"Country:\t{f.Country}");
                Console.WriteLine($"Rating:\t{f.Rating}{Environment.NewLine}");
                //Console.WriteLine($"Actors:\t{string.Join(", ", f.Actors)}{Environment.NewLine}");

                break;
            }
        }
    }
}
