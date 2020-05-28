using Mentoring.DataAccess;
using Mentoring.Shapes.Interfaces;
using System;

namespace Mentoring.Shapes.Shapes
{
    public class Circle : BaseShape
    {
        public readonly double _radius;
        public readonly Units _unit;

        public override ShapeTypes shapeType => ShapeTypes.Circle;

        #region constructor

        public Circle(double radius, Units u) : base(u)
        {
            if (radius < 0)
            {
                throw new ArgumentException($"Radius cannot be less than 0! Actual value was '{radius}'");
            }

            _radius = ShapeHelper.ToMeters(u, radius);
            _unit = u;
        }

        #endregion

        override public double GetPerimeter()
        {
            // cr: please do in 1 line in all such cases: return checked(2 * Math.PI * _radius);
            var result = checked(2 * Math.PI * _radius);
            return result;
        }

        override public double GetSquare()
        {
            double result = checked(Math.PI * Math.Pow(_radius, 2));
            return result;
        }

        public override string ToString()
        {
            return $"Shape: '{GetType().Name}'. Square = {GetSquare()}, perimeter = {GetPerimeter()}, radius = {this._radius}";
        }
    }
}
