using System;
using System.IO;
using System.Linq;

namespace MVESIGN.AdventOfCode
{
    public class Program
    {
        static void Main(string[] args)
        {
            var frequency = 0;
            File.ReadAllLines(@"input.txt")
                .Select(line => int.Parse(line))
                .ToList()
                .ForEach(f => frequency += f);
            
            Console.WriteLine($"Frequency: {frequency}");
        }
    }
}