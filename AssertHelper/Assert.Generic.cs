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
            DebugAction<T>(() =>
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
            DebugAction<T>(() =>
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
            DebugAction<T>(() =>
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
            DebugAction<T>(() =>
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
            DebugAction<T>(() =>
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
            DebugAction<T>(() =>
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
            DebugAction<T>(() =>
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
            DebugAction<T>(() =>
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
            DebugAction<T>(() =>
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
            DebugAction<T>(() =>
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
            DebugAction<T>(() =>
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
            DebugAction<T>(() =>
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
            DebugAction<T>(() =>
                        True(value, paramName, message));
        }

        /// <summary>
        /// logic about the <see cref="TryMustDebug"/>
        /// if the value is true keep exception
        /// else catch it to return bool result
        /// </summary>
        private static bool DebugAction<T>(Action action) where T : Exception
        {
            try
            {
                action?.Invoke();
                return true;
            }
            catch (Exception e)
            {
                bool useMessage = true;
                var ctor = typeof(T).GetConstructor(new[] { typeof(string) });

                if (ctor == null)
                {
                    useMessage = false;
                    typeof(T).GetConstructor(Type.EmptyTypes);
                }

                // NOTE : not use assert, else inseption of assert !
                // EXCEPTION : StackOverflow
                if (ctor == null)
                    throw new AssertException($"{typeof(T)} need ctor() or ctor(string) to be used in generic assert");

                var exception = useMessage
                            ? Activator.CreateInstance(typeof(T), new[] { e.Message }) as Exception
                            : Activator.CreateInstance<T>() as Exception;

                throw exception;
            }
        }
    }
}
