using Module1.TypesAndClasses.Interfaces;
using System;

namespace Module1.TypesAndClasses.Shapes
{
    public class Rectangle : IShape
    {
        #region  private fields

        private readonly int _sideA;
        private readonly int _sideB;

        #endregion 

        public Rectangle(int a, int b)
        {
            if (a >= 0 && b >= 0)
            {
                _sideA = a;
                _sideB = b;
            }
            else 
            { 
                throw new ArgumentException($"Cannot perform an operation: Argument values must be positive "); 
            }
        }

        #region Public Functions
              
        public int Perimeter()
        {
            return (_sideA + _sideB) * 2;
        }

        public long Square()
        {
            return (_sideA * _sideB);
        }
        #endregion

        #region Public Methods
        public override string ToString()
        {
            return $"Shape: '{nameof(Rectangle)}'. Square = {Square()}, perimeter = {Perimeter()}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Rectangle m = obj as Rectangle;
            return m.Perimeter() == this.Perimeter();
        }
        
        public static bool operator ==(Rectangle obj1, Rectangle obj2)
        {
            return obj1.Square() == obj2.Square();
        }
       
        public static bool operator !=(Rectangle obj1, Rectangle obj2)
        {
            return obj1.Square() != obj2.Square();
        }

        #endregion
    }
}
