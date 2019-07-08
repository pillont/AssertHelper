using System;
using System.Runtime.Serialization;

namespace AssertHelper.Exceptions
{
    public class TypeAssertException : ArgumentException
    {
        public TypeAssertException()
        { }

        public TypeAssertException(string message) : base(message)
        { }

        public TypeAssertException(string message, Exception innerException) : base(message, innerException)
        { }

        public TypeAssertException(string message, string paramName) : base(message, paramName)
        { }

        public TypeAssertException(string message, string paramName, Exception innerException) : base(message, paramName, innerException)
        { }

        protected TypeAssertException(SerializationInfo info, StreamingContext context) : base(info, context)
        { }
    }
}
