using Module1.TypesAndClasses.Interfaces;
using System;

namespace Module1.TypesAndClasses.Shapes
{

    public class Rectangle : BaseShape
    {
        #region  private fields

        private readonly int _sideA;
        private readonly int _sideB;
        private readonly Units _metricName;

        #endregion
        public override string ShapeName => nameof(Rectangle);

        public Rectangle(int a, int b, Units units) : base(units)
        {
            if (a >= 0 && b >= 0)
            {
                _sideA = a;
                _sideB = b;
                _metricName = units;
            }
            else
            {
                throw new ArgumentException($"Cannot perform an operation: Argument values must be positive ");
            }
        }
               
        #region Public Functions

        public override double Perimeter()
        {
            return (ToMeters(_metricName,_sideA) + ToMeters(_metricName,_sideB)) * 2;
        }

        public override double Square()
        {
            return (ToMeters(_metricName, _sideA) * ToMeters(_metricName, _sideB));
        }
        #endregion

         #region Public Methods

        public override string ToString()
        {
            return $"Shape: '{nameof(Rectangle)}'. Square = {Square()} {Units.meters}2, perimeter = {Perimeter()} {Units.meters}, SideA = {ToMeters(_metricName,this._sideA)}, SideB = {ToMeters(_metricName,this._sideB)}";
        }
        #endregion

    }
}

