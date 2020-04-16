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

        //public override bool Equals(object obj)
        //{
        //    var triangle_ = new EquilateralTriangle();

        //    var circle = obj as Circle;
        //    var ellipse = obj as Ellipse;
        //    var rectangle = obj as Rectangle;
        //    var triangle = obj as EquilateralTriangle;

        //    if (triangle_.Perimeter() == circle.Perimeter())
        //    {
        //        return true;

        //    } else if (triangle_.Perimeter() == ellipse.Perimeter())
        //    {
        //        return true;

        //    } else if (triangle_.Perimeter() == rectangle.Perimeter())
        //    {
        //        return true;

        //    } else if (triangle_.Perimeter() == triangle.Perimeter())
        //    {
        //        return true;

        //    } else
        //    {
        //        return false;
        //    }
        //}

        public override bool Equals(object obj)
        {
            IShape objectShape = obj as IShape;

            if (objectShape == null) return false;
            //if (!(obj is IShape shapeObject)) return false;

            return objectShape.Perimeter() == Perimeter();
        }

        //public static bool operator ==(EquilateralTriangle triangle, object obj)
        //{
        //    var circle = obj as Circle;
        //    var ellipse = obj as Ellipse;
        //    var rectangle = obj as Rectangle;
        //    var regularPolygon = obj as RegularPolygon;

        //    if (triangle.Square() == circle.Square()) return true;
        //    else if (triangle.Square() == ellipse.Square()) return true;
        //    else if (triangle.Square() == rectangle.Square()) return true;
        //    else if (triangle.Square() == regularPolygon.Square()) return true;
        //    return false;
        //}

        //public static bool operator !=(EquilateralTriangle triangle, object obj)
        //{
        //    var circle = obj as Circle;
        //    var ellipse = obj as Ellipse;
        //    var rectangle = obj as Rectangle;
        //    var regularPolygon = obj as RegularPolygon;

        //    if (triangle.Square() == circle.Square()) return false;
        //    else if (triangle.Square() == ellipse.Square()) return false;
        //    else if (triangle.Square() == rectangle.Square()) return false;
        //    else if (triangle.Square() == regularPolygon.Square()) return false;
        //    return true;

        //    //if (triangle.Square() == circle.Square()) return false;
        //    //return true;
        //}

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
