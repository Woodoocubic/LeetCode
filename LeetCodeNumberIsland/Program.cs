using System;

namespace LeetCodeNumberIsland
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int NumIslands(char[][] grid)
        {
            if (grid == null || grid.Length == 0 || grid[0].Length == 0)
            {
                return 0;
            }

            int islandCount = 0;
            var rows = grid.Length;
            var columns = grid[0].Length;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    var current = grid[row][col];
                    if (current == '0')
                    {
                        continue;
                    }

                    RunDepthFirstSearch(grid, row, col, rows, columns);
                    islandCount++;
                }
            }

            return islandCount;
        }

        private static void RunDepthFirstSearch(char[][] grid, int row, int col, int rows, int columns)
        {
            if (!(row<rows && row>=0 && col< columns && col >=0))
            {
                return;
            }

            if (grid[row][col] != '1')
            {
                return;
            }

            grid[row][col] = '0';

            RunDepthFirstSearch(grid, row, col-1, rows, columns);
            RunDepthFirstSearch(grid, row, col+1, rows, columns);
            RunDepthFirstSearch(grid, row-1, col, rows, columns);
            RunDepthFirstSearch(grid, row+1, col, rows, columns);
        }
    }
}
