namespace AssertHelper.Attributes
{
    /// <see cref="Core.Assert.LessThan(double, double, string, string, bool)"/>
    public class LessThanAttribute : ComparisonAttribute
    {
        /// <param name="border"> <see cref="Border"/> </param>
        /// <param name="allowEquality"> <see cref="AssertAttribute.AllowEquality"/> </param>
        public LessThanAttribute(double border, bool allowEquality = false)
            : base(border, allowEquality)
        { }

        /// <param name="border"> <see cref="Border"/> </param>
        /// <param name="paramName"> <see cref="AssertAttribute.ParameterName"/> </param>
        /// <param name="allowEquality"> <see cref="AssertAttribute.AllowEquality"/> </param>
        public LessThanAttribute(double border, string paramName, bool allowEquality = false)
            : base(border, paramName, allowEquality)
        { }
    }
}
