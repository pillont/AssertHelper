using System;
using System.Runtime.Serialization;

namespace AssertHelper.Exceptions
{
    public class EmptyAssertException : ArgumentException
    {
        public EmptyAssertException()
        { }

        public EmptyAssertException(string message) : base(message)
        { }

        public EmptyAssertException(string message, Exception innerException) : base(message, innerException)
        { }

        public EmptyAssertException(string message, string paramName) : base(message, paramName)
        { }

        public EmptyAssertException(string message, string paramName, Exception innerException) : base(message, paramName, innerException)
        { }

        protected EmptyAssertException(SerializationInfo info, StreamingContext context) : base(info, context)
        { }
    }
}
