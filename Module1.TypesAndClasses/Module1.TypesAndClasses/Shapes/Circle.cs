using Module1.TypesAndClasses.Interfaces;
using System;
using System.Runtime.CompilerServices;

namespace Module1.TypesAndClasses.Shapes
{    
    public class Circle : BaseShape
    {
        #region private

        private readonly int _radius;

        public Metric Metric { get; }

        #endregion

        #region constructor

        public Circle(int radius, Metric metric = Metric.Metr) : base(metric)
        {
            if (radius < 0) 
            {
                throw new ArgumentException($"Radius cannot be less than 0! Actual value was '{radius}'");
            }

            _radius = radius;
        }

        #endregion

        public override double Perimeter()
        {
            var result = checked(2 * Math.PI * _radius);
            int perimeter = Convert.ToInt32(result);
            return perimeter;
        }

        public override double Square()
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

            return ToMeters(this.Metric, this.Perimeter()) == ToMeters(circle.Metric, circle.Perimeter());
        }
       
        public static bool operator ==(Circle circle1, Circle circle2)
        {
            return ToMeters(circle1.Metric, circle1.Square()) == ToMeters(circle2.Metric, circle2.Square());
        }

        public static bool operator !=(Circle circle1, Circle circle2)
        {
            return !(ToMeters(circle1.Metric, circle1.Square()) == ToMeters(circle2.Metric, circle2.Square()));
        }
    }
}
