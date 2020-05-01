using Module1.TypesAndClasses.Extensions;
using Module1.TypesAndClasses.Generics;
using Module1.TypesAndClasses.Helpers;
using Module1.TypesAndClasses.Interfaces;
using Module1.TypesAndClasses.Shapes;
using System;
using System.Collections.Generic;

namespace Module1.TypesAndClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Module 1. Shapes example.");

            var shapes = new List<IShape>
            {
                //new Ellipse(2,3),
                //new Circle(1, BaseShape.units.cm),
                //new Rectangle(1,1),
                new EquilateralTriangle(5, Units.meters),
                //new RegularPolygon()
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine(shape.ToString());
            }

            #region Katsiaryna

            Console.WriteLine("Testing ShapeHelper");
            Console.WriteLine(ShapeHelper.PerimeterEquals(new EquilateralTriangle(5, Units.meters), new Circle(2, Units.millimeters)));
            Console.WriteLine(ShapeHelper.SquareEquals(new EquilateralTriangle(5, Units.meters), new Circle(2, Units.centimeters)));

            Console.WriteLine("Testing ShapeExtensions");
            var triangle = new EquilateralTriangle(7, Units.meters);
            Console.WriteLine(triangle.PerimeterEquals(new EquilateralTriangle(4, Units.centimeters)));
            Console.WriteLine(triangle.SquareEquals(new Rectangle(2, 3, Units.millimeters)));

            Console.WriteLine("Test Generics");

            var triangle1 = new EquilateralTriangle(5, Units.centimeters);
            var triangle2 = new EquilateralTriangle(0.05, Units.meters);
            Console.WriteLine($"Perimeter 1 = {triangle1.Perimeter()} cm");
            Console.WriteLine($"Perimeter 2 = {triangle2.Perimeter()} mm");
            Console.WriteLine($"Square 1 = {triangle1.Square()} cm");
            Console.WriteLine($"Square 2 = {triangle2.Square()} mm");
            Console.WriteLine($"Perimeters equal? {triangle1.PerimeterEquals(triangle1, triangle2)}");
            Console.WriteLine($"Squares equal? {triangle1.SquareEquals(triangle1, triangle2)}");

            var gen = new ShapePrinter<EquilateralTriangle>();
            gen.Print(triangle);

            Console.WriteLine(gen.PerimeterEquals(triangle, triangle2));

            #endregion
        }
    }
}
