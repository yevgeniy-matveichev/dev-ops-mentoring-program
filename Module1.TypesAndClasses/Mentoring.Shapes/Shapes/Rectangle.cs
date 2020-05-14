using Mentoring.Shapes.Interfaces;
using System;

namespace Mentoring.Shapes.Shapes
{
    public class Rectangle : BaseShape
    {
        #region  private fields

        private readonly int _sideA;
        private readonly int _sideB;

        #endregion    

        public Rectangle(int a, int b, Units unit) : base(unit)
        {
            if (a < 0 || b < 0)
            {
                throw new ArgumentException($"Cannot perform an operation: Argument values must be positive ");
            }

            _sideA = a;
            _sideB = b;
        }

        public override ShapeType shapeType => ShapeType.Rectangle;

        #region public methods

        public override double Perimeter()
        {
            return (ShapeHelper.ToMeters(this.Unit,_sideA) + ShapeHelper.ToMeters(this.Unit, _sideB)) * 2;
        }

        public override double Square()
        {
            return (ShapeHelper.ToMeters(this.Unit, _sideA) * ShapeHelper.ToMeters(this.Unit, _sideB));
        }

        public override string ToString()
        {
            return $"Shape: '{nameof(Rectangle)}'. Square = {Square()} {Units.Meters}2,"
                + $"perimeter = {Perimeter()} {Units.Meters}, SideA = {ShapeHelper.ToMeters(this.Unit,this._sideA)}, "
                + $"SideB = {ShapeHelper.ToMeters(this.Unit, this._sideB)}";
        }
        
        #endregion
    }
}

