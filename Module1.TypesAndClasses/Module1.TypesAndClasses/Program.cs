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

            //var shapes = new List<IShape>
            //{
            //    //new Ellipse(2,3),
            //    new Circle(1, Units.centimeters),
            //    //new Rectangle(1,1),
            //    new EquilateralTriangle(5, Units.meters),
            //    //new RegularPolygon()
            //};

            //foreach (var shape in shapes)
            //{
            //    Console.WriteLine(shape.ToString());
            //}

            //#region Katsiaryna

            //Console.WriteLine("Testing ShapeHelper");
            //Console.WriteLine(ShapeHelper.PerimeterEquals(new EquilateralTriangle(5, Units.meters), new Circle(2, Units.millimeters)));
            //Console.WriteLine(ShapeHelper.SquareEquals(new EquilateralTriangle(5, Units.meters), new Circle(2, Units.centimeters)));

            //Console.WriteLine("Testing ShapeExtensions");
            //var triangle = new EquilateralTriangle(7, Units.meters);
            //Console.WriteLine(triangle.PerimeterEquals(new EquilateralTriangle(4, Units.centimeters)));
            //Console.WriteLine(triangle.SquareEquals(new Rectangle(2, 3, Units.millimeters)));

            //Console.WriteLine("Test Generics");

            //var triangle1 = new EquilateralTriangle(5, Units.centimeters);
            //var triangle2 = new EquilateralTriangle(0.05, Units.meters);
            //Console.WriteLine($"Perimeter 1 = {triangle1.Perimeter()} cm");
            //Console.WriteLine($"Perimeter 2 = {triangle2.Perimeter()} mm");
            //Console.WriteLine($"Square 1 = {triangle1.Square()} cm");
            //Console.WriteLine($"Square 2 = {triangle2.Square()} mm");
            //Console.WriteLine($"Perimeters equal? {triangle1.PerimeterEquals(triangle1, triangle2)}");
            //Console.WriteLine($"Squares equal? {triangle1.SquareEquals(triangle1, triangle2)}");

            //var gen = new ShapePrinter<EquilateralTriangle>();
            //gen.Print(triangle);

            //Console.WriteLine(gen.PerimeterEquals(triangle, triangle2));

            //#endregion

            EquilateralTriangle triangle = new EquilateralTriangle(3, Units.centimeters);
            EquilateralTriangle triangle2 = new EquilateralTriangle(7.8, Units.millimeters);
            EquilateralTriangle triangle3 = new EquilateralTriangle(5, Units.meters);
            Circle circle = new Circle(5, Units.meters);
            Circle circle2 = new Circle(2.6, Units.centimeters);
            Circle circle3 = new Circle(8, Units.millimeters);
            Ellipse ellipse = new Ellipse(4, 6, Units.millimeters);
            Ellipse ellipse2 = new Ellipse(6, 9, Units.centimeters);
            Ellipse ellipse3 = new Ellipse(1, 2, Units.meters);
            Rectangle rectangle = new Rectangle(1, 2, Units.meters);
            Rectangle rectangle2 = new Rectangle(10, 24, Units.millimeters);
            Rectangle rectangle3 = new Rectangle(2, 3, Units.meters);

            Console.WriteLine($"triangle: perimeter = {triangle.Perimeter()} {triangle.Units}, square = {triangle.Square()} {triangle.Units}");
            Console.WriteLine($"triangle2: perimeter = {triangle2.Perimeter()} {triangle2.Units}, square = {triangle2.Square()} {triangle2.Units}");
            Console.WriteLine($"triangle3: perimeter = {triangle3.Perimeter()} {triangle3.Units}, square = {triangle3.Square()} {triangle.Units}");
            Console.WriteLine($"circle: perimeter = {circle.Perimeter()} {circle.Units}, square = {circle.Square()} {circle.Units}");
            Console.WriteLine($"circle2: perimeter = {circle2.Perimeter()} {circle2.Units}, square = {circle2.Square()} {circle2.Units}");
            Console.WriteLine($"circle3: perimeter = {circle3.Perimeter()} {circle3.Units}, square = {circle3.Square()} {circle3.Units}");
            Console.WriteLine($"ellipse: perimeter = {ellipse.Perimeter()} millimeters, square = {ellipse.Square()} millimeters");
            Console.WriteLine($"ellipse2: perimeter = {ellipse2.Perimeter()} centimeters, square = {ellipse2.Square()} centimeters");
            Console.WriteLine($"ellipse3: perimeter = {ellipse3.Perimeter()} meters, square = {ellipse3.Square()} meters");
            Console.WriteLine($"rectangle: perimeter = {rectangle.Perimeter()} {rectangle.Units}, square = {rectangle.Square()} {rectangle.Units}");
            Console.WriteLine($"rectangle2: perimeter = {rectangle2.Perimeter()} {rectangle2.Units}, square = {rectangle2.Square()} {rectangle2.Units}");
            Console.WriteLine($"rectangle3: perimeter = {rectangle3.Perimeter()} {rectangle3.Units}, square = {rectangle3.Square()} {rectangle3.Units}");

            var shapes = new List<IShape> {
                new EquilateralTriangle(3, Units.centimeters),
                new EquilateralTriangle(7.8, Units.millimeters),
                new EquilateralTriangle(5, Units.meters),
                new Circle(5, Units.meters),
                new Circle(8, Units.millimeters),
                new Circle(2.6, Units.centimeters),
                new Ellipse(4, 6, Units.millimeters),
                new Ellipse(6, 9, Units.centimeters),
                new Ellipse(1, 2, Units.meters),
                new Rectangle(5, 8, Units.centimeters),
                new Rectangle(10, 24, Units.millimeters),
                new Rectangle(1, 2, Units.meters)
            };

            //var shape = shapes.OrderByDescending(s => s.Square()).First();
            //Console.WriteLine(shape);

            var circleLargestSquare = shapes.OfType<Circle>().Where(s => s.Square() >= 1).OrderByDescending(s => s).Take(1);
            Console.WriteLine(circleLargestSquare);
        }
    }
}
