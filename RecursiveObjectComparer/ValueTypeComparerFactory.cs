using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace RecursiveObjectComparer
{
    public abstract class ValueTypeComparerFactory
    {
        private static readonly Dictionary<Type, ValueTypeComparerFactory> ComparerTypesDictionary = new Dictionary<Type, ValueTypeComparerFactory>
        {
            {typeof(bool), new BoolComparer()},
            {typeof(byte), new NumericComparer()},
            {typeof(sbyte), new NumericComparer()},
            {typeof(char), new AlphaComparer()},
            {typeof(decimal), new NumericComparer()},
            {typeof(double), new NumericComparer()},
            {typeof(float), new NumericComparer()},
            {typeof(int), new NumericComparer()},
            {typeof(uint), new NumericComparer()},
            {typeof(long), new NumericComparer()},
            {typeof(ulong), new NumericComparer()},
            {typeof(short), new NumericComparer()},
            {typeof(ushort), new NumericComparer()},
            {typeof(string), new AlphaComparer()},
            {typeof(DateTime), new DateTimeComparer()},
            {typeof(Enum), new EnumComparer()},
            {typeof(IList), new ListComparer()},
            {typeof(object), new ObjectComparer()}
        };

        [Flags]
        public enum ComparerFlags
        {
            None = 0,
            IgnoreId = 2,
            IgnoreKeyAttributeProperties = 4
        }

        public static ValueTypeComparerFactory GetInstance(Type t)
        {
            if (t.BaseType == typeof(Enum))
            {
                return ComparerTypesDictionary[typeof(Enum)];
            }

            if (t == typeof(string))
            {
                return ComparerTypesDictionary[typeof(string)];
            }

            if (t.ImplementsIEnumerableAndIsNotAString())
            {
                return ComparerTypesDictionary[typeof(IList)];
            }

            if (t.IsClass)
            {
                return ComparerTypesDictionary[typeof(object)];
            }

            if (!ComparerTypesDictionary.ContainsKey(t))
                throw new ArgumentOutOfRangeException($"Tracker doesn't know how to create a comparer factory for type {t.Name}");

            return ComparerTypesDictionary[t];

        }

        /// <summary>
        /// Returns a value when at least one object is null
        /// </summary>
        /// <param name="thisObject"></param>
        /// <param name="thatObject"></param>
        /// <returns>0 = both objects are null; -1 = thisObject is null; 1 = thatObject is null</returns>
        public static int? NullTest(object thisObject, object thatObject)
        {
            if (thisObject == null && thatObject == null) return 0;
            if (thisObject == null) return -1;
            if (thatObject == null) return 1;

            return null;
        }

        public abstract int Compare(object thisObject, object thatObject, BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance, ComparerFlags flags = ComparerFlags.None);
    }

    public class BoolComparer : ValueTypeComparerFactory
    {
        public override int Compare(object thisObject, object thatObject, BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance, ComparerFlags flags = ComparerFlags.None)
        {
            if (NullTest(thisObject, thatObject).HasValue)
                return Convert.ToInt32(NullTest(thisObject, thatObject));

            if (!(thisObject is bool) || !(thatObject is bool))
                throw new ArgumentException("Boolean values are required");

            var b1 = (bool)thisObject;
            var b2 = (bool)thatObject;
            return b1.CompareTo(b2);
        }
    }

    public class NumericComparer : ValueTypeComparerFactory
    {
        public override int Compare(object thisObject, object thatObject, BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance, ComparerFlags flags = ComparerFlags.None)
        {
            if (NullTest(thisObject, thatObject).HasValue)
                return Convert.ToInt32(NullTest(thisObject, thatObject));

            if (!thisObject.IsNumber() || !thatObject.IsNumber())
                throw new ArgumentException("Numeric values are required");

            var b1 = Convert.ToDouble(thisObject);
            var b2 = Convert.ToDouble(thatObject);
            return b1.CompareTo(b2);
        }
    }

    public class AlphaComparer : ValueTypeComparerFactory
    {
        public override int Compare(object thisObject, object thatObject, BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance, ComparerFlags flags = ComparerFlags.None)
        {
            if (NullTest(thisObject, thatObject).HasValue)
                return Convert.ToInt32(NullTest(thisObject, thatObject));

            if (thisObject is string && thatObject is string)
            {
                var s1 = thisObject.ToString();
                var s2 = thatObject.ToString();
                return string.Compare(s1, s2, StringComparison.Ordinal);
            }

            if (thisObject is char && thatObject is char)
            {
                var c1 = (char)thisObject;
                var c2 = (char)thatObject;
                return c1.CompareTo(c2);
            }

            throw new ArgumentException("String type or char type is required.");
        }
    }

    // okay, not a value type. But whatever.
    public class DateTimeComparer : ValueTypeComparerFactory
    {
        public override int Compare(object thisObject, object thatObject,
            BindingFlags bindingFlags = BindingFlags.Default | BindingFlags.Instance | BindingFlags.Public,
            ComparerFlags flags = ComparerFlags.None)
        {
            if (NullTest(thisObject, thatObject).HasValue)
                return Convert.ToInt32(NullTest(thisObject, thatObject));

            if (!(thisObject is DateTime) || !(thatObject is DateTime))
                throw new ArgumentException($"DateTime expected. Can not compare types {thisObject.GetType().FullName} to {thatObject.GetType().FullName}");

            var d1 = Convert.ToDateTime(thisObject);
            var d2 = Convert.ToDateTime(thatObject);

            // disregard milliseconds/ticks comparison
            d1 = new DateTime(d1.Year, d1.Month, d1.Day, d1.Hour, d1.Minute, d1.Second);
            d2 = new DateTime(d2.Year, d2.Month, d2.Day, d2.Hour, d2.Minute, d2.Second);

            return d1.CompareTo(d2);
        }
    }

    public class EnumComparer : ValueTypeComparerFactory
    {
        public override int Compare(object thisObject, object thatObject, BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance, ComparerFlags flags = ComparerFlags.None)
        {
            if (NullTest(thisObject, thatObject).HasValue)
                return Convert.ToInt32(NullTest(thisObject, thatObject));

            if (!(thisObject is Enum) || !(thatObject is Enum))
                throw new ArgumentException($"Can not compare types {thisObject.GetType().FullName} to {thatObject.GetType().FullName}");

            var o1 = Convert.ToInt32(thisObject);
            var o2 = Convert.ToInt32(thatObject);

            return o1.CompareTo(o2);
        }
    }

    /// <summary>
    /// This is recursive. Object.CompareTo extension uses ValueTypeComparerFactory
    /// </summary>
    public class ObjectComparer : ValueTypeComparerFactory
    {
        public override int Compare(object thisObject, object thatObject, BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance, ComparerFlags flags = ComparerFlags.None)
        {
            if (NullTest(thisObject, thatObject).HasValue)
                return Convert.ToInt32(NullTest(thisObject, thatObject));

            if (thisObject.GetType() != thatObject.GetType())
                throw new ArgumentException("Objects must be same type");

            if (!thisObject.GetType().IsClass || !thatObject.GetType().IsClass)
                throw new ApplicationException($"Object comparer expects classes not {thisObject.GetType().Name}");

            var properties = FilterProperties(thisObject.GetType().GetProperties(bindingFlags), flags);

            foreach (var property in properties)
            {
                var thisValue = property.GetValue(thisObject);
                var otherValue = property.GetValue(thatObject);

                var nullTest = NullTest(thisValue, otherValue);
                if (nullTest == 0)
                    continue;

                if (nullTest.HasValue)
                    return Convert.ToInt32(nullTest);

                ValueTypeComparerFactory comparer;
                try
                {
                    comparer = GetInstance(thisValue.GetType());
                }
                catch (ArgumentOutOfRangeException)
                {
                    // recursive comparison using `object` type
                    comparer = GetInstance(typeof(object));
                }

                var compareResult = comparer.Compare(thisValue, otherValue);

                if (compareResult != 0)
                    return compareResult;
            }

            return 0;
        }

        private List<PropertyInfo> FilterProperties(PropertyInfo[] propInfo, ComparerFlags flags)
        {
            if (propInfo == null || flags == ComparerFlags.None)
                return propInfo?.ToList();

            var _return = propInfo.ToList();
            _return.RemoveAll(FlaggedProperty);

            return _return;

            bool FlaggedProperty(PropertyInfo p)
            {
                if (flags.HasFlag(ComparerFlags.IgnoreId))
                {
                    if (p.Name.ToLower() == "id")
                        return true;
                }

                if (flags.HasFlag(ComparerFlags.IgnoreKeyAttributeProperties))
                {
                    if (p.GetCustomAttributes(true).All(attr => attr.GetType().Name == nameof(KeyAttribute)))
                        return true;
                }

                return false;
            }

        }

    }

    public class ListComparer : ValueTypeComparerFactory
    {
        public override int Compare(object thisObject, object thatObject, BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance, ComparerFlags flags = ComparerFlags.None)
        {
            var nullTest = NullTest(thisObject, thatObject);
            if (nullTest.HasValue)
                return nullTest.Value;

            if (!thisObject.ImplementsIEnumerableAndIsNotAString() ||
                !thatObject.ImplementsIEnumerableAndIsNotAString())
                throw new ArgumentException(
                    $"Can not compare {thisObject.GetType().Name} to {thatObject.GetType().Name}. Must be List<T>");

            var thisList = (IList)thisObject;
            var otherList = (IList)thatObject;

            // compare list size
            if (thisList.Count < otherList.Count)
                return -1;

            if (thisList.Count > otherList.Count)
                return 1;

            // compare list items. List order matters.
            for (var i = 0; i < thisList.Count; i++)
            {
                var item1 = thisList[i];
                var item2 = otherList[i];
                var comparerResult = item1.CompareTo(item2);
                if (comparerResult != 0)
                    return comparerResult;
            }

            return 0;
        }
    }
}
