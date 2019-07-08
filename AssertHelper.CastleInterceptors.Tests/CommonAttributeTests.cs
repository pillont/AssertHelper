using AssertHelper.Attributes;
using AssertHelper.Exceptions;
using AssertHelper.CastleInterceptors;
using System.Drawing;
using Xunit;
using XAssert = Xunit.Assert;

namespace AssertHelper.Tests.Attributes
{
    public class CommonAttributeTests
    {
        public Test Implem { get; }

        public ITest Proxy { get; }

        public CommonAttributeTests()
        {
            Implem = new Test();
            Proxy = AssertProxyFactory.CreateForInterface<ITest>(Implem);
        }

        [Fact]
        public void DifferentName_MethodAttributeInClassTest()
        {
            XAssert.Throws<NullAssertException>(() =>
                                            Proxy.Func4(null));
            Proxy.Func4(new object());
        }

        [Fact]
        public void DifferentName_MethodAttributeInInterfaceTest()
        {
            XAssert.Throws<NullAssertException>(() =>
                                            Proxy.Func3(null));
            Proxy.Func3(new object());
        }

        [Fact]
        public void DifferentName_ParamAttributeInClassTest()
        {
            XAssert.Throws<NullAssertException>(() =>
                                            Proxy.Func2(null));
            Proxy.Func2(new object());
        }

        [Fact]
        public void DifferentName_ParamAttributeInInterfaceTest()
        {
            XAssert.Throws<NullAssertException>(() =>
                                            Proxy.Func1(null));
            Proxy.Func1(new object());
        }

        [Fact]
        public void DifferentSubName_MethodAttributeInClassTest()
        {
            XAssert.Throws<DefaultAssertException>(() =>
                                            Proxy.Func5(new Point()));
            Proxy.Func6(new Point(1, 2));
        }

        [Fact]
        public void DifferentSubName_MethodAttributeInInterfaceTest()
        {
            XAssert.Throws<DefaultAssertException>(() =>
                                            Proxy.Func5(new Point()));
            Proxy.Func5(new Point(1, 2));
        }

        [Fact]
        public void NullOperationInArgumentNameTest()
        {
            XAssert.Throws<AttributeAssertException>(() =>
                                            Proxy.Func7(null));

            XAssert.Throws<AttributeAssertException>(() =>
                                            Proxy.Func8(null));
        }

        public interface ITest
        {
            void Func1([NotNull]object arg);

            void Func2(object arg);

            [NotNull(ParameterName = "arg")]
            void Func3(object arg);

            void Func4(object arg);

            [NotDefault(ParameterName = "arg.X")]
            void Func5(Point arg);

            void Func6(Point arg);

            [NotDefault(ParameterName = "arg?.X")]
            void Func7(Point? arg);

            void Func8(Point? arg);
        }

        public class Test : ITest
        {
            public void Func1(object arg1)
            { }

            public void Func2([NotNull] object arg1)
            { }

            public void Func3(object arg1)
            { }

            [NotNull(ParameterName = "arg1")]
            public void Func4(object arg1)
            { }

            public void Func5(Point arg1)
            { }

            [NotDefault(ParameterName = "arg1.X")]
            public void Func6(Point arg1)
            { }

            public void Func7(Point? arg)
            { }

            [NotDefault(ParameterName = "arg1?.X")]
            public void Func8(Point? arg1)
            { }
        }
    }
}
