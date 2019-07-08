using AssertHelper.Exceptions;
using System;
using System.Collections.Generic;
using System.Drawing;
using Xunit;
using AssertStandard = AssertHelper.Assert;
using XAssert = Xunit.Assert;

namespace AssertHelper.Tests.Core
{
    public class AssertGenericTest
    {
        /// <summary>
        /// if exception not contains sample ctor => throw exception
        /// </summary>
        [Fact]
        public void ComplexeExceptionTest()
        {
            XAssert.Throws<AssertException>(() =>
                    AssertStandard.NotEmpty<ComplexeException>(null, "param"));
        }

        [Fact]
        public void DefaultTest()
        {
            AssertStandard.Default<ArgumentException, Point?>(null, "param");
            AssertStandard.Default<ArgumentException, Point>(new Point(), "param");
            XAssert.Throws<ArgumentException>(() =>
                    AssertStandard.Default<ArgumentException, Point?>(new Point(12, 12), "param"));
        }

        [Fact]
        public void EmptyTest()
        {
            AssertStandard.Empty<ArgumentException>(null, "param");
            AssertStandard.Empty<ArgumentException>(new List<int>(), "param");
            XAssert.Throws<ArgumentException>(() =>
                    AssertStandard.Empty<ArgumentException>(new List<int>() { 12, 12 }, "param"));
        }

        [Fact]
        public void FalseOnActionTest()
        {
            XAssert.Throws<ArgumentException>(() =>
                    AssertStandard.False<ArgumentException>("12" != "13", "param"));

            AssertStandard.False<ArgumentException>("12" != "12", "param");
        }

        [Fact]
        public void FalseTest()
        {
            XAssert.Throws<ArgumentException>(() =>
                    AssertStandard.False<ArgumentException>(true, "param"));

            AssertStandard.False<ArgumentException>(false, "param");
        }

        [Fact]
        public void GreaterThanTest()
        {
            AssertStandard.GreaterThan<ArgumentException>(13, 12, "param");
            XAssert.Throws<ArgumentException>(() =>
                    AssertStandard.GreaterThan<ArgumentException>(12, 13, "param"));
        }

        [Fact]
        public void LessThanTest()
        {
            AssertStandard.LessThan<ArgumentException>(12, 13, "param");
            XAssert.Throws<ArgumentException>(() =>
                    AssertStandard.LessThan<ArgumentException>(13, 12, "param"));
        }

        [Fact]
        public void NotDefaultTest()
        {
            XAssert.Throws<ArgumentException>(() =>
                    AssertStandard.NotDefault<ArgumentException>((Point?)null, "param"));
            XAssert.Throws<ArgumentException>(() =>
                    AssertStandard.NotDefault<ArgumentException>(new Point(), "param"));
            AssertStandard.NotDefault<ArgumentException>(new Point(12, 12), "param");
        }

        [Fact]
        public void NotEmptyTest()
        {
            XAssert.Throws<ArgumentException>(() =>
                    AssertStandard.NotEmpty<ArgumentException>(null, "param"));
            XAssert.Throws<ArgumentException>(() =>
                    AssertStandard.NotEmpty<ArgumentException>(new List<int>(), "param"));
            AssertStandard.NotEmpty<ArgumentException>(new List<int>() { 12, 12 }, "param");
        }

        [Fact]
        public void NotNullTest()
        {
            XAssert.Throws<ArgumentException>(() =>
                    AssertStandard.NotNull<ArgumentException>(null, "param"));
            AssertStandard.NotNull<ArgumentException>(new Point(), "param");
            AssertStandard.NotNull<ArgumentException>(new Point(12, 12), "param");
        }

        [Fact]
        public void NullTest()
        {
            AssertStandard.Null(null, "param");
            XAssert.Throws<ArgumentException>(() =>
                    AssertStandard.Null<ArgumentException>(new Point(), "param"));
            XAssert.Throws<ArgumentException>(() =>
                    AssertStandard.Null<ArgumentException>(new Point(12, 12), "param"));
        }

        [Fact]
        public void TrueOnActionTest()
        {
            XAssert.Throws<ArgumentException>(() =>
                    AssertStandard.True<ArgumentException>("12" == "13", "param"));

            AssertStandard.True<ArgumentException>("12" == "12", "param");
        }

        [Fact]
        public void TrueTest()
        {
            XAssert.Throws<ArgumentException>(() =>
                    AssertStandard.True<ArgumentException>(false, "param"));

            AssertStandard.True<ArgumentException>(true, "param");
        }

        public class ComplexeException : Exception
        {
            public ComplexeException(string message, Exception inner, bool whyNot)
            {
            }
        }
    }
}
