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
        /// <param name="e"> exception throw if fail</param>
        /// <param name="value"> value to check </param>
        /// <returns> return result of the assert if <see cref="TryMustDebug"/> is false </returns>
        public static void Default<U>(U value, Exception e)
        {
            CatchOnAction(e, () =>
                        Default(value));
        }

        /// <summary>
        /// Check if the value is empty value
        /// </summary>
        /// <param name="value"> value to check </param>
        /// <param name="e"> exception throw if fail</param>
        /// <returns> return result of the assert if <see cref="TryMustDebug"/> is false </returns>
        public static void Empty(IEnumerable value, Exception e)
        {
            CatchOnAction(e, () =>
                        Empty(value));
        }

        /// <summary>
        /// Check if the value is false
        /// </summary>
        /// <param name="value"> value to check </param>
        /// <param name="e"> exception throw if fail</param>
        /// <returns> return result of the assert if <see cref="TryMustDebug"/> is false </returns>
        public static void False(bool value, Exception e)
        {
            CatchOnAction(e, () =>
                        False(value));
        }

        /// <summary>
        /// Check if the value is greater than border
        /// </summary>
        /// <param name="value"> value to check </param>
        /// <param name="border"> border to be sure value arg is greater </param>
        /// <param name="e"> exception throw if fail</param>
        /// <returns> return result of the assert if <see cref="TryMustDebug"/> is false </returns>
        public static void GreaterThan(double value, double border, Exception e)
        {
            CatchOnAction(e, () =>
                        GreaterThan(value, border));
        }

        /// <summary>
        /// Check if the value is assignable to generic type
        /// </summary>
        /// <typeparam name="U">generic Type </typeparam>
        /// <param name="target"> target to must be assignable </param>
        /// <param name="e"> exception throw if fail</param>
        public static void IsAssignable<U>(object value, Exception e)
        {
            CatchOnAction(e, () =>
                        IsAssignable<U>(value));
        }

        /// <summary>
        /// Check if the value is less than border
        /// </summary>
        /// <param name="value"> value to check </param>
        /// <param name="border"> border to be sure value arg is less </param>
        /// <param name="e"> exception throw if fail</param>
        /// <returns> return result of the assert if <see cref="TryMustDebug"/> is false </returns>
        public static void LessThan(double value, double border, Exception e)
        {
            CatchOnAction(e, () =>
                        LessThan(value, border));
        }

        /// <summary>
        /// Check if the value is not default value
        /// </summary>
        /// <param name="value"> value to check </param>
        /// <param name="e"> exception throw if fail</param>
        /// <returns> return result of the assert if <see cref="TryMustDebug"/> is false </returns>
        public static void NotDefault(object value, Exception e)
        {
            CatchOnAction(e, () =>
                        NotDefault(value));
        }

        /// <summary>
        /// Check if the value is not empty value
        /// </summary>
        /// <param name="value"> value to check </param>
        /// <param name="e"> exception throw if fail</param>
        /// <returns> return result of the assert if <see cref="TryMustDebug"/> is false </returns>
        public static void NotEmpty(IEnumerable value, Exception e)
        {
            CatchOnAction(e, () =>
                        NotEmpty(value));
        }

        /// <summary>
        /// Check if the value is not null
        /// </summary>
        /// <param name="value"> value to check </param>
        /// <param name="e"> exception throw if fail</param>
        /// <returns> return result of the assert if <see cref="TryMustDebug"/> is false </returns>
        public static void NotNull(object value, Exception e)
        {
            CatchOnAction(e, () =>
                        NotNull(value));
        }

        /// <summary>
        /// Check if the value is null
        /// </summary>
        /// <param name="value"> value to check </param>
        /// <param name="e"> exception throw if fail</param>
        /// <returns> return result of the assert if <see cref="TryMustDebug"/> is false </returns>
        public static void Null(object value, Exception e)
        {
            CatchOnAction(e, () =>
                        Null(value));
        }

        /// <summary>
        /// Check if the value is true
        /// </summary>
        /// <param name="value"> value to check </param>
        /// <param name="e"> exception throw if fail</param>
        /// <returns> return result of the assert if <see cref="TryMustDebug"/> is false </returns>
        public static void True(bool value, Exception e)
        {
            CatchOnAction(e, () =>
                         True(value));
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
