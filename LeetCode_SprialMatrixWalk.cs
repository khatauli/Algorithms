using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    //https://leetcode.com/problems/spiral-matrix-iii/description/
    class Program
    {
        static void Main(string[] args)
        {
            var test = new Solution().SpiralMatrixWalk(5, 6, new Point { r = 1, c = 4 });
        }
    }

    class Point
    {
        public int r { get; set; }
        public int c { get; set; }

        public override string ToString()
        {
            return $"[{r},{c}]";
        }
    }
    class Solution
    {
        public Point[] SpiralMatrixWalk(int R, int C, Point start)
        {
            int totalPoints = R * C;
            var toReturn = new List<Point> { start };
            var stepSize = 0;
            var round = 0; 
            var direction = 0;
            var currentPoint = start;
            while (toReturn.Count < totalPoints)
            {
                if (round == 0)
                {
                    stepSize++;
                }
                round = NextRound(round);
                
                for(int i = 0; i < stepSize; i++)
                {
                    var newPoint = GetNextPoint(currentPoint, direction);
                    currentPoint = newPoint;
                    if (IsPointInRange(R, C, newPoint))
                    {
                        toReturn.Add(newPoint);
                        if (toReturn.Count == totalPoints)
                        {
                            break;
                        }
                    }
                }
                direction = newDirection(direction);
            }

            return toReturn.ToArray();
           
        }

        private bool IsPointInRange(int R, int C, Point point)
        {
            return (!(point.r < 0 || point.r >= R || point.c < 0 || point.c >= C));
        }

        private int NextRound(int currentRound)
        {
            return (currentRound + 1) % 2;
        }
        private int newDirection(int currentDir)
        {
            return (currentDir + 1) % 4;
        }

        private Point GetNextPoint(Point current, int direction)
        {
            switch (direction)
            {
                //right
                case (0): return new Point { r = current.r, c = current.c + 1 };
                //down
                case (1): return new Point { r = current.r + 1, c = current.c };
                //left
                case (2): return new Point { r = current.r, c = current.c - 1 };
                //Up
                case (3): return new Point { r = current.r - 1, c = current.c };
                default:
                    throw new ArgumentException("not possible");
            }
        }
    }
}


