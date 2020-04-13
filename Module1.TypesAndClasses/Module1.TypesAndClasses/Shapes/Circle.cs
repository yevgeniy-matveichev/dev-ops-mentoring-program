using Module1.TypesAndClasses.Interfaces;
using System;

namespace Module1.TypesAndClasses.Shapes
{
    public class Circle : IShape
    {
        #region private
        private int radius { get; }

        #endregion

        #region constructor
        public Circle(int radius) 
        {
            if (radius < 0) 
            {
                throw new ArgumentException($"Radius cannot be less than 0! Actual value was '{radius}'");
            }
            else 
            { 
                this.radius = checked(radius);
            }
        }

        #endregion

        public int Perimeter()
        {
            try
            {
                var result = 2 * Convert.ToInt32(Math.PI) * radius;
                return result;
            }
            catch
            {
                throw new ArgumentException($"Cannot perform an operation: 'Perimeter' with radius = '{radius}'");
            }
        }

        public long Square()
        {
            try
            {
                double result = Math.PI * Math.Pow(Convert.ToDouble(radius), Convert.ToDouble(2));
                return Convert.ToInt64(result);
            }
            catch
            {
                throw new ArgumentException($"Cannot perform an operation: 'Square' with radius = '{radius}'");
            }
        }

        public override string ToString()
        {
            return $"Shape: '{this.GetType().Name}'. Square = {this.Square()}, perimeter = {this.Perimeter()}";
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                Circle circle = (Circle)obj;
                return this.Perimeter() == circle.Perimeter();
            }
            else
            {
                return false;
            }
        }

        public static bool operator ==(Circle circle1, Circle circle2)
        {
            return circle1.Square() == circle2.Square();
        }

        public static bool operator !=(Circle circle1, Circle circle2)
        {
            return !(circle1.Square() == circle2.Square());
        }
    }
}
