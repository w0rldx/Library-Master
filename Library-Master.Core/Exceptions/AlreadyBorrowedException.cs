using System;
using System.Runtime.Serialization;

namespace Library_Master.Core.Exceptions
{
    public class AlreadyBorrowedException : Exception
    {

        public AlreadyBorrowedException()
        {
        }

        public AlreadyBorrowedException(string message) : base(message)
        {
        }

        public AlreadyBorrowedException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}