using System;

namespace AssertHelper.Attributes
{
    /// <summary>
    /// base class to apply assert in method signature
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Parameter | AttributeTargets.Property, Inherited = true, AllowMultiple = true)]
    public abstract class AssertAttribute : Attribute
    {
        /// <summary>
        /// Message to show during assert fail
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// associated parameter name
        /// inform each parameter is associated with the assert
        /// can contains sub properties too
        /// </summary>
        /// <example>
        ///
        /// [AssertAttibuteExtending(ParameterName = "arg1")]   // this is about the object argument
        /// [AssertAttibuteExtending(ParameterName = "arg2.X")] // this is about X of the point argument
        /// public void Test(object arg1, Point arg2)
        ///
        /// </example>
        public string ParameterName { get; set; }
    }
}
