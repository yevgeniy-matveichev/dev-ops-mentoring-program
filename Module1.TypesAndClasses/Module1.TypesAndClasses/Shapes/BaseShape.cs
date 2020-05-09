using Module1.TypesAndClasses.Interfaces;
using System;

namespace Module1.TypesAndClasses.Shapes
{
    public abstract class BaseShape : IShape
    {
        private const double Delta = 0.001;

        public abstract double Perimeter();

        public abstract double Square();
        

        public Units Units { get; }

        public abstract ShapeType ShapeName { get; }

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
                case Units.meters:
                    return value;
                case Units.centimeters:
                    return value / 100;
                case Units.millimeters:
                    return value / 1000;
                default:
                    throw new NotSupportedException($"The unit of measurement {unit} is not supported.");
            }
        }
    }
}