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
                new Circle(),
                new Ellipse(),
                new EquilateralTriangle(),
                new Rectangle(),
                new RegularPolygon()
            };

            foreach(var shape in shapes)
            {
                Console.WriteLine(shape.ToString());
            }
        }
    }
}
