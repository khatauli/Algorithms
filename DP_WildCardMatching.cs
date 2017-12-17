using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = "catisgreatt";
            var pattern = "*sg??*tt";
            bool result = Match(data, pattern);
        }

        //this works for negative as well the positive numbersA
        static bool Match(string data, string pattern)
        {
            var t = new bool[data.Length + 1, pattern.Length + 1];

            t[0, 0] = true;
            if (pattern[0] == '*')
            {
                t[1, 0] = true;
            }

            for (int i = 1; i < t.GetLength(0); i++)
            {
                for (int j = 1; j < t.GetLength(1); j++)
                {
                    if (pattern[j-1] == '?' || pattern[j - 1] == data[i-1])
                    {
                        t[i, j] = t[i - 1, j - 1];
                    }
                    else if (pattern[j - 1] == '*')
                    {
                        t[i, j] = t[i - 1, j] || t[i, j-1];
                    }
                }
            }
            return t[data.Length, pattern.Length];
        }
    }
}