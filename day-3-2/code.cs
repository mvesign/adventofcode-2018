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

            var grid = new int[1000, 1000];
            var positions = new List<int>();

            foreach (var claim in claims)
            {
                var matches = new Regex(@"^#(?<id>\d+) @ (?<start>[0-9]+),(?<end>\d+): (?<width>\d+)x(?<height>\d+)$").Match(claim).Groups
                    .Where(g => int.TryParse(g.Value, out _))
                    .Select(g => int.Parse(g.Value))
                    .ToList();
                
                var id = matches[0];
                var start = matches[1];
                var end = matches[2];
                var width = matches[3];
                var height = matches[4];

                positions.Add(id);
                
                for (var i = 0; i < width; i++)
                {
                    for (var j = 0; j < height; j++)
                    {
                        var previousId = grid[start + i, end + j];
                        if (previousId != 0)
                        {
                            positions.Remove(id);
                            positions.Remove(previousId);
                            continue;
                        }

                        grid[start + i, end + j] = id;
                    }
                }
            }

            Console.WriteLine($"Identifier: {positions.First()}");
        }
    }
}