using AssertHelper.Attributes;
using AssertHelper.Exceptions;
using AssertHelper.ReflectionProxies;
using System;
using System.Drawing;
using Xunit;
using XAssert = Xunit.Assert;

namespace AssertHelper.Tests.Attributes
{
    public class NotNullAttributeTests
    {
        public TestCl Implem { get; }

        public ITest Proxy { get; }

        [Obsolete]
        public NotNullAttributeTests()
        {
            Implem = new TestCl();
            Proxy = AssertProxyFactory.Create<ITest>(Implem);
        }

        [Fact]
        public void InterfaceMethodAttributeTest()
        {
            XAssert.Throws<NullAssertException>(() =>
                                                Proxy.Func2(null));
            XAssert.False(Proxy.FuncCalled);

            Proxy.Func2(5);
            XAssert.True(Proxy.FuncCalled);
        }

        [Fact]
        public void InterfaceParameterAttributeTest()
        {
            XAssert.Throws<NullAssertException>(() =>
                                                Proxy.Func1(null));
            XAssert.False(Proxy.FuncCalled);

            Proxy.Func1(5);
            XAssert.True(Proxy.FuncCalled);
        }

        [Fact]
        public void Property_InClassTest()
        {
            XAssert.Throws<DefaultAssertException>(() =>
                                                Proxy.Prop2 = null);
            Proxy.Prop2 = 5;
        }

        [Fact]
        public void Property_InInterfaceTest()
        {
            XAssert.Throws<DefaultAssertException>(() =>
                                                Proxy.Prop1 = null);
            Proxy.Prop1 = 5;
        }

        [Fact]
        public void PropertyUnknownTest()
        {
            XAssert.Throws<AttributeAssertException>(() =>
                                                Proxy.Func7(null));
            XAssert.False(Proxy.FuncCalled);
        }

        [Fact]
        public void SubPropertyUnknownTest()
        {
            var obj = new Point();
            XAssert.Throws<AttributeAssertException>(() =>
                                                Proxy.Func5(obj));
            XAssert.False(Proxy.FuncCalled);
        }

        [Fact]
        public void SubPropInMethodAttributeTest()
        {
            XAssert.Throws<NullAssertException>(() =>
                                                Proxy.Func3(null));

            var obj = new FakeObject();
            XAssert.Throws<NullAssertException>(() =>
                                                Proxy.Func3(obj));
            XAssert.False(Proxy.FuncCalled);

            obj.Test = "test";
            Proxy.Func3(obj);
            XAssert.True(Proxy.FuncCalled);
        }

        [Fact]
        public void SubPropInParamAttributeTest()
        {
            XAssert.Throws<NullAssertException>(() =>
                                                Proxy.Func8(null));
            var obj = new FakeObject();
            XAssert.Throws<NullAssertException>(() =>
                                                Proxy.Func8(obj));
            XAssert.False(Proxy.FuncCalled);

            obj.Test = "test";
            Proxy.Func8(obj);
            XAssert.True(Proxy.FuncCalled);
        }

        public interface ITest
        {
            bool FuncCalled { get; }

            [NotDefault()]
            int? Prop1 { get; set; }

            int? Prop2 { get; set; }

            void Func1([NotNull]int? value);

            [NotNull(ParameterName = "value")]
            void Func2(int? value);

            [NotNull(ParameterName = "value.Test")]
            void Func3(FakeObject value);

            [NotNull(ParameterName = "value.ZZZ")]
            void Func5(Point? value);

            [NotNull(ParameterName = "value")]
            void Func6(string value);

            [NotNull(ParameterName = "ZZZ")]
            void Func7(int? value);

            void Func8([NotNull(ParameterName = "value.Test")]FakeObject value);
        }

        public class FakeObject { public string Test { get; set; } }

        public class TestCl : ITest
        {
            public bool FuncCalled { get; set; }
            public int? Prop1 { get; set; }

            [NotDefault]
            public int? Prop2 { get; set; }

            public void Func1(int? value)
            {
                FuncCalled = true;
            }

            public void Func2(int? value)
            {
                FuncCalled = true;
            }

            public void Func3(FakeObject value)
            {
                FuncCalled = true;
            }

            public void Func4(Point? value)
            {
                FuncCalled = true;
            }

            public void Func5(Point? value)
            {
                FuncCalled = true;
            }

            public void Func6(string value)
            {
                FuncCalled = true;
            }

            public void Func7(int? value)
            {
                FuncCalled = true;
            }

            public void Func8(FakeObject value)
            {
                FuncCalled = true;
            }
        }
    }
}
