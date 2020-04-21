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
        }
    }
}
