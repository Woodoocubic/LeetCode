using System;
using System.ComponentModel.Design;
using System.Linq;

namespace LeetCode287
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int FindDuplicate(int[] nums)
        {
            int li = 1, hi = nums.Length;
            while (li < hi)
            {
                int mid = li + (hi - li) / 2;
                int count = nums.Count(x => x <= mid);
                if (count > mid)
                {
                    hi = mid;
                }
                else
                {
                    li = mid + 1;
                }
            }
            return li;
        }

        public int FindDuplicate_2(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                while (nums[i] - 1 !=i)
                {
                    var tempIndex = nums[i] - 1;
                    if (nums[tempIndex] == nums[i])
                    {
                        break;
                    }

                    nums[i] = nums[tempIndex];
                    nums[tempIndex] = tempIndex + 1;
                }
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (i != nums[i] - 1)
                {
                    return nums[i];
                }
            }
            throw new Exception("never reach");
        }

        public int FindDuplicate_3(int[] nums)
        {
            int fp, sp, init;
            init = nums[0];
            sp = nums[init];
            fp = nums[nums[init]];
            while (sp != fp)
            {
                sp = nums[sp];
                fp = nums[nums[fp]];
            }
            sp = init;
            while (sp != fp)
            {
                sp = nums[sp];
                fp = nums[fp];
            }

            return sp;
        }

        public int FindDuplicat_4(int[] nums)
        {
            int start, stop, len, mid, lesscounter, equalcounter;
            start = 1;
            stop = nums.Length;
            while (stop >= start)
            {
                mid = start + (stop - start) / 2;
                lesscounter = equalcounter = 0;
                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] == mid)
                    {
                        equalcounter++;
                    }
                    else if (nums[i] < mid)
                    {
                        lesscounter++;
                    }
                }

                if (equalcounter > 1)
                {
                    return mid;
                }
                else
                {
                    if (lesscounter > mid - 1)
                    {
                        stop = mid - 1;
                    }
                    else {
                        if (lesscounter > mid-1)
                        {
                            stop = mid - 1;
                        }
                        else
                        {
                            start = mid + 1;
                        }
                    }
                }
            }
        }
    }
}
