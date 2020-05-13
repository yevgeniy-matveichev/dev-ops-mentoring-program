using Mentoring.Shapes.Interfaces;
using System;

namespace Mentoring.Shapes.Extensions
{
    public static class IShapeExtensions
    {
        public static bool PerimeterEquals(this IShape shape, IShape other)
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

        public static bool SquareEquals(this IShape shape, IShape other)
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
