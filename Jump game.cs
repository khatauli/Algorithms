using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/jump-game/description/
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[] { 2, 3, 1, 1, 4 };
            
            //arr = new int[] { 3, 2, 1, 0, 4 };
            var result = CanJump(arr);
        }


        public static bool CanJump(int[] arr)
        {
            var t = new bool[arr.Length + 1];
            t[0] = true;
            for (int i = 1; i <= arr.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    var currentStatus = t[j] && arr[j] >= (i - j);
                    t[i] = t[i] || currentStatus;
                }
            }

            return t[arr.Length];
        }
    } 
}