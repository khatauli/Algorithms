using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    //https://www.youtube.com/watch?v=LBsvAwQbVdw
    class Program
    {
        private static int[] values = new int[] { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
        private static string[] romans = new string[] { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I"};

        static void Main(string[] args)
        {
            var input = 3999;
            var result = ConvertToRoman(input);
            var result2 = ConvertRomanToNumeral(result);
        }

        public static int ConvertRomanToNumeral(string roman)
        {
            var result = 0;
            var pointer = 0;

            while (roman.Length > 0)
            {
                if (roman.IndexOf(romans[pointer]) == 0)
                {
                    result += values[pointer];
                    roman = roman.Remove(0, romans[pointer].Length);
                }
                else
                {
                    pointer++;
                }
            }
            return result;
        }
            public static string ConvertToRoman(int number)
        {
            var result = new StringBuilder();
            var pointer = 0;

            while(number > 0)
            {
                if (number >= values[pointer])
                {
                    number = number - values[pointer];
                    result.Append(romans[pointer]);
                }
                else
                {
                    pointer++;
                }
            }

            return result.ToString();
        }
    }
}