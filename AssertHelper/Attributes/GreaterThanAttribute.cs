namespace AssertHelper.Attributes
{
    /// <see cref="Core.Assert.GreaterThan(double, double, string, string, bool)"/>
    public class GreaterThanAttribute : ComparisonAttribute
    {
        /// <param name="border"> <see cref="Border"/> </param>
        /// <param name="allowEquality"> <see cref="AssertAttribute.AllowEquality"/> </param>
        public GreaterThanAttribute(double border, bool allowEquality = false)
            : base(border, allowEquality)
        { }

        /// <param name="border"> <see cref="Border"/> </param>
        /// <param name="paramName"> <see cref="AssertAttribute.ParameterName"/> </param>
        /// <param name="allowEquality"> <see cref="AssertAttribute.AllowEquality"/> </param>
        public GreaterThanAttribute(double border, string paramName, bool allowEquality = false)
            : base(border, paramName, allowEquality)
        { }
    }
}
