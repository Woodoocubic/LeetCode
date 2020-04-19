using System;

namespace LeetCodeMaxSubarray
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            int[] nums = new Int32[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
            
            Console.WriteLine(program.MaxSubArray(nums));
        }

        public int MaxSubArray(int[] nums)
        {
            if (nums == null)
            {
                return 0;
            }

            var prefixSum = getPrefixSum(nums);
            var minimumSofar = 0;
            var max = int.MinValue;
            for (int i = 0; i < nums.Length; i++)
            {
                var current = prefixSum[i];
                var currentMax = current - minimumSofar;

                max = max < currentMax ? currentMax : max;
                minimumSofar = minimumSofar > current ? current : minimumSofar;
            }

            return max;
        }

        private static int[] getPrefixSum(int[] nums)
        {
            var length = nums.Length;
            var prefixSum = new int[length];

            for (int i = 0; i < length; i++)
            {
                prefixSum[i] = i > 0 ? prefixSum[i - 1] : 0;
                prefixSum[i] += nums[i];
            }

            return prefixSum;
        }
    }
}
