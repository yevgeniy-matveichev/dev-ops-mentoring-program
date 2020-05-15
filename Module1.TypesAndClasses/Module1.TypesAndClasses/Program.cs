using System;
using System.Collections.Generic;
using System.Linq;
using Mentoring.Shapes.Interfaces;
using Mentoring.Shapes.Shapes;

namespace Module1.TypesAndClasses
{
    class Program
    {
        // cr: I would recommend to name it "shapeCommandsMapping"
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

            // cr: List<string> supportedShapes = args.ToList();
            // after that, we do not work with args but wih the supportedShapes:
            // if (!supportedShapes.Any())
            // {
            //    supportedShapes.AddRange() // add here all the commands from the  shapeCommandsMapping
            // }
            if (args.Length == 0)
            {
                Console.WriteLine($"Hello! This is Shapes program. Supported shapes: {supportedShapes["c"]}, {supportedShapes["e"]}, {supportedShapes["r"]}, {supportedShapes["t"]}\n");

            } else
            {
                Console.WriteLine($"Hello! This is Shapes program. Supported shapes: {string.Join(", ", args)}");
                Console.WriteLine("Please enter the shape:\n");

                // cr: while loop instead of for ...
                for (var attempt = 0; attempt < 5; attempt++)
                {
                    string userInput = Console.ReadLine();

                    // cr: is not needed, this block can be simply moved out of the loop, without 'if'
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

            // cr: Environment.NewLine instead of \n
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
