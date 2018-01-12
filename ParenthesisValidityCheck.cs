using System;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleApp2
{
    class Program
    {
        class Node
        {
            public int Value { get; set; }
            public Node Next { get; set; }
        }

        static void Main(string[] args)
        {
            var validInput = "([(){()}])";
            var result = CheckIfValid(validInput);
            var invalidInput = "([(){()})]";
            var result2 = CheckIfValid(invalidInput);
            var emptyInput = "(";
            var result3 = CheckIfValid(emptyInput);
        }

        private static bool CheckIfValid(string input)
        {
            var length = input.Length;

            var stack = new char[length];
            var i = -1;
            foreach (var ch in input)
            {
                switch (ch)
                {
                    case ('['):
                        stack[++i] = ']';
                        break;
                    case ('{'):
                        stack[++i] = '}';
                        break;
                    case ('('):
                        stack[++i] = ')';
                        break;
                    default:
                        var savedChar = stack[i--];
                        if (savedChar != ch)
                        {
                            return false;
                        }
                        break;
                }
            }

            return (i == -1);
        }
    }
}