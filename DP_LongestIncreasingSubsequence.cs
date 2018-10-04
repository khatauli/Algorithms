using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    //https://www.geeksforgeeks.org/longest-increasing-subsequence-dp-3/
    class Program
    {
        static void Main(string[] args)
        {
            var test = new Solution().LongestIncreasingSubsequence(new int[] { 3, 6, 12, 11, 13 , 55, 65, 12 });
        }
    }

    class Solution
    {
        public int LongestIncreasingSubsequence(int[] ar)
        {
            var T = new int[ar.Length];
            T[0] = 1;
            return Calculate(ar, ar.Length -1, T);
        }

        private int Calculate(int[] ar, int endIndex, int[] T)
        {
            if (T[endIndex] > 0)
            {
                return T[endIndex];
            }

            int max = 1;
            for (int j = 1; j < endIndex; j++)
            {
                if (ar[endIndex] > ar[j])
                {
                    int T_j = Calculate(ar, j, T);
                    max = Math.Max(max, T_j);
                }
            }
            T[endIndex] = Math.Max(max + 1, Calculate(ar, endIndex - 1, T));
            return T[endIndex];
        }
    }
}