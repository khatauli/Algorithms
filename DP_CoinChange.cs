using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    //https://www.youtube.com/watch?annotation_id=annotation_2195265949&feature=iv&src_vid=Y0ZqKpToTic&v=NJuKJ8sasGk
    class Program
    {
        static void Main(string[] args)
        {
            var coins = new int[] { 3, 2, 4 };

            var result = MinimumCoins(11, coins);
        }

        public static int MinimumCoins(int total, int[] coins)
        {
            var t = new int[total+1];
            var r = new int[total+1];
            t[0] = 0;

            for (int i = 1; i <= total; i++)
            {
                t[i] = int.MaxValue - 1;
                r[i] = -1;
            }

            for (int j = 0; j < coins.Length; j++)
            {
                for (int i = 1; i <= total; i++)
                {
                    if (i >= coins[j])
                    {
                        if (t[i] > 1 + t[i - coins[j]])
                        {
                            t[i] = 1+ t[i - coins[j]];
                            r[i] = j;
                        }
                    }
                }
            }
            printCombinations(r);
            return t[total];
        }

        private static void printCombinations(int[] r)
        {
        }
    }
}