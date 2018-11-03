
namespace ConsoleApp3
{
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Threading.Tasks;

    //https://leetcode.com/problems/binary-tree-pruning/description/
    class Program
    {
        static void Main(string[] args)
        {
            var n7 = new Node(1);
            var n6 = new Node(0);
            var n4 = new Node(0);
            var n5 = new Node(0);
            var n2 = new Node(0, n4, n5);
            var n3 = new Node(1, n6, n7);
            var n1 = new Node(1, n2, n3);


            //var result = new Solution().numFriendRequests(new int[] { 1, 5, 6, 8, 15, 16, 25, 20, 75, 65, 65, 98, 87, 67, 45, 34, 23, 45, 73, 38, 38, 96, 67, 91, 92, 63, 64, 65, 75, 85, 86, 86, 86, 84, 93 });
            var value = new Solution().CleanTree(n1);
        }
    }

    class Node
    {
        public Node(int value, Node left = null, Node right = null)
        {
            this.Value = value;
            this.Left = left;
            this.Right = right;


        }
        public int Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
    }

    class Solution
    {
        public Node CleanTree(Node root)
        {
            return removeMe(root) ? null : root;
        }

        public bool removeMe(Node n)
        {
            if (n == null) return true;

            var removeLeft = removeMe(n.Left);
            var removeRight = removeMe(n.Right);

            if (removeLeft)
            {
                n.Left = null;
            }

            if (removeRight)
            {
                n.Right = null;
            }

            return n.Value == 0 && removeLeft && removeRight;
        }
    }
}