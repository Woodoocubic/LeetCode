using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode735
{
    class Program
    {
        static void Main(string[] args)
        {
            var prg = new Program();
            int[] input = {5, 10, -5};
            var output = prg.AsteroidCollision(input);
            foreach (var num in output)
            {
                Console.WriteLine(num);
            }
        }

        public int[] AsteroidCollision(int[] asteroids)
        {
            if (asteroids == null || asteroids.Length == 0)
            {
                return null;
            }

            var stack = new Stack<int>();
            stack.Push(asteroids[0]);

            for (int i = 0; i < asteroids.Length; i++)
            {
                while (true)
                {
                    if (stack.Count >0 && stack.Peek() >0 && asteroids[i] <0 )
                    {
                        if (Math.Abs(stack.Peek()) == Math.Abs(asteroids[i]))
                        {
                            stack.Pop();
                            break;
                        }
                        else if(Math.Abs(stack.Peek()) < Math.Abs(asteroids[i]))
                        {
                            stack.Pop();
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        stack.Push(asteroids[i]);
                        break;
                    }
                }
            }

            return stack.Reverse().ToArray();
        }

        public int[] AsteroidCollision_2(int[] asteroids)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < asteroids.Length; i++)
            {
                list.Add(asteroids[i]);
                if (asteroids[i]< 0)
                {
                    for (int j = list.Count-2; j > =0 ; j--)
                    {
                        if (list[j] >0)
                        {
                            if (list[j] < -asteroids[i])
                            {
                                list.RemoveAt(j);
                            }
                            else if (list[j] == -asteroids[i])
                            {
                                list.RemoveAt(j);
                                list.RemoveAt(list.Count - 1);
                                break;
                            }
                            else
                            {
                                list.RemoveAt(list.Count -1);
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            return list.ToArray();
        }
    }
}
