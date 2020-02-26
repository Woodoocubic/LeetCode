using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LeetCode994
{
    class Program
    {
        public class Solution
        {
            public int OrangeRotting(int[][] grid)
            { 
                int[] horiDirec = new int[]{ 1, -1, 0, 0};
                int[] vertDirec = new int[]{ 0, 0, 1, -1};
                List<int[]> rotList = new List<int[]>();
                int minute = 0;

                for (int i = 0; i < grid.GetLength(1) ; i++)
                {
                    for (int j = 0; j < grid.GetLength( 0); j++)
                    {
                        if (grid[i][j] == 2)
                        {
                            rotList.Add(new int[] {i,j});
                        }
                    }
                }

                int size = rotList.Count();
                while (size-- !=0 )
                {
                    List<int[]> newRotList = new List<int[]>();
                    foreach (var node in rotList)
                    {
                        int x0 = node[0];
                        int y0 = node[1];
                        for (int k = 0; k < 4; k++)
                        {
                            int x = x0 + horiDirec[k];
                            int y = y0 + vertDirec[k];

                            bool xRange = x >= 0 && x < grid.GetLength(0);
                            bool yRange = y >= 0 && y < grid.GetLength(1);
                            if (xRange && yRange && grid[x][y]==1)
                            {
                                grid[x][y] = 2;
                                newRotList.Add(new int[]{x,y});
                            }
                        }
                    }

                    if (!newRotList.Any())
                    {
                        break;
                    }

                    minute++;
                }

                foreach (var item in grid)
                {
                    foreach (var num in item)
                    {
                        if (num ==1) {return -1;}
                    }
                }

                return minute;
            }
        }
    }
}
