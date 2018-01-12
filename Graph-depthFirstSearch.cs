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
            var e = new Job { Id = "E" };
            var g = new Job { Id = "G" };
            var f = new Job { Id = "F" };
            var d = new Job { Id = "D", Children = new Job[] { e } };
            var b = new Job { Id = "B", Children = new Job[] { d } };
            var c = new Job { Id = "C", Children = new Job[] { d } };
            var a = new Job { Id = "A", Children = new Job[] { b, c } };

            var output = FindOrder(new Job[] {f, g, c, d, b, a, e });
        }

        public static Job[] FindOrder(Job[] input)
        {
            foreach(var job in input)
            {
                PopulateOrder(job);
            }

            return stack.ToArray();
        }

        private static void PopulateOrder(Job job)
        {
            if (job != null)
            {
                if (visited.Contains(job.Id))
                {
                    return;
                }

                if (job.Children != null)
                {
                    foreach (var child in job.Children)
                    {
                        if (!visited.Contains(child.Id))
                        {
                            PopulateOrder(child);
                            visited.Add(child.Id);
                        }
                    }
                }

                stack.Push(job);
                if (!visited.Contains(job.Id))
                {
                    visited.Add(job.Id);
                }
            }
        }

        private static Stack<Job> stack = new Stack<Job>();

        private static HashSet<string> visited = new HashSet<string>();

    }

    public class Job
    {
        public string Id { get; set; }
        public Job[] Children { get; set; }
    }


}