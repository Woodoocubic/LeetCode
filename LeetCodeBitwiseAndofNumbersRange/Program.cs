using System;

namespace LeetCodeBitwiseAndofNumbersRange
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int RangeBitwiseAnd(int n, int m)
        {
            int numBits1 = GetNumBits(m);
            int numBits2 = GetNumBits(n);

            if (numBits1 != numBits2)
            {
                return 0;
            }

            int diffNumBits = GetNumBits(Math.Abs(m - n));
            int mask = (int) (Math.Pow(2, numBits1) - 1);
            mask -= (int) (Math.Pow(2, diffNumBits) - 1);

            return m & n & mask;
        }

        public int GetNumBits(int n)
        {
            int bits = 0;
            while (n>0)
            {
                n = n >> 1;
                ++bits;
            }

            return bits;
        }

        public int RangeBitwiseAnd1(int m, int n)
        {
            int x = 0;
            int len = n - m + 1;
            int y = 0;
            for (int i = 0; i < 31; i++)
            {
                y = y == 0 ? 1 : y << 1;
                if (y < len || y >n)
                {
                    continue;
                }

                int next = y << 1;
                if (m % next >= y && n%next >=y)
                {
                    x |= y;
                }
            }

            return x;
        }

        public int RangeBitwiseAnd2(int m, int n)
        {
            var from = Convert.ToString(m, 2);
            var to = Convert.ToString(n, 2);

            if (from.Length != to.Length)
            {
                return 0;
            }

            var result = 0;
            for (int i = 0; i < from.Length; i++)
            {
                if (from[i] == to[i])
                {
                    if (from[i] == '1')
                    {
                        result += (int) Math.Pow(2, from.Length - 1 - i);
                    }
                }
                else
                {
                    break;
                }
            }

            return result;
        }
    }
}
