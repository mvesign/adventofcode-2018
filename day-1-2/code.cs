using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MVESIGN.AdventOfCode
{
    public class Program
    {
        static void Main(string[] args)
        {
            var frequencies = File.ReadAllLines(@"input.txt").Select(line => int.Parse(line)).ToArray();
            var frequency = 0;
            var results = new HashSet<int>();
            for (int i = 0; ; i++)
            {
                if (!results.Add(frequency))
                    break;
                frequency += frequencies[i % frequencies.Length];
            }

            Console.WriteLine($"Frequency: {frequency}");
        }
    }
}