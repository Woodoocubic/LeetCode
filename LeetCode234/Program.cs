using System;

namespace LeetCode234
{
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var prg = new Program();
            Console.WriteLine("Hello World!");
        }

        public bool IsPalindrome(ListNode head)
        {
            if (head.next == null)
            {
                return true;
            }

            var length = getLinkedListLength(head);
            var isEven = length % 2 == 0;
            var back = head;
            var front = getNodeGivenK(head, length / 2);
            if (!isEven)
            {
                front = front.next;
            }

            var reversed = reverseLinkedList(front);
            var index = 0;
            while (index < length / 2)
            {
                if (back.val != reversed.val)
                {
                    return false;
                }

                back = back.next;
                reversed = reversed.next;
                index++;
            }

            return true;
        }

        private static int getLinkedListLength(ListNode head)
        {
            if (head == null)
            {
                return 0;
            }

            var index = 0;
            var iterate = head;

            while (iterate !=null)
            {
                index++;
                iterate = iterate.next;
            }

            return index;
        }

        private static ListNode getNodeGivenK(ListNode head, int k)
        {
            if (k == 0)
            {
                return head;
            }

            int index = 0;
            var iterate = head;
            while (index < k)
            {
                iterate = iterate.next;
                index++;
            }

            return iterate;
        }

        private static ListNode reverseLinkedList(ListNode head)
        {
            if (head == null)
            {
                return null;
            }

            if (head.next == null)
            {
                return null;
            }

            var next = head.next;
            var reversed = reverseLinkedList(next);

            head.next = null;
            next.next = head;

            return reversed;
        }

        public bool IsPalindrome2(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return true;
            }

            ListNode slow = head,
                fast = head,
                rightHalfHead = null;

            while (fast.next !=null && fast.next.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
            }

            rightHalfHead = Reverse(slow.next);
            slow.next = null;
            while (rightHalfHead != null)
            {
                if (head.val != rightHalfHead.val)
                {
                    return false;
                }

                head = head.next;
                rightHalfHead = rightHalfHead.next;
            }

            return true;

        }

        private ListNode Reverse(ListNode head)
        {
            ListNode node1 = null,
                node2 = head,
                node3 = null;
            if (node2 != null)
            {
                node3 = node2.next;
            }

            while (node2 !=null)
            {
                node2.next = node1;

                node1 = node2;
                node2 = node3;
            }

            return node1;
        }
    }
}
