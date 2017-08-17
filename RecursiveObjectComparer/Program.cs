using System;
using RecursiveObjectComparerTool.Models;

namespace RecursiveObjectComparerTool
{
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
}