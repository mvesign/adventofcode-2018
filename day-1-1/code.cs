using System;
using System.IO;

namespace MVESIGN.AdventOfCode
{
    public class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines(@"input.txt");
            
            var result = 0;
            foreach (var line in lines)
                result = result + int.Parse(line.Substring(1)) * (line.Substring(0,1) == "+" ? 1 : -1);
            
            Console.WriteLine($"Frequency: {result}");
        }
    }
}