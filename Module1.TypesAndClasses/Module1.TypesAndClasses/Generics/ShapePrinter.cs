using Module1.TypesAndClasses.Interfaces;
using System;

namespace Module1.TypesAndClasses.Generics
{
    public class ShapePrinter<T> where T: IShape
    {
        public void Print(T shape)
        {
            Console.WriteLine(shape.ToString());
        }
    }
}
