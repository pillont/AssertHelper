using Castle.DynamicProxy;

namespace AssertHelper.CastleInterceptors
{
    public static class AssertProxyFactory
    {
        public static T CreateForClass<T>(T target) where T : class
        {
            return new ProxyGenerator()
                               .CreateClassProxyWithTarget<T>(target, new AssertInterceptor());
        }

        public static T CreateForInterface<T>(T target) where T : class
        {
            return new ProxyGenerator()
                               .CreateInterfaceProxyWithTarget<T>(target, new AssertInterceptor());
        }
    }
}
