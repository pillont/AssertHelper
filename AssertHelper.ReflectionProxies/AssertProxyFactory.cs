using System;

namespace AssertHelper.ReflectionProxies
{
    /// <summary>
    /// factory to create implementation with assert attribute
    /// </summary>
    [Obsolete("better to use AssertHelper.Proxies.CastleInterceptors.AssertProxyFactory")]
    public static class AssertProxyFactory
    {
        /// <summary>
        /// implement interface to apply assert attribute and call implementation
        /// </summary>
        /// <typeparam name="T">Asserted interface</typeparam>
        /// <param name="implementation"> implementation of the interface</param>
        public static T Create<T>(object implementation)
        {
            Assert.IsAssignable<T>(implementation, nameof(implementation));

            object proxy = AssertProxy.Create<T, AssertProxy>();
            ((AssertProxy)proxy).Target = implementation;
            return (T)proxy;
        }
    }
}
