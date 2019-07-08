using AssertHelper.Attributes;
using AssertHelper.Exceptions;
using System;
using System.Collections;

namespace AssertHelper.Logic.AttributesActions
{
    internal class AssertAttributeService
    {
        public void ApplyAssertOnValue<T>(AssertAttribute attr, T value)
        {
            double numeric;
            switch (attr)
            {
                case NotNullAttribute att:
                    Assert.NotNull(value, att.ParameterName, att.Message);
                    return;

                case GreaterThanAttribute att:
                    numeric = CollectNumericValue(value, att.ParameterName);
                    Assert.GreaterThan(numeric, att.Border, att.ParameterName, att.Message, att.AllowEquality);
                    return;

                case LessThanAttribute att:
                    numeric = CollectNumericValue(value, att.ParameterName);
                    Assert.LessThan(numeric, att.Border, att.ParameterName, att.Message, att.AllowEquality);
                    return;

                case NotDefaultAttribute att:
                    Assert.NotDefault(value, att.ParameterName, att.Message);
                    return;

                case NotEmptyAttribute att:

                    // NOTE : must not be null
                    Assert.NotNull<EmptyAssertException>(value,
                                                        nameof(value),
                                                        $"value is null");

                    // NOTE : must be a collection
                    var collection = value as IEnumerable;
                    Assert.NotNull<AttributeAssertException>(collection,
                                                            nameof(collection),
                                                            $"value of {nameof(NotEmptyAttribute)} must be {nameof(IEnumerable)}");

                    Assert.NotEmpty(collection, att.ParameterName, att.Message);
                    return;

                    /*
                case TryNotNullAttribute att:
                    Assert.TryNotNull(value, att.ParameterName, att.Message);
                    return;

                case TryGreaterThanAttribute att:
                    numeric = CollectNumericValue(value, att.ParameterName);
                    Assert.TryGreaterThan(numeric, att.Border, att.ParameterName, att.Message);
                    return;

                case TryLessThanAttribute att:
                    numeric = CollectNumericValue(value, att.ParameterName);
                    Assert.TryLessThan(numeric, att.Border, att.ParameterName, att.Message);
                    return;

                case TryNotDefaultAttribute att:
                    Assert.TryNotDefault(value, att.ParameterName, att.Message);
                    return;
                    */
            }
        }

        public double CollectNumericValue(object value, string parameterName)
        {
            try
            {
                var numeric = Convert.ToDouble(value);
                return numeric;
            }
            catch (Exception e)
            {
                throw new AttributeAssertException($"value {parameterName} is not convertable to double", e);
            }
        }
    }
}
