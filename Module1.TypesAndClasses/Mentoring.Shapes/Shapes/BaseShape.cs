using Mentoring.DataAccess;
using Mentoring.Shapes.Interfaces;
using System;

namespace Mentoring.Shapes.Shapes
{
    public abstract class BaseShape : IShape
    {
        private const double Delta = 0.001;

        public abstract double GetPerimeter();

        public abstract double GetSquare();

        public Units Unit { get; }

        // cr: in UpperCamelCase, please
        public abstract ShapeTypes ShapeType { get; }

        protected BaseShape(Units unit)
        {
            this.Unit = unit;
        }
    }
}