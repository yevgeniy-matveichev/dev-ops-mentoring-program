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

        static void Main(string[] args)
        {
            IShapeRepository shapeRepository = new ShapesRepository();
            ShapesService shapeService = new ShapesService(shapeRepository);

            List<string> supportedShapes = args.ToList();

            if (!supportedShapes.Any())
            {
                supportedShapes.AddRange(shapeCommandsMapping.Keys);
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Hello! This is Shapes program. Supported shapes: {string.Join(", ", ToFullShapeName(supportedShapes))}. {Environment.NewLine}");
            Console.WriteLine($"Please enter the command. Put 'list' to see the full list of supported commands or put 'exit' to quit: {Environment.NewLine}");
            Console.ForegroundColor = ConsoleColor.White;

            string userInput;
            
            while (!(userInput = Console.ReadLine()).Equals("exit"))
            {
                switch (userInput.ToLower().Trim())
                {
                    case "c": 
                        if (!supportedShapes.Contains(userInput))
                        {
                            Console.WriteLine($"{Environment.NewLine}Unknown parameter - {userInput}.");
                            Console.WriteLine($"Put 'list' to see the full list of supported commands or put 'exit' to quit: {Environment.NewLine}");
                        } else
                        {
                            Console.WriteLine($"{Environment.NewLine}{shapeService.ReadShape(ShapeTypes.Circle).ToString()} {Environment.NewLine}");
                        }

                        break;

                    case "e":
                        if (!supportedShapes.Contains(userInput))
                        {
                            Console.WriteLine($"{Environment.NewLine}Unknown parameter - {userInput}.");
                            Console.WriteLine($"Put 'list' to see the full list of supported commands or put 'exit' to quit: {Environment.NewLine}");
                        } else
                        {
                            Console.WriteLine($"{Environment.NewLine}{shapeService.ReadShape(ShapeTypes.Ellipse).ToString()} {Environment.NewLine}");
                        }

                        break;

                    case "r":
                        if (!supportedShapes.Contains(userInput))
                        {
                            Console.WriteLine($"{Environment.NewLine}Unknown parameter - {userInput}.");
                            Console.WriteLine($"Put 'list' to see the full list of supported commands or put 'exit' to quit: {Environment.NewLine}");
                        } else
                        {
                            Console.WriteLine($"{Environment.NewLine}{shapeService.ReadShape(ShapeTypes.Rectangle).ToString()} {Environment.NewLine}");
                        }

                        break;

                    case "t":
                        if (!supportedShapes.Contains(userInput))
                        {
                            Console.WriteLine($"{Environment.NewLine}Provide a supported command: {Environment.NewLine}");
                        } else
                        {
                            Console.WriteLine($"{Environment.NewLine}{shapeService.ReadShape(ShapeTypes.EquilateralTriangle).ToString()} {Environment.NewLine}");
                        }

                        break;

                    case "list":
                        foreach (var supportedShape in supportedShapes)
                        {
                            Console.WriteLine($"{Environment.NewLine}Put '{supportedShape}' for {shapeCommandsMapping[supportedShape]}");
                        }

                        Console.WriteLine(Environment.NewLine);

                        break;

                    default:
                        Console.WriteLine($"{Environment.NewLine}Unknown parameter - {userInput}.");
                        Console.WriteLine($"Put 'list' to see the full list of supported commands or put 'exit' to quit: {Environment.NewLine}");

                        break;
                }
            }
        }

        private static List<string> ToFullShapeName(List<string> shapes)
        {
            return shapeCommandsMapping.Where(pair => shapes.Contains(pair.Key))
                                       .Select(pair => pair.Value).ToList();
        }
    }
}