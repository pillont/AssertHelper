using AssertHelper.Attributes;
using AssertHelper.CastleInterceptors;
using AssertHelper.Exceptions;

using System;
using System.Diagnostics;

namespace AssertHelper.Samples.Examples
{
    public class AttributePerformanceExample
    {
        public static void Example()
        {
            var classic = new ClassicInterface();
            var watch = new Stopwatch();
            watch.Start();

            classic.Funct1(3);
            classic.Funct1(5);
            classic.Funct2(8);
            classic.Prop = true;
            try
            {
                classic.Funct2(18);
            }
            catch { Console.WriteLine("catch fail assert"); }

            watch.Stop();
            Console.WriteLine($"Take : {watch.ElapsedMilliseconds}ms\n");

            var implementation = new TestInterface();
            var proxy = AssertProxyFactory.CreateForInterface<ITestInterface>(implementation);

            watch = new Stopwatch();
            watch.Start();

            proxy.Funct1(3);
            proxy.Funct1(5);
            proxy.Funct2(8);
            proxy.Prop = true;
            try
            {
                proxy.Funct2(18);
            }
            catch { Console.WriteLine("catch fail assert"); }

            watch.Stop();
            Console.WriteLine($"Take : {watch.ElapsedMilliseconds}ms");

            /* result :
                start example of attribute performance :
                function1 logic with 3
                function1 logic with 5
                function2 logic with 8
                Prop is set with True
                catch fail assert
                Take : 12ms

                function1 logic with 3
                function1 logic with 5
                function2 logic with 8
                Prop is set with True
                catch fail assert
                Take : 23ms
            */
        }

        public interface ITestInterface
        {
            [NotNull]
            object Prop { get; set; }

            void Funct1(int value);

            void Funct2([LessThan(10)]int value);
        }

        public class ClassicInterface : ITestInterface
        {
            private object _prop;

            public object Prop
            {
                get { return _prop; }
                set
                {
                    if (value == null)
                        throw new NullAssertException();

                    Console.WriteLine($"Prop is set with {value}");
                    _prop = value;
                }
            }

            [GreaterThan(3, AllowEquality = true, ParameterName = "value2")]
            public void Funct1(int value2)
            {
                if (value2 < 3)
                    throw new ComparisonAssertException();

                Console.WriteLine($"function1 logic with {value2}");
            }

            public void Funct2([LessThan(10)] int value)
            {
                if (value >= 10)
                    throw new ComparisonAssertException();

                Console.WriteLine($"function2 logic with {value}");
            }
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
