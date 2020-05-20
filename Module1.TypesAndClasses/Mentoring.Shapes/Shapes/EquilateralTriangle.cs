using Mentoring.DataModel;
using Mentoring.Shapes.Interfaces;
using System;
using System.Text;

namespace Mentoring.Shapes.Shapes
{
    public class EquilateralTriangle : BaseShape
    {
        private readonly double _sideInMeters;

        public override ShapeTypes shapeType => ShapeTypes.EquilateralTriangle;

        public EquilateralTriangle(double side, Units units = Units.Meter) : base(units)
        {
            if (side <= 0)
            {
                throw new ArgumentException("The side cannot be less or equal to 0.");
            }

            _sideInMeters = ShapeHelper.ToMeters(units, side);
        }

        #region public methods

        public override double GetPerimeter()
        {
            return 3 * _sideInMeters;
        }

        public override double GetSquare()
        {
            return (Math.Sqrt(3) / 4) * Math.Pow(_sideInMeters, 2);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append($"Shape: '{nameof(EquilateralTriangle)}'. ");
            sb.Append($"Square = {this.GetSquare()} {Unit}s, ");
            sb.Append($"perimeter = {this.GetPerimeter()} {Unit}s. ");
            sb.Append($"Side = {_sideInMeters} ");
            sb.Append($"{Unit}s.");

            return sb.ToString();
        }

        #endregion
    }
}