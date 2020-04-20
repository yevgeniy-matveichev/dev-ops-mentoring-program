using System;
using System.Collections.Generic;
using System.Text;
using Module1.TypesAndClasses.Interfaces;



namespace Module1.TypesAndClasses.Helpers
{
    static class ShapeHelper
    {
        public static bool PerimeterEquals(IShape shape, int value)
        {
            if (shape != null) { return (shape.Perimeter() == value); }
            else 
            { 
                throw new ArgumentNullException($"ArgumentException must be not null for {nameof(shape)}"); 
            }
        }
        public static bool SquareEquals(IShape shape, int value)
        {
            if (shape != null) { return (shape.Square() == value); }
            else
            {
                throw new ArgumentNullException($"ArgumentException must be not null for {nameof(shape)}");
            }
        }
    }
}
