using System;
using System.Collections.Generic;
using System.Linq;
using Mentoring.Shapes.Interfaces;
using Mentoring.DataAccess.Interfaces;
using Mentoring.DataAccess.ShapesRepository;
using Module1.TypesAndClasses.Services;

namespace Module1.TypesAndClasses
{
    class Program
    {
        static readonly Dictionary<string, string> shapeCommandsMapping = new Dictionary<string, string>
        {
            { "c", "Circle" },
            { "e", "Ellipse" },
            { "r", "Rectangle" },
            { "t", "EquilateralTriangle" }
        };

        static readonly List<string> parametersList = new List<string>
        {
            "help", "list", "import", "export", "exit"
        };

        static void Main(string[] args)
        {
            List<string> supportedShapes = args.ToList();

            if (!supportedShapes.Any())
            {
                supportedShapes.AddRange(shapeCommandsMapping.Keys);
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

                switch (parameters[0].ToLower().Trim())
                {
                    case "list":
                        if(!(parameters.Length == 3))
                        {
                            Console.WriteLine($"Incorrect usage of 'list' command. {Environment.NewLine}" +
                                "Example: list -json-example c.");
                        }

                        if (!(parameters[1] == "-json-example"))
                        {
                            Console.WriteLine($"Incorrect usage of 'list' command: '{parameters[1]}' is not recognized as an option. {Environment.NewLine}" +
                                "Example: list -json-example c.");
                        }

                        if (!supportedShapes.Contains(parameters[2]))
                        {
                            Console.WriteLine($"Not supported argument - {parameters[2]}");
                        }
                        else
                        {
                            Console.WriteLine(ListCommand(parameters[2]));
                        }

                        break;

                    case "import":

                        break;

                    case "export":

                        break;

                    case "help":
                        parametersList.Sort();

                        foreach(var parameter in parametersList)
                        {
                            Console.WriteLine($"{HelpCommand(parameter)}");
                        }

                        break;

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
            return shapeCommandsMapping.Where(pair => shapes.Contains(pair.Key))
                                       .Select(pair => pair.Value).ToList();
        }

        private static string ListCommand(string option)
        {
            IShapeRepository shapeRepository = new ShapesRepository();
            ShapesService shapeService = new ShapesService(shapeRepository);

            string result = "";

            if (option == null)
            {
                Console.WriteLine("Argument was null.");
            }
            else
            {
                switch(option)
                {
                    case "c":
                        result = $"{Environment.NewLine}{shapeService.ReadShape(ShapeTypes.Circle).ToString()} {Environment.NewLine}";

                        break;

                    case "e":
                        result = $"{Environment.NewLine}{shapeService.ReadShape(ShapeTypes.Ellipse).ToString()} {Environment.NewLine}";

                        break;

                    case "r":
                        result = $"{Environment.NewLine}{shapeService.ReadShape(ShapeTypes.Rectangle).ToString()} {Environment.NewLine}";

                        break;

                    case "t":
                        result = $"{Environment.NewLine}{shapeService.ReadShape(ShapeTypes.EquilateralTriangle).ToString()} {Environment.NewLine}";

                        break;

                    default:
                        Console.WriteLine($"Not supported argument - {option}");
                        break;
                }
            }
            
            return result;
        }

        private static string HelpCommand(string option)
        {
            string result = "";

            if(option == null)
            {
                Console.WriteLine("Command was null");
            }
            else
            {
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
            }

            return result;
        }

        #endregion
    }
}