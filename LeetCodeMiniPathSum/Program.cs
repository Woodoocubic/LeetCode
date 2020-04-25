using System;

namespace LeetCodeMiniPathSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int MinPathSum(int[][] grid)
        {
            var n = grid.Length;
            var m = grid[0].Length;
            var dp = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (i==0&&j==0)
                    {
                        dp[i, j] = grid[i][j];
                    }
                    else if (i == 0)
                    {
                        dp[i, j] = dp[i, j - 1] + grid[i][j];
                    }
                    else if (j == 0)
                    {
                        dp[i, j] = dp[i - 1, j] + grid[i][j];
                    }
                    else
                    {
                        dp[i, j] = Math.Min(dp[i - 1, j], dp[i, j - 1]) + grid[i][j];
                    }
                }
            }
            return dp[n - 1, m - 1];
        }
    }
}
