using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = 5;
            var memoaization = new int[n+1];
            var result = GetFibonachi(n, memoaization);
        }

        private static int GetFibonachi(int n, int[] memoaization)
        {
            if (n == 0 || n == 1)
            {
                return n;
            }
            if (memoaization[n] != 0)
            {
                return memoaization[n];
            }
            var fib = GetFibonachi(n - 1, memoaization) + GetFibonachi(n - 2, memoaization);
            memoaization[n] = fib;
            return fib;
        }
    }
}