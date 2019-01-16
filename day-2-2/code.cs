using System;
using System.IO;

namespace MVESIGN.AdventOfCode
{
    public class Program
    {
        static void Main(string[] args)
        {
            var identifiers = File.ReadAllLines(@"input.txt");

            for (var i = 0; i + 1 < identifiers.Length; i++)
            {
                var current = identifiers[i];
                for (var j = i + 1; j < identifiers.Length; j++)
                {
                    var next = identifiers[j];
                    var matching = string.Empty;
                    for (var position = 0; position < current.Length; position++)
                        if (current[position] == next[position])
                            matching += current[position];
                    
                    if (matching.Length == current.Length - 1)
                    {
                        Console.WriteLine($"Common letters: {matching}");
                        return;
                    }
                }
            }
        }
    }
}