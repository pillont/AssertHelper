using System;
using System.Runtime.Serialization;

namespace AssertHelper.Exceptions
{
    public class ComparisonAssertException : ArgumentException
    {
        public ComparisonAssertException()
        { }

        public ComparisonAssertException(string message) : base(message)
        { }

        public ComparisonAssertException(string message, Exception innerException) : base(message, innerException)
        { }

        public ComparisonAssertException(string message, string paramName) : base(message, paramName)
        { }

        public ComparisonAssertException(string message, string paramName, Exception innerException) : base(message, paramName, innerException)
        { }

        protected ComparisonAssertException(SerializationInfo info, StreamingContext context) : base(info, context)
        { }
    }
}
