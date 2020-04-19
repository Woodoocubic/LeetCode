using System;
using System.Collections.Generic;
using System.Globalization;

namespace LeetCodeContiguousArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            var input = new int[]{0, 1, 0, 0};
            Console.WriteLine(program.FindMaxLength(input));
        }

        public int FindMaxLength(int[] nums)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int count = 0;
            int maxLength = 0;
            for (int i=0; i < nums.Length; i++)
            {
                if (nums[i] == 1) count++;
                if (nums[i] == 0) count--;

                if (dict.ContainsKey(count))
                {
                    maxLength = Math.Max(maxLength, i - dict[count]);
                }
                else
                {
                    dict[count] = i;
                }

                if (count == 0)
                {
                    maxLength = i + 1;
                }
            }

            return maxLength;
        }

        public int FindMaxLength1(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            var d = new Dictionary<int, int>();
            d.Add(0, -1);
            int max = 0, sum = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    nums[i] = -1;
                }

                sum += nums[i];
                if (d.ContainsKey(sum))
                {
                    max = i - d[sum] > max ? i - d[sum] : max;
                }
                else
                {
                    d.Add(sum, i);
                }
                
            }

            return max;
        }
    }
}
