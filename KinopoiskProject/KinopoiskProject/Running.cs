using Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinopoiskProject
{
    public class Running
    {

        public void Run()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Hello! This is film finder program. Please enter Film name you are interested in:{Environment.NewLine}");
            Console.ForegroundColor = ConsoleColor.White;

            string userInput;

            while (!(userInput = Console.ReadLine()).Equals("exit"))
            {
                string filmName = userInput.Trim();

                try
                {
                    string commandName = filmName.ToLower();

                    if (string.IsNullOrEmpty(filmName))
                    {
                        Console.WriteLine("What?");
                        continue;
                    }
                    Finder Film = new Finder();
                    Film.TestMethod1();
                    Console.WriteLine($"Film '{commandName}' is searching.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex}");
                    continue;
                }
            }
        }
    }
}
