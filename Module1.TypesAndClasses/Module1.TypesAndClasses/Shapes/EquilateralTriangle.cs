using Module1.TypesAndClasses.Interfaces;
using System;
using System.Text;

namespace Module1.TypesAndClasses.Shapes
{
    public class EquilateralTriangle : BaseShape
    {
        private readonly double _a;

        public EquilateralTriangle(double side, Units units = Units.meter) : base(units)
        {
            if (side <= 0)
            {
                throw new ArgumentException("The side cannot be less or equal to 0.");
            }

            _a = side;
        }

        public override double Perimeter()
        {
            return 3 * _a;
        }

        public override double Square()
        {
            var res = (Math.Sqrt(3) / 4) * Math.Pow(_a, 2);
            return res;
        }

        public override string ToString() {
            var eTriangle = new EquilateralTriangle(5);

            var sb = new StringBuilder();
            sb.Append($"Shape: '{nameof(EquilateralTriangle)}'. ");
            sb.Append($"Square = {eTriangle.Square()}, ");
            sb.Append($"perimeter = {eTriangle.Perimeter()}. ");
            sb.Append($"Side = {_a}");

            return sb.ToString();
        }
    }
}