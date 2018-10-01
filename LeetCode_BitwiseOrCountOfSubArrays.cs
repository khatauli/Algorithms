using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    //https://leetcode.com/problems/bitwise-ors-of-subarrays/solution/
    class Program
    {
        static void Main(string[] args)
        {
            var test = new Solution().CountOfUniqueBitWiseOrs(new int[] { 0, 1, 2, 3, 8 });
        }
    }
    class Solution
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <returns>Returns the count of fruits in the basket</returns>
        public int CountOfUniqueBitWiseOrs(int[] a)
        {
            var totalset = new HashSet<int>();
            var cur = new HashSet<int>();

            cur.Add(0);

            for (int i = 0; i < a.Length; i++)
            {
                var temp = new HashSet<int>();
                foreach (int j in cur)
                {
                    temp.Add(j | a[i]);
                }
                cur = temp;

                foreach (int j in cur)
                {
                    totalset.Add(j);
                }
            }

            return totalset.Count;
        }
    }
}


