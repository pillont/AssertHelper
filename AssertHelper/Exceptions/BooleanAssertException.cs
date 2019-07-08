using System;
using System.Runtime.Serialization;

namespace AssertHelper.Exceptions
{
    public class BooleanAssertException : ArgumentException
    {
        public BooleanAssertException()
        { }

        public BooleanAssertException(string message) : base(message)
        { }

        public BooleanAssertException(string message, Exception innerException) : base(message, innerException)
        { }

        public BooleanAssertException(string message, string paramName) : base(message, paramName)
        { }

        public BooleanAssertException(string message, string paramName, Exception innerException) : base(message, paramName, innerException)
        { }

        protected BooleanAssertException(SerializationInfo info, StreamingContext context) : base(info, context)
        { }
    }
}
