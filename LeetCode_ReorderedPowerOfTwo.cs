
namespace ConsoleApp3
{
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Threading.Tasks;

    //https://leetcode.com/problems/reordered-power-of-2/solution/
    class Program
    {
        static void Main(string[] args)
        {
            var result = new Solution().reorderedPowerOf2(2410);
        }
    }

    class Solution
    {
        public bool reorderedPowerOf2(int number)
        {
            var intString = $"{number}";
            var intArray = new int[intString.Length];
            int i = 0;
            foreach(char c in intString)
            {
                intArray[i++] = int.Parse($"{c}");
            }

            return Permutations(intArray, 0);
        }

        private bool Permutations(int[] ar, int startIndex)
        {
            if (startIndex == ar.Length - 1)
            {
                if (IsPowerOfTwo(ConvertToInt(ar)))
                {
                    return true;
                }
            }

            for (var i = startIndex; i < ar.Length; i++)
            {
                Swap(ar, startIndex, i);
                if (Permutations(ar, startIndex + 1))
                {
                    return true;
                }
                Swap(ar, startIndex, i);
            }

            return false;
        }

        private int ConvertToInt(int[] ar)
        {
            if (ar[0] == 0)
            {
                return 0;
            }

            int result = 0;
            foreach(int d in ar)
            {
                result = result * 10 + d;
            }
            return result;
        }

        public void Swap(int[] ar, int i1, int i2)
        {
            ar[i1] = ar[i1] ^ ar[i2];
            ar[i2] = ar[i1] ^ ar[i2];
            ar[i1] = ar[i1] ^ ar[i2];
        }

        private bool IsPowerOfTwo(int n)
        {
            if (n <= 0)
            {
                return false;
            }

            return ((n & (n - 1)) == 0);
        }
    }
}


