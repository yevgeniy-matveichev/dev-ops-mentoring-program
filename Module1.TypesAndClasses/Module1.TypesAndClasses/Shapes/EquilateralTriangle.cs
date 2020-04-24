using Module1.TypesAndClasses.Interfaces;
using System;
using System.Text;

namespace Module1.TypesAndClasses.Shapes
{
    public class EquilateralTriangle : BaseShape
    {
        private readonly double _sideInMeters;

        public EquilateralTriangle(double side, Units units = Units.meters) : base(units)
        {
            if (side <= 0)
            {
                throw new ArgumentException("The side cannot be less or equal to 0.");
            }

            _sideInMeters = ToMeters(units, side);
        }

        public override double Perimeter()
        {
            return 3 * _sideInMeters;
        }

        public override double Square()
        {
            var res = (Math.Sqrt(3) / 4) * Math.Pow(_sideInMeters, 2);
            return res;
        }

        public override string ToString() {
            var sb = new StringBuilder();

            sb.Append($"Shape: '{nameof(EquilateralTriangle)}'. ");
            sb.Append($"Square = {this.Square()}, ");
            sb.Append($"perimeter = {this.Perimeter()}. ");
            sb.Append($"Side = {_sideInMeters} ");
            sb.Append($"{Units}.");

            return sb.ToString();
        }
    }
}