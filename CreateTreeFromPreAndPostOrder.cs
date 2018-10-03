using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    //https://leetcode.com/problems/find-and-replace-pattern/description/
    class Program
    {
        static void Main(string[] args)
        {
            var test = new Solution().ConstructFromPrePost(new int[] { 1, 2, 4, 5, 3, 6, 7 }, new int[] { 4, 5, 2, 6, 7, 3, 1 });
        }
    }

    public class TreeNode
    {
        public TreeNode(int val)
        {
            this.val = val;
        }

        public int val { get; set; }
        public TreeNode left { get; set; }
        public TreeNode right { get; set; }
    }

    class Solution
    {
        public TreeNode ConstructFromPrePost(int[] pre, int[] post)
        {
            int i = 0;
            int j = 0;
            return ConstructTree(pre, ref i, post, ref j);
        }

        private TreeNode ConstructTree(int[] pre, ref int i, int[] post, ref int j)
        {
            TreeNode node = new TreeNode(pre[i++]);
            if (node.val == post[j])
            {
                j++;
                return node;
            }
            node.left = ConstructTree(pre, ref i, post, ref j);
            if (node.val == post[j])
            {
                j++;
                return node;
            }
            node.right = ConstructTree(pre, ref i, post, ref j);
            j++;
            return node;
        }
    }
}


