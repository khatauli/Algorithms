using System;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 4;
            var result = GenParan(n);
        }


        public static HashSet<string> GenParan(int n)
        {
            if (n < 1)
            {
                throw new ArgumentException("not valid");
            }

            if (n == 1) return new HashSet<string> { "()" };

            var result = new HashSet<string>();
            var internalResult = GenParan(n - 1);
            foreach (var row in internalResult)
            {
                AddToHashSet(result, "()" + row);
                AddToHashSet(result, row + "()");
                AddToHashSet(result, $"({row})");
            }

            return result;
        }

       

        private static void AddToHashSet(HashSet<string> set, string value)
        {
            if (!set.Contains(value))
            {
                set.Add(value);
            }
        }
    }
}