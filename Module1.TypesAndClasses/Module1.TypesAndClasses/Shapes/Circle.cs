using Module1.TypesAndClasses.Interfaces;
using System;

namespace Module1.TypesAndClasses.Shapes
{
    public class Circle : BaseShape
    {
        public readonly int _radius; //for tests becomes protected
        public readonly units _unit;

        #region constructor
        public Circle(int radius, units u) : base(u)
        {
            if (radius < 0) 
            {
                throw new ArgumentException($"Radius cannot be less than 0! Actual value was '{radius}'");
            }

            _radius = radius;
            _unit = u;
        }

        #endregion

        override public int Perimeter()
        {
            var result = checked(2 * Math.PI * _radius);
            int perimeter = Convert.ToInt32(result);
            return perimeter;
        }

        override public long Square()
        {
            double result = checked(Math.PI * Math.Pow(Convert.ToDouble(_radius), Convert.ToDouble(2)));
            return Convert.ToInt64(result);
        }

        public override string ToString()
        {
            return $"Shape: '{GetType().Name}'. Square = {Square()}, perimeter = {Perimeter()}, radius = {this._radius}";
        }
    }
}
