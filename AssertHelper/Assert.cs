using AssertHelper.Exceptions;
using AssertHelper.Utils;
using System.Collections;

namespace AssertHelper
{
    /// <summary>
    /// sample asserts function to secure function
    /// </summary>
    /// <example>
    ///
    /// public void Main()
    /// {
    ///     SampleExample(null);
    /// }
    ///
    /// public void SampleExample(object obj)
    /// {
    ///     //Assert check
    ///     // this line throw exception everytime
    ///     Assert.NotNull(obj);
    ///
    ///     [...]
    /// }
    ///
    /// </example>
    public static partial class Assert
    {
        /// <summary>
        /// check if the value is default value
        /// </summary>
        /// <param name="value"> value to compare </param>
        /// <param name="paramName">
        /// name of the param about this assert
        /// to inform in error message
        /// </param>
        /// <param name="message"> specific message to show on error case </param>
        /// <param name="comparer"> comparer to use in equal comparison </param>
        /// <exception cref="DefaultAssertException"> if assert false</exception>
        public static void Default<T>(T value, string paramName, string message = null)
        {
            message = message ?? $"{value} must be default value";
            var defaultValue = default(T);

            if (value == null)
            {
                Null(defaultValue, paramName, message);
                return;
            }

            if (!value.Equals(defaultValue))
                throw new DefaultAssertException(message);
        }

        /// <summary>
        /// check if the value is empty value
        /// </summary>
        /// <param name="value"> value to compare </param>
        /// <param name="paramName">
        /// name of the param about this assert
        /// to inform in error message
        /// </param>
        /// <param name="message"> specific message to show on error case </param>
        /// <param name="comparer"> comparer to use in equal comparison </param>
        /// <exception cref="EmptyAssertException"> if assert false</exception>
        public static void Empty(IEnumerable value, string paramName, string message = null)
        {
            message = message ?? "list must not be empty";
            if (value?.GetEnumerator()?.MoveNext() ?? false)
                throw new EmptyAssertException(message, paramName);
        }

        /// <summary>
        /// check if the value is false
        /// </summary>
        /// <param name="value"> value to compare </param>
        /// <param name="paramName">
        /// name of the param about this assert
        /// to inform in error message
        /// </param>
        /// <param name="message"> specific message to show on error case </param>
        /// <param name="comparer"> comparer to use in equal comparison </param>
        /// <exception cref="BooleanAssertException"> if assert false</exception>
        public static void False(bool value, string paramName, string message = null)
        {
            message = message ?? "value must be false";

            True(!value, paramName, message);
        }

        /// <summary>
        /// Check if the value is greater than border
        /// </summary>
        /// <param name="value"> value to check </param>
        /// <param name="border"> border to be sure value arg is greater </param>
        /// <param name="paramName">
        /// name of the param about this assert
        /// to inform in error message
        /// </param>
        /// <param name="message"> specific message to show on error case </param>
        /// <exception cref="ComparisonAssertException"> if assert false</exception>
        public static void GreaterThan(double value, double border, string paramName, string message = null, bool allowEquality = false)
        {
            message = message ?? $"variable {paramName} must be greater than {border}";

            if (value > border
            || (allowEquality
                && value == border))
                return;

            throw new ComparisonAssertException(message);
        }

        /// <summary>
        /// Check if the value is assignable to generic type
        /// </summary>
        /// <typeparam name="T">generic Type </typeparam>
        /// <param name="target"> target to must be assignable </param>
        /// <param name="paramName">
        /// name of the param about this assert
        /// to inform in error message
        /// </param>
        /// <param name="message"> specific message to show on error case </param>
        /// <exception cref="TypeAssertException"> if assert false</exception>
        public static void IsAssignable<T>(object target, string paramName, string message = null)
        {
            message = message ?? $"{paramName} must implement {typeof(T).Name}";

            if (!(target is T))
                throw new TypeAssertException(paramName, message);
        }

        /// <summary>
        /// Check if the value is less than border
        /// </summary>
        /// <param name="value"> value to check </param>
        /// <param name="border"> border to be sure value arg is less </param>
        /// <param name="paramName">
        /// name of the param about this assert
        /// to inform in error message
        /// </param>
        /// <param name="message"> specific message to show on error case </param>
        /// <exception cref="ComparisonAssertException"> if assert false</exception>
        public static void LessThan(double value, double border, string paramName, string message = null, bool allowEquality = false)
        {
            message = message ?? $"variable {paramName} must be less than {border}";

            if (value < border
            || (allowEquality
                && value == border))
                return;

            throw new ComparisonAssertException(message);
        }

        /// <summary>
        /// Check if the value is not default value
        /// </summary>
        /// <param name="value"> value to check </param>
        /// <param name="paramName">
        /// name of the param about this assert
        /// to inform in error message
        /// </param>
        /// <param name="message"> specific message to show on error case </param>
        /// <exception cref="DefaultAssertException"> if assert false</exception>
        public static void NotDefault<T>(T value, string paramName, string message = null)
        {
            message = message ?? $"value must not be default of {typeof(T)}";
            if (value == null)
            {
                if (default(T) == null)
                    throw new DefaultAssertException(message, paramName);

                return;
            }

            if (value.Equals(DefaultUtils.GetDefault(value.GetType())))
                throw new DefaultAssertException(message, paramName);
        }

        /// <summary>
        /// Check if the value is not empty value
        /// </summary>
        /// <param name="value"> value to check </param>
        /// <param name="paramName">
        /// name of the param about this assert
        /// to inform in error message
        /// </param>
        /// <param name="message"> specific message to show on error case </param>
        /// <exception cref="EmptyAssertException"> if assert false</exception>
        public static void NotEmpty(IEnumerable value, string paramName, string message = null)
        {
            message = message ?? $"list must not not be empty";

            if ((!value?.GetEnumerator()?.MoveNext()) ?? true)
                throw new EmptyAssertException(message, paramName);
        }

        /// <summary>
        /// Check if the value is not null
        /// </summary>
        /// <param name="value"> value to check </param>
        /// <param name="paramName">
        /// name of the param about this assert
        /// to inform in error message
        /// </param>
        /// <param name="message"> specific message to show on error case </param>
        /// <exception cref="NullAssertException"> if assert false</exception>
        public static void NotNull(object value, string paramName, string message = null)
        {
            message = message ?? $"parameter : {paramName} message : {message ?? $"value must be null but was not"}";

            if (value == null)
                throw new NullAssertException(message, paramName);
        }

        /// <summary>
        /// Check if the value is null
        /// </summary>
        /// <param name="value"> value to check </param>
        /// <param name="paramName">
        /// name of the param about this assert
        /// to inform in error message
        /// </param>
        /// <param name="message"> specific message to show on error case </param>
        /// <exception cref="NullAssertException"> if assert false</exception>
        public static void Null(object value, string paramName, string message = null)
        {
            message = message ?? $"parameter : {paramName} message : {message ?? $"value must be null but was not"}";
            if (value != null)
                throw new NullAssertException(message, paramName);
        }

        /// <summary>
        /// Check if the value is true
        /// </summary>
        /// <param name="value"> value to check </param>
        /// <param name="paramName">
        /// name of the param about this assert
        /// to inform in error message
        /// </param>
        /// <param name="message"> specific message to show on error case </param>
        /// <exception cref="BooleanAssertException"> if assert false</exception>
        public static void True(bool value, string paramName, string message = null)
        {
            message = message ?? $"parameter : {paramName} message : {message ?? $"value must be true but was not"}";
            if (!value)
                throw new BooleanAssertException(paramName, message);
        }
    }
}
