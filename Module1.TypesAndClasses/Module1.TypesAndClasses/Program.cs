using System;
using System.Collections.Generic;
using System.Linq;
using Module1.TypesAndClasses.Commands;

namespace Module1.TypesAndClasses
{
    class Program
    {
        public static readonly Dictionary<string, string> ShapeCommandsMapping = new Dictionary<string, string>
        {
            { "c", "Circle" },
            { "e", "Ellipse" },
            { "r", "Rectangle" },
            { "t", "EquilateralTriangle" }
        };

        static readonly List<string> ParametersList = new List<string>
        {
            "help", "list", "import", "export", "exit"
        }.OrderBy(x => x).ToList();

        static void Main(string[] args)
        {
            List<string> supportedShapes = args.ToList();

            if (!supportedShapes.Any())
            {
                supportedShapes.AddRange(ShapeCommandsMapping.Keys);
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Hello! This is Shapes program. Supported commands: {string.Join(", ", ParametersList)}. {Environment.NewLine}");
            Console.ForegroundColor = ConsoleColor.White;

            string userInput;
            
            while (!(userInput = Console.ReadLine()).Equals("exit"))
            {
                string[] parameters = userInput.Split(' ');

                if(!ParametersList.Contains(parameters[0]))
                {
                    Console.WriteLine($"The Shapes program does not support command '{userInput}'.");
                }

                string commandName = parameters[0].ToLower().Trim();

                switch (commandName)
                {
                    case "list":
                        var listCommand = new ListCommand(parameters);
                        string listValidationMessage = listCommand.Validate();

                        if (!string.IsNullOrEmpty(listValidationMessage))
                        {
                            Console.WriteLine(listValidationMessage);

                            break;
                        }

                        Console.WriteLine(listCommand.Execute(parameters[2]) ?? $"Command '{commandName}' executed.");

                        break;

                    case "import":

                        break;

                    case "export":

                        break;

                    case "help":
                        var helpCommand = new HelpCommand(parameters);
                        string helpValidationMessage = helpCommand.Validate();

                        if(!string.IsNullOrEmpty(helpValidationMessage))
                        {
                            Console.WriteLine(helpValidationMessage);

                            break;
                        }

                        Console.WriteLine(helpCommand.Execute(string.Join(" ", parameters)) ?? $"Command '{commandName}' executed.");

                        break;

                    default:
                        Console.WriteLine($"{Environment.NewLine}Unknown parameter - {userInput}.");
                        Console.WriteLine($"Supported commands: {string.Join(", ", ParametersList)}. {Environment.NewLine}");

                        break;
                }
            }
        }

        //private static List<string> ToFullShapeName(List<string> shapes)
        //{
        //    return ShapeCommandsMapping.Where(pair => shapes.Contains(pair.Key))
        //                               .Select(pair => pair.Value).ToList();
        //}
    }
}