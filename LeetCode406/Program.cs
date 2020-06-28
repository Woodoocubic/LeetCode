using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace LeetCode406
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] input = new int[6][];
            input[0] = new[] { 7, 0 };
            input[1] = new[] { 4, 4 };
            input[2] = new[] { 7, 1 };
            input[3] = new[] { 5, 0 };
            input[4] = new[] { 6, 1 };
            input[5] = new[] { 5, 2 };

            
            var output = ReconstructQueue2(input);

            Console.WriteLine(output.ToString());
        }

        public int[][] ReconstructQueue(int[][] people)
        {
            int n = people.Length;
            IList<int[]> result = new List<int[]>();
            Array.Sort(people, (a, b)=>
                    a[0] == b [0] ?
                        a[1] - b[1] :
                        b[0] - a[0]);
            foreach (int[] person in people)
            {
                result.Insert(person[1], person);
            }

            return result.ToArray();
        }

        public static int[][] ReconstructQueue2(int[][] people)
        {
            List<int[]> res = new List<int[]>();
            var sortedPeople = people.ToList().OrderByDescending(x => x[0]).ThenBy(x => x[1]);

            foreach (var person in sortedPeople)
            {
                Console.WriteLine(person[1]);
                res.Insert(person[1], person);                
            }

            return res.ToArray();
        }

        public int[][] ReconstructQueue3(int[][] people)
        {
            SortedSet<Team> ordered_queue = new SortedSet<Team>();
            foreach (int[] pair in people)
            {
                ordered_queue.Add(new Team() {h = pair[0], k = pair[1]});
            }
            List<Team> result = new List<Team>();

            foreach (var pair in ordered_queue)
            {
                if (result.Count() == 0)
                {
                    result.Add(new Team(){h = pair.h, k=pair.k});
                    continue;
                }

                int j = 0;
                for (int i = 0; i < result.Count(); i++)
                {
                    if (pair.k == 0)
                    {
                        j = 0;
                        break;
                    }

                    if (result[i].h >= pair.h)
                    {
                        j = pair.k;
                        break;
                    }
                }
                result.Insert(j, new Team(){h = pair.h, k = pair.k});
            }
            return result.Select(t => (new int[]{t.h, t.k})).ToArray();
        }

    }

    class Team : IComparable<Team>
    {
        public int h { get; set; }
        public int k { get; set; }

        public int CompareTo(Team other)
        {
            if (this.h == other.h)
            {
                return this.k.CompareTo(other.k);
            }

            return other.h.CompareTo(this.h);
        }
    }
}
