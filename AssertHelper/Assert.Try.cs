using System;
using System.Collections;
using System.Diagnostics;

namespace AssertHelper
{
    /// <summary>
    /// contains same function same sample assert
    /// but can disable exception
    /// there functions start with 'Try'
    /// try part to :
    /// - throw exception in debug case
    /// - return false in release case
    /// </summary>
    /// <example>
    ///
    /// public void Main()
    /// {
    ///     // init assert config  to know current context
    ///     if(release)
    ///         Assert.TryMustThrow = false;
    ///
    ///     // DEBUG CASE : TryMustThrow is true
    ///         => this code throw exception to inform directly developer
    ///     // RELEASE CASE :TryMustThrow is false
    ///         => the assert retun false, this function use the secure exist
    ///             to not crash the final user
    ///     TryExample(null);
    /// }
    ///
    /// public void TryExample(object obj)
    /// {
    ///     // Assert check
    ///     // in debug, this line throw exception
    ///     bool fail = !Assert.TryNotNull(obj);
    ///     // Secure exit to not show crash on the final user usage
    ///     if(fail)
    ///         return;
    ///
    ///     [...]
    /// }
    ///
    /// </example>
    public static partial class Assert
    {
        /// <summary>
        /// inform if the 'Try' function must throw exception or just return false
        /// think to setup this value in the start of your application
        /// </summary>
        public static bool TryMustDebug { get; set; } = true;

        /// <summary>
        /// Try check if the value is default value
        /// </summary>
        /// <param name="value"> value to check </param>
        /// <param name="paramName">
        /// name of the param about this assert
        /// to inform in error message
        /// </param>
        /// <param name="message"> specific message to show on error case </param>
        /// <returns> return result of the assert if <see cref="TryMustDebug"/> is false </returns>
        /// <exception cref="Exceptions.DefaultAssertException"> if assert false and <see cref="TryMustDebug"/> is true</exception>
        public static bool TryDefault<T>(T value, string paramName, string message = null)
        {
            return DebugAction(() =>
                        Default<T>(value, paramName, message));
        }

        /// <summary>
        /// Try check if the value is empty value
        /// </summary>
        /// <param name="value"> value to check </param>
        /// <param name="paramName">
        /// name of the param about this assert
        /// to inform in error message
        /// </param>
        /// <param name="message"> specific message to show on error case </param>
        /// <returns> return result of the assert if <see cref="TryMustDebug"/> is false </returns>
        /// <exception cref="Exceptions.EmptyAssertException"> if assert false and <see cref="TryMustDebug"/> is true</exception>
        public static bool TryEmpty(IEnumerable value, string paramName, string message = null)
        {
            return DebugAction(() =>
                        Empty(value, paramName, message));
        }

        /// <summary>
        /// Try check if the value is false
        /// </summary>
        /// <param name="value"> value to check </param>
        /// <param name="paramName">
        /// name of the param about this assert
        /// to inform in error message
        /// </param>
        /// <param name="message"> specific message to show on error case </param>
        /// <returns> return result of the assert if <see cref="TryMustDebug"/> is false </returns>
        /// <exception cref="Exceptions.BooleanAssertException"> if assert false and <see cref="TryMustDebug"/> is true</exception>
        public static bool TryFalse(bool value, string paramName, string message = null)
        {
            return DebugAction(() =>
                        False(value, paramName, message));
        }

