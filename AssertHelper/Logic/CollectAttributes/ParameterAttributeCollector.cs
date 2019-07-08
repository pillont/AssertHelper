using AssertHelper.Attributes;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AssertHelper.Logic.CollectAttributes
{
    /// <summary>
    /// used to colled attribute on method parameters
    /// </summary>
    internal class ParameterAttributeCollector
    {
        public Dictionary<AssertAttribute, ParameterInfo> ParamAssertsCollect(MethodInfo method)
        {
            return method.GetParameters()
                                    .SelectMany(param => param.GetCustomAttributes<AssertAttribute>().Select(attr => new { Param = param, Attri = attr }))
                                    .Distinct()
                                    .ToDictionary(pair => pair.Attri, pair => pair.Param);
        }
    }
}
