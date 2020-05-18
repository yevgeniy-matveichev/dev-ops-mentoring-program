using System;
using System.Collections.Generic;
using System.Linq;
using Mentoring.Shapes.Interfaces;
using Mentoring.Shapes.Shapes;
using MentoringDataAccess.Interfaces;
using MentoringDataAccess.ShapesRepository;
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
                { "t", "Triangle" }
            };

        static void Main(string[] args)
        {
            //IShapeRepository shapeRepository = new IShapeRepository();
            //var shapeSerice = new ShapesService(shape);

            List<string> supportedShapes = args.ToList();

            if (!supportedShapes.Any())
            {
                supportedShapes.AddRange(shapeCommandsMapping.Keys);
            }

            Console.WriteLine($"Hello! This is Shapes program. Supported commands (shapes): {string.Join(", ", supportedShapes)}");
            Console.WriteLine($"Please enter one of the options. Put 'list' to see the full list of supported commands (shapes) or put 'exit' to quit: {Environment.NewLine}");

            var userInput = Console.ReadLine();

            while (!userInput.Equals("exit"))
            {
                switch (userInput.ToLower())
                {
                    case "list":
                        foreach (var supportedShape in supportedShapes)
                        {
                            Console.WriteLine($"Put '{supportedShape}' for {shapeCommandsMapping[supportedShape]}");
                        }

                        Console.WriteLine("Put 'stop' to exit {0}", Environment.NewLine);

                        var _userInput = Console.ReadLine();

                        //var shapeRepository = new IShapeRepository();
                        //IShapeRepository shapeRepository;
                        //var shapeSerice = new ShapesService(shapeRepository);
                        //ShapesService shapesService = new ShapesService(shapeRepository);

                        switch (_userInput.ToLower())
                        {
                            case "c":
                                if (!supportedShapes.Contains(_userInput))
                                {
                                    Console.WriteLine($"{_userInput} is not in the list of supported shapes.");
                                }

                                //ShapeTypes 

                                Console.WriteLine($"Processing {_userInput}");
                                break;
                            case "e":
                                if (!supportedShapes.Contains(_userInput))
                                {
                                    Console.WriteLine($"{_userInput} is not in the list of supported shapes.");
                                }

                                //ShapeTypes 

                                Console.WriteLine($"Processing {_userInput}");
                                break;
                            case "r":
                                if (!supportedShapes.Contains(_userInput))
                                {
                                    Console.WriteLine($"{_userInput} is not in the list of supported shapes.");
                                }

                                //ShapeTypes 

                                Console.WriteLine($"Processing {_userInput}");
                                break;
                            case "t":
                                if (!supportedShapes.Contains(_userInput))
                                {
                                    Console.WriteLine($"{_userInput} is not in the list of supported shapes.");
                                }

                                //ShapeTypes 

                                Console.WriteLine($"Processing {_userInput}");
                                break;
                            case "stop":
                                Console.WriteLine("Exiting the list...");
                                return;
                            default:
                                Console.WriteLine($"Unknown command - {_userInput}");
                                break;
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
    }
}


//        // todo: add functionality to the method bellow
//        private string ToFullShapeName(/*string[] args*/)
//        {
//            return "";
//        }

