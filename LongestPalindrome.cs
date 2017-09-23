using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	//https://leetcode.com/problems/longest-palindromic-substring/description/
    class Program
    {
        static void Main(string[] args)
        {
           var result = LongestPalindrome("abaxabaxabybaxabyb");
           //var result = LongestPalindrome("abcdef");
        }


        public static String LongestPalindrome(String s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return s;
            }
            var start = 0;
            var end  = 0;
            for (int i = 0; i < s.Length; i++)
            {
                var distance = 0;
                while (i - distance >= 0 && 
                    i + distance < s.Length &&
                    s[i-distance] == s[i+distance])
                {
                    if ((end - start) < (distance * 2))
                    {
                        start = i - distance;
                        end = i + distance;
                    }
                    distance++;
                }
            }

            return s.Substring(start, end - start + 1);
        }
    }
}
