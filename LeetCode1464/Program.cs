using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace LeetCode1464
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            Console.WriteLine("Hello World!");
        }

        public int MaxProduct(int[] nums)
        {
            var numsDic = new Dictionary<int, int>();
            int index = 0;
            foreach (var item in nums)
            {
                numsDic[index] = item;
                index++;
            }
            var i = numsDic.Values.Max();
            //while (numsDic.ContainsValue(i))
            //{
            //    var getTheKeyOfMax = numsDic.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
            //    numsDic.Remove(getTheKeyOfMax);
            //}
            //var getTheKeyOfMax = numsDic.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
            int getTheKeyOfMax = numsDic.FirstOrDefault(x => x.Value == i).Key;
            numsDic.Remove(getTheKeyOfMax);
            var j = numsDic.Values.Max();
            return (i-1) * (j-1);
        }

        public int MaxProduct2(int[] nums)
        {
            int i = nums.Max();
            int iIdx = Array.IndexOf(nums, i);
            List<int> tmp = new List<int>(nums);
            tmp.RemoveAt(iIdx);
            int[] newNums = tmp.ToArray();
            var j = newNums.Max();
            return (i - 1) * (j - 1);
        }

        public int MaxProduct3(int[] nums)
        {
            int[] maxTwo = nums.OrderByDescending(x => x).Take(2).ToArray();
            return (maxTwo[0] - 1) * (maxTwo[1] - 1);
        }
    }
}
