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

            var graph = new Graph();
            var sorted = graph.TopologicalSort();
        }

        public class Node
        {
            public string Name { get; set; }
            public List<Node> children { get; set; }

            public override string ToString()
            {
                return Name;
            }
        }

        public class Graph
        {
            private List<Node> nodes;

            private Stack<Node> explored;
            private HashSet<Node> visited;
            
            public Graph()
            {
                var G = new Node { Name = "G", children = new List<Node>() };
                var H = new Node { Name = "H", children = new List<Node>() };
                var F = new Node { Name = "F", children= new List<Node> { G} };
                var E = new Node { Name = "E", children = new List<Node> { H, F } };
                var D = new Node { Name = "D", children = new List<Node> { F } };
                var C = new Node { Name = "C", children = new List<Node> { E } };
                var B = new Node { Name = "B", children = new List<Node> { C, D } };
                var A = new Node { Name = "A", children = new List<Node> { C } };
                nodes = new List<Node> { G, E, C, F, D, B, A, H};
            }

            public List<Node> TopologicalSort()
            {
                explored = new Stack<Node>();
                visited = new HashSet<Node>();

                foreach (var node in nodes)
                {
                    Explore(node);
                }

                return explored.ToList();
            }

            private void Explore(Node n)
            {
                if (visited.Add(n))
                {
                    foreach (var child in n.children)
                    {
                        Explore(child);
                    }
                    explored.Push(n);
                }
            }
        }
    }
}
