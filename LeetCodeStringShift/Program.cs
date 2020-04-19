using System;
using System.Xml;

namespace LeetCodeStringShift
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            var inputString = "abc";
            int[][] shifts = new int[][]
            {
                new int[]{0,1},
                new int[]{1,2}, 
            };
            Console.WriteLine(program.StringShift1(inputString, shifts));
        }

        public string StringShift(string s, int[][] shifts)
        {
            var originS = s.ToCharArray();
            var len = originS.Length;
            var changeS =new char[len];
            foreach (var nums in shifts)
            {
                var temp = shifts[0] == nums ? originS : changeS;

                if (nums[0] == 0)
                {
                    
                    for (int i=0; i<len; i++)
                    {
                        var position =(i + nums[1]) % len;
                        changeS[position] = temp[i];
                    }
                }
                if (nums[0] == 1)
                {
                    for (int i = 0; i < len; i++)
                    {
                        var position = Math.Abs(i-nums[1]) % len;
                        changeS[position] = temp[i];
                    }
                }
            }

            return new string(changeS);
        }

        public string StringShift1(string s, int[][] shifts)
        {
            var originS = s.ToCharArray();
            var len = s.Length;

            int totalShift = 0;
            foreach (var rotate in shifts)
            {
                if (rotate[0] == 0)
                {
                    totalShift -= rotate[1];
                    if (totalShift < -len)
                    {
                        totalShift += len;
                    }
                }
                else
                {
                    totalShift += rotate[1];
                    if (totalShift >= len)
                    {
                        totalShift -= len;
                    }
                }
            }

            if (totalShift >= 0)
            {
                Rotate(originS, totalShift);
            }
            else
            {
                Rotate(originS, len + totalShift);
            }
            return new string(originS);
        }

        private void Reverse(char[] charArray, int left, int right)
        {
            while (left < right)
            {
                Swap(charArray, left, right);
                left++;
                right--;
            }
        }

        private void Swap(char[] charArray, int index1, int index2)
        {
            char temp = charArray[index1];
            charArray[index1] = charArray[index2];
            charArray[index2] = temp;
        }

        public void Rotate(char[] charArray, int k)
        {
            int len = charArray.Length;
            if (len == 0 || k%len == 0)
            {
                return;
            }

            k = k % len;

            Reverse(charArray, 0, len-k-1);
            Reverse(charArray, len-k, len-1);
            Reverse(charArray, 0, len-1);
        }
    }


}
