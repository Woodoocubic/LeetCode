using System;

namespace LeetCode1342
{
    class Program
    {
        static void Main(string[] args)
        {
            var program =new Program();


            Console.WriteLine(program.NumberOfSteps(14));
        }

        public int NumberOfSteps(int num)
        {
            int count = 0;
            while (num != 0)
            {
                if (num %2 == 0)
                {
                    num = num / 2;
                    count++;
                }
                else
                {
                    num = num - 1;
                    count++;
                }
            }
            return count;
        }
    }


}
