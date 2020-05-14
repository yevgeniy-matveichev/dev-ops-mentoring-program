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
    }
}