using System;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string phonenumber = "425";
            var result = ConvertToCombination(phonenumber);
        }

        private static List<string> ConvertToCombination(string phonenumber)
        {
            var mapping = new Dictionary<char, string>
            {
                { '1', "ab" },
                { '2', "cd" },
                { '3', "ef" },
                { '4', "gh" },
                { '5', "ij" },
                { '6', "kl" }
            };
            var result = new List<string>();
            ConvertRecursive(phonenumber, "", mapping, result);
            return result;
        }

        private static void ConvertRecursive(string phoneNumber, string currentPAttern, Dictionary<char, string> mapping, List<string> result)
        {
            var currentIndex = currentPAttern.Length;
            foreach (var ch in mapping[phoneNumber[currentIndex]])
            {
                var newString = currentPAttern + ch;
                if (currentIndex == phoneNumber.Length - 1)
                {
                    result.Add(newString);
                }
                else
                {
                    ConvertRecursive(phoneNumber, newString, mapping, result);
                }
            }
        }
    }
}