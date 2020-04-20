using Module1.TypesAndClasses.Interfaces;
using System;

namespace Module1.TypesAndClasses.Shapes
{
    public class Rectangle : BaseShape
    {
        #region  private fields

        private readonly int _sideA;
        private readonly int _sideB;
        private readonly string _metricName;

        #endregion

        public override string ShapeName() 
        {
            return nameof(Rectangle);
        }
      
        public Rectangle(int a, int b, MetricName metric)
        {
            if (a >= 0 && b >= 0)
            {
                _sideA = a;
                _sideB = b;
                _metricName = metric.ToString();
            }
            else 
            { 
                throw new ArgumentException($"Cannot perform an operation: Argument values must be positive "); 
            }
        }
        
          public override string Metric()
        {
            return _metricName;
        }
        #region Public Functions
              
        public override int Perimeter()
        {
            return (_sideA + _sideB) * 2;
        }

        public override long Square()
        {
            return (_sideA * _sideB);
        }
        #endregion
         #region Public Methods
        public override string ToString()
        {
            return $"Shape: '{ShapeName()}'. Square = {Square()} {_metricName}2, perimeter = {Perimeter()} {_metricName}";
        }

        

        #endregion
    }
}
