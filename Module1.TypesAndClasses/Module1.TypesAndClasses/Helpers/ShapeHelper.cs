using Module1.TypesAndClasses.Interfaces;
using System;

namespace Module1.TypesAndClasses.Helpers
{
    static class ShapeHelper
    {
        public static bool PerimeterEquals(IShape shape, IShape other)
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

        public static bool SquareEquals(IShape shape, IShape other)
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
