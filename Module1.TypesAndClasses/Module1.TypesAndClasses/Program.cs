using System;
using System.Collections.Generic;
using Mentoring.Shapes.Interfaces;
using Mentoring.Shapes.Shapes;

namespace Module1.TypesAndClasses
{
    class Program
    {
        static readonly Dictionary<string, string> supportedShapes = new Dictionary<string, string>
            {
                { "c", "Circle" },
                { "e", "Ellipse" },
                { "r", "Rectangle" },
                { "t", "Triangle" }
            };

        static void Main(string[] args)
        {
            // todo: what if more than 4 parameters passed?
            // todo: warning if not supported parameter was passed

            if (args.Length == 0)
            {
                Console.WriteLine($"Hello! This is Shapes program. Supported shapes: {supportedShapes["c"]}, {supportedShapes["e"]}, {supportedShapes["r"]}, {supportedShapes["t"]}\n");

            } else
            {
                Console.WriteLine($"Hello! This is Shapes program. Supported shapes: {string.Join(", ", args)}");
                Console.WriteLine("Please enter the shape:\n");

                for (var attempt = 0; attempt < 5; attempt++)
                {
                    string userInput = Console.ReadLine();

                    if (attempt == 3)
                    {
                        Console.WriteLine("\nYou've reached the limit of attempts :(");
                        break;
                    }

                    switch (userInput)
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
                            Console.WriteLine($"The shape is not supported. Supported shapes: {string.Join(", ", args)}");
                            break;
                    }
                }
            }

            //Console.WriteLine($"Please enter one of the options bellow: " +
            //                  $"\n1. '{args[0]}' to process Circle " +
            //                  $"\n2. '{args[1]}' to process Ellipse " +
            //                  $"\n3. '{args[2]}' to process Rectangle " +
            //                  $"\n4. '{args[3]}' to process Triangle ");
        }

        // todo: add functionality to the method bellow
        private string ArgsToShapeName(string[] args)
        {
            return "";
        }
    }
}
