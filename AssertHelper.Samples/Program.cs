using AssertHelper.Samples.Examples;
using System;

namespace AssertHelper.Samples
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\n\n*************\n" +
                                "start example of helper : ");
            HelperExample.Example();

            Console.WriteLine("\n\n*************\n" +
                                "start example of attribute : ");

            AttributeExample.Example();

            Console.WriteLine("\n\n*************\n" +
                    "start example of attribute performance : ");

            AttributePerformanceExample.Example();

            Console.WriteLine("\n\n*************\n" +
                    "start example of try performance : ");

            TryPerformanceExample.Example();

            Console.ReadLine();
        }
    }
}
