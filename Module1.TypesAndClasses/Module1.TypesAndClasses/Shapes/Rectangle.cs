using Module1.TypesAndClasses.Interfaces;
using System;

namespace Module1.TypesAndClasses.Shapes
{
    public class Rectangle : BaseShape
    {
        #region  private fields

        private readonly double _sideA;
        private readonly double _sideB;

        #endregion 

        public Rectangle(double a, double b, Metric metric = Metric.Metr) : base(metric)
        {
            if (a >= 0 && b >= 0)
            {
                _sideA = a;
                _sideB = b;
            }
            else 
            { 
                throw new ArgumentException($"Cannot perform an operation: Argument values must be positive "); 
            }
        }

        #region Public Functions
              
        public override double Perimeter()
        {
            return (_sideA + _sideB) * 2;
        }

        public override double Square()
        {
            return (_sideA * _sideB);
        }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return "";
            //return $"Shape: '{nameof(Rectangle)}'. Square = {this.Square()}, perimeter = {Perimeter()}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Rectangle m = obj as Rectangle;
            return ToMeters(this.Metric, m.Perimeter()) == ToMeters(this.Metric, this.Perimeter());
        }

        public static bool operator ==(Rectangle obj1, Rectangle obj2)
        {
            return obj1.Square() == obj2.Square();
        }
       
        public static bool operator !=(Rectangle obj1, Rectangle obj2)
        {
            return obj1.Square() != obj2.Square();
        }

        #endregion
    }
}
