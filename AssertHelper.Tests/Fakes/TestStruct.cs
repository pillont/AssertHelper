using System.Collections.Generic;

namespace AssertHelper.Tests.Fakes
{
    public struct TestStruct
    {
        public string Value { get; set; }

        public class TestStructComparer : IEqualityComparer<TestStruct>
        {
            public bool Result { get; set; }

            public bool Equals(TestStruct x, TestStruct y)
            {
                return Result;
            }

            public int GetHashCode(TestStruct obj)
            {
                return obj.Value.GetHashCode();
            }
        }
    }
}
