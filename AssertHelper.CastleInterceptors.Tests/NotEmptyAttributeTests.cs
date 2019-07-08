using AssertHelper.Attributes;
using AssertHelper.CastleInterceptors;
using AssertHelper.Exceptions;
using System.Collections.Generic;
using System.Drawing;
using Xunit;
using XAssert = Xunit.Assert;

namespace AssertHelper.Tests.Attributes
{
    public class NotEmptyAttributeTests
    {
        public TestCl Implem { get; }

        public ITest Proxy { get; }

        public NotEmptyAttributeTests()
        {
            Implem = new TestCl();
            Proxy = AssertProxyFactory.CreateForInterface<ITest>(Implem);
        }

        [Fact]
        public void InterfaceMethodAttributeTest()
        {
            XAssert.Throws<EmptyAssertException>(() =>
                                                Proxy.Func2(null));
            XAssert.False(Proxy.FuncCalled);

            XAssert.Throws<EmptyAssertException>(() =>
                                    Proxy.Func2(new List<int>()));
            XAssert.False(Proxy.FuncCalled);

            Proxy.Func2(new List<int>() { 5 });
            XAssert.True(Proxy.FuncCalled);
        }

        [Fact]
        public void InterfaceParameterAttributeTest()
        {
            XAssert.Throws<EmptyAssertException>(() =>
                                                Proxy.Func1(null));
            XAssert.False(Proxy.FuncCalled);

            XAssert.Throws<EmptyAssertException>(() =>
                                    Proxy.Func1(new List<int>()));
            XAssert.False(Proxy.FuncCalled);

            Proxy.Func1(new List<int>() { 5 });
            XAssert.True(Proxy.FuncCalled);
        }

        [Fact]
        public void NotEnumerableInPropertyTest()
        {
            XAssert.Throws<AttributeAssertException>(() =>
                                                Proxy.Prop3 = new Point());
        }

        [Fact]
        public void NotEnumerableSubPropertyInMethodTest()
        {
            XAssert.Throws<EmptyAssertException>(() =>
                                                Proxy.Func8(new FakeObject()));
        }

        [Fact]
        public void NotEnumerableSubPropertyInParameterTest()
        {
            XAssert.Throws<AttributeAssertException>(() =>
                                                Proxy.Func9(new FakeObject()));
        }

        [Fact]
        public void Property_InClassTest()
        {
            XAssert.Throws<EmptyAssertException>(() =>
                                                Proxy.Prop2 = null);
            XAssert.False(Proxy.FuncCalled);

            XAssert.Throws<EmptyAssertException>(() =>
                                    Proxy.Prop2 = new List<int>());
            XAssert.False(Proxy.FuncCalled);

            Proxy.Prop2 = new List<int>() { 5 };
        }

        [Fact]
        public void Property_InInterfaceTest()
        {
            XAssert.Throws<EmptyAssertException>(() =>
                                                Proxy.Prop1 = null);
            XAssert.False(Proxy.FuncCalled);

            XAssert.Throws<EmptyAssertException>(() =>
                                    Proxy.Prop1 = new List<int>());
            XAssert.False(Proxy.FuncCalled);

            Proxy.Prop1 = new List<int>() { 5 };
        }

        [Fact]
        public void PropertyUnknownTest()
        {
            XAssert.Throws<AttributeAssertException>(() =>
                                                Proxy.Func7(null));
            XAssert.False(Proxy.FuncCalled);

            XAssert.Throws<AttributeAssertException>(() =>
                                    Proxy.Func7(new List<int>()));
            XAssert.False(Proxy.FuncCalled);

            XAssert.Throws<AttributeAssertException>(() =>
                                Proxy.Func7(new List<int>() { 5 }));
            XAssert.False(Proxy.FuncCalled);
        }

        [Fact]
        public void SubPropertyUnknownTest()
        {
            XAssert.Throws<NullAssertException>(() =>
                                                        Proxy.Func5(null));
            XAssert.False(Proxy.FuncCalled);

            XAssert.Throws<AttributeAssertException>(() =>
                                    Proxy.Func5(new FakeObject() { Test = new List<int>() }));
            XAssert.False(Proxy.FuncCalled);

            XAssert.Throws<AttributeAssertException>(() =>
                                    Proxy.Func5(new FakeObject() { Test = new List<int>() { 5 } }));
            XAssert.False(Proxy.FuncCalled);
        }

        [Fact]
        public void SubPropInMethodAttributeTest()
        {
            XAssert.Throws<NullAssertException>(() =>
                                                Proxy.Func3(null));
            XAssert.False(Proxy.FuncCalled);

            XAssert.Throws<EmptyAssertException>(() =>
                                    Proxy.Func3(new FakeObject() { Test = new List<int>() }));
            XAssert.False(Proxy.FuncCalled);

            Proxy.Func3(new FakeObject() { Test = new List<int>() { 5 } });
            XAssert.True(Proxy.FuncCalled);
        }

        [Fact]
        public void SubPropInParamAttributeTest()
        {
            XAssert.Throws<NullAssertException>(() =>
                                                Proxy.Func8(null));
            XAssert.False(Proxy.FuncCalled);

            XAssert.Throws<EmptyAssertException>(() =>
                                    Proxy.Func8(new FakeObject() { Test = new List<int>() }));
            XAssert.False(Proxy.FuncCalled);

            Proxy.Func8(new FakeObject() { Test = new List<int>() { 5 } });
            XAssert.True(Proxy.FuncCalled);
        }

        public interface ITest
        {
            bool FuncCalled { get; }

            [NotEmpty()]
            List<int> Prop1 { get; set; }

            List<int> Prop2 { get; set; }

            [NotEmpty]
            Point Prop3 { get; set; }

            void Func1([NotEmpty]List<int> value);

            [NotEmpty(ParameterName = "value")]
            void Func10(Point value);

            [NotEmpty(ParameterName = "value")]
            void Func2(List<int> value);

            [NotEmpty(ParameterName = "value.Test")]
            void Func3(FakeObject value);

            [NotEmpty(ParameterName = "value.ZZZ")]
            void Func5(FakeObject value);

            [NotEmpty(ParameterName = "value")]
            void Func6(List<int> value);

            [NotEmpty(ParameterName = "ZZZ")]
            void Func7(List<int> value);

            void Func8([NotEmpty(ParameterName = "value.Test")]FakeObject value);

            void Func9([NotEmpty(ParameterName = "value.Test2")]FakeObject value);
        }

        public class FakeObject
        {
            public List<int> Test { get; set; }
            public Point Test2 { get; set; }
        }

        public class TestCl : ITest
        {
            public bool FuncCalled { get; set; }
            public List<int> Prop1 { get; set; }

            [NotEmpty]
            public List<int> Prop2 { get; set; }

            public Point Prop3 { get; set; }

            public void Func1(List<int> value)
            {
                FuncCalled = true;
            }

            public void Func10(Point value)
            {
                FuncCalled = true;
            }

            public void Func2(List<int> value)
            {
                FuncCalled = true;
            }

            public void Func3(FakeObject value)
            {
                FuncCalled = true;
            }

            public void Func4(FakeObject value)
            {
                FuncCalled = true;
            }

            public void Func5(FakeObject value)
            {
                FuncCalled = true;
            }

            public void Func6(List<int> value)
            {
                FuncCalled = true;
            }

            public void Func7(List<int> value)
            {
                FuncCalled = true;
            }

            public void Func8(FakeObject value)
            {
                FuncCalled = true;
            }

            public void Func9(FakeObject value)
            {
                FuncCalled = true;
            }
        }
    }
}
