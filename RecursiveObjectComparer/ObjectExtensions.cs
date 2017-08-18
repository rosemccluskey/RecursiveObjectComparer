using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace RecursiveObjectComparer
{
    public static class ObjectExtensions
    {
        public static int CompareTo(this object thisObject, object otherObject, BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance, ValueTypeComparerFactory.ComparerFlags comparerFlags = ValueTypeComparerFactory.ComparerFlags.None)
        {
            var nullTest = ValueTypeComparerFactory.NullTest(thisObject, otherObject);
            if (nullTest.HasValue)
                return nullTest.Value;

            if (thisObject.GetType() != otherObject.GetType())
                throw new ArgumentException("Types do not match, compare fails.");

            var comparer = ValueTypeComparerFactory.GetInstance(thisObject.GetType());
            return comparer.Compare(thisObject, otherObject, bindingFlags, comparerFlags);
        }

        public static bool ImplementsIEnumerableAndIsNotAString(this Type t)
        {
            return t.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IEnumerable<>)) && t != typeof(string);
        }

        public static bool ImplementsIEnumerableAndIsNotAString(this object c)
        {
            return c.GetType().GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IEnumerable<>)) && !(c is string);
        }

        /// <summary>
        /// Evalutes to true for numeric types and also for boxed numeric types
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNumber(this object value)
        {
            return value is sbyte
                   || value is byte
                   || value is short
                   || value is ushort
                   || value is int
                   || value is uint
                   || value is long
                   || value is ulong
                   || value is float
                   || value is double
                   || value is decimal
                   || value.GetType() == typeof(sbyte)
                   || value.GetType() == typeof(byte)
                   || value.GetType() == typeof(short)
                   || value.GetType() == typeof(ushort)
                   || value.GetType() == typeof(int)
                   || value.GetType() == typeof(uint)
                   || value.GetType() == typeof(long)
                   || value.GetType() == typeof(ulong)
                   || value.GetType() == typeof(float)
                   || value.GetType() == typeof(double)
                   || value.GetType() == typeof(decimal);
        }
    }
}
