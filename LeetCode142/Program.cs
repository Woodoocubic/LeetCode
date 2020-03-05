using System;
using System.Collections.Generic;

namespace LeetCode142
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var program = new Program();

            Console.WriteLine("Hello World!");
        }

        public ListNode DetectCycle(ListNode head)
        {
            ListNode p1 = head;
            ListNode p2 = head;
            bool hasCycle = false;
            if (p1 == null)
            {
                return null;
            }
            while (p2.next != null && p2.next.next != null )
            {
                p1 = p1.next;
                p2 = p2.next.next;
                if (p1 == p2)
                {
                    hasCycle = true;
                    break;
                }
            }

            if (hasCycle)
            {
                ListNode q = head;
                while (p1 != q)
                {
                    q = q.next;
                    p1 = p1.next;
                }

                return q;
            }
            else
            {
                return null;
            }
            
        }

        public class ListNode
        {
            public int val;
            public ListNode next;

            public ListNode(int x)
            {
                val = x;
                next = null;
            }
        }
    }
}
