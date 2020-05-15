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

            return shape.GetPerimeter() == other.GetPerimeter();
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

            return shape.GetSquare() == other.GetSquare();
        }
    }
}
