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
                var matches = new Regex(@"^#\d+ @ (?<start>[0-9]+),(?<end>[0-9]+): (?<width>[0-9]+)x(?<height>[0-9]+)$")
                    .Match(claim)
                    .Groups;
                
                var start = int.Parse(matches["start"].Value);
                var end = int.Parse(matches["end"].Value);
                var width = int.Parse(matches["width"].Value);
                var height = int.Parse(matches["height"].Value);

                for (var i = start; i < start + width; i++)
                {
                    for (var j = end; j < end + height; j++)
                    {
                        var key = j * 10000 + i;
                        if (!positions.ContainsKey(key))
                            positions.Add(key, 0);
                        positions[key]++;
                    }
                }
            }

            Console.WriteLine($"Square inches: {positions.Count(p => p.Value > 1)}");
        }
    }
}