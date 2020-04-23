using Module1.TypesAndClasses.Interfaces;
using System;

namespace Module1.TypesAndClasses.Shapes
{
    public abstract class BaseShape : IShape
    {
        public abstract double Perimeter();

        public abstract double Square();

        public Units Units { get; }

        protected BaseShape(Units unit)
        {
            this.Units = unit;
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

            return ToMeters(shape1.Units, shape1.Perimeter()) == ToMeters(shape2.Units, shape2.Perimeter());
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

            return ToMeters(shape1.Units, shape1.Square()) == ToMeters(shape2.Units, shape2.Square());
        }

        protected static double ToMeters(Units unit, double value)
        {
            switch (unit)
            {
                case Units.meter:
                    return Math.Round(value, 2);
                case Units.centimeter:
                    return Math.Round(value / 100, 2);
                case Units.millimeter:
                    return Math.Round(value / 1000, 2);

                default:
                    throw new NotSupportedException($"The unit of measurement {unit} is not supported.");
            }
        }
    }
}