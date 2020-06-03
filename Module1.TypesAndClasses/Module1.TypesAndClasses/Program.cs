using Module1.TypesAndClasses.Commands;
using Module1.TypesAndClasses.Factories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Module1.TypesAndClasses
{
    public class Program
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

                try
                {
                    string commandName = parameters[0].ToLower().Trim();

                    var commandsFactory = new CommandsFactory(parameters);
                    IInputCommand command = commandsFactory.Create(commandName);

                    string validationMessage = command.Validate();

                    if (!string.IsNullOrEmpty(validationMessage))
                    {
                        Console.WriteLine(validationMessage);
                        continue;
                    }

                    Console.WriteLine(command.Execute() ?? $"Command '{commandName}' executed.");
                }
                catch (NotSupportedException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
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