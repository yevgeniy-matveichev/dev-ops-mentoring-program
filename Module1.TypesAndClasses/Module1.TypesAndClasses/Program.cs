using System;
<<<<<<< HEAD
using System.Collections.Generic;
using System.Linq;
using Mentoring.Shapes.Interfaces;
using Mentoring.Shapes.Shapes;
=======
>>>>>>> c5b85bf4b34c181ec5c7428ad191d6281fb1e3cd

namespace Module1.TypesAndClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Hello! This is Shapes program. Supported shapes: Circle, Ellipse, Rectangle and Triangle.\n");
            Console.WriteLine($"Please enter one of the options bellow: " +
                              $"\n1. '{args[0]}' to process Circle " +
                              $"\n2. '{args[1]}' to process Ellipse " +
                              $"\n3. '{args[2]}' to process Rectangle " +
                              $"\n4. '{args[3]}' to process Triangle " +
                              $"\n5. Empty to process all the shapes\n");

            for (var attempt = 0; attempt < 4; attempt++)
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
                        Console.WriteLine($"The shape is not supported. Supported shapes: {args[0]} - Circle, {args[1]} - Ellipse, {args[2]} - Rectangle, {args[3]} - Triangle");
                        break;
                }
            }
        }
    }
}
