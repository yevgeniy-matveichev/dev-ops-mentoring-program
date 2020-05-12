using System;

namespace Module1.TypesAndClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Hello! This is Shapes program. Supported shapes: Circle, Ellipse, Rectangle and Triangle.\n");
            Console.WriteLine($"Please enter the letter of the shape you would like to process: {args[0]} - Circle, {args[1]} - Ellipse, {args[2]} - Rectangle, {args[3]} - Triangle.\n");

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
                        Console.WriteLine("You've chosen Circle.");
                        //break;
                        return;
                    case "e":
                        // todo: read the shape of type Ellipse from the ShapesService
                        Console.WriteLine("You've chosen Ellipse");
                        //break;
                        return;
                    case "r":
                        // todo: read the shape of type Rectangle from the ShapesService
                        Console.WriteLine("You've chosen Rectangle.");
                        //break;
                        return;
                    case "t":
                        // todo: read the shape of type EquilateralTriangle from the ShapesService
                        Console.WriteLine("You've chosen Triangle.");
                        //break;
                        return;
                    default:
                        Console.WriteLine($"The shape is not supported. Supported shapes: {args[0]} - Circle, {args[1]} - Ellipse, {args[2]} - Rectangle, {args[3]} - Triangle");
                        break;
                }
            }
        }
    }
}
