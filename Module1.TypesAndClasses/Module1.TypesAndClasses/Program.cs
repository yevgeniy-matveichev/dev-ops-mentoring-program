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
                new Circle(1, Units.Centimeters),
                new Rectangle(1,1,Units.Meters),
                new EquilateralTriangle(5, Units.Meters)
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine(shape.ToString());
            }

            #region Kate task 3 - will remove soon

            EquilateralTriangle triangle = new EquilateralTriangle(3, Units.Centimeters);
            EquilateralTriangle triangle2 = new EquilateralTriangle(7.8, Units.Millimeters);
            EquilateralTriangle triangle3 = new EquilateralTriangle(5, Units.Meters);
            Circle circle = new Circle(5, Units.Meters);
            Circle circle2 = new Circle(2.6, Units.Centimeters);
            Circle circle3 = new Circle(8, Units.Millimeters);
            Ellipse ellipse = new Ellipse(4, 6, Units.Millimeters);
            Ellipse ellipse2 = new Ellipse(6, 9, Units.Centimeters);
            Ellipse ellipse3 = new Ellipse(1, 2, Units.Meters);
            Rectangle rectangle = new Rectangle(5, 8, Units.Centimeters);
            Rectangle rectangle2 = new Rectangle(10, 24, Units.Millimeters);
            Rectangle rectangle3 = new Rectangle(2, 3, Units.Meters);

            Console.WriteLine($"triangle: perimeter = {triangle.Perimeter()} {triangle.Unit}, square = {triangle.Square()} {triangle.Unit}");
            Console.WriteLine($"triangle2: perimeter = {triangle2.Perimeter()} {triangle2.Unit}, square = {triangle2.Square()} {triangle2.Unit}");
            Console.WriteLine($"triangle3: perimeter = {triangle3.Perimeter()} {triangle3.Unit}, square = {triangle3.Square()} {triangle.Unit}");
            Console.WriteLine($"circle: perimeter = {circle.Perimeter()} {circle.Unit}, square = {circle.Square()} {circle.Unit}");
            Console.WriteLine($"circle2: perimeter = {circle2.Perimeter()} {circle2.Unit}, square = {circle2.Square()} {circle2.Unit}");
            Console.WriteLine($"circle3: perimeter = {circle3.Perimeter()} {circle3.Unit}, square = {circle3.Square()} {circle3.Unit}");
            Console.WriteLine($"ellipse: perimeter = {ellipse.Perimeter()} millimeters, square = {ellipse.Square()} millimeters");
            Console.WriteLine($"ellipse2: perimeter = {ellipse2.Perimeter()} centimeters, square = {ellipse2.Square()} centimeters");
            Console.WriteLine($"ellipse3: perimeter = {ellipse3.Perimeter()} meters, square = {ellipse3.Square()} meters");
            Console.WriteLine($"rectangle: perimeter = {rectangle.Perimeter()} {rectangle.Unit}, square = {rectangle.Square()} {rectangle.Unit}");
            Console.WriteLine($"rectangle2: perimeter = {rectangle2.Perimeter()} {rectangle2.Unit}, square = {rectangle2.Square()} {rectangle2.Unit}");
            Console.WriteLine($"rectangle3: perimeter = {rectangle3.Perimeter()} {rectangle3.Unit}, square = {rectangle3.Square()} {rectangle3.Unit}");

            var KateShapes = new List<IShape> {
                new EquilateralTriangle(3, Units.Centimeters),
                new EquilateralTriangle(7.8, Units.Millimeters),
                new EquilateralTriangle(5, Units.Meters),
                new Circle(5, Units.Meters),
                new Circle(8, Units.Millimeters),
                new Circle(2.6, Units.Centimeters),
                new Ellipse(4, 6, Units.Millimeters),
                new Ellipse(6, 9, Units.Centimeters),
                new Ellipse(1, 2, Units.Meters),
                new Rectangle(5, 8, Units.Centimeters),
                new Rectangle(10, 24, Units.Millimeters),
                new Rectangle(1, 2, Units.Meters)
            };

            var squares = KateShapes.Select(s => s.Square()).OrderBy(s => s);
            foreach (var i in squares)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine(squares.Max());
            Console.WriteLine(squares.Min());

            #endregion
        }
    }
}
