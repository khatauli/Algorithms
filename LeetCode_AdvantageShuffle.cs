
namespace ConsoleApp3
{
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Threading.Tasks;

    //https://leetcode.com/problems/advantage-shuffle/solution/
    class Program
    {
        static void Main(string[] args)
        {
            var result = new Solution().AdvantageShuffle(new int[] { 12, 24, 8, 32 }, new int[] { 13, 25, 32, 11 });
        }
    }

    class Solution
    {
        public int[] AdvantageShuffle(int[] A, int[] B)
        {
            var A_sorted = A.OrderBy(x => x).ToArray();
            var B_sorted = B.OrderBy(x => x).ToArray();
            var remaining = new List<int>();
            var mapping = new Dictionary<int, int>();

            var index_a = 0;
            var index_b = 0;
            while (true)
            {
                if (index_a < A_sorted.Length)
                {
                    var a = A_sorted[index_a++];
                    var b = B_sorted[index_b];

                    if (b < a)
                    {
                        mapping.Add(b, a);
                        index_b++;
                    }
                    else
                    {
                        remaining.Add(a);
                    }
                }
                else
                {
                    break;
                }
            }

            var remainingIndex = 0;

            for(var i = 0; i < B.Length; i++)
            {
                if (mapping.ContainsKey(B[i]))
                {
                    A[i] = B[i];
                }
                else
                {
                    A[i] = remaining[remainingIndex++];
                }
            }

            return A;
        }
    }
}


