using Module1.TypesAndClasses.Interfaces;
using System;

namespace Module1.TypesAndClasses.Shapes
{
    public class Rectangle : IShape
    {
        private int SideA { set; get; }
        public int SideB { set; get; }


        public int Perimeter()
        {
            return (SideA + SideB) * 2;
        }

        public long Square()
        {
            return (SideA * SideB);
                    }

        public Rectangle(int A, int B)
        {
            SideA = A;
            SideB = B;
        }
       
        public override string ToString()
                 {
                        return $"Shape: '{GetType().Name}'. Square = {Square()}, perimeter = {Perimeter()}";
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
            if (obj1.Square() == obj2.Square())
                return true;
            else return false;
        }
        public static bool operator !=(Rectangle obj1, Rectangle obj2)
        {
            if (obj1.Square() == obj2.Square())
                return false;
            else return true;
        }


    }
}
