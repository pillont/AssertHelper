using AssertHelper.Attributes;

using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AssertHelper.Logic.CollectAttributes
{
    /// <summary>
    /// used to colled attribute on method
    /// also used to collect attribute on properties
    /// </summary>
    internal class MethodAttributeCollector
    {
        /// <summary>
        /// parameter in properties's setter
        /// </summary>
        private const string SetterArgumentName = "value";

        /// <summary>
        /// prefix of properties's setter method
        /// </summary>
        private const string SetterPrefix = "set_";

        public List<AssertAttribute> CollectMethodAttr(MethodInfo method)
        {
            string methodName = method.Name;
            bool IsNotSetterMethod = !methodName.StartsWith(SetterPrefix);

            return IsNotSetterMethod
                        ? CollectAttributesOnPropertySetter(method)
                        : CollectAttributesOnSampleMethod(method, methodName);
        }

        private List<AssertAttribute> CollectAttributesOnPropertySetter(MethodInfo method)
        {
            return method.GetCustomAttributes<AssertAttribute>()
                            .ToList();
        }

        private List<AssertAttribute> CollectAttributesOnSampleMethod(MethodInfo method, string methodName)
        {
            var propName = methodName.Substring(SetterPrefix.Length);
            var allAttr = method.DeclaringType.GetProperty(propName).GetCustomAttributes<AssertAttribute>()
                            .ToList();

            foreach (var attr in allAttr)
            {
                attr.ParameterName = SetterArgumentName;
            }

            return allAttr;
        }
    }
}
