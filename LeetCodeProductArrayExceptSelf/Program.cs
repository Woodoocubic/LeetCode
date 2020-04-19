using System;

namespace LeetCodeProductArrayExceptSelf
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int[] ProductExceptSelf(int[] nums)
        {
            int n = nums.Length;
            int[] res = new int[n];
            int prod = 1;

            for (int i = 0; i < n; i++)
            {
                res[i] = prod;
                prod *= nums[i];
            }

            int afterProd = 1;
            for (int i = n-1; i >=0; i--)
            {
                res[i] *= afterProd;
                afterProd *= nums[i];
            }

            return res;
        }
    }
}
