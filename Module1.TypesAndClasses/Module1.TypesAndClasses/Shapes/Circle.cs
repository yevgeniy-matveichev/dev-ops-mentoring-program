using Module1.TypesAndClasses.Interfaces;
using System;

namespace Module1.TypesAndClasses.Shapes
{
    public class Circle : BaseShape
    {
        public readonly int _radius;
        public readonly Units _unit;

        #region constructor
        public Circle(int radius, Units u) : base(u)
        {
            if (radius < 0) 
            {
                throw new ArgumentException($"Radius cannot be less than 0! Actual value was '{radius}'");
            }

            _radius = radius;
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
            double result = checked(Math.PI * Math.Pow(Convert.ToDouble(_radius), Convert.ToDouble(2)));
            return result;
        }

        public override string ToString()
        {
            return $"Shape: '{GetType().Name}'. Square = {Square()}, perimeter = {Perimeter()}, radius = {this._radius}";
        }
    }
}
