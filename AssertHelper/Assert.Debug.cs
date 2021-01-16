using System;
using System.Collections;
using System.Diagnostics;

namespace AssertHelper
{
    /// <summary>
    /// contains same function same sample assert
    /// but can disable debug
    /// there functions start with 'Debug'
    /// try part to :
    /// - debug warn in debug case
    /// - do nothing in release case
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
    ///         => this code apply warn to inform directly developer
    ///     // RELEASE CASE : TryMustThrow is false
    ///         => do nothing to not crash the final user
    ///     DebugExample(null);
    /// }
    ///
    /// public void DebugExample(object obj)
    /// {
    ///     // Assert check
    ///     // in debug, this line inform developer
    ///     Assert.DebugNotNull(obj);
    ///     [...]
    /// }
    ///
    /// </example>
    public static partial class Assert
    {
        public static event Action<string> OnFail;

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
        public static void DebugDefault<T>(T value, string paramName = null, string message = null)
        {
            DebugAction(() =>
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
        public static void DebugEmpty(IEnumerable value, string paramName = null, string message = null)
        {
            DebugAction(() =>
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
        public static void DebugFalse(bool value, string paramName = null, string message = null)
        {
            DebugAction(() =>
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
        public static void DebugGreaterThan(double value, double border, string paramName = null, string message = null)
        {
            DebugAction(() =>
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
        public static void DebugIsAssignable<T>(object value, string paramName = null, string message = null)
        {
            DebugAction(() =>
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
        public static void DebugLessThan(double value, double border, string paramName = null, string message = null)
        {
            DebugAction(() =>
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
        public static void DebugNotDefault<T>(T value, string paramName = null, string message = null)
        {
            DebugAction(() =>
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
        public static void DebugNotEmpty(IEnumerable value, string paramName = null, string message = null)
        {
            DebugAction(() =>
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
        public static void DebugNotNull(object value, string paramName = null, string message = null)
        {
            DebugAction(() =>
                        NotNull(value, paramName, message));
        }

        /// <summary>
        /// Check if the value is not null or Empty
        /// </summary>
        /// <param name="value"> value to check </param>
        /// <param name="paramName">
        /// name of the param about this assert
        /// to inform in error message
        /// </param>
        /// <param name="message"> specific message to show on error case </param>
        /// <returns> return result of the assert if <see cref="TryMustDebug"/> is false </returns>
        /// <exception cref="NullAssertException"> if assert false</exception>
        public static void DebugNotNullOrEmpty(string value, string paramName = null, string message = null)
        {
            DebugAction(() =>
                            NotNullOrEmpty(value, paramName, message));
        }

        /// <summary>
        /// Check if the value is not null or white space
        /// </summary>
        /// <param name="value"> value to check </param>
        /// <param name="paramName">
        /// name of the param about this assert
        /// to inform in error message
        /// </param>
        /// <param name="message"> specific message to show on error case </param>
        /// <returns> return result of the assert if <see cref="TryMustDebug"/> is false </returns>
        /// <exception cref="NullAssertException"> if assert false</exception>
        public static void DebugNotNullOrWhiteSpace(string value, string paramName = null, string message = null)
        {
            DebugAction(() =>
                            NotNullOrWhiteSpace(value, paramName, message));
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
        public static void DebugNull(object value, string paramName = null, string message = null)
        {
            DebugAction(() =>
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
        public static void DebugTrue(bool value, string paramName = null, string message = null)
        {
            DebugAction(() =>
                        True(value, paramName, message));
        }

        /// <summary>
        /// logic about the <see cref="TryMustDebug"/>
        /// if the value is true keep exception
        /// else catch it to return bool result
        /// </summary>
        private static void DebugAction(Action action)
        {
            if (!TryMustDebug)
                return;

            try
            {
                action?.Invoke();
            }
            catch (Exception e)
            {
                // look at the "Call Stack" window to find failed assert call  !
                Debug.Fail(e.Message);
                OnFail?.Invoke(e.Message);
            }
        }
    }
}