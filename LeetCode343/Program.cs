using System;
using System.Security.Cryptography;

namespace LeetCode343
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            int input = 5;
            Console.WriteLine(program.IntegerBreak(5));
        }

        public int IntegerBreak(int n)
        {
            int[] dp = new int[n + 1];
            dp[1] = 1;
            for (int i = 1; i < dp.Length; i++)
            {
                for (int j = 1; j < i; j++)
                {
                    //dp[i]表示对于的整数i的最大成绩,i由j和j-i拆分，看哪个更大
                    dp[i] = Math.Max(dp[i], j*(i-j));
                    //dp[i]的值，应该是dp[i-j]*j,[1,i-1]范围内的最大值
                    dp[i] = Math.Max(dp[i], j * dp[i - j]);
                }
            }
            return dp[n];
        }
    }
}
