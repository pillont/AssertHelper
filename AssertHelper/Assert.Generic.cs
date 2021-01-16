using AssertHelper.Exceptions;
using System;
using System.Collections;

namespace AssertHelper
{
    /// <summary>
    /// contains same function same sample assert
    /// but can custom exception type
    /// </summary>
    /// <example>
    ///
    /// public void Main()
    /// {
    ///     try
    ///     {
    ///         // throw custom type if assert fail
    ///         TryExample(null);
    ///     }
    ///     catch(CustomException e)
    ///     {
    ///         // assert catch
    ///         [...]
    ///     }
    /// }
    ///
    /// public void TryExample(object obj)
    /// {
    ///     // Assert check
    ///     Assert.NotNull<CustomException>(obj);
    ///
    ///     [...]
    /// }
    ///
    /// </example>
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
        public static void Default<T, U>(U value, string paramName = null, string message = null)
            where T : Exception
        {
            TryAction<T>(() =>
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
        public static void Empty<T>(IEnumerable value, string paramName = null, string message = null)
            where T : Exception
        {
            TryAction<T>(() =>
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
        public static void False<T>(bool value, string paramName = null, string message = null)
            where T : Exception
        {
            TryAction<T>(() =>
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
        public static void GreaterThan<T>(double value, double border, string paramName = null, string message = null)
            where T : Exception
        {
            TryAction<T>(() =>
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
        public static void IsAssignable<T, U>(object value, string paramName = null, string message = null)
            where T : Exception
        {
            TryAction<T>(() =>
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
        public static void LessThan<T>(double value, double border, string paramName = null, string message = null)
            where T : Exception
        {
            TryAction<T>(() =>
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
        public static void NotDefault<T>(object value, string paramName = null, string message = null)
            where T : Exception
        {
            TryAction<T>(() =>
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
        public static void NotEmpty<T>(IEnumerable value, string paramName = null, string message = null)
            where T : Exception
        {
            TryAction<T>(() =>
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
        public static void NotNull<T>(object value, string paramName = null, string message = null)
            where T : Exception
        {
            TryAction<T>(() =>
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
        public static void NotNullOrEmpty<T>(string value, string paramName = null, string message = null)
            where T : Exception
        {
            TryAction<T>(() =>
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
        public static void NotNullOrWhiteSpace<T>(string value, string paramName = null, string message = null)
            where T : Exception
        {
            TryAction<T>(() =>
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
        public static void Null<T>(object value, string paramName = null, string message = null)
            where T : Exception
        {
            TryAction<T>(() =>
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
        public static void True<T>(bool value, string paramName = null, string message = null)
            where T : Exception
        {
            TryAction<T>(() =>
                        True(value, paramName, message));
        }

        internal static Exception CastExceptionInOtherType(Exception e, Type targetType)
        {
            var ctor = targetType.GetConstructor(new[] { typeof(string) });

            bool useMessage = true;
            if (ctor == null)
            {
                useMessage = false;
                targetType.GetConstructor(Type.EmptyTypes);
            }

            // NOTE : not use assert, else inseption of assert !
            // EXCEPTION : StackOverflow
            if (ctor == null)
                throw new AssertException($"{targetType} need ctor() or ctor(string) to be used in generic assert");

            var exception = useMessage
                        ? Activator.CreateInstance(targetType, new[] { e.Message }) as Exception
                        : Activator.CreateInstance(targetType) as Exception;
            return exception;
        }

        /// <summary>
        /// logic about the <see cref="TryMustDebug"/>
        /// if the value is true keep exception
        /// else catch it to return bool result
        /// </summary>
        private static bool TryAction<T>(Action action) where T : Exception
        {
            try
            {
                action?.Invoke();
                return true;
            }
            catch (Exception e)
            {
                Exception exception = CastExceptionInOtherType(e, typeof(T));

                throw exception;
            }
        }
    }
}