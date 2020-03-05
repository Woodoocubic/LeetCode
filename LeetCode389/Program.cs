using System;

namespace LeetCode389
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            string inputOne = "abcd";
            string inputTwo = "abcde";
            Console.WriteLine(program.FindTheDifference(inputOne, inputTwo));
        }

        public char FindTheDifference(string s, string t)
        {
            int res = 0;
            foreach (var item in s+t)
            {
                res = item ^ res;
            }

            return (char)res;
        }
    }
}
