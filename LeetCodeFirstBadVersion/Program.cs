using System;

namespace LeetCodeFirstBadVersion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public bool IsBadVersion(int n)
        {
            return true;
        }
        public int FirstBadVersion(int n)
        {
            var start = 1;
            var end = n;
            while (start<end)
            {
                var mid = start + (end - start) / 2;
                if (IsBadVersion(mid))
                {
                    end = mid;
                }
                else
                {
                    start = mid + 1;
                }
            }

            return start;
        }
    }
}
