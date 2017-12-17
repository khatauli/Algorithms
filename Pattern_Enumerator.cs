using System;
using System.Collections;
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
            var bst = new BST();
            
            //two ways to implement this.
            //1.
            foreach (int n in bst.NodeList())
            {
                Console.WriteLine($"{n}, ");
            }

            //two ways to implement this.
            //1.
            foreach (int n in bst.RecursiveNodeList())
            {
                Console.WriteLine($"{n}, ");
            }

            // Using IEnumerator / IEnumerable
            foreach (Node n in bst)
            {
                Console.WriteLine($"{n.Value}, ");
            }

            //Or we can also call it like this.
            while (bst.MoveNext())
            {
                Node value = ((IEnumerator<Node>)bst).Current;
                Console.WriteLine($"{value.Value}, ");
            }
        }
    }

    internal class BST : IEnumerator<Node>, IEnumerable<Node>
    {
        private Node Root { get; set; }

        private Node currentNode { get; set; }
        public Node Next { get; set; }

        Node IEnumerator<Node>.Current => this.currentNode;

        object IEnumerator.Current => this.currentNode;

        public BST()
        {
            Node node1 = new Node { Value = 1 };
            Node node3 = new Node { Value = 3 };
            Node node6 = new Node { Value = 6 };
            Node node4 = new Node { Value = 4, Left = node3, Right = node6 };
            Node node2 = new Node { Value = 2, Left = node1, Right = node4 };
            Node node10 = new Node { Value = 10 };
            Node node13 = new Node { Value = 13 };
            Node node25 = new Node { Value = 25 };
            Node node11 = new Node { Value = 11, Left = node10, Right = node13 };
            Node node20 = new Node { Value = 20, Left = node11, Right = node25 };
            Root = new Node { Value = 8, Left = node2, Right = node20 };

            Next = Root;
        }

        public void Dispose()
        {
            this.Reset();
        }

        public bool MoveNext()
        {
            Node curr = this.Next;
            if (curr == null)
            {
                this.Reset(); // note that we are resetting it here.
                return false;
            }

            while (true)
            {
                if (curr.Left != null)
                {
                    Node pred = GetPred(curr);
                    if (pred.Right == null)
                    {
                        pred.Right = curr;
                        curr = curr.Left;
                    }
                    else
                    {
                        pred.Right = null;
                        this.currentNode = curr; ////
                        this.Next = curr.Right;
                        break;
                    }
                }
                else
                {
                    this.currentNode = curr; ////
                    this.Next = curr.Right;
                    break;
                }
            }
            return (this.currentNode != null);
        }

        public IEnumerable<int> NodeList()
        {
            Node curr = this.Root;

            while (curr != null)
            {
                if (curr.Left != null)
                {
                    Node pred = GetPred(curr);
                    if (pred.Right == null)
                    {
                        pred.Right = curr;
                        curr = curr.Left;
                    }
                    else
                    {
                        pred.Right = null;
                        yield return curr.Value;
                        curr = curr.Right;
                    }
                }
                else
                {
                    yield return curr.Value;
                    curr = curr.Right;
                }
            }
        }

        public IEnumerable<int> RecursiveNodeList()
        {
            return inorderTraverse(this.Root);
        }

        private IEnumerable<int> inorderTraverse(Node n)
        {
            if (n != null)
            {
                inorderTraverse(n.Left);
                //yield return n.Value;
                inorderTraverse(n.Right);
            }
            yield return -1;
        }

        private Node GetPred(Node curr)
        {
            Node left = curr.Left;
            while (left.Right != null && left.Right.Value < curr.Value)
            {
                left = left.Right;
            }
            return left;
        }

        public void Reset()
        {
            this.Next = Root;
            this.currentNode = null;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }

        public IEnumerator<Node> GetEnumerator()
        {
            return this;
        }
    }

    internal class Node
    {
        public int Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
    }
}
