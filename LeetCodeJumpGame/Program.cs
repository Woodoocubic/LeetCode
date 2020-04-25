using System;

namespace LeetCodeJumpGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            int[] input = new[] {3, 2, 1, 0, 4};
            Console.WriteLine(program.CanJump(input));
        }

        public bool CanJump(int[] nums)
        {
            if (nums.Length == 0)
            {
                return false;
            }

            if (nums.Length == 1)
            {
                return true;
            }

            var preMax = nums[0];

            if (preMax == 0)
            {
                return false;
            }

            for (int i = 1; i < nums.Length; i++)
            {
                var cur = Math.Max(preMax - 1, nums[i]);
                if (cur == 0)
                {
                    if (i == nums.Length-1)
                    {
                        return true;
                    }
                    return false;
                }

                preMax = cur;
            }

            return true;
        }
    }
}
