
namespace ConsoleApp3
{
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            //var result = new Solution().BinaryGap(5);

            var edges = new Edge[]
            {
                new Edge(0, 1, 4),
                new Edge(0, 2, 5),
                new Edge(1, 2, -3),
                new Edge(2, 4, 4),
                new Edge(0, 3, 8),
                new Edge(3, 4, 2),
                new Edge(4, 3, 1),
            };

            var result = new Solution().ShortestPath(new int[] { 0, 1, 2, 3, 4, }, edges);
        }
    }

    class Solution
    {
        Dictionary<int, int> distanceMap = new Dictionary<int, int>();
        Dictionary<int, int> viaMap = new Dictionary<int, int>();

        public int[] ShortestPath(int[] nodes, Edge[] edges)
        {
            foreach(int node in nodes)
            {
                distanceMap.Add(node, int.MaxValue);
            }
            distanceMap[nodes[0]] = 0;
            viaMap.Add(nodes[0], nodes[0]);
            
            for(int i = 0; i< nodes.Length -1; i++)
            {
                foreach(var edge in edges)
                {
                    Relax(edge);
                }
            }

            return null;
        }


        private void Relax(Edge edge)
        {
            int distance_v = distanceMap[edge.u] + edge.Weight;

            if (distance_v < distanceMap[edge.v])
            {
                distanceMap[edge.v] = distance_v;
                viaMap[edge.v] = edge.u;
            }
        }
    }

    public class Edge
    {
        public int u { get; set; }
        public int v { get; set; }
        public int Weight { get; set; }

        public Edge(int from, int to, int weight)
        {
            this.u = from;
            this.v = to;
            this.Weight = weight;
        }
    }
}
