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
            var doubles = 0;
            var triples = 0;

            var identifiers = File.ReadAllLines(@"input.txt");
            foreach (var identifier in identifiers)
            {
                var groups = identifier
                    .GroupBy(c => c)
                    .ToDictionary(g => g.Key, g => g.Count());

                doubles += groups.Values.Any(v => v == 2) ? 1 : 0;
                triples += groups.Values.Any(v => v == 3) ? 1 : 0;
            }

            Console.WriteLine($"Checksum: {doubles * triples}");
        }
    }
}