using System;
using System.Runtime.Serialization;

namespace AssertHelper.Exceptions
{
    public class DefaultAssertException : ArgumentException
    {
        public DefaultAssertException()
        { }

        public DefaultAssertException(string message) : base(message)
        { }

        public DefaultAssertException(string message, Exception innerException) : base(message, innerException)
        { }

        public DefaultAssertException(string message, string paramName) : base(message, paramName)
        { }

        public DefaultAssertException(string message, string paramName, Exception innerException) : base(message, paramName, innerException)
        { }

        protected DefaultAssertException(SerializationInfo info, StreamingContext context) : base(info, context)
        { }
    }
}
