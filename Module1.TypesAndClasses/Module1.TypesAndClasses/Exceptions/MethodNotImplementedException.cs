using System;

namespace Module1.TypesAndClasses.Exceptions
{
    class MethodNotImplementedException : Exception
    {
        public MethodNotImplementedException()
        {

        }

        public MethodNotImplementedException(string message) : base(message)
        {

        }

        public MethodNotImplementedException(string message, Exception inner) : base(message, inner)
        {

        }
    }
}
