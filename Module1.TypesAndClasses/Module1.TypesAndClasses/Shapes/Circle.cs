using Module1.TypesAndClasses.Interfaces;
using System;

namespace Module1.TypesAndClasses.Shapes
{
    public class Circle : IShape
    {
        private int radius { get; }

        Circle(int radius) 
        {
            this.radius = checked(radius);
        }

        //add overflow filters  
        public int Perimeter()
        {
            var result = 2 * Convert.ToInt32(Math.PI) * radius;
            return result;
        }

        //add overflow filters  
        public long Square()
        {
            var result = Math.Pow(Convert.ToDouble(2 * Math.PI * radius), Convert.ToDouble(2));
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
