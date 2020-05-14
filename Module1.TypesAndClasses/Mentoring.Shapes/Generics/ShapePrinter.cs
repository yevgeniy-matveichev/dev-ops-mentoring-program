using Mentoring.Shapes.Interfaces;
using System;

namespace Mentoring.Shapes.Generics
{
    public class ShapePrinter<T> where T : IShape
    {
        public void Print(T shape)
        {
            Console.WriteLine(shape.ToString());
        }
    }
}
