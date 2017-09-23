using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://leetcode.com/problems/zigzag-conversion/description/
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
           var result = ZigZagWriting("PAYPALISHIRING", 4);
        }


        public static String ZigZagWriting(String s, int rows)
        {
            var columns = (s.Length - 1 )/ (rows -1);
            var rem = (s.Length - 1) % (rows-1);
            if (rem > 0)
            {
                columns++;
            }

            var matrix = new char[rows, columns];

            var currentRow = 0;
            var currentColumn = 0;
            var downDirection = true;
            for (int i = 0; i < s.Length; i++)
            {
                matrix[currentRow, currentColumn] = s[i];
                if (downDirection)
                {

                    if (currentRow == rows - 1)
                    {
                        currentColumn++;
                        currentRow--;
                        downDirection = false;
                    }
                    else
                    {
                        currentRow++;
                    }
                }
                else
                {
                    if (currentRow == 0)
                    {
                        currentColumn++;
                        currentRow++;
                        downDirection = true;
                    }
                    else
                    {
                        currentRow--;
                    }
                }
            }

            return printMatrix(matrix);
        }

        
        private static string printMatrix(char [,] matrix)
        {
            var builder = new StringBuilder();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] != '\0')
                    {
                        builder.Append(matrix[i, j]);
                    }
                }
            }
            return builder.ToString();
            
        }
    }
}
