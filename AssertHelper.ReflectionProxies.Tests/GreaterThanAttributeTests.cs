using AssertHelper.Attributes;
using AssertHelper.Exceptions;
using AssertHelper.ReflectionProxies;
using System;
using System.Drawing;
using Xunit;
using XAssert = Xunit.Assert;

namespace AssertHelper.Tests.Attributes
{
    public class GreaterThanAttributeTests
    {
        public TestCl Implem { get; }

        public ITest Proxy { get; }

        [Obsolete]
        public GreaterThanAttributeTests()
        {
            Implem = new TestCl();
            Proxy = AssertProxyFactory.Create<ITest>(Implem);
        }

        [Fact]
        public void AllowEqualityTest()
        {
            XAssert.Throws<ComparisonAssertException>(() =>
                                                Proxy.Func8(5));
            XAssert.False(Proxy.FuncCalled);

            Proxy.Func8(12);
            XAssert.True(Proxy.FuncCalled);
        }

        [Fact]
        public void InterfaceMethodAttributeTest()
        {
            XAssert.Throws<ComparisonAssertException>(() =>
                                                Proxy.Func2(12));
            XAssert.False(Proxy.FuncCalled);

            XAssert.Throws<ComparisonAssertException>(() =>
                                                Proxy.Func2(5));
            XAssert.False(Proxy.FuncCalled);

            Proxy.Func2(42);
            XAssert.True(Proxy.FuncCalled);
        }

        [Fact]
        public void InterfaceParameterAttributeTest()
        {
            XAssert.Throws<ComparisonAssertException>(() =>
                                                Proxy.Func1(12));
            XAssert.False(Proxy.FuncCalled);

            XAssert.Throws<ComparisonAssertException>(() =>
                                                Proxy.Func1(5));
            XAssert.False(Proxy.FuncCalled);

            Proxy.Func1(42);
            XAssert.True(Proxy.FuncCalled);
        }

        [Fact]
        public void Property_InClassTest()
        {
            XAssert.Throws<ComparisonAssertException>(() =>
                                                Proxy.Prop2 = 12);
            XAssert.Throws<ComparisonAssertException>(() =>
                                                Proxy.Prop2 = 5);
            Proxy.Prop1 = 42;
        }

        [Fact]
        public void Property_InInterfaceTest()
        {
            XAssert.Throws<ComparisonAssertException>(() =>
                                                Proxy.Prop1 = 12);
            XAssert.Throws<ComparisonAssertException>(() =>
                                                Proxy.Prop1 = 5);
            Proxy.Prop1 = 42;
        }

        [Fact]
        public void PropertyTypeNotGoodTest()
        {
            XAssert.Throws<AttributeAssertException>(() =>
                                                Proxy.Func6("test"));
            XAssert.False(Proxy.FuncCalled);
        }

        [Fact]
        public void PropertyUnknownTest()
        {
            XAssert.Throws<AttributeAssertException>(() =>
                                                Proxy.Func7(5));
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
            point.X = 12;
            XAssert.Throws<ComparisonAssertException>(() =>
                                                Proxy.Func3(point));
            XAssert.False(Proxy.FuncCalled);

            point.X = 5;
            XAssert.Throws<ComparisonAssertException>(() =>
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
            point.X = 12;
            XAssert.Throws<ComparisonAssertException>(() =>
                                                Proxy.Func3(point));
            XAssert.False(Proxy.FuncCalled);

            point.X = 5;
            XAssert.Throws<ComparisonAssertException>(() =>
                                                Proxy.Func3(point));
            XAssert.False(Proxy.FuncCalled);

            point.X = 42;
            Proxy.Func3(point);
            XAssert.True(Proxy.FuncCalled);
        }

        public interface ITest
        {
            bool FuncCalled { get; }

            [GreaterThan(12)]
            int Prop1 { get; set; }

            int Prop2 { get; set; }

            void Func1([GreaterThan(12)]int value);

            [GreaterThan(12, "value")]
            void Func2(int value);

            [GreaterThan(12, "value.X")]
            void Func3(Point value);

            void Func4([GreaterThan(12, "value.X")]Point value);

            [GreaterThan(12, "value.ZZZ")]
            void Func5(Point value);

            [GreaterThan(12, "value")]
            void Func6(string value);

            [GreaterThan(12, "ZZZ")]
            void Func7(int value);

            [GreaterThan(12, "value", AllowEquality = true)]
            void Func8(int value);
        }

        public class TestCl : ITest
        {
            public bool FuncCalled { get; set; }

            public int Prop1 { get; set; }

            [GreaterThan(12)]
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

            public void Func8(int value)
            {
                FuncCalled = true;
            }
        }
    }
}
