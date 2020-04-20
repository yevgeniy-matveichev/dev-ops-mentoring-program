using System;
using System.Collections.Generic;
using System.Text;
using Module1.TypesAndClasses.Interfaces;
using Module1.TypesAndClasses.Shapes;

namespace Module1.TypesAndClasses.Helpers
{
    static class ShapeHelper
    {
        public static bool PerimeterEquals(BaseShape shape, BaseShape value)
        {
            if (shape != null && value != null) { return (shape.Perimeter() == value.Perimeter()); }
            else 
            { 
                throw new ArgumentNullException($"ArgumentException must be not null for {nameof(shape)}"); 
            }
        }
        public static bool SquareEquals(BaseShape shape,BaseShape value)
        {
            if (shape != null && value != null) { return (shape.Square() == value.Square()); }
            else
            {
                throw new ArgumentNullException($"ArgumentException must be not null for {nameof(shape)}");
            }
        }
    }
}
