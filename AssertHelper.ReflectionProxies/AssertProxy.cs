using AssertHelper.Logic.AttributesActions;
using System;
using System.Reflection;

namespace AssertHelper.ReflectionProxies
{
    /// <summary>
    /// proxy to inject assert logic on method and properties called
    /// </summary>
    /// <remarks>
    /// NOTE : must be public to allow creation by factory
    /// </remarks>
    [Obsolete("better to use AssertHelper.Proxies.CastleInterceptors.AssertProxyFactory")]
    public class AssertProxy : DispatchProxy
    {
        /// <summary>
        /// service to apply logic of assert
        /// </summary>
        internal AssertProxyService Service { get; }

        /// <summary>
        /// object proxied
        /// flat pass of cache taget
        /// </summary>
        protected internal object Target
        {
            get => Service.Target;
            set => Service.Target = value;
        }

        public AssertProxy()
        {
            Service = new AssertProxyService();
        }

        /// <summary>
        /// called when method is called
        /// collect all attribute and check assert before call real method
        /// </summary>
        /// <param name="method"> method called </param>
        /// <param name="parameters"> param used </param>
        /// <returns> result of the method </returns>
        protected override object Invoke(MethodInfo method, object[] parameters)
        {
            Assert.NotNull(method, nameof(method));

            Service.ApplyAsserts(method, parameters);
            var result = method.Invoke(Target, parameters);
            return result;
        }
    }
}
