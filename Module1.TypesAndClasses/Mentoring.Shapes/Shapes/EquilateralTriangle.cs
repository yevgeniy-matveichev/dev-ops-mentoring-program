using Mentoring.Shapes.Interfaces;
using System;
using System.Text;

namespace Mentoring.Shapes.Shapes
{
    public class EquilateralTriangle : BaseShape
    {
        private readonly double _sideInMeters;

        public EquilateralTriangle(double side, Units units = Units.Meter) : base(units)
        {
            if (side <= 0)
            {
                throw new ArgumentException("The side cannot be less or equal to 0.");
            }

            _sideInMeters = ShapeHelper.ToMeters(units, side);
        }

        #region public methods

        public override ShapeTypes shapeType => ShapeTypes.EquilateralTriangle;

        public override double Perimeter()
        {
            return 3 * _sideInMeters;
        }

        public override double Square()
        {
            return (Math.Sqrt(3) / 4) * Math.Pow(_sideInMeters, 2);
        }

        public override string ToString() {
            var sb = new StringBuilder();

            sb.Append($"Shape: '{nameof(EquilateralTriangle)}'. ");
            sb.Append($"Square = {this.Square()} {Unit}, ");
            sb.Append($"perimeter = {this.Perimeter()} {Unit}. ");
            sb.Append($"Side = {_sideInMeters} ");
            sb.Append($"{Unit}.");

            return sb.ToString();
        }

        #endregion
    }
}