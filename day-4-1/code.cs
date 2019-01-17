using System;
using System.IO;

namespace MVESIGN.AdventOfCode
{
    public class Program
    {
        static void Main(string[] args)
        {
            var actions = File.ReadAllLines(@"input.txt");

            foreach (var action in actions)
            {
                var groups = new Regex(@"^\[(?<datetime>\d{4}-\d{2}-\d{2} \d{2}:\d{2})\] (?<action>.+)$").Match(action).Groups;
                foreach (var group in groups)
                {

                }
            }
        }
    }
}