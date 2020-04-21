using Module1.TypesAndClasses.Interfaces;
using System;

namespace Module1.TypesAndClasses.Shapes
{
    public enum Metric
    {
        Milimetr,
        Decimetr,
        Santimetr,
        Metr,
        Kilometr
    }

    public class Circle : IShape
    {
        #region private

        private readonly int _radius;

        #endregion

        public Metric Metric { get; }

        #region constructor

        public Circle(int radius, Metric metric = Metric.Metr) 
        {
            if (radius < 0) 
            {
                throw new ArgumentException($"Radius cannot be less than 0! Actual value was '{radius}'");
            }

            _radius = radius;
            Metric = metric;
        }

        #endregion

        public double Perimeter()
        {
            var result = checked(2 * Math.PI * _radius);
            int perimeter = Convert.ToInt32(result);
            return perimeter;
        }

        public double Square()
        {
            double result = checked(Math.PI * Math.Pow(Convert.ToDouble(_radius), Convert.ToDouble(2)));
            return Convert.ToInt64(result);
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
            
            Circle circle = (Circle)obj;

            return this.Perimeter() == circle.Perimeter();
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
