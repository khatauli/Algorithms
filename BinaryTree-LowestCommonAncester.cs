using System;
using System.Collections.Generic;
using System.Threading;

namespace ConsoleApp2
{
    class Program
    {
        class Node
        {
            public int Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
        }

        static void Main(string[] args)
        {
            Node n2 = new Node { Value = 2 };
            Node n9 = new Node { Value = 9 };
            Node n5 = new Node { Value = 5 };
            Node n7 = new Node { Value = 7 };
            Node n11 = new Node { Value = 11, Left = n9, Right = n5 };
            Node n13 = new Node { Value = 13, Left = n7};
            Node n6 = new Node { Value = 6, Left = n2, Right = n11 };
            Node n8 = new Node { Value = 8, Right = n13 };
            Node n3 = new Node { Value = 3, Left = n6, Right = n8 };

            var result = LowestCommonAncestor(n3, 7, 13);
        }

        private static Node LowestCommonAncestor(Node node, int first, int second)
        {
            if (node == null)
            {
                return null;
            }
            if (node.Value == first || node.Value == second)
            {
                return node;
            }

            var leftResult = LowestCommonAncestor(node.Left, first, second);
            var rightResult = LowestCommonAncestor(node.Right, first, second);

            if (leftResult != null && rightResult != null)
            {
                return node;
            }
            else
            {
                return leftResult == null ? rightResult : leftResult;
            }
        }
    }
}