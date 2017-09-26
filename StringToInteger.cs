using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    //https://leetcode.com/problems/string-to-integer-atoi/description
    class Program
    {
        static void Main(string[] args)
        {
           var result = StringToInt("    -12387dsdf   ");
        }


        public static int StringToInt(string numberString)
        {
            bool negativeNumber = false;

            var currentNumber = 0;
            for (int i = 0; i < numberString.Length; i++)
            {
                string ch = numberString[i].ToString();
                if (string.IsNullOrWhiteSpace(ch))
                {
                    continue;
                }

                var digit = 0;

                switch (ch)
                {
                    case ("-"):
                        negativeNumber = true;
                        break;
                    case ("0"):
                        digit = 0;
                        break;
                    case ("1"):
                        digit = 1;
                        break;
                    case ("2"):
                        digit = 2;
                        break;
                    case ("3"):
                        digit = 3;
                        break;
                    case ("4"):
                        digit = 4;
                        break;
                    case ("5"):
                        digit = 5;
                        break;
                    case ("6"):
                        digit = 6;
                        break;
                    case ("7"):
                        digit = 7;
                        break;
                    case ("8"):
                        digit = 8;
                        break;
                    case ("9"):
                        digit = 9;
                        break;
                    default:
                        continue;
                }
                try
                {
                    currentNumber = checked(currentNumber * 10 + digit);
                }
                catch (OverflowException)
                {
                    return negativeNumber ? int.MinValue : int.MaxValue;
                }
            }

            return negativeNumber ? currentNumber * -1 : currentNumber;
        }
    }
}
