using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    //https://leetcode.com/problems/find-and-replace-pattern/description/
    class Program
    {
        static void Main(string[] args)
        {
            var test = new Solution().ReturnPatternMatch(new string[] { "abc", "deq", "mee", "aqq", "dkd", "ccc" }, "ttt");
        }
    }
    class Solution
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <returns>Returns the count of fruits in the basket</returns>
        public string[] ReturnPatternMatch(string[] a, string pattern)
        {
            var result = new List<string>();
            foreach(var input in a)
            {
                if (input.Length != pattern.Length)
                {
                    continue;
                }

                var length = pattern.Length;
                var mapping_PatternToInput = new Dictionary<char, char>();
                var mapping_InputTpPattern = new Dictionary<char, char>();

                var mappedWord = new StringBuilder();
                bool isMatch = true;
                for (int i= 0; i < length; i++){
                    if (!mapping_PatternToInput.ContainsKey(pattern[i]))
                    {
                        mapping_PatternToInput.Add(pattern[i], input[i]);
                        if (mapping_InputTpPattern.ContainsKey(input[i]))
                        {
                            isMatch = false;
                            break;
                        }
                        mapping_InputTpPattern.Add(input[i], pattern[i]);
                        mappedWord.Append(input[i]);
                    }
                    else
                    {
                        mappedWord.Append(mapping_PatternToInput[pattern[i]]);

                    }
                }
                if (isMatch && mappedWord.ToString() == input)
                {
                    result.Add(input);
                }
            }
            return result.ToArray();
        }
    }
}


