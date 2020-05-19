using System;
using System.Collections.Generic;
using System.Linq;
using Mentoring.Shapes.Interfaces;
using Mentoring.Shapes.Shapes;
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
                { "r", "EquilateralRectangle" },
                { "t", "Triangle" }
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

            Console.WriteLine($"Hello! This is Shapes program. Supported commands: {string.Join(", ", supportedShapes)}");
            Console.WriteLine($"Please enter the command. Put 'list' to see the full list of supported commands (shapes) or put 'exit' to quit: {Environment.NewLine}");

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

                        shapeService.ReadShape(ShapeTypes.Circle);

                        return;

                    case "e":
                        if (!supportedShapes.Contains(userInput))
                        {
                            Console.WriteLine($"Not supported command - {userInput}");
                        }
                        
                        shapeService.ReadShape(ShapeTypes.Ellipse);

                        break;

                    case "r":
                        if (!supportedShapes.Contains(userInput))
                        {
                            Console.WriteLine($"Not supported command - {userInput}");
                        }

                        shapeService.ReadShape(ShapeTypes.EquilateralTriangle);

                        break;

                    case "t":
                        if (!supportedShapes.Contains(userInput))
                        {
                            Console.WriteLine($"Not supported command - {userInput}");
                        }

                        shapeService.ReadShape(ShapeTypes.Rectangle);

                        break;

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

        private static string ToFullShapeName(List<string> shapes)
        {
            string newShape = "";

            foreach(var shape in shapes)
            {
                switch (shape)
                {
                    case "c":
                        newShape = string.Concat(shape, "tring");
                        //return circleShape;
                        break;
                    case "e":
                        newShape = string.Concat(shape, "llipse");
                        //return ellipseShape;
                        break;
                    case "r":
                        newShape = string.Concat(shape, "ectangle");
                        //return rectangleShape;
                        break;
                    case "t":
                        newShape = string.Concat(shape, "riangle");
                        //return triangleShape;
                        break;
                    default:
                        Console.WriteLine($"The input did not contain any of the supported shapes.");
                        break;
                }
            }

            return newShape;
        }
    }
}

