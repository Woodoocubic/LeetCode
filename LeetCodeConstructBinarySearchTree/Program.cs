using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

namespace LeetCodeConstructBinarySearchTree
{
    class Program
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int x)
            {
                val = x;
            }
        }

        static void Main(string[] args)
        {
            var program = new Program();
            var input = new int[] {8, 5, 1, 7, 10, 12};
            var result = program.BstFromPreorder(input);
            Console.WriteLine("Hello World!");
        }

        public TreeNode BstFromPreorder(int[] preorder)
        {
            return preorderTraversal(new List<int>(preorder));
        }

        private static TreeNode preorderTraversal(IList<int> numbers)
        {
            if (numbers == null || numbers.Count == 0)
            {
                return null;
            }

            var rootValue = numbers[0];
            var root = new TreeNode(rootValue);
            var leftList = new List<int>();
            var rightList = new List<int>();

            for (int i = 1; i < numbers.Count; i++)
            {
                var current = numbers[i];
                if (current < rootValue)
                {
                    leftList.Add(current);
                }
                else
                {
                    rightList.Add(current);
                }
            }

            root.left = preorderTraversal(leftList);
            root.right = preorderTraversal(rightList);

            return root;
        }
    }
}
