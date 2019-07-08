using System.Collections.Generic;
using System.Drawing;
using Xunit;
using XAssert = Xunit.Assert;
using AssertStandard = AssertHelper.Assert;

namespace AssertHelper.Tests.Core
{
    public class AssertTryTests : IClassFixture<AssertFixture>
    {
        public AssertTryTests(AssertFixture fixture)
        { }

        [Fact]
        public void TryDefaultTest()
        {
            AssertStandard.TryDefault((Point?)null, "param");
            AssertStandard.TryDefault(new Point(), "param");
            XAssert.False(
                    AssertStandard.TryDefault(new Point(12, 12), "param"));
        }

        [Fact]
        public void TryEmptyTest()
        {
            AssertStandard.TryEmpty(null, "param");
            AssertStandard.TryEmpty(new List<int>(), "param");
            XAssert.False(
                    AssertStandard.TryEmpty(new List<int>() { 12, 12 }, "param"));
        }

        [Fact]
        public void TryFalseOnActionTest()
        {
            XAssert.False(
                    AssertStandard.TryFalse("12" != "13", "param"));

            AssertStandard.TryFalse("12" != "12", "param");
        }

        [Fact]
        public void TryFalseTest()
        {
            XAssert.False(
                    AssertStandard.TryFalse(true, "param"));

            AssertStandard.TryFalse(false, "param");
        }

        [Fact]
        public void TryGreaterThanTest()
        {
            AssertStandard.TryGreaterThan(13, 12, "param");
            XAssert.False(
                    AssertStandard.TryGreaterThan(12, 13, "param"));
        }

        [Fact]
        public void TryLessThanTest()
        {
            AssertStandard.TryLessThan(12, 13, "param");
            XAssert.False(
                    AssertStandard.TryLessThan(13, 12, "param"));
        }

        [Fact]
        public void TryNotDefaultTest()
        {
            XAssert.False(
                    AssertStandard.TryNotDefault((Point?)null, "param"));
            XAssert.False(
                    AssertStandard.TryNotDefault(new Point(), "param"));
            AssertStandard.TryNotDefault(new Point(12, 12), "param");
        }

        [Fact]
        public void TryNotEmptyTest()
        {
            XAssert.False(
                    AssertStandard.TryNotEmpty(null, "param"));
            XAssert.False(
                    AssertStandard.TryNotEmpty(new List<int>(), "param"));
            AssertStandard.TryNotEmpty(new List<int>() { 12, 12 }, "param");
        }

        [Fact]
        public void TryNotNullTest()
        {
            XAssert.False(
                    AssertStandard.TryNotNull(null, "param"));
            AssertStandard.TryNotNull(new Point(), "param");
            AssertStandard.TryNotNull(new Point(12, 12), "param");
        }

        [Fact]
        public void TryNullTest()
        {
            AssertStandard.TryNull(null, "param");
            XAssert.False(
                    AssertStandard.TryNull(new Point(), "param"));
            XAssert.False(
                    AssertStandard.TryNull(new Point(12, 12), "param"));
        }

        [Fact]
        public void TryTrueOnActionTest()
        {
            XAssert.False(
                    AssertStandard.TryTrue("12" == "13", "param"));

            AssertStandard.TryTrue("12" == "12", "param");
        }

        [Fact]
        public void TryTrueTest()
        {
            XAssert.False(
                    AssertStandard.TryTrue(false, "param"));

            AssertStandard.TryTrue(true, "param");
        }
    }
}
