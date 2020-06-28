using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode1189
{
    class Program
    {
        static void Main(string[] args)
        {
            var prg = new Program();
            string input = "lllooo";
            int output = prg.MaxNumberOfBalloons2(input);
            Console.WriteLine(output);
        }

        public int MaxNumberOfBalloons(string text)
        {
            var target = "ballono";
            var targetDic = new Dictionary<char, int>();
            var textDic = new Dictionary<char, int>();
            foreach (var item in target)
            {
                targetDic[item] = targetDic.ContainsKey(item) ? targetDic[item]+1: 1;
                textDic[item] = 0;
            }

            foreach (var item in text)
            {
                if (targetDic.ContainsKey(item))
                {
                    textDic[item]++;
                }
            }

            return targetDic.Min(p => textDic[p.Key] / p.Value);
        }

        public int MaxNumberOfBalloons2(string text)
        {
            var count = new int[5];
            foreach (var item in text)
            {
                switch (item)
                {
                    case 'a':
                        count[0]++;
                        break;
                    case 'b':
                        count[1]++;
                        break;
                    case 'l':
                        count[2]++;
                        break;
                    case 'o':
                        count[3]++;
                        break;
                    case 'n':
                        count[4]++;
                        break;
                }
            }

            count[2] /= 2;
            count[3] /= 2;

            return count.Min();
        }
    }
}
