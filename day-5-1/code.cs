using System;
using System.Collections.Generic;
using System.IO;

namespace MVESIGN.AdventOfCode
{
    public class Program
    {
        private static List<char> _stack = new List<char>();

        static void Main(string[] args)
        {
            var polymer = File.ReadAllText(@"input.txt");
            var unitSize = 1;
            foreach(var unit in polymer)
            {
                if (!Program.Peek().HasValue)
                {
                    //Console.WriteLine($"Peek -, Push {unit}, UnitSize {unitSize} - No peek");
                    Program.Push(unit);
                    continue;
                }

                var peek = Program.Peek().Value;
                if (char.IsLower(peek) && char.IsLower(unit))
                {
                    //Console.WriteLine($"Peek {peek}, Push {unit}, UnitSize {unitSize} - Peek lower, unit lower");
                    Program.Push(unit);
                    continue;
                }

                if (char.IsLower(peek) && char.IsUpper(unit))
                {
                    if (char.Equals(peek, char.ToLower(unit)))
                        unitSize++;

                    //Console.WriteLine($"Peek {peek}, Push {unit}, UnitSize {unitSize} - Peek lower, unit upper");
                    Program.Push(unit);
                    continue;
                }

                if (char.IsUpper(peek) && char.IsUpper(unit))
                {
                    if (unitSize > 1)
                    {
                        Program.Pop(unitSize);
                        unitSize = 1;
                    }

                    //Console.WriteLine($"Peek {peek}, Push {unit}, UnitSize {unitSize} - Peek upper, unit upper");
                    Program.Push(unit);
                    continue;
                }

                if (char.IsUpper(peek) && char.IsLower(unit))
                    if (char.Equals(peek, char.ToUpper(unit)))
                    {
                        Program.Pop(1);
                        var secondPeek = Program.Peek();
                        if (secondPeek.HasValue && char.Equals(char.ToUpper(secondPeek.Value), peek))
                            Program.Pop(1);
                    }
                    else
                    {
                        if (unitSize > 1)
                        {
                            //Console.WriteLine($"Pop unitSize {unitSize}");
                            Program.Pop(unitSize);
                            unitSize = 1;
                        }

                        //Console.WriteLine($"Peek {peek}, Push {unit}, UnitSize {unitSize} - Peek upper, unit lower");
                        Program.Push(unit);
                    }
            }

            Console.WriteLine($"Remaining units: {Program.List()}");
        }

        public static string List() =>
            string.Join(string.Empty, _stack);

        public static char? Peek() =>
            _stack.Count > 0 ? _stack[_stack.Count - 1] : (char?)null;

        public static void Pop(int size)
        {
            for(var i = 0; i < size; i++)
                _stack.RemoveAt(_stack.Count - 1);
        }

        public static void Push(char unit) =>
            _stack.Add(unit);
    }
}