        /// <summary>
        /// Try check if the value is greater than border
        /// </summary>
        /// <param name="value"> value to check </param>
        /// <param name="border"> border to be sure value arg is greater </param>
        /// <param name="paramName">
        /// name of the param about this assert
        /// to inform in error message
        /// </param>
        /// <param name="message"> specific message to show on error case </param>
        /// <returns> return result of the assert if <see cref="TryMustDebug"/> is false </returns>
        /// <exception cref="Exceptions.ComparisonAssertException"> if assert false and <see cref="TryMustDebug"/> is true</exception>
        public static bool TryGreaterThan(double value, double border, string paramName, string message = null)
        {
            return DebugAction(() =>
                        GreaterThan(value, border, paramName, message));
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
        /// <exception cref="Exceptions.TypeAssertException"> if assert false and <see cref="TryMustDebug"/> is true</exception>
        public static bool TryIsAssignable<T>(object value, string paramName, string message = null)
        {
            return DebugAction(() =>
                        IsAssignable<T>(value, paramName, message));
        }

        /// <summary>
        /// Try check if the value is less than border
        /// </summary>
        /// <param name="value"> value to check </param>
        /// <param name="border"> border to be sure value arg is less </param>
        /// <param name="paramName">
        /// name of the param about this assert
        /// to inform in error message
        /// </param>
        /// <param name="message"> specific message to show on error case </param>
        /// <returns> return result of the assert if <see cref="TryMustDebug"/> is false </returns>
        /// <exception cref="Exceptions.ComparisonAssertException"> if assert false and <see cref="TryMustDebug"/> is true</exception>
        public static bool TryLessThan(double value, double border, string paramName, string message = null)
        {
            return DebugAction(() =>
                        LessThan(value, border, paramName, message));
        }

        /// <summary>
        /// Try check if the value is not default value
        /// </summary>
        /// <param name="value"> value to check </param>
        /// <param name="paramName">
        /// name of the param about this assert
        /// to inform in error message
        /// </param>
        /// <param name="message"> specific message to show on error case </param>
        /// <returns> return result of the assert if <see cref="TryMustDebug"/> is false </returns>
        /// <exception cref="Exceptions.DefaultAssertException"> if assert false and <see cref="TryMustDebug"/> is true</exception>
        public static bool TryNotDefault<T>(T value, string paramName, string message = null)
        {
            return DebugAction(() =>
                        NotDefault<T>(value, paramName, message));
        }

        /// <summary>
        /// Try check if the value is not empty value
        /// </summary>
        /// <param name="value"> value to check </param>
        /// <param name="paramName">
        /// name of the param about this assert
        /// to inform in error message
        /// </param>
        /// <param name="message"> specific message to show on error case </param>
        /// <returns> return result of the assert if <see cref="TryMustDebug"/> is false </returns>
        /// <exception cref="Exceptions.EmptyAssertException"> if assert false and <see cref="TryMustDebug"/> is true</exception>
        public static bool TryNotEmpty(IEnumerable value, string paramName, string message = null)
        {
            return DebugAction(() =>
                        NotEmpty(value, paramName, message));
        }

        /// <summary>
        /// Try check if the value is not null
        /// </summary>
        /// <param name="value"> value to check </param>
        /// <param name="paramName">
        /// name of the param about this assert
        /// to inform in error message
        /// </param>
        /// <param name="message"> specific message to show on error case </param>
        /// <returns> return result of the assert if <see cref="TryMustDebug"/> is false </returns>
        /// <exception cref="Exceptions.NullAssertException"> if assert false and <see cref="TryMustDebug"/> is true</exception>
        public static bool TryNotNull(object value, string paramName, string message = null)
        {
            return DebugAction(() =>
                        NotNull(value, paramName, message));
        }

        /// <summary>
        /// Try check if the value is null
        /// </summary>
        /// <param name="value"> value to check </param>
        /// <param name="paramName">
        /// name of the param about this assert
        /// to inform in error message
        /// </param>
        /// <param name="message"> specific message to show on error case </param>
        /// <returns> return result of the assert if <see cref="TryMustDebug"/> is false </returns>
        /// <exception cref="Exceptions.NullAssertException"> if assert false and <see cref="TryMustDebug"/> is true</exception>
        public static bool TryNull(object value, string paramName, string message = null)
        {
            return DebugAction(() =>
                        Null(value, paramName, message));
        }

        /// <summary>
        /// Try check if the value is true
        /// </summary>
        /// <param name="value"> value to check </param>
        /// <param name="paramName">
        /// name of the param about this assert
        /// to inform in error message
        /// </param>
        /// <param name="message"> specific message to show on error case </param>
        /// <returns> return result of the assert if <see cref="TryMustDebug"/> is false </returns>
        /// <exception cref="Exceptions.BooleanAssertException"> if assert false and <see cref="TryMustDebug"/> is true</exception>
        public static bool TryTrue(bool value, string paramName, string message = null)
        {
            return DebugAction(() =>
                        True(value, paramName, message));
        }

        /// <summary>
        /// logic about the <see cref="TryMustDebug"/>
        /// if the value is true keep exception
        /// else catch it to return bool result
        /// </summary>
        private static bool DebugAction(Action action)
        {
            try
            {
                action?.Invoke();
                return true;
            }
            catch (Exception e)
            {
                if (TryMustDebug)
                {
                    // look at the "Call Stack" window to find failed assert call  !
                    Debug.Fail(e.Message);
                }

                return false;
            }
        }
    }
}
