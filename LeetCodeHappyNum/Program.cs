using System;
using System.Collections.Generic;

namespace LeetCodeHappyNum
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(IsHappy(2));
        }

        static bool IsHappy(int n)
        {
            HashSet<int> numList = new HashSet<int>();
            
            while (n != 1)
            {
                if (numList.Contains(n))
                {
                    return false;
                }

                numList.Add(n);
                int newNum = 0;
                while (n > 0)
                {
                    newNum = (n % 10)*(n% 10);
                    //newNum += (int)Math.Pow(n % 10, 2);
                    n = n / 10;
                }

                n = newNum;
            }

            return true;
        }
    }
}
