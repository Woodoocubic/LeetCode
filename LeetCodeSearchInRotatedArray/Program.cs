using System;

namespace LeetCodeSearchInRotatedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int Search(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
            {
                return -1;
            }

            var pivot = findPivotIndex(nums);
            var result = runBinarySearch(nums, 0, pivot - 1, target);
            if (result > 0)
            {
                return result;
            }

            result = runBinarySearch(nums, pivot, nums.Length - 1, target);
            return result;
        }

        public static int runBinarySearch(int[] nums, int start, int end, int target)
        {
            if (start > end || target < nums[start] || target > nums[end])
            {
                return -1;
            }

            while (start <= end)
            {
                int middle = start + (end - start) / 2;
                int middleValue = nums[middle];
                if (middleValue == target)
                {
                    return middle;
                }

                if (target >= nums[start] && target < nums[middle])
                {
                    end = middle - 1;
                }
                else
                {
                    start = middle + 1;
                }
            }

            return -1;
        }

        private static int findPivotIndex(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
            {
                return -1;
            }

            int start = 0;
            int length = numbers.Length;
            int end = length - 1;

            while (start <= end)
            {
                int middle = start + (end - start) / 2;

                if (middle + 1 < length && numbers[middle] > numbers[middle+1])
                {
                    return middle + 1;
                }
                else if(middle - 1>=0 && numbers[middle - 1] > numbers[middle])
                {
                    return middle;
                } 
                else if (numbers[start]<=numbers[middle])
                {
                    start = middle + 1;
                }
                else if(numbers[middle] <= numbers[end])
                {
                    end = middle - 1;
                }
            }

            return 0;
        }
    }
}
