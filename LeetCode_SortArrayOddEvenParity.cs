using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new Solution().ArraySortParity(new int[] { 1, 3, 5, 7, 9, 2, 4, 6, 8, 2 });
        }

        class Solution
        {
            public int[] ArraySortParity(int[] a)
            {
                if (a == null) return a;

                int i = 0;
                int j = a.Length - 1;

                while (i < j)
                {
                    if (IsEven(a[i]))
                    {
                        i++;
                        continue;
                    }
                    if (!IsEven(a[j]))
                    {
                        j--;
                        continue;
                    }

                    Swap(i, j, a);
                }

                return a;
            }

            private static bool IsEven(int num)
            {
                int result = num % 2;
                return result == 0;
            }

            private static void Swap(int i, int j, int[] a)
            {
                int temp = a[i];
                a[i] = a[j];
                a[j] = temp;
            }
        }
    }
}
