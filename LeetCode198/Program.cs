﻿using System;

namespace LeetCode198
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            int[] input = new int[] {2, 7, 9, 3, 1};
            Console.WriteLine(program.Rob(input));
        }

        public int Rob(int[] nums)
        {
            if (nums.Length == 0) return 0;
            if (nums.Length == 1) return nums[0];
            
            int[] dp = new int[nums.Length];

            dp[0] = nums[0];
            dp[1] = Math.Max(nums[0], nums[1]);

            for (int i = 2; i < nums.Length; i++)
            {
                dp[i] = Math.Max(nums[i] + dp[i - 2], dp[i-1]);
            }

            return dp[nums.Length - 1];
        }
    }
}
