# Recursive Object Comparer

This code allows you to add `.CompareTo()` to any type derived from `object` without having to implement IComparable interface. Return values are consistent with c# IComparable return values.

return|description
---|---
0 | objects match
&lt; 0 | object 1 precedes object 2
&gt; 0 | object 1 follows object 2

This is a recursive comparer. When it receives an object containing complex properites, lists and lists of complex properties, it will delve into the properties and do a deep comparison.

Note: when comparing lists, order matters. `{1, 2, 3}` does not match `{1, 3, 2}`.

**Usage:**
```c#
object.CompareTo(object otherObject, BindingFlags bindingFlags, ValueTypeComparerFactory.ComparerFlags comparerFlags)
```

Value | Condition
--- | ---
object | any type derived from object
otherObject | any type derived from object; same type as `object`
bindingFlags | OPTIONAL. Refer to [BindingFlags](https://msdn.microsoft.com/en-us/library/system.reflection.bindingflags(v=vs.110).aspx) documentation. Applies when comparing classes. Default is 
```
BindingFlags.Public | BindingFlags.Instance
```
comparerFlags | OPTIONAL. `ValueTypeComparerFactory.ComparerFlags.IgnoreId` - comparer will not look at properties named ID, Id or id. `ValueTypeComparerFactory.ComparerFlags.IgnoreKeyAttributeProperties` - comparer will not look at properties with a `[Key]` attribute.  Applies when comparing classes. Default is `ValueTypeComparerFactory.ComparerFlags.None`.

## Example
```c#
class Program
    {
        static void Main()
        {
            var person1 = new Person { FirstName = "fn", LastName = "ln" };
            var person2 = new Person { FirstName = "fn", LastName = "ln" };

            Console.WriteLine($"Compare person one to person two: {person1.CompareTo(person2)}");

            var hedy = new Person { FirstName = "Hedy", LastName = "Lamaar" };
            var mae = new Person { FirstName = "Mae", LastName = "Jemison" };

            Console.WriteLine($"Compare Person one to Person Two: {hedy.CompareTo(mae)}");
            Console.WriteLine($"Compare Person two to Person one: {mae.CompareTo(hedy)}");

            person1.Id = 3;
            person2.Id = 4;

            Console.WriteLine($"Compare person {person1.Id} to person {person2.Id}, ignore id: {person1.CompareTo(person2, comparerFlags:ValueTypeComparerFactory.ComparerFlags.IgnoreId)}");
            Console.WriteLine($"Compare person {person1.Id} to person {person2.Id}, ignore key: {person1.CompareTo(person2, comparerFlags: ValueTypeComparerFactory.ComparerFlags.IgnoreKeyAttributeProperties)}");

            Console.ReadLine();
        }
    }
```

**Output:**
```
Compare person one to person two: 0
Compare person one to person two: -5
Compare person two to person one: 5
Compare person 3 to person 4, ignore id: 0
Compare person 3 to person 4, ignore key: 0
```
