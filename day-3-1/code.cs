using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace MVESIGN.AdventOfCode
{
    public class Program
    {
        static void Main(string[] args)
        {
            var claims = File.ReadAllLines(@"input.txt");

            var positions = new Dictionary<long, int>();

            foreach (var claim in claims)
            {
                var matches = new Regex(@"^#\d+ @ (?<start>[0-9]+),(?<end>[0-9]+): (?<width>[0-9]+)x(?<height>[0-9]+)$").Match(claim).Groups
                    .Where(g => int.TryParse(g.Value, out _))
                    .Select(g => int.Parse(g.Value))
                    .ToList();
                
                var start = matches[0];
                var end = matches[1];
                var width = matches[2];
                var height = matches[3];

                for (var x = start; x < start + width; x++)
                {
                    for (var y = end; y < end + height; y++)
                    {
                        var key = y * 1000 + x;
                        if (!positions.ContainsKey(key))
                            positions.Add(key, 1);
                        else
                            positions[key]++;
                    }
                }
            }

            Console.WriteLine($"Square inches: {positions.Count(p => p.Value > 1)}");
        }
    }
}