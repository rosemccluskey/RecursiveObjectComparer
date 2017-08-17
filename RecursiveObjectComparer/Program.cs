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

            Console.ReadLine();
        }
    }
}