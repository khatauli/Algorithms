using System;
using System.Collections.Generic;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var avlTree = new AVLTree();

            avlTree.Insert(6);
            avlTree.Insert(5);
            avlTree.Insert(4);
            avlTree.Insert(3);
            avlTree.Insert(2);
            avlTree.Insert(1);
            avlTree.Insert(-1);
            avlTree.Insert(-2);
            avlTree.Insert(-3);
        }

    }

    public class AVLTree
    {
        public Node Root { get; private set; }

        public void Insert(int value)
        {
            Root = InsertNode(Root, value);
        }

        private Node InsertNode(Node node, int value)
        {

            /* 1.  Perform the normal BST insertion */
            if (node == null)
            {
                var newNode = new Node(value);
                newNode.Height = 1;
                return newNode;
            }

            if (value < node.Value)
                node.Left = InsertNode(node.Left, value);
            else if (value > node.Value)
                node.Right = InsertNode(node.Right, value);
            else // Duplicate keys not allowed
                return node;

            /* 2. Update height of this ancestor node */
            node.Height = 1 + Math.Max(height(node.Left),
                                  height(node.Right));

            /* 3. Get the balance factor of this ancestor
                  node to check whether this node became
                  unbalanced */
            int balance = getBalance(node);

            // If this node becomes unbalanced, then there
            // are 4 cases Left Left Case
            if (balance > 1 && value < node.Left.Value)
                return RightRotate(node);

            // Right Right Case
            if (balance < -1 && value > node.Right.Value)
                return LeftRotate(node);

            // Left Right Case
            if (balance > 1 && value > node.Left.Value)
            {
                node.Left = LeftRotate(node.Left);
                return RightRotate(node);
            }

            // Right Left Case
            if (balance < -1 && value < node.Right.Value)
            {
                node.Right = RightRotate(node.Right);
                return LeftRotate(node);
            }

            /* return the (unchanged) node pointer */
            return node;
        }

        // Get Balance factor of node N
        int getBalance(Node N)
        {
            if (N == null)
                return 0;

            return height(N.Left) - height(N.Right);
        }

        Node RightRotate(Node y)
        {
            Node x = y.Left;
            Node T2 = x.Right;

            // Perform rotation
            x.Right = y;
            y.Left = T2;

            // Update heights
            y.Height = Math.Max(height(y.Left), height(y.Right)) + 1;
            x.Height = Math.Max(height(x.Left), height(x.Right)) + 1;

            // Return new root
            return x;
        }

        // A utility function to Left rotate subtree rooted with x
        // See the diagram given above.
        Node LeftRotate(Node x)
        {
            Node y = x.Right;
            Node T2 = y.Left;

            // Perform rotation
            y.Left = x;
            x.Right = T2;

            //  Update heights
            x.Height = Math.Max(height(x.Left), height(x.Right)) + 1;
            y.Height = Math.Max(height(y.Left), height(y.Right)) + 1;

            // Return new root
            return y;
        }
        private int height(Node node)
        {
            if (node == null)
                return 0;

            return node.Height;
        }

    }

    public class Node
    {
        public Node(int value)
        {
            this.Value = value;
        }

        public Node Left { get; set; }
        public Node Right { get; set; }
        public int Value { get; set; }
        public int Height { get; set; }
    }
}