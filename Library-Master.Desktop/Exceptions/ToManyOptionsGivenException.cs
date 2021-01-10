using System;
using System.Runtime.Serialization;

namespace Library_Master.Desktop.Exceptions
{
    public class ToManyOptionsGivenException : Exception
    {
        public ToManyOptionsGivenException()
        {
            
        }

        public ToManyOptionsGivenException(string message) : base(message)
        {
            
        }

        public ToManyOptionsGivenException(string message, Exception inner) : base(message, inner)
        {
            
        }
    }
}