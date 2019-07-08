using System;
using System.Runtime.Serialization;

namespace AssertHelper.Exceptions
{
    public class AssertException : ArgumentException
    {
        public AssertException()
        { }

        public AssertException(string message) : base(message)
        { }

        public AssertException(string message, Exception innerException) : base(message, innerException)
        { }

        public AssertException(string message, string paramName) : base(message, paramName)
        { }

        public AssertException(string message, string paramName, Exception innerException) : base(message, paramName, innerException)
        { }

        protected AssertException(SerializationInfo info, StreamingContext context) : base(info, context)
        { }
    }
}
