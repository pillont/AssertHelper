using System.Collections.Generic;

namespace AssertHelper.Tests.Fakes
{
    public class TestObj
    {
        public string Value { get; set; }

        public class TestObjComparer : IEqualityComparer<TestObj>
        {
            public bool Equals(TestObj x, TestObj y)
            {
                return x.Value == y.Value;
            }

            public int GetHashCode(TestObj obj)
            {
                return obj.Value.GetHashCode();
            }
        }
    }
}
