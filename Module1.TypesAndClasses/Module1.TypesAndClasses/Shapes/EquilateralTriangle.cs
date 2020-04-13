using Module1.TypesAndClasses.Interfaces;
using System.Text;

namespace Module1.TypesAndClasses.Shapes
{
    public class EquilateralTriangle : IShape
    {

        #region private 

        private int _side = 6;
        private int _height = 8;

        #endregion

        #region constructors

        public EquilateralTriangle(int side, int height)
        {
            _side = side;
            _height = height;
        }

        public EquilateralTriangle(int side)
        {
            _side = side;
        }

        public EquilateralTriangle() { }

        #endregion

        public int Perimeter()
        {
            //throw new NotImplementedException();
            var eTriangle = new EquilateralTriangle();
            var perimeter = 3 * eTriangle._side;

            return perimeter;
        }

        public long Square()
        {
            //throw new NotImplementedException();
            var eTriangle = new EquilateralTriangle();
            var square = 1 / 2 * eTriangle._side * eTriangle._height;

            return square;
        }

        public override string ToString() {
            var eTriangle = new EquilateralTriangle();

            var sb = new StringBuilder();
            sb.AppendLine($"Shape: '{eTriangle.GetType().Name}'. ");
            sb.AppendLine($"Square = {eTriangle.Square()}, ");
            sb.AppendLine($"perimeter = {eTriangle.Perimeter()}");

            //var perimeter = eTriangle.Perimeter();
            //var square = eTriangle.Square();
            //var type = eTriangle.GetType().Name;

            //sb.AppendLine();

            //"Shape: '{shape.GetType().Name}'. Square = {shape.Square()}, perimeter = {shape.Perimeter()}"

            return sb.ToString();
        }
    }
}
