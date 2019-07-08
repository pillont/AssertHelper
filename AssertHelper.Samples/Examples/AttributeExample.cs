using AssertHelper.Attributes;
using AssertHelper.CastleInterceptors;
using AssertHelper.Exceptions;
using System;

namespace AssertHelper.Samples.Examples
{
    public class AttributeExample
    {
        public static void Example()
        {
            var implementation = new TestInterface();
            var proxy = AssertProxyFactory.CreateForInterface<ITestInterface>(implementation);

            try
            {
                proxy.Prop = null;
                Console.WriteLine("Not a problem to set null Prop");
            }
            catch (NullAssertException)
            { Console.WriteLine("Prop can not be null"); }

            try
            {
                proxy.Funct1(2);
                Console.WriteLine("Not a problem to set less than 3");
            }
            catch (ComparisonAssertException)
            { Console.WriteLine("arg of func1 can not be less than 3"); }

            try
            {
                proxy.Funct2(12);
                Console.WriteLine("Not a problem to set greater than 10");
            }
            catch (ComparisonAssertException)
            { Console.WriteLine("arg of func2 can not be greater than 10"); }

            proxy.Prop = true;
            Console.WriteLine("Prop can have not null value");

            proxy.Funct1(3);
            Console.WriteLine("arg of func1 can be equal to 3 because 'AllowEquality =true' in attribute");

            proxy.Funct1(3);
            Console.WriteLine("arg of func1 can be greater than 3");

            proxy.Funct2(9);
            Console.WriteLine("arg of func2 can be less than 10");

            /* result :
                Prop can not be null
                arg of func1 can not be less than 3
                arg of func2 can not be greater than 10
                Prop is set with True
                Prop can have not null value
                function1 logic with 3
                arg of func1 can be equal to 3 because 'AllowEquality =true' in attribute
                function1 logic with 3
                arg of func1 can be greater than 3
                function2 logic with 9
                arg of func2 can be less than 10
            */
        }

        public interface ITestInterface
        {
            [NotNull]
            object Prop { get; set; }

            void Funct1(int value);

            void Funct2([LessThan(10)]int value);
        }

        public class TestInterface : ITestInterface
        {
            private object _prop;

            public object Prop
            {
                get { return _prop; }
                set
                {
                    Console.WriteLine($"Prop is set with {value}");
                    _prop = value;
                }
            }

            [GreaterThan(3, AllowEquality = true, ParameterName = "value2")]
            public void Funct1(int value2)
            {
                Console.WriteLine($"function1 logic with {value2}");
            }

            public void Funct2([LessThan(10, false)] int value)
            {
                Console.WriteLine($"function2 logic with {value}");
            }
        }
    }
}
