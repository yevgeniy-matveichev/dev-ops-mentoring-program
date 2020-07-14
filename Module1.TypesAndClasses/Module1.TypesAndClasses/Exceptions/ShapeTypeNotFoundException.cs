using System;

namespace Module1.TypesAndClasses.Exceptions
{
    class ShapeTypeNotFoundException : Exception
    {
        public ShapeTypeNotFoundException()
        {

        }

        public ShapeTypeNotFoundException(string message) : base(message)
        {

        }

        public ShapeTypeNotFoundException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
