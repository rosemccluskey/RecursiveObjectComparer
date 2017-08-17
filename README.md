# Recursive Object Comparer

This code allows you to add `.CompareTo()` to any type derived from `object` without having to implement IComparable interface. Return values are consistent with c# IComparable return values.

return|description
---|---
0 | objects match
&lt; 0 | object 1 precedes object 2
&gt; 0 | object 1 follows object 2

This is a recursive comparer. When it receives an object containing complex properites, lists and lists of complex properties, it will delve into the properties and do a deep comparison.
Note: when comparing lists, order matters. `{1, 2, 3}` does not match `{1, 3, 2}`.

## Example Usage
```
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

            Console.ReadLine();
        }
    }
```

`Output:`
`Compare person one to person two: 0`
`Compare person one to person two: -5`
`Compare person two to person one: 5`