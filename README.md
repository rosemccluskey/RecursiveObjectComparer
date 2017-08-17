# Recursive Object Comparer

This code allows you to add `.CompareTo()` to any type derived from `object`. Return values are consistent with c# IComparable return values.
0 | objects match
<0 | object 1 precedes object 2
>0 | object 1 follows object 2
This is a recursive comparer. When it receives an object containing complex properites, lists and lists of complex properties, it will delve into the properties and do a deep comparison.
Note: when comparing lists, order matters. `{1, 2, 3}` does not match `{1, 3, 2}`.

## Example Usage
```
class Program
    {
        static void Main()
        {
            var hedy = new Person { FirstName = "Hedy", LastName = "Lamaar" };
            var mae = new Person { FirstName = "Mae", LastName = "Jemison" };

            Console.WriteLine($"Compare Hedy Lamaar to Mae Jemison: {hedy.CompareTo(mae)}");
            Console.ReadLine();
        }
    }
```
`Output: -5`
