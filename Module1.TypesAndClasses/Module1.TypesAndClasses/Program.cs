using System;
using System.Collections.Generic;
using System.Linq;
using Mentoring.Shapes.Interfaces;
using Mentoring.Shapes.Shapes;
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
            // todo: what if more than 4 parameters passed?
            // => usually, UI should tell user something like
            // "Hello!. This is... Supported shapes: ..."

            // after that we start the interaction loop:
            // "Please enter the shape type. Supported Shapes: '" + [list of supported shapes here]
            // "Put 'list' to see the full list of supported commands or put 'exit' to quit."
            // "
            // "Put 'c' for Circle"
            // "Put 't' for Triangle"
            // etc.
            // this could be done via infinite loop (while !userInput.Equals("exit", ..IgnoreCase)).
            // if user enters "exit", then the program completes.
            // if user enters "list" - the program prints the list of the supported commands.

            // todo: warning if not supported parameter was passed

            //var shapeSerice = new ShapesService();

            List<string> supportedShapes = args.ToList();
            if (!supportedShapes.Any())
            {
                supportedShapes.AddRange(shapeCommandsMapping.Keys);

                Console.WriteLine($"Hello! This is Shapes program. Supported shapes: {shapeCommandsMapping["c"]}, {shapeCommandsMapping["e"]}, {shapeCommandsMapping["r"]}, {shapeCommandsMapping["t"]}\n");
                Console.WriteLine($"Please enter the Shape type. Put 'list' to see the full list of supported commands or put 'exit' to quit: {Environment.NewLine}");
                
                var _userInput = Console.ReadLine();

                while (!_userInput.Equals("exit"))
                {
                    // whats the benefit of using Environment.NewLine instead of \n ?
                    Console.WriteLine($"Put 'c' for Circle {Environment.NewLine}" +
                                      $"Put 'e' for Ellipse {Environment.NewLine}" +
                                      $"Put 'r' for Rectangle {Environment.NewLine}" +
                                      $"Put 't' for Triangle {Environment.NewLine}");

                    var userInput = Console.ReadLine();
                    var attempt = 0;

                    while (attempt < 4)
                    {
                        switch (userInput.ToLower())
                        {
                            case "c":
                                // todo: read the shape of type Circle from the ShapesService
                                Console.WriteLine("Processing Circle...");
                                return;
                            case "e":
                                // todo: read the shape of type Ellipse from the ShapesService
                                Console.WriteLine("Processing Ellipse...");
                                return;
                            case "r":
                                // todo: read the shape of type Rectangle from the ShapesService
                                Console.WriteLine("Processing Rectangle...");
                                return;
                            case "t":
                                // todo: read the shape of type EquilateralTriangle from the ShapesService
                                Console.WriteLine("Processing Triangle...");
                                return;
                            default:
                                Console.WriteLine($"Hello! This is Shapes program. Supported shapes: {shapeCommandsMapping["c"]}, {shapeCommandsMapping["e"]}, {shapeCommandsMapping["r"]}, {shapeCommandsMapping["t"]}\n");
                                break;
                        }
                    }

                    Console.WriteLine("You've reached the limit of attempts :(\n");
                }
            } else
            {
                Console.WriteLine($"Hello! This is Shapes program. Supported shapes: {string.Join(", ", args)}");
                Console.WriteLine("Please enter the Shape type. Put 'list' to see the full list of supported commands or put 'exit' to quit:\n");
                
                var _userInput = Console.ReadLine();

                while (!_userInput.Equals("exit"))
                {
                    // todo: add varification of user input (must be in the args list)

                    foreach(var arg in args)
                    {
                        if(supportedShapes.Contains(arg))
                        {
                            // todo: replace the ? on shape name somehow
                            Console.WriteLine($"Put {arg} for ?");
                        }
                    }

                    var userInput = Console.ReadLine();

                    if(!supportedShapes.Contains(userInput))
                    {
                        //Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("");
                    }

                    switch (userInput.ToLower())
                    {
                        case "c":
                            // todo: read the shape of type Circle from the ShapesService
                            Console.WriteLine("Processing Circle...");
                            return;
                        case "e":
                            // todo: read the shape of type Ellipse from the ShapesService
                            Console.WriteLine("Processing Ellipse...");
                            return;
                        case "r":
                            // todo: read the shape of type Rectangle from the ShapesService
                            Console.WriteLine("Processing Rectangle...");
                            return;
                        case "t":
                            // todo: read the shape of type EquilateralTriangle from the ShapesService
                            Console.WriteLine("Processing Triangle...");
                            return;
                        case "":
                            // todo: read all shapes from the ShapesService
                            Console.WriteLine("Processing all shapes...");
                            return;
                        default:
                            Console.WriteLine($"Hello! This is Shapes program. Supported shapes: {shapeCommandsMapping["c"]}, {shapeCommandsMapping["e"]}, {shapeCommandsMapping["r"]}, {shapeCommandsMapping["t"]}\n");
                            break;
                    }
                }
            }
        }

        // todo: add functionality to the method bellow
        private string ToFullShapeName(/*string[] args*/)
        {
            return "";
        }
    }
}
