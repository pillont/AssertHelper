using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace AssertHelper.Samples.Examples
{
    public class TryPerformanceExample
    {
        public static void Example()
        {
            Assert.TryMustDebug = false;

            TryFailExample();
            Console.WriteLine();
            TrySuccessExample();
        }

        internal static void TryFailExample()
        {
            var watch = new Stopwatch();
            watch.Start();

            Console.WriteLine("classic func 1 fail");
            FuncClassic1(null);
            Console.WriteLine("classic func 2 fail");
            FuncClassic2(new Collection<int>());
            Console.WriteLine("classic func 3 fail");
            FuncClassic3(12);

            watch.Stop();
            Console.WriteLine($"Take : {watch.ElapsedMilliseconds}ms\n");

            watch = new Stopwatch();
            watch.Start();

            Console.WriteLine("try func 1 fail");
            FuncTry1(null);
            Console.WriteLine("try func 2 fail");
            FuncTry2(new Collection<int>());
            Console.WriteLine("try func 3 fail");
            FuncTry3(12);

            watch.Stop();
            Console.WriteLine($"Take : {watch.ElapsedMilliseconds}ms\n");

            /* result :
                classic func 1 fail
                classic func 2 fail
                classic func 3 fail
                Take : 4ms

                try func 1 fail
                try func 2 fail
                try func 3 fail
                Take : 45ms
             */
        }

        internal static void TrySuccessExample()
        {
            var watch = new Stopwatch();
            watch.Start();

            Console.WriteLine("classic func 1 success");
            FuncClassic1(true);
            Console.WriteLine("classic func 2 success");
            FuncClassic2(new Collection<int>() { 1 });
            Console.WriteLine("classic func 3 success");
            FuncClassic3(5);

            watch.Stop();
            Console.WriteLine($"Take : {watch.ElapsedMilliseconds}ms\n");

            watch = new Stopwatch();
            watch.Start();

            Console.WriteLine("try func 1 success");
            FuncTry1(true);
            Console.WriteLine("try func 2 success");
            FuncTry2(new Collection<int>() { 1 });
            Console.WriteLine("try func 3 success");
            FuncTry3(5);

            watch.Stop();
            Console.WriteLine($"Take : {watch.ElapsedMilliseconds}ms\n");

            /* result :
                classic func 1 success
                func1 process
                classic func 2 success
                func2 process
                classic func 3 success
                func3 process
                Take : 6ms

                try func 1 success
                func1 process
                try func 2 success
                func2 process
                try func 3 success
                func3 process
                Take : 2ms
            */
        }

        private static void FuncClassic1(object p)
        {
            bool isNull = p == null;
            if (isNull)
                return;

            Console.WriteLine("func1 process");
        }

        private static void FuncClassic2(IEnumerable<int> p)
        {
            bool isEmpty = !p.Any();
            if (isEmpty)
                return;

            Console.WriteLine("func2 process");
        }

        private static void FuncClassic3(int value)
        {
            bool isNotLessThanTen = value > 10;
            if (isNotLessThanTen)
                return;

            Console.WriteLine("func3 process");
        }

        private static void FuncTry1(object p)
        {
            bool isNull = !Assert.TryNotNull(p, nameof(p));
            if (isNull)
                return;

            Console.WriteLine("func1 process");
        }

        private static void FuncTry2(IEnumerable<int> p)
        {
            bool isEmpty = !Assert.TryNotEmpty(p, nameof(p));
            if (isEmpty)
                return;

            Console.WriteLine("func2 process");
        }

        private static void FuncTry3(int value)
        {
            bool isNotLessThanTen = !Assert.TryLessThan(value, 10, nameof(value));
            if (isNotLessThanTen)
                return;

            Console.WriteLine("func3 process");
        }
    }
}
