using Mentoring.Shapes.Interfaces;
using System;

namespace Mentoring.Shapes.Shapes
{
    public abstract class BaseShape : IShape
    {
        private const double Delta = 0.001;

        public abstract double Perimeter();

        public abstract double Square();

        public Units Unit { get; }

        public abstract ShapeType shapeType { get; }

        protected BaseShape(Units unit)
        {
            this.Unit = unit;
        }

        public bool PerimeterEquals(IShape shape1, IShape shape2)
        {
            if (shape1 == null)
            {
                throw new ArgumentNullException(nameof(shape1));
            }

            if (shape2 == null)
            {
                throw new ArgumentNullException(nameof(shape2));
            }

            double delta = shape1.Perimeter() - shape2.Perimeter();

            return Math.Abs(delta) < Delta;
        }

        public bool SquareEquals(IShape shape1, IShape shape2)
        {
            if (shape1 == null)
            {
                throw new ArgumentNullException(nameof(shape1));
            }

            if (shape2 == null)
            {
                throw new ArgumentNullException(nameof(shape2));
            }

            double delta = shape1.Square() - shape2.Square();

            return Math.Abs(delta) < Delta;
        }

        protected static double ToMeters(Units unit, double value)
        {
            switch (unit)
            {
                case Units.Meters:
                    return value;
                case Units.Centimeters:
                    return value / 100;
                case Units.Millimeters:
                    return value / 1000;
                default:
                    throw new NotSupportedException($"The unit of measurement {unit} is not supported.");
            }
        }
    }
}