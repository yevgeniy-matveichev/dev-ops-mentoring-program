using Mentoring.Shapes.Interfaces;
using System;

namespace Mentoring.Shapes.Shapes
{
    public class Circle : BaseShape
    {
        public readonly double _radius;
        public readonly Units _unit;

        public override ShapeType shapeType => ShapeType.Circle;

        #region constructor

        public Circle(double radius, Units u) : base(u)
        {
            if (radius < 0)
            {
                throw new ArgumentException($"Radius cannot be less than 0! Actual value was '{radius}'");
            }

            _radius = ToMeters(u, radius);
            _unit = u;
        }

        #endregion

        override public double Perimeter()
        {
            var result = checked(2 * Math.PI * _radius);
            return result;
        }

        override public double Square()
        {
            double result = checked(Math.PI * Math.Pow(_radius, 2));
            return result;
        }

        public override string ToString()
        {
            return $"Shape: '{GetType().Name}'. Square = {Square()}, perimeter = {Perimeter()}, radius = {this._radius}";
        }
    }
}
