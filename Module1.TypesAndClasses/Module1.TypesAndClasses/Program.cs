using System;
using System.Collections.Generic;
using System.Linq;
using Module1.TypesAndClasses.Commands;

namespace Module1.TypesAndClasses
{
    class Program
    {
        static readonly Dictionary<string, string> PhapeCommandsMapping = new Dictionary<string, string>
        {
            { "c", "Circle" },
            { "e", "Ellipse" },
            { "r", "Rectangle" },
            { "t", "EquilateralTriangle" }
        };

        static readonly List<string> parametersList = new List<string>
        {
            "help", "list", "import", "export", "exit"
        }.OrderBy(x => x).ToList();

        static void Main(string[] args)
        {
            List<string> supportedShapes = args.ToList();

            if (!supportedShapes.Any())
            {
                supportedShapes.AddRange(PhapeCommandsMapping.Keys);
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Hello! This is Shapes program. Supported commands: {string.Join(", ", parametersList)}. {Environment.NewLine}");
            Console.ForegroundColor = ConsoleColor.White;

            string userInput;
            
            while (!(userInput = Console.ReadLine()).Equals("exit"))
            {
                string[] parameters = userInput.Split(' ');

                if(!parametersList.Contains(parameters[0]))
                {
                    Console.WriteLine($"The Shapes program does not support command '{userInput}'.");
                }

                string commandName = parameters[0].ToLower().Trim();
                switch (commandName)
                {
                    case "list":
                        var listCommand = new ListCommand(parameters);
                        string validationMessage = listCommand.Validate();
                        if (!string.IsNullOrEmpty(validationMessage))
                        {
                            Console.WriteLine(validationMessage);
                            // continue;
                            break;
                        }
                        Console.WriteLine(listCommand.Execute() ?? $"Command '{commandName}' executed.");

                        break;

                    case "import":

                        break;

                    case "export":

                        break;

                    case "help":
                        {
                            foreach (var parameter in parametersList)
                            {
                                Console.WriteLine($"{HelpCommand(parameter)}");
                            }

                            break;
                        }

                    default:
                        Console.WriteLine($"{Environment.NewLine}Unknown parameter - {userInput}.");
                        Console.WriteLine($"Put 'list' to see the full list of supported commands or put 'exit' to quit: {Environment.NewLine}");

                        break;
                }
            }
        }

        #region private

        private static List<string> ToFullShapeName(List<string> shapes)
        {
            return PhapeCommandsMapping.Where(pair => shapes.Contains(pair.Key))
                                       .Select(pair => pair.Value).ToList();
        }

        private static string HelpCommand(string option)
        {
            if (option == null)
            {
                // throw ...
            }

            string result = string.Empty;                     
            switch(option)
            {
                case "help":
                    Console.WriteLine();
                    break;
                case "list":
                    break;
                case "import":
                    break;
                case "export":
                    break;
                case "exit":
                    break;
                default:
                    Console.WriteLine("Incorrect input.");
                    break;
            }

            return result;
        }

        #endregion
    }
}