using Module1.TypesAndClasses.Interfaces;
using System;
using System.Text;

namespace Module1.TypesAndClasses.Shapes
{
    public class EquilateralTriangle : BaseShape
    {
        private readonly int _a;

        public EquilateralTriangle(int side, Metric metric = Metric.Metr): base(metric)
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
            return (long)res;
        }

        public override string ToString() {
            var eTriangle = new EquilateralTriangle(5);

            var sb = new StringBuilder();
            sb.Append($"Shape: '{nameof(EquilateralTriangle)}'. ");
            sb.Append($"Square = {eTriangle.Square()}, ");
            sb.Append($"perimeter = {eTriangle.Perimeter()}");

            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            IShape objectShape = obj as IShape;

            if (objectShape == null) return false;
            return objectShape.Perimeter() == Perimeter();
        }

        public static bool operator ==(EquilateralTriangle obj1, IShape obj2)
        {
            if (ReferenceEquals(obj1, null))
            {
                if (ReferenceEquals(obj2, null))
                {
                    return true;
                }
                return false;
            }

            if (ReferenceEquals(obj2, null))
            {
                return false;
            }

            return obj1.Square() == obj2.Square();
        }

        public static bool operator !=(EquilateralTriangle obj1, IShape obj2)
        {
            if (ReferenceEquals(obj1, null))
            {
                if (ReferenceEquals(obj2, null))
                {
                    return false;
                }
                return true;
            }

            if (ReferenceEquals(obj2, null))
            {
                return true;
            }

            return obj1.Square() != obj2.Square();
        }
    }
}
