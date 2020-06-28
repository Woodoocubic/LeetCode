using System;
using System.Collections;
using System.Collections.Generic;

namespace LeetCode1475
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int[] FinalPrices(int[] prices)
        {
            var length = prices.Length;
            for (int i = 0; i < length; i++)
            {
                for (int j = i+1; j < length; j++)
                {
                    if (prices[j] < prices[i] )
                    {
                        prices[i] = prices[i] - prices[j];
                        break;
                    }
                }
            }

            return prices;
        }

        public int[] FinalPrices2(int[] prices)
        {
            var stack = new Stack<int>();
            for (int i = 0; i < prices.Length; i++)
            {
                while (stack.Count !=0 && prices[stack.Peek()] >= prices[i])
                {
                    prices[stack.Peek()] -= prices[i];
                    stack.Pop();
                }
                stack.Push(i);
            }

            return prices;
        }
    }
}
