using System;
using System.Collections;
using System.Collections.Generic;
using LeetCodeLeftMostColWithALeastOne;

namespace LeetCodeLeftMostColWithALeastOne
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int LeftfMostColumnWithOne(BinaryMatrix binaryMatrix)
        {
            var row = binaryMatrix.Dimensions()[0];
            var col = binaryMatrix.Dimensions()[1];
            var mostLeft = col;
            for (int r = 0; r < row; r++)
            {
                int li = 0, hi = col - 1;
                while (li < hi)
                {
                    int mid = li + (hi - li) / 2;
                    if (binaryMatrix.Get(r, mid)==0)
                    {
                        li = mid + 1;
                    }
                    else
                    {
                        hi = mid;
                    }
                }
                if (binaryMatrix.Get(r, li) == 1)
                {
                    mostLeft = Math.Min(li, mostLeft);
                }
            }

            return mostLeft == col ? -1 : mostLeft;
        }

        public int LeftfMostColumnWithOne2(BinaryMatrix binaryMatrix)
        {
            var row = binaryMatrix.Dimensions()[0];
            var col = binaryMatrix.Dimensions()[1];
            int c = col - 1;
            int r = 0;
            int mostLeft = col;

            while (c >= 0 && r<row)
            {
                if (binaryMatrix.Get(r, c) == 1)
                {
                    c--;
                }
                else
                {
                    r++;
                }

                mostLeft = Math.Min(c + 1, mostLeft);
            }

            return mostLeft == col ? -1 : mostLeft;
        }
    }
}
