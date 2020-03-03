using System;

namespace LeetCode278
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello World!");
        }

        public int FirstBadVersion(int n)
        {
            int lo = 1;
            int hi = n;
            while (lo < hi)
            {
                int mid = lo + (hi - lo) / 2;
                if (IsBadVersion(mid))
                {
                    hi = mid;
                }
                else
                {
                    lo = mid + 1;
                }
            }

            return hi;
        }
    }
}
