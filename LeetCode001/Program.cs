using System.Collections.Generic;

namespace LeetCode001
{
    class Program
    {
        public static void Main(string[] args)
        {
            
        }
        public class Solution
        {
            public int[] TwoSums(int[] nums, int target)
            {
                Dictionary<int, int> dict = new Dictionary<int, int>();
                int[] results = new int[2];

                for (int i = 0; i < nums.Length; i++)
                {
                    if (dict.ContainsKey(target - nums[i]))
                    {
                        results[0] = dict[target - nums[i]];
                        results[1] = i;
                        return results;
                    }
                    else
                    {
                        dict[target - nums[i]] = i;
                    }
                }
                return null;
            }
        }
    }
}


