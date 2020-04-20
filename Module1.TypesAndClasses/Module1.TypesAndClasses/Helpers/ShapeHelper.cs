using System;
using System.Collections.Generic;
using System.Text;
using Module1.TypesAndClasses.Interfaces;
using Module1.TypesAndClasses.Shapes;

namespace Module1.TypesAndClasses.Helpers
{
    public static class ShapeHelper
    {
        public static bool PerimeterEquals(BaseShape shape1, BaseShape shape2)
        {
             return shape1.Equals(shape2); 
        }
                   
        public static bool SquareEquals(BaseShape shape1, BaseShape shape2)
        {
            if (shape1 is null)
            {
                throw new ArgumentNullException(nameof(shape1));
            }

            if (shape2 is null)
            {
                throw new ArgumentNullException(nameof(shape2));
            }

            { return (shape1 == shape2); }
                    }
    }
}
