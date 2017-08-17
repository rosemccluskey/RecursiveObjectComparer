using System;
using RecursiveObjectComparer.Models;

namespace RecursiveObjectComparer
{
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
}