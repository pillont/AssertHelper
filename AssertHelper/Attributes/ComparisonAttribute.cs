namespace AssertHelper.Attributes
{
    /// <summary>
    /// base class to apply comparison
    /// </summary>
    public abstract class ComparisonAttribute : AssertAttribute
    {
        /// <summary>
        /// if check, assert of same value not fail
        /// </summary>
        public bool AllowEquality { get; set; }

        /// <summary>
        /// value to compare the parameter
        /// </summary>
        public double Border { get; set; }

        /// <param name="border"> <see cref="Border"/> </param>
        /// <param name="allowEquality"> <see cref="AllowEquality"/> </param>
        public ComparisonAttribute(double border, bool allowEquality = false)
        {
            Border = border;
            AllowEquality = allowEquality;
        }

        /// <param name="border"> <see cref="Border"/> </param>
        /// <param name="paramName"> <see cref="AssertAttribute.ParameterName"/> </param>
        public ComparisonAttribute(double border, string paramName, bool allowEquality = false)
        {
            ParameterName = paramName;
            Border = border;
            AllowEquality = allowEquality;
        }
    }
}
