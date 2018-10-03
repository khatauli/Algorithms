using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    //https://leetcode.com/problems/super-egg-drop/solution/
    class Program
    {
        static void Main(string[] args)
        {
            var test = new Solution().EggDrop(2, 6);
        }
    }

    class Solution
    {
        public int EggDrop(int eggs, int floors)
        {
            int[,] memo = new int[eggs + 1, floors + 1];

            return EggDropCount(eggs, floors, memo);
        }

        private int EggDropCount(int eggs, int floors, int[,] memo)
        {
            if (memo[eggs, floors] > 0)
            {
                return memo[eggs, floors];
            }

            for (int i = 1; i <= eggs; i++)
            {
                for (int j = 1; j <= floors; j++)
                {
                    if (i == 1)
                    {
                        memo[i, j] = j;
                    }
                    else if (i > j)
                    {
                        memo[i, j] = memo[i - 1, j];
                    }
                    else
                    {
                        int result = int.MaxValue;
                        for (int k = 1; k <= j; k++)
                        {
                            result = Math.Min(result, Math.Max(EggDropCount(i - 1, k - 1, memo), EggDropCount(i, j - k, memo)));
                        }
                        memo[i, j] = 1 + result;
                    }
                }
            }
            return memo[eggs, floors];
        }
    }
}


