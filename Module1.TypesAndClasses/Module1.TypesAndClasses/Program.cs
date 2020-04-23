﻿using Module1.TypesAndClasses.Extensions;
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
                new EquilateralTriangle(5, Units.meter),
                //new RegularPolygon()
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
            //Console.WriteLine(triangle.PerimeterEquals(new EquilateralTriangle(7)));
            //Console.WriteLine(triangle.SquareEquals(new Rectangle(2, 3)));

            //Console.WriteLine("Test Generics");
            //var b = ShapePrinter.Print();

            var triangle = new EquilateralTriangle(5, Units.centimeter);
            var triangle2 = new EquilateralTriangle(0.05, Units.meter);
            Console.WriteLine($"Perimeter 1 = {triangle.Perimeter()} cm");
            Console.WriteLine($"Perimeter 2 = {triangle2.Perimeter()} m");
            Console.WriteLine($"Square 1 = {triangle.Square()} cm");
            Console.WriteLine($"Square 2 = {triangle2.Square()} m");
            Console.WriteLine($"Perimeters equal? {triangle.PerimeterEquals(triangle, triangle2)}");
            Console.WriteLine($"Squares equal? {triangle.SquareEquals(triangle, triangle2)}");
        }
    }
}
