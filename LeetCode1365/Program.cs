using System;

namespace LeetCode1365
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            int[] input = {8, 1, 2, 2, 3};

            Console.WriteLine(program.SmallerNumbersThanCurrent3(input));
        }

        public int[] SmallerNumbersThanCurrent(int[] nums)
        {
            var len = nums.Length;
            int[] res = new int[len];
            for (int i = 0; i < len; i++)
            {
                res[i] = SmallerNumbersCount(nums[i], nums);
            }
            return res;
        }

        private int SmallerNumbersCount(int num, int[] nums)
        {
            int count = 0;
            foreach (var i in nums)
            {
                if (num > i)
                {
                    count++;
                }
            }
            return count;
        }

        public int[] SmallerNumbersThanCurrent2(int[] nums)
        {
            int[] record = new int[101];
            foreach (var num in nums)
            {
                record[num]++;
            }
            int[] smallerNums = new int[101];

            for (int i = 1; i < record.Length; i++)
            {
                smallerNums[i] = record[i - 1] + smallerNums[i - 1];
            }

            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = smallerNums[nums[i]];
            }

            return nums;
        }

        public int[] SmallerNumbersThanCurrent3(int[] nums)
        {
            int[] newNums = new int[nums.Length];
            Array.Copy(nums, newNums, nums.Length);
            Array.Sort(nums);
            int[] res = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                res[i] = Array.IndexOf(nums, newNums[i]);
            }
            return res;
        }
    }
}
