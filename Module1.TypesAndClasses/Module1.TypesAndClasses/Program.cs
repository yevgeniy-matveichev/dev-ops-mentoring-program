using Module1.TypesAndClasses.Helpers;
using Module1.TypesAndClasses.Interfaces;
using Module1.TypesAndClasses.Shapes;
using System;
using System.Collections.Generic;
using static Module1.TypesAndClasses.Shapes.BaseShape.MetricName;

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
                new Circle(1),
                new Rectangle(1,1,m),
                new EquilateralTriangle(6),
                new RegularPolygon()
            };
            var shapes2 = new List<BaseShape>
            {
             //   new Ellipse(2,3),
               new Circle(1),
                new Rectangle(1,2,sm),
             //   new EquilateralTriangle(6),
            //    new RegularPolygon()
            };

            foreach (var shape in shapes2)
            {
                Console.WriteLine(shape.ToString());
            }
            Console.WriteLine(shapes2[1].Equals(shapes2[0]));
            Console.WriteLine(ShapeHelper.PerimeterEquals(shapes2[0], 4));
            Console.WriteLine("Shape Name = " + shapes2[0].ShapeName());
            Console.WriteLine(ShapeHelper.SquareEquals(shapes[0], 1));
        }
    }
}
