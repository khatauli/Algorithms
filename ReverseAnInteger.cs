using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    //https://leetcode.com/problems/reverse-integer/solution/
    class Program
    {
        static void Main(string[] args)
        {
           var result = ReverseInteger(-1238796);
        }


        public static int ReverseInteger(int number)
        {
            var result = 0;
            while (number != 0)
            {
                result = result * 10 + number % 10;
                number /= 10;
            }

            return result;
        }
    }
}
