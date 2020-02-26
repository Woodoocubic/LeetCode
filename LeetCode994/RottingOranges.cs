using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCode994
{
    public class RottingOranges
    {
        private int row = 0;
        private int column = 0;
        private int freshOrangeCount = 0;
        private int rottenOrangeCount = 0;
        private int minute = 0;
        private Queue<int[]> queue = new Queue<int[]>();
        private int[,] tagGrid;

        public void BFS(int[][] grid)
        {
            var rottingList = new List<int[]>();

            while (queue.Count>0)
            {
                while (queue.Count>0)
                {
                    var orange = queue.Dequeue();
                    int i = orange[0];
                    int j = orange[1];

                    int i_new = -1;
                    int j_new = -1;

                    //up
                    i_new = i - 1;
                    j_new = j;
                    if (i_new >= 0 && tagGrid[i_new, j_new] == 0 && grid[i_new][j_new] == 1)
                    {
                        freshOrangeCount--;
                        rottenOrangeCount++;
                        tagGrid[i_new, j_new] = 1;
                        grid[i_new][j_new] = 2;
                        rottingList.Add(new int[] {i_new, j_new});
                    }

                    //down
                    i_new = i + 1;
                    j_new = j;
                    if (i_new <= row - 1 && tagGrid[i_new, j_new] == 0 && grid[i_new][j_new] == 1)
                    {
                        freshOrangeCount--;
                        rottenOrangeCount++;
                        tagGrid[i_new, j_new] = 1;
                        grid[i_new][j_new] = 2;
                        rottingList.Add(new int[] {i_new, j_new});
                    }

                    //left: j-1 >=0
                    i_new = i;
                    j_new = j - 1;
                    if (j_new >= 0 && tagGrid[i_new, j_new] == 0 && grid[i_new][j_new] == 1)
                    {
                        freshOrangeCount--;
                        rottenOrangeCount++;
                        tagGrid[i_new, j_new] = 1;
                        grid[i_new][j_new] = 2;
                        rottingList.Add(new int[] {i_new, j_new});
                    }

                    //right: j+1 <= column-1;
                    i_new = i;
                    j_new = j + 1;
                    if (j_new <= column - 1 && tagGrid[i_new, j_new] == 0 && grid[i_new][j_new] == 1)
                    {
                        freshOrangeCount--;
                        rottenOrangeCount++;
                        tagGrid[i_new, j_new] = 1;
                        grid[i_new][j_new] = 2;
                        rottingList.Add(new int[] {i_new, j_new});
                    }
                }

                if (rottingList.Any())
                {
                    minute++;
                }

                foreach (var item in rottingList)
                {
                    queue.Enqueue(item);
                }
                rottingList.Clear();
            }
        }

        public int OrangesRotting(int[][] grid)
        {
            row = grid.Length;
            column = grid[0].Length;
            tagGrid = new int[row, column];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    tagGrid[i, j] = 0;
                    if (grid[i][j] == 1)
                    {
                        freshOrangeCount++;
                    }

                    if (grid[i][j] == 2)
                    {
                        rottenOrangeCount++;
                        queue.Enqueue(new int[] {i, j});
                    }
                }
            }

            BFS(grid);

            if (freshOrangeCount !=0)
            {
                return -1;
            }
            else
            {
                return minute;
            }
        }
    }
}
