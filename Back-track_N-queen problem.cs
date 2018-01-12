using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = SolveChess(8);
        }


        public static int SolveChess(int rows)
        {
            var chess = new bool[rows, rows];
            var successCount = 0;
            SolutionCounts(chess, 0, ref successCount);

            return successCount;
        }


        private static bool SolutionCounts(bool[,] chess, int rowIndex, ref int successCount)
        {
            bool success = false;
            for (int i = 0; i < chess.GetLength(0); i++)
            {
                if (IsValidMove(chess, rowIndex, i))
                {
                    chess[rowIndex, i] = true;
                    if (rowIndex == chess.GetLength(0) - 1)
                    {
                        successCount++;
                        success = true;

                        PrintChess(chess);
                    }
                    else
                    {
                        success = SolutionCounts(chess, rowIndex + 1, ref successCount);
                    }
                }
                chess[rowIndex, i] = false;
            }

            return success;
        }

        private static void PrintChess(bool[,] chess)
        {
            for (int i = 0; i < chess.GetLength(0); i++)
            {
                for (int j = 0; j < chess.GetLength(0); j++)
                {
                    var val = chess[i, j] ? 1 : 0;

                    Console.Write($"{val}\t");

                }
                Console.WriteLine("");
                Console.WriteLine("");
            }
            Console.WriteLine("------------------------------------------------------------------------");

        }

        private static bool IsValidMove(bool[,] chess, int rowIndex, int colIndex)
        {
            //check row
            for(int i=0;i< chess.GetLength(0); i++)
            {
                if (chess[rowIndex,i] == true || chess[i, colIndex] == true)
                {
                    return false;
                }
            }

            int currentRow = rowIndex;
            int currentCol = colIndex;
            while (currentRow >= 0 && currentRow < chess.GetLength(0) && currentCol >= 0 && currentCol < chess.GetLength(0))
            {

                if (chess[currentRow, currentCol] == true)
                {
                    return false;
                }
                currentRow--;
                currentCol--;
            }

            currentRow = rowIndex;
            currentCol = colIndex;
            while (currentRow >= 0 && currentRow < chess.GetLength(0) && currentCol >= 0 && currentCol < chess.GetLength(0))
            {

                if (chess[currentRow, currentCol] == true)
                {
                    return false;
                }
                currentRow--;
                currentCol++;
            }

            currentRow = rowIndex;
            currentCol = colIndex;
            while (currentRow >= 0 && currentRow < chess.GetLength(0) && currentCol >= 0 && currentCol < chess.GetLength(0))
            {

                if (chess[currentRow, currentCol] == true)
                {
                    return false;
                }
                currentRow++;
                currentCol++;
            }

            currentRow = rowIndex;
            currentCol = colIndex;
            while (currentRow >= 0 && currentRow < chess.GetLength(0) && currentCol >= 0 && currentCol < chess.GetLength(0))
            {

                if (chess[currentRow, currentCol] == true)
                {
                    return false;
                }
                currentRow++;
                currentCol--;
            }
            return true;
        }
    }
}