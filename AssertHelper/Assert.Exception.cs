using AssertHelper.Exceptions;
using System;
using System.Collections;

namespace AssertHelper
{
    public static partial class Assert
    {
        /// <summary>
        /// Check if the value is default value
        /// </summary>
        /// <param name="value"> value to check </param>
        /// <param name="paramName">
        /// name of the param about this assert
        /// to inform in error message
        /// </param>
        /// <param name="message"> specific message to show on error case </param>
        /// <typeparamref name="T">
        /// Type of the exception throw by if fail
        /// must have ctor(string) or defautl ctor
        /// </typeparamref>
        /// <exception cref="AssertException"> if ctor of the wanted exception not found </exception>
        /// <returns> return result of the assert if <see cref="TryMustDebug"/> is false </returns>
        public static void Default<U>(U value, Exception e, string paramName = null, string message = null)
        {
            CatchOnAction(e, () =>
                        Default<U>(value, paramName, message));
        }

        /// <summary>
        /// Check if the value is empty value
        /// </summary>
        /// <param name="value"> value to check </param>
        /// <param name="paramName">
        /// name of the param about this assert
        /// to inform in error message
        /// </param>
        /// <param name="message"> specific message to show on error case </param>
        /// <typeparamref name="T">
        /// Type of the exception throw by if fail
        /// must have ctor(string) or defautl ctor
        /// </typeparamref>
        /// <exception cref="AssertException"> if ctor of the wanted exception not found </exception>
        /// <returns> return result of the assert if <see cref="TryMustDebug"/> is false </returns>
        public static void Empty(IEnumerable value, Exception e, string paramName = null, string message = null)
        {
            CatchOnAction(e, () =>
                        Empty(value, paramName, message));
        }

        /// <summary>
        /// Check if the value is false
        /// </summary>
        /// <param name="value"> value to check </param>
        /// <param name="paramName">
        /// name of the param about this assert
        /// to inform in error message
        /// </param>
        /// <param name="message"> specific message to show on error case </param>
        /// <typeparamref name="T">
        /// Type of the exception throw by if fail
        /// must have ctor(string) or defautl ctor
        /// </typeparamref>
        /// <exception cref="AssertException"> if ctor of the wanted exception not found </exception>
        /// <returns> return result of the assert if <see cref="TryMustDebug"/> is false </returns>
        public static void False(bool value, Exception e, string paramName = null, string message = null)
        {
            CatchOnAction(e, () =>
                        False(value, paramName, message));
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
        /// <typeparamref name="T">
        /// Type of the exception throw by if fail
        /// must have ctor(string) or defautl ctor
        /// </typeparamref>
        /// <exception cref="AssertException"> if ctor of the wanted exception not found </exception>
        /// <returns> return result of the assert if <see cref="TryMustDebug"/> is false </returns>
        public static void GreaterThan(double value, double border, Exception e, string paramName = null, string message = null)
        {
            CatchOnAction(e, () =>
                        GreaterThan(value, border, paramName, message));
        }

        /// <summary>
        /// Check if the value is assignable to generic type
        /// </summary>
        /// <typeparam name="T">exeption type if fail </typeparam>
        /// <typeparam name="U">generic Type </typeparam>
        /// <param name="target"> target to must be assignable </param>
        /// <param name="paramName">
        /// name of the param about this assert
        /// to inform in error message
        /// </param>
        /// <typeparamref name="T">
        /// Type of the exception throw by if fail
        /// must have ctor(string) or defautl ctor
        /// </typeparamref>
        /// <exception cref="AssertException"> if ctor of the wanted exception not found </exception>
        /// <param name="message"> specific message to show on error case </param>
        public static void IsAssignable<U>(object value, Exception e, string paramName = null, string message = null)
        {
            CatchOnAction(e, () =>
                        IsAssignable<U>(value, paramName, message));
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
        /// <typeparamref name="T">
        /// Type of the exception throw by if fail
        /// must have ctor(string) or defautl ctor
        /// </typeparamref>
        /// <exception cref="AssertException"> if ctor of the wanted exception not found </exception>
        /// <returns> return result of the assert if <see cref="TryMustDebug"/> is false </returns>
        public static void LessThan(double value, double border, Exception e, string paramName = null, string message = null)
        {
            CatchOnAction(e, () =>
                        LessThan(value, border, paramName, message));
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
        /// <typeparamref name="T">
        /// Type of the exception throw by if fail
        /// must have ctor(string) or defautl ctor
        /// </typeparamref>
        /// <exception cref="AssertException"> if ctor of the wanted exception not found </exception>
        /// <returns> return result of the assert if <see cref="TryMustDebug"/> is false </returns>
        public static void NotDefault(object value, Exception e, string paramName = null, string message = null)
        {
            CatchOnAction(e, () =>
                        NotDefault(value, paramName, message));
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
        /// <typeparamref name="T">
        /// Type of the exception throw by if fail
        /// must have ctor(string) or defautl ctor
        /// </typeparamref>
        /// <exception cref="AssertException"> if ctor of the wanted exception not found </exception>
        /// <returns> return result of the assert if <see cref="TryMustDebug"/> is false </returns>
        public static void NotEmpty(IEnumerable value, Exception e, string paramName = null, string message = null)
        {
            CatchOnAction(e, () =>
                        NotEmpty(value, paramName, message));
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
        /// <typeparamref name="T">
        /// Type of the exception throw by if fail
        /// must have ctor(string) or defautl ctor
        /// </typeparamref>
        /// <exception cref="AssertException"> if ctor of the wanted exception not found </exception>
        /// <returns> return result of the assert if <see cref="TryMustDebug"/> is false </returns>
        public static void NotNull(object value, Exception e, string paramName = null, string message = null)
        {
            CatchOnAction(e, () =>
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
        /// <exception cref="NullAssertException"> if assert false</exception>
        public static void NotNullOrEmpty(string value, Exception e, string paramName = null, string message = null)
        {
            CatchOnAction(e, () =>
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
        /// <exception cref="NullAssertException"> if assert false</exception>
        public static void NotNullOrWhiteSpace(string value, Exception e, string paramName = null, string message = null)
        {
            CatchOnAction(e, () =>
                            NotNullOrWhiteSpace(value, paramName, message));
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
        /// <typeparamref name="T">
        /// Type of the exception throw by if fail
        /// must have ctor(string) or defautl ctor
        /// </typeparamref>
        /// <exception cref="AssertException"> if ctor of the wanted exception not found </exception>
        /// <returns> return result of the assert if <see cref="TryMustDebug"/> is false </returns>
        public static void Null(object value, Exception e, string paramName = null, string message = null)
        {
            CatchOnAction(e, () =>
                        Null(value, paramName, message));
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
        /// <typeparamref name="T">
        /// Type of the exception throw by if fail
        /// must have ctor(string) or defautl ctor
        /// </typeparamref>
        /// <exception cref="AssertException"> if ctor of the wanted exception not found </exception>
        /// <returns> return result of the assert if <see cref="TryMustDebug"/> is false </returns>
        public static void True(bool value, Exception e, string paramName = null, string message = null)
        {
            CatchOnAction(e, () =>
                         True(value, paramName, message));
        }

        private static void CatchOnAction(Exception e, Action a)
        {
            try
            {
                a?.Invoke();
            }
            catch (AssertException)
            {
                throw e;
            }
        }
    }
}
