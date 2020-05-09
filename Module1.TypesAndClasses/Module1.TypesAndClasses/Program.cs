using Module1.TypesAndClasses.Extensions;
using Module1.TypesAndClasses.Generics;
using Module1.TypesAndClasses.Helpers;
using Module1.TypesAndClasses.Interfaces;
using Module1.TypesAndClasses.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Module1.TypesAndClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Module 1. Shapes example.");

            var shapes = new List<IShape>
            {
                new Ellipse(2,3),
                new Circle(1, Units.centimeters),
                new Rectangle(1,1,Units.meters),
                new EquilateralTriangle(5, Units.meters),
                //new RegularPolygon()
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine(shape.ToString());
            }

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

            #region For Testing Linq
  
            #endregion
        }
    }
}
