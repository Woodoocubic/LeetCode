using System;
using System.Collections.Generic;

namespace LeetCodeBackspaceCompare
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            string inputS = "a#c";
            string inputT = "b";
            var result = program.BackspaceCompare(inputS, inputT);
            Console.WriteLine(result);
        }

        public bool BackspaceCompare(string S, string T)
        {
            if (S == null || T == null)
            {
                return false;
            }

            var appliedS = ApplyBackspace(S);
            var appliedT = ApplyBackspace(T);

            return appliedT == appliedS;
        }

        private string ApplyBackspace(string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                return input;
            }
            Stack<char> sta = new Stack<char>();
            foreach (var item in input)
            {
                bool isBackspace = item == '#';
                if (isBackspace && sta.Count > 0)
                {
                    sta.Pop();
                    continue;
                }

                if (!isBackspace)
                {
                    sta.Push(item);
                }
            }

            return new string(sta.ToArray());
        }
    }
}
