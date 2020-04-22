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
                new Ellipse(2,3),
                new Circle(1, BaseShape.units.cm),
                new Rectangle(1,1),
                new EquilateralTriangle(5),
                new RegularPolygon()
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine(shape.ToString());
            }

            //Console.WriteLine("Testing ShapeHelper");
            //Console.WriteLine(ShapeHelper.PerimeterEquals(new EquilateralTriangle(5), new Circle(2)));
            //Console.WriteLine(ShapeHelper.SquareEquals(new EquilateralTriangle(5), new Circle(2)));

            //Console.WriteLine("Testing ShapeExtensions");
            //var triangle = new EquilateralTriangle(7);
            //Console.WriteLine(triangle.PerimeterEquals(new Circle(4)));
            //Console.WriteLine(triangle.SquareEquals(new Rectangle(2, 3)));

            //Console.WriteLine("Test Generics");
            //var b = ShapePrinter.Print();
        }
    }
}
