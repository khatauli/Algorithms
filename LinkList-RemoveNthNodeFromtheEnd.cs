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
            public Node Next { get; set; }
        }

        static void Main(string[] args)
        {
            var n1 = new Node { Value = 1 };
            var n2 = new Node { Value = 2, Next = n1 };
            var n3 = new Node { Value = 3, Next = n2 };
            var n4 = new Node { Value = 4, Next = n3 };
            //var n5 = new Node { Value = 5, Next = n4 };
            //var n6 = new Node { Value = 6, Next = n5 };
            //var n7 = new Node { Value = 7, Next = n6 };
            //var n8 = new Node { Value = 8, Next = n7 };
            //var n9 = new Node { Value = 9, Next = n8 };

            var result = RemoveNthNode(n4, 5);

        }

        private static Node RemoveNthNode(Node root, int n)
        {
            var ps = root;
            var pe = root;

            var count = 0;
            
            while (pe != null)
            {
                count++;
                pe = pe.Next;

                if (count > n + 1)
                {
                    ps = ps.Next;
                }
            }

            if (count < n)
            {
                throw new ArgumentException("n is bigger than the length");
            }

            if (count == n)
            {
                var next = root.Next;
                root.Next = null;
                return next;
            }

            DeleteNextNode(ps);

            return root;
        }

        private static void DeleteNextNode(Node n)
        {
            if (n == null || n.Next == null)
            {
                throw new ArgumentException("can not delete since there is no next node");
            }

            var next = n.Next;
            n.Next = next.Next;
            next.Next = null;
        }
    }
}