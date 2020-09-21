using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumWrapper;
using System;

namespace FilmsSearcher
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput;

            Console.WriteLine("Hello! This is Kinopoisk Search Project.");
            Console.WriteLine($"Please enter a film name to search for:{Environment.NewLine}");
            userInput = Console.ReadLine();
            var film = new FindFilm(userInput);
            Console.WriteLine($"Searching for '{userInput}'...");
            film.Find();
        }
    }
}
