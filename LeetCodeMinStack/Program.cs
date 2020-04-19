using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LeetCodeMinStack
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();

            Console.WriteLine("Hello World!");
        }

        #region Anwser One
        public class MinStack
        {
            private Stack<int> stack1 { get; set; }
            private Stack<int> stackForMinimums { get; set; }

            public MinStack()
            {
                stack1 = new Stack<int>();
                stackForMinimums = new Stack<int>();
            }

            public void Push(int x)
            {
                if (stackForMinimums.Count == 0 || x < GetMin())
                {
                    stackForMinimums.Push(x);
                }
                stack1.Push(x);
            }

            public void Pop()
            {
                var value = stack1.Peek();
                if (value == GetMin())
                {
                    stackForMinimums.Pop();
                }

                stack1.Pop();
            }

            public int Top()
            {
                return stack1.Peek();
            }

            public int GetMin()
            {
                if (stackForMinimums.Count > 0)
                {
                    return stackForMinimums.Peek();
                }
                else
                {
                    return 0;
                }
            }
        }


        #endregion

        #region MyRegion

        

        #endregion
    }
}
