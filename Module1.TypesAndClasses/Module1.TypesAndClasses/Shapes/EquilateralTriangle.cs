using Module1.TypesAndClasses.Interfaces;
using System;
using System.Text;

namespace Module1.TypesAndClasses.Shapes
{
    public class EquilateralTriangle : IShape
    {
        protected readonly int _a = 5;

        public int A => _a;

        #region constructors

        public EquilateralTriangle(int side)
        {
            if(side <= 0)
            {
                throw new ArgumentException("The side cannot be less or equal to 0.");
            }
            
            _a = side;
        }

        public EquilateralTriangle() { }

        #endregion

        public int Perimeter()
        {
            return 3 * A;
        }

        public long Square()
        {
            var res = (Math.Sqrt(3) / 4) * Math.Pow(A, 2);
            return (long)res;
        }

        public override string ToString() {
            var eTriangle = new EquilateralTriangle();

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
            return obj1.Square() == obj2.Square();
        }
        public static bool operator !=(EquilateralTriangle obj1, IShape obj2)
        {
            return obj1.Square() != obj2.Square();
        }
    }
}
