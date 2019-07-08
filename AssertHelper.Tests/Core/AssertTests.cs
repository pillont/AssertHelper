using AssertHelper.Exceptions;
using System.Collections.Generic;
using System.Drawing;
using Xunit;
using AssertStandard = AssertHelper.Assert;
using XAssert = Xunit.Assert;

namespace AssertHelper.Tests.Core
{
    public class AssertTests
    {
        [Fact]
        public void DefaultTest()
        {
            AssertStandard.Default((Point?)null, "param");
            AssertStandard.Default(new Point(), "param");
            XAssert.Throws<DefaultAssertException>(() =>
                    AssertStandard.Default(new Point(12, 12), "param"));
        }

        [Fact]
        public void EmptyTest()
        {
            AssertStandard.Empty(null, "param");
            AssertStandard.Empty(new List<int>(), "param");
            XAssert.Throws<EmptyAssertException>(() =>
                    AssertStandard.Empty(new List<int>() { 12, 12 }, "param"));
        }

        [Fact]
        public void FalseOnActionTest()
        {
            XAssert.Throws<BooleanAssertException>(() =>
                    AssertStandard.False("12" != "13", "param"));

            AssertStandard.False("12" != "12", "param");
        }

        [Fact]
        public void FalseTest()
        {
            XAssert.Throws<BooleanAssertException>(() =>
                    AssertStandard.False(true, "param"));

            AssertStandard.False(false, "param");
        }

        [Fact]
        public void GreaterThan_EqualityTest()
        {
            AssertStandard.GreaterThan(13, 12, "param", allowEquality: true);
            AssertStandard.GreaterThan(12, 12, "param", allowEquality: true);
            XAssert.Throws<ComparisonAssertException>(() =>
                    AssertStandard.GreaterThan(12, 13, "param", allowEquality: true));
        }

        [Fact]
        public void GreaterThanTest()
        {
            AssertStandard.GreaterThan(13, 12, "param");
            XAssert.Throws<ComparisonAssertException>(() =>
                                AssertStandard.GreaterThan(12, 12, "param"));
            XAssert.Throws<ComparisonAssertException>(() =>
                                    AssertStandard.GreaterThan(12, 13, "param"));
        }

        [Fact]
        public void LessThan_EqualityTest()
        {
            AssertStandard.LessThan(12, 13, "param", allowEquality: true);
            AssertStandard.LessThan(12, 12, "param", allowEquality: true);
            XAssert.Throws<ComparisonAssertException>(() =>
                                    AssertStandard.LessThan(13, 12, "param", allowEquality: true));
        }

        [Fact]
        public void LessThanTest()
        {
            AssertStandard.LessThan(12, 13, "param");
            XAssert.Throws<ComparisonAssertException>(() =>
                                AssertStandard.LessThan(12, 12, "param"));
            XAssert.Throws<ComparisonAssertException>(() =>
                                    AssertStandard.LessThan(13, 12, "param"));
        }

        [Fact]
        public void NotDefaultTest()
        {
            XAssert.Throws<DefaultAssertException>(() =>
                    AssertStandard.NotDefault((Point?)null, "param"));
            XAssert.Throws<DefaultAssertException>(() =>
                    AssertStandard.NotDefault(new Point(), "param"));
            AssertStandard.NotDefault(new Point(12, 12), "param");
        }

        [Fact]
        public void NotEmptyTest()
        {
            XAssert.Throws<EmptyAssertException>(() =>
                    AssertStandard.NotEmpty(null, "param"));
            XAssert.Throws<EmptyAssertException>(() =>
                    AssertStandard.NotEmpty(new List<int>(), "param"));
            AssertStandard.NotEmpty(new List<int>() { 12, 12 }, "param");
        }

        [Fact]
        public void NotNullTest()
        {
            XAssert.Throws<NullAssertException>(() =>
                    AssertStandard.NotNull(null, "param"));
            AssertStandard.NotNull(new Point(), "param");
            AssertStandard.NotNull(new Point(12, 12), "param");
        }

        [Fact]
        public void NullTest()
        {
            AssertStandard.Null(null, "param");
            XAssert.Throws<NullAssertException>(() =>
                    AssertStandard.Null(new Point(), "param"));
            XAssert.Throws<NullAssertException>(() =>
                    AssertStandard.Null(new Point(12, 12), "param"));
        }

        [Fact]
        public void TrueOnActionTest()
        {
            XAssert.Throws<BooleanAssertException>(() =>
                    AssertStandard.True("12" == "13", "param"));

            AssertStandard.True("12" == "12", "param");
        }

        [Fact]
        public void TrueTest()
        {
            XAssert.Throws<BooleanAssertException>(() =>
                    AssertStandard.True(false, "param"));

            AssertStandard.True(true, "param");
        }
    }
}
