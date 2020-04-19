using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeCountingElements
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            var input =new int[]{ 1,1,2,2 } ;
            Console.WriteLine(program.CountElements(input));
        }

        public int CountElements(int[] arr)
        {
            int count = 0;
            Dictionary<int, int> dupli = new Dictionary<int, int>();
            HashSet<int> hashArr = new HashSet<int>();
            foreach (var item in arr)
            {
                if (!hashArr.Contains(item))
                {
                     hashArr.Add(item);
                     dupli.Add(item, 1);
                }
                else
                {
                    dupli[item]++;
                }
                
            }

            foreach (var num in hashArr)
            {
                if (hashArr.Contains(num+1))
                {
                    count+=count+dupli[num];
                }
            }

            return count;
        }
    }
}
