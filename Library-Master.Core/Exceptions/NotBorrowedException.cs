using System;
using System.Runtime.Serialization;

namespace Library_Master.Core.Exceptions
{
    public class NotBorrowedException : Exception
    {
        public NotBorrowedException()
        {
        }

        public NotBorrowedException(string message) : base(message)
        {
        }

        public NotBorrowedException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
