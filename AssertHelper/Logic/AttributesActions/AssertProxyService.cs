using AssertHelper.Attributes;
using AssertHelper.Exceptions;
using AssertHelper.Logic.CollectAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AssertHelper.Logic.AttributesActions
{
    /// <summary>
    /// service to apply logic of assert interceptor
    /// </summary>
    public class AssertProxyService
    {
        /// <summary>
        /// object proxied
        /// flat pass of cache taget
        /// </summary>
        public object Target
        {
            get => AttributeCache.Target;
            set => AttributeCache.Target = value;
        }

        /// <summary>
        /// service to apply logic of assert
        /// </summary>
        internal AssertAttributeService Service { get; }

        /// <summary>
        /// cache of method attributes
        /// collect attribut and store there to avoid collect each time
        /// </summary>
        private AttributeCache AttributeCache { get; }

        public AssertProxyService()
        {
            Service = new AssertAttributeService();
            AttributeCache = new AttributeCache();
        }

        public void ApplyAsserts(MethodInfo method, object[] parameters)
        {
            AttributeCollection attributeCollection = AttributeCache.CollectWithCache(method);
            MethodInfo currentMethod = attributeCollection.CurrentMethod;
            MethodInfo interfaceMethod = attributeCollection.InterfaceMethod;

            var interfaceParamAttr = attributeCollection.InterfaceParamAttr
                .Where(pair => !pair.Key.IsTargetResult);
            ApplyAssertOnMethodParameters(parameters, interfaceMethod, interfaceParamAttr);

            IEnumerable<AssertAttribute> interfaceMethodAttributes = attributeCollection.InterfaceMethodAttributes
                .Where(attr => !attr.IsTargetResult);
            ApplyAssertOnMethod(attributeCollection.InterfaceMethod, interfaceMethodAttributes, parameters);

            if (currentMethod != interfaceMethod)
            {
                var currentParamAttr = attributeCollection.CurrentParamAttr
                    .Where(pair => !pair.Key.IsTargetResult);
                ApplyAssertOnMethodParameters(parameters, currentMethod, currentParamAttr);

                var currentMethodAttributes = attributeCollection.CurrentMethodAttributes
                    .Where(attr => !attr.IsTargetResult);
                ApplyAssertOnMethod(currentMethod, currentMethodAttributes, parameters);
            }
        }

        public void ApplyResultAsserts(MethodInfo method, object returnValue)
        {
            AttributeCollection attributeCollection = AttributeCache.CollectWithCache(method);
            MethodInfo currentMethod = attributeCollection.CurrentMethod;
            MethodInfo interfaceMethod = attributeCollection.InterfaceMethod;

            var interfaceMethodAttributes = attributeCollection.InterfaceMethodAttributes
                .Where(attr => attr.IsTargetResult);
            ApplyAssertOnResult(attributeCollection.InterfaceMethod, interfaceMethodAttributes, returnValue);

            if (currentMethod != interfaceMethod)
            {
                var currentMethodAttributes = attributeCollection.CurrentMethodAttributes
                    .Where(attr => attr.IsTargetResult);
                ApplyAssertOnResult(currentMethod, currentMethodAttributes, returnValue);
            }
        }

        private void ApplyAssertOnMethod(MethodInfo method, IEnumerable<AssertAttribute> allAttributes, object[] allParameters)
        {
            foreach (var attr in allAttributes)
            {
                var value = CollectValueFromMethod(attr.ParameterName, method, allParameters);
                Service.ApplyAssertOnValue(attr, value);
            }
        }

        private void ApplyAssertOnMethodParameters(object[] parameters, MethodInfo currentMethod, IEnumerable<KeyValuePair<AssertAttribute, ParameterInfo>> allAttributes)
        {
            foreach (var pair in allAttributes)
            {
                var attr = pair.Key;
                var param = pair.Value;
                object paramValue = parameters[param.Position];

                if (string.IsNullOrEmpty(attr.ParameterName))
                    attr.ParameterName = param.Name;
                else
                {
                    var paramName = attr.ParameterName;
                    Assert.True(paramName.StartsWith(param.Name), nameof(paramName), "param name must start with the name of the param");
                    paramValue = CollectValueFromMethod(paramName, currentMethod, parameters);
                }
                Service.ApplyAssertOnValue(attr, paramValue);
            }
        }

        private void ApplyAssertOnResult(MethodInfo method, IEnumerable<AssertAttribute> allAttributes, object returnValue)
        {
            foreach (var attr in allAttributes)
            {
                Service.ApplyAssertOnValue(attr, returnValue);
            }
        }

        private object CollectValueFromMethod(string parameterName, MethodInfo method, object[] allParameters)
        {
            Assert.False<AttributeAssertException>(parameterName.Contains('?')
                                                || parameterName.Contains('['),
                nameof(parameterName),
                $"Error on {parameterName} : must not contain operation '?' or indexer '[x]'");

            var allStr = parameterName.Split('.').ToList();
            Assert.True(allStr.Any(), nameof(allStr), $"Error on {parameterName} : must not be empty");

            // Collect param value
            var paramName = allStr.FirstOrDefault();
            allStr.RemoveAt(0);

            var list = method.GetParameters().ToList();
            var paramIndex = list.FindIndex(par => par.Name == paramName);
            Assert.GreaterThan<AttributeAssertException>(paramIndex, -1, nameof(paramIndex), $"Parameter {paramName} not found");

            var value = allParameters[paramIndex];

            // COLLECT SUB-VALUE
            while (allStr.Any())
            {
                var propName = allStr.FirstOrDefault();
                allStr.RemoveAt(0);

                // CHECK PREVIOUS VALUE IS NOT NULL
                Assert.NotNull(value, nameof(value), $"previous value is null to collect {propName} from {parameterName}");

                PropertyInfo propertyInfo;
                try
                {
                    propertyInfo = value.GetType().GetProperty(propName);
                    Assert.NotNull(propertyInfo, nameof(propertyInfo));
                }
                catch (Exception)
                { throw new AttributeAssertException($"{propName} not found from {parameterName}"); }

                value = propertyInfo.GetValue(value);
            }

            return value;
        }
    }
}