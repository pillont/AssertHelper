using System;

namespace AssertHelper.Tests
{
    /// <summary>
    /// SEE : https://xunit.net/docs/shared-context
    /// </summary>
    /// <example>
    ///
    ///   public class ClassTests : IClassFixture<AssertFixture>
    ///   {
    ///      public AssertTryTests(AssertFixture fixture)
    ///      { }
    ///   }
    ///
    /// </example>
    public class AssertFixture : IDisposable
    {
        public AssertFixture()
        {
            Assert.TryMustDebug = false;
            // HERE : initialize
        }

        public void Dispose()
        {
            // HERE : clean up test data from the database
        }
    }
}
