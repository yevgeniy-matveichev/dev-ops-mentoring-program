using Module1.TypesAndClasses.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Module1.TypesAndClasses.Shapes
{
    public class BaseShape : IShape
    {
        public enum units
        {
            mm,
            dm,
            cm,
            m,
            km
        }

        virtual public int Perimeter()
        {
            return 0;
        }

        virtual public long Square()
        {
            return 0;
        }

        public static bool operator ==(BaseShape obj1, BaseShape obj2)
        {
            return obj1.Square() == obj2.Square();
        }

        public static bool operator !=(BaseShape obj1, BaseShape obj2)
        {
            return !(obj1.Square() == obj2.Square());
        }
    }
}
