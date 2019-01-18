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
            var actions = File.ReadAllLines(@"input.txt")
                .Select(line =>
                {
                    var groups = new Regex(@"^\[(?<datetime>\d{4}-\d{2}-\d{2} \d{2}:\d{2})\] (?<action>.+)$").Match(line).Groups;
                    return new
                    {
                        Action = groups["action"].Value,
                        DateTime = DateTime.Parse(groups["datetime"].Value)
                    };
                })
                .OrderBy(action => action.DateTime)
                .ToList();

            var guardId = 0;
            var minuteAsleep = 0;
            var sleepSchedule = new Dictionary<(int, int), int>();
            foreach (var action in actions)
            {
                if (action.Action.StartsWith("Guard"))
                    guardId = int.Parse(action.Action.Replace("Guard #", string.Empty).Replace(" begins shift", string.Empty));
                if (action.Action == "falls asleep")
                    minuteAsleep = action.DateTime.Minute;
                else if (action.Action == "wakes up")
                {
                    for(;minuteAsleep < action.DateTime.Minute; minuteAsleep++)
                    {
                        if (!sleepSchedule.ContainsKey((guardId, minuteAsleep)))
                            sleepSchedule.Add((guardId, minuteAsleep), 0);

                        sleepSchedule[(guardId, minuteAsleep)]++;
                    }
                }
            }

            var guardMinute = sleepSchedule.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
            Console.WriteLine($"Guard {guardMinute.Item1} slept the most in minute {guardMinute.Item2}, resulting in the answer {guardMinute.Item1 * guardMinute.Item2}");
        }
    }
}