using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var ar1 = new int[] { 1, 3, 8, 10, 12 };
            //var ar2 = new int[] { 2, 9, 11, 13, 18, 22, 28 };
            var ar2 = new int[] {};
            var result = Merge(ar1, ar2);
        }


        public static int[] Merge(int[] ar1, int[] ar2)
        {
            if (ar1 == null)
            {
                return ar2;
            }
            else if (ar2 == null)
            {
                return ar1;
            }

            var resultArray = new int[ar1.Length + ar2.Length];

            var p1 = 0;
            var p2 = 0;
            var p3 = 0;
            while (p1 < ar1.Length || p2 < ar2.Length)
            {
                var e1 = p1 < ar1.Length ? ar1[p1] : int.MaxValue;
                var e2 = p2 < ar2.Length ? ar2[p2] : int.MaxValue;

                if (e1 < e2)
                {
                    resultArray[p3] = e1;
                    p1++;
                }
                else
                {
                    resultArray[p3] = e2;
                    p2++;
                }
                p3++;
            }

            return resultArray;
        }
    }
}
