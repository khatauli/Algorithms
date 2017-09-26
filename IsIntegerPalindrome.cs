using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    //https://leetcode.com/problems/palindrome-number/solution/
    class Program
    {
        static void Main(string[] args)
        {
            var result = IsNumberPalindrome(123321);
        }

        public static bool IsNumberPalindrome(int number)
        {
            if (number < 0 || (number % 10 == 0 && number != 0))
            {
                return false;
            }

            var result = 0;

            while (result < number)
            {
                result = result * 10 + number % 10;
                number /= 10;
            }

            return result == number || number == result/10;
        }
    }
}