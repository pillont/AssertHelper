using AssertHelper.Logic.AttributesActions;
using Castle.DynamicProxy;

namespace AssertHelper.CastleInterceptors
{
    internal class AssertInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            var service = new AssertProxyService
            {
                Target = invocation.InvocationTarget
            };

            service.ApplyAsserts(invocation.Method, invocation.Arguments);

            invocation.Proceed();
        }
    }
}
