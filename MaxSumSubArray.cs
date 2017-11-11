using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { -3, -5, -8, 6, -1, -3, -8 };

            var value = ReturnSubarray(array);

        }
        //this works for negative as well the positive numbersA
        static int[] ReturnSubarray(int[] array)
        {
            int maxSum = int.MinValue;
            int maxStart = 0;
            int maxEnd = 0;

            int currentSum = 0;
            int currentStart = 0;
            for (int i = 0; i < array.Length; i++)
            {
                currentSum += array[i];

                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    maxStart = currentStart;
                    maxEnd = i;
                }

                if (currentSum < 0)
                {
                    currentStart = i + 1;
                    currentSum = 0;
                }
            }

            return null;
        }

    }
}