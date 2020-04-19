using System;

namespace LeetCodeBuySellStock2
{
    class Program
    {
        static void Main(string[] args)
        {
            var program =new Program();
            int[] prices = new int[] {7, 1, 5, 3, 6, 4};
            var profit = program.MaxProfit(prices);

            Console.WriteLine(profit);
        }

        public int MaxProfit(int[] prices)
        {
            var length = prices.Length;
            if (length == 0)
            {
                return 0;
            }

            var profit = 0;
            for (int i = 1; i < length; i++)
            {
                if (prices[i-1] < prices[i])
                {
                    profit += prices[i] - prices[i - 1];
                }
            }

            return profit;
        }
    }
}
