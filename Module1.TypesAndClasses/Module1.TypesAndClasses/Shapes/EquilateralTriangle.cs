using Module1.TypesAndClasses.Interfaces;
using System;
using System.Text;

namespace Module1.TypesAndClasses.Shapes
{
    public class EquilateralTriangle : BaseShape
    {
        private readonly int _a;
        // private readonly int _unit;
        //protected Unit unit;

        //public virtual Unit Unit
        //{
        //    get { return unit; }
        //    set { SetUnit(value); }
        //}

        //protected virtual void SetUnit(Unit value)
        //{
        //    throw new NotImplementedException();
        //}

        //public int Unit => _unit;

        //public enum Units
        //{
        //    m,
        //    cm,
        //    mm
        //}

        public EquilateralTriangle(int side)
        {
            if (side <= 0)
            {
                throw new ArgumentException("The side cannot be less or equal to 0.");
            }

            _a = side;

            //Units unit = Units.cm;
            //switch(unit)
            //{
            //    case Units.m:
            //        unit = units;
            //        break;
            //    case Units.cm:
            //        unit = units;
            //        break;
            //    case Units.mm:
            //        unit = units;
            //        break;
            //    default:
            //        Console.WriteLine("The unit did not match any of the allowed units.");
            //        break;
            //}
        }

        public override int Perimeter()
        {
            return 3 * _a;
        }

        public override long Square()
        {
            var res = (Math.Sqrt(3) / 4) * Math.Pow(_a, 2);
            return (long)res;
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