using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new SnakeAndLadder();
            var sorted = game.FindMinimumSteps();
        }
                
        public class SnakeAndLadder
        {
            private int[,] board;

            /// <summary>
            /// In the explored queue, first element is the position on the board, 
            /// and second element is the number of turns it took to reach that position.
            /// </summary>
            private Queue<Tuple<int, int>> explored;

            /// <summary>
            /// it keeps optimizes the position, so that, we don't visit the same cell over and over, because first visit is alwasy going to
            /// be most efficient.            
            /// </summary>
            private HashSet<int> visitedCells;
            public SnakeAndLadder()
            {
                board = new int[6,6]
                {
                    {-1, -1, -1, -1, -1, -1 },
                    {-1, -1, -1, -1, -1, -1 },
                    {-1, -1, -1, -1, -1, -1 },
                    {-1, 35, -1, -1, 13, -1 },
                    {-1, -1, -1, -1, -1, -1 },
                    {-1, 15, -1, -1, -1, -1 }
                };
            }
            
            public int FindMinimumSteps()
            {
                int diceMaxCount = 6;
                explored = new Queue<Tuple<int, int>>();

                visitedCells = new HashSet<int>();

                explored.Enqueue(new Tuple<int, int>(1,0));
                visitedCells.Add(1);
                while (explored.Any())
                {
                    var currentTuple = explored.Dequeue();

                    var firstValue = currentTuple.Item1;
                    var turnCount = currentTuple.Item2;

                    for (int i = 1; i <= diceMaxCount; i++)
                    {
                        int nextValue = firstValue + i;
                        if (nextValue > board.Length)
                        {
                            break;
                        }

                        int cellsValue = GetCellValue(nextValue);
                        nextValue = (cellsValue == -1) ? nextValue : cellsValue;

                        if (nextValue == board.Length)
                        {
                            return turnCount + 1;
                        }

                        if (visitedCells.Add(nextValue))
                        {
                            explored.Enqueue(new Tuple<int, int>(nextValue, turnCount + 1));
                        }
                    }
                }

                return 0;
            }

            /// <summary>
            /// Returns what is the value in the matrix.
            /// </summary>
            /// <param name="index"></param>
            /// <returns></returns>
            private int GetCellValue(int index)
            {
                var tuple = GetArrayIndex(index);
                return board[tuple.Item1, tuple.Item2];
            }

            //position is always positive number, and starts from 1
            private Tuple<int, int> GetArrayIndex(int positionOnBoard)
            {
                int a = board.GetLength(0);
                int b = board.GetLength(1);

                int column = (positionOnBoard - 1) % b;
                int row = (positionOnBoard - 1) / b;

                bool isRowEven = row % 2 == 0;

                int x = a - row - 1;
                int y = isRowEven ? column : b - column - 1;

                return new Tuple<int, int>(x, y);
            }
        }
    }
}
