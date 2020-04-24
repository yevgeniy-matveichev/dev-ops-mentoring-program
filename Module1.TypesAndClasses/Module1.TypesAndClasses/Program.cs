using Module1.TypesAndClasses.Interfaces;
using Module1.TypesAndClasses.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

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
                new Rectangle(1,1),
                new EquilateralTriangle(5),
                new RegularPolygon()
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine(shape.Metric);
                Console.WriteLine(shape.ToString());
            }

            IEnumerable<IShape> filteredShapes = shapes.Where(s => s.Metric == Metric.Metr);
            IEnumerable<IShape> filteredShapesP = shapes.Where(s => s.Perimeter() > 5);
            List<List<IShape>> shapesList = new List<List<IShape>>
            {
                filteredShapes.ToList(),
                filteredShapesP.ToList()
            };

            var selectedShapes = shapesList.Select(s => s).ToList();
            var selectMany = shapesList.SelectMany(s => s).ToList();

            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var numsInPlace = numbers.Select((num, index) => new { Num = num, InPlace = (num == index) });

        }
    }
}
