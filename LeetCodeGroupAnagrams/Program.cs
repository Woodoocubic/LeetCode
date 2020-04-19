using System;
using System.Collections.Generic;

namespace LeetCodeGroupAnagrams
{
    class Program
    {
        static void Main(string[] args)
        {
            var program =new Program();
            var input = new string[]
            {
                "eat", "tea", "tan", "ate", "nat", "bat"
            };
            Console.WriteLine(program.GroupAnagrams(input));
        }

        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            if (strs==null || strs.Length == 0)
            {
                return new List<IList<string>>();
            }
            var map = new Dictionary<String, IList<string>>();
            foreach (var s in strs)
            {
                char[] ca = s.ToCharArray();
                Array.Sort(ca);

                String keyStr = new string(ca);

                if (!map.ContainsKey(keyStr))
                {
                    map.Add(keyStr,new List<String>());
                }

                map[keyStr].Add(s);
            }

            return new List<IList<string>>(map.Values);
        }
    }
}
