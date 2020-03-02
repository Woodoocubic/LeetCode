using System;
using System.Collections.Generic;

namespace LeetCode1156
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            string input = "aaababba";

            Console.WriteLine(program.MaxReOpt1(input));
        }


        public int MaxReOpt1(string text)
        {
            Dictionary<char, int> countText = new Dictionary<char, int>();
            int len = text.Length;
            for (int i = 0; i < len; i++)
            {
                char key = text[i];
                if (countText.ContainsKey(key))
                {
                    countText[key] = countText[key] + 1;
                }
                else
                {
                    countText.Add(key, 1);
                }
            }
            if (countText.Count == 1)
            {
                return len;
            }
            int max = 0;
            foreach (var item in countText)
            {
                char ch = item.Key;
                int total = item.Value;
                for (int i = 0; i < len; i++)
                {
                    int count = 0;
                    for (int j = i; j < len; j++)
                    {
                        char cur = text[j];
                        if (ch != cur && count + 1 == j - i)
                        {
                            break;
                        }

                        if (ch == cur && (count == j - i || count + 1 == j - i))
                        {
                            count++;
                        }
                    }
                    if (count < total)
                    {
                        count++;
                    }
                    max = Math.Max(max, count);
                }
            }
            return max;
        }
    }
}
