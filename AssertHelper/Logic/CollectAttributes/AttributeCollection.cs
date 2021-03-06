using AssertHelper.Attributes;
using System.Collections.Generic;
using System.Reflection;

namespace AssertHelper.Logic.CollectAttributes
{
    internal class AttributeCollection
    {
        /// <summary>
        /// method of the implementing object
        /// </summary>
        public MethodInfo CurrentMethod { get; internal set; }

        /// <summary>
        /// attribute on the method of the implementing object
        /// </summary>
        public IEnumerable<AssertAttribute> CurrentMethodAttributes { get; set; }

        /// <summary>
        /// attribute on the params of the method in the implementing object
        /// </summary>
        public Dictionary<AssertAttribute, ParameterInfo> CurrentParamAttr { get; internal set; }

        /// <summary>
        /// method of the interface
        /// </summary>
        public MethodInfo InterfaceMethod { get; internal set; }

        /// <summary>
        /// attribute on the method of the interface
        /// </summary>
        public IEnumerable<AssertAttribute> InterfaceMethodAttributes { get; set; }

        /// <summary>
        /// attribute on the params of the method in the interface
        /// </summary>
        public Dictionary<AssertAttribute, ParameterInfo> InterfaceParamAttr { get; internal set; }
    }
}
