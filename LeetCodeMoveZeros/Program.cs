using System;

namespace LeetCodeMoveZeros
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            int[] input = new int[] { 0, 1, 0, 3, 12};
            program.MoveZeroes(input);
            Console.WriteLine(input);
        }

        public void MoveZeroes(int[] nums)
        {
            var n = nums.Length;
            var zeroIndex = 0;
            for (int i = 0; i < n; i++)
            {
                if (nums[i] !=0)
                {
                    var temp = nums[i];
                    nums[i] = nums[zeroIndex];
                    nums[zeroIndex] = temp;
                }

                if (nums[zeroIndex] != 0)
                {
                    zeroIndex++;
                }
            }
        } 
    }
}
