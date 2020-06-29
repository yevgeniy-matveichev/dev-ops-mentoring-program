using Mentoring.DataAccess;
using Mentoring.Shapes.Interfaces;
using System;

namespace Mentoring.Shapes.Shapes
{
    public class Rectangle : BaseShape
    {
        #region  private fields

        private readonly double _sideA;
        private readonly double _sideB;

        #endregion    

        // cr: let all the shapes work with double values
        public Rectangle(double a, double b, Units unit) : base(unit)
        {
            if (a < 0 || b < 0)
            {
                throw new ArgumentException($"Cannot perform an operation: Argument values must be positive ");
            }

            _sideA = a;
            _sideB = b;
        }

        public override ShapeTypes ShapeType => ShapeTypes.Rectangle;

        #region public methods

        public override double GetPerimeter()
        {
            return (ShapeHelper.ToMeters(this.Unit,_sideA) + ShapeHelper.ToMeters(this.Unit, _sideB)) * 2;
        }

        public override double GetSquare()
        {
            return (ShapeHelper.ToMeters(this.Unit, _sideA) * ShapeHelper.ToMeters(this.Unit, _sideB));
        }

        public override string ToString()
        {
            return $"Shape: '{nameof(Rectangle)}'. Square = {GetSquare()} {Units.Meter},"
                + $"perimeter = {GetPerimeter()} {Units.Meter}, SideA = {ShapeHelper.ToMeters(this.Unit,this._sideA)}, "
                + $"SideB = {ShapeHelper.ToMeters(this.Unit, this._sideB)}";
        }
        
        #endregion
    }
}

