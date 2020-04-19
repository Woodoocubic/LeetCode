using System;

namespace LeetCodeDiameterOfBinTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right; 
            public TreeNode(int x) { val = x; }
        }

        private int maxDiameter = 0;
        public int DiameterOfBinaryTree(TreeNode root)
        {
            MaxDepth(root);
            return maxDiameter;
        }

        private int MaxDepth(TreeNode node)
        {
            if (node == null)
            {
                return 0;
            }

            int maxDepthOfLeftSubtree = MaxDepth(node.left);
            int maxDepthOfRightSubtree = MaxDepth(node.right);

            maxDiameter = Math.Max(maxDiameter, maxDepthOfRightSubtree + maxDepthOfLeftSubtree);

            return Math.Max(maxDepthOfLeftSubtree, maxDepthOfRightSubtree) + 1;
        }
    }
}
