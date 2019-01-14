using System;
using System.IO;

namespace MVESIGN.AdventOfCode
{
    public class Program
    {
        static void Main(string[] args)
        {
            var frequencyChanges  = File.ReadAllLines(@"input.txt");
            
            var currentFrequency = 0;
            foreach (var frequencyChange in frequencyChanges)
                currentFrequency = currentFrequency + int.Parse(frequencyChange.Substring(1)) * (frequencyChange.Substring(0,1) == "+" ? 1 : -1);
            
            Console.WriteLine($"Frequency: {currentFrequency}");
        }
    }
}