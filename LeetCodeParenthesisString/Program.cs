using System;
using System.Xml.Serialization;

namespace LeetCodeParenthesisString
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public bool CheckValidString(string s)
        {
            int left = 0, any=0, needRight = 0;
            foreach (char c in s)
            {
                if (c == '(')
                {
                    left++;
                    needRight++;
                }
                else if (c == '*')
                {
                    any++;
                    if (needRight > 0)
                    {
                        needRight--;
                    }
                }
                else
                {
                    if (left>0)
                    {
                        left--;
                        if (needRight > 0)
                        {
                            needRight--;
                        }
                    }
                    else if (any > 0)
                    {
                        any--;
                    }
                    else
                    {
                        return false;
                    }
                }
                
            }

            return needRight == 0;
        }

        public bool CheckValidString1(string s)
        {
            int min = 0, max = 0;
            foreach (var c in s)
            {
                if (c == '(')
                {
                    min++;
                    max++;
                } else if (c == ')')
                {
                    min--;
                    max--;
                }
                else
                {
                    min--;
                    max++;
                }

                if (max < 0) return false;
                min = Math.Max(min, 0);
            }

            return min == 0;
        }
    }
}
