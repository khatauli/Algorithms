using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 0, 1, 2, 0, 1, 2, 0, 1, 2, 0, 1, 2, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2 };

            DutchFlagAlgo(array);

        }

        //this works for negative as well the positive numbersA
        static void DutchFlagAlgo(int[] array)
        {
            int p1 = 0;
            int p2 = array.Length - 1;

            for (int i = 0; i < array.Length; i++)
            {
                if (i >= p2) break;

                int val = array[i];

                if (val == 0)
                {
                    if (i > p1)
                    {
                        array[i] = array[p1];
                        array[p1] = val;
                    }
                    p1++;
                }
                else if (val == 2)
                {
                    array[i] = array[p2];
                    array[p2] = val;
                    p2--;
                    i--;
                }
            }
        }
    }
}