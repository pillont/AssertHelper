using System;

namespace AssertHelper.Utils
{
    /// <summary>
    /// helper for know default values
    /// </summary>
    public static class DefaultUtils
    {
        public static object GetDefault(this Type t)
        {
            var defaultValue = typeof(DefaultUtils)
                .GetMethod(nameof(GetDefaultGeneric), new Type[] { })
                .MakeGenericMethod(t).Invoke(null, null);
            return defaultValue;
        }

        public static T GetDefaultGeneric<T>()
        {
            return default(T);
        }
    }
}
