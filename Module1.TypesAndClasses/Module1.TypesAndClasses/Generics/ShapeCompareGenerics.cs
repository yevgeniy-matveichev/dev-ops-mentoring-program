using Module1.TypesAndClasses.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Module1.TypesAndClasses.Generics
{
    public class ShapeCompareGenerics<T1, T2>
        where T1: IShape
        where T2: IShape
    {
        public bool PerimeterEquals(T1 shape, T2 other)
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
        public bool SquareEquals(T1 shape, T2 other)
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
