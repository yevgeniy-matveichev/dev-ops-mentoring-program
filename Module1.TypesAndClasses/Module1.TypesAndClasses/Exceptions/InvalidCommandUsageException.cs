using System;

namespace Module1.TypesAndClasses.Exceptions
{
    class InvalidCommandUsageException : Exception
    {
        public InvalidCommandUsageException()
        {

        }

        public InvalidCommandUsageException(string message) : base(message)
        {

        }

        public InvalidCommandUsageException(string message, Exception inner)
        {

        }
    }
}
