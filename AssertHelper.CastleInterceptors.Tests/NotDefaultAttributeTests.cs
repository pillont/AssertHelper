using AssertHelper.Attributes;
using AssertHelper.Exceptions;
using AssertHelper.CastleInterceptors;
using System.Drawing;
using Xunit;
using XAssert = Xunit.Assert;

namespace AssertHelper.Tests.Attributes
{
    public class NotDefaultAttributeTests
    {
        public TestCl Implem { get; }

        public ITest Proxy { get; }

        public NotDefaultAttributeTests()
        {
            Implem = new TestCl();
            Proxy = AssertProxyFactory.CreateForInterface<ITest>(Implem);
        }

        [Fact]
        public void InterfaceMethodAttributeTest()
        {
            XAssert.Throws<DefaultAssertException>(() =>
                                                Proxy.Func2(0));
            XAssert.False(Proxy.FuncCalled);

            Proxy.Func2(5);
            XAssert.True(Proxy.FuncCalled);
        }

        [Fact]
        public void InterfaceParameterAttributeTest()
        {
            XAssert.Throws<DefaultAssertException>(() =>
                                                Proxy.Func1(0));
            XAssert.False(Proxy.FuncCalled);

            Proxy.Func1(5);
            XAssert.True(Proxy.FuncCalled);
        }

        [Fact]
        public void Property_InClassTest()
        {
            XAssert.Throws<DefaultAssertException>(() =>
                                                Proxy.Prop2 = 0);
            Proxy.Prop2 = 5;
        }

        [Fact]
        public void Property_InInterfaceTest()
        {
            XAssert.Throws<DefaultAssertException>(() =>
                                                Proxy.Prop1 = 0);
            Proxy.Prop1 = 5;
        }

        [Fact]
        public void PropertyUnknownTest()
        {
            XAssert.Throws<AttributeAssertException>(() =>
                                                Proxy.Func7(42));
            XAssert.False(Proxy.FuncCalled);
        }

        [Fact]
        public void SubPropertyUnknownTest()
        {
            XAssert.Throws<AttributeAssertException>(() =>
                                                Proxy.Func5(new Point()));
            XAssert.False(Proxy.FuncCalled);
        }

        [Fact]
        public void SubPropInMethodAttributeTest()
        {
            var point = new Point();
            point.X = 0;
            XAssert.Throws<DefaultAssertException>(() =>
                                                Proxy.Func3(point));
            XAssert.False(Proxy.FuncCalled);

            point.X = 42;
            Proxy.Func3(point);
            XAssert.True(Proxy.FuncCalled);
        }

        [Fact]
        public void SubPropInParamAttributeTest()
        {
            var point = new Point();
            point.X = 0;
            XAssert.Throws<DefaultAssertException>(() =>
                                                Proxy.Func8(point));
            XAssert.False(Proxy.FuncCalled);

            point.X = 42;
            Proxy.Func8(point);
            XAssert.True(Proxy.FuncCalled);
        }

        public interface ITest
        {
            bool FuncCalled { get; }

            [NotDefault()]
            int Prop1 { get; set; }

            int Prop2 { get; set; }

            void Func1([NotDefault]int value);

            [NotDefault(ParameterName = "value")]
            void Func2(int value);

            [NotDefault(ParameterName = "value.X")]
            void Func3(Point value);

            [NotDefault(ParameterName = "value.ZZZ")]
            void Func5(Point value);

            [NotDefault(ParameterName = "value")]
            void Func6(string value);

            [NotDefault(ParameterName = "ZZZ")]
            void Func7(int value);

            void Func8([NotDefault(ParameterName = "value.X")]Point value);
        }

        public class TestCl : ITest
        {
            public bool FuncCalled { get; set; }
            public int Prop1 { get; set; }

            [NotDefault()]
            public int Prop2 { get; set; }

            public void Func1(int value)
            {
                FuncCalled = true;
            }

            public void Func2(int value)
            {
                FuncCalled = true;
            }

            public void Func3(Point value)
            {
                FuncCalled = true;
            }

            public void Func4(Point value)
            {
                FuncCalled = true;
            }

            public void Func5(Point value)
            {
                FuncCalled = true;
            }

            public void Func6(string value)
            {
                FuncCalled = true;
            }

            public void Func7(int value)
            {
                FuncCalled = true;
            }

            public void Func8(Point value)
            {
                FuncCalled = true;
            }
        }
    }
}
