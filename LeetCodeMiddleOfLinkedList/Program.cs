using System;

namespace LeetCodeMiddleOfLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();

            Console.WriteLine("Hello World!");
        }

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public ListNode MiddleNode(ListNode head)
        {
            if (head == null)
            {
                return null;
            }

            var length = GetLength(head);
            if (length == 0)
            {
                return null;
            }

            var index = 0;
            var node = head;
            ListNode middle = null;
            while (index <= length/2)
            {
                index++;
                middle = node;
                node = node.next;
            }

            return middle;
        }

        private int GetLength(ListNode head)
        {
            var length = 0;
            var temp = head;
            while (temp != null)
            {
                length++;
                temp = temp.next;
            }

            return length;
        }
    }
}
