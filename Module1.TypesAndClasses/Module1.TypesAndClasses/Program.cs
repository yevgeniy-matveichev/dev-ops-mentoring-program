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

            Console.WriteLine($"Hello! This is Shapes program. Supported shapes: {string.Join(", ", ToFullShapeName(supportedShapes))} {Environment.NewLine}");
            Console.WriteLine($"Please enter the command. Put 'list' to see the full list of supported commands or put 'exit' to quit: {Environment.NewLine}");

            var userInput = Console.ReadLine();
            
            while (!userInput.Equals("exit"))
            {
                switch (userInput.ToLower())
                {
                    case "c": 
                        if (!supportedShapes.Contains(userInput))
                        {
                            Console.WriteLine($"Not supported command - {userInput}");
                        }

                        Console.WriteLine(shapeService.ReadShape(ShapeTypes.Circle).ToString());

                        return;

                    case "e":
                        if (!supportedShapes.Contains(userInput))
                        {
                            Console.WriteLine($"Not supported command - {userInput}");
                        }

                        Console.WriteLine(shapeService.ReadShape(ShapeTypes.Ellipse).ToString());

                        return;

                    case "r":
                        if (!supportedShapes.Contains(userInput))
                        {
                            Console.WriteLine($"Not supported command - {userInput}");
                        }

                        Console.WriteLine(shapeService.ReadShape(ShapeTypes.Rectangle).ToString());

                        return;

                    case "t":
                        if (!supportedShapes.Contains(userInput))
                        {
                            Console.WriteLine($"Not supported command - {userInput}");
                        }

                        Console.WriteLine(shapeService.ReadShape(ShapeTypes.EquilateralTriangle).ToString());

                        return;

                    case "list":
                        foreach (var supportedShape in supportedShapes)
                        {
                            Console.WriteLine($"Put '{supportedShape}' for {shapeCommandsMapping[supportedShape]}");
                        }

                        break;

                    case "exit":
                        Console.WriteLine("Exiting the Shapes program...");

                        return;

                    default:
                        Console.WriteLine($"Unknown command - {userInput}");

                        break;
                }
            }
        }

        private static List<string> ToFullShapeName(List<string> shapes)
        {
            List<string> newShape = new List<string>();
            foreach (var i in shapes)
            {
                newShape.Add(shapeCommandsMapping[i]);
            }

            return newShape;
        }
    }
}

