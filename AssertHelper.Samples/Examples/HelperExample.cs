using System;

namespace AssertHelper.Samples.Examples
{
    internal class HelperExample
    {
        public static void Example()
        {
            Console.WriteLine("Set up environment setting");
            Assert.TryMustDebug = true;

            Console.WriteLine("Start try issue");
            TryAssertFunc(null);

            try
            {
                Console.WriteLine("Start sample issue");
                AssertFunc(null);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ouf.. we think to the catch ! Message is : {e.Message}");
            }

            /* result :
                Set up environment setting
                Start try issue
                [Debug popup if 'TryMustDebug' is true]
                Assert Fail !! Not a problem : there is secure issue
                Start sample issue
                Ouf.. we think to the catch ! Message is : Assert will fail, warning to the exception !!!!
            */
        }

        private static void AssertFunc(object parameter)
        {
            Assert.NotNull(parameter, nameof(parameter),
                    message: "Assert will fail, warning to the exception !!!!");

            Console.WriteLine("Real try function never done !");
        }

        private static void TryAssertFunc(object parameter)
        {
            var parameterIsNull = !Assert.TryNotNull(parameter, nameof(parameter),
                                    message: "Assert will fail");
            if (parameterIsNull)
            {
                Console.WriteLine("Assert Fail !! Not a problem : there is secure issue");
                return;
            }

            Console.WriteLine("Real try function never done !");
        }
    }
}
