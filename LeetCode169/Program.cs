using System;

namespace LeetCode169
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            int[] input = new[] {6, 5, 5};
            Console.WriteLine(program.majorityElement(input));
        }

        public int majorityElement(int[] input)
        {
            int count = 0;
            int maj = input[0];
            for (int i = 0; i < input.Length; i++)
            {
                if (maj == input[i])
                {
                    count++;

                }
                else
                {
                    count--;
                    if (count == 0 )
                    {
                        if (i != input.Length - 1)
                        {
                            maj = input[i + 1];
                        }
                    };
                }
            }
            return maj;
        }
    }
}
