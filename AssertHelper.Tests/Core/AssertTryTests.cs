using System.Collections.Generic;
using System.Drawing;
using Xunit;
using XAssert = Xunit.Assert;
using AssertStandard = AssertHelper.Assert;

namespace AssertHelper.Tests.Core
{
    public class AssertTryTests : IClassFixture<AssertFixture>
    {
        public AssertTryTests()
        { }

        [Fact]
        public void TryDefaultTest()
        {
            XAssert.True(
                    AssertStandard.TryDefault((Point?)null, "param"));
            XAssert.True(
                    AssertStandard.TryDefault(new Point(), "param"));
            XAssert.False(
                    AssertStandard.TryDefault(new Point(12, 12), "param"));
        }

        [Fact]
        public void TryEmptyTest()
        {
            XAssert.True(
                    AssertStandard.TryEmpty(null, "param"));
            XAssert.True(
                    AssertStandard.TryEmpty(new List<int>(), "param"));
            XAssert.False(
                    AssertStandard.TryEmpty(new List<int>() { 12, 12 }, "param"));
        }

        [Fact]
        public void TryFalseOnActionTest()
        {
            XAssert.False(
                    AssertStandard.TryFalse("12" != "13", "param"));

            XAssert.True(
                    AssertStandard.TryFalse("12" != "12", "param"));
        }

        [Fact]
        public void TryFalseTest()
        {
            XAssert.False(
                    AssertStandard.TryFalse(true, "param"));

            XAssert.True(
                    AssertStandard.TryFalse(false, "param"));
        }

        [Fact]
        public void TryGreaterThanTest()
        {
            XAssert.True(
                    AssertStandard.TryGreaterThan(13, 12, "param"));
            XAssert.False(
                    AssertStandard.TryGreaterThan(12, 13, "param"));
        }

        [Fact]
        public void TryLessThanTest()
        {
            XAssert.True(
                    AssertStandard.TryLessThan(12, 13, "param"));
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
            XAssert.True(
                    AssertStandard.TryNotDefault(new Point(12, 12), "param"));
        }

        [Fact]
        public void TryNotEmptyTest()
        {
            XAssert.False(
                    AssertStandard.TryNotEmpty(null, "param"));
            XAssert.False(
                    AssertStandard.TryNotEmpty(new List<int>(), "param"));
            XAssert.True(
                    AssertStandard.TryNotEmpty(new List<int>() { 12, 12 }, "param"));
        }

        public void TryNotNullOrEmptyTest()
        {
            XAssert.True(
                    AssertStandard.TryNotNullOrEmpty("test", "param"));
            XAssert.False(
                            AssertStandard.TryNotNullOrEmpty(null, "param"));
            XAssert.False(
                            AssertStandard.TryNotNullOrEmpty("", "param"));
        }

        [Fact]
        public void TryNotNullOrWhiteSpaceTest()
        {
            XAssert.True(
                    AssertStandard.TryNotNullOrWhiteSpace("test", "param"));
            XAssert.False(
                            AssertStandard.TryNotNullOrWhiteSpace(null, "param"));
            XAssert.False(
                            AssertStandard.TryNotNullOrWhiteSpace("", "param"));
            XAssert.False(
                            AssertStandard.TryNotNullOrWhiteSpace(" ", "param"));
        }

        [Fact]
        public void TryNotNullTest()
        {
            XAssert.False(
                    AssertStandard.TryNotNull(null, "param"));
            XAssert.True(
            AssertStandard.TryNotNull(new Point(), "param"));
            XAssert.True(
            AssertStandard.TryNotNull(new Point(12, 12), "param"));
        }

        [Fact]
        public void TryNullTest()
        {
            XAssert.True(
                    AssertStandard.TryNull(null, "param"));
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

            XAssert.True(
                    AssertStandard.TryTrue("12" == "12", "param"));
        }

        [Fact]
        public void TryTrueTest()
        {
            XAssert.False(
                    AssertStandard.TryTrue(false, "param"));

            XAssert.True(
                    AssertStandard.TryTrue(true, "param"));
        }
    }
}
