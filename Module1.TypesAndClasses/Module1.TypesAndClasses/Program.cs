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
                new Circle(1, Units.centimeters),
                //new Rectangle(1,1),
                new EquilateralTriangle(5, Units.meters),
                //new RegularPolygon()
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine(shape.ToString());
            }

<<<<<<< HEAD
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
=======
            //Console.WriteLine("Testing ShapeHelper");
            //Console.WriteLine(ShapeHelper.PerimeterEquals(new EquilateralTriangle(5), new Circle(2)));
            //Console.WriteLine(ShapeHelper.SquareEquals(new EquilateralTriangle(5), new Circle(2)));

            //Console.WriteLine("Testing ShapeExtensions");
            //var triangle = new EquilateralTriangle(7);
            //Console.WriteLine(triangle.PerimeterEquals(new EquilateralTriangle(7)));
            //Console.WriteLine(triangle.SquareEquals(new Rectangle(2, 3)));

            //Console.WriteLine("Test Generics");
            //var b = ShapePrinter.Print();

            var triangle = new EquilateralTriangle(5, Units.centimeters);
            var triangle2 = new EquilateralTriangle(0.05, Units.meters);
            Console.WriteLine($"Perimeter 1 = {triangle.Perimeter()} cm");
            Console.WriteLine($"Perimeter 2 = {triangle2.Perimeter()} m");
            Console.WriteLine($"Square 1 = {triangle.Square()} cm");
            Console.WriteLine($"Square 2 = {triangle2.Square()} m");
            Console.WriteLine($"Perimeters equal? {triangle.PerimeterEquals(triangle, triangle2)}");
            Console.WriteLine($"Squares equal? {triangle.SquareEquals(triangle, triangle2)}");

            var circle1 = new Circle(5, Units.centimeters);
            var circle2 = new Circle(0.05, Units.meters);
            Console.WriteLine($"Perimeter 1 = {circle1.Perimeter()} cm");
            Console.WriteLine($"Perimeter 2 = {circle2.Perimeter()} m");
            Console.WriteLine($"Square 1 = {circle1.Square()} cm");
            Console.WriteLine($"Square 2 = {circle2.Square()} m");
            Console.WriteLine($"Perimeters equal? {circle1.PerimeterEquals(circle1, circle2)}");
            Console.WriteLine($"Squares equal? {circle1.SquareEquals(circle1, circle2)}");
            Console.WriteLine($"Perimeters equal? {circle1.PerimeterEquals(circle1, circle2)}");
            Console.WriteLine($"Squares equal? {circle1.SquareEquals(circle1, circle2)}");
>>>>>>> 2d4c0c6dcfaecee9b8fafe6536e83e60299e6e83
        }
    }
}
