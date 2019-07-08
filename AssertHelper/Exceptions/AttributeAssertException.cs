using System;
using System.Runtime.Serialization;

namespace AssertHelper.Exceptions
{
    public class AttributeAssertException : ArgumentException
    {
        public AttributeAssertException()
        { }

        public AttributeAssertException(string message) : base(message)
        { }

        public AttributeAssertException(string message, Exception innerException) : base(message, innerException)
        { }

        public AttributeAssertException(string message, string paramName) : base(message, paramName)
        { }

        public AttributeAssertException(string message, string paramName, Exception innerException) : base(message, paramName, innerException)
        { }

        protected AttributeAssertException(SerializationInfo info, StreamingContext context) : base(info, context)
        { }
    }
}
