using System;

namespace LeetCode540
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            int[] input = new[] {1, 1, 2, 3, 3, 4, 4, 8, 8};

            Console.WriteLine(program.SingleNonDuplicate(input));
        }

        public int SingleNonDuplicate(int[] nums)
        {
            int left = 0;
            int right = nums.Length - 1;

            while (left < right)
            {
                int mid =(left + right) / 2;
                if (nums[mid] != nums[mid-1] && nums[mid] != nums[mid+1])
                {
                    return nums[mid];
                }

                if (mid%2 == 0 && nums[mid] == nums[mid+1])
                {
                    left = mid + 1;
                }

                if (mid% 2 == 1 && nums[mid] == nums[mid-1])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return nums[left];
        }
    }
}
