using System;
using System.Runtime.Serialization;

namespace AssertHelper.Exceptions
{
    public class NullAssertException : ArgumentException
    {
        public NullAssertException()
        { }

        public NullAssertException(string message) : base(message)
        { }

        public NullAssertException(string message, Exception innerException) : base(message, innerException)
        { }

        public NullAssertException(string message, string paramName) : base(message, paramName)
        { }

        public NullAssertException(string message, string paramName, Exception innerException) : base(message, paramName, innerException)
        { }

        protected NullAssertException(SerializationInfo info, StreamingContext context) : base(info, context)
        { }
    }
}
