using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new int[] { 109, 4, -3, 2, 5, 4, 9, 4, 3, 6, 4, -1, -5, -6, 12, 4, 56, 45, 4 };
            QuickSort(array, 0, array.Length-1);
            Console.WriteLine("Hello World!");
        }
         

        static void QuickSort(int[] a, int low, int high)
        {
            if (low >= high || ((high - low) <= 1 && a[low] <= a[high]))
            {
                return;
            }
            var j = Partition(a, low, high);
            QuickSort(a, low, j - 1);
            QuickSort(a, j + 1, high);
        }

        private static int Partition(int[] a, int low, int high)
        { 
            var i = low;
            var j = high;
            var pivot = a[(low + high) / 2];

            while (i < j)
            {
                if (a[i] < pivot)
                {
                    i++;
                    continue;
                }

                if (a[j] > pivot)
                {
                    j--;
                    continue;
                }
                if (a[i] != a[j])
                {
                    var temp = a[i];
                    a[i] = a[j];
                    a[j] = temp;
                }
                else
                {
                    i++;
                }
            }
            return j;
        }
    }
}