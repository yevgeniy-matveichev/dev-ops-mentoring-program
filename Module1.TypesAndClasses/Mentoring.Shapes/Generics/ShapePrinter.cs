using Mentoring.Shapes.Interfaces;
using System;

namespace Mentoring.Shapes.Generics
{
    public class ShapePrinter<T> where T: IShape
    {
        public void Print(T shape)
        {
            Console.WriteLine(shape.ToString());
        }

        public bool PerimeterEquals(T shape, T other)
        {
            if (shape == null)
            {
                throw new ArgumentNullException(nameof(shape));
            }

            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            return shape.Perimeter() == other.Perimeter();
        }

        public bool SquareEquals(T shape, T other)
        {
            if (shape == null)
            {
                throw new ArgumentNullException(nameof(shape));
            }

            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            return shape.Square() == other.Square();
        }
    }
}
